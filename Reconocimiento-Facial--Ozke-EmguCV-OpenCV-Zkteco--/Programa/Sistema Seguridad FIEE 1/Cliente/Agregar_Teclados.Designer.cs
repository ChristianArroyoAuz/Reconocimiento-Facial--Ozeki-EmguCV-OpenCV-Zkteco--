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
    partial class Agregar_Teclados
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agregar_Teclados));
            this.groupBox_AgregarTeclado = new System.Windows.Forms.GroupBox();
            this.boton_Cancelar = new System.Windows.Forms.Button();
            this.dataGridView_Teclados = new System.Windows.Forms.DataGridView();
            this.datoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etiquetaTecla = new System.Windows.Forms.Label();
            this.etiquetaTeclaPresionada = new System.Windows.Forms.Label();
            this.etiquetaDescripcionTeclado = new System.Windows.Forms.Label();
            this.etiquetaRegistroTeclado = new System.Windows.Forms.Label();
            this.etiquetaDescripcion = new System.Windows.Forms.Label();
            this.etiquetaRegistro = new System.Windows.Forms.Label();
            this.boton_Agregar = new System.Windows.Forms.Button();
            this.boton_OK = new System.Windows.Forms.Button();
            this.boton_Buscar = new System.Windows.Forms.Button();
            this.groupBox_AgregarTeclado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Teclados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_AgregarTeclado
            // 
            this.groupBox_AgregarTeclado.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_AgregarTeclado.Controls.Add(this.boton_Cancelar);
            this.groupBox_AgregarTeclado.Controls.Add(this.dataGridView_Teclados);
            this.groupBox_AgregarTeclado.Controls.Add(this.etiquetaTecla);
            this.groupBox_AgregarTeclado.Controls.Add(this.etiquetaTeclaPresionada);
            this.groupBox_AgregarTeclado.Controls.Add(this.etiquetaDescripcionTeclado);
            this.groupBox_AgregarTeclado.Controls.Add(this.etiquetaRegistroTeclado);
            this.groupBox_AgregarTeclado.Controls.Add(this.etiquetaDescripcion);
            this.groupBox_AgregarTeclado.Controls.Add(this.etiquetaRegistro);
            this.groupBox_AgregarTeclado.Controls.Add(this.boton_Agregar);
            this.groupBox_AgregarTeclado.Controls.Add(this.boton_OK);
            this.groupBox_AgregarTeclado.Controls.Add(this.boton_Buscar);
            this.groupBox_AgregarTeclado.Location = new System.Drawing.Point(12, 12);
            this.groupBox_AgregarTeclado.Name = "groupBox_AgregarTeclado";
            this.groupBox_AgregarTeclado.Size = new System.Drawing.Size(942, 420);
            this.groupBox_AgregarTeclado.TabIndex = 0;
            this.groupBox_AgregarTeclado.TabStop = false;
            this.groupBox_AgregarTeclado.Text = "Agregar Teclados";
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
            // dataGridView_Teclados
            // 
            this.dataGridView_Teclados.AllowUserToAddRows = false;
            this.dataGridView_Teclados.AllowUserToDeleteRows = false;
            this.dataGridView_Teclados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Teclados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datoNombre,
            this.datoRegistro});
            this.dataGridView_Teclados.Location = new System.Drawing.Point(6, 29);
            this.dataGridView_Teclados.MultiSelect = false;
            this.dataGridView_Teclados.Name = "dataGridView_Teclados";
            this.dataGridView_Teclados.ReadOnly = true;
            this.dataGridView_Teclados.RowTemplate.Height = 24;
            this.dataGridView_Teclados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Teclados.Size = new System.Drawing.Size(924, 155);
            this.dataGridView_Teclados.TabIndex = 8;
            this.dataGridView_Teclados.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Teclados_RowEnter);
            // 
            // datoNombre
            // 
            this.datoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datoNombre.HeaderText = "Nombre Del Teclado";
            this.datoNombre.Name = "datoNombre";
            this.datoNombre.ReadOnly = true;
            // 
            // datoRegistro
            // 
            this.datoRegistro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datoRegistro.HeaderText = "Registro Del Teclado";
            this.datoRegistro.Name = "datoRegistro";
            this.datoRegistro.ReadOnly = true;
            // 
            // etiquetaTecla
            // 
            this.etiquetaTecla.AutoSize = true;
            this.etiquetaTecla.Location = new System.Drawing.Point(175, 305);
            this.etiquetaTecla.Name = "etiquetaTecla";
            this.etiquetaTecla.Size = new System.Drawing.Size(0, 23);
            this.etiquetaTecla.TabIndex = 5;
            // 
            // etiquetaTeclaPresionada
            // 
            this.etiquetaTeclaPresionada.AutoSize = true;
            this.etiquetaTeclaPresionada.Location = new System.Drawing.Point(2, 305);
            this.etiquetaTeclaPresionada.Name = "etiquetaTeclaPresionada";
            this.etiquetaTeclaPresionada.Size = new System.Drawing.Size(167, 23);
            this.etiquetaTeclaPresionada.TabIndex = 4;
            this.etiquetaTeclaPresionada.Text = "Tecla Presionada:";
            // 
            // etiquetaDescripcionTeclado
            // 
            this.etiquetaDescripcionTeclado.AutoSize = true;
            this.etiquetaDescripcionTeclado.Location = new System.Drawing.Point(2, 187);
            this.etiquetaDescripcionTeclado.Name = "etiquetaDescripcionTeclado";
            this.etiquetaDescripcionTeclado.Size = new System.Drawing.Size(227, 23);
            this.etiquetaDescripcionTeclado.TabIndex = 0;
            this.etiquetaDescripcionTeclado.Text = "Descripcion Del Teclado:";
            // 
            // etiquetaRegistroTeclado
            // 
            this.etiquetaRegistroTeclado.AutoSize = true;
            this.etiquetaRegistroTeclado.Location = new System.Drawing.Point(2, 246);
            this.etiquetaRegistroTeclado.Name = "etiquetaRegistroTeclado";
            this.etiquetaRegistroTeclado.Size = new System.Drawing.Size(199, 23);
            this.etiquetaRegistroTeclado.TabIndex = 2;
            this.etiquetaRegistroTeclado.Text = "Registro Del Teclado:";
            // 
            // etiquetaDescripcion
            // 
            this.etiquetaDescripcion.AutoSize = true;
            this.etiquetaDescripcion.Location = new System.Drawing.Point(239, 187);
            this.etiquetaDescripcion.Name = "etiquetaDescripcion";
            this.etiquetaDescripcion.Size = new System.Drawing.Size(0, 23);
            this.etiquetaDescripcion.TabIndex = 1;
            // 
            // etiquetaRegistro
            // 
            this.etiquetaRegistro.AutoSize = true;
            this.etiquetaRegistro.Location = new System.Drawing.Point(204, 246);
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
            // Agregar_Teclados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Cliente.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(962, 439);
            this.Controls.Add(this.groupBox_AgregarTeclado);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agregar_Teclados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Teclados";
            this.groupBox_AgregarTeclado.ResumeLayout(false);
            this.groupBox_AgregarTeclado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Teclados)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox groupBox_AgregarTeclado;
        private System.Windows.Forms.Button boton_OK;
        private System.Windows.Forms.Button boton_Buscar;
        private System.Windows.Forms.Button boton_Agregar;
        private System.Windows.Forms.Label etiquetaDescripcion;
        private System.Windows.Forms.Label etiquetaRegistro;
        private System.Windows.Forms.Label etiquetaDescripcionTeclado;
        private System.Windows.Forms.Label etiquetaRegistroTeclado;
        private System.Windows.Forms.Label etiquetaTecla;
        private System.Windows.Forms.Label etiquetaTeclaPresionada;
        private System.Windows.Forms.DataGridView dataGridView_Teclados;
        private System.Windows.Forms.DataGridViewTextBoxColumn datoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn datoRegistro;
        private System.Windows.Forms.Button boton_Cancelar;
    }
}