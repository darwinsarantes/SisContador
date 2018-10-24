namespace SisContador.Formularios
{
    partial class frmReportesHistorico
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeriodAños = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPeriodosCerrados = new System.Windows.Forms.DataGridView();
            this.txtBuscarPeriodo = new System.Windows.Forms.TextBox();
            this.txtListadoDeReportes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListadoDeReportes = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbFiltarPorFechas = new System.Windows.Forms.GroupBox();
            this.dtpkFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpkFecha1 = new System.Windows.Forms.DateTimePicker();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.gbCuentasBancarias = new System.Windows.Forms.GroupBox();
            this.dgvListarCuentas = new System.Windows.Forms.DataGridView();
            this.chkCuentas = new System.Windows.Forms.CheckBox();
            this.gbCuentas = new System.Windows.Forms.GroupBox();
            this.mskidCuenta = new System.Windows.Forms.MaskedTextBox();
            this.cmbCategoriaDeCuentas = new System.Windows.Forms.ComboBox();
            this.chkCategoriaDeCuentas = new System.Windows.Forms.CheckBox();
            this.chkIdCuenta = new System.Windows.Forms.CheckBox();
            this.cmbGruposDeCuentas = new System.Windows.Forms.ComboBox();
            this.chkGrupoDeCuentas = new System.Windows.Forms.CheckBox();
            this.txtDescCuenta = new System.Windows.Forms.TextBox();
            this.chkDescCuenta = new System.Windows.Forms.CheckBox();
            this.gbTransacciones = new System.Windows.Forms.GroupBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.cmbTipoDeTransaccion = new System.Windows.Forms.ComboBox();
            this.chkTipoDeTransaccion = new System.Windows.Forms.CheckBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.chkConcepto = new System.Windows.Forms.CheckBox();
            this.txtNoTransaccion = new System.Windows.Forms.TextBox();
            this.chkNoTransaccion = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdMostarOcultarDatosPanelIzquierdo = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbPrinter = new System.Windows.Forms.ToolStripButton();
            this.cmdExportarAExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimirComprobante = new System.Windows.Forms.ToolStripButton();
            this.tsbAplicarBorde = new System.Windows.Forms.ToolStripButton();
            this.tsbVerEnDolares = new System.Windows.Forms.ToolStripButton();
            this.tsbEtiquetaTasa = new System.Windows.Forms.ToolStripLabel();
            this.tsbTasaDeCambio = new System.Windows.Forms.ToolStripLabel();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.ssBarraDeEstado = new System.Windows.Forms.StatusStrip();
            this.lblCantidadRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Consultar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDesmarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbaBarradeprogreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.Barradeprogreso = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodosCerrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDeReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbFiltarPorFechas.SuspendLayout();
            this.gbCuentasBancarias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarCuentas)).BeginInit();
            this.gbCuentas.SuspendLayout();
            this.gbTransacciones.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.ssBarraDeEstado.SuspendLayout();
            this.MenuContextual.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbPeriodAños);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dgvPeriodosCerrados);
            this.splitContainer1.Panel1.Controls.Add(this.txtBuscarPeriodo);
            this.splitContainer1.Panel1.Controls.Add(this.txtListadoDeReportes);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dgvListadoDeReportes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1291, 526);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Periodos - Años ";
            // 
            // cmbPeriodAños
            // 
            this.cmbPeriodAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodAños.FormattingEnabled = true;
            this.cmbPeriodAños.Location = new System.Drawing.Point(360, 29);
            this.cmbPeriodAños.Name = "cmbPeriodAños";
            this.cmbPeriodAños.Size = new System.Drawing.Size(81, 21);
            this.cmbPeriodAños.TabIndex = 18;
            this.cmbPeriodAños.SelectionChangeCommitted += new System.EventHandler(this.cmbPeriodAños_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Periodos Cerrados";
            // 
            // dgvPeriodosCerrados
            // 
            this.dgvPeriodosCerrados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeriodosCerrados.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriodosCerrados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPeriodosCerrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodosCerrados.Location = new System.Drawing.Point(12, 55);
            this.dgvPeriodosCerrados.Name = "dgvPeriodosCerrados";
            this.dgvPeriodosCerrados.Size = new System.Drawing.Size(429, 229);
            this.dgvPeriodosCerrados.TabIndex = 16;
            this.dgvPeriodosCerrados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodosCerrados_CellContentClick);
            // 
            // txtBuscarPeriodo
            // 
            this.txtBuscarPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarPeriodo.Location = new System.Drawing.Point(15, 29);
            this.txtBuscarPeriodo.Name = "txtBuscarPeriodo";
            this.txtBuscarPeriodo.Size = new System.Drawing.Size(339, 20);
            this.txtBuscarPeriodo.TabIndex = 15;
            this.txtBuscarPeriodo.TextChanged += new System.EventHandler(this.txtBuscarPeriodo_TextChanged);
            // 
            // txtListadoDeReportes
            // 
            this.txtListadoDeReportes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListadoDeReportes.Location = new System.Drawing.Point(141, 284);
            this.txtListadoDeReportes.Name = "txtListadoDeReportes";
            this.txtListadoDeReportes.Size = new System.Drawing.Size(300, 20);
            this.txtListadoDeReportes.TabIndex = 15;
            this.txtListadoDeReportes.TextChanged += new System.EventHandler(this.txtListadoDeReportes_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filtrar reporte por nombre";
            // 
            // dgvListadoDeReportes
            // 
            this.dgvListadoDeReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListadoDeReportes.BackgroundColor = System.Drawing.Color.White;
            this.dgvListadoDeReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListadoDeReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoDeReportes.Location = new System.Drawing.Point(12, 308);
            this.dgvListadoDeReportes.Name = "dgvListadoDeReportes";
            this.dgvListadoDeReportes.Size = new System.Drawing.Size(429, 205);
            this.dgvListadoDeReportes.TabIndex = 12;
            this.dgvListadoDeReportes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoDeReportes_CellClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Panel2.Controls.Add(this.dgvListar);
            this.splitContainer2.Size = new System.Drawing.Size(834, 526);
            this.splitContainer2.SplitterDistance = 251;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.gbFiltarPorFechas);
            this.flowLayoutPanel1.Controls.Add(this.gbCuentasBancarias);
            this.flowLayoutPanel1.Controls.Add(this.gbCuentas);
            this.flowLayoutPanel1.Controls.Add(this.gbTransacciones);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(834, 251);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // gbFiltarPorFechas
            // 
            this.gbFiltarPorFechas.Controls.Add(this.dtpkFecha2);
            this.gbFiltarPorFechas.Controls.Add(this.dtpkFecha1);
            this.gbFiltarPorFechas.Controls.Add(this.chkFecha);
            this.gbFiltarPorFechas.Location = new System.Drawing.Point(3, 3);
            this.gbFiltarPorFechas.Name = "gbFiltarPorFechas";
            this.gbFiltarPorFechas.Size = new System.Drawing.Size(329, 64);
            this.gbFiltarPorFechas.TabIndex = 0;
            this.gbFiltarPorFechas.TabStop = false;
            // 
            // dtpkFecha2
            // 
            this.dtpkFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFecha2.Location = new System.Drawing.Point(162, 23);
            this.dtpkFecha2.Name = "dtpkFecha2";
            this.dtpkFecha2.Size = new System.Drawing.Size(148, 20);
            this.dtpkFecha2.TabIndex = 7;
            this.dtpkFecha2.ValueChanged += new System.EventHandler(this.dtpkFecha2_ValueChanged);
            // 
            // dtpkFecha1
            // 
            this.dtpkFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFecha1.Location = new System.Drawing.Point(10, 23);
            this.dtpkFecha1.Name = "dtpkFecha1";
            this.dtpkFecha1.Size = new System.Drawing.Size(146, 20);
            this.dtpkFecha1.TabIndex = 6;
            this.dtpkFecha1.ValueChanged += new System.EventHandler(this.dtpkFecha1_ValueChanged);
            // 
            // chkFecha
            // 
            this.chkFecha.Location = new System.Drawing.Point(9, -2);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(118, 24);
            this.chkFecha.TabIndex = 5;
            this.chkFecha.Text = "Filtrar por Fecha:";
            this.chkFecha.UseVisualStyleBackColor = true;
            // 
            // gbCuentasBancarias
            // 
            this.gbCuentasBancarias.Controls.Add(this.dgvListarCuentas);
            this.gbCuentasBancarias.Controls.Add(this.chkCuentas);
            this.gbCuentasBancarias.Location = new System.Drawing.Point(338, 3);
            this.gbCuentasBancarias.Name = "gbCuentasBancarias";
            this.gbCuentasBancarias.Size = new System.Drawing.Size(473, 163);
            this.gbCuentasBancarias.TabIndex = 1;
            this.gbCuentasBancarias.TabStop = false;
            // 
            // dgvListarCuentas
            // 
            this.dgvListarCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListarCuentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvListarCuentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListarCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarCuentas.Location = new System.Drawing.Point(7, 19);
            this.dgvListarCuentas.Name = "dgvListarCuentas";
            this.dgvListarCuentas.Size = new System.Drawing.Size(459, 138);
            this.dgvListarCuentas.TabIndex = 14;
            this.dgvListarCuentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListarCuentas_CellClick);
            // 
            // chkCuentas
            // 
            this.chkCuentas.Location = new System.Drawing.Point(9, -2);
            this.chkCuentas.Name = "chkCuentas";
            this.chkCuentas.Size = new System.Drawing.Size(118, 24);
            this.chkCuentas.TabIndex = 5;
            this.chkCuentas.Text = "Filtrar por cuentas:";
            this.chkCuentas.UseVisualStyleBackColor = true;
            // 
            // gbCuentas
            // 
            this.gbCuentas.Controls.Add(this.mskidCuenta);
            this.gbCuentas.Controls.Add(this.cmbCategoriaDeCuentas);
            this.gbCuentas.Controls.Add(this.chkCategoriaDeCuentas);
            this.gbCuentas.Controls.Add(this.chkIdCuenta);
            this.gbCuentas.Controls.Add(this.cmbGruposDeCuentas);
            this.gbCuentas.Controls.Add(this.chkGrupoDeCuentas);
            this.gbCuentas.Controls.Add(this.txtDescCuenta);
            this.gbCuentas.Controls.Add(this.chkDescCuenta);
            this.gbCuentas.Location = new System.Drawing.Point(3, 172);
            this.gbCuentas.Name = "gbCuentas";
            this.gbCuentas.Size = new System.Drawing.Size(473, 130);
            this.gbCuentas.TabIndex = 2;
            this.gbCuentas.TabStop = false;
            this.gbCuentas.Text = "Filtros de cuentas";
            // 
            // mskidCuenta
            // 
            this.mskidCuenta.Location = new System.Drawing.Point(146, 19);
            this.mskidCuenta.Name = "mskidCuenta";
            this.mskidCuenta.Size = new System.Drawing.Size(237, 20);
            this.mskidCuenta.TabIndex = 10;
            // 
            // cmbCategoriaDeCuentas
            // 
            this.cmbCategoriaDeCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDeCuentas.FormattingEnabled = true;
            this.cmbCategoriaDeCuentas.Location = new System.Drawing.Point(146, 74);
            this.cmbCategoriaDeCuentas.MaxDropDownItems = 10;
            this.cmbCategoriaDeCuentas.Name = "cmbCategoriaDeCuentas";
            this.cmbCategoriaDeCuentas.Size = new System.Drawing.Size(237, 21);
            this.cmbCategoriaDeCuentas.TabIndex = 14;
            // 
            // chkCategoriaDeCuentas
            // 
            this.chkCategoriaDeCuentas.Location = new System.Drawing.Point(14, 72);
            this.chkCategoriaDeCuentas.Name = "chkCategoriaDeCuentas";
            this.chkCategoriaDeCuentas.Size = new System.Drawing.Size(141, 24);
            this.chkCategoriaDeCuentas.TabIndex = 13;
            this.chkCategoriaDeCuentas.Text = "Categoria de Cuentas:";
            this.chkCategoriaDeCuentas.UseVisualStyleBackColor = true;
            // 
            // chkIdCuenta
            // 
            this.chkIdCuenta.Location = new System.Drawing.Point(14, 18);
            this.chkIdCuenta.Name = "chkIdCuenta";
            this.chkIdCuenta.Size = new System.Drawing.Size(92, 24);
            this.chkIdCuenta.TabIndex = 9;
            this.chkIdCuenta.Text = "No. Cuenta:";
            this.chkIdCuenta.UseVisualStyleBackColor = true;
            // 
            // cmbGruposDeCuentas
            // 
            this.cmbGruposDeCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGruposDeCuentas.FormattingEnabled = true;
            this.cmbGruposDeCuentas.Location = new System.Drawing.Point(146, 47);
            this.cmbGruposDeCuentas.Name = "cmbGruposDeCuentas";
            this.cmbGruposDeCuentas.Size = new System.Drawing.Size(237, 21);
            this.cmbGruposDeCuentas.TabIndex = 12;
            // 
            // chkGrupoDeCuentas
            // 
            this.chkGrupoDeCuentas.Location = new System.Drawing.Point(14, 45);
            this.chkGrupoDeCuentas.Name = "chkGrupoDeCuentas";
            this.chkGrupoDeCuentas.Size = new System.Drawing.Size(118, 24);
            this.chkGrupoDeCuentas.TabIndex = 11;
            this.chkGrupoDeCuentas.Text = "Grupo de Cuentas:";
            this.chkGrupoDeCuentas.UseVisualStyleBackColor = true;
            // 
            // txtDescCuenta
            // 
            this.txtDescCuenta.Location = new System.Drawing.Point(146, 102);
            this.txtDescCuenta.Name = "txtDescCuenta";
            this.txtDescCuenta.Size = new System.Drawing.Size(237, 20);
            this.txtDescCuenta.TabIndex = 16;
            // 
            // chkDescCuenta
            // 
            this.chkDescCuenta.Location = new System.Drawing.Point(14, 100);
            this.chkDescCuenta.Name = "chkDescCuenta";
            this.chkDescCuenta.Size = new System.Drawing.Size(92, 24);
            this.chkDescCuenta.TabIndex = 15;
            this.chkDescCuenta.Text = "Descripcion:";
            this.chkDescCuenta.UseVisualStyleBackColor = true;
            // 
            // gbTransacciones
            // 
            this.gbTransacciones.Controls.Add(this.cmbEstado);
            this.gbTransacciones.Controls.Add(this.chkEstado);
            this.gbTransacciones.Controls.Add(this.cmbTipoDeTransaccion);
            this.gbTransacciones.Controls.Add(this.chkTipoDeTransaccion);
            this.gbTransacciones.Controls.Add(this.txtConcepto);
            this.gbTransacciones.Controls.Add(this.chkConcepto);
            this.gbTransacciones.Controls.Add(this.txtNoTransaccion);
            this.gbTransacciones.Controls.Add(this.chkNoTransaccion);
            this.gbTransacciones.Location = new System.Drawing.Point(3, 308);
            this.gbTransacciones.Name = "gbTransacciones";
            this.gbTransacciones.Size = new System.Drawing.Size(473, 130);
            this.gbTransacciones.TabIndex = 3;
            this.gbTransacciones.TabStop = false;
            this.gbTransacciones.Text = "Filtros para mostrar los movimientos contables";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "PENDIENTE",
            "GRABADA"});
            this.cmbEstado.Location = new System.Drawing.Point(146, 99);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(237, 21);
            this.cmbEstado.TabIndex = 10;
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(14, 97);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(137, 24);
            this.chkEstado.TabIndex = 9;
            this.chkEstado.Text = "Estado:";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // cmbTipoDeTransaccion
            // 
            this.cmbTipoDeTransaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDeTransaccion.FormattingEnabled = true;
            this.cmbTipoDeTransaccion.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cmbTipoDeTransaccion.Location = new System.Drawing.Point(146, 72);
            this.cmbTipoDeTransaccion.Name = "cmbTipoDeTransaccion";
            this.cmbTipoDeTransaccion.Size = new System.Drawing.Size(237, 21);
            this.cmbTipoDeTransaccion.TabIndex = 8;
            // 
            // chkTipoDeTransaccion
            // 
            this.chkTipoDeTransaccion.Location = new System.Drawing.Point(14, 70);
            this.chkTipoDeTransaccion.Name = "chkTipoDeTransaccion";
            this.chkTipoDeTransaccion.Size = new System.Drawing.Size(137, 24);
            this.chkTipoDeTransaccion.TabIndex = 3;
            this.chkTipoDeTransaccion.Text = "Tipo de Transacción:";
            this.chkTipoDeTransaccion.UseVisualStyleBackColor = true;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(146, 46);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(237, 20);
            this.txtConcepto.TabIndex = 6;
            // 
            // chkConcepto
            // 
            this.chkConcepto.Location = new System.Drawing.Point(14, 44);
            this.chkConcepto.Name = "chkConcepto";
            this.chkConcepto.Size = new System.Drawing.Size(118, 24);
            this.chkConcepto.TabIndex = 4;
            this.chkConcepto.Text = "Concepto:";
            this.chkConcepto.UseVisualStyleBackColor = true;
            // 
            // txtNoTransaccion
            // 
            this.txtNoTransaccion.Location = new System.Drawing.Point(146, 20);
            this.txtNoTransaccion.Name = "txtNoTransaccion";
            this.txtNoTransaccion.Size = new System.Drawing.Size(237, 20);
            this.txtNoTransaccion.TabIndex = 7;
            // 
            // chkNoTransaccion
            // 
            this.chkNoTransaccion.Location = new System.Drawing.Point(14, 18);
            this.chkNoTransaccion.Name = "chkNoTransaccion";
            this.chkNoTransaccion.Size = new System.Drawing.Size(118, 24);
            this.chkNoTransaccion.TabIndex = 5;
            this.chkNoTransaccion.Text = "No. Transacción";
            this.chkNoTransaccion.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdMostarOcultarDatosPanelIzquierdo,
            this.tsbSearch,
            this.tsbPrinter,
            this.cmdExportarAExcel,
            this.tsbImprimirComprobante,
            this.tsbAplicarBorde,
            this.tsbVerEnDolares,
            this.tsbEtiquetaTasa,
            this.tsbTasaDeCambio});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // cmdMostarOcultarDatosPanelIzquierdo
            // 
            this.cmdMostarOcultarDatosPanelIzquierdo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdMostarOcultarDatosPanelIzquierdo.Image = global::SisContador.Properties.Resources.leftarrow20x20;
            this.cmdMostarOcultarDatosPanelIzquierdo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdMostarOcultarDatosPanelIzquierdo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdMostarOcultarDatosPanelIzquierdo.Name = "cmdMostarOcultarDatosPanelIzquierdo";
            this.cmdMostarOcultarDatosPanelIzquierdo.Size = new System.Drawing.Size(24, 28);
            this.cmdMostarOcultarDatosPanelIzquierdo.Tag = "OCULTAR";
            this.cmdMostarOcultarDatosPanelIzquierdo.Text = "Ocultar Panel";
            this.cmdMostarOcultarDatosPanelIzquierdo.Click += new System.EventHandler(this.cmdMostarOcultarDatosPanelIzquierdo_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = global::SisContador.Properties.Resources.view22x22;
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(133, 28);
            this.tsbSearch.Text = "Filtrar información";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbPrinter
            // 
            this.tsbPrinter.Image = global::SisContador.Properties.Resources.printer22x22;
            this.tsbPrinter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrinter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrinter.Name = "tsbPrinter";
            this.tsbPrinter.Size = new System.Drawing.Size(79, 28);
            this.tsbPrinter.Text = "Imprimir";
            this.tsbPrinter.Click += new System.EventHandler(this.tsbPrinter_Click);
            // 
            // cmdExportarAExcel
            // 
            this.cmdExportarAExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdExportarAExcel.Image = global::SisContador.Properties.Resources.if_logo_brand_brands_logos_excel_2993694__1_;
            this.cmdExportarAExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdExportarAExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExportarAExcel.Name = "cmdExportarAExcel";
            this.cmdExportarAExcel.Size = new System.Drawing.Size(115, 28);
            this.cmdExportarAExcel.Text = "Importar a excel";
            this.cmdExportarAExcel.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbImprimirComprobante
            // 
            this.tsbImprimirComprobante.Image = global::SisContador.Properties.Resources.printer22x22;
            this.tsbImprimirComprobante.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbImprimirComprobante.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimirComprobante.Name = "tsbImprimirComprobante";
            this.tsbImprimirComprobante.Size = new System.Drawing.Size(154, 28);
            this.tsbImprimirComprobante.Text = "Imprimir comprobante";
            this.tsbImprimirComprobante.Click += new System.EventHandler(this.tsbImprimirComprobante_Click);
            // 
            // tsbAplicarBorde
            // 
            this.tsbAplicarBorde.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAplicarBorde.Image = global::SisContador.Properties.Resources.checked20x20;
            this.tsbAplicarBorde.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAplicarBorde.Name = "tsbAplicarBorde";
            this.tsbAplicarBorde.Size = new System.Drawing.Size(100, 28);
            this.tsbAplicarBorde.Text = "Ocultar Borde";
            this.tsbAplicarBorde.Click += new System.EventHandler(this.tsbAplicarBorde_Click);
            // 
            // tsbVerEnDolares
            // 
            this.tsbVerEnDolares.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbVerEnDolares.Image = global::SisContador.Properties.Resources.checked16x16;
            this.tsbVerEnDolares.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbVerEnDolares.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVerEnDolares.Name = "tsbVerEnDolares";
            this.tsbVerEnDolares.Size = new System.Drawing.Size(100, 28);
            this.tsbVerEnDolares.Text = "Ver en dolares";
            this.tsbVerEnDolares.Click += new System.EventHandler(this.tsbVerEnDolares_Click);
            // 
            // tsbEtiquetaTasa
            // 
            this.tsbEtiquetaTasa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbEtiquetaTasa.Name = "tsbEtiquetaTasa";
            this.tsbEtiquetaTasa.Size = new System.Drawing.Size(103, 28);
            this.tsbEtiquetaTasa.Text = "Cambio Oficial:";
            this.tsbEtiquetaTasa.Visible = false;
            // 
            // tsbTasaDeCambio
            // 
            this.tsbTasaDeCambio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbTasaDeCambio.Name = "tsbTasaDeCambio";
            this.tsbTasaDeCambio.Size = new System.Drawing.Size(0, 28);
            this.tsbTasaDeCambio.Visible = false;
            // 
            // dgvListar
            // 
            this.dgvListar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListar.BackgroundColor = System.Drawing.Color.White;
            this.dgvListar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Location = new System.Drawing.Point(3, 34);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.Size = new System.Drawing.Size(828, 234);
            this.dgvListar.TabIndex = 15;
            // 
            // ssBarraDeEstado
            // 
            this.ssBarraDeEstado.BackColor = System.Drawing.Color.White;
            this.ssBarraDeEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCantidadRegistros});
            this.ssBarraDeEstado.Location = new System.Drawing.Point(0, 531);
            this.ssBarraDeEstado.Name = "ssBarraDeEstado";
            this.ssBarraDeEstado.Size = new System.Drawing.Size(1291, 22);
            this.ssBarraDeEstado.TabIndex = 7;
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(86, 17);
            this.lblCantidadRegistros.Text = "№. Registros: 0";
            // 
            // MenuContextual
            // 
            this.MenuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Consultar,
            this.mnuMarcar,
            this.mnuDesmarcar});
            this.MenuContextual.Name = "MenuContextualAranceles";
            this.MenuContextual.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuContextual.Size = new System.Drawing.Size(131, 70);
            // 
            // Consultar
            // 
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(130, 22);
            this.Consultar.Tag = "Consultar";
            this.Consultar.Text = "Consultar";
            // 
            // mnuMarcar
            // 
            this.mnuMarcar.Name = "mnuMarcar";
            this.mnuMarcar.Size = new System.Drawing.Size(130, 22);
            this.mnuMarcar.Tag = "Marcar";
            this.mnuMarcar.Text = "Marcar";
            // 
            // mnuDesmarcar
            // 
            this.mnuDesmarcar.Name = "mnuDesmarcar";
            this.mnuDesmarcar.Size = new System.Drawing.Size(130, 22);
            this.mnuDesmarcar.Tag = "Desmarcar";
            this.mnuDesmarcar.Text = "Desmarcar";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbaBarradeprogreso,
            this.Barradeprogreso});
            this.statusStrip1.Location = new System.Drawing.Point(1134, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(157, 22);
            this.statusStrip1.TabIndex = 8;
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
            // frmReportesHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 553);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ssBarraDeEstado);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmReportesHistorico";
            this.Text = "frmReportesHistorico";
            this.Shown += new System.EventHandler(this.frmReportesHistorico_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodosCerrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDeReportes)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbFiltarPorFechas.ResumeLayout(false);
            this.gbCuentasBancarias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarCuentas)).EndInit();
            this.gbCuentas.ResumeLayout(false);
            this.gbCuentas.PerformLayout();
            this.gbTransacciones.ResumeLayout(false);
            this.gbTransacciones.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ssBarraDeEstado.ResumeLayout(false);
            this.ssBarraDeEstado.PerformLayout();
            this.MenuContextual.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtListadoDeReportes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListadoDeReportes;
        private System.Windows.Forms.StatusStrip ssBarraDeEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblCantidadRegistros;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem Consultar;
        private System.Windows.Forms.ToolStripMenuItem mnuMarcar;
        private System.Windows.Forms.ToolStripMenuItem mnuDesmarcar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbFiltarPorFechas;
        private System.Windows.Forms.DateTimePicker dtpkFecha2;
        private System.Windows.Forms.DateTimePicker dtpkFecha1;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.GroupBox gbCuentasBancarias;
        private System.Windows.Forms.DataGridView dgvListarCuentas;
        private System.Windows.Forms.CheckBox chkCuentas;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbPrinter;
        private System.Windows.Forms.GroupBox gbCuentas;
        private System.Windows.Forms.MaskedTextBox mskidCuenta;
        private System.Windows.Forms.ComboBox cmbCategoriaDeCuentas;
        private System.Windows.Forms.CheckBox chkCategoriaDeCuentas;
        private System.Windows.Forms.CheckBox chkIdCuenta;
        private System.Windows.Forms.ComboBox cmbGruposDeCuentas;
        private System.Windows.Forms.CheckBox chkGrupoDeCuentas;
        private System.Windows.Forms.TextBox txtDescCuenta;
        private System.Windows.Forms.CheckBox chkDescCuenta;
        private System.Windows.Forms.GroupBox gbTransacciones;
        private System.Windows.Forms.ComboBox cmbTipoDeTransaccion;
        private System.Windows.Forms.CheckBox chkTipoDeTransaccion;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.CheckBox chkConcepto;
        private System.Windows.Forms.TextBox txtNoTransaccion;
        private System.Windows.Forms.CheckBox chkNoTransaccion;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.ToolStripButton cmdMostarOcultarDatosPanelIzquierdo;
        private System.Windows.Forms.ToolStripButton cmdExportarAExcel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbaBarradeprogreso;
        private System.Windows.Forms.ToolStripProgressBar Barradeprogreso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPeriodosCerrados;
        private System.Windows.Forms.TextBox txtBuscarPeriodo;
        private System.Windows.Forms.ToolStripButton tsbImprimirComprobante;
        private System.Windows.Forms.ToolStripButton tsbVerEnDolares;
        private System.Windows.Forms.ToolStripLabel tsbEtiquetaTasa;
        private System.Windows.Forms.ToolStripLabel tsbTasaDeCambio;
        private System.Windows.Forms.ToolStripButton tsbAplicarBorde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodAños;
    }
}