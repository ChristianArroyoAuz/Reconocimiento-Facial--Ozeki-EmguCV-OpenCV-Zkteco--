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
    partial class Sistema_Seguridad_FIEE
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

        #region Código generado por el Diseñador de Windows Forms
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sistema_Seguridad_FIEE));
            this.etiquetaBienvenida = new System.Windows.Forms.Label();
            this.iniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.loginSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsiario = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesEventos = new System.Windows.Forms.ToolStripMenuItem();
            this.verLogDeEventos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Administracion = new System.Windows.Forms.MenuStrip();
            this.administrarBiometricos = new System.Windows.Forms.ToolStripMenuItem();
            this.elegirSistemaDeAcceso = new System.Windows.Forms.ToolStripMenuItem();
            this.activarDeteccionFacial = new System.Windows.Forms.ToolStripMenuItem();
            this.activarHuellaDactilar = new System.Windows.Forms.ToolStripMenuItem();
            this.activarPINAcceso = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónProgramador = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDelProgramador = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_Facial = new System.Windows.Forms.GroupBox();
            this.TabControl_Detalles = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_Detalles = new System.Windows.Forms.GroupBox();
            this.groupBox_Video = new System.Windows.Forms.GroupBox();
            this.txt_Video = new System.Windows.Forms.TextBox();
            this.groupBox_DetallesCamara = new System.Windows.Forms.GroupBox();
            this.txt_DetallesCamara = new System.Windows.Forms.TextBox();
            this.groupBox_Audio = new System.Windows.Forms.GroupBox();
            this.txt_Audio = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox_Colores = new System.Windows.Forms.GroupBox();
            this.etiquetaCorreccionBrillo = new System.Windows.Forms.Label();
            this.etiquetaBrillo = new System.Windows.Forms.Label();
            this.etiquetaCorreccionGamma = new System.Windows.Forms.Label();
            this.etiquetaCorreccionContraste = new System.Windows.Forms.Label();
            this.etiquetaGamma = new System.Windows.Forms.Label();
            this.etiquetaCorreccionSaturacion = new System.Windows.Forms.Label();
            this.etiquetaContraste = new System.Windows.Forms.Label();
            this.scrollBar_Gamma = new System.Windows.Forms.HScrollBar();
            this.scrollBar_Brillo = new System.Windows.Forms.HScrollBar();
            this.etiquetaSaturacion = new System.Windows.Forms.Label();
            this.scrollBar_Saturacion = new System.Windows.Forms.HScrollBar();
            this.scrollBar_Contraste = new System.Windows.Forms.HScrollBar();
            this.groupBox_LimpiarPantallas = new System.Windows.Forms.GroupBox();
            this.boton_LimpiarSala = new System.Windows.Forms.Button();
            this.groupBox_Zoom = new System.Windows.Forms.GroupBox();
            this.boton_DisminuirZoom = new System.Windows.Forms.Button();
            this.boton_AumentarZoom = new System.Windows.Forms.Button();
            this.groupBox_Orientacion = new System.Windows.Forms.GroupBox();
            this.checkBox_Vertical = new System.Windows.Forms.CheckBox();
            this.checkBox_Horizontal = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox_ReconocimientoSala = new System.Windows.Forms.GroupBox();
            this.etiquetaRespuesta1 = new System.Windows.Forms.Label();
            this.etiquetaPersonaEnCuadro = new System.Windows.Forms.Label();
            this.etiquetaNombre = new System.Windows.Forms.Label();
            this.etiquetaRostros = new System.Windows.Forms.Label();
            this.etiquetaCantidadRostrosDetectados = new System.Windows.Forms.Label();
            this.boton_DeshabilitarReconocimiento = new System.Windows.Forms.Button();
            this.boton_HabilitarReconocimiento = new System.Windows.Forms.Button();
            this.reconocimientoSala = new Emgu.CV.UI.ImageBox();
            this.groupBox_Camara = new System.Windows.Forms.GroupBox();
            this.videoSala = new Ozeki.Media.VideoViewerWF();
            this.boton_FinalizarVideo = new System.Windows.Forms.Button();
            this.boton_CapturarImagen = new System.Windows.Forms.Button();
            this.boton_Guardar = new System.Windows.Forms.Button();
            this.boton_IniciarVideo = new System.Windows.Forms.Button();
            this.txt_Guardar = new System.Windows.Forms.TextBox();
            this.groupBox_BuscarCamara = new System.Windows.Forms.GroupBox();
            this.boton_Conectar = new System.Windows.Forms.Button();
            this.boton_Desconectar = new System.Windows.Forms.Button();
            this.etiquetaURL = new System.Windows.Forms.Label();
            this.txt_CamaraURL = new System.Windows.Forms.TextBox();
            this.boton_Buscar = new System.Windows.Forms.Button();
            this.groupBox_Logs = new System.Windows.Forms.GroupBox();
            this.listBox_Logs = new System.Windows.Forms.ListBox();
            this.buscadorArchivos = new System.Windows.Forms.FolderBrowserDialog();
            this.timer_Deteccion = new System.Windows.Forms.Timer(this.components);
            this.timer_Ubicacion = new System.Windows.Forms.Timer(this.components);
            this.groupBox_Pin = new System.Windows.Forms.GroupBox();
            this.groupBox_Teclado = new System.Windows.Forms.GroupBox();
            this.etiquetaRespuesta2 = new System.Windows.Forms.Label();
            this.etiquetaPin = new System.Windows.Forms.Label();
            this.txt_Acceso = new System.Windows.Forms.TextBox();
            this.groupBox_BuscarTeclado = new System.Windows.Forms.GroupBox();
            this.boton_ConectarTeclado = new System.Windows.Forms.Button();
            this.boton_DesconectarTeclado = new System.Windows.Forms.Button();
            this.etiquetaTeclado = new System.Windows.Forms.Label();
            this.txt_NombreTeclado = new System.Windows.Forms.TextBox();
            this.boton_BuscarTeclado = new System.Windows.Forms.Button();
            this.groupBox_Huella = new System.Windows.Forms.GroupBox();
            this.groupBox_Lector = new System.Windows.Forms.GroupBox();
            this.pictureBox_Huella = new System.Windows.Forms.PictureBox();
            this.etiquetaRespuesta3 = new System.Windows.Forms.Label();
            this.groupBox_BuscarLectores = new System.Windows.Forms.GroupBox();
            this.boton_ConectarLector = new System.Windows.Forms.Button();
            this.boton_DesconectarLector = new System.Windows.Forms.Button();
            this.etiquetaLector = new System.Windows.Forms.Label();
            this.txt_NombreLector = new System.Windows.Forms.TextBox();
            this.boton_BuscarLector = new System.Windows.Forms.Button();
            this.timer_Reconocimiento = new System.Windows.Forms.Timer(this.components);
            this.menuStrip_Administracion.SuspendLayout();
            this.groupBox_Facial.SuspendLayout();
            this.TabControl_Detalles.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_Detalles.SuspendLayout();
            this.groupBox_Video.SuspendLayout();
            this.groupBox_DetallesCamara.SuspendLayout();
            this.groupBox_Audio.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox_Colores.SuspendLayout();
            this.groupBox_LimpiarPantallas.SuspendLayout();
            this.groupBox_Zoom.SuspendLayout();
            this.groupBox_Orientacion.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox_ReconocimientoSala.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconocimientoSala)).BeginInit();
            this.groupBox_Camara.SuspendLayout();
            this.groupBox_BuscarCamara.SuspendLayout();
            this.groupBox_Logs.SuspendLayout();
            this.groupBox_Pin.SuspendLayout();
            this.groupBox_Teclado.SuspendLayout();
            this.groupBox_BuscarTeclado.SuspendLayout();
            this.groupBox_Huella.SuspendLayout();
            this.groupBox_Lector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Huella)).BeginInit();
            this.groupBox_BuscarLectores.SuspendLayout();
            this.SuspendLayout();
            // 
            // etiquetaBienvenida
            // 
            this.etiquetaBienvenida.AutoSize = true;
            this.etiquetaBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.etiquetaBienvenida.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaBienvenida.Location = new System.Drawing.Point(16, 45);
            this.etiquetaBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.etiquetaBienvenida.Name = "etiquetaBienvenida";
            this.etiquetaBienvenida.Size = new System.Drawing.Size(653, 33);
            this.etiquetaBienvenida.TabIndex = 1;
            this.etiquetaBienvenida.Text = "Bienvenido al Sistema de Seguridad de la FIEE.";
            // 
            // iniciarSesion
            // 
            this.iniciarSesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginSistema,
            this.logoutSistema});
            this.iniciarSesion.Name = "iniciarSesion";
            this.iniciarSesion.Size = new System.Drawing.Size(139, 27);
            this.iniciarSesion.Text = "Iniciar Sesión";
            // 
            // loginSistema
            // 
            this.loginSistema.Name = "loginSistema";
            this.loginSistema.Size = new System.Drawing.Size(216, 28);
            this.loginSistema.Text = "Login";
            this.loginSistema.Click += new System.EventHandler(this.LoginSistema_Click);
            // 
            // logoutSistema
            // 
            this.logoutSistema.Name = "logoutSistema";
            this.logoutSistema.Size = new System.Drawing.Size(216, 28);
            this.logoutSistema.Text = "Logout";
            this.logoutSistema.Click += new System.EventHandler(this.LogoutSistema_Click);
            // 
            // administrarUsuarios
            // 
            this.administrarUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarUsuario,
            this.modificarUsiario,
            this.eliminarUsuario});
            this.administrarUsuarios.Name = "administrarUsuarios";
            this.administrarUsuarios.Size = new System.Drawing.Size(203, 27);
            this.administrarUsuarios.Text = "Administrar Usuarios";
            // 
            // registrarUsuario
            // 
            this.registrarUsuario.Name = "registrarUsuario";
            this.registrarUsuario.Size = new System.Drawing.Size(239, 28);
            this.registrarUsuario.Text = "Registrar Usuario";
            this.registrarUsuario.Click += new System.EventHandler(this.RegistrarUsuario_Click);
            // 
            // modificarUsiario
            // 
            this.modificarUsiario.Name = "modificarUsiario";
            this.modificarUsiario.Size = new System.Drawing.Size(239, 28);
            this.modificarUsiario.Text = "Modificar Usiario";
            this.modificarUsiario.Click += new System.EventHandler(this.ModificarUsiario_Click);
            // 
            // eliminarUsuario
            // 
            this.eliminarUsuario.Name = "eliminarUsuario";
            this.eliminarUsuario.Size = new System.Drawing.Size(239, 28);
            this.eliminarUsuario.Text = "Eliminar Usuario";
            this.eliminarUsuario.Click += new System.EventHandler(this.EliminarUsuario_Click);
            // 
            // reportesEventos
            // 
            this.reportesEventos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verLogDeEventos});
            this.reportesEventos.Name = "reportesEventos";
            this.reportesEventos.Size = new System.Drawing.Size(103, 27);
            this.reportesEventos.Text = "Reportes";
            // 
            // verLogDeEventos
            // 
            this.verLogDeEventos.Name = "verLogDeEventos";
            this.verLogDeEventos.Size = new System.Drawing.Size(259, 28);
            this.verLogDeEventos.Text = "Ver Log de Eventos";
            this.verLogDeEventos.Click += new System.EventHandler(this.VerLogDeEventos_Click);
            // 
            // menuStrip_Administracion
            // 
            this.menuStrip_Administracion.Font = new System.Drawing.Font("Arial", 12F);
            this.menuStrip_Administracion.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_Administracion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesion,
            this.administrarUsuarios,
            this.administrarBiometricos,
            this.reportesEventos,
            this.informaciónProgramador});
            this.menuStrip_Administracion.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Administracion.Name = "menuStrip_Administracion";
            this.menuStrip_Administracion.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip_Administracion.Size = new System.Drawing.Size(1924, 33);
            this.menuStrip_Administracion.TabIndex = 0;
            this.menuStrip_Administracion.Text = "menuStrip1";
            // 
            // administrarBiometricos
            // 
            this.administrarBiometricos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elegirSistemaDeAcceso});
            this.administrarBiometricos.Name = "administrarBiometricos";
            this.administrarBiometricos.Size = new System.Drawing.Size(230, 27);
            this.administrarBiometricos.Text = "Administrar Biometricos";
            // 
            // elegirSistemaDeAcceso
            // 
            this.elegirSistemaDeAcceso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarDeteccionFacial,
            this.activarHuellaDactilar,
            this.activarPINAcceso});
            this.elegirSistemaDeAcceso.Name = "elegirSistemaDeAcceso";
            this.elegirSistemaDeAcceso.Size = new System.Drawing.Size(314, 28);
            this.elegirSistemaDeAcceso.Text = "Elegir Sistema De Acceso";
            // 
            // activarDeteccionFacial
            // 
            this.activarDeteccionFacial.Name = "activarDeteccionFacial";
            this.activarDeteccionFacial.Size = new System.Drawing.Size(297, 28);
            this.activarDeteccionFacial.Text = "Activar Deteccion Facial";
            this.activarDeteccionFacial.Click += new System.EventHandler(this.ActivarDeteccionFacial_Click);
            // 
            // activarHuellaDactilar
            // 
            this.activarHuellaDactilar.Name = "activarHuellaDactilar";
            this.activarHuellaDactilar.Size = new System.Drawing.Size(297, 28);
            this.activarHuellaDactilar.Text = "Activar Huella Dactilar";
            this.activarHuellaDactilar.Click += new System.EventHandler(this.ActivarHuellaDactilar_Click);
            // 
            // activarPINAcceso
            // 
            this.activarPINAcceso.Name = "activarPINAcceso";
            this.activarPINAcceso.Size = new System.Drawing.Size(297, 28);
            this.activarPINAcceso.Text = "Activar PIN Acceso";
            this.activarPINAcceso.Click += new System.EventHandler(this.ActivarPINAcceso_Click);
            // 
            // informaciónProgramador
            // 
            this.informaciónProgramador.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDelProgramador});
            this.informaciónProgramador.Name = "informaciónProgramador";
            this.informaciónProgramador.Size = new System.Drawing.Size(124, 27);
            this.informaciónProgramador.Text = "Información";
            // 
            // acercaDelProgramador
            // 
            this.acercaDelProgramador.Name = "acercaDelProgramador";
            this.acercaDelProgramador.Size = new System.Drawing.Size(302, 28);
            this.acercaDelProgramador.Text = "Acerca del Programador";
            this.acercaDelProgramador.Click += new System.EventHandler(this.AcercaDelProgramador_Click);
            // 
            // groupBox_Facial
            // 
            this.groupBox_Facial.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Facial.Controls.Add(this.TabControl_Detalles);
            this.groupBox_Facial.Controls.Add(this.groupBox_Camara);
            this.groupBox_Facial.Controls.Add(this.groupBox_BuscarCamara);
            this.groupBox_Facial.Location = new System.Drawing.Point(22, 81);
            this.groupBox_Facial.Name = "groupBox_Facial";
            this.groupBox_Facial.Size = new System.Drawing.Size(473, 875);
            this.groupBox_Facial.TabIndex = 2;
            this.groupBox_Facial.TabStop = false;
            this.groupBox_Facial.Text = "Reconocimiento Facial";
            // 
            // TabControl_Detalles
            // 
            this.TabControl_Detalles.Controls.Add(this.tabPage1);
            this.TabControl_Detalles.Controls.Add(this.tabPage2);
            this.TabControl_Detalles.Controls.Add(this.tabPage3);
            this.TabControl_Detalles.Location = new System.Drawing.Point(7, 456);
            this.TabControl_Detalles.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl_Detalles.Name = "TabControl_Detalles";
            this.TabControl_Detalles.SelectedIndex = 0;
            this.TabControl_Detalles.Size = new System.Drawing.Size(456, 407);
            this.TabControl_Detalles.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.groupBox_Detalles);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(448, 371);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Transmisión";
            // 
            // groupBox_Detalles
            // 
            this.groupBox_Detalles.Controls.Add(this.groupBox_Video);
            this.groupBox_Detalles.Controls.Add(this.groupBox_DetallesCamara);
            this.groupBox_Detalles.Controls.Add(this.groupBox_Audio);
            this.groupBox_Detalles.Location = new System.Drawing.Point(8, 8);
            this.groupBox_Detalles.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Detalles.Name = "groupBox_Detalles";
            this.groupBox_Detalles.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Detalles.Size = new System.Drawing.Size(436, 355);
            this.groupBox_Detalles.TabIndex = 0;
            this.groupBox_Detalles.TabStop = false;
            this.groupBox_Detalles.Text = "Detalles";
            // 
            // groupBox_Video
            // 
            this.groupBox_Video.Controls.Add(this.txt_Video);
            this.groupBox_Video.Location = new System.Drawing.Point(219, 23);
            this.groupBox_Video.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Video.Name = "groupBox_Video";
            this.groupBox_Video.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Video.Size = new System.Drawing.Size(205, 166);
            this.groupBox_Video.TabIndex = 1;
            this.groupBox_Video.TabStop = false;
            this.groupBox_Video.Text = "Video";
            // 
            // txt_Video
            // 
            this.txt_Video.Location = new System.Drawing.Point(8, 23);
            this.txt_Video.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Video.Multiline = true;
            this.txt_Video.Name = "txt_Video";
            this.txt_Video.ReadOnly = true;
            this.txt_Video.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Video.Size = new System.Drawing.Size(189, 135);
            this.txt_Video.TabIndex = 0;
            // 
            // groupBox_DetallesCamara
            // 
            this.groupBox_DetallesCamara.Controls.Add(this.txt_DetallesCamara);
            this.groupBox_DetallesCamara.Location = new System.Drawing.Point(8, 197);
            this.groupBox_DetallesCamara.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_DetallesCamara.Name = "groupBox_DetallesCamara";
            this.groupBox_DetallesCamara.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_DetallesCamara.Size = new System.Drawing.Size(424, 150);
            this.groupBox_DetallesCamara.TabIndex = 2;
            this.groupBox_DetallesCamara.TabStop = false;
            this.groupBox_DetallesCamara.Text = "Detalles de la Camara";
            // 
            // txt_DetallesCamara
            // 
            this.txt_DetallesCamara.Location = new System.Drawing.Point(9, 25);
            this.txt_DetallesCamara.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DetallesCamara.Multiline = true;
            this.txt_DetallesCamara.Name = "txt_DetallesCamara";
            this.txt_DetallesCamara.ReadOnly = true;
            this.txt_DetallesCamara.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_DetallesCamara.Size = new System.Drawing.Size(407, 117);
            this.txt_DetallesCamara.TabIndex = 0;
            // 
            // groupBox_Audio
            // 
            this.groupBox_Audio.Controls.Add(this.txt_Audio);
            this.groupBox_Audio.Location = new System.Drawing.Point(8, 23);
            this.groupBox_Audio.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Audio.Name = "groupBox_Audio";
            this.groupBox_Audio.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Audio.Size = new System.Drawing.Size(203, 166);
            this.groupBox_Audio.TabIndex = 0;
            this.groupBox_Audio.TabStop = false;
            this.groupBox_Audio.Text = "Audio";
            // 
            // txt_Audio
            // 
            this.txt_Audio.Location = new System.Drawing.Point(8, 23);
            this.txt_Audio.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Audio.Multiline = true;
            this.txt_Audio.Name = "txt_Audio";
            this.txt_Audio.ReadOnly = true;
            this.txt_Audio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Audio.Size = new System.Drawing.Size(187, 135);
            this.txt_Audio.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.groupBox_Colores);
            this.tabPage2.Controls.Add(this.groupBox_LimpiarPantallas);
            this.tabPage2.Controls.Add(this.groupBox_Zoom);
            this.tabPage2.Controls.Add(this.groupBox_Orientacion);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(448, 371);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Propiedades";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox_Colores
            // 
            this.groupBox_Colores.Controls.Add(this.etiquetaCorreccionBrillo);
            this.groupBox_Colores.Controls.Add(this.etiquetaBrillo);
            this.groupBox_Colores.Controls.Add(this.etiquetaCorreccionGamma);
            this.groupBox_Colores.Controls.Add(this.etiquetaCorreccionContraste);
            this.groupBox_Colores.Controls.Add(this.etiquetaGamma);
            this.groupBox_Colores.Controls.Add(this.etiquetaCorreccionSaturacion);
            this.groupBox_Colores.Controls.Add(this.etiquetaContraste);
            this.groupBox_Colores.Controls.Add(this.scrollBar_Gamma);
            this.groupBox_Colores.Controls.Add(this.scrollBar_Brillo);
            this.groupBox_Colores.Controls.Add(this.etiquetaSaturacion);
            this.groupBox_Colores.Controls.Add(this.scrollBar_Saturacion);
            this.groupBox_Colores.Controls.Add(this.scrollBar_Contraste);
            this.groupBox_Colores.Location = new System.Drawing.Point(4, 113);
            this.groupBox_Colores.Name = "groupBox_Colores";
            this.groupBox_Colores.Size = new System.Drawing.Size(433, 251);
            this.groupBox_Colores.TabIndex = 9;
            this.groupBox_Colores.TabStop = false;
            this.groupBox_Colores.Text = "Manipulación Color Imagen";
            // 
            // etiquetaCorreccionBrillo
            // 
            this.etiquetaCorreccionBrillo.AutoSize = true;
            this.etiquetaCorreccionBrillo.Location = new System.Drawing.Point(5, 210);
            this.etiquetaCorreccionBrillo.Name = "etiquetaCorreccionBrillo";
            this.etiquetaCorreccionBrillo.Size = new System.Drawing.Size(154, 23);
            this.etiquetaCorreccionBrillo.TabIndex = 9;
            this.etiquetaCorreccionBrillo.Text = "Corrección Brillo";
            // 
            // etiquetaBrillo
            // 
            this.etiquetaBrillo.AutoSize = true;
            this.etiquetaBrillo.Location = new System.Drawing.Point(230, 210);
            this.etiquetaBrillo.Name = "etiquetaBrillo";
            this.etiquetaBrillo.Size = new System.Drawing.Size(21, 23);
            this.etiquetaBrillo.TabIndex = 29;
            this.etiquetaBrillo.Text = "1";
            // 
            // etiquetaCorreccionGamma
            // 
            this.etiquetaCorreccionGamma.AutoSize = true;
            this.etiquetaCorreccionGamma.Location = new System.Drawing.Point(1, 156);
            this.etiquetaCorreccionGamma.Name = "etiquetaCorreccionGamma";
            this.etiquetaCorreccionGamma.Size = new System.Drawing.Size(181, 23);
            this.etiquetaCorreccionGamma.TabIndex = 8;
            this.etiquetaCorreccionGamma.Text = "Corrección Gamma";
            // 
            // etiquetaCorreccionContraste
            // 
            this.etiquetaCorreccionContraste.AutoSize = true;
            this.etiquetaCorreccionContraste.Location = new System.Drawing.Point(4, 101);
            this.etiquetaCorreccionContraste.Name = "etiquetaCorreccionContraste";
            this.etiquetaCorreccionContraste.Size = new System.Drawing.Size(197, 23);
            this.etiquetaCorreccionContraste.TabIndex = 7;
            this.etiquetaCorreccionContraste.Text = "Corrección Contraste";
            // 
            // etiquetaGamma
            // 
            this.etiquetaGamma.AutoSize = true;
            this.etiquetaGamma.Location = new System.Drawing.Point(230, 156);
            this.etiquetaGamma.Name = "etiquetaGamma";
            this.etiquetaGamma.Size = new System.Drawing.Size(21, 23);
            this.etiquetaGamma.TabIndex = 28;
            this.etiquetaGamma.Text = "1";
            // 
            // etiquetaCorreccionSaturacion
            // 
            this.etiquetaCorreccionSaturacion.AutoSize = true;
            this.etiquetaCorreccionSaturacion.Location = new System.Drawing.Point(5, 47);
            this.etiquetaCorreccionSaturacion.Name = "etiquetaCorreccionSaturacion";
            this.etiquetaCorreccionSaturacion.Size = new System.Drawing.Size(204, 23);
            this.etiquetaCorreccionSaturacion.TabIndex = 6;
            this.etiquetaCorreccionSaturacion.Text = "Correccion Saturación";
            // 
            // etiquetaContraste
            // 
            this.etiquetaContraste.AutoSize = true;
            this.etiquetaContraste.Location = new System.Drawing.Point(233, 101);
            this.etiquetaContraste.Name = "etiquetaContraste";
            this.etiquetaContraste.Size = new System.Drawing.Size(21, 23);
            this.etiquetaContraste.TabIndex = 27;
            this.etiquetaContraste.Text = "1";
            // 
            // scrollBar_Gamma
            // 
            this.scrollBar_Gamma.LargeChange = 1;
            this.scrollBar_Gamma.Location = new System.Drawing.Point(276, 158);
            this.scrollBar_Gamma.Maximum = 200;
            this.scrollBar_Gamma.Minimum = 1;
            this.scrollBar_Gamma.Name = "scrollBar_Gamma";
            this.scrollBar_Gamma.Size = new System.Drawing.Size(149, 21);
            this.scrollBar_Gamma.TabIndex = 24;
            this.scrollBar_Gamma.Value = 1;
            this.scrollBar_Gamma.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Color_Scroll);
            // 
            // scrollBar_Brillo
            // 
            this.scrollBar_Brillo.LargeChange = 1;
            this.scrollBar_Brillo.Location = new System.Drawing.Point(280, 212);
            this.scrollBar_Brillo.Maximum = 200;
            this.scrollBar_Brillo.Minimum = 1;
            this.scrollBar_Brillo.Name = "scrollBar_Brillo";
            this.scrollBar_Brillo.Size = new System.Drawing.Size(145, 21);
            this.scrollBar_Brillo.TabIndex = 10;
            this.scrollBar_Brillo.Value = 1;
            this.scrollBar_Brillo.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Color_Scroll);
            // 
            // etiquetaSaturacion
            // 
            this.etiquetaSaturacion.AutoSize = true;
            this.etiquetaSaturacion.Location = new System.Drawing.Point(234, 47);
            this.etiquetaSaturacion.Name = "etiquetaSaturacion";
            this.etiquetaSaturacion.Size = new System.Drawing.Size(21, 23);
            this.etiquetaSaturacion.TabIndex = 26;
            this.etiquetaSaturacion.Text = "1";
            // 
            // scrollBar_Saturacion
            // 
            this.scrollBar_Saturacion.LargeChange = 1;
            this.scrollBar_Saturacion.Location = new System.Drawing.Point(280, 49);
            this.scrollBar_Saturacion.Maximum = 200;
            this.scrollBar_Saturacion.Minimum = 1;
            this.scrollBar_Saturacion.Name = "scrollBar_Saturacion";
            this.scrollBar_Saturacion.Size = new System.Drawing.Size(145, 21);
            this.scrollBar_Saturacion.TabIndex = 22;
            this.scrollBar_Saturacion.Value = 1;
            this.scrollBar_Saturacion.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Color_Scroll);
            // 
            // scrollBar_Contraste
            // 
            this.scrollBar_Contraste.LargeChange = 1;
            this.scrollBar_Contraste.Location = new System.Drawing.Point(279, 103);
            this.scrollBar_Contraste.Maximum = 200;
            this.scrollBar_Contraste.Minimum = 1;
            this.scrollBar_Contraste.Name = "scrollBar_Contraste";
            this.scrollBar_Contraste.Size = new System.Drawing.Size(146, 21);
            this.scrollBar_Contraste.TabIndex = 23;
            this.scrollBar_Contraste.Value = 1;
            this.scrollBar_Contraste.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Color_Scroll);
            // 
            // groupBox_LimpiarPantallas
            // 
            this.groupBox_LimpiarPantallas.Controls.Add(this.boton_LimpiarSala);
            this.groupBox_LimpiarPantallas.Location = new System.Drawing.Point(256, 8);
            this.groupBox_LimpiarPantallas.Name = "groupBox_LimpiarPantallas";
            this.groupBox_LimpiarPantallas.Size = new System.Drawing.Size(181, 99);
            this.groupBox_LimpiarPantallas.TabIndex = 8;
            this.groupBox_LimpiarPantallas.TabStop = false;
            this.groupBox_LimpiarPantallas.Text = "Limpiar Pantallas";
            // 
            // boton_LimpiarSala
            // 
            this.boton_LimpiarSala.Location = new System.Drawing.Point(6, 29);
            this.boton_LimpiarSala.Name = "boton_LimpiarSala";
            this.boton_LimpiarSala.Size = new System.Drawing.Size(167, 63);
            this.boton_LimpiarSala.TabIndex = 9;
            this.boton_LimpiarSala.Text = "Limpiar Pantalla";
            this.boton_LimpiarSala.UseVisualStyleBackColor = true;
            this.boton_LimpiarSala.Click += new System.EventHandler(this.Boton_LimpiarSala1_Click);
            // 
            // groupBox_Zoom
            // 
            this.groupBox_Zoom.Controls.Add(this.boton_DisminuirZoom);
            this.groupBox_Zoom.Controls.Add(this.boton_AumentarZoom);
            this.groupBox_Zoom.Location = new System.Drawing.Point(143, 8);
            this.groupBox_Zoom.Name = "groupBox_Zoom";
            this.groupBox_Zoom.Size = new System.Drawing.Size(107, 99);
            this.groupBox_Zoom.TabIndex = 7;
            this.groupBox_Zoom.TabStop = false;
            this.groupBox_Zoom.Text = "Zoom";
            // 
            // boton_DisminuirZoom
            // 
            this.boton_DisminuirZoom.Location = new System.Drawing.Point(6, 66);
            this.boton_DisminuirZoom.Name = "boton_DisminuirZoom";
            this.boton_DisminuirZoom.Size = new System.Drawing.Size(89, 29);
            this.boton_DisminuirZoom.TabIndex = 9;
            this.boton_DisminuirZoom.Text = "- Zoom";
            this.boton_DisminuirZoom.UseVisualStyleBackColor = true;
            this.boton_DisminuirZoom.Click += new System.EventHandler(this.Boton_DisminuirZoom_Click);
            // 
            // boton_AumentarZoom
            // 
            this.boton_AumentarZoom.Location = new System.Drawing.Point(6, 29);
            this.boton_AumentarZoom.Name = "boton_AumentarZoom";
            this.boton_AumentarZoom.Size = new System.Drawing.Size(89, 29);
            this.boton_AumentarZoom.TabIndex = 8;
            this.boton_AumentarZoom.Text = "+ Zoom";
            this.boton_AumentarZoom.UseVisualStyleBackColor = true;
            this.boton_AumentarZoom.Click += new System.EventHandler(this.Boton_AumentarZoom_Click);
            // 
            // groupBox_Orientacion
            // 
            this.groupBox_Orientacion.Controls.Add(this.checkBox_Vertical);
            this.groupBox_Orientacion.Controls.Add(this.checkBox_Horizontal);
            this.groupBox_Orientacion.Location = new System.Drawing.Point(5, 7);
            this.groupBox_Orientacion.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Orientacion.Name = "groupBox_Orientacion";
            this.groupBox_Orientacion.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Orientacion.Size = new System.Drawing.Size(131, 99);
            this.groupBox_Orientacion.TabIndex = 6;
            this.groupBox_Orientacion.TabStop = false;
            this.groupBox_Orientacion.Text = "Orientacion";
            // 
            // checkBox_Vertical
            // 
            this.checkBox_Vertical.AutoSize = true;
            this.checkBox_Vertical.Location = new System.Drawing.Point(8, 66);
            this.checkBox_Vertical.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Vertical.Name = "checkBox_Vertical";
            this.checkBox_Vertical.Size = new System.Drawing.Size(97, 27);
            this.checkBox_Vertical.TabIndex = 12;
            this.checkBox_Vertical.Text = "Vertical";
            this.checkBox_Vertical.UseVisualStyleBackColor = true;
            this.checkBox_Vertical.CheckedChanged += new System.EventHandler(this.OrientarImagen);
            // 
            // checkBox_Horizontal
            // 
            this.checkBox_Horizontal.AutoSize = true;
            this.checkBox_Horizontal.Location = new System.Drawing.Point(8, 31);
            this.checkBox_Horizontal.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Horizontal.Name = "checkBox_Horizontal";
            this.checkBox_Horizontal.Size = new System.Drawing.Size(118, 27);
            this.checkBox_Horizontal.TabIndex = 11;
            this.checkBox_Horizontal.Text = "Horizontal";
            this.checkBox_Horizontal.UseVisualStyleBackColor = true;
            this.checkBox_Horizontal.CheckedChanged += new System.EventHandler(this.OrientarImagen);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage3.BackgroundImage")));
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.groupBox_ReconocimientoSala);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(448, 371);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Control de Vigilancia";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox_ReconocimientoSala
            // 
            this.groupBox_ReconocimientoSala.Controls.Add(this.etiquetaRespuesta1);
            this.groupBox_ReconocimientoSala.Controls.Add(this.etiquetaPersonaEnCuadro);
            this.groupBox_ReconocimientoSala.Controls.Add(this.etiquetaNombre);
            this.groupBox_ReconocimientoSala.Controls.Add(this.etiquetaRostros);
            this.groupBox_ReconocimientoSala.Controls.Add(this.etiquetaCantidadRostrosDetectados);
            this.groupBox_ReconocimientoSala.Controls.Add(this.boton_DeshabilitarReconocimiento);
            this.groupBox_ReconocimientoSala.Controls.Add(this.boton_HabilitarReconocimiento);
            this.groupBox_ReconocimientoSala.Controls.Add(this.reconocimientoSala);
            this.groupBox_ReconocimientoSala.Location = new System.Drawing.Point(7, 7);
            this.groupBox_ReconocimientoSala.Name = "groupBox_ReconocimientoSala";
            this.groupBox_ReconocimientoSala.Size = new System.Drawing.Size(434, 357);
            this.groupBox_ReconocimientoSala.TabIndex = 0;
            this.groupBox_ReconocimientoSala.TabStop = false;
            this.groupBox_ReconocimientoSala.Text = "Reconocimiento Salas De Redes";
            // 
            // etiquetaRespuesta1
            // 
            this.etiquetaRespuesta1.AutoSize = true;
            this.etiquetaRespuesta1.Location = new System.Drawing.Point(8, 331);
            this.etiquetaRespuesta1.Name = "etiquetaRespuesta1";
            this.etiquetaRespuesta1.Size = new System.Drawing.Size(104, 23);
            this.etiquetaRespuesta1.TabIndex = 42;
            this.etiquetaRespuesta1.Text = "Respuesta";
            // 
            // etiquetaPersonaEnCuadro
            // 
            this.etiquetaPersonaEnCuadro.AutoSize = true;
            this.etiquetaPersonaEnCuadro.Location = new System.Drawing.Point(109, 303);
            this.etiquetaPersonaEnCuadro.Name = "etiquetaPersonaEnCuadro";
            this.etiquetaPersonaEnCuadro.Size = new System.Drawing.Size(0, 23);
            this.etiquetaPersonaEnCuadro.TabIndex = 9;
            // 
            // etiquetaNombre
            // 
            this.etiquetaNombre.AutoSize = true;
            this.etiquetaNombre.Location = new System.Drawing.Point(8, 303);
            this.etiquetaNombre.Name = "etiquetaNombre";
            this.etiquetaNombre.Size = new System.Drawing.Size(95, 23);
            this.etiquetaNombre.TabIndex = 8;
            this.etiquetaNombre.Text = "Nombres:";
            // 
            // etiquetaRostros
            // 
            this.etiquetaRostros.AutoSize = true;
            this.etiquetaRostros.Location = new System.Drawing.Point(6, 280);
            this.etiquetaRostros.Name = "etiquetaRostros";
            this.etiquetaRostros.Size = new System.Drawing.Size(159, 23);
            this.etiquetaRostros.TabIndex = 7;
            this.etiquetaRostros.Text = "Numero Rostros:";
            // 
            // etiquetaCantidadRostrosDetectados
            // 
            this.etiquetaCantidadRostrosDetectados.AutoSize = true;
            this.etiquetaCantidadRostrosDetectados.Location = new System.Drawing.Point(171, 280);
            this.etiquetaCantidadRostrosDetectados.Name = "etiquetaCantidadRostrosDetectados";
            this.etiquetaCantidadRostrosDetectados.Size = new System.Drawing.Size(0, 23);
            this.etiquetaCantidadRostrosDetectados.TabIndex = 6;
            // 
            // boton_DeshabilitarReconocimiento
            // 
            this.boton_DeshabilitarReconocimiento.Location = new System.Drawing.Point(229, 245);
            this.boton_DeshabilitarReconocimiento.Name = "boton_DeshabilitarReconocimiento";
            this.boton_DeshabilitarReconocimiento.Size = new System.Drawing.Size(198, 32);
            this.boton_DeshabilitarReconocimiento.TabIndex = 0;
            this.boton_DeshabilitarReconocimiento.Text = "Deshabilitar";
            this.boton_DeshabilitarReconocimiento.UseVisualStyleBackColor = true;
            this.boton_DeshabilitarReconocimiento.Click += new System.EventHandler(this.Boton_DeshabilitarReconocimiento_Click);
            // 
            // boton_HabilitarReconocimiento
            // 
            this.boton_HabilitarReconocimiento.Location = new System.Drawing.Point(8, 245);
            this.boton_HabilitarReconocimiento.Name = "boton_HabilitarReconocimiento";
            this.boton_HabilitarReconocimiento.Size = new System.Drawing.Size(198, 32);
            this.boton_HabilitarReconocimiento.TabIndex = 6;
            this.boton_HabilitarReconocimiento.Text = "Habilitar";
            this.boton_HabilitarReconocimiento.UseVisualStyleBackColor = true;
            this.boton_HabilitarReconocimiento.Click += new System.EventHandler(this.Boton_HabilitarReconocimiento_Click);
            // 
            // reconocimientoSala
            // 
            this.reconocimientoSala.BackColor = System.Drawing.Color.Black;
            this.reconocimientoSala.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reconocimientoSala.Enabled = false;
            this.reconocimientoSala.Location = new System.Drawing.Point(8, 23);
            this.reconocimientoSala.Margin = new System.Windows.Forms.Padding(4);
            this.reconocimientoSala.Name = "reconocimientoSala";
            this.reconocimientoSala.Size = new System.Drawing.Size(419, 215);
            this.reconocimientoSala.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reconocimientoSala.TabIndex = 5;
            this.reconocimientoSala.TabStop = false;
            // 
            // groupBox_Camara
            // 
            this.groupBox_Camara.Controls.Add(this.videoSala);
            this.groupBox_Camara.Controls.Add(this.boton_FinalizarVideo);
            this.groupBox_Camara.Controls.Add(this.boton_CapturarImagen);
            this.groupBox_Camara.Controls.Add(this.boton_Guardar);
            this.groupBox_Camara.Controls.Add(this.boton_IniciarVideo);
            this.groupBox_Camara.Controls.Add(this.txt_Guardar);
            this.groupBox_Camara.Location = new System.Drawing.Point(7, 124);
            this.groupBox_Camara.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Camara.Name = "groupBox_Camara";
            this.groupBox_Camara.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Camara.Size = new System.Drawing.Size(456, 324);
            this.groupBox_Camara.TabIndex = 1;
            this.groupBox_Camara.TabStop = false;
            this.groupBox_Camara.Text = "Sala De Redes";
            // 
            // videoSala
            // 
            this.videoSala.BackColor = System.Drawing.Color.Black;
            this.videoSala.ContextMenuEnabled = true;
            this.videoSala.FlipMode = Ozeki.Media.FlipMode.None;
            this.videoSala.FrameStretch = Ozeki.Media.FrameStretch.Uniform;
            this.videoSala.FullScreenEnabled = true;
            this.videoSala.Location = new System.Drawing.Point(8, 23);
            this.videoSala.Margin = new System.Windows.Forms.Padding(4);
            this.videoSala.Name = "videoSala";
            this.videoSala.RotateAngle = 0;
            this.videoSala.Size = new System.Drawing.Size(440, 215);
            this.videoSala.TabIndex = 0;
            // 
            // boton_FinalizarVideo
            // 
            this.boton_FinalizarVideo.Location = new System.Drawing.Point(308, 246);
            this.boton_FinalizarVideo.Margin = new System.Windows.Forms.Padding(4);
            this.boton_FinalizarVideo.Name = "boton_FinalizarVideo";
            this.boton_FinalizarVideo.Size = new System.Drawing.Size(140, 32);
            this.boton_FinalizarVideo.TabIndex = 3;
            this.boton_FinalizarVideo.Text = "Finalizar";
            this.boton_FinalizarVideo.UseVisualStyleBackColor = true;
            this.boton_FinalizarVideo.Click += new System.EventHandler(this.Boton_FinalizarVideo_Click);
            // 
            // boton_CapturarImagen
            // 
            this.boton_CapturarImagen.Location = new System.Drawing.Point(8, 246);
            this.boton_CapturarImagen.Margin = new System.Windows.Forms.Padding(4);
            this.boton_CapturarImagen.Name = "boton_CapturarImagen";
            this.boton_CapturarImagen.Size = new System.Drawing.Size(140, 32);
            this.boton_CapturarImagen.TabIndex = 1;
            this.boton_CapturarImagen.Text = "Snapshot";
            this.boton_CapturarImagen.UseVisualStyleBackColor = true;
            this.boton_CapturarImagen.Click += new System.EventHandler(this.Boton_CapturarImagen_Click);
            // 
            // boton_Guardar
            // 
            this.boton_Guardar.Location = new System.Drawing.Point(9, 288);
            this.boton_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Guardar.Name = "boton_Guardar";
            this.boton_Guardar.Size = new System.Drawing.Size(125, 28);
            this.boton_Guardar.TabIndex = 4;
            this.boton_Guardar.Text = "Guardar en:";
            this.boton_Guardar.UseVisualStyleBackColor = true;
            this.boton_Guardar.Click += new System.EventHandler(this.Boton_Guardar_Click);
            // 
            // boton_IniciarVideo
            // 
            this.boton_IniciarVideo.Location = new System.Drawing.Point(158, 246);
            this.boton_IniciarVideo.Margin = new System.Windows.Forms.Padding(4);
            this.boton_IniciarVideo.Name = "boton_IniciarVideo";
            this.boton_IniciarVideo.Size = new System.Drawing.Size(140, 32);
            this.boton_IniciarVideo.TabIndex = 2;
            this.boton_IniciarVideo.Text = "Iniciar";
            this.boton_IniciarVideo.UseVisualStyleBackColor = true;
            this.boton_IniciarVideo.Click += new System.EventHandler(this.Boton_IniciarVideo_Click);
            // 
            // txt_Guardar
            // 
            this.txt_Guardar.Location = new System.Drawing.Point(137, 288);
            this.txt_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Guardar.Name = "txt_Guardar";
            this.txt_Guardar.ReadOnly = true;
            this.txt_Guardar.Size = new System.Drawing.Size(311, 30);
            this.txt_Guardar.TabIndex = 5;
            // 
            // groupBox_BuscarCamara
            // 
            this.groupBox_BuscarCamara.Controls.Add(this.boton_Conectar);
            this.groupBox_BuscarCamara.Controls.Add(this.boton_Desconectar);
            this.groupBox_BuscarCamara.Controls.Add(this.etiquetaURL);
            this.groupBox_BuscarCamara.Controls.Add(this.txt_CamaraURL);
            this.groupBox_BuscarCamara.Controls.Add(this.boton_Buscar);
            this.groupBox_BuscarCamara.Location = new System.Drawing.Point(7, 25);
            this.groupBox_BuscarCamara.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_BuscarCamara.Name = "groupBox_BuscarCamara";
            this.groupBox_BuscarCamara.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_BuscarCamara.Size = new System.Drawing.Size(456, 91);
            this.groupBox_BuscarCamara.TabIndex = 0;
            this.groupBox_BuscarCamara.TabStop = false;
            this.groupBox_BuscarCamara.Text = "Buscar Camara";
            // 
            // boton_Conectar
            // 
            this.boton_Conectar.BackColor = System.Drawing.Color.Transparent;
            this.boton_Conectar.ForeColor = System.Drawing.Color.Black;
            this.boton_Conectar.Location = new System.Drawing.Point(158, 53);
            this.boton_Conectar.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Conectar.Name = "boton_Conectar";
            this.boton_Conectar.Size = new System.Drawing.Size(140, 28);
            this.boton_Conectar.TabIndex = 5;
            this.boton_Conectar.Text = "Conectar";
            this.boton_Conectar.UseVisualStyleBackColor = false;
            this.boton_Conectar.Click += new System.EventHandler(this.Boton_Conectar_Click);
            // 
            // boton_Desconectar
            // 
            this.boton_Desconectar.Location = new System.Drawing.Point(308, 53);
            this.boton_Desconectar.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Desconectar.Name = "boton_Desconectar";
            this.boton_Desconectar.Size = new System.Drawing.Size(140, 28);
            this.boton_Desconectar.TabIndex = 6;
            this.boton_Desconectar.Text = "Desconectar";
            this.boton_Desconectar.UseVisualStyleBackColor = true;
            this.boton_Desconectar.Click += new System.EventHandler(this.Boton_Desconectar_Click);
            // 
            // etiquetaURL
            // 
            this.etiquetaURL.AutoSize = true;
            this.etiquetaURL.Location = new System.Drawing.Point(11, 22);
            this.etiquetaURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.etiquetaURL.Name = "etiquetaURL";
            this.etiquetaURL.Size = new System.Drawing.Size(130, 23);
            this.etiquetaURL.TabIndex = 0;
            this.etiquetaURL.Text = "Camara URL:";
            // 
            // txt_CamaraURL
            // 
            this.txt_CamaraURL.Location = new System.Drawing.Point(149, 15);
            this.txt_CamaraURL.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CamaraURL.Name = "txt_CamaraURL";
            this.txt_CamaraURL.ReadOnly = true;
            this.txt_CamaraURL.Size = new System.Drawing.Size(299, 30);
            this.txt_CamaraURL.TabIndex = 2;
            // 
            // boton_Buscar
            // 
            this.boton_Buscar.BackColor = System.Drawing.Color.Transparent;
            this.boton_Buscar.Location = new System.Drawing.Point(8, 53);
            this.boton_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Buscar.Name = "boton_Buscar";
            this.boton_Buscar.Size = new System.Drawing.Size(140, 28);
            this.boton_Buscar.TabIndex = 4;
            this.boton_Buscar.Text = "Buscar";
            this.boton_Buscar.UseVisualStyleBackColor = false;
            this.boton_Buscar.Click += new System.EventHandler(this.Boton_Buscar_Click);
            // 
            // groupBox_Logs
            // 
            this.groupBox_Logs.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Logs.Controls.Add(this.listBox_Logs);
            this.groupBox_Logs.Location = new System.Drawing.Point(955, 81);
            this.groupBox_Logs.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Logs.Name = "groupBox_Logs";
            this.groupBox_Logs.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Logs.Size = new System.Drawing.Size(956, 875);
            this.groupBox_Logs.TabIndex = 5;
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
            this.listBox_Logs.Size = new System.Drawing.Size(939, 832);
            this.listBox_Logs.TabIndex = 0;
            // 
            // timer_Deteccion
            // 
            this.timer_Deteccion.Tick += new System.EventHandler(this.Timer_Deteccion_Tick);
            // 
            // timer_Ubicacion
            // 
            this.timer_Ubicacion.Tick += new System.EventHandler(this.Timer_Ubicacion_Tick);
            // 
            // groupBox_Pin
            // 
            this.groupBox_Pin.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Pin.Controls.Add(this.groupBox_Teclado);
            this.groupBox_Pin.Controls.Add(this.groupBox_BuscarTeclado);
            this.groupBox_Pin.Location = new System.Drawing.Point(501, 81);
            this.groupBox_Pin.Name = "groupBox_Pin";
            this.groupBox_Pin.Size = new System.Drawing.Size(447, 250);
            this.groupBox_Pin.TabIndex = 3;
            this.groupBox_Pin.TabStop = false;
            this.groupBox_Pin.Text = "PIN De Acceso";
            // 
            // groupBox_Teclado
            // 
            this.groupBox_Teclado.Controls.Add(this.etiquetaRespuesta2);
            this.groupBox_Teclado.Controls.Add(this.etiquetaPin);
            this.groupBox_Teclado.Controls.Add(this.txt_Acceso);
            this.groupBox_Teclado.Location = new System.Drawing.Point(7, 123);
            this.groupBox_Teclado.Name = "groupBox_Teclado";
            this.groupBox_Teclado.Size = new System.Drawing.Size(431, 118);
            this.groupBox_Teclado.TabIndex = 1;
            this.groupBox_Teclado.TabStop = false;
            this.groupBox_Teclado.Text = "Salas De Redes";
            // 
            // etiquetaRespuesta2
            // 
            this.etiquetaRespuesta2.AutoSize = true;
            this.etiquetaRespuesta2.Location = new System.Drawing.Point(6, 85);
            this.etiquetaRespuesta2.Name = "etiquetaRespuesta2";
            this.etiquetaRespuesta2.Size = new System.Drawing.Size(104, 23);
            this.etiquetaRespuesta2.TabIndex = 0;
            this.etiquetaRespuesta2.Text = "Respuesta";
            // 
            // etiquetaPin
            // 
            this.etiquetaPin.AutoSize = true;
            this.etiquetaPin.Location = new System.Drawing.Point(6, 26);
            this.etiquetaPin.Name = "etiquetaPin";
            this.etiquetaPin.Size = new System.Drawing.Size(149, 23);
            this.etiquetaPin.TabIndex = 0;
            this.etiquetaPin.Text = "PIN De Acceso:";
            // 
            // txt_Acceso
            // 
            this.txt_Acceso.Location = new System.Drawing.Point(6, 52);
            this.txt_Acceso.Name = "txt_Acceso";
            this.txt_Acceso.PasswordChar = '*';
            this.txt_Acceso.Size = new System.Drawing.Size(417, 30);
            this.txt_Acceso.TabIndex = 1;
            this.txt_Acceso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Acceso1_KeyPress);
            // 
            // groupBox_BuscarTeclado
            // 
            this.groupBox_BuscarTeclado.Controls.Add(this.boton_ConectarTeclado);
            this.groupBox_BuscarTeclado.Controls.Add(this.boton_DesconectarTeclado);
            this.groupBox_BuscarTeclado.Controls.Add(this.etiquetaTeclado);
            this.groupBox_BuscarTeclado.Controls.Add(this.txt_NombreTeclado);
            this.groupBox_BuscarTeclado.Controls.Add(this.boton_BuscarTeclado);
            this.groupBox_BuscarTeclado.Location = new System.Drawing.Point(7, 25);
            this.groupBox_BuscarTeclado.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_BuscarTeclado.Name = "groupBox_BuscarTeclado";
            this.groupBox_BuscarTeclado.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_BuscarTeclado.Size = new System.Drawing.Size(431, 91);
            this.groupBox_BuscarTeclado.TabIndex = 0;
            this.groupBox_BuscarTeclado.TabStop = false;
            this.groupBox_BuscarTeclado.Text = "Buscar Teclados";
            // 
            // boton_ConectarTeclado
            // 
            this.boton_ConectarTeclado.BackColor = System.Drawing.Color.Transparent;
            this.boton_ConectarTeclado.ForeColor = System.Drawing.Color.Black;
            this.boton_ConectarTeclado.Location = new System.Drawing.Point(149, 53);
            this.boton_ConectarTeclado.Margin = new System.Windows.Forms.Padding(4);
            this.boton_ConectarTeclado.Name = "boton_ConectarTeclado";
            this.boton_ConectarTeclado.Size = new System.Drawing.Size(133, 28);
            this.boton_ConectarTeclado.TabIndex = 5;
            this.boton_ConectarTeclado.Text = "Conectar";
            this.boton_ConectarTeclado.UseVisualStyleBackColor = false;
            this.boton_ConectarTeclado.Click += new System.EventHandler(this.Boton_ConectarTeclado_Click);
            // 
            // boton_DesconectarTeclado
            // 
            this.boton_DesconectarTeclado.Location = new System.Drawing.Point(290, 53);
            this.boton_DesconectarTeclado.Margin = new System.Windows.Forms.Padding(4);
            this.boton_DesconectarTeclado.Name = "boton_DesconectarTeclado";
            this.boton_DesconectarTeclado.Size = new System.Drawing.Size(133, 28);
            this.boton_DesconectarTeclado.TabIndex = 6;
            this.boton_DesconectarTeclado.Text = "Desconectar";
            this.boton_DesconectarTeclado.UseVisualStyleBackColor = true;
            this.boton_DesconectarTeclado.Click += new System.EventHandler(this.Boton_DesconectarTeclado_Click);
            // 
            // etiquetaTeclado
            // 
            this.etiquetaTeclado.AutoSize = true;
            this.etiquetaTeclado.Location = new System.Drawing.Point(11, 22);
            this.etiquetaTeclado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.etiquetaTeclado.Name = "etiquetaTeclado";
            this.etiquetaTeclado.Size = new System.Drawing.Size(159, 23);
            this.etiquetaTeclado.TabIndex = 0;
            this.etiquetaTeclado.Text = "Teclado Nombre:";
            // 
            // txt_NombreTeclado
            // 
            this.txt_NombreTeclado.Location = new System.Drawing.Point(178, 15);
            this.txt_NombreTeclado.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NombreTeclado.Name = "txt_NombreTeclado";
            this.txt_NombreTeclado.ReadOnly = true;
            this.txt_NombreTeclado.Size = new System.Drawing.Size(245, 30);
            this.txt_NombreTeclado.TabIndex = 2;
            // 
            // boton_BuscarTeclado
            // 
            this.boton_BuscarTeclado.BackColor = System.Drawing.Color.Transparent;
            this.boton_BuscarTeclado.Location = new System.Drawing.Point(8, 53);
            this.boton_BuscarTeclado.Margin = new System.Windows.Forms.Padding(4);
            this.boton_BuscarTeclado.Name = "boton_BuscarTeclado";
            this.boton_BuscarTeclado.Size = new System.Drawing.Size(133, 30);
            this.boton_BuscarTeclado.TabIndex = 4;
            this.boton_BuscarTeclado.Text = "Buscar";
            this.boton_BuscarTeclado.UseVisualStyleBackColor = false;
            this.boton_BuscarTeclado.Click += new System.EventHandler(this.Boton_BuscarTeclado_Click);
            // 
            // groupBox_Huella
            // 
            this.groupBox_Huella.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Huella.Controls.Add(this.groupBox_Lector);
            this.groupBox_Huella.Controls.Add(this.groupBox_BuscarLectores);
            this.groupBox_Huella.Location = new System.Drawing.Point(501, 337);
            this.groupBox_Huella.Name = "groupBox_Huella";
            this.groupBox_Huella.Size = new System.Drawing.Size(447, 619);
            this.groupBox_Huella.TabIndex = 4;
            this.groupBox_Huella.TabStop = false;
            this.groupBox_Huella.Text = "Huella Dactilar";
            // 
            // groupBox_Lector
            // 
            this.groupBox_Lector.Controls.Add(this.pictureBox_Huella);
            this.groupBox_Lector.Controls.Add(this.etiquetaRespuesta3);
            this.groupBox_Lector.Location = new System.Drawing.Point(6, 126);
            this.groupBox_Lector.Name = "groupBox_Lector";
            this.groupBox_Lector.Size = new System.Drawing.Size(435, 481);
            this.groupBox_Lector.TabIndex = 3;
            this.groupBox_Lector.TabStop = false;
            this.groupBox_Lector.Text = "Salas De Redes";
            // 
            // pictureBox_Huella
            // 
            this.pictureBox_Huella.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Huella.Location = new System.Drawing.Point(6, 29);
            this.pictureBox_Huella.Name = "pictureBox_Huella";
            this.pictureBox_Huella.Size = new System.Drawing.Size(418, 410);
            this.pictureBox_Huella.TabIndex = 1;
            this.pictureBox_Huella.TabStop = false;
            // 
            // etiquetaRespuesta3
            // 
            this.etiquetaRespuesta3.AutoSize = true;
            this.etiquetaRespuesta3.Location = new System.Drawing.Point(6, 444);
            this.etiquetaRespuesta3.Name = "etiquetaRespuesta3";
            this.etiquetaRespuesta3.Size = new System.Drawing.Size(104, 23);
            this.etiquetaRespuesta3.TabIndex = 0;
            this.etiquetaRespuesta3.Text = "Respuesta";
            // 
            // groupBox_BuscarLectores
            // 
            this.groupBox_BuscarLectores.Controls.Add(this.boton_ConectarLector);
            this.groupBox_BuscarLectores.Controls.Add(this.boton_DesconectarLector);
            this.groupBox_BuscarLectores.Controls.Add(this.etiquetaLector);
            this.groupBox_BuscarLectores.Controls.Add(this.txt_NombreLector);
            this.groupBox_BuscarLectores.Controls.Add(this.boton_BuscarLector);
            this.groupBox_BuscarLectores.Location = new System.Drawing.Point(7, 30);
            this.groupBox_BuscarLectores.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_BuscarLectores.Name = "groupBox_BuscarLectores";
            this.groupBox_BuscarLectores.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_BuscarLectores.Size = new System.Drawing.Size(431, 89);
            this.groupBox_BuscarLectores.TabIndex = 1;
            this.groupBox_BuscarLectores.TabStop = false;
            this.groupBox_BuscarLectores.Text = "Buscar Teclados";
            // 
            // boton_ConectarLector
            // 
            this.boton_ConectarLector.BackColor = System.Drawing.Color.Transparent;
            this.boton_ConectarLector.ForeColor = System.Drawing.Color.Black;
            this.boton_ConectarLector.Location = new System.Drawing.Point(149, 53);
            this.boton_ConectarLector.Margin = new System.Windows.Forms.Padding(4);
            this.boton_ConectarLector.Name = "boton_ConectarLector";
            this.boton_ConectarLector.Size = new System.Drawing.Size(133, 28);
            this.boton_ConectarLector.TabIndex = 5;
            this.boton_ConectarLector.Text = "Conectar";
            this.boton_ConectarLector.UseVisualStyleBackColor = false;
            this.boton_ConectarLector.Click += new System.EventHandler(this.Boton_ConectarLector_Click);
            // 
            // boton_DesconectarLector
            // 
            this.boton_DesconectarLector.Location = new System.Drawing.Point(290, 53);
            this.boton_DesconectarLector.Margin = new System.Windows.Forms.Padding(4);
            this.boton_DesconectarLector.Name = "boton_DesconectarLector";
            this.boton_DesconectarLector.Size = new System.Drawing.Size(133, 28);
            this.boton_DesconectarLector.TabIndex = 6;
            this.boton_DesconectarLector.Text = "Desconectar";
            this.boton_DesconectarLector.UseVisualStyleBackColor = true;
            this.boton_DesconectarLector.Click += new System.EventHandler(this.Boton_DesconectarLector_Click);
            // 
            // etiquetaLector
            // 
            this.etiquetaLector.AutoSize = true;
            this.etiquetaLector.Location = new System.Drawing.Point(11, 22);
            this.etiquetaLector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.etiquetaLector.Name = "etiquetaLector";
            this.etiquetaLector.Size = new System.Drawing.Size(159, 23);
            this.etiquetaLector.TabIndex = 0;
            this.etiquetaLector.Text = "Teclado Nombre:";
            // 
            // txt_NombreLector
            // 
            this.txt_NombreLector.Location = new System.Drawing.Point(178, 15);
            this.txt_NombreLector.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NombreLector.Name = "txt_NombreLector";
            this.txt_NombreLector.ReadOnly = true;
            this.txt_NombreLector.Size = new System.Drawing.Size(245, 30);
            this.txt_NombreLector.TabIndex = 2;
            // 
            // boton_BuscarLector
            // 
            this.boton_BuscarLector.BackColor = System.Drawing.Color.Transparent;
            this.boton_BuscarLector.Location = new System.Drawing.Point(8, 53);
            this.boton_BuscarLector.Margin = new System.Windows.Forms.Padding(4);
            this.boton_BuscarLector.Name = "boton_BuscarLector";
            this.boton_BuscarLector.Size = new System.Drawing.Size(133, 28);
            this.boton_BuscarLector.TabIndex = 4;
            this.boton_BuscarLector.Text = "Buscar";
            this.boton_BuscarLector.UseVisualStyleBackColor = false;
            this.boton_BuscarLector.Click += new System.EventHandler(this.Boton_BuscarLector_Click);
            // 
            // timer_Reconocimiento
            // 
            this.timer_Reconocimiento.Interval = 1000;
            this.timer_Reconocimiento.Tick += new System.EventHandler(this.Timer_Reconocimiento_Tick);
            // 
            // Sistema_Seguridad_FIEE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.groupBox_Huella);
            this.Controls.Add(this.groupBox_Pin);
            this.Controls.Add(this.groupBox_Logs);
            this.Controls.Add(this.groupBox_Facial);
            this.Controls.Add(this.etiquetaBienvenida);
            this.Controls.Add(this.menuStrip_Administracion);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_Administracion;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Sistema_Seguridad_FIEE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Seguridad FIEE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sistema_Seguridad_FIEE_FormClosing);
            this.Load += new System.EventHandler(this.Sistema_Seguridad_FIEE_Load);
            this.menuStrip_Administracion.ResumeLayout(false);
            this.menuStrip_Administracion.PerformLayout();
            this.groupBox_Facial.ResumeLayout(false);
            this.TabControl_Detalles.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_Detalles.ResumeLayout(false);
            this.groupBox_Video.ResumeLayout(false);
            this.groupBox_Video.PerformLayout();
            this.groupBox_DetallesCamara.ResumeLayout(false);
            this.groupBox_DetallesCamara.PerformLayout();
            this.groupBox_Audio.ResumeLayout(false);
            this.groupBox_Audio.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox_Colores.ResumeLayout(false);
            this.groupBox_Colores.PerformLayout();
            this.groupBox_LimpiarPantallas.ResumeLayout(false);
            this.groupBox_Zoom.ResumeLayout(false);
            this.groupBox_Orientacion.ResumeLayout(false);
            this.groupBox_Orientacion.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox_ReconocimientoSala.ResumeLayout(false);
            this.groupBox_ReconocimientoSala.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconocimientoSala)).EndInit();
            this.groupBox_Camara.ResumeLayout(false);
            this.groupBox_Camara.PerformLayout();
            this.groupBox_BuscarCamara.ResumeLayout(false);
            this.groupBox_BuscarCamara.PerformLayout();
            this.groupBox_Logs.ResumeLayout(false);
            this.groupBox_Pin.ResumeLayout(false);
            this.groupBox_Teclado.ResumeLayout(false);
            this.groupBox_Teclado.PerformLayout();
            this.groupBox_BuscarTeclado.ResumeLayout(false);
            this.groupBox_BuscarTeclado.PerformLayout();
            this.groupBox_Huella.ResumeLayout(false);
            this.groupBox_Lector.ResumeLayout(false);
            this.groupBox_Lector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Huella)).EndInit();
            this.groupBox_BuscarLectores.ResumeLayout(false);
            this.groupBox_BuscarLectores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label etiquetaBienvenida;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem loginSistema;
        private System.Windows.Forms.ToolStripMenuItem logoutSistema;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuarios;
        private System.Windows.Forms.ToolStripMenuItem registrarUsuario;
        private System.Windows.Forms.ToolStripMenuItem modificarUsiario;
        private System.Windows.Forms.ToolStripMenuItem reportesEventos;
        private System.Windows.Forms.MenuStrip menuStrip_Administracion;
        private System.Windows.Forms.GroupBox groupBox_Facial;
        private System.Windows.Forms.Button boton_FinalizarVideo;
        private System.Windows.Forms.TextBox txt_Guardar;
        private System.Windows.Forms.Button boton_Guardar;
        private System.Windows.Forms.Button boton_IniciarVideo;
        private System.Windows.Forms.Button boton_CapturarImagen;
        private System.Windows.Forms.GroupBox groupBox_Camara;
        private Ozeki.Media.VideoViewerWF videoSala;
        private System.Windows.Forms.GroupBox groupBox_BuscarCamara;
        private System.Windows.Forms.Button boton_Conectar;
        private System.Windows.Forms.Button boton_Desconectar;
        private System.Windows.Forms.Label etiquetaURL;
        private System.Windows.Forms.TextBox txt_CamaraURL;
        private System.Windows.Forms.Button boton_Buscar;
        private System.Windows.Forms.GroupBox groupBox_Logs;
        private System.Windows.Forms.ListBox listBox_Logs;
        private System.Windows.Forms.FolderBrowserDialog buscadorArchivos;
        private System.Windows.Forms.Timer timer_Deteccion;
        private System.Windows.Forms.Timer timer_Ubicacion;
        private System.Windows.Forms.GroupBox groupBox_Pin;
        private System.Windows.Forms.GroupBox groupBox_BuscarTeclado;
        private System.Windows.Forms.Button boton_ConectarTeclado;
        private System.Windows.Forms.Button boton_DesconectarTeclado;
        private System.Windows.Forms.Label etiquetaTeclado;
        private System.Windows.Forms.TextBox txt_NombreTeclado;
        private System.Windows.Forms.Button boton_BuscarTeclado;
        private System.Windows.Forms.TextBox txt_Acceso;
        private System.Windows.Forms.GroupBox groupBox_Teclado;
        private System.Windows.Forms.Label etiquetaPin;
        private System.Windows.Forms.GroupBox groupBox_Huella;
        private System.Windows.Forms.Label etiquetaRespuesta2;
        private System.Windows.Forms.ToolStripMenuItem eliminarUsuario;
        private System.Windows.Forms.ToolStripMenuItem verLogDeEventos;
        private System.Windows.Forms.ToolStripMenuItem informaciónProgramador;
        private System.Windows.Forms.ToolStripMenuItem acercaDelProgramador;
        private System.Windows.Forms.ToolStripMenuItem administrarBiometricos;
        private System.Windows.Forms.ToolStripMenuItem elegirSistemaDeAcceso;
        private System.Windows.Forms.ToolStripMenuItem activarDeteccionFacial;
        private System.Windows.Forms.ToolStripMenuItem activarHuellaDactilar;
        private System.Windows.Forms.ToolStripMenuItem activarPINAcceso;
        private System.Windows.Forms.Timer timer_Reconocimiento;
        private System.Windows.Forms.GroupBox groupBox_BuscarLectores;
        private System.Windows.Forms.Button boton_ConectarLector;
        private System.Windows.Forms.Button boton_DesconectarLector;
        private System.Windows.Forms.Label etiquetaLector;
        private System.Windows.Forms.TextBox txt_NombreLector;
        private System.Windows.Forms.Button boton_BuscarLector;
        private System.Windows.Forms.GroupBox groupBox_Lector;
        private System.Windows.Forms.Label etiquetaRespuesta3;
        private System.Windows.Forms.PictureBox pictureBox_Huella;
        private System.Windows.Forms.TabControl TabControl_Detalles;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox_Detalles;
        private System.Windows.Forms.GroupBox groupBox_Video;
        private System.Windows.Forms.TextBox txt_Video;
        private System.Windows.Forms.GroupBox groupBox_DetallesCamara;
        private System.Windows.Forms.TextBox txt_DetallesCamara;
        private System.Windows.Forms.GroupBox groupBox_Audio;
        private System.Windows.Forms.TextBox txt_Audio;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox_Colores;
        private System.Windows.Forms.Label etiquetaCorreccionBrillo;
        private System.Windows.Forms.Label etiquetaBrillo;
        private System.Windows.Forms.Label etiquetaCorreccionGamma;
        private System.Windows.Forms.Label etiquetaCorreccionContraste;
        private System.Windows.Forms.Label etiquetaGamma;
        private System.Windows.Forms.Label etiquetaCorreccionSaturacion;
        private System.Windows.Forms.Label etiquetaContraste;
        private System.Windows.Forms.HScrollBar scrollBar_Gamma;
        private System.Windows.Forms.HScrollBar scrollBar_Brillo;
        private System.Windows.Forms.Label etiquetaSaturacion;
        private System.Windows.Forms.HScrollBar scrollBar_Saturacion;
        private System.Windows.Forms.HScrollBar scrollBar_Contraste;
        private System.Windows.Forms.GroupBox groupBox_LimpiarPantallas;
        private System.Windows.Forms.Button boton_LimpiarSala;
        private System.Windows.Forms.GroupBox groupBox_Zoom;
        private System.Windows.Forms.Button boton_DisminuirZoom;
        private System.Windows.Forms.Button boton_AumentarZoom;
        private System.Windows.Forms.GroupBox groupBox_Orientacion;
        private System.Windows.Forms.CheckBox checkBox_Vertical;
        private System.Windows.Forms.CheckBox checkBox_Horizontal;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox_ReconocimientoSala;
        private System.Windows.Forms.Label etiquetaRespuesta1;
        private System.Windows.Forms.Label etiquetaPersonaEnCuadro;
        private System.Windows.Forms.Label etiquetaNombre;
        private System.Windows.Forms.Label etiquetaRostros;
        private System.Windows.Forms.Label etiquetaCantidadRostrosDetectados;
        private System.Windows.Forms.Button boton_DeshabilitarReconocimiento;
        private System.Windows.Forms.Button boton_HabilitarReconocimiento;
        private Emgu.CV.UI.ImageBox reconocimientoSala;
    }
}