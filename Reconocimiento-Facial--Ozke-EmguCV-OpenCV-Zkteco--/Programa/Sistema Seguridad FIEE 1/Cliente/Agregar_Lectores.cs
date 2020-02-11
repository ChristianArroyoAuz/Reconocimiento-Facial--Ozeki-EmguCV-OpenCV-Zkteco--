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


using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using AxZKFPEngXControl;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System;

namespace Cliente
{
    public partial class Agregar_Lectores : Form
    {
        private AxZKFPEngX dispositivoDactilar = new AxZKFPEngX();
        public List<string> listaLectores = new List<string>();
        private const int noBotonCerrar = 0x200;
        public string pasarRegistro;
        public string pasarNombre;

        private void DataGridView_Lectores_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            etiquetaDescripcion.Text = dataGridView_Lectores.Rows[e.RowIndex].Cells[0].Value.ToString();
            etiquetaRegistro.Text = dataGridView_Lectores.Rows[e.RowIndex].Cells[1].Value.ToString();
            pasarRegistro = dataGridView_Lectores.Rows[e.RowIndex].Cells[1].Value.ToString();
            pasarNombre = dataGridView_Lectores.Rows[e.RowIndex].Cells[0].Value.ToString();
            boton_OK.Enabled = true;
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
            etiquetaDescripcion.Text = dispositivoDactilar.CompanyName;
            etiquetaRegistro.Text = dispositivoDactilar.SensorSN;
        }

        private void Huella_Enrolada(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            string informacion = dispositivoDactilar.EncodeTemplate1(e.aTemplate);
            txt_Huella.Text = informacion;
        }

        private void Boton_Cancelar_Click(object sender, EventArgs e)
        {
            dispositivoDactilar.OnImageReceived -= Huella_Recibida;
            dispositivoDactilar.OnCapture -= Huella_Enrolada;
            try
            {
                dispositivoDactilar.EndEngine();
            }
            catch (Exception)
            {
                //NADA
            }
            pasarRegistro = String.Empty;
            pasarNombre = String.Empty;
            Close();
        }

        private void Boton_Agregar_Click(object sender, EventArgs e)
        {
            if (etiquetaDescripcion.Text == String.Empty || etiquetaRegistro.Text == String.Empty)
            {
                MessageBox.Show("Para agregar un lector tome ua muestra dactilar y luego presione el boton AGREGAR. Se le recuerda no conectar un lector durante este proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (listaLectores.Contains(etiquetaDescripcion.Text + "@" + etiquetaRegistro.Text))
                {
                    MessageBox.Show("El lector ya ha sido agregado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    listaLectores.Add(etiquetaDescripcion.Text + "@" + etiquetaRegistro.Text);
                    dataGridView_Lectores.Rows.Add(etiquetaDescripcion.Text, etiquetaRegistro.Text);
                    dataGridView_Lectores.Rows[0].Selected = true;
                }
            }
        }

        private void Boton_Buscar_Click(object sender, EventArgs e)
        {
            DialogResult busqueda = MessageBox.Show("Antes de buscar un lector debe agregarlo. Caso contrario presione CANCELAR, y conectelo.", "INFORMACIÓN", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (busqueda == DialogResult.OK)
            {
                LectoresGuardados();
                boton_Buscar.Enabled = false;
                boton_Agregar.Enabled = true;
                IniciarDispositivo();
                txt_Informacion.Text = "Muestra de la huella.";
            }
            else
            {
                return;
            }
        }

        private void Boton_OK_Click(object sender, EventArgs e)
        {
            if (dataGridView_Lectores.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar un Lector.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dispositivoDactilar.OnImageReceived -= Huella_Recibida;
                dispositivoDactilar.OnCapture -= Huella_Enrolada;
                dispositivoDactilar.EndEngine();
                Close();
            }
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

        private void IniciarDispositivo()
        {
            try
            {
                Controls.Add(dispositivoDactilar);
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

        private void LectoresGuardados()
        {
            if (listaLectores.Count == 0)
            {
                return;
            }
            else
            {
                foreach (var lectores in listaLectores)
                {
                    string[] dato = lectores.Split('@');
                    dataGridView_Lectores.Rows.Add(dato[0], dato[1]);
                    dataGridView_Lectores.Rows[0].Selected = true;
                }
            }
        }

        private void BloquearElementos()
        {
            boton_Agregar.Enabled = false;
            boton_OK.Enabled = false;
        }

        public Agregar_Lectores()
        {
            InitializeComponent();
            BloquearElementos();
        }
    }
}