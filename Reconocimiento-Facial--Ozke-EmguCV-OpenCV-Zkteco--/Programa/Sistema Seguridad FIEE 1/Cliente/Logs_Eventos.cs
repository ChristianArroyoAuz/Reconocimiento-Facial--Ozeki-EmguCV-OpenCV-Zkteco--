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
using iTextSharp.text.pdf;
using System.ServiceModel;
using System.Collections;
using System.Reflection;
using System.Threading;
using iTextSharp.text;
using System.Drawing;
using ObjetoRemoto;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace Cliente
{
    public partial class Logs_Eventos : Form
    {
        private ChannelFactory<IObjetoRemoto> canal = new ChannelFactory<IObjetoRemoto>(new NetTcpBinding(), "net.tcp://localhost:8080");
        private ObjetoRemoto.ObjetoRemoto objetoremotoUsuario = new ObjetoRemoto.ObjetoRemoto();
        private List<Logs> recibirDatosEventos = new List<Logs>();
        private List<Logs> buscarDatosEventos = new List<Logs>();
        private Thread servidor = new Thread(Servidor.Main);
        private const int noBotonCerrar = 0x200;
        private IObjetoRemoto interfaz;

        private void Boton_Imprimir1_Click(object sender, EventArgs e)
        {
            if (txt_Guardar1.Text != String.Empty)
            {
                if (txt_Nombre1.Text != String.Empty)
                {
                    if (radioButton_XLSX1.Checked == true)
                    {
                        ExportadorXLS(dataGridView_Logs, @txt_Guardar1.Text + @"\" + txt_Nombre1.Text + ".xls");
                        MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Guardar1.Text = String.Empty;
                        txt_Nombre1.Text = string.Empty;
                    }
                    if (radioButton_PDF1.Checked == true)
                    {
                        try
                        {
                            ExportadorPDF1();
                            MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_Guardar1.Text = String.Empty;
                            txt_Nombre1.Text = string.Empty;
                        }
                        catch
                        {
                            MessageBox.Show("No hay nada para imprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_Guardar1.Text = String.Empty;
                            txt_Nombre1.Text = string.Empty;
                        }

                    }
                    if (radioButton_DOC1.Checked == true)
                    {
                        ExportadorDOC(dataGridView_Logs, @txt_Guardar1.Text + @"\" + txt_Nombre1.Text + ".doc");
                        MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Guardar1.Text = String.Empty;
                        txt_Nombre1.Text = string.Empty;
                    }
                    if (radioButton_TXT1.Checked == true)
                    {
                        ExportadorTXT(dataGridView_Logs, @txt_Guardar1.Text + @"\" + txt_Nombre1.Text + ".txt");
                        MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Guardar1.Text = String.Empty;
                        txt_Nombre1.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Debe poner un nombre antes de guardar el documento.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar el documento.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_Imprimir2_Click(object sender, EventArgs e)
        {
            if (txt_Guardar2.Text != String.Empty)
            {
                if (txt_Nombre2.Text != String.Empty)
                {
                    if (radioButton_XLSX2.Checked == true)
                    {
                        ExportadorXLS(dataGridView_LogsBusqueda, @txt_Guardar2.Text + @"\" + txt_Nombre2.Text + ".xls");
                        MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Guardar2.Text = String.Empty;
                        txt_Nombre2.Text = string.Empty;
                    }
                    if (radioButton_PDF2.Checked == true)
                    {
                        try
                        {
                            ExportadorPDF2();
                            MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_Guardar2.Text = String.Empty;
                            txt_Nombre2.Text = string.Empty;
                        }
                        catch
                        {
                            MessageBox.Show("No hay nada para imprimir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_Guardar2.Text = String.Empty;
                            txt_Nombre2.Text = string.Empty;
                        }
                    }
                    if (radioButton_DOC2.Checked == true)
                    {
                        ExportadorDOC(dataGridView_LogsBusqueda, @txt_Guardar2.Text + @"\" + txt_Nombre2.Text + ".doc");
                        MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Guardar2.Text = String.Empty;
                        txt_Nombre2.Text = string.Empty;
                    }
                    if (radioButton_TXT2.Checked == true)
                    {
                        ExportadorTXT(dataGridView_LogsBusqueda, @txt_Guardar2.Text + @"\" + txt_Nombre2.Text + ".txt");
                        MessageBox.Show("Documento creado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Guardar2.Text = String.Empty;
                        txt_Nombre2.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Debe poner un nombre antes de guardar el documento.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe escoger una ruta antes de guardar el documento.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Boton_Regresar_Click(object sender, EventArgs e)
        {
            FinalizarServidor();
            Close();
        }

        private void Boton_Guardar1_Click(object sender, EventArgs e)
        {
            var busquedaRuta1 = buscadorArchivos.ShowDialog();
            if (busquedaRuta1 == DialogResult.OK)
            {
                txt_Guardar1.Text = buscadorArchivos.SelectedPath;
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
            }
            else
            {
                MessageBox.Show("No se escogio una ruta.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportadorXLS(DataGridView eventos, string ruta)
        {
            string columnas = "";
            string filas = "";
            for (int j = 0; j < eventos.Columns.Count; j++)
            {
                if (j == 0)
                {
                    columnas = "\t\t\t\t Escuela Politécnica Nacional" + "\n" + "\t\t\t Documento creado con Fecha: " + DateTime.Now.ToString() + "\n\n";
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText) + "\t\t";
                }
                if (j == 1)
                {
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText) + "\t\t ";
                }
                if (j > 1)
                {
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText);
                }
            }
            filas += columnas + "\n\n";
            for (int i = 0; i < eventos.RowCount; i++)
            {
                string celdas = "";
                for (int j = 0; j < eventos.Rows[i].Cells.Count; j++)
                {
                    if (j == 0)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value) + "\t\t";
                    }
                    if (j == 1)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value) + "\t\t";
                    }
                    if (j > 1)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value);
                    }
                }
                filas += celdas + "\n\n";
            }
            Encoding codificacion = Encoding.GetEncoding(1254);
            byte[] salida = codificacion.GetBytes(filas);
            FileStream datos = new FileStream(ruta, FileMode.Create);
            BinaryWriter datosBinarios = new BinaryWriter(datos);
            datosBinarios.Write(salida, 0, salida.Length);
            datosBinarios.Flush();
            datosBinarios.Close();
            datos.Close();
        }

        private void ExportadorDOC(DataGridView eventos, string ruta)
        {
            string columnas = "";
            string filas = "";
            for (int j = 0; j < eventos.Columns.Count; j++)
            {
                if (j == 0)
                {
                    columnas = "\t\t\t\t Escuela Politécnica Nacional" + "\n" + "\t\t Documento creado con Fecha: " + DateTime.Now.ToString() + "\n\n";
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText) + "\t";
                }
                if (j == 1)
                {
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText) + "\t\t\t ";
                }
                if (j > 1)
                {
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText);
                }
            }
            filas += columnas + "\n\n";
            for (int i = 0; i < eventos.RowCount; i++)
            {
                string celdas = "";
                for (int j = 0; j < eventos.Rows[i].Cells.Count; j++)
                {
                    if (j == 0)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value) + "\t\t";
                    }
                    if (j == 1)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value);
                    }
                    if (j > 1)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value);
                    }
                }
                filas += celdas + "\n\n";
            }
            Encoding codificacion = Encoding.GetEncoding(1254);
            byte[] salida = codificacion.GetBytes(filas);
            FileStream datos = new FileStream(ruta, FileMode.Create);
            BinaryWriter datosBinarios = new BinaryWriter(datos);
            datosBinarios.Write(salida, 0, salida.Length);
            datosBinarios.Flush();
            datosBinarios.Close();
            datos.Close();
        }

        private void ExportadorTXT(DataGridView eventos, string ruta)
        {
            string columnas = "";
            string filas = "";
            for (int j = 0; j < eventos.Columns.Count; j++)
            {
                if (j == 0)
                {
                    columnas = "\t\t\t\t Escuela Politécnica Nacional" + "\r\n" + "\t\t\t Documento creado con Fecha: " + DateTime.Now.ToString() + "\r\n\r\n";
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText) + "\t\t";
                }
                if (j == 1)
                {
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText) + "\t\t\t ";
                }
                if (j > 1)
                {
                    columnas = columnas.ToString() + Convert.ToString(eventos.Columns[j].HeaderText);
                }
            }
            filas += columnas + "\r\n";
            for (int i = 0; i < eventos.RowCount; i++)
            {
                string celdas = "";
                for (int j = 0; j < eventos.Rows[i].Cells.Count; j++)
                {
                    if (j == 0)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value) + "\t\t";
                    }
                    if (j == 1)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value) + "\t";
                    }
                    if (j > 1)
                    {
                        celdas = celdas.ToString() + Convert.ToString(eventos.Rows[i].Cells[j].Value);
                    }
                }
                filas += celdas + "\r\n";
            }
            Encoding codificacion = Encoding.GetEncoding(1254);
            byte[] salida = codificacion.GetBytes(filas);
            FileStream datos = new FileStream(ruta, FileMode.Create);
            BinaryWriter datosBinarios = new BinaryWriter(datos);
            datosBinarios.Write(salida, 0, salida.Length);
            datosBinarios.Flush();
            datosBinarios.Close();
            datos.Close();
        }

        private void Boton_Buscar_Click(object sender, EventArgs e)
        {
            (objetoremotoUsuario as IObjetoRemoto).MostrarEventos(recibirDatosEventos);
            buscarDatosEventos.Clear();
            foreach (Logs item in recibirDatosEventos)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(item.ToString(), txt_Buscar.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    buscarDatosEventos.Add(item);
                }  
            }
            if (buscarDatosEventos.Count == 0)
            {
                MessageBox.Show("No se encontaron resultados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView_LogsBusqueda.DataSource = buscarDatosEventos.Select(x => x).Select(y => new
                {
                    ID_LOGS = y.Id_Log,
                    FECHA = y.Fecha,
                    EVENTO = y.Evento
                }).ToList();
                recibirDatosEventos.Clear();
            }
            else
            {
                foreach (Logs item in buscarDatosEventos)
                {
                    dataGridView_LogsBusqueda.DataSource = buscarDatosEventos.Select(x => x).Select(y => new
                    {
                        ID_LOGS = y.Id_Log,
                        FECHA = y.Fecha,
                        EVENTO = y.Evento
                    }).ToList();
                }
                dataGridView_LogsBusqueda.Columns[0].Width = 100;
                dataGridView_LogsBusqueda.Columns[1].Width = 140;
                dataGridView_LogsBusqueda.Rows[0].Selected = false;
                recibirDatosEventos.Clear();
            }
        }

        private void Logs_Eventos_Load(object sender, EventArgs e)
        {
            CargarEventos();
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

        private void ExportadorPDF1()
        {
            PdfPTable pdfTabla = new PdfPTable(dataGridView_Logs.ColumnCount);
            foreach (DataGridViewColumn columna in dataGridView_Logs.Columns)
            {
                PdfPCell celdas = new PdfPCell(new Phrase(columna.HeaderText));
                pdfTabla.AddCell(celdas);
            }
            foreach (DataGridViewRow filas in dataGridView_Logs.Rows)
            {
                foreach (DataGridViewCell cell in filas.Cells)
                {
                    pdfTabla.AddCell(cell.Value.ToString());
                }
            }
            string ruta = @txt_Guardar1.Text + @"\";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            using (FileStream datos = new FileStream(ruta + txt_Nombre1.Text + ".pdf", FileMode.Create))
            {
                Document documento = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(documento, datos);
                documento.Open();
                documento.Add(new Paragraph("Escuela Politécnica Nacional" + "\n" + "Documento creado con Fecha: " + DateTime.Now.ToString() + "\n\n"));
                documento.Add(pdfTabla);
                documento.Close();
                datos.Close();
            }
        }

        private void ExportadorPDF2()
        {
            PdfPTable pdfTabla = new PdfPTable(dataGridView_LogsBusqueda.ColumnCount);
            foreach (DataGridViewColumn columna in dataGridView_LogsBusqueda.Columns)
            {
                PdfPCell celdas = new PdfPCell(new Phrase(columna.HeaderText));
                pdfTabla.AddCell(celdas);
            }
            foreach (DataGridViewRow filas in dataGridView_LogsBusqueda.Rows)
            {
                foreach (DataGridViewCell cell in filas.Cells)
                {
                    pdfTabla.AddCell(cell.Value.ToString());
                }
            }
            string ruta = @txt_Guardar2.Text + @"\";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            using (FileStream datos = new FileStream(ruta + txt_Nombre2.Text + ".pdf", FileMode.Create))
            {
                Document documento = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(documento, datos);
                documento.Open();
                documento.Add(new Paragraph("Escuela Politécnica Nacional" + "\n" + "Documento creado con Fecha: " + DateTime.Now.ToString() + "\n\n"));
                documento.Add(pdfTabla);
                documento.Close();
                datos.Close();
            }
        }

        private void LimpiarCampos()
        {
        }

        private void CargarEventos()
        {
            try
            {
                (objetoremotoUsuario as IObjetoRemoto).MostrarEventos(recibirDatosEventos);
                foreach (Logs item in recibirDatosEventos)
                {
                    dataGridView_Logs.DataSource = objetoremotoUsuario.eventosRegistrados.Select(x => x).Select(y => new
                    {
                        ID_LOGS = y.Id_Log,
                        FECHA = y.Fecha,
                        EVENTO = y.Evento
                    }).ToList();
                }
                dataGridView_Logs.Columns[0].Width = 100;
                dataGridView_Logs.Columns[1].Width = 140;
                dataGridView_Logs.Rows[0].Selected = false;
                recibirDatosEventos.Clear();
            }
            catch
            {
                MessageBox.Show("No existen datos en la base de datos.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Logs_Eventos()
        {
            InitializeComponent();
            IniciarServidor();
        }
    }
}