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

namespace Cliente
{
    partial class Logs_Eventos
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logs_Eventos));
            this.pictureBox_Imagen = new System.Windows.Forms.PictureBox();
            this.etiquetaTitulo = new System.Windows.Forms.Label();
            this.dataGridView_Logs = new System.Windows.Forms.DataGridView();
            this.etiquetaBuscar = new System.Windows.Forms.Label();
            this.dataGridView_LogsBusqueda = new System.Windows.Forms.DataGridView();
            this.boton_Regresar = new System.Windows.Forms.Button();
            this.boton_Imprimir1 = new System.Windows.Forms.Button();
            this.groupBox_Imprimir1 = new System.Windows.Forms.GroupBox();
            this.txt_Nombre1 = new System.Windows.Forms.TextBox();
            this.etiquetaNombre1 = new System.Windows.Forms.Label();
            this.groupBox_Formato1 = new System.Windows.Forms.GroupBox();
            this.radioButton_XLSX1 = new System.Windows.Forms.RadioButton();
            this.radioButton_TXT1 = new System.Windows.Forms.RadioButton();
            this.radioButton_DOC1 = new System.Windows.Forms.RadioButton();
            this.radioButton_PDF1 = new System.Windows.Forms.RadioButton();
            this.boton_Guardar1 = new System.Windows.Forms.Button();
            this.txt_Guardar1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Nombre2 = new System.Windows.Forms.TextBox();
            this.etiquetaNombre2 = new System.Windows.Forms.Label();
            this.boton_Buscar = new System.Windows.Forms.Button();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.groupBox_Formato2 = new System.Windows.Forms.GroupBox();
            this.radioButton_XLSX2 = new System.Windows.Forms.RadioButton();
            this.radioButton_TXT2 = new System.Windows.Forms.RadioButton();
            this.radioButton_DOC2 = new System.Windows.Forms.RadioButton();
            this.radioButton_PDF2 = new System.Windows.Forms.RadioButton();
            this.boton_Guardar2 = new System.Windows.Forms.Button();
            this.txt_Guardar2 = new System.Windows.Forms.TextBox();
            this.boton_Imprimir2 = new System.Windows.Forms.Button();
            this.buscadorArchivos = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Imagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LogsBusqueda)).BeginInit();
            this.groupBox_Imprimir1.SuspendLayout();
            this.groupBox_Formato1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_Formato2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_Imagen
            // 
            this.pictureBox_Imagen.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Imagen.BackgroundImage = global::Cliente.Properties.Resources.Logs;
            this.pictureBox_Imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Imagen.Location = new System.Drawing.Point(1225, 13);
            this.pictureBox_Imagen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox_Imagen.Name = "pictureBox_Imagen";
            this.pictureBox_Imagen.Size = new System.Drawing.Size(290, 614);
            this.pictureBox_Imagen.TabIndex = 1;
            this.pictureBox_Imagen.TabStop = false;
            // 
            // etiquetaTitulo
            // 
            this.etiquetaTitulo.AutoSize = true;
            this.etiquetaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaTitulo.Font = new System.Drawing.Font("Arial", 30F);
            this.etiquetaTitulo.Location = new System.Drawing.Point(15, 9);
            this.etiquetaTitulo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaTitulo.Name = "etiquetaTitulo";
            this.etiquetaTitulo.Size = new System.Drawing.Size(628, 57);
            this.etiquetaTitulo.TabIndex = 2;
            this.etiquetaTitulo.Text = "VER LOGS DE EVENTOS.";
            // 
            // dataGridView_Logs
            // 
            this.dataGridView_Logs.AllowUserToAddRows = false;
            this.dataGridView_Logs.AllowUserToDeleteRows = false;
            this.dataGridView_Logs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Logs.Location = new System.Drawing.Point(14, 70);
            this.dataGridView_Logs.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView_Logs.MultiSelect = false;
            this.dataGridView_Logs.Name = "dataGridView_Logs";
            this.dataGridView_Logs.ReadOnly = true;
            this.dataGridView_Logs.RowHeadersWidth = 30;
            this.dataGridView_Logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Logs.Size = new System.Drawing.Size(811, 258);
            this.dataGridView_Logs.TabIndex = 35;
            // 
            // etiquetaBuscar
            // 
            this.etiquetaBuscar.AutoSize = true;
            this.etiquetaBuscar.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaBuscar.Font = new System.Drawing.Font("Arial", 30F);
            this.etiquetaBuscar.Location = new System.Drawing.Point(15, 332);
            this.etiquetaBuscar.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaBuscar.Name = "etiquetaBuscar";
            this.etiquetaBuscar.Size = new System.Drawing.Size(733, 57);
            this.etiquetaBuscar.TabIndex = 36;
            this.etiquetaBuscar.Text = "BUSCAR LOGS DE EVENTOS.";
            // 
            // dataGridView_LogsBusqueda
            // 
            this.dataGridView_LogsBusqueda.AllowUserToAddRows = false;
            this.dataGridView_LogsBusqueda.AllowUserToDeleteRows = false;
            this.dataGridView_LogsBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_LogsBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LogsBusqueda.Location = new System.Drawing.Point(14, 393);
            this.dataGridView_LogsBusqueda.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView_LogsBusqueda.MultiSelect = false;
            this.dataGridView_LogsBusqueda.Name = "dataGridView_LogsBusqueda";
            this.dataGridView_LogsBusqueda.ReadOnly = true;
            this.dataGridView_LogsBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_LogsBusqueda.Size = new System.Drawing.Size(811, 296);
            this.dataGridView_LogsBusqueda.TabIndex = 37;
            // 
            // boton_Regresar
            // 
            this.boton_Regresar.Location = new System.Drawing.Point(1225, 635);
            this.boton_Regresar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boton_Regresar.Name = "boton_Regresar";
            this.boton_Regresar.Size = new System.Drawing.Size(290, 43);
            this.boton_Regresar.TabIndex = 39;
            this.boton_Regresar.Text = "REGRESAR.";
            this.boton_Regresar.UseVisualStyleBackColor = true;
            this.boton_Regresar.Click += new System.EventHandler(this.Boton_Regresar_Click);
            // 
            // boton_Imprimir1
            // 
            this.boton_Imprimir1.Location = new System.Drawing.Point(8, 207);
            this.boton_Imprimir1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boton_Imprimir1.Name = "boton_Imprimir1";
            this.boton_Imprimir1.Size = new System.Drawing.Size(369, 42);
            this.boton_Imprimir1.TabIndex = 38;
            this.boton_Imprimir1.Text = "IMPRIMIR.";
            this.boton_Imprimir1.UseVisualStyleBackColor = true;
            this.boton_Imprimir1.Click += new System.EventHandler(this.Boton_Imprimir1_Click);
            // 
            // groupBox_Imprimir1
            // 
            this.groupBox_Imprimir1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Imprimir1.Controls.Add(this.txt_Nombre1);
            this.groupBox_Imprimir1.Controls.Add(this.etiquetaNombre1);
            this.groupBox_Imprimir1.Controls.Add(this.groupBox_Formato1);
            this.groupBox_Imprimir1.Controls.Add(this.boton_Guardar1);
            this.groupBox_Imprimir1.Controls.Add(this.txt_Guardar1);
            this.groupBox_Imprimir1.Controls.Add(this.boton_Imprimir1);
            this.groupBox_Imprimir1.Location = new System.Drawing.Point(833, 69);
            this.groupBox_Imprimir1.Name = "groupBox_Imprimir1";
            this.groupBox_Imprimir1.Size = new System.Drawing.Size(384, 259);
            this.groupBox_Imprimir1.TabIndex = 40;
            this.groupBox_Imprimir1.TabStop = false;
            this.groupBox_Imprimir1.Text = "Imprimir";
            // 
            // txt_Nombre1
            // 
            this.txt_Nombre1.Location = new System.Drawing.Point(202, 170);
            this.txt_Nombre1.Name = "txt_Nombre1";
            this.txt_Nombre1.Size = new System.Drawing.Size(174, 30);
            this.txt_Nombre1.TabIndex = 41;
            // 
            // etiquetaNombre1
            // 
            this.etiquetaNombre1.AutoSize = true;
            this.etiquetaNombre1.Location = new System.Drawing.Point(6, 177);
            this.etiquetaNombre1.Name = "etiquetaNombre1";
            this.etiquetaNombre1.Size = new System.Drawing.Size(190, 23);
            this.etiquetaNombre1.TabIndex = 40;
            this.etiquetaNombre1.Text = "Nombre Documento:";
            // 
            // groupBox_Formato1
            // 
            this.groupBox_Formato1.Controls.Add(this.radioButton_XLSX1);
            this.groupBox_Formato1.Controls.Add(this.radioButton_TXT1);
            this.groupBox_Formato1.Controls.Add(this.radioButton_DOC1);
            this.groupBox_Formato1.Controls.Add(this.radioButton_PDF1);
            this.groupBox_Formato1.Location = new System.Drawing.Point(7, 67);
            this.groupBox_Formato1.Name = "groupBox_Formato1";
            this.groupBox_Formato1.Size = new System.Drawing.Size(369, 100);
            this.groupBox_Formato1.TabIndex = 39;
            this.groupBox_Formato1.TabStop = false;
            this.groupBox_Formato1.Text = "Formato";
            // 
            // radioButton_XLSX1
            // 
            this.radioButton_XLSX1.AutoSize = true;
            this.radioButton_XLSX1.Location = new System.Drawing.Point(282, 62);
            this.radioButton_XLSX1.Name = "radioButton_XLSX1";
            this.radioButton_XLSX1.Size = new System.Drawing.Size(81, 27);
            this.radioButton_XLSX1.TabIndex = 3;
            this.radioButton_XLSX1.Text = "XLSX";
            this.radioButton_XLSX1.UseVisualStyleBackColor = true;
            // 
            // radioButton_TXT1
            // 
            this.radioButton_TXT1.AutoSize = true;
            this.radioButton_TXT1.Location = new System.Drawing.Point(282, 29);
            this.radioButton_TXT1.Name = "radioButton_TXT1";
            this.radioButton_TXT1.Size = new System.Drawing.Size(68, 27);
            this.radioButton_TXT1.TabIndex = 2;
            this.radioButton_TXT1.Text = "TXT";
            this.radioButton_TXT1.UseVisualStyleBackColor = true;
            // 
            // radioButton_DOC1
            // 
            this.radioButton_DOC1.AutoSize = true;
            this.radioButton_DOC1.Location = new System.Drawing.Point(6, 62);
            this.radioButton_DOC1.Name = "radioButton_DOC1";
            this.radioButton_DOC1.Size = new System.Drawing.Size(75, 27);
            this.radioButton_DOC1.TabIndex = 1;
            this.radioButton_DOC1.Text = "DOC";
            this.radioButton_DOC1.UseVisualStyleBackColor = true;
            // 
            // radioButton_PDF1
            // 
            this.radioButton_PDF1.AutoSize = true;
            this.radioButton_PDF1.Checked = true;
            this.radioButton_PDF1.Location = new System.Drawing.Point(6, 29);
            this.radioButton_PDF1.Name = "radioButton_PDF1";
            this.radioButton_PDF1.Size = new System.Drawing.Size(70, 27);
            this.radioButton_PDF1.TabIndex = 0;
            this.radioButton_PDF1.TabStop = true;
            this.radioButton_PDF1.Text = "PDF";
            this.radioButton_PDF1.UseVisualStyleBackColor = true;
            // 
            // boton_Guardar1
            // 
            this.boton_Guardar1.Location = new System.Drawing.Point(7, 30);
            this.boton_Guardar1.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Guardar1.Name = "boton_Guardar1";
            this.boton_Guardar1.Size = new System.Drawing.Size(125, 30);
            this.boton_Guardar1.TabIndex = 6;
            this.boton_Guardar1.Text = "Guardar en:";
            this.boton_Guardar1.UseVisualStyleBackColor = true;
            this.boton_Guardar1.Click += new System.EventHandler(this.Boton_Guardar1_Click);
            // 
            // txt_Guardar1
            // 
            this.txt_Guardar1.Location = new System.Drawing.Point(134, 30);
            this.txt_Guardar1.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Guardar1.Name = "txt_Guardar1";
            this.txt_Guardar1.ReadOnly = true;
            this.txt_Guardar1.Size = new System.Drawing.Size(243, 30);
            this.txt_Guardar1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txt_Nombre2);
            this.groupBox1.Controls.Add(this.etiquetaNombre2);
            this.groupBox1.Controls.Add(this.boton_Buscar);
            this.groupBox1.Controls.Add(this.txt_Buscar);
            this.groupBox1.Controls.Add(this.groupBox_Formato2);
            this.groupBox1.Controls.Add(this.boton_Guardar2);
            this.groupBox1.Controls.Add(this.txt_Guardar2);
            this.groupBox1.Controls.Add(this.boton_Imprimir2);
            this.groupBox1.Location = new System.Drawing.Point(833, 393);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 296);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imprimir";
            // 
            // txt_Nombre2
            // 
            this.txt_Nombre2.Location = new System.Drawing.Point(200, 209);
            this.txt_Nombre2.Name = "txt_Nombre2";
            this.txt_Nombre2.Size = new System.Drawing.Size(174, 30);
            this.txt_Nombre2.TabIndex = 43;
            // 
            // etiquetaNombre2
            // 
            this.etiquetaNombre2.AutoSize = true;
            this.etiquetaNombre2.Location = new System.Drawing.Point(4, 216);
            this.etiquetaNombre2.Name = "etiquetaNombre2";
            this.etiquetaNombre2.Size = new System.Drawing.Size(190, 23);
            this.etiquetaNombre2.TabIndex = 42;
            this.etiquetaNombre2.Text = "Nombre Documento:";
            // 
            // boton_Buscar
            // 
            this.boton_Buscar.Location = new System.Drawing.Point(7, 30);
            this.boton_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Buscar.Name = "boton_Buscar";
            this.boton_Buscar.Size = new System.Drawing.Size(125, 30);
            this.boton_Buscar.TabIndex = 40;
            this.boton_Buscar.Text = "Buscar por:";
            this.boton_Buscar.UseVisualStyleBackColor = true;
            this.boton_Buscar.Click += new System.EventHandler(this.Boton_Buscar_Click);
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Location = new System.Drawing.Point(134, 30);
            this.txt_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(243, 30);
            this.txt_Buscar.TabIndex = 41;
            // 
            // groupBox_Formato2
            // 
            this.groupBox_Formato2.Controls.Add(this.radioButton_XLSX2);
            this.groupBox_Formato2.Controls.Add(this.radioButton_TXT2);
            this.groupBox_Formato2.Controls.Add(this.radioButton_DOC2);
            this.groupBox_Formato2.Controls.Add(this.radioButton_PDF2);
            this.groupBox_Formato2.Location = new System.Drawing.Point(7, 105);
            this.groupBox_Formato2.Name = "groupBox_Formato2";
            this.groupBox_Formato2.Size = new System.Drawing.Size(369, 100);
            this.groupBox_Formato2.TabIndex = 39;
            this.groupBox_Formato2.TabStop = false;
            this.groupBox_Formato2.Text = "Formato";
            // 
            // radioButton_XLSX2
            // 
            this.radioButton_XLSX2.AutoSize = true;
            this.radioButton_XLSX2.Location = new System.Drawing.Point(282, 62);
            this.radioButton_XLSX2.Name = "radioButton_XLSX2";
            this.radioButton_XLSX2.Size = new System.Drawing.Size(81, 27);
            this.radioButton_XLSX2.TabIndex = 3;
            this.radioButton_XLSX2.Text = "XLSX";
            this.radioButton_XLSX2.UseVisualStyleBackColor = true;
            // 
            // radioButton_TXT2
            // 
            this.radioButton_TXT2.AutoSize = true;
            this.radioButton_TXT2.Location = new System.Drawing.Point(282, 29);
            this.radioButton_TXT2.Name = "radioButton_TXT2";
            this.radioButton_TXT2.Size = new System.Drawing.Size(68, 27);
            this.radioButton_TXT2.TabIndex = 2;
            this.radioButton_TXT2.Text = "TXT";
            this.radioButton_TXT2.UseVisualStyleBackColor = true;
            // 
            // radioButton_DOC2
            // 
            this.radioButton_DOC2.AutoSize = true;
            this.radioButton_DOC2.Location = new System.Drawing.Point(6, 62);
            this.radioButton_DOC2.Name = "radioButton_DOC2";
            this.radioButton_DOC2.Size = new System.Drawing.Size(75, 27);
            this.radioButton_DOC2.TabIndex = 1;
            this.radioButton_DOC2.Text = "DOC";
            this.radioButton_DOC2.UseVisualStyleBackColor = true;
            // 
            // radioButton_PDF2
            // 
            this.radioButton_PDF2.AutoSize = true;
            this.radioButton_PDF2.Checked = true;
            this.radioButton_PDF2.Location = new System.Drawing.Point(6, 29);
            this.radioButton_PDF2.Name = "radioButton_PDF2";
            this.radioButton_PDF2.Size = new System.Drawing.Size(70, 27);
            this.radioButton_PDF2.TabIndex = 0;
            this.radioButton_PDF2.TabStop = true;
            this.radioButton_PDF2.Text = "PDF";
            this.radioButton_PDF2.UseVisualStyleBackColor = true;
            // 
            // boton_Guardar2
            // 
            this.boton_Guardar2.Location = new System.Drawing.Point(7, 68);
            this.boton_Guardar2.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Guardar2.Name = "boton_Guardar2";
            this.boton_Guardar2.Size = new System.Drawing.Size(125, 30);
            this.boton_Guardar2.TabIndex = 6;
            this.boton_Guardar2.Text = "Guardar en:";
            this.boton_Guardar2.UseVisualStyleBackColor = true;
            this.boton_Guardar2.Click += new System.EventHandler(this.Boton_Guardar2_Click);
            // 
            // txt_Guardar2
            // 
            this.txt_Guardar2.Location = new System.Drawing.Point(134, 68);
            this.txt_Guardar2.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Guardar2.Name = "txt_Guardar2";
            this.txt_Guardar2.ReadOnly = true;
            this.txt_Guardar2.Size = new System.Drawing.Size(243, 30);
            this.txt_Guardar2.TabIndex = 7;
            // 
            // boton_Imprimir2
            // 
            this.boton_Imprimir2.Location = new System.Drawing.Point(7, 243);
            this.boton_Imprimir2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boton_Imprimir2.Name = "boton_Imprimir2";
            this.boton_Imprimir2.Size = new System.Drawing.Size(369, 42);
            this.boton_Imprimir2.TabIndex = 38;
            this.boton_Imprimir2.Text = "IMPRIMIR.";
            this.boton_Imprimir2.UseVisualStyleBackColor = true;
            this.boton_Imprimir2.Click += new System.EventHandler(this.Boton_Imprimir2_Click);
            // 
            // Logs_Eventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Cliente.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1525, 702);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Imprimir1);
            this.Controls.Add(this.boton_Regresar);
            this.Controls.Add(this.dataGridView_LogsBusqueda);
            this.Controls.Add(this.etiquetaBuscar);
            this.Controls.Add(this.dataGridView_Logs);
            this.Controls.Add(this.etiquetaTitulo);
            this.Controls.Add(this.pictureBox_Imagen);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Logs_Eventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs Eventos";
            this.Load += new System.EventHandler(this.Logs_Eventos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LogsBusqueda)).EndInit();
            this.groupBox_Imprimir1.ResumeLayout(false);
            this.groupBox_Imprimir1.PerformLayout();
            this.groupBox_Formato1.ResumeLayout(false);
            this.groupBox_Formato1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_Formato2.ResumeLayout(false);
            this.groupBox_Formato2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Imagen;
        private System.Windows.Forms.Label etiquetaTitulo;
        private System.Windows.Forms.DataGridView dataGridView_Logs;
        private System.Windows.Forms.Label etiquetaBuscar;
        private System.Windows.Forms.DataGridView dataGridView_LogsBusqueda;
        private System.Windows.Forms.Button boton_Regresar;
        private System.Windows.Forms.Button boton_Imprimir1;
        private System.Windows.Forms.GroupBox groupBox_Imprimir1;
        private System.Windows.Forms.Button boton_Guardar1;
        private System.Windows.Forms.TextBox txt_Guardar1;
        private System.Windows.Forms.GroupBox groupBox_Formato1;
        private System.Windows.Forms.RadioButton radioButton_TXT1;
        private System.Windows.Forms.RadioButton radioButton_DOC1;
        private System.Windows.Forms.RadioButton radioButton_PDF1;
        private System.Windows.Forms.RadioButton radioButton_XLSX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button boton_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.GroupBox groupBox_Formato2;
        private System.Windows.Forms.RadioButton radioButton_XLSX2;
        private System.Windows.Forms.RadioButton radioButton_TXT2;
        private System.Windows.Forms.RadioButton radioButton_DOC2;
        private System.Windows.Forms.RadioButton radioButton_PDF2;
        private System.Windows.Forms.Button boton_Guardar2;
        private System.Windows.Forms.TextBox txt_Guardar2;
        private System.Windows.Forms.Button boton_Imprimir2;
        private System.Windows.Forms.FolderBrowserDialog buscadorArchivos;
        private System.Windows.Forms.TextBox txt_Nombre1;
        private System.Windows.Forms.Label etiquetaNombre1;
        private System.Windows.Forms.TextBox txt_Nombre2;
        private System.Windows.Forms.Label etiquetaNombre2;
    }
}