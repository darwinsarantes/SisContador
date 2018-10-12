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
            this.tsmHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRespaldarBaseDeDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRestaurar = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónDeLaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbEtiqueta = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPeriodo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGeneral,
            this.tsmHerramientas,
            this.configuracionesToolStripMenuItem,
            this.tsmAyuda});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(825, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsmGeneral
            // 
            this.tsmGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.tiposDeCuentasToolStripMenuItem});
            this.tsmGeneral.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.tsmGeneral.Name = "tsmGeneral";
            this.tsmGeneral.Size = new System.Drawing.Size(70, 20);
            this.tsmGeneral.Tag = "Generales";
            this.tsmGeneral.Text = "Generales";
            this.tsmGeneral.ToolTipText = "Opciones generales";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Image = global::SisContador.Properties.Resources.ajustes16x16;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.usuariosToolStripMenuItem.Tag = "Usuario";
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // tiposDeCuentasToolStripMenuItem
            // 
            this.tiposDeCuentasToolStripMenuItem.Name = "tiposDeCuentasToolStripMenuItem";
            this.tiposDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.tiposDeCuentasToolStripMenuItem.Tag = "Rol";
            this.tiposDeCuentasToolStripMenuItem.Text = "Tipos de Cuentas";
            this.tiposDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.tiposDeCuentasToolStripMenuItem_Click);
            // 
            // tsmHerramientas
            // 
            this.tsmHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRespaldarBaseDeDatos,
            this.tsmRestaurar});
            this.tsmHerramientas.Name = "tsmHerramientas";
            this.tsmHerramientas.Size = new System.Drawing.Size(90, 20);
            this.tsmHerramientas.Tag = "Herramientas";
            this.tsmHerramientas.Text = "&Herramientas";
            // 
            // tsmRespaldarBaseDeDatos
            // 
            this.tsmRespaldarBaseDeDatos.Image = global::SisContador.Properties.Resources.server_base_de_datos;
            this.tsmRespaldarBaseDeDatos.Name = "tsmRespaldarBaseDeDatos";
            this.tsmRespaldarBaseDeDatos.Size = new System.Drawing.Size(200, 22);
            this.tsmRespaldarBaseDeDatos.Tag = "Respaldar";
            this.tsmRespaldarBaseDeDatos.Text = "&Respaldar Base de datos";
            this.tsmRespaldarBaseDeDatos.ToolTipText = "Respaldar base de datos";
            this.tsmRespaldarBaseDeDatos.Click += new System.EventHandler(this.tsmRespaldarBaseDeDatos_Click);
            // 
            // tsmRestaurar
            // 
            this.tsmRestaurar.Image = global::SisContador.Properties.Resources.serverbasededatos32x32;
            this.tsmRestaurar.Name = "tsmRestaurar";
            this.tsmRestaurar.Size = new System.Drawing.Size(200, 22);
            this.tsmRestaurar.Tag = "Restaurar";
            this.tsmRestaurar.Text = "Restaurar Base de Datos";
            this.tsmRestaurar.ToolTipText = "Restaurar base de datos";
            this.tsmRestaurar.Click += new System.EventHandler(this.tsmRestaurar_Click);
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
            this.configuraciToolStripMenuItem.Name = "configuraciToolStripMenuItem";
            this.configuraciToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.configuraciToolStripMenuItem.Tag = "Configuracion";
            this.configuraciToolStripMenuItem.Text = "Configuracion generales";
            this.configuraciToolStripMenuItem.Click += new System.EventHandler(this.configuraciToolStripMenuItem_Click);
            // 
            // informaciónDeLaEmpresaToolStripMenuItem
            // 
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
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Tag = "Acercade";
            this.aboutToolStripMenuItem.Text = "&Acerca de...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFecha,
            this.tsbEtiqueta});
            this.statusStrip.Location = new System.Drawing.Point(0, 527);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(825, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // tsFecha
            // 
            this.tsFecha.Name = "tsFecha";
            this.tsFecha.Size = new System.Drawing.Size(39, 17);
            this.tsFecha.Text = "Status";
            // 
            // tsbEtiqueta
            // 
            this.tsbEtiqueta.Name = "tsbEtiqueta";
            this.tsbEtiqueta.Size = new System.Drawing.Size(272, 17);
            this.tsbEtiqueta.Text = "Sistema contable gasolinera shell <<Esquipulas>>";
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
            this.toolStripSeparator3,
            this.tsbPeriodo,
            this.toolStripSeparator4,
            this.toolStripButton1});
            this.tsMenu.Location = new System.Drawing.Point(0, 24);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(158, 503);
            this.tsMenu.TabIndex = 4;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbGruposDeCuentas
            // 
            this.tsbGruposDeCuentas.Image = global::SisContador.Properties.Resources.carnet_de_identidad24x24;
            this.tsbGruposDeCuentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbGruposDeCuentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGruposDeCuentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGruposDeCuentas.Name = "tsbGruposDeCuentas";
            this.tsbGruposDeCuentas.Size = new System.Drawing.Size(156, 28);
            this.tsbGruposDeCuentas.Tag = "GrupoDecuentas";
            this.tsbGruposDeCuentas.Text = "Grupos de Cuentas";
            this.tsbGruposDeCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbGruposDeCuentas.Click += new System.EventHandler(this.tsbGruposDeCuentas_Click);
            // 
            // tsbCategoriaDeCuenta
            // 
            this.tsbCategoriaDeCuenta.Image = global::SisContador.Properties.Resources.Catalogo24x24;
            this.tsbCategoriaDeCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbCategoriaDeCuenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCategoriaDeCuenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCategoriaDeCuenta.Name = "tsbCategoriaDeCuenta";
            this.tsbCategoriaDeCuenta.Size = new System.Drawing.Size(156, 28);
            this.tsbCategoriaDeCuenta.Tag = "CategoriaDeCuentas";
            this.tsbCategoriaDeCuenta.Text = "Categoria de Cuentas";
            this.tsbCategoriaDeCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbCategoriaDeCuenta.Click += new System.EventHandler(this.tsbCategoriaDeCuenta_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::SisContador.Properties.Resources.Catalogo24x24;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(156, 28);
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
            this.tsbTipoDeTransaccion.Image = ((System.Drawing.Image)(resources.GetObject("tsbTipoDeTransaccion.Image")));
            this.tsbTipoDeTransaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbTipoDeTransaccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTipoDeTransaccion.Name = "tsbTipoDeTransaccion";
            this.tsbTipoDeTransaccion.Size = new System.Drawing.Size(156, 20);
            this.tsbTipoDeTransaccion.Tag = "TipoDeTransaccion";
            this.tsbTipoDeTransaccion.Text = "Tipo de Transacción";
            this.tsbTipoDeTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbTipoDeTransaccion.Click += new System.EventHandler(this.tsbTipoDeTransaccion_Click);
            // 
            // tsbMovimientos
            // 
            this.tsbMovimientos.Image = ((System.Drawing.Image)(resources.GetObject("tsbMovimientos.Image")));
            this.tsbMovimientos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbMovimientos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMovimientos.Name = "tsbMovimientos";
            this.tsbMovimientos.Size = new System.Drawing.Size(156, 20);
            this.tsbMovimientos.Tag = "Transacciones";
            this.tsbMovimientos.Text = "Movimientos Contables";
            this.tsbMovimientos.Click += new System.EventHandler(this.tsbMovimientos_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // tsbEgresos
            // 
            this.tsbEgresos.Image = ((System.Drawing.Image)(resources.GetObject("tsbEgresos.Image")));
            this.tsbEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEgresos.Name = "tsbEgresos";
            this.tsbEgresos.Size = new System.Drawing.Size(156, 20);
            this.tsbEgresos.Tag = "Transacciones";
            this.tsbEgresos.Text = "Contabilizar - Egreso";
            this.tsbEgresos.ToolTipText = "Transacciones";
            this.tsbEgresos.Click += new System.EventHandler(this.tsbEgresos_Click);
            // 
            // tsbIngresos
            // 
            this.tsbIngresos.Image = ((System.Drawing.Image)(resources.GetObject("tsbIngresos.Image")));
            this.tsbIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbIngresos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIngresos.Name = "tsbIngresos";
            this.tsbIngresos.Size = new System.Drawing.Size(156, 20);
            this.tsbIngresos.Tag = "Transacciones";
            this.tsbIngresos.Text = "Contabilizar - Ingreso";
            this.tsbIngresos.Click += new System.EventHandler(this.tsbIngresos_Click);
            // 
            // tsbDiarios
            // 
            this.tsbDiarios.Image = ((System.Drawing.Image)(resources.GetObject("tsbDiarios.Image")));
            this.tsbDiarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbDiarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiarios.Name = "tsbDiarios";
            this.tsbDiarios.Size = new System.Drawing.Size(156, 20);
            this.tsbDiarios.Tag = "Transacciones";
            this.tsbDiarios.Text = "Contabilizar - Diario";
            this.tsbDiarios.Click += new System.EventHandler(this.tsbDiarios_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // tsbPeriodo
            // 
            this.tsbPeriodo.Image = ((System.Drawing.Image)(resources.GetObject("tsbPeriodo.Image")));
            this.tsbPeriodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbPeriodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPeriodo.Name = "tsbPeriodo";
            this.tsbPeriodo.Size = new System.Drawing.Size(156, 20);
            this.tsbPeriodo.Tag = "Periodo";
            this.tsbPeriodo.Text = "Periodo de Cierre";
            this.tsbPeriodo.Click += new System.EventHandler(this.tsbPeriodo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(156, 6);
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
            this.toolStripButton1.Text = "Impresiones";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 549);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Principal_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel tsFecha;
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
    }
}



