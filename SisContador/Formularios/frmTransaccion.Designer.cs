namespace SisContador.Formularios
{
    partial class frmTransaccion
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCategoriaDeLasCuentas = new System.Windows.Forms.ComboBox();
            this.chkCategoriaDeLasCuentas = new System.Windows.Forms.CheckBox();
            this.cmbGrupoDeCuentas = new System.Windows.Forms.ComboBox();
            this.chkGrupoDeCuentas = new System.Windows.Forms.CheckBox();
            this.mskidCuenta = new System.Windows.Forms.MaskedTextBox();
            this.chkIdCuenta = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.dtpkFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpkFecha1 = new System.Windows.Forms.DateTimePicker();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.cmbTipoDeTransaccion = new System.Windows.Forms.ComboBox();
            this.chkTipoDeTransaccion = new System.Windows.Forms.CheckBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.chkConcepto = new System.Windows.Forms.CheckBox();
            this.txtNoTransaccion = new System.Windows.Forms.TextBox();
            this.chkNoTransaccion = new System.Windows.Forms.CheckBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.mcsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGrabarDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprobanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbNoRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbFiltrar = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltroAutomatico = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmComprobantes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNuevoRegistro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMarcarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsbSeleccionarTodos = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.mcsMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvLista);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.tsMenu);
            this.splitContainer1.Size = new System.Drawing.Size(933, 533);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbCategoriaDeLasCuentas);
            this.groupBox1.Controls.Add(this.chkCategoriaDeLasCuentas);
            this.groupBox1.Controls.Add(this.cmbGrupoDeCuentas);
            this.groupBox1.Controls.Add(this.chkGrupoDeCuentas);
            this.groupBox1.Controls.Add(this.mskidCuenta);
            this.groupBox1.Controls.Add(this.chkIdCuenta);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.chkEstado);
            this.groupBox1.Controls.Add(this.dtpkFecha2);
            this.groupBox1.Controls.Add(this.dtpkFecha1);
            this.groupBox1.Controls.Add(this.chkFecha);
            this.groupBox1.Controls.Add(this.cmbTipoDeTransaccion);
            this.groupBox1.Controls.Add(this.chkTipoDeTransaccion);
            this.groupBox1.Controls.Add(this.txtConcepto);
            this.groupBox1.Controls.Add(this.chkConcepto);
            this.groupBox1.Controls.Add(this.txtNoTransaccion);
            this.groupBox1.Controls.Add(this.chkNoTransaccion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar informacion de los grupos de cuentas";
            // 
            // cmbCategoriaDeLasCuentas
            // 
            this.cmbCategoriaDeLasCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDeLasCuentas.FormattingEnabled = true;
            this.cmbCategoriaDeLasCuentas.Items.AddRange(new object[] {
            "PENDIENTE",
            "EN REVISIÓN",
            "REBISADA",
            "ANULADA"});
            this.cmbCategoriaDeLasCuentas.Location = new System.Drawing.Point(564, 84);
            this.cmbCategoriaDeLasCuentas.Name = "cmbCategoriaDeLasCuentas";
            this.cmbCategoriaDeLasCuentas.Size = new System.Drawing.Size(237, 21);
            this.cmbCategoriaDeLasCuentas.TabIndex = 12;
            this.cmbCategoriaDeLasCuentas.SelectionChangeCommitted += new System.EventHandler(this.cmbCategoriaDeLasCuentas_SelectionChangeCommitted);
            // 
            // chkCategoriaDeLasCuentas
            // 
            this.chkCategoriaDeLasCuentas.Location = new System.Drawing.Point(425, 82);
            this.chkCategoriaDeLasCuentas.Name = "chkCategoriaDeLasCuentas";
            this.chkCategoriaDeLasCuentas.Size = new System.Drawing.Size(137, 24);
            this.chkCategoriaDeLasCuentas.TabIndex = 11;
            this.chkCategoriaDeLasCuentas.Text = "Categoria de Cuentas:";
            this.chkCategoriaDeLasCuentas.UseVisualStyleBackColor = true;
            // 
            // cmbGrupoDeCuentas
            // 
            this.cmbGrupoDeCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoDeCuentas.FormattingEnabled = true;
            this.cmbGrupoDeCuentas.Items.AddRange(new object[] {
            "PENDIENTE",
            "EN REVISIÓN",
            "REBISADA",
            "ANULADA"});
            this.cmbGrupoDeCuentas.Location = new System.Drawing.Point(564, 57);
            this.cmbGrupoDeCuentas.Name = "cmbGrupoDeCuentas";
            this.cmbGrupoDeCuentas.Size = new System.Drawing.Size(237, 21);
            this.cmbGrupoDeCuentas.TabIndex = 10;
            this.cmbGrupoDeCuentas.SelectionChangeCommitted += new System.EventHandler(this.cmbGrupoDeCuentas_SelectionChangeCommitted);
            // 
            // chkGrupoDeCuentas
            // 
            this.chkGrupoDeCuentas.Location = new System.Drawing.Point(425, 55);
            this.chkGrupoDeCuentas.Name = "chkGrupoDeCuentas";
            this.chkGrupoDeCuentas.Size = new System.Drawing.Size(137, 24);
            this.chkGrupoDeCuentas.TabIndex = 9;
            this.chkGrupoDeCuentas.Text = "Grupo de Cuentas:";
            this.chkGrupoDeCuentas.UseVisualStyleBackColor = true;
            // 
            // mskidCuenta
            // 
            this.mskidCuenta.Location = new System.Drawing.Point(564, 110);
            this.mskidCuenta.Name = "mskidCuenta";
            this.mskidCuenta.Size = new System.Drawing.Size(237, 20);
            this.mskidCuenta.TabIndex = 7;
            this.mskidCuenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mskidCuenta_KeyUp);
            // 
            // chkIdCuenta
            // 
            this.chkIdCuenta.Location = new System.Drawing.Point(425, 108);
            this.chkIdCuenta.Name = "chkIdCuenta";
            this.chkIdCuenta.Size = new System.Drawing.Size(92, 24);
            this.chkIdCuenta.TabIndex = 8;
            this.chkIdCuenta.Text = "No. Cuenta:";
            this.chkIdCuenta.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "PENDIENTE",
            "GRABADA"});
            this.cmbEstado.Location = new System.Drawing.Point(564, 31);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(237, 21);
            this.cmbEstado.TabIndex = 6;
            this.cmbEstado.SelectionChangeCommitted += new System.EventHandler(this.cmbEstado_SelectionChangeCommitted);
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(425, 29);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(137, 24);
            this.chkEstado.TabIndex = 5;
            this.chkEstado.Text = "Estado:";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // dtpkFecha2
            // 
            this.dtpkFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFecha2.Location = new System.Drawing.Point(282, 57);
            this.dtpkFecha2.Name = "dtpkFecha2";
            this.dtpkFecha2.Size = new System.Drawing.Size(111, 20);
            this.dtpkFecha2.TabIndex = 4;
            this.dtpkFecha2.ValueChanged += new System.EventHandler(this.dtpkFecha2_ValueChanged);
            // 
            // dtpkFecha1
            // 
            this.dtpkFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFecha1.Location = new System.Drawing.Point(156, 57);
            this.dtpkFecha1.Name = "dtpkFecha1";
            this.dtpkFecha1.Size = new System.Drawing.Size(111, 20);
            this.dtpkFecha1.TabIndex = 4;
            this.dtpkFecha1.ValueChanged += new System.EventHandler(this.dtpkFecha1_ValueChanged);
            // 
            // chkFecha
            // 
            this.chkFecha.Location = new System.Drawing.Point(21, 55);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(118, 24);
            this.chkFecha.TabIndex = 3;
            this.chkFecha.Text = "Fecha:";
            this.chkFecha.UseVisualStyleBackColor = true;
            // 
            // cmbTipoDeTransaccion
            // 
            this.cmbTipoDeTransaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDeTransaccion.FormattingEnabled = true;
            this.cmbTipoDeTransaccion.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cmbTipoDeTransaccion.Location = new System.Drawing.Point(156, 110);
            this.cmbTipoDeTransaccion.Name = "cmbTipoDeTransaccion";
            this.cmbTipoDeTransaccion.Size = new System.Drawing.Size(237, 21);
            this.cmbTipoDeTransaccion.TabIndex = 2;
            this.cmbTipoDeTransaccion.SelectionChangeCommitted += new System.EventHandler(this.cmbDebito_SelectionChangeCommitted);
            // 
            // chkTipoDeTransaccion
            // 
            this.chkTipoDeTransaccion.Location = new System.Drawing.Point(21, 108);
            this.chkTipoDeTransaccion.Name = "chkTipoDeTransaccion";
            this.chkTipoDeTransaccion.Size = new System.Drawing.Size(137, 24);
            this.chkTipoDeTransaccion.TabIndex = 0;
            this.chkTipoDeTransaccion.Text = "Tipo de Transacción:";
            this.chkTipoDeTransaccion.UseVisualStyleBackColor = true;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(156, 84);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(237, 20);
            this.txtConcepto.TabIndex = 1;
            this.txtConcepto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescTransacciones_KeyUp);
            // 
            // chkConcepto
            // 
            this.chkConcepto.Location = new System.Drawing.Point(21, 82);
            this.chkConcepto.Name = "chkConcepto";
            this.chkConcepto.Size = new System.Drawing.Size(118, 24);
            this.chkConcepto.TabIndex = 0;
            this.chkConcepto.Text = "Concepto:";
            this.chkConcepto.UseVisualStyleBackColor = true;
            // 
            // txtNoTransaccion
            // 
            this.txtNoTransaccion.Location = new System.Drawing.Point(156, 31);
            this.txtNoTransaccion.Name = "txtNoTransaccion";
            this.txtNoTransaccion.Size = new System.Drawing.Size(237, 20);
            this.txtNoTransaccion.TabIndex = 1;
            this.txtNoTransaccion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtIdentificador_KeyUp);
            // 
            // chkNoTransaccion
            // 
            this.chkNoTransaccion.Location = new System.Drawing.Point(21, 29);
            this.chkNoTransaccion.Name = "chkNoTransaccion";
            this.chkNoTransaccion.Size = new System.Drawing.Size(118, 24);
            this.chkNoTransaccion.TabIndex = 0;
            this.chkNoTransaccion.Text = "No. Transacción";
            this.chkNoTransaccion.UseVisualStyleBackColor = true;
            // 
            // dgvLista
            // 
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.ContextMenuStrip = this.mcsMenu;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(0, 31);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(933, 304);
            this.dgvLista.TabIndex = 2;
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            this.dgvLista.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvLista_CellContextMenuStripNeeded);
            this.dgvLista.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLista_CurrentCellDirtyStateChanged);
            this.dgvLista.DoubleClick += new System.EventHandler(this.dgvLista_DoubleClick);
            this.dgvLista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvLista_MouseDown);
            // 
            // mcsMenu
            // 
            this.mcsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.tsmGrabarDatos,
            this.toolStripSeparator1,
            this.visualizarToolStripMenuItem,
            this.imprimirToolStripMenuItem});
            this.mcsMenu.Name = "mcsMenu";
            this.mcsMenu.Size = new System.Drawing.Size(143, 142);
            this.mcsMenu.Opened += new System.EventHandler(this.mcsMenu_Opened);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::SisContador.Properties.Resources.New16x16;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::SisContador.Properties.Resources.Edit16x16;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::SisContador.Properties.Resources.Eliminar16x16;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // tsmGrabarDatos
            // 
            this.tsmGrabarDatos.Image = global::SisContador.Properties.Resources.Save16x16;
            this.tsmGrabarDatos.Name = "tsmGrabarDatos";
            this.tsmGrabarDatos.Size = new System.Drawing.Size(142, 22);
            this.tsmGrabarDatos.Tag = "Grabar Datos";
            this.tsmGrabarDatos.Text = "Grabar Datos";
            this.tsmGrabarDatos.Click += new System.EventHandler(this.tsmGrabarDatos_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.Image = global::SisContador.Properties.Resources.view16x16;
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            this.visualizarToolStripMenuItem.Click += new System.EventHandler(this.visualizarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprobanteToolStripMenuItem});
            this.imprimirToolStripMenuItem.Image = global::SisContador.Properties.Resources.printer16x16;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // comprobanteToolStripMenuItem
            // 
            this.comprobanteToolStripMenuItem.Name = "comprobanteToolStripMenuItem";
            this.comprobanteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.comprobanteToolStripMenuItem.Text = "Comprobante";
            this.comprobanteToolStripMenuItem.Click += new System.EventHandler(this.comprobanteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNoRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(933, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbNoRegistros
            // 
            this.tsbNoRegistros.Name = "tsbNoRegistros";
            this.tsbNoRegistros.Size = new System.Drawing.Size(102, 17);
            this.tsbNoRegistros.Text = "No. de registros: 0";
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFiltrar,
            this.tsbFiltroAutomatico,
            this.tsbImprimir,
            this.tsbNuevoRegistro,
            this.toolStripSeparator2,
            this.tsbMarcarTodos,
            this.tsbSeleccionarTodos});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(933, 31);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Filtrar";
            // 
            // tsbFiltrar
            // 
            this.tsbFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltrar.Image = global::SisContador.Properties.Resources.filtrar24x24;
            this.tsbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltrar.Name = "tsbFiltrar";
            this.tsbFiltrar.Size = new System.Drawing.Size(28, 28);
            this.tsbFiltrar.Text = "Filtrar";
            this.tsbFiltrar.ToolTipText = "Filtrar (F5)";
            this.tsbFiltrar.Click += new System.EventHandler(this.tsbFiltrar_Click);
            // 
            // tsbFiltroAutomatico
            // 
            this.tsbFiltroAutomatico.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFiltroAutomatico.Image = global::SisContador.Properties.Resources.checked16x16;
            this.tsbFiltroAutomatico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFiltroAutomatico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltroAutomatico.Name = "tsbFiltroAutomatico";
            this.tsbFiltroAutomatico.Size = new System.Drawing.Size(120, 28);
            this.tsbFiltroAutomatico.Text = "Filtro Automatico";
            this.tsbFiltroAutomatico.Click += new System.EventHandler(this.tsbFiltroAutomatico_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImprimir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmListado,
            this.tsmComprobantes});
            this.tsbImprimir.Image = global::SisContador.Properties.Resources.printer24x24;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(37, 28);
            this.tsbImprimir.Text = "Imprimir";
            // 
            // tsmListado
            // 
            this.tsmListado.Name = "tsmListado";
            this.tsmListado.Size = new System.Drawing.Size(200, 22);
            this.tsmListado.Text = "Listado";
            this.tsmListado.Click += new System.EventHandler(this.tsmListado_Click);
            // 
            // tsmComprobantes
            // 
            this.tsmComprobantes.Name = "tsmComprobantes";
            this.tsmComprobantes.Size = new System.Drawing.Size(200, 22);
            this.tsmComprobantes.Text = "Imprimir comprobantes";
            this.tsmComprobantes.Click += new System.EventHandler(this.transacciónToolStripMenuItem_Click);
            // 
            // tsbNuevoRegistro
            // 
            this.tsbNuevoRegistro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevoRegistro.Image = global::SisContador.Properties.Resources.new24x24;
            this.tsbNuevoRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoRegistro.Name = "tsbNuevoRegistro";
            this.tsbNuevoRegistro.Size = new System.Drawing.Size(28, 28);
            this.tsbNuevoRegistro.Text = "Nuevo Registro";
            this.tsbNuevoRegistro.ToolTipText = "Nuevo Registro (F2)";
            this.tsbNuevoRegistro.Click += new System.EventHandler(this.tsbNuevoRegistro_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbMarcarTodos
            // 
            this.tsbMarcarTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMarcarTodos.Image = global::SisContador.Properties.Resources.checked16x16;
            this.tsbMarcarTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMarcarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMarcarTodos.Name = "tsbMarcarTodos";
            this.tsbMarcarTodos.Size = new System.Drawing.Size(23, 28);
            this.tsbMarcarTodos.Text = "toolStripButton1";
            this.tsbMarcarTodos.Click += new System.EventHandler(this.tsbMarcarTodos_Click);
            // 
            // tsbSeleccionarTodos
            // 
            this.tsbSeleccionarTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSeleccionarTodos.Image = global::SisContador.Properties.Resources.checked16x16;
            this.tsbSeleccionarTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSeleccionarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSeleccionarTodos.Name = "tsbSeleccionarTodos";
            this.tsbSeleccionarTodos.Size = new System.Drawing.Size(23, 28);
            this.tsbSeleccionarTodos.Text = "toolStripButton2";
            this.tsbSeleccionarTodos.Click += new System.EventHandler(this.tsbSeleccionarTodos_Click);
            // 
            // frmTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 533);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmTransaccion";
            this.Text = "Grupos de cuentas";
            this.Shown += new System.EventHandler(this.frmTransaccion_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmTransaccion_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.mcsMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsbNoRegistros;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbFiltrar;
        private System.Windows.Forms.ToolStripButton tsbFiltroAutomatico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.CheckBox chkConcepto;
        private System.Windows.Forms.TextBox txtNoTransaccion;
        private System.Windows.Forms.CheckBox chkNoTransaccion;
        private System.Windows.Forms.ToolStripButton tsbNuevoRegistro;
        private System.Windows.Forms.ContextMenuStrip mcsMenu;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbMarcarTodos;
        private System.Windows.Forms.ToolStripButton tsbSeleccionarTodos;
        private System.Windows.Forms.ComboBox cmbTipoDeTransaccion;
        private System.Windows.Forms.CheckBox chkTipoDeTransaccion;
        private System.Windows.Forms.DateTimePicker dtpkFecha2;
        private System.Windows.Forms.DateTimePicker dtpkFecha1;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.MaskedTextBox mskidCuenta;
        private System.Windows.Forms.CheckBox chkIdCuenta;
        private System.Windows.Forms.ComboBox cmbCategoriaDeLasCuentas;
        private System.Windows.Forms.CheckBox chkCategoriaDeLasCuentas;
        private System.Windows.Forms.ComboBox cmbGrupoDeCuentas;
        private System.Windows.Forms.CheckBox chkGrupoDeCuentas;
        private System.Windows.Forms.ToolStripDropDownButton tsbImprimir;
        private System.Windows.Forms.ToolStripMenuItem tsmListado;
        private System.Windows.Forms.ToolStripMenuItem tsmComprobantes;
        private System.Windows.Forms.ToolStripMenuItem comprobanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmGrabarDatos;
    }
}