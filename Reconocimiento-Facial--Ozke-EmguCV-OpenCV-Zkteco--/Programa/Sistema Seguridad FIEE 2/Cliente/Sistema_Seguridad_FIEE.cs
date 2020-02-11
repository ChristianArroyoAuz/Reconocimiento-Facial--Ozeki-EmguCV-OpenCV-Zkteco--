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
        private delegate void Informacion(string sala);
        private Image<Gray, byte> escalaGrises = null;
        private SerialPort arduino = new SerialPort();
        private string laboratorio = "laboratorio";
        private Eventos_Teclado dispositivoTeclado;
        private string rutaNombresEntrenamiento;
        private string[] nombresEntrenamiento;
        private Image<Bgr, byte> videoRostro;
        private string apellidoAdministrador;
        private Image<Gray, byte> imagenGris;
        private HaarCascade deteccionRostro;
        private bool videoIniciado = false;
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
        private Graphics nuevaImagen;
        private string nombre = null;
        private int orientacionSala;
        private string borrarLector;
        private string nombreLector;
        private string cargarRostro;
        private Bitmap capturaVideo;
        private int saturacion = 1;
        private bool tecladoActivo;
        private int numeroTeclados;
        private int contraste = 1;
        private bool lectorActivo;
        private bool camaraActiva;
        private int identificador;
        private int numeroNombres;
        private string nombreSala;
        private bool pin = true;
        private int brillo = 1;
        private int tiempo = 0;
        private bool Comprobar;
        private int gamma = 1;
        private bool facial;
        private bool sesion;
        private int SX;
        private int SY;

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
                    try
                    {
                        arduino.Write("T");
                        arduino.Write("O");
                        arduino.Write("J");
                        arduino.Write("X");
                        arduino.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo establecer comunicación con la cerradura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    Graphics huella = pictureBox_Huella.CreateGraphics();
                    Bitmap imagenHuella = new Bitmap(pictureBox_Huella.Width, pictureBox_Huella.Height);
                    huella = Graphics.FromImage(imagenHuella);
                    int contador = huella.GetHdc().ToInt32();
                    dispositivoDactilar.PrintImageAt(contador, 0, 0, imagenHuella.Width, imagenHuella.Height);
                    huella.Dispose();
                    pictureBox_Huella.Image = imagenHuella;
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
                    txt_Acceso.Focus();
                }
            }
        }

        private void Boton_DeshabilitarReconocimiento_Click(object sender, EventArgs e)
        {
            if (boton_HabilitarReconocimiento.Enabled == true)
            {
                boton_DeshabilitarReconocimiento.Enabled = false;
                boton_HabilitarReconocimiento.Enabled = true;
                reconocimientoSala.Image = null;
                timer_Ubicacion.Enabled = false;
                timer_Deteccion.Enabled = false;
            }
            else
            {
                Eventos.Escribir("Se ha deshabilitado el Reconocimiento Facial.");
                etiquetaCantidadRostrosDetectados.Text = String.Empty;
                boton_DeshabilitarReconocimiento.Enabled = false;
                boton_HabilitarReconocimiento.Enabled = true;
                etiquetaPersonaEnCuadro.Text = String.Empty;
                etiquetaRespuesta1.Text = String.Empty;
                reconocimientoSala.Image = null;
                timer_Ubicacion.Enabled = false;
                timer_Deteccion.Enabled = false;
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
                    (objetoremotoUsuario as IObjetoRemoto).ObtenerHuellas(recibirDatosUsuario);
                    foreach (Usuarios item in recibirDatosUsuario)
                    {
                        if (dispositivoDactilar.VerFingerFromStr(ref informacionHuella, item.Huella, false, ref Comprobar))
                        {
                            Eventos.Escribir("El usuario" + " " + item.Nombre + " " + item.Apellido + " " + "ha ingresado a la " + nombreSala + ".");
                            etiquetaRespuesta3.Text = "Huella Verificada - Acceso Concedido.";
                            try
                            {
                                if (System.Text.RegularExpressions.Regex.IsMatch(nombreSala, "1", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                {
                                    AbrirCerradura_Sala1();
                                }
                                if (System.Text.RegularExpressions.Regex.IsMatch(nombreSala, "2", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                {
                                    AbrirCerradura_Sala2();
                                }
                            }
                            catch
                            {
                                //NADA
                            }
                            break;
                        }
                        else
                        {
                            etiquetaRespuesta3.Text = "Huella No Verificada - Acceso Denegado.";
                        }
                    }
                    recibirDatosUsuario.Clear();
                }
            }
        }

        private void Boton_HabilitarReconocimiento_Click(object sender, EventArgs e)
        {
            try
            {
                Eventos.Escribir("Se ha habilitado el Reconocimiento Facial.");
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
                boton_DeshabilitarReconocimiento.Enabled = true;
                boton_HabilitarReconocimiento.Enabled = false;
                timer_Ubicacion.Enabled = true;
                timer_Deteccion.Enabled = true;
            }
            catch
            {
                MessageBox.Show("No hay nada en la base de datos binaria, agregue al menos un rostro.", "Carga de Rostros de Entrenamiento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Boton_DesconectarTeclado_Click(object sender, EventArgs e)
        {
            if (txt_NombreTeclado.Text != String.Empty)
            {
                foreach (var elemento in recuperarTeclados)
                {
                    string[] eliminar = elemento.Split('@');
                    Eventos.Escribir("Se ha desconectado el teclado " + eliminar[0] + ".");
                    tecladosConectados.Remove(eliminar[1]);
                    borrarTeclado = elemento;
                    teclados.Clear();
                }
                recuperarTeclados.Remove(borrarTeclado);
                groupBox_Teclado.Enabled = false;
                txt_Acceso.Text = String.Empty;
                DesactivarDetallesTeclado();
                tecladoActivo = false;
                groupBox_Pin.Focus();
                DesactivarPin();
            }
            else
            {
                MessageBox.Show("No se ha podido desconectar. Especifique el teclado a desconectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dispositivoTeclado.TeclaPresionada -= new Eventos_Teclado.ControladorEventosTeclado(TeclaPresionada);
            etiquetaRespuesta2.Text = "Respuesta";
        }

        private void Boton_DesconectarLector_Click(object sender, EventArgs e)
        {
            if (txt_NombreLector.Text != String.Empty)
            {
                foreach (var elemento in recuperarLectores)
                {
                    string[] eliminar = elemento.Split('@');
                    Eventos.Escribir("Se ha desconectado el lector " + eliminar[0] + ".");
                    lectoresConectados.Remove(eliminar[1]);
                    borrarLector = elemento;
                    lectores.Clear();
                }
                recuperarLectores.Remove(borrarLector);
                txt_NombreLector.Text = String.Empty;
                groupBox_Lector.Enabled = false;
                pictureBox_Huella.Image = null;
                DesactivarDetallesLector();
                groupBox_Huella.Focus();
                lectorActivo = false;
                DesactivarHuella();
            }
            else
            {
                MessageBox.Show("No se ha podido desconectar. Especifique el lector a desconectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dispositivoDactilar.OnImageReceived -= Huella_Recibida;
            dispositivoDactilar.OnCapture -= Huella_Enrolada;
            dispositivoDactilar.EndEngine();
        }

        private void RecibirSala(object sender, SerialDataReceivedEventArgs e)
        {
            string sala = arduino.ReadLine();
            BeginInvoke(new Informacion(Datos), sala);
        }

        private void Txt_Acceso1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                ObtenerPin();
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
            DesactivarDetallesTeclado();
            DesactivarDetallesLector();
            DesactivarDetalles();
            BloquearElementos();
            IniciarSalas();
        }

        private void Boton_ConectarTeclado_Click(object sender, EventArgs e)
        {
            if (txt_NombreTeclado.Text != String.Empty)
            {
                if (tecladosConectados.Contains(registroTeclado))
                {
                    MessageBox.Show("El teclado ya esta siendo utilizado. Debe escoger otro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Eventos.Escribir("Se ha conectado al teclado " + nombreTeclado + ".");
                    recuperarTeclados.Add(nombreTeclado + "@" + registroTeclado);
                    groupBox_Teclado.Enabled = true;
                    tecladoActivo = true;
                    ActivarTeclados();
                    ActivarPin();
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

        private void Boton_CapturarImagen_Click(object sender, EventArgs e)
        {
            if (txt_Guardar.Text != String.Empty)
            {
                string rutaSala;
                rutaSala = txt_Guardar.Text;
                listaEventos[0].TomarSnapShot(rutaSala, laboratorio);
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar la imagen.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    MessageBox.Show("El lector ya esta siendo utilizado. Debe escoger otro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Eventos.Escribir("Se ha conectado al lector " + nombreLector + ".");
                    recuperarLectores.Add(nombreLector + "@" + registroLector);
                    groupBox_Lector.Enabled = true;
                    lectorActivo = true;
                    ActivarLectores();
                    ActivarHuella();
                }
            }
            else
            {
                MessageBox.Show("Debe escoger un LECTOR y una SALA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_FinalizarVideo_Click(object sender, EventArgs e)
        {
            if (videoIniciado == true)
            {
                listaEventos[0].DetenerCapturaVideo(laboratorio);
                videoIniciado = false;
            }
            else
            {
                MessageBox.Show("Primero debe iniciar el video.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Reconocimiento_Tick(object sender, EventArgs e)
        {
            tiempo++;
        }

        private void Boton_BuscarTeclado_Click(object sender, EventArgs e)
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

        private void Boton_DisminuirZoom_Click(object sender, EventArgs e)
        {
            eventoActual.Zoom("Disminuir", laboratorio);
        }

        private void Boton_IniciarVideo_Click(object sender, EventArgs e)
        {
            if (txt_Guardar.Text != String.Empty)
            {
                string rutaSala;
                videoIniciado = true;
                rutaSala = txt_Guardar.Text;
                listaEventos[0].IniciarCapturaVideo(rutaSala, laboratorio);
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar el video.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_BuscarLector_Click(object sender, EventArgs e)
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

        private void Boton_AumentarZoom_Click(object sender, EventArgs e)
        {
            eventoActual.Zoom("Aumentar", laboratorio);
        }

        private void Boton_LimpiarSala1_Click(object sender, EventArgs e)
        {
            videoSala.ClearScreen();
            Eventos.Escribir("Se ha limpiado la pantalla.");
        }

        private void Boton_Desconectar_Click(object sender, EventArgs e)
        {
            if (videoIniciado == true)
            {
                MessageBox.Show("Debe finalizar el video que se estan grabando antes de desconectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listaCamaras.Remove(txt_CamaraURL.Text);
                if (!txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://"))
                {
                    Eventos.Escribir("Estado de la Camara IP Disconnected.");
                }
                Eventos.Escribir("Se ha desconectado la camara" + eventoActual.EventoCamara.ToString().Remove(0, eventoActual.EventoCamara.ToString().Split(' ')[0].Length) + ".");
                Eventos.Escribir("La orientación de camara normalizada.");
                Boton_DeshabilitarReconocimiento_Click(sender, e);
                groupBox_ReconocimientoSala.Enabled = false;
                eventoActual.Zoom("Default", laboratorio);
                groupBox_Camara.Enabled = false;
                orientacionSala = 00;
                saturacion = 1;
                contraste = 1;
                brillo = 1;
                gamma = 1;
                txt_CamaraURL.Text = String.Empty;
                boton_Desconectar.Enabled = false;
                boton_Buscar.Enabled = true;
                eventoActual.Desconectar();
                DesactivarDetalles();
                DesactivarRostro();
            }
        }

        private void EstadoCamara(object sender, CameraStateEventArgs e)
        {
            LlamadaEvento(() =>
            {
                if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://"))
                {
                    Eventos.Escribir("Estado de la Camara USB: " + e.State + ".");
                }
                else
                {
                    Eventos.Escribir("Estado de la Camara IP: " + e.State + ".");
                }
                switch (e.State)
                {
                    case CameraState.Streaming:
                        {
                            if (txt_CamaraURL.Text.ToUpper().Trim().StartsWith("USB://"))
                            {
                                Eventos.Escribir("Se ha conectado a la camara" + eventoActual.EventoCamara.ToString().Remove(0, eventoActual.EventoCamara.ToString().Split(' ')[0].Length) + ".");
                                ObternerInformacionCamaraUSB();
                                break;
                            }
                            else
                            {
                                Eventos.Escribir("Se ha conectado a la camara" + eventoActual.EventoCamara.ToString().Remove(0, eventoActual.EventoCamara.ToString().Split(' ')[0].Length) + ".");
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
                Eventos.Escribir("Error en la Camara USB: " + (e.Details ?? e.Error.ToString()) + ".");
            }
            else
            {
                Eventos.Escribir("Error en la Camara IP: " + (e.Details ?? e.Error.ToString()) + ".");
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

        private void Timer_Deteccion_Tick(object sender, EventArgs e)
        {
            capturaVideo = new Bitmap(317, 215);
            nuevaImagen = CreateGraphics();
            nuevaImagen = Graphics.FromImage(capturaVideo);
            nuevaImagen.CopyFromScreen(SX + 30, SY + 105, 0, 0, new Size(317, 215));
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
                etiquetaCantidadRostrosDetectados.Text = rostroDetectado[0].Length.ToString();
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
            etiquetaPersonaEnCuadro.Text = nombres;
            nombres = "";
            nombrePersonas.Clear();
            reconocimientoSala.Image = videoRostro;
            if (rostroDetectado[0].Length < 1)
            {
                etiquetaRespuesta1.Text = "No hay personas en cuadro.";
                etiquetaCantidadRostrosDetectados.Text = "0";
                etiquetaPersonaEnCuadro.Text = String.Empty;
                timer_Reconocimiento.Enabled = false;
                tiempo = 0;
            }
            else
            {
                if (rostroDetectado[0].Length >= 2)
                {
                    etiquetaRespuesta1.Text = "Demasiadas personas en cuadro.";
                    timer_Reconocimiento.Enabled = false;
                    tiempo = 0;
                }
                else
                {
                    if (nombre != String.Empty)
                    {
                        etiquetaRespuesta1.Text = String.Empty;
                        timer_Reconocimiento.Enabled = true;
                        if (tiempo == 3)
                        {
                            Eventos.Escribir("El usuario" + " " + etiquetaPersonaEnCuadro.Text + " " + "ha ingresado a la " + nombreSala + ".");
                            timer_Reconocimiento.Stop();
                            try
                            {
                                if (System.Text.RegularExpressions.Regex.IsMatch(nombreSala, "1", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                {
                                    AbrirCerradura_Sala1();
                                }
                                if (System.Text.RegularExpressions.Regex.IsMatch(nombreSala, "2", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                                {
                                    AbrirCerradura_Sala2();
                                }
                            }
                            catch
                            {
                                //NADA
                            }
                            tiempo = 100;
                        }
                        if (tiempo >= 3)
                        {
                            etiquetaRespuesta1.Text = "Rostro Verificado - Acceso Concedido.";
                        }
                    }
                    else
                    {
                        etiquetaRespuesta1.Text = "Rostro No Verificado - Acceso Denegado.";
                        timer_Reconocimiento.Enabled = false;
                        tiempo = 0;
                    }
                }
            }
        }

        private void Timer_Ubicacion_Tick(object sender, EventArgs e)
        {
            Point ubicacionPantalla1 = PointToScreen(groupBox_Camara.Location);
            SX = ubicacionPantalla1.X;
            SY = ubicacionPantalla1.Y;
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
                    MessageBox.Show("La camara ya esta siendo utilizada. Debe escoger otra.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    listaCamaras.Add(txt_CamaraURL.Text);
                    videoSalaActual = listaVideoSalas[0];
                    eventoActual = listaEventos[0];
                    camaraActiva = true;
                    ConectarCamara();
                    ActivarDetalles();
                    ActivarRostro();
                }
            }
            else
            {
                MessageBox.Show("Debe escoger una CAMARA antes de conectar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_Guardar_Click(object sender, EventArgs e)
        {
            var busquedaRuta = buscadorArchivos.ShowDialog();
            if (busquedaRuta == DialogResult.OK)
            {
                txt_Guardar.Text = buscadorArchivos.SelectedPath;
                Eventos.Escribir("Se ha seleecionado la ruta " + txt_Guardar.Text + ".");
            }
            else
            {
                MessageBox.Show("No se escogio una ruta.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LogoutSistema_Click(object sender, EventArgs e)
        {
            Eventos.Escribir("El Administrador " + nombreAdministrador + " " + "ha finalizado sesion.");
            logoutSistema.Enabled = false;
            loginSistema.Enabled = true;
            BloquearElementos();
            sesion = false;
            if (facial == true)
            {
                if (camaraActiva == true)
                {
                    boton_DeshabilitarReconocimiento.Enabled = true;
                    groupBox_ReconocimientoSala.Enabled = true;
                    boton_Desconectar.Enabled = true;
                    groupBox_Camara.Enabled = true;
                }
                facial = false;
            }
            else
            {
                facial = true;
            }
            if (pin == true)
            {
                if (tecladoActivo == true)
                {
                    groupBox_Teclado.Enabled = true;
                    groupBox_Pin.Enabled = true;
                    foreach (Control item in groupBox_Teclado.Controls)
                    {
                        if (item.Name.Equals("txt_Acceso1"))
                        {
                            groupBox_Teclado.ForeColor = Color.DarkGray;
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
                if (lectorActivo == true)
                {
                    boton_DesconectarLector.Enabled = true;
                    groupBox_Lector.Enabled = true;
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

        private void Color_Scroll(object sender, ScrollEventArgs e)
        {
            etiquetaSaturacion.Text = scrollBar_Saturacion.Value.ToString();
            etiquetaContraste.Text = scrollBar_Contraste.Value.ToString();
            etiquetaBrillo.Text = scrollBar_Brillo.Value.ToString();
            etiquetaGamma.Text = scrollBar_Gamma.Value.ToString();
            saturacion = scrollBar_Saturacion.Value;
            contraste = scrollBar_Contraste.Value;
            brillo = scrollBar_Brillo.Value;
            gamma = scrollBar_Gamma.Value;
            eventoActual.ManipulacionColor(scrollBar_Saturacion.Value, scrollBar_Contraste.Value, scrollBar_Gamma.Value, scrollBar_Brillo.Value);
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
                groupBox_Teclado.ForeColor = Color.Black;
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
                Eventos.Escribir("La camara ha girado horizontalmente y verticalmente.");

                orientacionSala = 11;

                videoSalaActual.FlipMode = FlipMode.FlipXY;
                return;
            }
            if (girarX == false && girarY == false)
            {
                Eventos.Escribir("La camara ha regresado a la posición normal.");

                orientacionSala = 00;

                videoSalaActual.FlipMode = FlipMode.None;
                return;
            }
            if (girarX == true)
            {
                Eventos.Escribir("La camara ha girado horizontalmente.");

                orientacionSala = 10;

                videoSalaActual.FlipMode = FlipMode.FlipX;
                return;
            }
            if (girarY == true)
            {
                Eventos.Escribir("La camara ha girado verticalmente.");

                orientacionSala = 01;

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

        private void AbrirCerradura_Sala1()
        {
            try
            {
                arduino.Write("1");
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con la cerradura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirCerradura_Sala2()
        {
            try
            {
                arduino.Write("2");
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
            boton_DeshabilitarReconocimiento.Enabled = false;
            groupBox_ReconocimientoSala.Enabled = false;
            boton_DesconectarTeclado.Enabled = false;
            boton_DesconectarLector.Enabled = false;
            administrarBiometricos.Enabled = false;
            boton_ConectarTeclado.Enabled = false;
            boton_ConectarLector.Enabled = false;
            administrarUsuarios.Enabled = false;
            txt_NombreTeclado.Enabled = false;
            boton_Desconectar.Enabled = false;
            groupBox_Teclado.Enabled = false;
            reportesEventos.Enabled = false;
            groupBox_Facial.Enabled = false;
            groupBox_Huella.Enabled = false;
            boton_Conectar.Enabled = false;
            groupBox_Camara.Enabled = false;
            txt_CamaraURL.Enabled = false;
            logoutSistema.Enabled = false;
            groupBox_Pin.Enabled = false;
        }

        private void EstadoOrientacion()
        {
            if (orientacionSala == 00)
            {
                checkBox_Horizontal.Checked = false;
                checkBox_Vertical.Checked = false;
            }
            if (orientacionSala == 01)
            {
                checkBox_Horizontal.Checked = false;
                checkBox_Vertical.Checked = true;
            }
            if (orientacionSala == 10)
            {
                checkBox_Horizontal.Checked = true;
                checkBox_Vertical.Checked = false;
            }
            if (orientacionSala == 11)
            {
                checkBox_Horizontal.Checked = true;
                checkBox_Vertical.Checked = true;
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
            IniciarArduino();
            PantallaSalas();
            NumeroCamaras();
        }

        private void DesactivarHuella()
        {
            try
            {
                arduino.Write("J");
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con el Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesactivarRostro()
        {
            try
            {
                arduino.Write("T");
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con el Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Datos(string sala)
        {
            nombreSala = String.Empty;
            nombreSala = sala;
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

        private void IniciarArduino()
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
                arduino.DtrEnable = true;
                arduino.Open();
                arduino.DataReceived += RecibirSala;
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con el Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConectarCamara()
        {
            eventoActual.ConexionCamara(urlCamara.CameraURL);
            videoSalaActual.Start();
            groupBox_ReconocimientoSala.Enabled = true;
            groupBox_Camara.Enabled = true;
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
            videoSalaActual = videoSala;
            listaVideoSalas.Add(videoSalaActual);
        }

        private void EstadoColores()
        {
            etiquetaSaturacion.Text = saturacion.ToString();
            etiquetaContraste.Text = contraste.ToString();
            etiquetaBrillo.Text = brillo.ToString();
            scrollBar_Saturacion.Value = saturacion;
            etiquetaGamma.Text = gamma.ToString();
            scrollBar_Contraste.Value = contraste;
            scrollBar_Brillo.Value = brillo;
            scrollBar_Gamma.Value = gamma;
        }

        private void ActivarRostro()
        {
            try
            {
                arduino.Write("R");
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con el Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesactivarPin()
        {
            try
            {
                arduino.Write("O");
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con el Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivarHuella()
        {
            try
            {
                arduino.Write("H");
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con el Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ObtenerPin()
        {
            try
            {
                objetoremotoUsuario.pinUsuario = Convert.ToInt32(txt_Acceso.Text);
                (objetoremotoUsuario as IObjetoRemoto).ConsultaPinUsuario(recibirDatosUsuario);
                if (recibirDatosUsuario.Count() > 0)
                {
                    foreach (var item in recibirDatosUsuario)
                    {
                        Eventos.Escribir("El usuario" + " " + item.Nombre + " " + item.Apellido + " " + "ha ingresado a la " + nombreSala + ".");
                        etiquetaRespuesta2.Text = "Pin Verificado - Acceso Concedido.";
                        try
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(nombreSala, "1", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                AbrirCerradura_Sala1();
                            }
                            if (System.Text.RegularExpressions.Regex.IsMatch(nombreSala, "2", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                            {
                                AbrirCerradura_Sala2();
                            }
                        }
                        catch
                        {
                            //NADA
                        }
                        txt_Acceso.Clear();
                    }
                }
                else
                {
                    etiquetaRespuesta2.Text = "Pin No Verificado - Acceso Denegado.";
                    txt_Acceso.Clear();
                }
                recibirDatosUsuario.Clear();
            }
            catch
            {
                etiquetaRespuesta2.Text = "Pin No Verificado - Acceso Denegado.";
                recibirDatosUsuario.Clear();
                txt_Acceso.Clear();
            }
        }

        private void ActivarPin()
        {
            try
            {
                arduino.Write("P");
            }
            catch
            {
                MessageBox.Show("No se pudo establecer comunicación con el Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}