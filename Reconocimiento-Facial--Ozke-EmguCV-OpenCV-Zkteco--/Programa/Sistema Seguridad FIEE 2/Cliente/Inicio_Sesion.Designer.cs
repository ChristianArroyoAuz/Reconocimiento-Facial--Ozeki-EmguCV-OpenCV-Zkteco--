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
    partial class Inicio_Sesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio_Sesion));
            this.pictureBox_Escudo = new System.Windows.Forms.PictureBox();
            this.etiquetaNombre = new System.Windows.Forms.Label();
            this.etiquetaPassword = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.boton_Regresar = new System.Windows.Forms.Button();
            this.boton_Ingresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Escudo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Escudo
            // 
            this.pictureBox_Escudo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Escudo.BackgroundImage = global::Cliente.Properties.Resources.Escudo;
            this.pictureBox_Escudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Escudo.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Escudo.Name = "pictureBox_Escudo";
            this.pictureBox_Escudo.Size = new System.Drawing.Size(459, 290);
            this.pictureBox_Escudo.TabIndex = 0;
            this.pictureBox_Escudo.TabStop = false;
            // 
            // etiquetaNombre
            // 
            this.etiquetaNombre.AutoSize = true;
            this.etiquetaNombre.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaNombre.Location = new System.Drawing.Point(8, 351);
            this.etiquetaNombre.Name = "etiquetaNombre";
            this.etiquetaNombre.Size = new System.Drawing.Size(82, 23);
            this.etiquetaNombre.TabIndex = 0;
            this.etiquetaNombre.Text = "Usuario:";
            // 
            // etiquetaPassword
            // 
            this.etiquetaPassword.AutoSize = true;
            this.etiquetaPassword.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaPassword.Location = new System.Drawing.Point(8, 423);
            this.etiquetaPassword.Name = "etiquetaPassword";
            this.etiquetaPassword.Size = new System.Drawing.Size(118, 23);
            this.etiquetaPassword.TabIndex = 1;
            this.etiquetaPassword.Text = "Contraseña:";
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(222, 344);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(249, 30);
            this.txt_Usuario.TabIndex = 2;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(222, 416);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(249, 30);
            this.txt_Password.TabIndex = 3;
            // 
            // boton_Regresar
            // 
            this.boton_Regresar.Location = new System.Drawing.Point(271, 488);
            this.boton_Regresar.Name = "boton_Regresar";
            this.boton_Regresar.Size = new System.Drawing.Size(200, 50);
            this.boton_Regresar.TabIndex = 5;
            this.boton_Regresar.Text = "Regresar";
            this.boton_Regresar.UseVisualStyleBackColor = true;
            this.boton_Regresar.Click += new System.EventHandler(this.Boton_Regresar_Click);
            // 
            // boton_Ingresar
            // 
            this.boton_Ingresar.Location = new System.Drawing.Point(12, 488);
            this.boton_Ingresar.Name = "boton_Ingresar";
            this.boton_Ingresar.Size = new System.Drawing.Size(200, 50);
            this.boton_Ingresar.TabIndex = 4;
            this.boton_Ingresar.Text = "Ingresar";
            this.boton_Ingresar.UseVisualStyleBackColor = true;
            this.boton_Ingresar.Click += new System.EventHandler(this.Boton_Ingresar_Click);
            // 
            // Inicio_Sesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Cliente.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(483, 552);
            this.Controls.Add(this.boton_Ingresar);
            this.Controls.Add(this.boton_Regresar);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.etiquetaPassword);
            this.Controls.Add(this.etiquetaNombre);
            this.Controls.Add(this.pictureBox_Escudo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio_Sesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio Sesion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Escudo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Escudo;
        private System.Windows.Forms.Label etiquetaNombre;
        private System.Windows.Forms.Label etiquetaPassword;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button boton_Regresar;
        private System.Windows.Forms.Button boton_Ingresar;
    }
}