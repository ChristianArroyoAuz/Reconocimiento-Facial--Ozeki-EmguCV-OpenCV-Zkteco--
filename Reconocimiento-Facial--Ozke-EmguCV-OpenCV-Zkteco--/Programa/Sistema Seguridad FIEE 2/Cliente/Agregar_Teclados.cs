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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System;

namespace Cliente
{
    public partial class Agregar_Teclados : Form
    {
        public List<string> listaTeclados = new List<string>();
        private const int noBotonCerrar = 0x200;
        private Eventos_Teclado dispositivo;
        public string pasarRegistro;
        private int numeroTeclados;
        public string pasarNombre;
        private string registro;
        private string nombre;

        private void DataGridView_Teclados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            etiquetaDescripcion.Text = dataGridView_Teclados.Rows[e.RowIndex].Cells[0].Value.ToString();
            etiquetaRegistro.Text = dataGridView_Teclados.Rows[e.RowIndex].Cells[1].Value.ToString();
            pasarRegistro = dataGridView_Teclados.Rows[e.RowIndex].Cells[1].Value.ToString();
            pasarNombre = dataGridView_Teclados.Rows[e.RowIndex].Cells[0].Value.ToString();
            etiquetaTecla.Text = String.Empty;
            boton_OK.Enabled = true;
        }

        private void TeclaPresionada(object sender, Eventos_Teclado.ControlEventosTeclas e)
        {
            etiquetaDescripcion.Text = e.Teclado.descripcionDispositivo.Substring(e.Teclado.descripcionDispositivo.IndexOf(';') + 1);
            nombre = e.Teclado.descripcionDispositivo.Substring(e.Teclado.descripcionDispositivo.IndexOf(';') + 1);
            etiquetaRegistro.Text = e.Teclado.registroDispositivo;
            registro = e.Teclado.registroDispositivo;
            etiquetaTecla.Text = e.Teclado.numero;
        }

        private void Boton_Cancelar_Click(object sender, EventArgs e)
        {
            pasarRegistro = String.Empty;
            pasarNombre = String.Empty;
            Close();
        }

        private void Boton_Agregar_Click(object sender, EventArgs e)
        {
            if (etiquetaDescripcion.Text == String.Empty || etiquetaRegistro.Text == String.Empty)
            {
                MessageBox.Show("Para agregar un teclado presione cualquier número del teclado y luego presione el boton AGREGAR. Se le recuerda no conectar un teclado durante este proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (listaTeclados.Contains(etiquetaDescripcion.Text + "@" + etiquetaRegistro.Text))
                {
                    MessageBox.Show("El Teclado ya ha sido agregado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    listaTeclados.Add(nombre + "@" + registro);
                    dataGridView_Teclados.Rows.Add(etiquetaDescripcion.Text, etiquetaRegistro.Text);
                    dataGridView_Teclados.Rows[0].Selected = true;
                }
            }
        }

        private void Boton_Buscar_Click(object sender, EventArgs e)
        {
            DialogResult busqueda = MessageBox.Show("Antes de buscar un teclado debe agregarlo. Caso contrario presione CANCELAR, y conectelo.", "INFORMACIÓN", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (busqueda == DialogResult.OK)
            {
                TecladosGuardados();
                boton_Buscar.Enabled = false;
                boton_Agregar.Enabled = true;
                dispositivo = new Eventos_Teclado(Handle);
                numeroTeclados = dispositivo.NumeroDispositivos();
                dispositivo.TeclaPresionada += new Eventos_Teclado.ControladorEventosTeclado(TeclaPresionada);
            }
            else
            {
                return;
            }
        }

        private void Boton_OK_Click(object sender, EventArgs e)
        {
            if (dataGridView_Teclados.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar un teclado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Close();
            }
        }

        protected override void WndProc(ref Message mensaje)
        {
            if (dispositivo != null)
            {
                dispositivo.ProcesarMensajes(mensaje);
            }
            base.WndProc(ref mensaje);
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

        private void BloquearElementos()
        {
            boton_Agregar.Enabled = false;
            boton_OK.Enabled = false;
        }

        private void TecladosGuardados()
        {
            if (listaTeclados.Count == 0)
            {
                return;
            }
            else
            {
                foreach (var teclado in listaTeclados)
                {
                    string[] dato = teclado.Split('@');
                    dataGridView_Teclados.Rows.Add(dato[0], dato[1]);
                    dataGridView_Teclados.Rows[0].Selected = true;
                }
            }
        }

        public Agregar_Teclados()
        {
            InitializeComponent();
            BloquearElementos();
        }
    }
}