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


using verificador = System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.ServiceModel;
using System.Collections;
using AxZKFPEngXControl;
using Emgu.CV.Structure;
using System.Data.Linq;
using System.Threading;
using System.Drawing;
using Emgu.CV.CvEnum;
using ObjetoRemoto;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using Emgu.CV;
using System;

namespace Cliente
{
    public partial class Administracion_Usuarios : Form
    {
        private ChannelFactory<IObjetoRemoto> canal = new ChannelFactory<IObjetoRemoto>(new NetTcpBinding(), "net.tcp://localhost:8080");
        private ObjetoRemoto.ObjetoRemoto objetoremotoUsuario = new ObjetoRemoto.ObjetoRemoto();
        private List<Image<Gray, byte>> imagenesEntrenamiento = new List<Image<Gray, byte>>();
        private MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        private List<Usuarios> recibirDatosUsuario = new List<Usuarios>();
        private AxZKFPEngX dispositivoDactilar = new AxZKFPEngX();
        private List<string> nombresUsuarios = new List<string>();
        private List<string> nombrePersonas = new List<string>();
        public List<string> usuariosCRUD = new List<string>();
        private OpenFileDialog buscar = new OpenFileDialog();
        private Thread servidor = new Thread(Servidor.Main);
        private Image<Gray, byte> imagenGuardar = null;
        private Image<Gray, byte> escalaGrises = null;
        private Image<Gray, byte> imagenGris = null;
        private Image<Bgr, byte> rostroActualizar;
        private const int noBotonCerrar = 0x200;
        private string rutaNombresEntrenamiento;
        private string[] nombresEntrenamiento;
        private Image<Bgr, byte> videoRostro;
        private HaarCascade deteccionRostro;
        public string apellidoAdministrador;
        private HaarCascade deteccionOjos;
        private int contadorEntrenamiento;
        public string nombreAdministrador;
        private string modificarApellido;
        private string modificarNombre;
        private IObjetoRemoto interfaz;
        private string nombres = null;
        private string nombre = null;
        private string cargarRostro;
        private string validacion;
        private int numeroNombres;
        private Capture imagen;
        public string tipoCrud;
        private bool Comprobar;
        private Binary rostro;

        private void Informacion_Huella(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            String datos = String.Empty;
            if (dispositivoDactilar.EnrollIndex != 1)
            {
                if (dispositivoDactilar.IsRegister)
                {
                    if (dispositivoDactilar.EnrollIndex - 1 > 0)
                    {
                        int contadorEnrolar = dispositivoDactilar.EnrollIndex - 1;
                        datos = "Por Favor escanee su huella otra vez." + " " + contadorEnrolar + ".";
                    }
                }
            }
            MostrarInformacion(datos);
        }

        private void DataGridView_Datos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_ConfirmarContraseña.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox_Departamento.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[7].Value.ToString();
            txt_Contraseña.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox_Tipo.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[6].Value.ToString();
            txt_Apellido.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[4].Value.ToString();
            modificarApellido = dataGridView_Datos.Rows[e.RowIndex].Cells[4].Value.ToString();
            rostro = new Binary((byte[])dataGridView_Datos.Rows[e.RowIndex].Cells[11].Value);
            txt_Huella.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[10].Value.ToString();
            txt_Correo.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[8].Value.ToString();
            txt_Nombre.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[3].Value.ToString();
            modificarNombre = dataGridView_Datos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Alias.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Pin.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[9].Value.ToString();
            txt_Id.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Facial.Text = rostro.ToArray().ToString();
            if (dataGridView_Datos.Rows[e.RowIndex].Cells[1].Value.ToString().Length == 9)
            {
                txt_Cedula.Text = "0" + dataGridView_Datos.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
            {
                txt_Cedula.Text = dataGridView_Datos.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void Huella_Recibida(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics huella = pictureBox_Huella.CreateGraphics();
            Bitmap imagenHuella = new Bitmap(pictureBox_Huella.Width, pictureBox_Huella.Height);
            huella = Graphics.FromImage(imagenHuella);
            int contador = huella.GetHdc().ToInt32();
            dispositivoDactilar.PrintImageAt(contador, 0, 0, imagenHuella.Width, imagenHuella.Height);
            huella.Dispose();
            pictureBox_Huella.Image = imagenHuella;
        }

        private void Capturar_Huella(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            string huella = dispositivoDactilar.EncodeTemplate1(e.aTemplate);
            if (dispositivoDactilar.VerFingerFromStr(ref huella, txt_RegistroHuella.Text, false, ref Comprobar))
            {
                MostrarInformacion("Huella Verificada.");
            }
            else
            {
                MostrarInformacion("Huella No Verificada. Registre Otra Vez");
            }
        }

        private void Huella_Enrolada(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult)
            {
                string informacion = dispositivoDactilar.EncodeTemplate1(e.aTemplate);
                txt_RegistroHuella.Text = informacion;
                MostrarInformacion("Registro Exitoso. Ahora puede Verificar.");
                boton_VerificarHuella.Enabled = true;
            }
            else
            {
                MostrarInformacion("Error al registrar. Registre Otra Vez.");
            }
        }

        private void Boton_HabilitarReconocimiento_Click(object sender, EventArgs e)
        {
            BuscarImagenesEntrenamiento();
            imagen = new Capture(1);
            imagen.QueryFrame();
            Application.Idle += new EventHandler(Capturadora);
        }

        private void Txt_ConfirmarContraseña_Leave(object sender, EventArgs e)
        {
            if (txt_ConfirmarContraseña.Text != txt_Contraseña.Text)
            {
                MessageBox.Show("La contraseña no coincide.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ConfirmarContraseña.Text = String.Empty;
                txt_Contraseña.Text = String.Empty;
            }
        }

        private void Administracion_Usuarios_Load(object sender, EventArgs e)
        {
            usuariosCRUD.Clear();
            BloquearElementos();
            DatosDepartamento();
            DatosTipo();
            CRUD();
        }

        private void Boton_RegistrarHuella_Click(object sender, EventArgs e)
        {
            dispositivoDactilar.CancelEnroll();
            dispositivoDactilar.EnrollCount = 3;
            dispositivoDactilar.BeginEnroll();
            MostrarInformacion("Por Favor. Ingrese una muestra de su huella.");
        }

        private void Txt_Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Boton_VerificarHuella_Click(object sender, EventArgs e)
        {
            if (dispositivoDactilar.IsRegister)
            {
                dispositivoDactilar.CancelEnroll();
            }
            dispositivoDactilar.OnCapture += Capturar_Huella;
            dispositivoDactilar.BeginCapture();
            MostrarInformacion("Por Favor. Dar una muestra de la huella.");
        }

        private void Boton_DetectarHuella_Click(object sender, EventArgs e)
        {
            boton_DetectarHuella.Enabled = false;
            Controls.Add(dispositivoDactilar);
            groupBox_Dactilar.Enabled = true;
            IniciarDispositivo();
        }

        private void Boton_DetectarRostro_Click(object sender, EventArgs e)
        {
            boton_GuardarRostro.Enabled = false;
            groupBox_Detectar.Enabled = true;
            boton_BuscarFoto.Enabled = false;
        }

        private void Boton_GuardarHuella_Click(object sender, EventArgs e)
        {
            dispositivoDactilar.OnFeatureInfo -= Informacion_Huella;
            dispositivoDactilar.OnImageReceived -= Huella_Recibida;
            dispositivoDactilar.OnEnroll -= Huella_Enrolada;
            dispositivoDactilar.EndEngine();
            txt_Huella.Text = txt_RegistroHuella.Text;
            txt_SerialDispositivo.Text = String.Empty;
            txt_RegistroHuella.Text = String.Empty;
            boton_VerificarHuella.Enabled = false;
            boton_RegistrarHuella.Enabled = true;
            boton_DetectarHuella.Enabled = true;
            boton_GuardarHuella.Enabled = false;
            etiquetaDatos.Text = String.Empty;
            groupBox_Dactilar.Enabled = false;
            pictureBox_Huella.Image = null;
        }

        private void Boton_GuardarRostro_Click(object sender, EventArgs e)
        {
            try
            {
                contadorEntrenamiento = contadorEntrenamiento + 1;
                escalaGrises = imagen.QueryGrayFrame().Resize(320, 240, INTER.CV_INTER_CUBIC);
                MCvAvgComp[][] rostroDetectado = escalaGrises.DetectHaarCascade(deteccionRostro, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                foreach (MCvAvgComp rostro in rostroDetectado[0])
                {
                    imagenGuardar = videoRostro.Copy(rostro.rect).Convert<Gray, byte>();
                    break;
                }
                imagenGuardar = imagenGris.Resize(100, 100, INTER.CV_INTER_CUBIC);
                imagenesEntrenamiento.Clear();
                nombresUsuarios.Clear();
                if (tipoCrud == "Registro")
                {
                    BuscarImagenesEntrenamiento();
                    imagenesEntrenamiento.Add(imagenGuardar);
                    nombresUsuarios.Add(txt_Nombre.Text + " " + txt_Apellido.Text);
                }
                byte[] fotoByte = Imagen_A_ArregloBytes(imagenGuardar.ToBitmap());
                rostro = null;
                rostro = new Binary(fotoByte);
                txt_Facial.Text = rostro.ToArray().ToString();
                MessageBox.Show("Se ha agregado el rostro del usuario.", "Imagen Agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se pudo agregar la image, intelo otra vez.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            imagen.Dispose();
            Application.Idle -= new EventHandler(Capturadora);
            boton_HabilitarReconocimiento.Enabled = true;
            boton_DetectarRostro.Enabled = true;
            boton_GuardarRostro.Enabled = false;
            groupBox_Detectar.Enabled = false;
            reconocimientoRostro.Image = null;
            boton_BuscarFoto.Enabled = true;
        }

        private void EtiquetaDatos_TextChanged(object sender, EventArgs e)
        {
            if (etiquetaDatos.Text == "Huella Verificada.")
            {
                boton_GuardarHuella.Enabled = true;
            }
        }

        private void Txt_Pin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Boton_BuscarImagen_Click(object sender, EventArgs e)
        {
            boton_GuardarFoto.Enabled = true;
            boton_BuscarFoto.Enabled = false;
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                BuscarImagenesEntrenamiento();
                Image imagenEntrada = Image.FromFile(buscar.FileName);
                videoRostro = new Image<Bgr, byte>(new Bitmap(imagenEntrada));
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
                        videoRostro.Draw(nombre, ref font, new Point(rostro.rect.X - 2, rostro.rect.Y - 2), new Bgr(Color.LightGreen));
                    }
                    nombrePersonas.Add("");
                    nombrePersonas[numeroNombres - 1] = nombre;
                    nombrePersonas.Add("");
                    etiquetaCantidasRostrosFoto.Text = rostroDetectado[0].Length.ToString();
                    escalaGrises.ROI = rostro.rect;
                    MCvAvgComp[][] eyesDetected = escalaGrises.DetectHaarCascade(deteccionOjos, 1.1, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                    escalaGrises.ROI = Rectangle.Empty;
                    foreach (MCvAvgComp ey in eyesDetected[0])
                    {
                        Rectangle eyeRect = ey.rect;
                        eyeRect.Offset(rostro.rect.X, rostro.rect.Y);
                        videoRostro.Draw(eyeRect, new Bgr(Color.Blue), 2);
                    }
                }
                numeroNombres = 0;
                for (int nnn = 0; nnn < rostroDetectado[0].Length; nnn++)
                {
                    nombres = nombres + nombrePersonas[nnn] + ", ";
                }
                reconocimientoFoto.Image = videoRostro;
                nombres = "";
                nombrePersonas.Clear();
            }
        }

        private void Boton_GuardarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                contadorEntrenamiento = contadorEntrenamiento + 1;
                Image imagenEntrada = Image.FromFile(buscar.FileName);
                videoRostro = new Image<Bgr, byte>(new Bitmap(imagenEntrada));
                escalaGrises = videoRostro.Convert<Gray, byte>();
                MCvAvgComp[][] rostroDetectado = escalaGrises.DetectHaarCascade(deteccionRostro, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                foreach (MCvAvgComp rostro in rostroDetectado[0])
                {
                    imagenGuardar = videoRostro.Copy(rostro.rect).Convert<Gray, byte>();
                    break;
                }
                imagenGuardar = imagenGris.Resize(100, 100, INTER.CV_INTER_CUBIC);
                imagenesEntrenamiento.Clear();
                nombresUsuarios.Clear();
                if (tipoCrud == "Registro")
                {
                    BuscarImagenesEntrenamiento();
                    imagenesEntrenamiento.Add(imagenGuardar);
                    nombresUsuarios.Add(txt_Nombre.Text + " " + txt_Apellido.Text);
                }
                byte[] fotoByte = Imagen_A_ArregloBytes(imagenGuardar.ToBitmap());
                rostro = null;
                rostro = new Binary(fotoByte);
                txt_Facial.Text = rostro.ToArray().ToString();
                MessageBox.Show("Se ha agregado el rostro del usuario.", "Imagen Agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se pudo agregar la image, intelo otra vez.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            boton_DetectarRostro.Enabled = true;
            groupBox_BuscarFoto.Enabled = false;
            boton_GuardarFoto.Enabled = false;
            boton_BuscarFoto.Enabled = true;
            reconocimientoFoto.Image = null;
        }

        private void Boton_BuscarFoto_Click(object sender, EventArgs e)
        {
            boton_DetectarRostro.Enabled = false;
            groupBox_BuscarFoto.Enabled = true;
            boton_GuardarFoto.Enabled = false;
        }

        private void Boton_Actualizar_Click(object sender, EventArgs e)
        {
            if (txt_Cedula.Text == String.Empty || txt_Alias.Text == String.Empty || txt_Nombre.Text == String.Empty || txt_Apellido.Text == String.Empty || txt_Contraseña.Text == String.Empty || txt_ConfirmarContraseña.Text == String.Empty || comboBox_Tipo.SelectedIndex < 0 || comboBox_Departamento.SelectedIndex < 0 || txt_Correo.Text == String.Empty || txt_Pin.Text == String.Empty || txt_Huella.Text == String.Empty || txt_Facial.Text == String.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DialogResult pregunta = MessageBox.Show("Seguro desea modificar el usuario?", "Confirmacion", MessageBoxButtons.YesNo);
                    if (pregunta == DialogResult.Yes)
                    {
                        string numeroIndice = "";
                        string indiceUsuario = Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt";
                        StreamReader indice = new StreamReader(indiceUsuario);
                        int contador = 0;
                        string registro = "";
                        registro = indice.ReadLine();
                        string[] separador = registro.Split('%');
                        foreach (string usuario in separador)
                        {
                            if (usuario == modificarNombre + " " + modificarApellido)
                            {
                                numeroIndice = contador.ToString();
                            }
                            contador++;
                        }
                        indice.Dispose();
                        string rutaRegistrUsuario = File.ReadAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt");
                        rutaRegistrUsuario = rutaRegistrUsuario.Replace(separador[Convert.ToInt16(numeroIndice)], txt_Nombre.Text + " " + txt_Apellido.Text);
                        File.WriteAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt", rutaRegistrUsuario);
                        BuscarImagenesEntrenamiento();
                        rostroActualizar = new Image<Bgr, byte>(new Bitmap(ArregloBytes_A_Imagen(rostro.ToArray())));
                        imagenesEntrenamiento[Convert.ToInt16(numeroIndice) - 1] = rostroActualizar.Convert<Gray, byte>();
                        for (int i = 1; i < imagenesEntrenamiento.ToArray().Length + 1; i++)
                        {
                            imagenesEntrenamiento.ToArray()[i - 1].Save(Application.StartupPath + "/Rostros_De_Entrenamiento/Rostro_Entrenamiento_" + i + ".bmp");
                        }
                        try
                        {
                            dataGridView_Datos.Rows[0].Selected = true;
                        }
                        catch
                        {
                            MessageBox.Show("No existen filas seleccionadas.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        dataGridView_Datos.Rows[0].Selected = true;
                        imagenesEntrenamiento.Clear();
                        nombresUsuarios.Clear();
                        ModificarDatos();
                    }
                    else
                    {
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error en el registro.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Boton_Registrar_Click(object sender, EventArgs e)
        {
            if (txt_Cedula.Text == String.Empty || txt_Alias.Text == String.Empty || txt_Nombre.Text == String.Empty || txt_Apellido.Text == String.Empty || txt_Contraseña.Text == String.Empty || txt_ConfirmarContraseña.Text == String.Empty || comboBox_Tipo.SelectedIndex < 0 || comboBox_Departamento.SelectedIndex < 0 || txt_Correo.Text == String.Empty || txt_Pin.Text == String.Empty || txt_Huella.Text == String.Empty || txt_Facial.Text == String.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ValidarAdministrador() == true)
                {
                    try
                    {
                        objetoremotoUsuario.departamentoUsuario = comboBox_Departamento.SelectedItem.ToString();
                        objetoremotoUsuario.identificadorUsuario = Convert.ToInt32(txt_Id.Text);
                        objetoremotoUsuario.tipoUsuario = comboBox_Tipo.SelectedItem.ToString();
                        objetoremotoUsuario.cedulaUsuario = Convert.ToInt32(txt_Cedula.Text);
                        objetoremotoUsuario.pinUsuario = Convert.ToInt32(txt_Pin.Text);
                        objetoremotoUsuario.passwordUsuario = txt_Contraseña.Text;
                        objetoremotoUsuario.apellidoUsuario = txt_Apellido.Text;
                        objetoremotoUsuario.nombreUsuario = txt_Nombre.Text;
                        objetoremotoUsuario.correoUsuario = txt_Correo.Text;
                        objetoremotoUsuario.huellaUsuario = txt_Huella.Text;
                        objetoremotoUsuario.aliasUsuario = txt_Alias.Text;
                        objetoremotoUsuario.rostroUsuario = rostro;
                        (objetoremotoUsuario as IObjetoRemoto).AgregarUsuario(recibirDatosUsuario);
                        foreach (Usuarios item in recibirDatosUsuario)
                        {
                            dataGridView_Datos.DataSource = objetoremotoUsuario.usuaurioCRUD.Select(x => x).Select(y => new
                            {
                                ID = y.Id,
                                CEDULA = y.Cedula,
                                ALIAS = y.Alias,
                                NOMBRE = y.Nombre,
                                APELLIDO = y.Apellido,
                                PASSWORD = y.Password,
                                TIPO = y.Tipo,
                                DEPARTAMENTO = y.Departamento,
                                CORREO = y.Correo,
                                PIN = y.Pin,
                                HUELLA = y.Huella,
                                ROSTRO = y.Rostro.ToArray()
                            }).ToList();
                        }
                        dataGridView_Datos.Rows[0].Selected = false;
                        recibirDatosUsuario.Clear();
                        File.WriteAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt", imagenesEntrenamiento.ToArray().Length.ToString() + "%");
                        for (int i = 1; i < imagenesEntrenamiento.ToArray().Length + 1; i++)
                        {
                            imagenesEntrenamiento.ToArray()[i - 1].Save(Application.StartupPath + "/Rostros_De_Entrenamiento/Rostro_Entrenamiento_" + i + ".bmp");
                            File.AppendAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt", nombresUsuarios.ToArray()[i - 1].ToString() + "%");
                        }
                        MessageBox.Show("Usuario registrado con exito.", "Felicidades.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        usuariosCRUD.Add(txt_Nombre.Text + "@" + txt_Apellido.Text);
                        listBox_Logs.Items.Add("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + " ha agregado al usuario " + txt_Nombre.Text + " " + txt_Apellido.Text + ".");
                        imagenesEntrenamiento.Clear();
                        nombresUsuarios.Clear();
                        CargarDatos();
                        CargarIdentificador();
                        dataGridView_Datos.ClearSelection();
                        LimpiarCampos();
                    }
                    catch (Exception xxx)
                    {
                        MessageBox.Show(xxx + "Ha ocurrido un error en el registro.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se permite registrar más Administradores.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Boton_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Seguro desea eliminar el usurio?", "Confirmacion", MessageBoxButtons.YesNo);
            if (pregunta == DialogResult.Yes)
            {
                string numeroIndice = "";
                string indiceUsuario = Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt";
                StreamReader indice = new StreamReader(indiceUsuario);
                int contador = 0;
                string registro = "";
                registro = indice.ReadLine();
                string[] separador = registro.Split('%');
                foreach (string usuario in separador)
                {
                    if (usuario == txt_Nombre.Text + " " + txt_Apellido.Text)
                    {
                        numeroIndice = contador.ToString();
                    }
                    contador++;
                }
                indice.Dispose();
                string rutaRegistrUsuario = File.ReadAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt");
                rutaRegistrUsuario = rutaRegistrUsuario.Replace(txt_Nombre.Text + " " + txt_Apellido.Text + "%", "");
                rutaRegistrUsuario = rutaRegistrUsuario.Replace(separador[0], Convert.ToString(Convert.ToInt16(separador[0]) - 1));
                File.WriteAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt", rutaRegistrUsuario);
                DirectoryInfo archivos = new DirectoryInfo(Application.StartupPath + "/Rostros_De_Entrenamiento/");
                if (File.Exists(Application.StartupPath + "/Rostros_De_Entrenamiento/Rostro_Entrenamiento_" + numeroIndice + ".bmp"))
                {
                    File.Delete(Application.StartupPath + "/Rostros_De_Entrenamiento/Rostro_Entrenamiento_" + numeroIndice + ".bmp");
                }
                int contadorImagenes = 1;
                foreach (var listaArchivos in archivos.GetFiles())
                {
                    if (listaArchivos.ToString().Contains("Rostro_Entrenamiento_"))
                    {
                        try
                        {
                            File.Move(Application.StartupPath + "/Rostros_De_Entrenamiento/" + listaArchivos.ToString(), Application.StartupPath + "/Rostros_De_Entrenamiento/Rostro_Entrenamiento_" + contadorImagenes + ".bmp");
                            contadorImagenes++;
                        }
                        catch
                        {
                            //NADA
                        }

                    }
                }
                objetoremotoUsuario.identificadorUsuario = Convert.ToInt32(txt_Id.Text);
                EliminarDatos();
            }
            else
            {
                return;
            }
        }

        private void Boton_Regresar_Click(object sender, EventArgs e)
        {
            try
            {
                dispositivoDactilar.EndEngine();
            }
            catch
            {
                //NADA
            }
            if (imagen != null)
            {
                imagen.Dispose();
                Application.Idle -= new EventHandler(Capturadora);
            }
            (interfaz as ICommunicationObject).Close();
            Servidor.StopServer();
            Close();
        }

        private void Txt_Contraseña_Leave(object sender, EventArgs e)
        {
            if (txt_Contraseña.Text.Length > 0)
            {
                if (ValidarContraseña(txt_Contraseña.Text))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La contraseña debe tener almenos un número, un caracter especial, una mayuscula, minusculas y una longitud de 6 a 15 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Contraseña.Clear();
                }
            }
        }

        private byte[] Imagen_A_ArregloBytes(Image imagenEntrada)
        {
            using (MemoryStream memoria = new MemoryStream())
            {
                imagenEntrada.Save(memoria, System.Drawing.Imaging.ImageFormat.Gif);
                return memoria.ToArray();
            }
        }

        private void Txt_Cedula_Leave(object sender, EventArgs e)
        {
            if (txt_Cedula.Text.Length > 0)
            {
                if (ValidarLongitud() == true)
                {
                    VerificarCedula();
                }
                else
                {
                    txt_Cedula.Clear();
                }
            }
        }

        private void Txt_Correo_Leave(object sender, EventArgs e)
        {
            if (txt_Correo.Text.Length > 0)
            {
                if (ValidarCorreo(txt_Correo.Text))
                {
                    VerificarCorreo();
                }
                else
                {
                    MessageBox.Show("Correo en formato invalido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Correo.Clear();
                }
            }
        }

        private Image ArregloBytes_A_Imagen(byte[] arregloBytes)
        {
            using (MemoryStream memoria = new MemoryStream(arregloBytes))
            {
                Image retornarImagen = Image.FromStream(memoria);
                return retornarImagen;
            }
        }

        private void Txt_Alias_Leave(object sender, EventArgs e)
        {
            VerificarUsuario();
        }

        private void Txt_Pin_Leave(object sender, EventArgs e)
        {
            if (txt_Pin.Text.Length >= 4)
            {
                VerificarPin();
            }
            else
            {
                MessageBox.Show("El PIN de Acceso debe tener un longitud minima de 4 digitos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Capturadora(object sender, EventArgs e)
        {
            try
            {
                videoRostro = imagen.QueryFrame().Resize(320, 240, INTER.CV_INTER_CUBIC);
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
                        videoRostro.Draw(nombre, ref font, new Point(rostro.rect.X - 2, rostro.rect.Y - 2), new Bgr(Color.LightGreen));
                    }
                    nombrePersonas.Add("");
                    nombrePersonas[numeroNombres - 1] = nombre;
                    nombrePersonas.Add("");
                    etiquetaCantidadRostrosDetectados.Text = rostroDetectado[0].Length.ToString();
                    escalaGrises.ROI = rostro.rect;
                    MCvAvgComp[][] eyesDetected = escalaGrises.DetectHaarCascade(deteccionOjos, 1.1, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                    escalaGrises.ROI = Rectangle.Empty;
                    foreach (MCvAvgComp ey in eyesDetected[0])
                    {
                        Rectangle eyeRect = ey.rect;
                        eyeRect.Offset(rostro.rect.X, rostro.rect.Y);
                        videoRostro.Draw(eyeRect, new Bgr(Color.Blue), 2);
                    }
                }
                numeroNombres = 0;
                for (int nnn = 0; nnn < rostroDetectado[0].Length; nnn++)
                {
                    nombres = nombres + nombrePersonas[nnn] + ", ";
                }
                reconocimientoRostro.Image = videoRostro;
                nombres = "";
                nombrePersonas.Clear();
                boton_HabilitarReconocimiento.Enabled = false;
                boton_DetectarRostro.Enabled = false;
                boton_GuardarRostro.Enabled = true;
            }
            catch
            {
                MessageBox.Show("La Camara esta siendo usada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Idle -= new EventHandler(Capturadora);
                boton_HabilitarReconocimiento.Enabled = true;
                boton_DetectarRostro.Enabled = true;
                boton_GuardarRostro.Enabled = false;
                groupBox_Detectar.Enabled = false;
                reconocimientoRostro.Image = null;
                boton_BuscarFoto.Enabled = true;
            }
        }

        private bool ValidarContraseña(string contraseña)
        {
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                return false;
            }
            try
            {
                return verificador.Regex.IsMatch(contraseña, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$", verificador.RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch
            {
                return false;
            }
        }

        private void MostrarInformacion(String dato)
        {
            etiquetaDatos.Text = dato;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cerrar = base.CreateParams;
                cerrar.ClassStyle = cerrar.ClassStyle | noBotonCerrar;
                return cerrar;
            }
        }

        private void BuscarImagenesEntrenamiento()
        {
            deteccionRostro = new HaarCascade("haarcascade_frontalface_default.xml");
            deteccionOjos = new HaarCascade("haarcascade_eye.xml");
            try
            {
                rutaNombresEntrenamiento = File.ReadAllText(Application.StartupPath + "/Rostros_De_Entrenamiento/Nombres_De_Entrenamiento.txt");
                nombresEntrenamiento = rutaNombresEntrenamiento.Split('%');
                contadorEntrenamiento = Convert.ToInt32(nombresEntrenamiento[0]);
                for (int numero = 1; numero < contadorEntrenamiento + 1; numero++)
                {
                    cargarRostro = "Rostro_Entrenamiento_" + numero + ".bmp";
                    imagenesEntrenamiento.Add(new Image<Gray, byte>(Application.StartupPath + "/Rostros_De_Entrenamiento/" + cargarRostro));
                    nombresUsuarios.Add(nombresEntrenamiento[numero]);
                }
            }
            catch
            {
                MessageBox.Show("No hay nada en la base de datos binaria, agregue al menos un rostro.", "Carga de Rostros de Entrenamiento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ValidarCorreo(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            try
            {
                email = verificador.Regex.Replace(email, @"(@)(.+)$", Dominio, verificador.RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string Dominio(verificador.Match match)
                {
                    var dominioInternet = new IdnMapping();
                    var nombreDominio = dominioInternet.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + nombreDominio;
                }
            }
            catch
            {
                return false;
            }
            try
            {
                return verificador.Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", verificador.RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarAdministrador()
        {
            objetoremotoUsuario.tipoUsuario = comboBox_Tipo.SelectedItem.ToString();
            (objetoremotoUsuario as IObjetoRemoto).ObtenerAdministradores(recibirDatosUsuario);
            if (comboBox_Tipo.SelectedIndex == 0 && recibirDatosUsuario.Count() >= 2)
            {
                recibirDatosUsuario.Clear();
                return false;
            }
            else
            {
                recibirDatosUsuario.Clear();
                return true;
            }
        }

        private void CargarIdentificador()
        {
            txt_Id.Text = Convert.ToString(interfaz.ObtenerID_Usuario(0));
        }

        private void IniciarDispositivo()
        {
            try
            {
                dispositivoDactilar.OnFeatureInfo += Informacion_Huella;
                dispositivoDactilar.OnImageReceived += Huella_Recibida;
                dispositivoDactilar.OnEnroll += Huella_Enrolada;
                if (dispositivoDactilar.InitEngine() == 0)
                {
                    dispositivoDactilar.FPEngineVersion = "9";
                    dispositivoDactilar.EnrollCount = 3;
                    txt_SerialDispositivo.Text += " " + dispositivoDactilar.SensorSN;
                    MostrarInformacion("Dispositivo Conectado Correctamente.");
                }
                else
                {
                    MessageBox.Show("No hay un lector dactilar conectado. Conecte uno Por Favor.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dispositivoDactilar.OnFeatureInfo -= Informacion_Huella;
                    dispositivoDactilar.OnImageReceived -= Huella_Recibida;
                    dispositivoDactilar.OnEnroll -= Huella_Enrolada;
                    boton_VerificarHuella.Enabled = false;
                    boton_RegistrarHuella.Enabled = true;
                    boton_DetectarHuella.Enabled = true;
                    groupBox_Dactilar.Enabled = false;
                    pictureBox_Huella.Image = null;
                }
            }
            catch (Exception ex)
            {
                MostrarInformacion("Error al iniciar el dipositivo" + " " + ex.Message);
                MessageBox.Show("No hay un lector dactilar conectado. Conecte uno Por Favor.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dispositivoDactilar.OnFeatureInfo -= Informacion_Huella;
                dispositivoDactilar.OnImageReceived -= Huella_Recibida;
                dispositivoDactilar.OnEnroll -= Huella_Enrolada;
                boton_VerificarHuella.Enabled = false;
                boton_RegistrarHuella.Enabled = true;
                boton_DetectarHuella.Enabled = true;
                groupBox_Dactilar.Enabled = false;
                pictureBox_Huella.Image = null;
            }
        }

        public Administracion_Usuarios()
        {
            InitializeComponent();
            IniciarServidor();
        }

        private void BloquearElementos()
        {
            txt_ConfirmarContraseña.Enabled = false;
            boton_VerificarHuella.Enabled = false;
            comboBox_Departamento.Enabled = false;
            boton_DetectarRostro.Enabled = false;
            boton_DetectarHuella.Enabled = false;
            groupBox_BuscarFoto.Enabled = false;
            boton_GuardarHuella.Enabled = false;
            dataGridView_Datos.Enabled = false;
            groupBox_Dactilar.Enabled = false;
            groupBox_Detectar.Enabled = false;
            boton_BuscarFoto.Enabled = false;
            boton_Actualizar.Enabled = false;
            boton_Registrar.Enabled = false;
            boton_Eliminar.Enabled = false;
            txt_Contraseña.Enabled = false;
            comboBox_Tipo.Enabled = false;
            txt_Apellido.Enabled = false;
            txt_Cedula.Enabled = false;
            txt_Nombre.Enabled = false;
            txt_Correo.Enabled = false;
            txt_Huella.Enabled = false;
            txt_Facial.Enabled = false;
            txt_Alias.Enabled = false;
            txt_Pin.Enabled = false;
        }

        private void DatosDepartamento()
        {
            comboBox_Departamento.Items.Add("DETRI");
        }

        private void VerificarUsuario()
        {
            objetoremotoUsuario.aliasUsuario = txt_Alias.Text;
            (objetoremotoUsuario as IObjetoRemoto).CompararUsuario(recibirDatosUsuario);
            if (recibirDatosUsuario.Count() > 0)
            {
                MessageBox.Show("El alias ya existe, escoja otro alias.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Alias.Clear();
            }
            recibirDatosUsuario.Clear();
        }

        private void VerificarCorreo()
        {
            objetoremotoUsuario.correoUsuario = txt_Correo.Text;
            (objetoremotoUsuario as IObjetoRemoto).CompararCorreo(recibirDatosUsuario);
            if (recibirDatosUsuario.Count() > 0)
            {
                MessageBox.Show("La correo ya esta registrado.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Correo.Clear();
            }
            recibirDatosUsuario.Clear();
        }

        private void IniciarServidor()
        {
            interfaz = canal.CreateChannel();
            servidor.IsBackground = true;
            Thread.Sleep(1000);
            servidor.Start();
        }

        private void VerificarCedula()
        {
            objetoremotoUsuario.cedulaUsuario = Convert.ToInt32(txt_Cedula.Text);
            (objetoremotoUsuario as IObjetoRemoto).CompararCedula(recibirDatosUsuario);
            if (recibirDatosUsuario.Count() > 0)
            {
                MessageBox.Show("La cedula ya esta registrada.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Cedula.Clear();
            }
            recibirDatosUsuario.Clear();
        }

        private bool ValidarLongitud()
        {
            if (txt_Cedula.Text.Length < 10 || txt_Cedula.Text.Length > 10)
            {
                MessageBox.Show("La Cedula Ingresada es Incorrecta, es demasiada larga o corta. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                string cedula = txt_Cedula.Text;
                char[] vector = cedula.ToArray();
                int sumatotal = 0;
                for (int i = 0; i < vector.Length - 1; i++)
                {
                    int numero = Convert.ToInt32(vector[i].ToString());
                    if ((i + 1) % 2 == 1)
                    {
                        numero = Convert.ToInt32(vector[i].ToString()) * 2;
                        if (numero > 9)
                        {
                            numero = numero - 9;
                        }
                    }
                    sumatotal += numero;
                }
                sumatotal = 10 - (sumatotal % 10);
                if (sumatotal > 9)
                {
                    validacion = "0";
                }
                else
                {
                    validacion = Convert.ToString(sumatotal);
                }
                if (Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "1" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "2" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "3" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "4" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "5" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "6" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "7" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "8" ||
                    Convert.ToString(vector[0]) == "0" && Convert.ToString(vector[1]) == "9" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "0" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "1" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "2" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "3" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "4" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "5" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "6" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "7" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "8" ||
                    Convert.ToString(vector[0]) == "1" && Convert.ToString(vector[1]) == "9" ||
                    Convert.ToString(vector[0]) == "2" && Convert.ToString(vector[1]) == "0" ||
                    Convert.ToString(vector[0]) == "2" && Convert.ToString(vector[1]) == "1" ||
                    Convert.ToString(vector[0]) == "2" && Convert.ToString(vector[1]) == "2" ||
                    Convert.ToString(vector[0]) == "2" && Convert.ToString(vector[1]) == "3" ||
                    Convert.ToString(vector[0]) == "2" && Convert.ToString(vector[1]) == "4")
                {
                    if (Convert.ToString(vector[2]) == "0" || Convert.ToString(vector[2]) == "1" ||
                        Convert.ToString(vector[2]) == "2" || Convert.ToString(vector[2]) == "3" ||
                        Convert.ToString(vector[2]) == "4" || Convert.ToString(vector[2]) == "5")
                    {
                        if (Convert.ToString(vector[9]) == validacion)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Cedula Incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cedula Incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Cedula Incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        private void ModificarDatos()
        {
            objetoremotoUsuario.departamentoUsuario = comboBox_Departamento.SelectedItem.ToString();
            objetoremotoUsuario.identificadorUsuario = Convert.ToInt32(txt_Id.Text);
            objetoremotoUsuario.tipoUsuario = comboBox_Tipo.SelectedItem.ToString();
            objetoremotoUsuario.cedulaUsuario = Convert.ToInt32(txt_Cedula.Text);
            objetoremotoUsuario.pinUsuario = Convert.ToInt32(txt_Pin.Text);
            objetoremotoUsuario.passwordUsuario = txt_Contraseña.Text;
            objetoremotoUsuario.apellidoUsuario = txt_Apellido.Text;
            objetoremotoUsuario.nombreUsuario = txt_Nombre.Text;
            objetoremotoUsuario.correoUsuario = txt_Correo.Text;
            objetoremotoUsuario.huellaUsuario = txt_Huella.Text;
            objetoremotoUsuario.aliasUsuario = txt_Alias.Text;
            objetoremotoUsuario.rostroUsuario = rostro;
            (objetoremotoUsuario as IObjetoRemoto).ModificarUsuario(recibirDatosUsuario);
            foreach (Usuarios item in recibirDatosUsuario)
            {
                dataGridView_Datos.DataSource = objetoremotoUsuario.usuaurioCRUD.Select(x => x).Select(y => new
                {
                    ID = y.Id,
                    CEDULA = y.Cedula,
                    ALIAS = y.Alias,
                    NOMBRE = y.Nombre,
                    APELLIDO = y.Apellido,
                    PASSWORD = y.Password,
                    TIPO = y.Tipo,
                    DEPARTAMENTO = y.Departamento,
                    CORREO = y.Correo,
                    PIN = y.Pin,
                    HUELLA = y.Huella,
                    ROSTRO = y.Rostro.ToArray()
                }).ToList();
            }
            dataGridView_Datos.Rows[0].Selected = false;
            recibirDatosUsuario.Clear();
            MessageBox.Show("Usuario actualizado con exito.", "Felicidades.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            usuariosCRUD.Add(txt_Nombre.Text + "@" + txt_Apellido.Text);
            listBox_Logs.Items.Add("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + " ha actualizado al usuario " + txt_Nombre.Text + " " + txt_Apellido.Text + ".");
            CargarIdentificador();
            LimpiarCampos();
            CargarDatos();
        }

        private void EliminarDatos()
        {
            (objetoremotoUsuario as IObjetoRemoto).EliminarUsuario(recibirDatosUsuario);
            recibirDatosUsuario.Clear();
            MessageBox.Show("Usuario eliminado con exito.", "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            usuariosCRUD.Add(txt_Nombre.Text + "@" + txt_Apellido.Text);
            listBox_Logs.Items.Add("El Administrador " + nombreAdministrador + " " + apellidoAdministrador + " ha eliminado al usuario " + txt_Nombre.Text + " " + txt_Apellido.Text + ".");
            CargarDatos();
            dataGridView_Datos.Rows[0].Selected = false;
            CargarIdentificador();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            if (imagen != null)
            {
                imagen.Dispose();
                Application.Idle -= new EventHandler(Capturadora);
            }
            boton_HabilitarReconocimiento.Enabled = true;
            comboBox_Departamento.Text = String.Empty;
            boton_GuardarRostro.Enabled = false;
            groupBox_BuscarFoto.Enabled = false;
            boton_DetectarRostro.Enabled = true;
            comboBox_Departamento.Items.Clear();
            comboBox_Tipo.Text = String.Empty;
            groupBox_Dactilar.Enabled = false;
            groupBox_Detectar.Enabled = false;
            boton_GuardarFoto.Enabled = false;
            boton_BuscarImagen.Enabled = true;
            reconocimientoRostro.Image = null;
            boton_BuscarFoto.Enabled = true;
            reconocimientoFoto.Image = null;
            txt_ConfirmarContraseña.Clear();
            comboBox_Tipo.Items.Clear();
            txt_Contraseña.Clear();
            txt_Apellido.Clear();
            DatosDepartamento();
            txt_Cedula.Clear();
            txt_Nombre.Clear();
            txt_Correo.Clear();
            txt_Huella.Clear();
            txt_Facial.Clear();
            txt_Cedula.Focus();
            txt_Alias.Clear();
            txt_Pin.Clear();
            DatosTipo();
        }

        private void VerificarPin()
        {
            objetoremotoUsuario.pinUsuario = Convert.ToInt32(txt_Pin.Text);
            (objetoremotoUsuario as IObjetoRemoto).CompararPin(recibirDatosUsuario);
            if (recibirDatosUsuario.Count() > 0)
            {
                MessageBox.Show("La PIN ya esta registrado.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Pin.Clear();
            }
        }

        private void CargarDatos()
        {
            (objetoremotoUsuario as IObjetoRemoto).MostrarUsuarios(recibirDatosUsuario);
            foreach (Usuarios item in recibirDatosUsuario)
            {
                dataGridView_Datos.DataSource = objetoremotoUsuario.enviarUsuario.Select(x => x).Select(y => new
                {
                    ID = y.Id,
                    CEDULA = y.Cedula,
                    ALIAS = y.Alias,
                    NOMBRE = y.Nombre,
                    APELLIDO = y.Apellido,
                    PASSWORD = y.Password,
                    TIPO = y.Tipo,
                    DEPARTAMENTO = y.Departamento,
                    CORREO = y.Correo,
                    PIN = y.Pin,
                    HUELLA = y.Huella,
                    ROSTRO = y.Rostro.ToArray()
                }).ToList();
            }
            try
            {
                dataGridView_Datos.Rows[0].Selected = false;
            }
            catch
            {
                MessageBox.Show("No existen datos en la base de datos.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            recibirDatosUsuario.Clear();
        }

        private void DatosTipo()
        {
            comboBox_Tipo.Items.Add("Administrador");
            comboBox_Tipo.Items.Add("Ayudante");
            comboBox_Tipo.Items.Add("Profesor");
            comboBox_Tipo.Items.Add("Temporal");
        }

        private void CRUD()
        {
            if (tipoCrud == "Registro")
            {
                dataGridView_Datos.RowEnter -= new DataGridViewCellEventHandler(DataGridView_Datos_RowEnter);
                etiquetaTitulo.Text = "CREAR NUEVA CUENTA.";
                txt_ConfirmarContraseña.Enabled = true;
                comboBox_Departamento.Enabled = true;
                boton_DetectarRostro.Enabled = true;
                boton_DetectarHuella.Enabled = true;
                dataGridView_Datos.Enabled = true;
                boton_BuscarFoto.Enabled = true;
                boton_Registrar.Enabled = true;
                txt_Contraseña.Enabled = true;
                comboBox_Tipo.Enabled = true;
                txt_Apellido.Enabled = true;
                txt_Cedula.Enabled = true;
                txt_Nombre.Enabled = true;
                txt_Correo.Enabled = true;
                txt_Alias.Enabled = true;
                txt_Pin.Enabled = true;
            }
            if (tipoCrud == "Actualizar")
            {
                etiquetaTitulo.Text = "ACTUALIZAR CUENTA.";
                txt_ConfirmarContraseña.Enabled = true;
                comboBox_Departamento.Enabled = true;
                boton_DetectarRostro.Enabled = true;
                boton_DetectarHuella.Enabled = true;
                dataGridView_Datos.Enabled = true;
                boton_BuscarFoto.Enabled = true;
                boton_Actualizar.Enabled = true;
                txt_Contraseña.Enabled = true;
                comboBox_Tipo.Enabled = true;
                txt_Apellido.Enabled = true;
                txt_Cedula.Enabled = true;
                txt_Nombre.Enabled = true;
                txt_Correo.Enabled = true;
                txt_Alias.Enabled = true;
                txt_Pin.Enabled = true;
            }
            if (tipoCrud == "Eliminar")
            {
                etiquetaTitulo.Text = "ELIMINAR CUENTA.";
                dataGridView_Datos.Enabled = true;
                boton_Eliminar.Enabled = true;
            }
            CargarIdentificador();
            CargarDatos();
        }
    }
}