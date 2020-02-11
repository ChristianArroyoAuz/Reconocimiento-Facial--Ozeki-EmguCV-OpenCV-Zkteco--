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
    partial class Administracion_Usuarios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administracion_Usuarios));
            this.pictureBox_Imagen = new System.Windows.Forms.PictureBox();
            this.etiquetaTitulo = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.Label();
            this.etiquetaID = new System.Windows.Forms.Label();
            this.txt_ConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.txt_Contraseña = new System.Windows.Forms.TextBox();
            this.etiquetaConfirmar = new System.Windows.Forms.Label();
            this.etiquetaContraseña = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.etiquetaNombre = new System.Windows.Forms.Label();
            this.etiquetaCedula = new System.Windows.Forms.Label();
            this.txt_Cedula = new System.Windows.Forms.TextBox();
            this.etiquetaAlias = new System.Windows.Forms.Label();
            this.txt_Alias = new System.Windows.Forms.TextBox();
            this.etiquetaApellido = new System.Windows.Forms.Label();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.etiquetaTipo = new System.Windows.Forms.Label();
            this.comboBox_Tipo = new System.Windows.Forms.ComboBox();
            this.etiquetaDepartamento = new System.Windows.Forms.Label();
            this.comboBox_Departamento = new System.Windows.Forms.ComboBox();
            this.etiquetaCorreo = new System.Windows.Forms.Label();
            this.txt_Correo = new System.Windows.Forms.TextBox();
            this.etiquetaPIN = new System.Windows.Forms.Label();
            this.txt_Pin = new System.Windows.Forms.TextBox();
            this.etiquetaHuella = new System.Windows.Forms.Label();
            this.txt_Huella = new System.Windows.Forms.TextBox();
            this.etiquetaFacial = new System.Windows.Forms.Label();
            this.txt_Facial = new System.Windows.Forms.TextBox();
            this.boton_Actualizar = new System.Windows.Forms.Button();
            this.dataGridView_Datos = new System.Windows.Forms.DataGridView();
            this.boton_Eliminar = new System.Windows.Forms.Button();
            this.boton_Registrar = new System.Windows.Forms.Button();
            this.boton_DetectarRostro = new System.Windows.Forms.Button();
            this.boton_BuscarFoto = new System.Windows.Forms.Button();
            this.boton_DetectarHuella = new System.Windows.Forms.Button();
            this.reconocimientoRostro = new Emgu.CV.UI.ImageBox();
            this.boton_HabilitarReconocimiento = new System.Windows.Forms.Button();
            this.boton_GuardarRostro = new System.Windows.Forms.Button();
            this.groupBox_Detectar = new System.Windows.Forms.GroupBox();
            this.etiquetaCantidadRostrosDetectados = new System.Windows.Forms.Label();
            this.etiquetaRostros = new System.Windows.Forms.Label();
            this.groupBox_BuscarFoto = new System.Windows.Forms.GroupBox();
            this.etiquetaCantidasRostrosFoto = new System.Windows.Forms.Label();
            this.etiquetaFotos = new System.Windows.Forms.Label();
            this.boton_GuardarFoto = new System.Windows.Forms.Button();
            this.boton_BuscarImagen = new System.Windows.Forms.Button();
            this.reconocimientoFoto = new Emgu.CV.UI.ImageBox();
            this.groupBox_Dactilar = new System.Windows.Forms.GroupBox();
            this.etiquetaDatos = new System.Windows.Forms.Label();
            this.etiquetaInformacion = new System.Windows.Forms.Label();
            this.boton_GuardarHuella = new System.Windows.Forms.Button();
            this.txt_RegistroHuella = new System.Windows.Forms.TextBox();
            this.etiquetaRegistro = new System.Windows.Forms.Label();
            this.txt_SerialDispositivo = new System.Windows.Forms.Label();
            this.etiquetaSerial = new System.Windows.Forms.Label();
            this.boton_VerificarHuella = new System.Windows.Forms.Button();
            this.boton_RegistrarHuella = new System.Windows.Forms.Button();
            this.pictureBox_Huella = new System.Windows.Forms.PictureBox();
            this.boton_Regresar = new System.Windows.Forms.Button();
            this.groupBox_Logs = new System.Windows.Forms.GroupBox();
            this.listBox_Logs = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Imagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconocimientoRostro)).BeginInit();
            this.groupBox_Detectar.SuspendLayout();
            this.groupBox_BuscarFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconocimientoFoto)).BeginInit();
            this.groupBox_Dactilar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Huella)).BeginInit();
            this.groupBox_Logs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_Imagen
            // 
            this.pictureBox_Imagen.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Imagen.BackgroundImage = global::Cliente.Properties.Resources.RegistroUsu;
            this.pictureBox_Imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Imagen.Location = new System.Drawing.Point(13, 13);
            this.pictureBox_Imagen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox_Imagen.Name = "pictureBox_Imagen";
            this.pictureBox_Imagen.Size = new System.Drawing.Size(130, 959);
            this.pictureBox_Imagen.TabIndex = 0;
            this.pictureBox_Imagen.TabStop = false;
            // 
            // etiquetaTitulo
            // 
            this.etiquetaTitulo.AutoSize = true;
            this.etiquetaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaTitulo.Font = new System.Drawing.Font("Arial", 30F);
            this.etiquetaTitulo.Location = new System.Drawing.Point(143, 13);
            this.etiquetaTitulo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaTitulo.Name = "etiquetaTitulo";
            this.etiquetaTitulo.Size = new System.Drawing.Size(606, 57);
            this.etiquetaTitulo.TabIndex = 0;
            this.etiquetaTitulo.Text = "CREAR NUEVA CUENTA.";
            // 
            // txt_Id
            // 
            this.txt_Id.AutoSize = true;
            this.txt_Id.BackColor = System.Drawing.Color.Transparent;
            this.txt_Id.Location = new System.Drawing.Point(440, 83);
            this.txt_Id.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(21, 23);
            this.txt_Id.TabIndex = 23;
            this.txt_Id.Text = "0";
            // 
            // etiquetaID
            // 
            this.etiquetaID.AutoSize = true;
            this.etiquetaID.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaID.Location = new System.Drawing.Point(154, 83);
            this.etiquetaID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaID.Name = "etiquetaID";
            this.etiquetaID.Size = new System.Drawing.Size(36, 23);
            this.etiquetaID.TabIndex = 1;
            this.etiquetaID.Text = "ID:";
            // 
            // txt_ConfirmarContraseña
            // 
            this.txt_ConfirmarContraseña.Location = new System.Drawing.Point(440, 322);
            this.txt_ConfirmarContraseña.Margin = new System.Windows.Forms.Padding(6);
            this.txt_ConfirmarContraseña.Name = "txt_ConfirmarContraseña";
            this.txt_ConfirmarContraseña.PasswordChar = '*';
            this.txt_ConfirmarContraseña.Size = new System.Drawing.Size(403, 30);
            this.txt_ConfirmarContraseña.TabIndex = 17;
            this.txt_ConfirmarContraseña.Leave += new System.EventHandler(this.Txt_ConfirmarContraseña_Leave);
            // 
            // txt_Contraseña
            // 
            this.txt_Contraseña.Location = new System.Drawing.Point(440, 280);
            this.txt_Contraseña.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Contraseña.Name = "txt_Contraseña";
            this.txt_Contraseña.PasswordChar = '*';
            this.txt_Contraseña.Size = new System.Drawing.Size(403, 30);
            this.txt_Contraseña.TabIndex = 16;
            this.txt_Contraseña.Leave += new System.EventHandler(this.Txt_Contraseña_Leave);
            // 
            // etiquetaConfirmar
            // 
            this.etiquetaConfirmar.AutoSize = true;
            this.etiquetaConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaConfirmar.Location = new System.Drawing.Point(154, 329);
            this.etiquetaConfirmar.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaConfirmar.Name = "etiquetaConfirmar";
            this.etiquetaConfirmar.Size = new System.Drawing.Size(276, 23);
            this.etiquetaConfirmar.TabIndex = 7;
            this.etiquetaConfirmar.Text = "CONFIRMAR CONTRASEÑA:";
            // 
            // etiquetaContraseña
            // 
            this.etiquetaContraseña.AutoSize = true;
            this.etiquetaContraseña.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaContraseña.Location = new System.Drawing.Point(154, 287);
            this.etiquetaContraseña.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaContraseña.Name = "etiquetaContraseña";
            this.etiquetaContraseña.Size = new System.Drawing.Size(151, 23);
            this.etiquetaContraseña.TabIndex = 6;
            this.etiquetaContraseña.Text = "CONTRASEÑA:";
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(440, 196);
            this.txt_Nombre.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(403, 30);
            this.txt_Nombre.TabIndex = 14;
            // 
            // etiquetaNombre
            // 
            this.etiquetaNombre.AutoSize = true;
            this.etiquetaNombre.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaNombre.Location = new System.Drawing.Point(154, 203);
            this.etiquetaNombre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaNombre.Name = "etiquetaNombre";
            this.etiquetaNombre.Size = new System.Drawing.Size(102, 23);
            this.etiquetaNombre.TabIndex = 4;
            this.etiquetaNombre.Text = "NOMBRE:";
            // 
            // etiquetaCedula
            // 
            this.etiquetaCedula.AutoSize = true;
            this.etiquetaCedula.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaCedula.Location = new System.Drawing.Point(154, 119);
            this.etiquetaCedula.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaCedula.Name = "etiquetaCedula";
            this.etiquetaCedula.Size = new System.Drawing.Size(94, 23);
            this.etiquetaCedula.TabIndex = 2;
            this.etiquetaCedula.Text = "CEDULA:";
            // 
            // txt_Cedula
            // 
            this.txt_Cedula.Location = new System.Drawing.Point(440, 112);
            this.txt_Cedula.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Cedula.Name = "txt_Cedula";
            this.txt_Cedula.Size = new System.Drawing.Size(403, 30);
            this.txt_Cedula.TabIndex = 24;
            this.txt_Cedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Cedula_KeyPress);
            this.txt_Cedula.Leave += new System.EventHandler(this.Txt_Cedula_Leave);
            // 
            // etiquetaAlias
            // 
            this.etiquetaAlias.AutoSize = true;
            this.etiquetaAlias.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaAlias.Location = new System.Drawing.Point(154, 161);
            this.etiquetaAlias.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaAlias.Name = "etiquetaAlias";
            this.etiquetaAlias.Size = new System.Drawing.Size(72, 23);
            this.etiquetaAlias.TabIndex = 3;
            this.etiquetaAlias.Text = "ALIAS:";
            // 
            // txt_Alias
            // 
            this.txt_Alias.Location = new System.Drawing.Point(440, 154);
            this.txt_Alias.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Alias.Name = "txt_Alias";
            this.txt_Alias.Size = new System.Drawing.Size(403, 30);
            this.txt_Alias.TabIndex = 25;
            this.txt_Alias.Leave += new System.EventHandler(this.Txt_Alias_Leave);
            // 
            // etiquetaApellido
            // 
            this.etiquetaApellido.AutoSize = true;
            this.etiquetaApellido.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaApellido.Location = new System.Drawing.Point(154, 245);
            this.etiquetaApellido.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaApellido.Name = "etiquetaApellido";
            this.etiquetaApellido.Size = new System.Drawing.Size(113, 23);
            this.etiquetaApellido.TabIndex = 5;
            this.etiquetaApellido.Text = "APELLIDO:";
            // 
            // txt_Apellido
            // 
            this.txt_Apellido.Location = new System.Drawing.Point(440, 238);
            this.txt_Apellido.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(403, 30);
            this.txt_Apellido.TabIndex = 15;
            // 
            // etiquetaTipo
            // 
            this.etiquetaTipo.AutoSize = true;
            this.etiquetaTipo.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaTipo.Location = new System.Drawing.Point(154, 370);
            this.etiquetaTipo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaTipo.Name = "etiquetaTipo";
            this.etiquetaTipo.Size = new System.Drawing.Size(63, 23);
            this.etiquetaTipo.TabIndex = 8;
            this.etiquetaTipo.Text = "TIPO:";
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(440, 362);
            this.comboBox_Tipo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(401, 31);
            this.comboBox_Tipo.TabIndex = 18;
            // 
            // etiquetaDepartamento
            // 
            this.etiquetaDepartamento.AutoSize = true;
            this.etiquetaDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaDepartamento.Location = new System.Drawing.Point(154, 409);
            this.etiquetaDepartamento.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaDepartamento.Name = "etiquetaDepartamento";
            this.etiquetaDepartamento.Size = new System.Drawing.Size(177, 23);
            this.etiquetaDepartamento.TabIndex = 9;
            this.etiquetaDepartamento.Text = "DEPARTAMENTO:";
            // 
            // comboBox_Departamento
            // 
            this.comboBox_Departamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Departamento.FormattingEnabled = true;
            this.comboBox_Departamento.Location = new System.Drawing.Point(440, 401);
            this.comboBox_Departamento.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBox_Departamento.Name = "comboBox_Departamento";
            this.comboBox_Departamento.Size = new System.Drawing.Size(403, 31);
            this.comboBox_Departamento.TabIndex = 19;
            // 
            // etiquetaCorreo
            // 
            this.etiquetaCorreo.AutoSize = true;
            this.etiquetaCorreo.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaCorreo.Location = new System.Drawing.Point(154, 449);
            this.etiquetaCorreo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaCorreo.Name = "etiquetaCorreo";
            this.etiquetaCorreo.Size = new System.Drawing.Size(103, 23);
            this.etiquetaCorreo.TabIndex = 10;
            this.etiquetaCorreo.Text = "CORREO:";
            // 
            // txt_Correo
            // 
            this.txt_Correo.Location = new System.Drawing.Point(440, 442);
            this.txt_Correo.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Correo.Name = "txt_Correo";
            this.txt_Correo.Size = new System.Drawing.Size(403, 30);
            this.txt_Correo.TabIndex = 20;
            this.txt_Correo.Leave += new System.EventHandler(this.Txt_Correo_Leave);
            // 
            // etiquetaPIN
            // 
            this.etiquetaPIN.AutoSize = true;
            this.etiquetaPIN.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaPIN.Location = new System.Drawing.Point(154, 491);
            this.etiquetaPIN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaPIN.Name = "etiquetaPIN";
            this.etiquetaPIN.Size = new System.Drawing.Size(169, 23);
            this.etiquetaPIN.TabIndex = 11;
            this.etiquetaPIN.Text = "PIN DE ACCESO:";
            // 
            // txt_Pin
            // 
            this.txt_Pin.Location = new System.Drawing.Point(440, 484);
            this.txt_Pin.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Pin.Name = "txt_Pin";
            this.txt_Pin.PasswordChar = '*';
            this.txt_Pin.Size = new System.Drawing.Size(403, 30);
            this.txt_Pin.TabIndex = 21;
            this.txt_Pin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Pin_KeyPress);
            this.txt_Pin.Leave += new System.EventHandler(this.Txt_Pin_Leave);
            // 
            // etiquetaHuella
            // 
            this.etiquetaHuella.AutoSize = true;
            this.etiquetaHuella.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaHuella.Location = new System.Drawing.Point(154, 533);
            this.etiquetaHuella.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaHuella.Name = "etiquetaHuella";
            this.etiquetaHuella.Size = new System.Drawing.Size(192, 23);
            this.etiquetaHuella.TabIndex = 12;
            this.etiquetaHuella.Text = "HUELLA DACTILAR:";
            // 
            // txt_Huella
            // 
            this.txt_Huella.Location = new System.Drawing.Point(440, 526);
            this.txt_Huella.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Huella.Name = "txt_Huella";
            this.txt_Huella.Size = new System.Drawing.Size(403, 30);
            this.txt_Huella.TabIndex = 22;
            // 
            // etiquetaFacial
            // 
            this.etiquetaFacial.AutoSize = true;
            this.etiquetaFacial.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaFacial.Location = new System.Drawing.Point(154, 624);
            this.etiquetaFacial.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.etiquetaFacial.Name = "etiquetaFacial";
            this.etiquetaFacial.Size = new System.Drawing.Size(205, 23);
            this.etiquetaFacial.TabIndex = 13;
            this.etiquetaFacial.Text = "DETECCIÓN FACIAL:";
            // 
            // txt_Facial
            // 
            this.txt_Facial.Location = new System.Drawing.Point(440, 617);
            this.txt_Facial.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Facial.Name = "txt_Facial";
            this.txt_Facial.Size = new System.Drawing.Size(403, 30);
            this.txt_Facial.TabIndex = 27;
            // 
            // boton_Actualizar
            // 
            this.boton_Actualizar.Location = new System.Drawing.Point(509, 709);
            this.boton_Actualizar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boton_Actualizar.Name = "boton_Actualizar";
            this.boton_Actualizar.Size = new System.Drawing.Size(290, 43);
            this.boton_Actualizar.TabIndex = 31;
            this.boton_Actualizar.Text = "ACTUALIZAR.";
            this.boton_Actualizar.UseVisualStyleBackColor = true;
            this.boton_Actualizar.Click += new System.EventHandler(this.Boton_Actualizar_Click);
            // 
            // dataGridView_Datos
            // 
            this.dataGridView_Datos.AllowUserToAddRows = false;
            this.dataGridView_Datos.AllowUserToDeleteRows = false;
            this.dataGridView_Datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Datos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Datos.Location = new System.Drawing.Point(153, 760);
            this.dataGridView_Datos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView_Datos.MultiSelect = false;
            this.dataGridView_Datos.Name = "dataGridView_Datos";
            this.dataGridView_Datos.ReadOnly = true;
            this.dataGridView_Datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Datos.Size = new System.Drawing.Size(1371, 213);
            this.dataGridView_Datos.TabIndex = 34;
            this.dataGridView_Datos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Datos_RowEnter);
            // 
            // boton_Eliminar
            // 
            this.boton_Eliminar.Location = new System.Drawing.Point(876, 710);
            this.boton_Eliminar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boton_Eliminar.Name = "boton_Eliminar";
            this.boton_Eliminar.Size = new System.Drawing.Size(290, 42);
            this.boton_Eliminar.TabIndex = 32;
            this.boton_Eliminar.Text = "ELIMINAR.";
            this.boton_Eliminar.UseVisualStyleBackColor = true;
            this.boton_Eliminar.Click += new System.EventHandler(this.Boton_Eliminar_Click);
            // 
            // boton_Registrar
            // 
            this.boton_Registrar.Location = new System.Drawing.Point(153, 709);
            this.boton_Registrar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boton_Registrar.Name = "boton_Registrar";
            this.boton_Registrar.Size = new System.Drawing.Size(290, 43);
            this.boton_Registrar.TabIndex = 30;
            this.boton_Registrar.Text = "REGISTRAR.";
            this.boton_Registrar.UseVisualStyleBackColor = true;
            this.boton_Registrar.Click += new System.EventHandler(this.Boton_Registrar_Click);
            // 
            // boton_DetectarRostro
            // 
            this.boton_DetectarRostro.Location = new System.Drawing.Point(440, 656);
            this.boton_DetectarRostro.Name = "boton_DetectarRostro";
            this.boton_DetectarRostro.Size = new System.Drawing.Size(200, 43);
            this.boton_DetectarRostro.TabIndex = 28;
            this.boton_DetectarRostro.Text = "TOMAR FOTO";
            this.boton_DetectarRostro.UseVisualStyleBackColor = true;
            this.boton_DetectarRostro.Click += new System.EventHandler(this.Boton_DetectarRostro_Click);
            // 
            // boton_BuscarFoto
            // 
            this.boton_BuscarFoto.Location = new System.Drawing.Point(646, 656);
            this.boton_BuscarFoto.Name = "boton_BuscarFoto";
            this.boton_BuscarFoto.Size = new System.Drawing.Size(200, 43);
            this.boton_BuscarFoto.TabIndex = 29;
            this.boton_BuscarFoto.Text = "BUSCAR FOTO";
            this.boton_BuscarFoto.UseVisualStyleBackColor = true;
            this.boton_BuscarFoto.Click += new System.EventHandler(this.Boton_BuscarFoto_Click);
            // 
            // boton_DetectarHuella
            // 
            this.boton_DetectarHuella.Location = new System.Drawing.Point(440, 565);
            this.boton_DetectarHuella.Name = "boton_DetectarHuella";
            this.boton_DetectarHuella.Size = new System.Drawing.Size(403, 43);
            this.boton_DetectarHuella.TabIndex = 26;
            this.boton_DetectarHuella.Text = "TOMAR HUELLA";
            this.boton_DetectarHuella.UseVisualStyleBackColor = true;
            this.boton_DetectarHuella.Click += new System.EventHandler(this.Boton_DetectarHuella_Click);
            // 
            // reconocimientoRostro
            // 
            this.reconocimientoRostro.BackColor = System.Drawing.Color.Black;
            this.reconocimientoRostro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reconocimientoRostro.Enabled = false;
            this.reconocimientoRostro.Location = new System.Drawing.Point(8, 23);
            this.reconocimientoRostro.Margin = new System.Windows.Forms.Padding(4);
            this.reconocimientoRostro.Name = "reconocimientoRostro";
            this.reconocimientoRostro.Size = new System.Drawing.Size(317, 204);
            this.reconocimientoRostro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reconocimientoRostro.TabIndex = 5;
            this.reconocimientoRostro.TabStop = false;
            // 
            // boton_HabilitarReconocimiento
            // 
            this.boton_HabilitarReconocimiento.Location = new System.Drawing.Point(10, 234);
            this.boton_HabilitarReconocimiento.Name = "boton_HabilitarReconocimiento";
            this.boton_HabilitarReconocimiento.Size = new System.Drawing.Size(131, 32);
            this.boton_HabilitarReconocimiento.TabIndex = 0;
            this.boton_HabilitarReconocimiento.Text = "Habilitar";
            this.boton_HabilitarReconocimiento.UseVisualStyleBackColor = true;
            this.boton_HabilitarReconocimiento.Click += new System.EventHandler(this.Boton_HabilitarReconocimiento_Click);
            // 
            // boton_GuardarRostro
            // 
            this.boton_GuardarRostro.Location = new System.Drawing.Point(196, 235);
            this.boton_GuardarRostro.Name = "boton_GuardarRostro";
            this.boton_GuardarRostro.Size = new System.Drawing.Size(131, 32);
            this.boton_GuardarRostro.TabIndex = 1;
            this.boton_GuardarRostro.Text = "Guardar";
            this.boton_GuardarRostro.UseVisualStyleBackColor = true;
            this.boton_GuardarRostro.Click += new System.EventHandler(this.Boton_GuardarRostro_Click);
            // 
            // groupBox_Detectar
            // 
            this.groupBox_Detectar.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Detectar.Controls.Add(this.etiquetaCantidadRostrosDetectados);
            this.groupBox_Detectar.Controls.Add(this.etiquetaRostros);
            this.groupBox_Detectar.Controls.Add(this.boton_GuardarRostro);
            this.groupBox_Detectar.Controls.Add(this.boton_HabilitarReconocimiento);
            this.groupBox_Detectar.Controls.Add(this.reconocimientoRostro);
            this.groupBox_Detectar.Location = new System.Drawing.Point(852, 112);
            this.groupBox_Detectar.Name = "groupBox_Detectar";
            this.groupBox_Detectar.Size = new System.Drawing.Size(333, 303);
            this.groupBox_Detectar.TabIndex = 35;
            this.groupBox_Detectar.TabStop = false;
            this.groupBox_Detectar.Text = "Deteccion Facial";
            // 
            // etiquetaCantidadRostrosDetectados
            // 
            this.etiquetaCantidadRostrosDetectados.AutoSize = true;
            this.etiquetaCantidadRostrosDetectados.Location = new System.Drawing.Point(206, 269);
            this.etiquetaCantidadRostrosDetectados.Name = "etiquetaCantidadRostrosDetectados";
            this.etiquetaCantidadRostrosDetectados.Size = new System.Drawing.Size(21, 23);
            this.etiquetaCantidadRostrosDetectados.TabIndex = 3;
            this.etiquetaCantidadRostrosDetectados.Text = "0";
            // 
            // etiquetaRostros
            // 
            this.etiquetaRostros.AutoSize = true;
            this.etiquetaRostros.Location = new System.Drawing.Point(8, 269);
            this.etiquetaRostros.Name = "etiquetaRostros";
            this.etiquetaRostros.Size = new System.Drawing.Size(192, 23);
            this.etiquetaRostros.TabIndex = 2;
            this.etiquetaRostros.Text = "Rostros Detectados:";
            // 
            // groupBox_BuscarFoto
            // 
            this.groupBox_BuscarFoto.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_BuscarFoto.Controls.Add(this.etiquetaCantidasRostrosFoto);
            this.groupBox_BuscarFoto.Controls.Add(this.etiquetaFotos);
            this.groupBox_BuscarFoto.Controls.Add(this.boton_GuardarFoto);
            this.groupBox_BuscarFoto.Controls.Add(this.boton_BuscarImagen);
            this.groupBox_BuscarFoto.Controls.Add(this.reconocimientoFoto);
            this.groupBox_BuscarFoto.Location = new System.Drawing.Point(1191, 112);
            this.groupBox_BuscarFoto.Name = "groupBox_BuscarFoto";
            this.groupBox_BuscarFoto.Size = new System.Drawing.Size(333, 303);
            this.groupBox_BuscarFoto.TabIndex = 36;
            this.groupBox_BuscarFoto.TabStop = false;
            this.groupBox_BuscarFoto.Text = "Buscar Foto";
            // 
            // etiquetaCantidasRostrosFoto
            // 
            this.etiquetaCantidasRostrosFoto.AutoSize = true;
            this.etiquetaCantidasRostrosFoto.Location = new System.Drawing.Point(194, 270);
            this.etiquetaCantidasRostrosFoto.Name = "etiquetaCantidasRostrosFoto";
            this.etiquetaCantidasRostrosFoto.Size = new System.Drawing.Size(21, 23);
            this.etiquetaCantidasRostrosFoto.TabIndex = 3;
            this.etiquetaCantidasRostrosFoto.Text = "0";
            // 
            // etiquetaFotos
            // 
            this.etiquetaFotos.AutoSize = true;
            this.etiquetaFotos.Location = new System.Drawing.Point(-4, 270);
            this.etiquetaFotos.Name = "etiquetaFotos";
            this.etiquetaFotos.Size = new System.Drawing.Size(192, 23);
            this.etiquetaFotos.TabIndex = 2;
            this.etiquetaFotos.Text = "Rostros Detectados:";
            // 
            // boton_GuardarFoto
            // 
            this.boton_GuardarFoto.Location = new System.Drawing.Point(196, 235);
            this.boton_GuardarFoto.Name = "boton_GuardarFoto";
            this.boton_GuardarFoto.Size = new System.Drawing.Size(131, 32);
            this.boton_GuardarFoto.TabIndex = 1;
            this.boton_GuardarFoto.Text = "Guardar";
            this.boton_GuardarFoto.UseVisualStyleBackColor = true;
            this.boton_GuardarFoto.Click += new System.EventHandler(this.Boton_GuardarFoto_Click);
            // 
            // boton_BuscarImagen
            // 
            this.boton_BuscarImagen.Location = new System.Drawing.Point(6, 235);
            this.boton_BuscarImagen.Name = "boton_BuscarImagen";
            this.boton_BuscarImagen.Size = new System.Drawing.Size(131, 32);
            this.boton_BuscarImagen.TabIndex = 0;
            this.boton_BuscarImagen.Text = "Buscar";
            this.boton_BuscarImagen.UseVisualStyleBackColor = true;
            this.boton_BuscarImagen.Click += new System.EventHandler(this.Boton_BuscarImagen_Click);
            // 
            // reconocimientoFoto
            // 
            this.reconocimientoFoto.BackColor = System.Drawing.Color.Black;
            this.reconocimientoFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reconocimientoFoto.Enabled = false;
            this.reconocimientoFoto.Location = new System.Drawing.Point(8, 23);
            this.reconocimientoFoto.Margin = new System.Windows.Forms.Padding(4);
            this.reconocimientoFoto.Name = "reconocimientoFoto";
            this.reconocimientoFoto.Size = new System.Drawing.Size(317, 205);
            this.reconocimientoFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reconocimientoFoto.TabIndex = 5;
            this.reconocimientoFoto.TabStop = false;
            // 
            // groupBox_Dactilar
            // 
            this.groupBox_Dactilar.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Dactilar.Controls.Add(this.etiquetaDatos);
            this.groupBox_Dactilar.Controls.Add(this.etiquetaInformacion);
            this.groupBox_Dactilar.Controls.Add(this.boton_GuardarHuella);
            this.groupBox_Dactilar.Controls.Add(this.txt_RegistroHuella);
            this.groupBox_Dactilar.Controls.Add(this.etiquetaRegistro);
            this.groupBox_Dactilar.Controls.Add(this.txt_SerialDispositivo);
            this.groupBox_Dactilar.Controls.Add(this.etiquetaSerial);
            this.groupBox_Dactilar.Controls.Add(this.boton_VerificarHuella);
            this.groupBox_Dactilar.Controls.Add(this.boton_RegistrarHuella);
            this.groupBox_Dactilar.Controls.Add(this.pictureBox_Huella);
            this.groupBox_Dactilar.Location = new System.Drawing.Point(852, 422);
            this.groupBox_Dactilar.Name = "groupBox_Dactilar";
            this.groupBox_Dactilar.Size = new System.Drawing.Size(672, 280);
            this.groupBox_Dactilar.TabIndex = 37;
            this.groupBox_Dactilar.TabStop = false;
            this.groupBox_Dactilar.Text = "Huella Dactilar";
            // 
            // etiquetaDatos
            // 
            this.etiquetaDatos.AutoSize = true;
            this.etiquetaDatos.Location = new System.Drawing.Point(363, 102);
            this.etiquetaDatos.Name = "etiquetaDatos";
            this.etiquetaDatos.Size = new System.Drawing.Size(21, 23);
            this.etiquetaDatos.TabIndex = 5;
            this.etiquetaDatos.Text = "0";
            this.etiquetaDatos.TextChanged += new System.EventHandler(this.EtiquetaDatos_TextChanged);
            // 
            // etiquetaInformacion
            // 
            this.etiquetaInformacion.AutoSize = true;
            this.etiquetaInformacion.Location = new System.Drawing.Point(248, 102);
            this.etiquetaInformacion.Name = "etiquetaInformacion";
            this.etiquetaInformacion.Size = new System.Drawing.Size(118, 23);
            this.etiquetaInformacion.TabIndex = 2;
            this.etiquetaInformacion.Text = "Informacion:";
            // 
            // boton_GuardarHuella
            // 
            this.boton_GuardarHuella.Location = new System.Drawing.Point(248, 238);
            this.boton_GuardarHuella.Name = "boton_GuardarHuella";
            this.boton_GuardarHuella.Size = new System.Drawing.Size(416, 32);
            this.boton_GuardarHuella.TabIndex = 8;
            this.boton_GuardarHuella.Text = "Guardar Huella";
            this.boton_GuardarHuella.UseVisualStyleBackColor = true;
            this.boton_GuardarHuella.Click += new System.EventHandler(this.Boton_GuardarHuella_Click);
            // 
            // txt_RegistroHuella
            // 
            this.txt_RegistroHuella.Location = new System.Drawing.Point(248, 177);
            this.txt_RegistroHuella.Multiline = true;
            this.txt_RegistroHuella.Name = "txt_RegistroHuella";
            this.txt_RegistroHuella.ReadOnly = true;
            this.txt_RegistroHuella.Size = new System.Drawing.Size(412, 55);
            this.txt_RegistroHuella.TabIndex = 7;
            // 
            // etiquetaRegistro
            // 
            this.etiquetaRegistro.AutoSize = true;
            this.etiquetaRegistro.Location = new System.Drawing.Point(248, 149);
            this.etiquetaRegistro.Name = "etiquetaRegistro";
            this.etiquetaRegistro.Size = new System.Drawing.Size(149, 23);
            this.etiquetaRegistro.TabIndex = 4;
            this.etiquetaRegistro.Text = "Registro Huella:";
            // 
            // txt_SerialDispositivo
            // 
            this.txt_SerialDispositivo.AutoSize = true;
            this.txt_SerialDispositivo.Location = new System.Drawing.Point(416, 125);
            this.txt_SerialDispositivo.Name = "txt_SerialDispositivo";
            this.txt_SerialDispositivo.Size = new System.Drawing.Size(21, 23);
            this.txt_SerialDispositivo.TabIndex = 6;
            this.txt_SerialDispositivo.Text = "0";
            // 
            // etiquetaSerial
            // 
            this.etiquetaSerial.AutoSize = true;
            this.etiquetaSerial.Location = new System.Drawing.Point(248, 125);
            this.etiquetaSerial.Name = "etiquetaSerial";
            this.etiquetaSerial.Size = new System.Drawing.Size(166, 23);
            this.etiquetaSerial.TabIndex = 3;
            this.etiquetaSerial.Text = "Serial Dispositivo:";
            // 
            // boton_VerificarHuella
            // 
            this.boton_VerificarHuella.Location = new System.Drawing.Point(248, 67);
            this.boton_VerificarHuella.Name = "boton_VerificarHuella";
            this.boton_VerificarHuella.Size = new System.Drawing.Size(416, 32);
            this.boton_VerificarHuella.TabIndex = 1;
            this.boton_VerificarHuella.Text = "Verificar Huella";
            this.boton_VerificarHuella.UseVisualStyleBackColor = true;
            this.boton_VerificarHuella.Click += new System.EventHandler(this.Boton_VerificarHuella_Click);
            // 
            // boton_RegistrarHuella
            // 
            this.boton_RegistrarHuella.Location = new System.Drawing.Point(248, 29);
            this.boton_RegistrarHuella.Name = "boton_RegistrarHuella";
            this.boton_RegistrarHuella.Size = new System.Drawing.Size(416, 32);
            this.boton_RegistrarHuella.TabIndex = 0;
            this.boton_RegistrarHuella.Text = "Registrar Huella";
            this.boton_RegistrarHuella.UseVisualStyleBackColor = true;
            this.boton_RegistrarHuella.Click += new System.EventHandler(this.Boton_RegistrarHuella_Click);
            // 
            // pictureBox_Huella
            // 
            this.pictureBox_Huella.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Huella.Location = new System.Drawing.Point(10, 29);
            this.pictureBox_Huella.Name = "pictureBox_Huella";
            this.pictureBox_Huella.Size = new System.Drawing.Size(232, 241);
            this.pictureBox_Huella.TabIndex = 0;
            this.pictureBox_Huella.TabStop = false;
            // 
            // boton_Regresar
            // 
            this.boton_Regresar.Location = new System.Drawing.Point(1234, 709);
            this.boton_Regresar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boton_Regresar.Name = "boton_Regresar";
            this.boton_Regresar.Size = new System.Drawing.Size(290, 43);
            this.boton_Regresar.TabIndex = 33;
            this.boton_Regresar.Text = "REGRESAR.";
            this.boton_Regresar.UseVisualStyleBackColor = true;
            this.boton_Regresar.Click += new System.EventHandler(this.Boton_Regresar_Click);
            // 
            // groupBox_Logs
            // 
            this.groupBox_Logs.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Logs.Controls.Add(this.listBox_Logs);
            this.groupBox_Logs.Location = new System.Drawing.Point(1531, 112);
            this.groupBox_Logs.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Logs.Name = "groupBox_Logs";
            this.groupBox_Logs.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Logs.Size = new System.Drawing.Size(380, 861);
            this.groupBox_Logs.TabIndex = 38;
            this.groupBox_Logs.TabStop = false;
            this.groupBox_Logs.Text = "Logs de Eventos";
            // 
            // listBox_Logs
            // 
            this.listBox_Logs.FormattingEnabled = true;
            this.listBox_Logs.HorizontalScrollbar = true;
            this.listBox_Logs.ItemHeight = 23;
            this.listBox_Logs.Location = new System.Drawing.Point(9, 25);
            this.listBox_Logs.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Logs.Name = "listBox_Logs";
            this.listBox_Logs.Size = new System.Drawing.Size(363, 832);
            this.listBox_Logs.TabIndex = 0;
            // 
            // Administracion_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Cliente.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 985);
            this.Controls.Add(this.groupBox_Logs);
            this.Controls.Add(this.boton_Regresar);
            this.Controls.Add(this.groupBox_Dactilar);
            this.Controls.Add(this.groupBox_BuscarFoto);
            this.Controls.Add(this.groupBox_Detectar);
            this.Controls.Add(this.boton_DetectarHuella);
            this.Controls.Add(this.boton_BuscarFoto);
            this.Controls.Add(this.boton_DetectarRostro);
            this.Controls.Add(this.boton_Actualizar);
            this.Controls.Add(this.dataGridView_Datos);
            this.Controls.Add(this.boton_Eliminar);
            this.Controls.Add(this.boton_Registrar);
            this.Controls.Add(this.txt_Facial);
            this.Controls.Add(this.etiquetaFacial);
            this.Controls.Add(this.txt_Huella);
            this.Controls.Add(this.etiquetaHuella);
            this.Controls.Add(this.txt_Pin);
            this.Controls.Add(this.etiquetaPIN);
            this.Controls.Add(this.txt_Correo);
            this.Controls.Add(this.etiquetaCorreo);
            this.Controls.Add(this.comboBox_Departamento);
            this.Controls.Add(this.etiquetaDepartamento);
            this.Controls.Add(this.comboBox_Tipo);
            this.Controls.Add(this.etiquetaTipo);
            this.Controls.Add(this.txt_Apellido);
            this.Controls.Add(this.etiquetaApellido);
            this.Controls.Add(this.txt_Alias);
            this.Controls.Add(this.etiquetaAlias);
            this.Controls.Add(this.txt_Cedula);
            this.Controls.Add(this.etiquetaCedula);
            this.Controls.Add(this.txt_Id);
            this.Controls.Add(this.etiquetaID);
            this.Controls.Add(this.txt_ConfirmarContraseña);
            this.Controls.Add(this.txt_Contraseña);
            this.Controls.Add(this.etiquetaConfirmar);
            this.Controls.Add(this.etiquetaContraseña);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.etiquetaNombre);
            this.Controls.Add(this.etiquetaTitulo);
            this.Controls.Add(this.pictureBox_Imagen);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Administracion_Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion Usuarios";
            this.Load += new System.EventHandler(this.Administracion_Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconocimientoRostro)).EndInit();
            this.groupBox_Detectar.ResumeLayout(false);
            this.groupBox_Detectar.PerformLayout();
            this.groupBox_BuscarFoto.ResumeLayout(false);
            this.groupBox_BuscarFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconocimientoFoto)).EndInit();
            this.groupBox_Dactilar.ResumeLayout(false);
            this.groupBox_Dactilar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Huella)).EndInit();
            this.groupBox_Logs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Imagen;
        private System.Windows.Forms.Label etiquetaTitulo;
        private System.Windows.Forms.Label txt_Id;
        private System.Windows.Forms.Label etiquetaID;
        private System.Windows.Forms.TextBox txt_ConfirmarContraseña;
        private System.Windows.Forms.TextBox txt_Contraseña;
        private System.Windows.Forms.Label etiquetaConfirmar;
        private System.Windows.Forms.Label etiquetaContraseña;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label etiquetaNombre;
        private System.Windows.Forms.Label etiquetaCedula;
        private System.Windows.Forms.TextBox txt_Cedula;
        private System.Windows.Forms.Label etiquetaAlias;
        private System.Windows.Forms.TextBox txt_Alias;
        private System.Windows.Forms.Label etiquetaApellido;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.Label etiquetaTipo;
        private System.Windows.Forms.ComboBox comboBox_Tipo;
        private System.Windows.Forms.Label etiquetaDepartamento;
        private System.Windows.Forms.ComboBox comboBox_Departamento;
        private System.Windows.Forms.Label etiquetaCorreo;
        private System.Windows.Forms.TextBox txt_Correo;
        private System.Windows.Forms.Label etiquetaPIN;
        private System.Windows.Forms.TextBox txt_Pin;
        private System.Windows.Forms.Label etiquetaHuella;
        private System.Windows.Forms.TextBox txt_Huella;
        private System.Windows.Forms.Label etiquetaFacial;
        private System.Windows.Forms.TextBox txt_Facial;
        private System.Windows.Forms.Button boton_Actualizar;
        private System.Windows.Forms.DataGridView dataGridView_Datos;
        private System.Windows.Forms.Button boton_Eliminar;
        private System.Windows.Forms.Button boton_Registrar;
        private System.Windows.Forms.Button boton_DetectarRostro;
        private System.Windows.Forms.Button boton_BuscarFoto;
        private System.Windows.Forms.Button boton_DetectarHuella;
        private Emgu.CV.UI.ImageBox reconocimientoRostro;
        private System.Windows.Forms.Button boton_HabilitarReconocimiento;
        private System.Windows.Forms.Button boton_GuardarRostro;
        private System.Windows.Forms.GroupBox groupBox_Detectar;
        private System.Windows.Forms.GroupBox groupBox_BuscarFoto;
        private System.Windows.Forms.Button boton_GuardarFoto;
        private System.Windows.Forms.Button boton_BuscarImagen;
        private Emgu.CV.UI.ImageBox reconocimientoFoto;
        private System.Windows.Forms.GroupBox groupBox_Dactilar;
        private System.Windows.Forms.Button boton_Regresar;
        private System.Windows.Forms.Label etiquetaCantidadRostrosDetectados;
        private System.Windows.Forms.Label etiquetaRostros;
        private System.Windows.Forms.Label etiquetaCantidasRostrosFoto;
        private System.Windows.Forms.Label etiquetaFotos;
        private System.Windows.Forms.Button boton_VerificarHuella;
        private System.Windows.Forms.Button boton_RegistrarHuella;
        private System.Windows.Forms.PictureBox pictureBox_Huella;
        private System.Windows.Forms.Button boton_GuardarHuella;
        private System.Windows.Forms.TextBox txt_RegistroHuella;
        private System.Windows.Forms.Label etiquetaRegistro;
        private System.Windows.Forms.Label txt_SerialDispositivo;
        private System.Windows.Forms.Label etiquetaSerial;
        private System.Windows.Forms.Label etiquetaDatos;
        private System.Windows.Forms.Label etiquetaInformacion;
        private System.Windows.Forms.GroupBox groupBox_Logs;
        private System.Windows.Forms.ListBox listBox_Logs;
    }
}