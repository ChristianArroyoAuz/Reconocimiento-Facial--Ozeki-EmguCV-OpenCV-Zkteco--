/*************************************************************************************************************************
**                                                                                                                      **
**                                         ESCUELA POLITÉCNICA NACIONAL                                                 **
**                                                                                                                      **
**                                  FACULTAD DE INGENIERÍA ÉLECTRICA Y ELECTRÓNICA                                      **
**                                                                                                                      **
**        DESARROLLO DE UN SISTEMA PROTOTIPO DE ACCESO A LOS LABORATORIOS DE REDES DE LA FACULTAD DE INGENIERÍA         **
**        ELÉCTRICA Y ELECTRÓNICA(FIEE) DE LA ESCUELA POLITÉCNICA NACIONAL(EPN) BASADO EN RECONOCIMIENTO FACIAL         **
**                                                                                                                      **
**     TRABAJO DE TITULACIÓN PREVIO A LA OBTENCIÓN DEL TÍTULO DE INGENIERO EN “ELECTRÓNICA Y REDES DE INFORMACIÓN”      **
**                                                                                                                      **
**                                         ARROYO AUZ CHRISTIAN XAVIER                                                  **
**                                         christian.arroyo@epn.edu.ec                                                  **
**                                                                                                                      **
**                              DIRECTOR:  MSC.CALDERÓN HINOJOSA XAVIER ALEXANDER                                       **
**                                         xavier.calderon@epn.edu.ec                                                   **
**                                                                                                                      **
**                                              Quito, mayo 2019                                                        **
**                                                                                                                      **
*************************************************************************************************************************/


using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.ServiceModel;
using System.Collections;
using AxZKFPEngXControl;
using Emgu.CV.Structure;
using System.Threading;
using System.IO.Ports;
using System.Drawing;
using Emgu.CV.CvEnum;
using ObjetoRemoto;
using Ozeki.Camera;
using Ozeki.Media;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using Emgu.CV;
using System;

namespace Cliente
{
    public partial class Sistema_Seguridad_FIEE : Form
    {
        private ChannelFactory<IObjetoRemoto> canal = new ChannelFactory<IObjetoRemoto>(new NetTcpBinding(), "net.tcp://localhost:8080");
        private ObjetoRemoto.ObjetoRemoto objetoremotoUsuario = new ObjetoRemoto.ObjetoRemoto();
        private List<Image<Gray, byte>> imagenesEntrenamiento = new List<Image<Gray, byte>>();
        private MCvFont letra = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        private List<VideoViewerWF> listaVideoSalas = new List<VideoViewerWF>();
        private List<Eventos_Camara> listaEventos = new List<Eventos_Camara>();
        private List<Usuarios> recibirDatosUsuario = new List<Usuarios>();
        private CameraURLBuilderWF urlCamara = new CameraURLBuilderWF();
        private List<string> tecladosConectados = new List<string>();
        private List<string> lectoresConectados = new List<string>();
        private List<string> recuperarTeclados = new List<string>();
        private List<string> recuperarLectores = new List<string>();
        private VideoViewerWF videoSalaActual = new VideoViewerWF();
        private Eventos_Camara eventoActual = new Eventos_Camara();
        private List<Logs> recibirDatosEventos = new List<Logs>();
        private AxZKFPEngX dispositivoDactilar = new AxZKFPEngX();
        private List<string> nombresUsuarios = new List<string>();
        private List<string> nombrePersonas = new List<string>();
        private List<string> usuariosCRUD = new List<string>();
        private List<string> listaCamaras = new List<string>();
        private Thread servidor = new Thread(Servidor.Main);
        private List<string> teclados = new List<string>();
        private List<string> lectores = new List<string>();
        private Image<Gray, byte> escalaGrises = null;
        private SerialPort arduino = new SerialPort();
        private Eventos_Teclado dispositivoTeclado;
        private string rutaNombresEntrenamiento;
        private string[] nombresEntrenamiento;
        private Image<Bgr, byte> videoRostro;
        private string apellidoAdministrador;
        private Image<Gray, byte> imagenGris;
        private bool videoIniciado1 = false;
        private bool videoIniciado2 = false;
        private HaarCascade deteccionRostro;
        private string nombreAdministrador;
        private HaarCascade deteccionOjos;
        private int contadorEntrenamiento;
        private string informacionHuella;
        private IObjetoRemoto interfaz;
        private string registroTeclado;
        private string registroLector;
        private string nombres = null;
        private bool dactilar = true;
        private string nombreTeclado;
        private string borrarTeclado;
        private int orientacionSala1;
        private int orientacionSala2;
        private int saturacionS1 = 1;
        private int saturacionS2 = 1;
        private Graphics nuevaImagen;
        private string nombre = null;
        private string borrarLector;
        private string nombreLector;
        private int contrasteS1 = 1;
        private int contrasteS2 = 1;
        private string cargarRostro;
        private Bitmap capturaVideo;
        private bool tecladoActivo1;
        private bool tecladoActivo2;
        private bool lectorActivo1;
        private bool lectorActivo2;
        private int numeroTeclados;
        private bool camaraActiva1;
        private bool camaraActiva2;
        private int identificador;
        private string nombreSala;
        private int numeroNombres;
        private int brilloS1 = 1;
        private int brilloS2 = 1;
        private int gammaS1 = 1;
        private int gammaS2 = 1;
        private bool pin = true;
        private int tiempo1 = 0;
        private int tiempo2 = 0;
        private bool Comprobar;
        private bool facial;
        private bool sesion;
        private int S1X;
        private int S1Y;
        private int S2X;
        private int S2Y;

        private void Sistema_Seguridad_FIEE_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult salir = MessageBox.Show("Seguro desea Salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (salir == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    dispositivoTeclado.TeclaPresionada -= new Eventos_Teclado.ControladorEventosTeclado(TeclaPresionada);
                    dispositivoDactilar.OnImageReceived -= Huella_Recibida;
                    dispositivoDactilar.OnCapture -= Huella_Enrolada;
                    dispositivoDactilar.EndEngine();
                    FinalizarServidor();
                    FinalizarSalas();
                }
                catch
                {
                    FinalizarServidor();
                    FinalizarSalas();
                    e.Cancel = false;
                }
            }
        }

        private void Huella_Recibida(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            groupBox_Huella.Focus();
            foreach (var elemento in recuperarLectores)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(elemento, dispositivoDactilar.SensorSN, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    string[] sala = elemento.Split('@');
                    if (sala[2] == "Sala De Redes 1")
                    {
                        pictureBox_Huella1.Image = null;
                        Graphics huella = pictureBox_Huella1.CreateGraphics();
                        Bitmap imagenHuella = new Bitmap(pictureBox_Huella1.Width, pictureBox_Huella1.Height);
                        huella = Graphics.FromImage(imagenHuella);
                        int contador = huella.GetHdc().ToInt32();
                        dispositivoDactilar.PrintImageAt(contador, 0, 0, imagenHuella.Width, imagenHuella.Height);
                        huella.Dispose();
                        pictureBox_Huella1.Image = imagenHuella;
                    }
                    if (sala[2] == "Sala De Redes 2")
                    {
                        pictureBox_Huella2.Image = null;
                        Graphics huella = pictureBox_Huella2.CreateGraphics();
                        Bitmap imagenHuella = new Bitmap(pictureBox_Huella2.Width, pictureBox_Huella2.Height);
                        huella = Graphics.FromImage(imagenHuella);
                        int contador = huella.GetHdc().ToInt32();
                        dispositivoDactilar.PrintImageAt(contador, 0, 0, imagenHuella.Width, imagenHuella.Height);
                        huella.Dispose();
                        pictureBox_Huella2.Image = imagenHuella;
                    }
                }
            }
        }

        private void TeclaPresionada(object sender, Eventos_Teclado.ControlEventosTeclas e)
        {
            groupBox_Pin.Focus();
            foreach (var elemento in recuperarTeclados)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(elemento, e.Teclado.registroDispositivo.Remove(0, 4), System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    string[] sala = elemento.Split('@');
                    if (sala[2] == "Sala De Redes 1")
                    {
                        txt_Acceso1.Focus();
                    }
                    if (sala[2] == "Sala De Redes 2")
                    {
                        txt_Acceso2.Focus();
                    }
                }
            }
        }

        private void ComboBox_SalaTeclado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_SalaTeclado.SelectedIndex == 0)
            {
                if (tecladoActivo1 == true)
                {
                    foreach (var elemento in recuperarTeclados)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 1", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] sala = elemento.Split('@');
                            txt_NombreTeclado.Text = sala[0];
                        }
                    }
                    groupBox_Teclado1.Enabled = true;
                    ActivarDetallesTeclado();
                }
                else
                {
                    groupBox_Teclado1.Enabled = false;
                    txt_Acceso1.Text = String.Empty;
                    DesactivarDetallesTeclado();
                }
            }
            if (comboBox_SalaTeclado.SelectedIndex == 1)
            {
                if (tecladoActivo2 == true)
                {
                    foreach (var elemento in recuperarTeclados)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 2", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] sala = elemento.Split('@');
                            txt_NombreTeclado.Text = sala[0];
                        }
                    }
                    groupBox_Teclado2.Enabled = true;
                    ActivarDetallesTeclado();
                }
                else
                {
                    groupBox_Teclado2.Enabled = false;
                    txt_Acceso2.Text = String.Empty;
                    DesactivarDetallesTeclado();
                }
            }
        }

        private void ComboBox_SalasLector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_SalasLector.SelectedIndex == 0)
            {
                if (lectorActivo1 == true)
                {
                    foreach (var elemento in recuperarLectores)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 1", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] sala = elemento.Split('@');
                            txt_NombreLector.Text = sala[0];
                        }
                    }
                    groupBox_Huella1.Enabled = true;
                    ActivarDetallesLector();
                }
                else
                {
                    groupBox_Huella1.Enabled = false;
                    txt_NombreLector.Text = String.Empty;
                    DesactivarDetallesLector();
                }
            }
            if (comboBox_SalasLector.SelectedIndex == 1)
            {
                if (lectorActivo2 == true)
                {
                    foreach (var elemento in recuperarLectores)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 2", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] sala = elemento.Split('@');
                            txt_NombreLector.Text = sala[0];
                        }
                    }
                    groupBox_Huella2.Enabled = true;
                    ActivarDetallesLector();
                }
                else
                {
                    groupBox_Huella2.Enabled = false;
                    txt_NombreLector.Text = String.Empty;
                    DesactivarDetallesLector();
                }
            }
        }

        private void Boton_DeshabilitarReconocimiento1_Click(object sender, EventArgs e)
        {
            if (boton_HabilitarReconocimiento1.Enabled == true)
            {
                boton_DeshabilitarReconocimiento1.Enabled = false;
                boton_HabilitarReconocimiento1.Enabled = true;
                reconocimientoSala1.Image = null;
                timer_Ubicacion1.Enabled = false;
                timer_Deteccion1.Enabled = false;
            }
            else
            {
                Eventos.Escribir("Se ha deshabilitado el Reconocimiento Facial de la Sala De Redes 1.");
                etiquetaCantidadRostrosDetectados1.Text = String.Empty;
                boton_DeshabilitarReconocimiento1.Enabled = false;
                boton_HabilitarReconocimiento1.Enabled = true;
                etiquetaPersonaEnCuadro1.Text = String.Empty;
                etiquetaRespuesta1.Text = String.Empty;
                etiquetaRespuesta1.Text = "Respuesta";
                reconocimientoSala1.Image = null;
                timer_Ubicacion1.Enabled = false;
                timer_Deteccion1.Enabled = false;
            }
        }

        private void Boton_DeshabilitarReconocimiento2_Click(object sender, EventArgs e)
        {
            if (boton_HabilitarReconocimiento2.Enabled == true)
            {
                boton_DeshabilitarReconocimiento2.Enabled = false;
                boton_HabilitarReconocimiento2.Enabled = true;
                reconocimientoSala2.Image = null;
                timer_Ubicacion2.Enabled = false;
                timer_Deteccion2.Enabled = false;
            }
            else
            {
                Eventos.Escribir("Se ha deshabilitado el Reconocimiento Facial de la Sala De Redes 2.");
                etiquetaCantidadRostrosDetectados2.Text = String.Empty;
                boton_DeshabilitarReconocimiento2.Enabled = false;
                boton_HabilitarReconocimiento2.Enabled = true;
                etiquetaPersonaEnCuadro2.Text = String.Empty;
                etiquetaRespuesta2.Text = String.Empty;
                etiquetaRespuesta2.Text = "Respuesta";
                reconocimientoSala2.Image = null;
                timer_Ubicacion2.Enabled = false;
                timer_Deteccion2.Enabled = false;
            }
        }

        private void Boton_HabilitarReconocimiento1_Click(object sender, EventArgs e)
        {
            try
            {
                Eventos.Escribir("Se ha habilitado el Reconocimiento Facial de la Sala De Redes 1.");
                deteccionRostro = new HaarCascade("haarcascade_frontalface_default.xml");
                deteccionOjos = new HaarCascade("haarcascade_eye.xml");
                rutaNombresEntrenamiento = File.ReadAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt");
                nombresEntrenamiento = rutaNombresEntrenamiento.Split('%');
                contadorEntrenamiento = Convert.ToInt32(nombresEntrenamiento[0]);
                for (int numero = 1; numero < contadorEntrenamiento + 1; numero++)
                {
                    cargarRostro = "Rostro_Entrenamiento_" + numero + ".bmp";
                    imagenesEntrenamiento.Add(new Image<Gray, byte>(Application.StartupPath + "/Rostros_De_Entrenamiento/" + cargarRostro));
                    nombresUsuarios.Add(nombresEntrenamiento[numero]);
                }
                boton_DeshabilitarReconocimiento1.Enabled = true;
                boton_HabilitarReconocimiento1.Enabled = false;
                timer_Ubicacion1.Enabled = true;
                timer_Deteccion1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("No hay nada en la base de datos binaria, agregue al menos un rostro.", "Carga de Rostros de Entrenamiento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Boton_HabilitarReconocimiento2_Click(object sender, EventArgs e)
        {
            try
            {
                Eventos.Escribir("Se ha habilitado el Reconocimiento Facial de la Sala De Redes 2.");
                deteccionRostro = new HaarCascade("haarcascade_frontalface_default.xml");
                deteccionOjos = new HaarCascade("haarcascade_eye.xml");
                rutaNombresEntrenamiento = File.ReadAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt");
                nombresEntrenamiento = rutaNombresEntrenamiento.Split('%');
                contadorEntrenamiento = Convert.ToInt32(nombresEntrenamiento[0]);
                for (int numero = 1; numero < contadorEntrenamiento + 1; numero++)
                {
                    cargarRostro = "Rostro_Entrenamiento_" + numero + ".bmp";
                    imagenesEntrenamiento.Add(new Image<Gray, byte>(Application.StartupPath + "/Rostros_De_Entrenamiento/" + cargarRostro));
                    nombresUsuarios.Add(nombresEntrenamiento[numero]);
                }
                boton_DeshabilitarReconocimiento2.Enabled = true;
                boton_HabilitarReconocimiento2.Enabled = false;
                timer_Ubicacion2.Enabled = true;
                timer_Deteccion2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("No hay nada en la base de datos binaria, agregue al menos un rostro.", "Carga de Rostros de Entrenamiento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Huella_Enrolada(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            informacionHuella = String.Empty;
            informacionHuella = dispositivoDactilar.EncodeTemplate1(e.aTemplate);
            groupBox_Huella.Focus();
            foreach (var elemento in recuperarLectores)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(elemento, dispositivoDactilar.SensorSN, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    string[] sala = elemento.Split('@');
                    if (sala[2] == "Sala De Redes 1")
                    {
                        (objetoremotoUsuario as IObjetoRemoto).ObtenerHuellas(recibirDatosUsuario);
                        foreach (Usuarios item in recibirDatosUsuario)
                        {
                            if (dispositivoDactilar.VerFingerFromStr(ref informacionHuella, item.Huella, false, ref Comprobar))
                            {
                                Eventos.Escribir("El usuario" + " " + item.Nombre + " " + item.Apellido + " " + "ha ingresado a la Sala De Redes 1.");
                                etiquetaRespuesta5.Text = "Huella Verificada - Acceso Concedido.";
                                AbrirCerradura_Sala1();
                                break;
                            }
                            else
                            {
                                etiquetaRespuesta5.Text = "Huella No Verificada - Acceso Denegado.";
                            }
                        }
                        recibirDatosUsuario.Clear();
                    }
                    if (sala[2] == "Sala De Redes 2")
                    {
                        (objetoremotoUsuario as IObjetoRemoto).ObtenerHuellas(recibirDatosUsuario);
                        foreach (Usuarios item in recibirDatosUsuario)
                        {
                            if (dispositivoDactilar.VerFingerFromStr(ref informacionHuella, item.Huella, false, ref Comprobar))
                            {
                                Eventos.Escribir("El usuario" + " " + item.Nombre + " " + item.Apellido + " " + "ha ingresado a la Sala De Redes 2.");
                                etiquetaRespuesta6.Text = "Huella Verificada - Acceso Concedido.";
                                AbrirCerradura_Sala2();
                                break;
                            }
                            else
                            {
                                etiquetaRespuesta6.Text = "Huella No Verificada - Acceso Denegado.";
                            }
                        }
                        recibirDatosUsuario.Clear();
                    }
                }
            }
        }

        private void ComboBox_Salas_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoSalaActual = listaVideoSalas[comboBox_Salas.SelectedIndex];
            eventoActual = listaEventos[comboBox_Salas.SelectedIndex];
            nombreSala = comboBox_Salas.SelectedItem.ToString();
            if (eventoActual.EventoCamara == null)
            {
                boton_Buscar.Enabled = true;
                DesactivarDetalles();
            }
            else
            {
                if (eventoActual.EventoCamara.State == CameraState.Streaming)
                {
                    ActivarDetalles();
                    if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://"))
                    {
                        ObternerInformacionCamaraUSB();
                    }
                    else
                    {
                        ObtenerInformacionCamara();
                    }
                }
            }
        }

        private void Boton_DesconectarTeclado_Click(object sender, EventArgs e)
        {
            if (txt_NombreTeclado.Text != String.Empty)
            {
                if (comboBox_SalaTeclado.SelectedIndex == 0)
                {
                    foreach (var elemento in recuperarTeclados)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 1", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] eliminar = elemento.Split('@');
                            Eventos.Escribir("Se ha desconectado el teclado " + eliminar[0] + " Sala De Redes 1.");
                            teclados.Remove(eliminar[0] + "@" + eliminar[1]);
                            tecladosConectados.Remove(eliminar[1]);
                            borrarTeclado = elemento;
                        }
                    }
                    recuperarTeclados.Remove(borrarTeclado);
                    etiquetaRespuesta3.Text = "Respuesta";
                    groupBox_Teclado1.Enabled = false;
                    txt_Acceso1.Text = String.Empty;
                    ElementosComboBoxSalaTeclado();
                    DesactivarDetallesTeclado();
                    tecladoActivo1 = false;
                    groupBox_Pin.Focus();
                }
                else
                {
                    foreach (var elemento in recuperarTeclados)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 2", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] eliminar = elemento.Split('@');
                            Eventos.Escribir("Se ha desconectado el teclado " + eliminar[0] + " Sala De Redes 2.");
                            teclados.Remove(eliminar[0] + "@" + eliminar[1]);
                            tecladosConectados.Remove(eliminar[1]);
                            borrarTeclado = elemento;
                        }
                    }
                    recuperarTeclados.Remove(borrarTeclado);
                    etiquetaRespuesta4.Text = "Respuesta";
                    groupBox_Teclado2.Enabled = false;
                    txt_Acceso2.Text = String.Empty;
                    ElementosComboBoxSalaTeclado();
                    DesactivarDetallesTeclado();
                    tecladoActivo2 = false;
                    groupBox_Pin.Focus();
                }
            }
            else
            {
                MessageBox.Show("No se ha podido desconectar. Especifique el teclado a desconectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (tecladoActivo1 == true || tecladoActivo2 == true)
            {
                dispositivoTeclado.TeclaPresionada += new Eventos_Teclado.ControladorEventosTeclado(TeclaPresionada);
            }
            else
            {
                dispositivoTeclado.TeclaPresionada -= new Eventos_Teclado.ControladorEventosTeclado(TeclaPresionada);
            }
        }

        private void Boton_DesconectarLector_Click(object sender, EventArgs e)
        {
            if (txt_NombreLector.Text != String.Empty)
            {
                if (comboBox_SalasLector.SelectedIndex == 0)
                {
                    foreach (var elemento in recuperarLectores)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 1", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] eliminar = elemento.Split('@');
                            Eventos.Escribir("Se ha desconectado el lector " + eliminar[0] + " Sala De Redes 1.");
                            lectores.Remove(eliminar[0] + "@" + eliminar[1]);
                            lectoresConectados.Remove(eliminar[1]);
                            borrarLector = elemento;
                        }
                    }
                    recuperarLectores.Remove(borrarLector);
                    etiquetaRespuesta5.Text = "Respuesta";
                    txt_NombreLector.Text = String.Empty;
                    groupBox_Huella1.Enabled = false;
                    pictureBox_Huella1.Image = null;
                    ElementosComboBoxSalaLector();
                    DesactivarDetallesLector();
                    groupBox_Huella.Focus();
                    lectorActivo1 = false;
                }
                else
                {
                    foreach (var elemento in recuperarLectores)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(elemento, "Sala De Redes 2", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            string[] eliminar = elemento.Split('@');
                            Eventos.Escribir("Se ha desconectado el lector " + eliminar[0] + " Sala De Redes 2.");
                            lectores.Remove(eliminar[0] + "@" + eliminar[1]);
                            lectoresConectados.Remove(eliminar[1]);
                            borrarLector = elemento;
                        }
                    }
                    recuperarLectores.Remove(borrarLector);
                    etiquetaRespuesta6.Text = "Respuesta";
                    txt_NombreLector.Text = String.Empty;
                    groupBox_Huella2.Enabled = false;
                    pictureBox_Huella2.Image = null;
                    ElementosComboBoxSalaLector();
                    DesactivarDetallesLector();
                    groupBox_Huella.Focus();
                    lectorActivo2 = false;
                }
            }
            else
            {
                MessageBox.Show("No se ha podido desconectar. Especifique el lector a desconectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (lectorActivo1 == true || lectorActivo2 == true)
            {
                dispositivoDactilar.OnImageReceived += Huella_Recibida;
                dispositivoDactilar.OnCapture += Huella_Enrolada;
            }
            else
            {
                dispositivoDactilar.OnImageReceived -= Huella_Recibida;
                dispositivoDactilar.OnCapture -= Huella_Enrolada;
                dispositivoDactilar.EndEngine();
            }
        }

        private void Txt_Acceso1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                ObtenerPin1();
            }
        }

        private void Txt_Acceso2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                ObtenerPin2();
            }
        }

        private void ActivarDeteccionFacial_Click(object sender, EventArgs e)
        {
            if (facial == false)
            {
                activarDeteccionFacial.Text = "Desactivar Deteccion Facial";
                groupBox_BuscarCamara.Enabled = true;
                groupBox_Facial.Enabled = true;
                facial = true;
            }
            else
            {
                activarDeteccionFacial.Text = "Activar Deteccion Facial";
                groupBox_Facial.Enabled = false;
                facial = false;
            }
        }

        private void Sistema_Seguridad_FIEE_Load(object sender, EventArgs e)
        {
            ElementosComboBoxSalaTeclado();
            ElementosComboBoxSalaLector();
            DesactivarDetallesTeclado();
            DesactivarDetallesLector();
            ElementosComboBoxSala();
            DesactivarDetalles();
            BloquearElementos();
            IniciarSalas();
        }

        private void Boton_CapturarImagen1_Click(object sender, EventArgs e)
        {
            if (txt_Guardar1.Text != String.Empty)
            {
                string rutaSala1;
                rutaSala1 = txt_Guardar1.Text;
                listaEventos[0].TomarSnapShot(rutaSala1, "Sala De Redes 1");
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar la imagen.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_CapturarImagen2_Click(object sender, EventArgs e)
        {
            if (txt_Guardar2.Text != String.Empty)
            {
                string rutaSala2;
                rutaSala2 = txt_Guardar2.Text;
                listaEventos[1].TomarSnapShot(rutaSala2, "Sala De Redes 2");
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar la imagen.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_FinalizarVideo1_Click(object sender, EventArgs e)
        {
            if (videoIniciado1 == true)
            {
                listaEventos[0].DetenerCapturaVideo("Sala De Redes 1");
                videoIniciado1 = false;
            }
            else
            {
                MessageBox.Show("Primero debe iniciar el video.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Boton_FinalizarVideo2_Click(object sender, EventArgs e)
        {
            if (videoIniciado2 == true)
            {
                listaEventos[1].DetenerCapturaVideo("Sala De Redes 2");
                videoIniciado2 = false;
            }
            else
            {
                MessageBox.Show("Primero debe iniciar el video.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_ConectarTeclado_Click(object sender, EventArgs e)
        {
            if (txt_NombreTeclado.Text != String.Empty)
            {
                if (tecladosConectados.Contains(registroTeclado))
                {
                    MessageBox.Show("El teclado ya esta siendo utilizado en otra sala. Debe escoger otro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_NombreTeclado.Text = String.Empty;
                    boton_ConectarTeclado.Enabled = false;
                }
                else
                {
                    tecladosConectados.Add(registroTeclado);
                    boton_DesconectarTeclado.Enabled = true;
                    boton_ConectarTeclado.Enabled = false;
                    boton_BuscarTeclado.Enabled = false;
                    groupBox_Pin.Focus();
                    if (comboBox_SalaTeclado.SelectedIndex == 0)
                    {
                        Eventos.Escribir("Se ha conectado al teclado " + nombreTeclado + " Sala De Redes 1.");
                        recuperarTeclados.Add(nombreTeclado + "@" + registroTeclado + "@" + "Sala De Redes 1");
                        groupBox_Teclado1.Enabled = true;
                        tecladoActivo1 = true;
                        ActivarTeclados();
                    }
                    else
                    {
                        Eventos.Escribir("Se ha conectado al teclado " + nombreTeclado + " Sala De Redes 2.");
                        recuperarTeclados.Add(nombreTeclado + "@" + registroTeclado + "@" + "Sala De Redes 2");
                        groupBox_Teclado2.Enabled = true;
                        tecladoActivo2 = true;
                        ActivarTeclados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe escoger un TECLADO y una SALA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivarHuellaDactilar_Click(object sender, EventArgs e)
        {
            if (dactilar == false)
            {
                activarHuellaDactilar.Text = "Desactivar Huella Dactilar";
                groupBox_BuscarLectores.Enabled = true;
                groupBox_Huella.Enabled = true;
                dactilar = true;
            }
            else
            {
                activarHuellaDactilar.Text = "Activar Huella Dactilar";
                groupBox_Huella.Enabled = false;
                dactilar = false;
            }
        }

        private void Timer_Reconocimiento1_Tick(object sender, EventArgs e)
        {
            tiempo1++;
        }

        private void Timer_Reconocimiento2_Tick(object sender, EventArgs e)
        {
            tiempo2++;
        }

        private void AcercaDelProgramador_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t\t ESCUELA POLITÉCNICA NACIONAL" + "\n\n" +
                            "\t FACULTAD DE INGENIERÍA ÉLECTRICA Y ELECTRÓNICA" + "\n\n" +
                            " DESARROLLO DE UN SISTEMA PROTOTIPO DE ACCESO A LOS LABORATORIOS" + "\n" +
                            "   DE REDES DE LA FACULTAD DE INGENIERÍA ELÉCTRICA Y ELECTRÓNICA(FIEE)" + "\n" +
                            "\t         DE LA ESCUELA POLITÉCNICA NACIONAL(EPN)" + "\n" +
                            "\t\t BASADO EN RECONOCIMIENTO FACIAL" + "\n\n" +
                            "        TRABAJO DE TITULACIÓN PREVIO A LA OBTENCIÓN DEL TÍTULO DE" + "\n" +
                            "\t INGENIERO EN “ELECTRÓNICA Y REDES DE INFORMACIÓN”" + "\n\n" +
                            "\t\t    ARROYO AUZ CHRISTIAN XAVIER" + "\n" +
                            "\t\t         christian.arroyo @epn.edu.ec" + "\n\n" +
                            "\t DIRECTOR:  MSC.CALDERÓN HINOJOSA XAVIER ALEXANDER" + "\n" +
                            "\t\t         xavier.calderon @epn.edu.ec" + "\n\n" +
                            "\t\t\t Quito, mayo 2019", "Programador");
        }

        private void Boton_ConectarLector_Click(object sender, EventArgs e)
        {
            if (txt_NombreLector.Text != String.Empty)
            {
                if (lectoresConectados.Contains(registroLector))
                {
                    MessageBox.Show("El lector ya esta siendo utilizado en otra sala. Debe escoger otro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_NombreLector.Text = String.Empty;
                    boton_ConectarLector.Enabled = false;
                }
                else
                {
                    
                    lectoresConectados.Add(registroLector);
                    boton_DesconectarLector.Enabled = true;
                    boton_ConectarLector.Enabled = false;
                    boton_BuscarLector.Enabled = false;
                    groupBox_Huella.Focus();
                    if (comboBox_SalasLector.SelectedIndex == 0)
                    {
                        Eventos.Escribir("Se ha conectado al lector " + nombreLector + " Sala De Redes 1.");
                        recuperarLectores.Add(nombreLector + "@" + registroLector + "@" + "Sala De Redes 1");
                        groupBox_Huella1.Enabled = true;
                        lectorActivo1 = true;
                        ActivarLectores();
                    }
                    if (comboBox_SalasLector.SelectedIndex == 1)
                    {
                        Eventos.Escribir("Se ha conectado al lector " + nombreLector + " Sala De Redes 2.");
                        recuperarLectores.Add(nombreLector + "@" + registroLector + "@" + "Sala De Redes 2");
                        groupBox_Huella2.Enabled = true;
                        lectorActivo2 = true;
                        ActivarLectores();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe escoger un LECTOR y una SALA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_BuscarTeclado_Click(object sender, EventArgs e)
        {
            if (comboBox_SalaTeclado.Text == String.Empty)
            {
                MessageBox.Show("Debe escoger una SALA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Agregar_Teclados cambio = new Agregar_Teclados();
                cambio.listaTeclados = teclados;
                if (cambio.ShowDialog() == DialogResult.OK)
                {
                    txt_NombreTeclado.Text = cambio.pasarNombre;
                    registroTeclado = cambio.pasarRegistro;
                    boton_ConectarTeclado.Enabled = true;
                    nombreTeclado = cambio.pasarNombre;
                    teclados = cambio.listaTeclados;
                    boton_ConectarTeclado.Focus();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un Teclado.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void Boton_IniciarVideo1_Click(object sender, EventArgs e)
        {
            if (txt_Guardar1.Text != String.Empty)
            {
                string rutaSala1;
                videoIniciado1 = true;
                rutaSala1 = txt_Guardar1.Text;
                listaEventos[0].IniciarCapturaVideo(rutaSala1, "Sala De Redes 1");
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar el video.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_IniciarVideo2_Click(object sender, EventArgs e)
        {
            if (txt_Guardar2.Text != String.Empty)
            {
                string rutaSala2;
                videoIniciado2 = true;
                rutaSala2 = txt_Guardar2.Text;
                listaEventos[1].IniciarCapturaVideo(rutaSala2, "Sala De Redes 2");
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar el video.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_DisminuirZoom_Click(object sender, EventArgs e)
        {
            eventoActual.Zoom("Disminuir", nombreSala);
        }

        private void Boton_BuscarLector_Click(object sender, EventArgs e)
        {
            if (comboBox_SalasLector.Text == String.Empty)
            {
                MessageBox.Show("Debe escoger una SALA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Agregar_Lectores cambio = new Agregar_Lectores();
                cambio.listaLectores = lectores;
                if (cambio.ShowDialog() == DialogResult.OK)
                {
                    txt_NombreLector.Text = cambio.pasarNombre;
                    registroLector = cambio.pasarRegistro;
                    boton_ConectarLector.Enabled = true;
                    nombreLector = cambio.pasarNombre;
                    lectores = cambio.listaLectores;
                    boton_ConectarLector.Focus();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un Lector.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void Boton_AumentarZoom_Click(object sender, EventArgs e)
        {
            eventoActual.Zoom("Aumentar", nombreSala);
        }

        private void Boton_LimpiarSala1_Click(object sender, EventArgs e)
        {
            videoSala1.ClearScreen();
            Eventos.Escribir("Se ha limpiado la pantalla de la Sala De Redes 1.");
        }

        private void Boton_LimpiarSala2_Click(object sender, EventArgs e)
        {
            videoSala2.ClearScreen();
            Eventos.Escribir("Se ha limpiado la pantalla de la Sala De Redes 2.");
        }

        private void Boton_Desconectar_Click(object sender, EventArgs e)
        {
            if (videoIniciado1 == true || videoIniciado2 == true)
            {
                MessageBox.Show("Debe finalizar los videos que se estan grabando antes de desconectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox_Salas.SelectedIndex != -1 && listaEventos[comboBox_Salas.SelectedIndex].EventoCamara != null)
                {
                    listaCamaras.Remove(txt_CamaraURL.Text);
                    if (!txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://") || comboBox_Salas.Text == String.Empty)
                    {
                        Eventos.Escribir("Estado de la Camara IP " + nombreSala + ": " + "Disconnected.");
                    }
                    if (comboBox_Salas.SelectedIndex == 0)
                    {
                        Eventos.Escribir("Se ha desconectado la camara" + eventoActual.EventoCamara.ToString().Remove(0, eventoActual.EventoCamara.ToString().Split(' ')[0].Length) + " " + nombreSala + ".");
                        Eventos.Escribir("La orientación de camara de la " + nombreSala + " normalizada.");
                        Boton_DeshabilitarReconocimiento1_Click(sender, e);
                        groupBox_ReconocimientoSala1.Enabled = false;
                        eventoActual.Zoom("Default", nombreSala);
                        groupBox_Sala1.Enabled = false;
                        orientacionSala1 = 00;
                        saturacionS1 = 1;
                        contrasteS1 = 1;
                        brilloS1 = 1;
                        gammaS1 = 1;
                    }
                    else
                    {
                        Eventos.Escribir("Se ha desconectado la camara" + eventoActual.EventoCamara.ToString().Remove(0, eventoActual.EventoCamara.ToString().Split(' ')[0].Length) + " " + nombreSala + ".");
                        Eventos.Escribir("La orientación de camara de la " + nombreSala + " normalizada.");
                        Boton_DeshabilitarReconocimiento2_Click(sender, e);
                        groupBox_ReconocimientoSala2.Enabled = false;
                        eventoActual.Zoom("Default", nombreSala);
                        groupBox_Sala2.Enabled = false;
                        orientacionSala2 = 00;
                        saturacionS2 = 1;
                        contrasteS2 = 1;
                        brilloS2 = 1;
                        gammaS2 = 1;
                    }
                    txt_CamaraURL.Text = String.Empty;
                    boton_Desconectar.Enabled = false;
                    boton_Buscar.Enabled = true;
                    eventoActual.Desconectar();
                    ElementosComboBoxSala();
                    DesactivarDetalles();
                }
                else
                {
                    MessageBox.Show("No se ha podido desconectar. Especifique la camara a desconectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EstadoCamara(object sender, CameraStateEventArgs e)
        {
            LlamadaEvento(() =>
            {
                if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://") || comboBox_Salas.Text == String.Empty)
                {
                    Eventos.Escribir("Estado de la Camara USB " + nombreSala + ": " + e.State + ".");
                }
                else
                {
                    Eventos.Escribir("Estado de la Camara IP " + nombreSala + ": " + e.State + ".");
                }
                switch (e.State)
                {
                    case CameraState.Streaming:
                        {
                            if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://"))
                            {
                                Eventos.Escribir("Se ha conectado a la camara" + eventoActual.EventoCamara.ToString().Remove(0, eventoActual.EventoCamara.ToString().Split(' ')[0].Length) + " " + nombreSala + ".");
                                ObternerInformacionCamaraUSB();
                                break;
                            }
                            else
                            {
                                Eventos.Escribir("Se ha conectado a la camara" + eventoActual.EventoCamara.ToString().Remove(0, eventoActual.EventoCamara.ToString().Split(' ')[0].Length) + " " + nombreSala + ".");
                                ObtenerInformacionCamara();
                                break;
                            }
                        }
                    case CameraState.Disconnected:
                        {
                            videoSalaActual.ClearScreen();
                            videoSalaActual.Stop();

                            break;
                        }
                    case CameraState.Error:
                        {
                            videoSalaActual.Stop();
                            videoSalaActual.ClearScreen();
                            break;
                        }
                }
            });
        }

        private void ActivarPINAcceso_Click(object sender, EventArgs e)
        {
            if (pin == false)
            {
                activarPINAcceso.Text = "Desactivar PIN Acceso";
                groupBox_BuscarTeclado.Enabled = true;
                groupBox_Pin.Enabled = true;
                pin = true;
            }
            else
            {
                activarPINAcceso.Text = "Activar PIN Acceso";
                groupBox_Pin.Enabled = false;
                pin = false;
            }
        }

        private void ErrorCamara(object sender, CameraErrorEventArgs e)
        {
            if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://"))
            {
                Eventos.Escribir("Error en la Camara USB " + nombreSala + ": " + (e.Details ?? e.Error.ToString()) + ".");
            }
            else
            {
                Eventos.Escribir("Error en la Camara IP " + nombreSala + ": " + (e.Details ?? e.Error.ToString()) + ".");
            }
        }

        private void RegistrarUsuario_Click(object sender, EventArgs e)
        {
            FinalizarServidor();
            try
            {
                dispositivoDactilar.EndEngine();
            }
            catch (Exception)
            {
                //NADA
            }
            Administracion_Usuarios cambio = new Administracion_Usuarios();
            cambio.apellidoAdministrador = apellidoAdministrador;
            cambio.nombreAdministrador = nombreAdministrador;
            cambio.tipoCrud = "Registro";
            cambio.ShowDialog();
            usuariosCRUD = cambio.usuariosCRUD;
            Thread servidor = new Thread(Servidor.Main);
            interfaz = canal.CreateChannel();
            servidor.IsBackground = true;
            Thread.Sleep(1000);
            servidor.Start();
            foreach (var item in usuariosCRUD)
            {
                string[] datos = item.Split('@');
                Eventos.Escribir("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + " ha agregado al usuario " + datos[0] + " " + datos[1] + ".");
            }
            usuariosCRUD.Clear();
            try
            {
                dispositivoDactilar.InitEngine();
            }
            catch (Exception)
            {
                //NADA
            }
        }

        private void ModificarUsiario_Click(object sender, EventArgs e)
        {
            FinalizarServidor();
            try
            {
                dispositivoDactilar.EndEngine();
            }
            catch (Exception)
            {
                //NADA
            }
            Administracion_Usuarios cambio = new Administracion_Usuarios();
            cambio.apellidoAdministrador = apellidoAdministrador;
            cambio.nombreAdministrador = nombreAdministrador;
            cambio.tipoCrud = "Actualizar";
            cambio.ShowDialog();
            usuariosCRUD = cambio.usuariosCRUD;
            Thread servidor = new Thread(Servidor.Main);
            interfaz = canal.CreateChannel();
            servidor.IsBackground = true;
            Thread.Sleep(1000);
            servidor.Start();
            foreach (var item in usuariosCRUD)
            {
                string[] datos = item.Split('@');
                Eventos.Escribir("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + " ha actualizado al usuario " + datos[0] + " " + datos[1] + ".");
            }
            usuariosCRUD.Clear();
            try
            {
                dispositivoDactilar.InitEngine();
            }
            catch (Exception)
            {
                //NADA
            }
        }

        private void Timer_Deteccion1_Tick(object sender, EventArgs e)
        {
            capturaVideo = new Bitmap(317, 215);
            nuevaImagen = CreateGraphics();
            nuevaImagen = Graphics.FromImage(capturaVideo);
            nuevaImagen.CopyFromScreen(S1X + 30, S1Y + 105, 0, 0, new Size(317, 215));
            Image<Bgr, byte> normalizarImagen = new Image<Bgr, byte>(capturaVideo);
            videoRostro = normalizarImagen;
            escalaGrises = videoRostro.Convert<Gray, byte>();
            MCvAvgComp[][] rostroDetectado = escalaGrises.DetectHaarCascade(deteccionRostro, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp rostro in rostroDetectado[0])
            {
                numeroNombres = numeroNombres + 1;
                imagenGris = videoRostro.Copy(rostro.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                videoRostro.Draw(rostro.rect, new Bgr(Color.Red), 2);
                if (imagenesEntrenamiento.ToArray().Length != 0)
                {
                    MCvTermCriteria criterio = new MCvTermCriteria(contadorEntrenamiento, 0.001);
                    EigenObjectRecognizer reconocedor = new EigenObjectRecognizer(imagenesEntrenamiento.ToArray(), nombresUsuarios.ToArray(), 3000, ref criterio);
                    nombre = reconocedor.Recognize(imagenGris);
                    videoRostro.Draw(nombre, ref letra, new Point(rostro.rect.X - 2, rostro.rect.Y - 2), new Bgr(Color.LightGreen));
                }
                nombrePersonas.Add("");
                nombrePersonas[numeroNombres - 1] = nombre;
                nombrePersonas.Add("");
                etiquetaCantidadRostrosDetectados1.Text = rostroDetectado[0].Length.ToString();
                escalaGrises.ROI = rostro.rect;
                MCvAvgComp[][] ojosDetectados = escalaGrises.DetectHaarCascade(deteccionOjos, 1.1, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                escalaGrises.ROI = System.Drawing.Rectangle.Empty;
                foreach (MCvAvgComp ojos in ojosDetectados[0])
                {
                    System.Drawing.Rectangle cuadroOjo = ojos.rect;
                    cuadroOjo.Offset(rostro.rect.X, rostro.rect.Y);
                    videoRostro.Draw(cuadroOjo, new Bgr(Color.Blue), 2);
                }
            }
            numeroNombres = 0;
            for (int nnn = 0; nnn < rostroDetectado[0].Length; nnn++)
            {
                nombres = nombres + nombrePersonas[nnn] + " ";
            }
            etiquetaPersonaEnCuadro1.Text = nombres;
            nombres = "";
            nombrePersonas.Clear();
            reconocimientoSala1.Image = videoRostro;
            if (rostroDetectado[0].Length < 1)
            {
                etiquetaRespuesta1.Text = "No hay personas en cuadro.";
                etiquetaCantidadRostrosDetectados1.Text = "0";
                etiquetaPersonaEnCuadro1.Text = String.Empty;
                timer_Reconocimiento1.Enabled = false;
                tiempo1 = 0;
            }
            else
            {
                if (rostroDetectado[0].Length >= 2)
                {
                    etiquetaRespuesta1.Text = "Demasiadas personas en cuadro.";
                    timer_Reconocimiento1.Enabled = false;
                    tiempo1 = 0;
                }
                else
                {
                    if (nombre != String.Empty)
                    {
                        etiquetaRespuesta1.Text = String.Empty;
                        timer_Reconocimiento1.Enabled = true;
                        if (tiempo1 == 3)
                        {
                            Eventos.Escribir("El usuario" + " " + etiquetaPersonaEnCuadro1.Text + " " + "ha ingresado a la Sala De Redes 1.");
                            timer_Reconocimiento1.Stop();
                            AbrirCerradura_Sala1();
                            tiempo1 = 100;
                        }
                        if (tiempo1 > 3)
                        {
                            etiquetaRespuesta1.Text = "Rostro Verificado - Acceso Concedido.";
                        }
                    }
                    else
                    {
                        etiquetaRespuesta1.Text = "Rostro No Verificado - Acceso Denegado.";
                        timer_Reconocimiento1.Enabled = false;
                        tiempo1 = 0;
                    }
                }
            }
        }

        private void Timer_Deteccion2_Tick(object sender, EventArgs e)
        {
            capturaVideo = new Bitmap(317, 215);
            nuevaImagen = CreateGraphics();
            nuevaImagen = Graphics.FromImage(capturaVideo);
            nuevaImagen.CopyFromScreen(S2X + 30, S2Y + 105, 0, 0, new Size(317, 215));
            Image<Bgr, Byte> normalizarImagen = new Image<Bgr, Byte>(capturaVideo);
            videoRostro = normalizarImagen;
            escalaGrises = videoRostro.Convert<Gray, byte>();
            MCvAvgComp[][] rostroDetectado = escalaGrises.DetectHaarCascade(deteccionRostro, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp rostro in rostroDetectado[0])
            {
                numeroNombres = numeroNombres + 1;
                imagenGris = videoRostro.Copy(rostro.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                videoRostro.Draw(rostro.rect, new Bgr(Color.Red), 2);
                if (imagenesEntrenamiento.ToArray().Length != 0)
                {
                    MCvTermCriteria criterio = new MCvTermCriteria(contadorEntrenamiento, 0.001);
                    EigenObjectRecognizer reconocedor = new EigenObjectRecognizer(imagenesEntrenamiento.ToArray(), nombresUsuarios.ToArray(), 3000, ref criterio);
                    nombre = reconocedor.Recognize(imagenGris);
                    videoRostro.Draw(nombre, ref letra, new Point(rostro.rect.X - 2, rostro.rect.Y - 2), new Bgr(Color.LightGreen));
                }
                nombrePersonas.Add("");
                nombrePersonas[numeroNombres - 1] = nombre;
                nombrePersonas.Add("");
                etiquetaCantidadRostrosDetectados2.Text = rostroDetectado[0].Length.ToString();
                escalaGrises.ROI = rostro.rect;
                MCvAvgComp[][] ojosDetectados = escalaGrises.DetectHaarCascade(deteccionOjos, 1.1, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                escalaGrises.ROI = System.Drawing.Rectangle.Empty;
                foreach (MCvAvgComp ojos in ojosDetectados[0])
                {
                    System.Drawing.Rectangle cuadroOjo = ojos.rect;
                    cuadroOjo.Offset(rostro.rect.X, rostro.rect.Y);
                    videoRostro.Draw(cuadroOjo, new Bgr(Color.Blue), 2);
                }
            }
            numeroNombres = 0;
            for (int nnn = 0; nnn < rostroDetectado[0].Length; nnn++)
            {
                nombres = nombres + nombrePersonas[nnn] + " ";
            }
            etiquetaPersonaEnCuadro2.Text = nombres;
            nombres = "";
            nombrePersonas.Clear();
            reconocimientoSala2.Image = videoRostro;
            if (rostroDetectado[0].Length < 1)
            {
                etiquetaRespuesta2.Text = "No hay personas en cuadro.";
                etiquetaCantidadRostrosDetectados2.Text = "0";
                etiquetaPersonaEnCuadro2.Text = String.Empty;
                timer_Reconocimiento2.Enabled = false;
                tiempo2 = 0;
            }
            else
            {
                if (rostroDetectado[0].Length >= 2)
                {
                    etiquetaRespuesta2.Text = "Demasiadas personas en cuadro.";
                    timer_Reconocimiento2.Enabled = false;
                    tiempo2 = 0;
                }
                else
                {
                    if (nombre != String.Empty)
                    {
                        etiquetaRespuesta2.Text = String.Empty;
                        timer_Reconocimiento2.Enabled = true;
                        if (tiempo2 == 3)
                        {
                            Eventos.Escribir("El usuario" + " " + etiquetaPersonaEnCuadro2.Text + " " + "ha ingresado a la Sala De Redes 2.");
                            etiquetaRespuesta2.Text = "Rostro Verificado - Acceso Concedido.";
                            timer_Reconocimiento1.Stop();
                            AbrirCerradura_Sala2();
                            tiempo2 = 100;
                        }
                        if (tiempo2 > 3)
                        {
                            etiquetaRespuesta2.Text = "Rostro Verificado - Acceso Concedido.";
                        }
                    }
                    else
                    {
                        etiquetaRespuesta1.Text = "Rostro No Verificado - Acceso Denegado.";
                        timer_Reconocimiento2.Enabled = false;
                        tiempo2 = 0;
                    }
                }
            }
        }

        private void Timer_Ubicacion1_Tick(object sender, EventArgs e)
        {
            Point ubicacionPantalla1 = PointToScreen(groupBox_Sala1.Location);
            S1X = ubicacionPantalla1.X;
            S1Y = ubicacionPantalla1.Y;
        }

        private void Timer_Ubicacion2_Tick(object sender, EventArgs e)
        {
            Point ubicacionPantalla2 = PointToScreen(groupBox_Sala2.Location);
            S2X = ubicacionPantalla2.X;
            S2Y = ubicacionPantalla2.Y;
        }

        private void EliminarUsuario_Click(object sender, EventArgs e)
        {
            FinalizarServidor();
            try
            {
                dispositivoDactilar.EndEngine();
            }
            catch (Exception)
            {
                //NADA
            }
            Administracion_Usuarios cambio = new Administracion_Usuarios();
            cambio.apellidoAdministrador = apellidoAdministrador;
            cambio.nombreAdministrador = nombreAdministrador;
            cambio.tipoCrud = "Eliminar";
            cambio.ShowDialog();
            usuariosCRUD = cambio.usuariosCRUD;
            Thread servidor = new Thread(Servidor.Main);
            interfaz = canal.CreateChannel();
            servidor.IsBackground = true;
            Thread.Sleep(1000);
            servidor.Start();
            foreach (var item in usuariosCRUD)
            {
                string[] datos = item.Split('@');
                Eventos.Escribir("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + " ha eliminado al usuario " + datos[0] + " " + datos[1] + ".");
            }
            usuariosCRUD.Clear();
            try
            {
                dispositivoDactilar.InitEngine();
            }
            catch (Exception)
            {
                //NADA
            }
        }

        private void VerLogDeEventos_Click(object sender, EventArgs e)
        {
            FinalizarServidor();
            Logs_Eventos cambio = new Logs_Eventos();
            cambio.ShowDialog();
            Thread servidor = new Thread(Servidor.Main);
            interfaz = canal.CreateChannel();
            servidor.IsBackground = true;
            Thread.Sleep(1000);
            servidor.Start();
        }

        private void EventoMensajeRecibido(object sender, Mensajes e)
        {
            LlamadaEvento(() =>
            {
                listBox_Logs.Items.Add(e.informacionEvento);
                listBox_Logs.SelectedIndex = listBox_Logs.Items.Count - 1;
                listBox_Logs.SelectedIndex = -1;
                try
                {
                    identificador = interfaz.ObtenerID_Eventos(0);
                    string[] evento = e.informacionEvento.Split('|');
                    objetoremotoUsuario.identificadorEvento = identificador;
                    objetoremotoUsuario.fechaEvento = evento[0];
                    objetoremotoUsuario.evento = evento[1];
                    (objetoremotoUsuario as IObjetoRemoto).AgregarEvento(recibirDatosEventos);
                    recibirDatosEventos.Clear();
                }
                catch
                {
                    //NADA
                }
            });
        }

        private void Boton_Conectar_Click(object sender, EventArgs e)
        {
            if (txt_CamaraURL.Text != String.Empty)
            {
                if (listaCamaras.Contains(txt_CamaraURL.Text))
                {
                    MessageBox.Show("La camara ya esta siendo utilizada en otra sala. Debe escoger otra.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("RTSP://"))
                    {
                        Eventos.Escribir("Conectando a Camara IP via RTSP.");
                    }
                    else
                    {
                        if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("HTTP://"))
                        {
                            Eventos.Escribir("Conectando a camara IP via HTTP.");
                        }
                        else
                        {
                            if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://"))
                            {
                                Eventos.Escribir("Conectando a Camara USB.");
                            }
                            else
                            {
                                Eventos.Escribir("Conectando a Camara IP via LAN.");
                            }
                        }
                    }
                    if (comboBox_Salas.SelectedIndex == 0)
                    {
                        camaraActiva1 = true;
                    }
                    if (comboBox_Salas.SelectedIndex == 1)
                    {
                        camaraActiva2 = true;
                    }
                    listaCamaras.Add(txt_CamaraURL.Text);
                    ConectarCamara();
                    ActivarDetalles();
                }
            }
            else
            {
                MessageBox.Show("Debe escoger una CAMARA y una SALA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_Guardar1_Click(object sender, EventArgs e)
        {
            var busquedaRuta1 = buscadorArchivos.ShowDialog();
            if (busquedaRuta1 == DialogResult.OK)
            {
                txt_Guardar1.Text = buscadorArchivos.SelectedPath;
                Eventos.Escribir("Se ha seleecionado la ruta " + txt_Guardar1.Text + " para la " + nombreSala + ".");
            }
            else
            {
                MessageBox.Show("No se escogio una ruta.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Boton_Guardar2_Click(object sender, EventArgs e)
        {
            var busquedaRuta2 = buscadorArchivos.ShowDialog();
            if (busquedaRuta2 == DialogResult.OK)
            {
                txt_Guardar2.Text = buscadorArchivos.SelectedPath;
                Eventos.Escribir("Se ha seleecionado la ruta " + txt_Guardar2.Text + " para la " + nombreSala + ".");
            }
            else
            {
                MessageBox.Show("No se escogio una ruta.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LogoutSistema_Click(object sender, EventArgs e)
        {
            Eventos.Escribir("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + "ha finalizado sesion.");
            logoutSistema.Enabled = false;
            loginSistema.Enabled = true;
            BloquearElementos();
            sesion = false;
            if (facial == true)
            {
                if (camaraActiva1 == true)
                {
                    boton_DeshabilitarReconocimiento1.Enabled = true;
                    groupBox_ReconocimientoSala1.Enabled = true;
                    boton_Desconectar.Enabled = true;
                    groupBox_Sala1.Enabled = true;
                }
                if (camaraActiva2 == true)
                {
                    boton_DeshabilitarReconocimiento2.Enabled = true;
                    groupBox_ReconocimientoSala2.Enabled = true;
                    boton_Desconectar.Enabled = true;
                    groupBox_Sala2.Enabled = true;
                }
                facial = false;
            }
            else
            {
                facial = true;
            }
            if (pin == true)
            {
                if (tecladoActivo1 == true)
                {
                    groupBox_Teclado1.Enabled = true;
                    groupBox_Pin.Enabled = true;
                    foreach (Control item in groupBox_Teclado1.Controls)
                    {
                        if (item.Name.Equals("txt_Acceso1"))
                        {
                            groupBox_Teclado1.ForeColor = Color.DarkGray;
                            groupBox_Pin.ForeColor = Color.DarkGray;
                            groupBox_BuscarTeclado.Enabled = false;
                            item.Enabled = true;
                        }
                    }
                    boton_DesconectarTeclado.Enabled = true;
                }
                if (tecladoActivo2 == true)
                {
                    groupBox_Teclado2.Enabled = true;
                    groupBox_Pin.Enabled = true;
                    foreach (Control item in groupBox_Teclado2.Controls)
                    {
                        if (item.Name.Equals("txt_Acceso2"))
                        {
                            groupBox_Teclado2.ForeColor = Color.DarkGray;
                            groupBox_Pin.ForeColor = Color.DarkGray;
                            groupBox_BuscarTeclado.Enabled = false;
                            item.Enabled = true;
                        }
                    }
                    boton_DesconectarTeclado.Enabled = true;
                }
                pin = false;
            }
            else
            {
                pin = true;
            }
            if (dactilar == true)
            {
                if (lectorActivo1 == true)
                {
                    boton_DesconectarLector.Enabled = true;
                    groupBox_Huella1.Enabled = true;
                }
                if (tecladoActivo2 == true)
                {
                    boton_DesconectarLector.Enabled = true;
                    groupBox_Huella2.Enabled = true;
                }
                dactilar = false;
            }
            else
            {
                dactilar = true;
            }
        }

        private void Boton_Buscar_Click(object sender, EventArgs e)
        {
            if (comboBox_Salas.Text == String.Empty)
            {
                MessageBox.Show("Debe escoger una SALA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var busqueda = urlCamara.ShowDialog();
                if (busqueda != DialogResult.OK)
                {
                    MessageBox.Show("No se ha seleccionado una Camara.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    txt_CamaraURL.Text = urlCamara.CameraURL;
                    boton_Conectar.Enabled = true;
                    boton_Conectar.Focus();
                }
            }
        }

        private void Color_Scroll(object sender, ScrollEventArgs e)
        {
            if (comboBox_Salas.SelectedIndex == 0)
            {
                etiquetaSaturacion.Text = scrollBar_Saturacion.Value.ToString();
                etiquetaContraste.Text = scrollBar_Contraste.Value.ToString();
                etiquetaBrillo.Text = scrollBar_Brillo.Value.ToString();
                etiquetaGamma.Text = scrollBar_Gamma.Value.ToString();
                saturacionS1 = scrollBar_Saturacion.Value;
                contrasteS1 = scrollBar_Contraste.Value;
                brilloS1 = scrollBar_Brillo.Value;
                gammaS1 = scrollBar_Gamma.Value;
                eventoActual.ManipulacionColor(scrollBar_Saturacion.Value, scrollBar_Contraste.Value, scrollBar_Gamma.Value, scrollBar_Brillo.Value);
            }
            else
            {
                etiquetaSaturacion.Text = scrollBar_Saturacion.Value.ToString();
                etiquetaContraste.Text = scrollBar_Contraste.Value.ToString();
                etiquetaBrillo.Text = scrollBar_Brillo.Value.ToString();
                etiquetaGamma.Text = scrollBar_Gamma.Value.ToString();
                saturacionS2 = scrollBar_Saturacion.Value;
                contrasteS2 = scrollBar_Contraste.Value;
                brilloS2 = scrollBar_Brillo.Value;
                gammaS2 = scrollBar_Gamma.Value;
                eventoActual.ManipulacionColor(scrollBar_Saturacion.Value, scrollBar_Contraste.Value, scrollBar_Gamma.Value, scrollBar_Brillo.Value);
            }
        }

        private void LoginSistema_Click(object sender, EventArgs e)
        {
            FinalizarServidor();
            Inicio_Sesion cambio = new Inicio_Sesion();
            cambio.ShowDialog();
            sesion = cambio.administrador;
            nombreAdministrador = cambio.nombre;
            apellidoAdministrador = cambio.apellido;
            if (sesion == true)
            {
                Eventos.Escribir("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + " ha iniciado sesion.");
                Thread servidor = new Thread(Servidor.Main);
                groupBox_Teclado1.ForeColor = Color.Black;
                groupBox_Teclado2.ForeColor = Color.Black;
                ActivarDeteccionFacial_Click(sender, e);
                ActivarHuellaDactilar_Click(sender, e);
                administrarBiometricos.Enabled = true;
                groupBox_Pin.ForeColor = Color.Black;
                administrarUsuarios.Enabled = true;
                ActivarPINAcceso_Click(sender, e);
                interfaz = canal.CreateChannel();
                reportesEventos.Enabled = true;
                logoutSistema.Enabled = true;
                loginSistema.Enabled = false;
                servidor.IsBackground = true;
                Thread.Sleep(1000);
                servidor.Start();
            }
            else
            {
                return;
            }
        }

        private void OrientarImagen(object sender, EventArgs e)
        {
            var girarX = checkBox_Horizontal.Checked;
            var girarY = checkBox_Vertical.Checked;
            if (girarX == true && girarY == true)
            {
                Eventos.Escribir("La camara de " + nombreSala + " ha girado horizontalmente y verticalmente.");
                if (comboBox_Salas.SelectedIndex == 0)
                {
                    orientacionSala1 = 11;
                }
                else
                {
                    orientacionSala2 = 11;
                }
                videoSalaActual.FlipMode = FlipMode.FlipXY;
                return;
            }
            if (girarX == false && girarY == false)
            {
                Eventos.Escribir("La camara de " + nombreSala + " ha regresado a la posición normal.");
                if (comboBox_Salas.SelectedIndex == 0)
                {
                    orientacionSala1 = 00;
                }
                else
                {
                    orientacionSala2 = 00;
                }
                videoSalaActual.FlipMode = FlipMode.None;
                return;
            }
            if (girarX == true)
            {
                Eventos.Escribir("La camara de " + nombreSala + " ha girado horizontalmente.");
                if (comboBox_Salas.SelectedIndex == 0)
                {
                    orientacionSala1 = 10;
                }
                else
                {
                    orientacionSala2 = 10;
                }
                videoSalaActual.FlipMode = FlipMode.FlipX;
                return;
            }
            if (girarY == true)
            {
                Eventos.Escribir("La camara de " + nombreSala + " ha girado verticalmente.");
                if (comboBox_Salas.SelectedIndex == 0)
                {
                    orientacionSala1 = 01;
                }
                else
                {
                    orientacionSala2 = 01;
                }
                videoSalaActual.FlipMode = FlipMode.FlipY;
                return;
            }
            videoSalaActual.FlipMode = FlipMode.None;
        }

        protected override void WndProc(ref Message mensaje)
        {
            if (dispositivoTeclado != null)
            {
                dispositivoTeclado.ProcesarMensajes(mensaje);
            }
            base.WndProc(ref mensaje);
        }

        private void ElementosComboBoxSalaTeclado()
        {
            comboBox_SalaTeclado.Items.Clear();
            comboBox_SalaTeclado.Items.Add("Sala De Redes 1");
            comboBox_SalaTeclado.Items.Add("Sala De Redes 2");
        }

        private void ObternerInformacionCamaraUSB()
        {
            txt_DetallesCamara.Text = "No se pudo obtener detalles de la Camara.";
            txt_Audio.Text = "No se pudo obtener información de Audio.";
            txt_Video.Text = "No se pudo obtener información de Video.";
            groupBox_Detalles.Text = "Detalles Camara USB";
        }

        private void LlamadaEvento(Action llamada)
        {
            BeginInvoke(llamada);
        }

        private void ElementosComboBoxSalaLector()
        {
            comboBox_SalasLector.Items.Clear();
            comboBox_SalasLector.Items.Add("Sala De Redes 1");
            comboBox_SalasLector.Items.Add("Sala De Redes 2");
        }

        private void DesactivarDetallesTeclado()
        {
            boton_DesconectarTeclado.Enabled = false;
            boton_ConectarTeclado.Enabled = false;
            txt_NombreTeclado.Text = String.Empty;
            boton_BuscarTeclado.Enabled = true;
            boton_BuscarTeclado.Focus();
        }

        private void ObtenerInformacionCamara()
        {
            txt_DetallesCamara.Text = eventoActual.InformacionDispositivo();
            txt_Audio.Text = eventoActual.InformacionAudio();
            txt_Video.Text = eventoActual.InformacionVideo();
            groupBox_Detalles.Text = "Detalles Camara IP";
        }

        private void DesactivarDetallesLector()
        {
            boton_DesconectarLector.Enabled = false;
            boton_ConectarLector.Enabled = false;
            txt_NombreLector.Text = String.Empty;
            boton_BuscarLector.Enabled = true;
            boton_BuscarLector.Focus();
        }

        private void ActivarDetallesTeclado()
        {
            boton_DesconectarTeclado.Enabled = true;
            boton_ConectarTeclado.Enabled = false;
            boton_BuscarTeclado.Enabled = false;
        }

        private void ActivarDetallesLector()
        {
            boton_DesconectarLector.Enabled = true;
            boton_ConectarLector.Enabled = false;
            boton_BuscarLector.Enabled = false;
        }

        private void ElementosComboBoxSala()
        {
            comboBox_Salas.Items.Clear();
            comboBox_Salas.Items.Add("Sala De Redes 1");
            comboBox_Salas.Items.Add("Sala De Redes 2");
            txt_DetallesCamara.Text = String.Empty;
            txt_Audio.Text = String.Empty;
            txt_Video.Text = String.Empty;
            boton_Buscar.Focus();
        }

        private void AbrirCerradura_Sala1()
        {
            string puerto = "";
            foreach (var item in SerialPort.GetPortNames())
            {
                puerto = item;
            }
            try
            {
                arduino.PortName = puerto;
                arduino.BaudRate = 9600;
                arduino.Open();
                arduino.Write("1");
                arduino.Close();
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con la cerradura.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirCerradura_Sala2()
        {
            string puerto = "";
            foreach (var item in SerialPort.GetPortNames())
            {
                puerto = item;
            }
            try
            {
                arduino.PortName = puerto;
                arduino.BaudRate = 9600;
                arduino.Open();
                arduino.Write("2");
                arduino.Close();
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con la cerradura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesactivarDetalles()
        {
            txt_DetallesCamara.Text = String.Empty;
            groupBox_Orientacion.Enabled = false;
            checkBox_Horizontal.Checked = false;
            groupBox_Detalles.Text = "Detalles";
            txt_DetallesCamara.Enabled = false;
            checkBox_Vertical.Checked = false;
            txt_CamaraURL.Text = String.Empty;
            boton_Desconectar.Enabled = false;
            groupBox_Colores.Enabled = false;
            scrollBar_Saturacion.Value = 1;
            boton_Conectar.Enabled = false;
            etiquetaSaturacion.Text = "1";
            scrollBar_Contraste.Value = 1;
            txt_Audio.Text = String.Empty;
            txt_Video.Text = String.Empty;
            groupBox_Zoom.Enabled = false;
            etiquetaContraste.Text = "1";
            scrollBar_Brillo.Value = 1;
            etiquetaBrillo.Text = "1";
            txt_Audio.Enabled = false;
            txt_Video.Enabled = false;
            scrollBar_Gamma.Value = 1;
            etiquetaGamma.Text = "1";
        }

        private void BloquearElementos()
        {
            boton_DeshabilitarReconocimiento1.Enabled = false;
            boton_DeshabilitarReconocimiento2.Enabled = false;
            groupBox_ReconocimientoSala1.Enabled = false;
            groupBox_ReconocimientoSala2.Enabled = false;
            boton_DesconectarTeclado.Enabled = false;
            boton_DesconectarLector.Enabled = false;
            administrarBiometricos.Enabled = false;
            boton_ConectarTeclado.Enabled = false;
            boton_ConectarLector.Enabled = false;
            administrarUsuarios.Enabled = false;
            txt_NombreTeclado.Enabled = false;
            boton_Desconectar.Enabled = false;
            groupBox_Teclado1.Enabled = false;
            groupBox_Teclado2.Enabled = false;
            reportesEventos.Enabled = false;
            groupBox_Facial.Enabled = false;
            groupBox_Huella.Enabled = false;
            boton_Conectar.Enabled = false;
            groupBox_Sala1.Enabled = false;
            groupBox_Sala2.Enabled = false;
            txt_CamaraURL.Enabled = false;
            logoutSistema.Enabled = false;
            groupBox_Pin.Enabled = false;
        }

        private void EstadoOrientacion()
        {
            if (comboBox_Salas.SelectedIndex == 0)
            {
                if (orientacionSala1 == 00)
                {
                    checkBox_Horizontal.Checked = false;
                    checkBox_Vertical.Checked = false;
                }
                if (orientacionSala1 == 01)
                {
                    checkBox_Horizontal.Checked = false;
                    checkBox_Vertical.Checked = true;
                }
                if (orientacionSala1 == 10)
                {
                    checkBox_Horizontal.Checked = true;
                    checkBox_Vertical.Checked = false;
                }
                if (orientacionSala1 == 11)
                {
                    checkBox_Horizontal.Checked = true;
                    checkBox_Vertical.Checked = true;
                }
            }
            else
            {
                if (orientacionSala2 == 00)
                {
                    checkBox_Horizontal.Checked = false;
                    checkBox_Vertical.Checked = false;
                }
                if (orientacionSala2 == 01)
                {
                    checkBox_Horizontal.Checked = false;
                    checkBox_Vertical.Checked = true;
                }
                if (orientacionSala2 == 10)
                {
                    checkBox_Horizontal.Checked = true;
                    checkBox_Vertical.Checked = false;
                }
                if (orientacionSala2 == 11)
                {
                    checkBox_Horizontal.Checked = true;
                    checkBox_Vertical.Checked = true;
                }
            }
        }

        private void FinalizarServidor()
        {
            (interfaz as ICommunicationObject).Close();
            Servidor.StopServer();
        }

        public Sistema_Seguridad_FIEE()
        {
            Eventos.Mensaje_Recibido += EventoMensajeRecibido;
            InitializeComponent();
            IniciarServidor();
            PantallaSalas();
            NumeroCamaras();
        }

        private void IniciarServidor()
        {
            interfaz = canal.CreateChannel();
            servidor.IsBackground = true;
            Thread.Sleep(1000);
            servidor.Start();
        }

        private void ActivarTeclados()
        {
            dispositivoTeclado = new Eventos_Teclado(Handle);
            numeroTeclados = dispositivoTeclado.NumeroDispositivos();
            dispositivoTeclado.TeclaPresionada += new Eventos_Teclado.ControladorEventosTeclado(TeclaPresionada);
        }

        private void ActivarLectores()
        {
            Controls.Add(dispositivoDactilar);
            try
            {
                dispositivoDactilar.OnImageReceived += Huella_Recibida;
                dispositivoDactilar.OnCapture += Huella_Enrolada;
                if (dispositivoDactilar.InitEngine() == 0)
                {
                    dispositivoDactilar.FPEngineVersion = "9";
                }
                else
                {
                    MessageBox.Show("No Hay dispositivos conectados", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error al iniciar el lector.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivarDetalles()
        {
            txt_CamaraURL.Text = eventoActual.EventoCamara.CameraURL;
            groupBox_Orientacion.Enabled = true;
            txt_DetallesCamara.Enabled = true;
            boton_Desconectar.Enabled = true;
            groupBox_Colores.Enabled = true;
            boton_Conectar.Enabled = false;
            boton_Buscar.Enabled = false;
            groupBox_Zoom.Enabled = true;
            txt_Audio.Enabled = true;
            txt_Video.Enabled = true;
            EstadoOrientacion();
            EstadoColores();
        }

        private void ConectarCamara()
        {
            eventoActual.ConexionCamara(urlCamara.CameraURL);
            videoSalaActual.Start();
            if (comboBox_Salas.SelectedIndex == 0)
            {
                groupBox_ReconocimientoSala1.Enabled = true;
                groupBox_Sala1.Enabled = true;
            }
            if (comboBox_Salas.SelectedIndex == 1)
            {
                groupBox_ReconocimientoSala2.Enabled = true;
                groupBox_Sala2.Enabled = true;
            }
        }

        private void FinalizarSalas()
        {
            foreach (var transmisiones in listaEventos)
            {
                transmisiones.Detener();
            }
            listaEventos.Clear();
            listaEventos = null;
            foreach (var videos in listaVideoSalas)
            {
                videos.Stop();
                videos.Dispose();
            }
            if (eventoActual != null)
            {
                eventoActual.Detener();
            }
            listaVideoSalas.Clear();
            listaVideoSalas = null;
        }

        private void NumeroCamaras()
        {
            var i = 0;
            while (i < 2)
            {
                listaEventos.Add(new Eventos_Camara());
                i++;
            }
        }

        private void PantallaSalas()
        {
            videoSalaActual = videoSala1;
            listaVideoSalas.Add(videoSalaActual);
            listaVideoSalas.Add(videoSala2);
        }

        private void EstadoColores()
        {
            if (comboBox_Salas.SelectedIndex == 0)
            {
                etiquetaSaturacion.Text = saturacionS1.ToString();
                etiquetaContraste.Text = contrasteS1.ToString();
                etiquetaBrillo.Text = brilloS1.ToString();
                scrollBar_Saturacion.Value = saturacionS1;
                etiquetaGamma.Text = gammaS1.ToString();
                scrollBar_Contraste.Value = contrasteS1;
                scrollBar_Brillo.Value = brilloS1;
                scrollBar_Gamma.Value = gammaS1;
            }
            else
            {
                etiquetaSaturacion.Text = saturacionS2.ToString();
                etiquetaContraste.Text = contrasteS2.ToString();
                etiquetaBrillo.Text = brilloS2.ToString();
                scrollBar_Saturacion.Value = saturacionS2;
                etiquetaGamma.Text = gammaS2.ToString();
                scrollBar_Contraste.Value = contrasteS2;
                scrollBar_Brillo.Value = brilloS2;
                scrollBar_Gamma.Value = gammaS2;
            }
        }

        private void IniciarSalas()
        {
            var i = 0;
            while (i < listaVideoSalas.Count)
            {
                listaVideoSalas[i].SetImageProvider(listaEventos[i].EventoProveedorImagen);
                i++;
            }
            foreach (var item in listaEventos)
            {
                item.EventoCambioEstadoCamara += EstadoCamara;
                item.EventoErrorEnCamara += ErrorCamara;
            }
        }

        private void ObtenerPin1()
        {
            try
            {
                objetoremotoUsuario.pinUsuario = Convert.ToInt32(txt_Acceso1.Text);
                (objetoremotoUsuario as IObjetoRemoto).ConsultaPinUsuario(recibirDatosUsuario);
                if (recibirDatosUsuario.Count() > 0)
                {
                    foreach (var item in recibirDatosUsuario)
                    {
                        Eventos.Escribir("El usuario" + " " + item.Nombre + " " + item.Apellido + " " + "ha ingresado a la Sala De Redes 1.");
                        etiquetaRespuesta3.Text = "Pin Verificado - Acceso Concedido.";
                        AbrirCerradura_Sala1();
                        txt_Acceso1.Clear();
                    }
                }
                else
                {
                    etiquetaRespuesta3.Text = "Pin No Verificado - Acceso Denegado.";
                    txt_Acceso1.Clear();
                }
                recibirDatosUsuario.Clear();
            }
            catch
            {
                etiquetaRespuesta3.Text = "Pin No Verificado - Acceso Denegado.";
                recibirDatosUsuario.Clear();
                txt_Acceso1.Clear();
            }
        }

        private void ObtenerPin2()
        {
            try
            {
                objetoremotoUsuario.pinUsuario = Convert.ToInt32(txt_Acceso2.Text);
                (objetoremotoUsuario as IObjetoRemoto).ConsultaPinUsuario(recibirDatosUsuario);
                if (recibirDatosUsuario.Count() > 0)
                {
                    foreach (var item in recibirDatosUsuario)
                    {
                        Eventos.Escribir("El usuario" + " " + item.Nombre + " " + item.Apellido + " " + "ha ingresado a la Sala De Redes 2.");
                        etiquetaRespuesta4.Text = "Pin Verificado - Acceso Concedido.";
                        AbrirCerradura_Sala2();
                        txt_Acceso2.Clear();
                    }
                }
                else
                {
                    etiquetaRespuesta4.Text = "Pin No Verificado - Acceso Denegado.";
                    txt_Acceso2.Clear();
                }
                recibirDatosUsuario.Clear();
            }
            catch
            {
                etiquetaRespuesta4.Text = "Pin No Verificado - Acceso Denegado.";
                recibirDatosUsuario.Clear();
                txt_Acceso2.Clear();
            }
        }
    }
}