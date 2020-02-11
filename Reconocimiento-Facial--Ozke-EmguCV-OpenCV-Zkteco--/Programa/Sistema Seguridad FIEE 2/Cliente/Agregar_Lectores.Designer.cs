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
    partial class Agregar_Lectores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agregar_Lectores));
            this.groupBox_AgregarLectores = new System.Windows.Forms.GroupBox();
            this.txt_Informacion = new System.Windows.Forms.Label();
            this.txt_Huella = new System.Windows.Forms.TextBox();
            this.pictureBox_Huella = new System.Windows.Forms.PictureBox();
            this.boton_Cancelar = new System.Windows.Forms.Button();
            this.dataGridView_Lectores = new System.Windows.Forms.DataGridView();
            this.datoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etiquetaClaveHuella = new System.Windows.Forms.Label();
            this.etiquetaDescripcionLector = new System.Windows.Forms.Label();
            this.etiquetaRegistroLector = new System.Windows.Forms.Label();
            this.etiquetaDescripcion = new System.Windows.Forms.Label();
            this.etiquetaRegistro = new System.Windows.Forms.Label();
            this.boton_Agregar = new System.Windows.Forms.Button();
            this.boton_OK = new System.Windows.Forms.Button();
            this.boton_Buscar = new System.Windows.Forms.Button();
            this.groupBox_AgregarLectores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Huella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lectores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_AgregarLectores
            // 
            this.groupBox_AgregarLectores.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_AgregarLectores.Controls.Add(this.txt_Informacion);
            this.groupBox_AgregarLectores.Controls.Add(this.txt_Huella);
            this.groupBox_AgregarLectores.Controls.Add(this.pictureBox_Huella);
            this.groupBox_AgregarLectores.Controls.Add(this.boton_Cancelar);
            this.groupBox_AgregarLectores.Controls.Add(this.dataGridView_Lectores);
            this.groupBox_AgregarLectores.Controls.Add(this.etiquetaClaveHuella);
            this.groupBox_AgregarLectores.Controls.Add(this.etiquetaDescripcionLector);
            this.groupBox_AgregarLectores.Controls.Add(this.etiquetaRegistroLector);
            this.groupBox_AgregarLectores.Controls.Add(this.etiquetaDescripcion);
            this.groupBox_AgregarLectores.Controls.Add(this.etiquetaRegistro);
            this.groupBox_AgregarLectores.Controls.Add(this.boton_Agregar);
            this.groupBox_AgregarLectores.Controls.Add(this.boton_OK);
            this.groupBox_AgregarLectores.Controls.Add(this.boton_Buscar);
            this.groupBox_AgregarLectores.Location = new System.Drawing.Point(10, 9);
            this.groupBox_AgregarLectores.Name = "groupBox_AgregarLectores";
            this.groupBox_AgregarLectores.Size = new System.Drawing.Size(942, 420);
            this.groupBox_AgregarLectores.TabIndex = 1;
            this.groupBox_AgregarLectores.TabStop = false;
            this.groupBox_AgregarLectores.Text = "Agregar Lectores";
            // 
            // txt_Informacion
            // 
            this.txt_Informacion.AutoSize = true;
            this.txt_Informacion.Location = new System.Drawing.Point(673, 139);
            this.txt_Informacion.Name = "txt_Informacion";
            this.txt_Informacion.Size = new System.Drawing.Size(112, 23);
            this.txt_Informacion.TabIndex = 13;
            this.txt_Informacion.Text = "Informacion";
            // 
            // txt_Huella
            // 
            this.txt_Huella.Location = new System.Drawing.Point(77, 294);
            this.txt_Huella.Multiline = true;
            this.txt_Huella.Name = "txt_Huella";
            this.txt_Huella.ReadOnly = true;
            this.txt_Huella.Size = new System.Drawing.Size(594, 34);
            this.txt_Huella.TabIndex = 12;
            // 
            // pictureBox_Huella
            // 
            this.pictureBox_Huella.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Huella.Location = new System.Drawing.Point(677, 165);
            this.pictureBox_Huella.Name = "pictureBox_Huella";
            this.pictureBox_Huella.Size = new System.Drawing.Size(253, 196);
            this.pictureBox_Huella.TabIndex = 11;
            this.pictureBox_Huella.TabStop = false;
            // 
            // boton_Cancelar
            // 
            this.boton_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.boton_Cancelar.Location = new System.Drawing.Point(750, 367);
            this.boton_Cancelar.Name = "boton_Cancelar";
            this.boton_Cancelar.Size = new System.Drawing.Size(180, 41);
            this.boton_Cancelar.TabIndex = 10;
            this.boton_Cancelar.Text = "Cancelar";
            this.boton_Cancelar.UseVisualStyleBackColor = true;
            this.boton_Cancelar.Click += new System.EventHandler(this.Boton_Cancelar_Click);
            // 
            // dataGridView_Lectores
            // 
            this.dataGridView_Lectores.AllowUserToAddRows = false;
            this.dataGridView_Lectores.AllowUserToDeleteRows = false;
            this.dataGridView_Lectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Lectores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datoNombre,
            this.datoRegistro});
            this.dataGridView_Lectores.Location = new System.Drawing.Point(6, 29);
            this.dataGridView_Lectores.MultiSelect = false;
            this.dataGridView_Lectores.Name = "dataGridView_Lectores";
            this.dataGridView_Lectores.ReadOnly = true;
            this.dataGridView_Lectores.RowTemplate.Height = 24;
            this.dataGridView_Lectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lectores.Size = new System.Drawing.Size(924, 107);
            this.dataGridView_Lectores.TabIndex = 8;
            this.dataGridView_Lectores.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Lectores_RowEnter);
            // 
            // datoNombre
            // 
            this.datoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datoNombre.HeaderText = "Nombre Del Lector";
            this.datoNombre.Name = "datoNombre";
            this.datoNombre.ReadOnly = true;
            // 
            // datoRegistro
            // 
            this.datoRegistro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datoRegistro.HeaderText = "Registro Del Lector";
            this.datoRegistro.Name = "datoRegistro";
            this.datoRegistro.ReadOnly = true;
            // 
            // etiquetaClaveHuella
            // 
            this.etiquetaClaveHuella.AutoSize = true;
            this.etiquetaClaveHuella.Location = new System.Drawing.Point(2, 305);
            this.etiquetaClaveHuella.Name = "etiquetaClaveHuella";
            this.etiquetaClaveHuella.Size = new System.Drawing.Size(69, 23);
            this.etiquetaClaveHuella.TabIndex = 4;
            this.etiquetaClaveHuella.Text = "Huella:";
            // 
            // etiquetaDescripcionLector
            // 
            this.etiquetaDescripcionLector.AutoSize = true;
            this.etiquetaDescripcionLector.Location = new System.Drawing.Point(2, 187);
            this.etiquetaDescripcionLector.Name = "etiquetaDescripcionLector";
            this.etiquetaDescripcionLector.Size = new System.Drawing.Size(215, 23);
            this.etiquetaDescripcionLector.TabIndex = 0;
            this.etiquetaDescripcionLector.Text = "Descripcion Del Lector:";
            // 
            // etiquetaRegistroLector
            // 
            this.etiquetaRegistroLector.AutoSize = true;
            this.etiquetaRegistroLector.Location = new System.Drawing.Point(2, 246);
            this.etiquetaRegistroLector.Name = "etiquetaRegistroLector";
            this.etiquetaRegistroLector.Size = new System.Drawing.Size(187, 23);
            this.etiquetaRegistroLector.TabIndex = 2;
            this.etiquetaRegistroLector.Text = "Registro Del Lector:";
            // 
            // etiquetaDescripcion
            // 
            this.etiquetaDescripcion.AutoSize = true;
            this.etiquetaDescripcion.Location = new System.Drawing.Point(223, 187);
            this.etiquetaDescripcion.Name = "etiquetaDescripcion";
            this.etiquetaDescripcion.Size = new System.Drawing.Size(0, 23);
            this.etiquetaDescripcion.TabIndex = 1;
            // 
            // etiquetaRegistro
            // 
            this.etiquetaRegistro.AutoSize = true;
            this.etiquetaRegistro.Location = new System.Drawing.Point(195, 246);
            this.etiquetaRegistro.Name = "etiquetaRegistro";
            this.etiquetaRegistro.Size = new System.Drawing.Size(0, 23);
            this.etiquetaRegistro.TabIndex = 3;
            // 
            // boton_Agregar
            // 
            this.boton_Agregar.Location = new System.Drawing.Point(250, 367);
            this.boton_Agregar.Name = "boton_Agregar";
            this.boton_Agregar.Size = new System.Drawing.Size(180, 41);
            this.boton_Agregar.TabIndex = 7;
            this.boton_Agregar.Text = "Agregar";
            this.boton_Agregar.UseVisualStyleBackColor = true;
            this.boton_Agregar.Click += new System.EventHandler(this.Boton_Agregar_Click);
            // 
            // boton_OK
            // 
            this.boton_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.boton_OK.Location = new System.Drawing.Point(500, 367);
            this.boton_OK.Name = "boton_OK";
            this.boton_OK.Size = new System.Drawing.Size(180, 41);
            this.boton_OK.TabIndex = 9;
            this.boton_OK.Text = "OK";
            this.boton_OK.UseVisualStyleBackColor = true;
            this.boton_OK.Click += new System.EventHandler(this.Boton_OK_Click);
            // 
            // boton_Buscar
            // 
            this.boton_Buscar.Location = new System.Drawing.Point(6, 367);
            this.boton_Buscar.Name = "boton_Buscar";
            this.boton_Buscar.Size = new System.Drawing.Size(180, 41);
            this.boton_Buscar.TabIndex = 6;
            this.boton_Buscar.Text = "Buscar";
            this.boton_Buscar.UseVisualStyleBackColor = true;
            this.boton_Buscar.Click += new System.EventHandler(this.Boton_Buscar_Click);
            // 
            // Agregar_Lectores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Cliente.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(962, 439);
            this.Controls.Add(this.groupBox_AgregarLectores);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agregar_Lectores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Lectores";
            this.groupBox_AgregarLectores.ResumeLayout(false);
            this.groupBox_AgregarLectores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Huella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lectores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_AgregarLectores;
        private System.Windows.Forms.Button boton_Cancelar;
        private System.Windows.Forms.DataGridView dataGridView_Lectores;
        private System.Windows.Forms.Label etiquetaClaveHuella;
        private System.Windows.Forms.Label etiquetaDescripcionLector;
        private System.Windows.Forms.Label etiquetaRegistroLector;
        private System.Windows.Forms.Label etiquetaDescripcion;
        private System.Windows.Forms.Label etiquetaRegistro;
        private System.Windows.Forms.Button boton_Agregar;
        private System.Windows.Forms.Button boton_OK;
        private System.Windows.Forms.Button boton_Buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn datoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn datoRegistro;
        private System.Windows.Forms.TextBox txt_Huella;
        private System.Windows.Forms.PictureBox pictureBox_Huella;
        private System.Windows.Forms.Label txt_Informacion;
    }
}