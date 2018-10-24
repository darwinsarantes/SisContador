namespace SisContador.Formularios
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTasaDeCambio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRespaldarBaseDeDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRestaurar = new System.Windows.Forms.ToolStripMenuItem();
            this.graficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónDeLaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDeLaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorPorDefectoEnLaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsbEtiqueta = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbEtiquetaDeRespaldo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbGruposDeCuentas = new System.Windows.Forms.ToolStripButton();
            this.tsbCategoriaDeCuenta = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTipoDeTransaccion = new System.Windows.Forms.ToolStripButton();
            this.tsbMovimientos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEgresos = new System.Windows.Forms.ToolStripButton();
            this.tsbIngresos = new System.Windows.Forms.ToolStripButton();
            this.tsbDiarios = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPeriodo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbHorayFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGeneral,
            this.tsmHerramientas,
            this.configuracionesToolStripMenuItem,
            this.tsmAyuda,
            this.ventanaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(825, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.TabStop = true;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsmGeneral
            // 
            this.tsmGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.tiposDeCuentasToolStripMenuItem,
            this.tsbTasaDeCambio});
            this.tsmGeneral.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.tsmGeneral.Name = "tsmGeneral";
            this.tsmGeneral.Size = new System.Drawing.Size(70, 20);
            this.tsmGeneral.Tag = "Generales";
            this.tsmGeneral.Text = "Generales";
            this.tsmGeneral.ToolTipText = "Opciones generales";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Image = global::SisContador.Properties.Resources.if_keys_60186;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.usuariosToolStripMenuItem.Tag = "Usuario";
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // tiposDeCuentasToolStripMenuItem
            // 
            this.tiposDeCuentasToolStripMenuItem.Image = global::SisContador.Properties.Resources.ajustes16x16;
            this.tiposDeCuentasToolStripMenuItem.Name = "tiposDeCuentasToolStripMenuItem";
            this.tiposDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.tiposDeCuentasToolStripMenuItem.Tag = "Rol";
            this.tiposDeCuentasToolStripMenuItem.Text = "Tipos de Cuentas";
            this.tiposDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.tiposDeCuentasToolStripMenuItem_Click);
            // 
            // tsbTasaDeCambio
            // 
            this.tsbTasaDeCambio.Name = "tsbTasaDeCambio";
            this.tsbTasaDeCambio.Size = new System.Drawing.Size(165, 22);
            this.tsbTasaDeCambio.Tag = "TasaDeCambio";
            this.tsbTasaDeCambio.Text = "Tasa de Cambio";
            this.tsbTasaDeCambio.Click += new System.EventHandler(this.tsbTasaDeCambio_Click);
            // 
            // tsmHerramientas
            // 
            this.tsmHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRespaldarBaseDeDatos,
            this.tsmRestaurar,
            this.graficosToolStripMenuItem});
            this.tsmHerramientas.Name = "tsmHerramientas";
            this.tsmHerramientas.Size = new System.Drawing.Size(90, 20);
            this.tsmHerramientas.Tag = "Herramientas";
            this.tsmHerramientas.Text = "&Herramientas";
            // 
            // tsmRespaldarBaseDeDatos
            // 
            this.tsmRespaldarBaseDeDatos.Image = global::SisContador.Properties.Resources.server_base_de_datos;
            this.tsmRespaldarBaseDeDatos.Name = "tsmRespaldarBaseDeDatos";
            this.tsmRespaldarBaseDeDatos.Size = new System.Drawing.Size(204, 26);
            this.tsmRespaldarBaseDeDatos.Tag = "Respaldar";
            this.tsmRespaldarBaseDeDatos.Text = "&Respaldar Base de datos";
            this.tsmRespaldarBaseDeDatos.ToolTipText = "Respaldar base de datos";
            this.tsmRespaldarBaseDeDatos.Click += new System.EventHandler(this.tsmRespaldarBaseDeDatos_Click);
            // 
            // tsmRestaurar
            // 
            this.tsmRestaurar.Image = global::SisContador.Properties.Resources.serverbasededatos32x32;
            this.tsmRestaurar.Name = "tsmRestaurar";
            this.tsmRestaurar.Size = new System.Drawing.Size(204, 26);
            this.tsmRestaurar.Tag = "Restaurar";
            this.tsmRestaurar.Text = "Restaurar Base de Datos";
            this.tsmRestaurar.ToolTipText = "Restaurar base de datos";
            this.tsmRestaurar.Click += new System.EventHandler(this.tsmRestaurar_Click);
            // 
            // graficosToolStripMenuItem
            // 
            this.graficosToolStripMenuItem.Image = global::SisContador.Properties.Resources.if_chart_512543__1_;
            this.graficosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graficosToolStripMenuItem.Name = "graficosToolStripMenuItem";
            this.graficosToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.graficosToolStripMenuItem.Tag = "Graficos";
            this.graficosToolStripMenuItem.Text = "Graficos";
            this.graficosToolStripMenuItem.Click += new System.EventHandler(this.graficosToolStripMenuItem_Click);
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciToolStripMenuItem,
            this.informaciónDeLaEmpresaToolStripMenuItem});
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.configuracionesToolStripMenuItem.Tag = "Configuraciones";
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // configuraciToolStripMenuItem
            // 
            this.configuraciToolStripMenuItem.Image = global::SisContador.Properties.Resources.ajustes16x16;
            this.configuraciToolStripMenuItem.Name = "configuraciToolStripMenuItem";
            this.configuraciToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.configuraciToolStripMenuItem.Tag = "Configuracion";
            this.configuraciToolStripMenuItem.Text = "Configuracion generales";
            this.configuraciToolStripMenuItem.Click += new System.EventHandler(this.configuraciToolStripMenuItem_Click);
            // 
            // informaciónDeLaEmpresaToolStripMenuItem
            // 
            this.informaciónDeLaEmpresaToolStripMenuItem.Image = global::SisContador.Properties.Resources.ajustes16x16;
            this.informaciónDeLaEmpresaToolStripMenuItem.Name = "informaciónDeLaEmpresaToolStripMenuItem";
            this.informaciónDeLaEmpresaToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.informaciónDeLaEmpresaToolStripMenuItem.Tag = "Empresa";
            this.informaciónDeLaEmpresaToolStripMenuItem.Text = "Información de la empresa";
            this.informaciónDeLaEmpresaToolStripMenuItem.Click += new System.EventHandler(this.informaciónDeLaEmpresaToolStripMenuItem_Click);
            // 
            // tsmAyuda
            // 
            this.tsmAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.tsmAyuda.Name = "tsmAyuda";
            this.tsmAyuda.Size = new System.Drawing.Size(53, 20);
            this.tsmAyuda.Tag = "Ayuda";
            this.tsmAyuda.Text = "Ayuda";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Image = global::SisContador.Properties.Resources.if_help_browser_118806;
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.contentsToolStripMenuItem.Tag = "Ayuda";
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SisContador.Properties.Resources.if_Information_27854;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Tag = "Acercade";
            this.aboutToolStripMenuItem.Text = "&Acerca de...";
            // 
            // ventanaToolStripMenuItem
            // 
            this.ventanaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorDeLaVentanaToolStripMenuItem,
            this.colorPorDefectoEnLaVentanaToolStripMenuItem});
            this.ventanaToolStripMenuItem.Name = "ventanaToolStripMenuItem";
            this.ventanaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ventanaToolStripMenuItem.Text = "Ventana";
            // 
            // colorDeLaVentanaToolStripMenuItem
            // 
            this.colorDeLaVentanaToolStripMenuItem.Name = "colorDeLaVentanaToolStripMenuItem";
            this.colorDeLaVentanaToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.colorDeLaVentanaToolStripMenuItem.Text = "Color de la Ventana";
            this.colorDeLaVentanaToolStripMenuItem.Click += new System.EventHandler(this.colorDeLaVentanaToolStripMenuItem_Click);
            // 
            // colorPorDefectoEnLaVentanaToolStripMenuItem
            // 
            this.colorPorDefectoEnLaVentanaToolStripMenuItem.Name = "colorPorDefectoEnLaVentanaToolStripMenuItem";
            this.colorPorDefectoEnLaVentanaToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.colorPorDefectoEnLaVentanaToolStripMenuItem.Text = "Color por defecto en la ventana";
            this.colorPorDefectoEnLaVentanaToolStripMenuItem.Click += new System.EventHandler(this.colorPorDefectoEnLaVentanaToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEtiqueta,
            this.tsbEtiquetaDeRespaldo});
            this.statusStrip.Location = new System.Drawing.Point(0, 527);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(825, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // tsbEtiqueta
            // 
            this.tsbEtiqueta.Name = "tsbEtiqueta";
            this.tsbEtiqueta.Size = new System.Drawing.Size(272, 17);
            this.tsbEtiqueta.Text = "Sistema contable gasolinera shell <<Esquipulas>>";
            // 
            // tsbEtiquetaDeRespaldo
            // 
            this.tsbEtiquetaDeRespaldo.Name = "tsbEtiquetaDeRespaldo";
            this.tsbEtiquetaDeRespaldo.Size = new System.Drawing.Size(0, 17);
            this.tsbEtiquetaDeRespaldo.Visible = false;
            // 
            // tsMenu
            // 
            this.tsMenu.AutoSize = false;
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGruposDeCuentas,
            this.tsbCategoriaDeCuenta,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.tsbTipoDeTransaccion,
            this.tsbMovimientos,
            this.toolStripSeparator2,
            this.tsbEgresos,
            this.tsbIngresos,
            this.tsbDiarios,
            this.toolStripSeparator4,
            this.tsbPeriodo,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripButton3});
            this.tsMenu.Location = new System.Drawing.Point(0, 24);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(158, 503);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.TabStop = true;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbGruposDeCuentas
            // 
            this.tsbGruposDeCuentas.Image = global::SisContador.Properties.Resources.if_SEO_content_management_969251__1_;
            this.tsbGruposDeCuentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbGruposDeCuentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGruposDeCuentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGruposDeCuentas.Name = "tsbGruposDeCuentas";
            this.tsbGruposDeCuentas.Size = new System.Drawing.Size(156, 24);
            this.tsbGruposDeCuentas.Tag = "GrupoDecuentas";
            this.tsbGruposDeCuentas.Text = "Grupos de Cuentas";
            this.tsbGruposDeCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbGruposDeCuentas.Click += new System.EventHandler(this.tsbGruposDeCuentas_Click);
            // 
            // tsbCategoriaDeCuenta
            // 
            this.tsbCategoriaDeCuenta.Image = global::SisContador.Properties.Resources.if_SEO_content_management_969251__1_;
            this.tsbCategoriaDeCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbCategoriaDeCuenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCategoriaDeCuenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCategoriaDeCuenta.Name = "tsbCategoriaDeCuenta";
            this.tsbCategoriaDeCuenta.Size = new System.Drawing.Size(156, 24);
            this.tsbCategoriaDeCuenta.Tag = "CategoriaDeCuentas";
            this.tsbCategoriaDeCuenta.Text = "Categoria de Cuentas";
            this.tsbCategoriaDeCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbCategoriaDeCuenta.Click += new System.EventHandler(this.tsbCategoriaDeCuenta_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::SisContador.Properties.Resources.if_SEO_content_management_969251__1_;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(156, 24);
            this.toolStripButton2.Tag = "Cuentas";
            this.toolStripButton2.Text = "Cuentas";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // tsbTipoDeTransaccion
            // 
            this.tsbTipoDeTransaccion.Image = global::SisContador.Properties.Resources.if_SEO_content_management_969251__1_;
            this.tsbTipoDeTransaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbTipoDeTransaccion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTipoDeTransaccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTipoDeTransaccion.Name = "tsbTipoDeTransaccion";
            this.tsbTipoDeTransaccion.Size = new System.Drawing.Size(156, 24);
            this.tsbTipoDeTransaccion.Tag = "TipoDeTransaccion";
            this.tsbTipoDeTransaccion.Text = "Tipo de Transacción";
            this.tsbTipoDeTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbTipoDeTransaccion.Click += new System.EventHandler(this.tsbTipoDeTransaccion_Click);
            // 
            // tsbMovimientos
            // 
            this.tsbMovimientos.Image = global::SisContador.Properties.Resources.if_SEO_content_management_969251__1_;
            this.tsbMovimientos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMovimientos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMovimientos.Name = "tsbMovimientos";
            this.tsbMovimientos.Size = new System.Drawing.Size(156, 24);
            this.tsbMovimientos.Tag = "Transacciones";
            this.tsbMovimientos.Text = "Movimientos Contables";
            this.tsbMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbMovimientos.Click += new System.EventHandler(this.tsbMovimientos_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // tsbEgresos
            // 
            this.tsbEgresos.Image = global::SisContador.Properties.Resources.Egresos24;
            this.tsbEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbEgresos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEgresos.Name = "tsbEgresos";
            this.tsbEgresos.Size = new System.Drawing.Size(156, 28);
            this.tsbEgresos.Tag = "Transacciones";
            this.tsbEgresos.Text = "Contabilizar - Egreso";
            this.tsbEgresos.ToolTipText = "Transacciones";
            this.tsbEgresos.Click += new System.EventHandler(this.tsbEgresos_Click);
            // 
            // tsbIngresos
            // 
            this.tsbIngresos.Image = global::SisContador.Properties.Resources.Egresos24;
            this.tsbIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbIngresos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbIngresos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIngresos.Name = "tsbIngresos";
            this.tsbIngresos.Size = new System.Drawing.Size(156, 28);
            this.tsbIngresos.Tag = "Transacciones";
            this.tsbIngresos.Text = "Contabilizar - Ingreso";
            this.tsbIngresos.Click += new System.EventHandler(this.tsbIngresos_Click);
            // 
            // tsbDiarios
            // 
            this.tsbDiarios.Image = global::SisContador.Properties.Resources.Egresos24;
            this.tsbDiarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbDiarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDiarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiarios.Name = "tsbDiarios";
            this.tsbDiarios.Size = new System.Drawing.Size(156, 28);
            this.tsbDiarios.Tag = "Transacciones";
            this.tsbDiarios.Text = "Contabilizar - Diario";
            this.tsbDiarios.Click += new System.EventHandler(this.tsbDiarios_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(156, 6);
            // 
            // tsbPeriodo
            // 
            this.tsbPeriodo.Image = global::SisContador.Properties.Resources.if_SEO_content_management_969251__1_;
            this.tsbPeriodo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.tsbPeriodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPeriodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPeriodo.Name = "tsbPeriodo";
            this.tsbPeriodo.Size = new System.Drawing.Size(156, 24);
            this.tsbPeriodo.Tag = "Periodo";
            this.tsbPeriodo.Text = "Periodo de Cierre";
            this.tsbPeriodo.Click += new System.EventHandler(this.tsbPeriodo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SisContador.Properties.Resources.printer22x22;
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(156, 26);
            this.toolStripButton1.Tag = "Reportes";
            this.toolStripButton1.Text = "Reportes";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::SisContador.Properties.Resources.printer22x22;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(156, 26);
            this.toolStripButton3.Tag = "Reportes";
            this.toolStripButton3.Text = "Reportes historico";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHorayFecha});
            this.statusStrip1.Location = new System.Drawing.Point(638, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(187, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbHorayFecha
            // 
            this.tsbHorayFecha.Name = "tsbHorayFecha";
            this.tsbHorayFecha.Size = new System.Drawing.Size(118, 17);
            this.tsbHorayFecha.Text = "toolStripStatusLabel1";
            this.tsbHorayFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 549);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Shown += new System.EventHandler(this.Principal_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsmHerramientas;
        private System.Windows.Forms.ToolStripMenuItem tsmRespaldarBaseDeDatos;
        private System.Windows.Forms.ToolStripMenuItem tsmAyuda;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem tsmRestaurar;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeCuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónDeLaEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsbEtiqueta;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbGruposDeCuentas;
        private System.Windows.Forms.ToolStripButton tsbCategoriaDeCuenta;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbTipoDeTransaccion;
        private System.Windows.Forms.ToolStripButton tsbEgresos;
        private System.Windows.Forms.ToolStripButton tsbIngresos;
        private System.Windows.Forms.ToolStripButton tsbDiarios;
        private System.Windows.Forms.ToolStripButton tsbMovimientos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbPeriodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbHorayFecha;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem ventanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorDeLaVentanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorPorDefectoEnLaVentanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripStatusLabel tsbEtiquetaDeRespaldo;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolStripMenuItem tsbTasaDeCambio;
        private System.Windows.Forms.ToolStripMenuItem graficosToolStripMenuItem;
    }
}



