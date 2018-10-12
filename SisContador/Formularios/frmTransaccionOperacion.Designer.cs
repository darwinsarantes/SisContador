namespace SisContador.Formularios
{
    partial class frmTransaccionOperacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumeroDeTransaccion = new System.Windows.Forms.TextBox();
            this.dtpkFecha = new System.Windows.Forms.DateTimePicker();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoDeTransacción = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbaBarradeprogreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.Barradeprogreso = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tstTotalRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbCuentas = new System.Windows.Forms.ToolStripButton();
            this.cmdMostarOcultarDatosPanelIzquierdo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbLimpiarCampos = new System.Windows.Forms.ToolStripButton();
            this.tsbGrabarDatos = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrarVentan = new System.Windows.Forms.ToolStripButton();
            this.tsbRecarRegistro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.chkCerrarVentana = new System.Windows.Forms.CheckBox();
            this.EP = new System.Windows.Forms.ErrorProvider(this.components);
            this.InformacionEntidadOperacion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 475);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(13, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1251, 413);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtValor);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtNumeroDeTransaccion);
            this.splitContainer1.Panel1.Controls.Add(this.dtpkFecha);
            this.splitContainer1.Panel1.Controls.Add(this.txtIdentificador);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cmbTipoDeTransacción);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmbEstado);
            this.splitContainer1.Panel1.Controls.Add(this.txtConcepto);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.dgvLista);
            this.splitContainer1.Panel2.Controls.Add(this.tsMenu);
            this.splitContainer1.Size = new System.Drawing.Size(1251, 413);
            this.splitContainer1.SplitterDistance = 475;
            this.splitContainer1.TabIndex = 16;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(136, 351);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(296, 20);
            this.txtValor.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Valor:";
            // 
            // txtNumeroDeTransaccion
            // 
            this.txtNumeroDeTransaccion.Location = new System.Drawing.Point(136, 14);
            this.txtNumeroDeTransaccion.Name = "txtNumeroDeTransaccion";
            this.txtNumeroDeTransaccion.Size = new System.Drawing.Size(296, 20);
            this.txtNumeroDeTransaccion.TabIndex = 3;
            // 
            // dtpkFecha
            // 
            this.dtpkFecha.Location = new System.Drawing.Point(136, 40);
            this.dtpkFecha.Name = "dtpkFecha";
            this.dtpkFecha.Size = new System.Drawing.Size(296, 20);
            this.dtpkFecha.TabIndex = 15;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(136, 14);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(118, 20);
            this.txtIdentificador.TabIndex = 4;
            this.txtIdentificador.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fecha:";
            // 
            // cmbTipoDeTransacción
            // 
            this.cmbTipoDeTransacción.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDeTransacción.FormattingEnabled = true;
            this.cmbTipoDeTransacción.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cmbTipoDeTransacción.Location = new System.Drawing.Point(136, 66);
            this.cmbTipoDeTransacción.Name = "cmbTipoDeTransacción";
            this.cmbTipoDeTransacción.Size = new System.Drawing.Size(296, 21);
            this.cmbTipoDeTransacción.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Concepto:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "PENDIENTE",
            "GRABADA"});
            this.cmbEstado.Location = new System.Drawing.Point(136, 379);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(296, 21);
            this.cmbEstado.TabIndex = 5;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(136, 93);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConcepto.Size = new System.Drawing.Size(296, 252);
            this.txtConcepto.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "No. Transacción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo de transacción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Identificador";
            this.label1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbaBarradeprogreso,
            this.Barradeprogreso});
            this.statusStrip1.Location = new System.Drawing.Point(612, 391);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(157, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbaBarradeprogreso
            // 
            this.lbaBarradeprogreso.Name = "lbaBarradeprogreso";
            this.lbaBarradeprogreso.Size = new System.Drawing.Size(38, 17);
            this.lbaBarradeprogreso.Text = "0 de 0";
            // 
            // Barradeprogreso
            // 
            this.Barradeprogreso.Name = "Barradeprogreso";
            this.Barradeprogreso.Size = new System.Drawing.Size(100, 16);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstTotalRegistros});
            this.statusStrip2.Location = new System.Drawing.Point(0, 391);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(772, 22);
            this.statusStrip2.TabIndex = 6;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tstTotalRegistros
            // 
            this.tstTotalRegistros.Name = "tstTotalRegistros";
            this.tstTotalRegistros.Size = new System.Drawing.Size(102, 17);
            this.tstTotalRegistros.Text = "No de registros:  0";
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(0, 25);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(769, 366);
            this.dgvLista.TabIndex = 3;
            this.dgvLista.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLista_CellBeginEdit);
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            this.dgvLista.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellEndEdit);
            this.dgvLista.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellEnter);
            this.dgvLista.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLista_CellValidating);
            this.dgvLista.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellValueChanged);
            this.dgvLista.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLista_CurrentCellDirtyStateChanged);
            this.dgvLista.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLista_EditingControlShowing);
            this.dgvLista.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvLista_Scroll);
            this.dgvLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLista_KeyDown);
            this.dgvLista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvLista_KeyUp);
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCuentas,
            this.cmdMostarOcultarDatosPanelIzquierdo});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(772, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip2";
            // 
            // tsbCuentas
            // 
            this.tsbCuentas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCuentas.Image = global::SisContador.Properties.Resources.view16x16;
            this.tsbCuentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCuentas.Name = "tsbCuentas";
            this.tsbCuentas.Size = new System.Drawing.Size(108, 22);
            this.tsbCuentas.Text = "Buscar Cuentas";
            this.tsbCuentas.Click += new System.EventHandler(this.tsbCuentas_Click);
            // 
            // cmdMostarOcultarDatosPanelIzquierdo
            // 
            this.cmdMostarOcultarDatosPanelIzquierdo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdMostarOcultarDatosPanelIzquierdo.Image = global::SisContador.Properties.Resources.leftarrows16x16;
            this.cmdMostarOcultarDatosPanelIzquierdo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdMostarOcultarDatosPanelIzquierdo.Name = "cmdMostarOcultarDatosPanelIzquierdo";
            this.cmdMostarOcultarDatosPanelIzquierdo.Size = new System.Drawing.Size(23, 22);
            this.cmdMostarOcultarDatosPanelIzquierdo.Tag = "OCULTAR";
            this.cmdMostarOcultarDatosPanelIzquierdo.Text = "Ocultar Panel";
            this.cmdMostarOcultarDatosPanelIzquierdo.Click += new System.EventHandler(this.tsbOcultarPanelIzquierdo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardar,
            this.tsbActualizar,
            this.tsbEliminar,
            this.tsbLimpiarCampos,
            this.tsbGrabarDatos,
            this.tsbCerrarVentan,
            this.tsbRecarRegistro,
            this.toolStripSeparator1,
            this.tsbImprimir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1282, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.Image = global::SisContador.Properties.Resources.Save24x24;
            this.tsbGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(77, 28);
            this.tsbGuardar.Text = "Guardar";
            this.tsbGuardar.ToolTipText = "Guardar registro";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // tsbActualizar
            // 
            this.tsbActualizar.Image = global::SisContador.Properties.Resources.Edit24x24;
            this.tsbActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizar.Name = "tsbActualizar";
            this.tsbActualizar.Size = new System.Drawing.Size(87, 28);
            this.tsbActualizar.Text = "Actualizar";
            this.tsbActualizar.ToolTipText = "Actualizar registro";
            this.tsbActualizar.Click += new System.EventHandler(this.tsbActualizar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = global::SisContador.Properties.Resources.Eliminar24x24;
            this.tsbEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(74, 28);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.ToolTipText = "Eliminar registro";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbLimpiarCampos
            // 
            this.tsbLimpiarCampos.Image = global::SisContador.Properties.Resources.Nuevo24x24;
            this.tsbLimpiarCampos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLimpiarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLimpiarCampos.Name = "tsbLimpiarCampos";
            this.tsbLimpiarCampos.Size = new System.Drawing.Size(70, 28);
            this.tsbLimpiarCampos.Text = "Nuevo";
            this.tsbLimpiarCampos.ToolTipText = "Nuevo registro";
            this.tsbLimpiarCampos.Click += new System.EventHandler(this.tsbLimpiarCampos_Click);
            // 
            // tsbGrabarDatos
            // 
            this.tsbGrabarDatos.Image = global::SisContador.Properties.Resources.Save24x24;
            this.tsbGrabarDatos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGrabarDatos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGrabarDatos.Name = "tsbGrabarDatos";
            this.tsbGrabarDatos.Size = new System.Drawing.Size(103, 28);
            this.tsbGrabarDatos.Text = "Grabar Datos";
            this.tsbGrabarDatos.Click += new System.EventHandler(this.tsbGrabarDatos_Click);
            // 
            // tsbCerrarVentan
            // 
            this.tsbCerrarVentan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCerrarVentan.Image = global::SisContador.Properties.Resources.Salir24x24;
            this.tsbCerrarVentan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCerrarVentan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrarVentan.Name = "tsbCerrarVentan";
            this.tsbCerrarVentan.Size = new System.Drawing.Size(57, 28);
            this.tsbCerrarVentan.Text = "Salir";
            this.tsbCerrarVentan.ToolTipText = "Cerrar la ventana y retornar";
            this.tsbCerrarVentan.Click += new System.EventHandler(this.tsbCerrarVentan_Click);
            // 
            // tsbRecarRegistro
            // 
            this.tsbRecarRegistro.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRecarRegistro.Image = global::SisContador.Properties.Resources.Refresh132x32;
            this.tsbRecarRegistro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRecarRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecarRegistro.Name = "tsbRecarRegistro";
            this.tsbRecarRegistro.Size = new System.Drawing.Size(84, 28);
            this.tsbRecarRegistro.Text = "Recargar ";
            this.tsbRecarRegistro.ToolTipText = "Recargar  registro";
            this.tsbRecarRegistro.Click += new System.EventHandler(this.tsbRecarRegistro_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Image = global::SisContador.Properties.Resources.printer24x24;
            this.tsbImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(81, 28);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Click += new System.EventHandler(this.tsbImprimir_Click);
            // 
            // chkCerrarVentana
            // 
            this.chkCerrarVentana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCerrarVentana.AutoSize = true;
            this.chkCerrarVentana.Location = new System.Drawing.Point(12, 518);
            this.chkCerrarVentana.Name = "chkCerrarVentana";
            this.chkCerrarVentana.Size = new System.Drawing.Size(204, 17);
            this.chkCerrarVentana.TabIndex = 1;
            this.chkCerrarVentana.Text = "Cerrar ventana de manera automatica";
            this.chkCerrarVentana.UseVisualStyleBackColor = true;
            this.chkCerrarVentana.CheckedChanged += new System.EventHandler(this.chkCerrarVentana_CheckedChanged);
            // 
            // EP
            // 
            this.EP.ContainerControl = this;
            // 
            // InformacionEntidadOperacion
            // 
            this.InformacionEntidadOperacion.AutoSize = true;
            this.InformacionEntidadOperacion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformacionEntidadOperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.InformacionEntidadOperacion.Location = new System.Drawing.Point(14, 15);
            this.InformacionEntidadOperacion.Name = "InformacionEntidadOperacion";
            this.InformacionEntidadOperacion.Size = new System.Drawing.Size(0, 16);
            this.InformacionEntidadOperacion.TabIndex = 3;
            // 
            // frmTransaccionOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1306, 546);
            this.Controls.Add(this.InformacionEntidadOperacion);
            this.Controls.Add(this.chkCerrarVentana);
            this.Controls.Add(this.panel1);
            this.Name = "frmTransaccionOperacion";
            this.Text = "frmTransaccionOperacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTransaccionOperacion_FormClosing);
            this.Shown += new System.EventHandler(this.frmTransaccionOperacion_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.CheckBox chkCerrarVentana;
        private System.Windows.Forms.ToolStripButton tsbActualizar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbLimpiarCampos;
        private System.Windows.Forms.ToolStripButton tsbRecarRegistro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbCerrarVentan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbTipoDeTransacción;
        private System.Windows.Forms.TextBox txtNumeroDeTransaccion;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider EP;
        private System.Windows.Forms.Label InformacionEntidadOperacion;
        private System.Windows.Forms.DateTimePicker dtpkFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tstTotalRegistros;
        private System.Windows.Forms.ToolStripButton tsbCuentas;
        private System.Windows.Forms.ToolStripButton cmdMostarOcultarDatosPanelIzquierdo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbaBarradeprogreso;
        private System.Windows.Forms.ToolStripProgressBar Barradeprogreso;
        private System.Windows.Forms.ToolStripButton tsbGrabarDatos;
    }
}