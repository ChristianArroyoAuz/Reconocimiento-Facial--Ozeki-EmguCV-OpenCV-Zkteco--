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

using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.ServiceModel;
using System.Collections;
using System.Threading;
using System.Drawing;
using ObjetoRemoto;
using System.Data;
using System.Linq;
using System.Text;
using System;

namespace Cliente
{
    public partial class Inicio_Sesion : Form
    {
        private ChannelFactory<IObjetoRemoto> canal = new ChannelFactory<IObjetoRemoto>(new NetTcpBinding(), "net.tcp://localhost:8080");
        private ObjetoRemoto.ObjetoRemoto objetoremotoUsuario = new ObjetoRemoto.ObjetoRemoto();
        private List<Usuarios> recibirDatosUsuario = new List<Usuarios>();
        private Thread servidor = new Thread(Servidor.Main);
        private const int noBotonCerrar = 0x200;
        private IObjetoRemoto interfaz;
        private bool existe = false;
        public bool administrador;
        public string apellido;
        public string nombre;

        private void Boton_Ingresar_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == "" || txt_Usuario.Text == "")
            {
                MessageBox.Show("Debe LLenar Todos Los Espacios.", "Advertencia.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Usuario.Focus();
            }
            else
            {
                try
                {
                    ObtenerUsuario();
                    if (existe == true)
                    {
                        FinalizarServidor();
                        MessageBox.Show("Bienvenido: " + "  " + nombre + " " + apellido + ".", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        administrador = true;
                        LimpiarCampos();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No existen usuarios registrados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarCampos();
                    }
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error en la ejecucion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Boton_Regresar_Click(object sender, EventArgs e)
        {
            FinalizarServidor();
            Close();
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

        private void FinalizarServidor()
        {
            (interfaz as ICommunicationObject).Close();
            Servidor.StopServer();
        }

        private void IniciarServidor()
        {
            interfaz = canal.CreateChannel();
            servidor.IsBackground = true;
            Thread.Sleep(1000);
            servidor.Start();
        }

        private void ObtenerUsuario()
        {
            objetoremotoUsuario.aliasUsuario = txt_Usuario.Text;
            objetoremotoUsuario.passwordUsuario = txt_Password.Text;
            (objetoremotoUsuario as IObjetoRemoto).ConsultaDatosUsuario(recibirDatosUsuario);
            if (recibirDatosUsuario.Count() > 0)
            {
                foreach (var item in recibirDatosUsuario)
                {
                    apellido = item.Apellido;
                    nombre = item.Nombre;
                }
                existe = true;
            }
            else
            {
                existe = false;
            }
            recibirDatosUsuario.Clear(); ;
        }

        private void LimpiarCampos()
        {
            txt_Password.Clear();
            txt_Usuario.Clear();
            txt_Usuario.Focus();
        }

        public Inicio_Sesion()
        {
            InitializeComponent();
            IniciarServidor();
        }
    }
}