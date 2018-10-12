namespace SisContador.Formularios
{
    partial class frmGraficos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chGraficos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbFiltarPorFechas = new System.Windows.Forms.GroupBox();
            this.dtpkFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpkFecha1 = new System.Windows.Forms.DateTimePicker();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbListadoDeImpresiones = new System.Windows.Forms.ComboBox();
            this.chkListadoDeImpriones = new System.Windows.Forms.CheckBox();
            this.gbPeriodo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPeriodoCerrado = new System.Windows.Forms.ComboBox();
            this.cmbPeriodAños = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPeriodo = new System.Windows.Forms.CheckBox();
            this.msmenu = new System.Windows.Forms.ToolStrip();
            this.tsbFiltrarInformacion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbWindows = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbOcultarPanelDeDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarGraficoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDerecha = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTituloDelGrafico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chGraficos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbFiltarPorFechas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPeriodo.SuspendLayout();
            this.msmenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbCuentasBancarias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarCuentas)).BeginInit();
            this.gbCuentas.SuspendLayout();
            this.gbTransacciones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chGraficos
            // 
            this.chGraficos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chGraficos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chGraficos.Legends.Add(legend1);
            this.chGraficos.Location = new System.Drawing.Point(12, 12);
            this.chGraficos.Name = "chGraficos";
            this.chGraficos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            this.chGraficos.Series.Add(series1);
            this.chGraficos.Series.Add(series2);
            this.chGraficos.Series.Add(series3);
            this.chGraficos.Size = new System.Drawing.Size(922, 414);
            this.chGraficos.TabIndex = 0;
            this.chGraficos.Text = "chart1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.msmenu);
            this.splitContainer1.Size = new System.Drawing.Size(1310, 611);
            this.splitContainer1.SplitterDistance = 950;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chGraficos);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvListar);
            this.splitContainer2.Size = new System.Drawing.Size(950, 611);
            this.splitContainer2.SplitterDistance = 441;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvListar
            // 
            this.dgvListar.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListar.Location = new System.Drawing.Point(0, 0);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.Size = new System.Drawing.Size(950, 166);
            this.dgvListar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 584);
            this.panel1.TabIndex = 1;
            // 
            // gbFiltarPorFechas
            // 
            this.gbFiltarPorFechas.Controls.Add(this.dtpkFecha2);
            this.gbFiltarPorFechas.Controls.Add(this.dtpkFecha1);
            this.gbFiltarPorFechas.Controls.Add(this.chkFecha);
            this.gbFiltarPorFechas.Location = new System.Drawing.Point(3, 135);
            this.gbFiltarPorFechas.Name = "gbFiltarPorFechas";
            this.gbFiltarPorFechas.Size = new System.Drawing.Size(334, 64);
            this.gbFiltarPorFechas.TabIndex = 2;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbListadoDeImpresiones);
            this.groupBox1.Controls.Add(this.chkListadoDeImpriones);
            this.groupBox1.Location = new System.Drawing.Point(3, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbListadoDeImpresiones
            // 
            this.cmbListadoDeImpresiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListadoDeImpresiones.FormattingEnabled = true;
            this.cmbListadoDeImpresiones.Location = new System.Drawing.Point(7, 22);
            this.cmbListadoDeImpresiones.Name = "cmbListadoDeImpresiones";
            this.cmbListadoDeImpresiones.Size = new System.Drawing.Size(321, 21);
            this.cmbListadoDeImpresiones.TabIndex = 19;
            this.cmbListadoDeImpresiones.SelectionChangeCommitted += new System.EventHandler(this.cmbListadoDeImpresiones_SelectionChangeCommitted);
            // 
            // chkListadoDeImpriones
            // 
            this.chkListadoDeImpriones.AutoSize = true;
            this.chkListadoDeImpriones.Location = new System.Drawing.Point(9, -1);
            this.chkListadoDeImpriones.Name = "chkListadoDeImpriones";
            this.chkListadoDeImpriones.Size = new System.Drawing.Size(165, 17);
            this.chkListadoDeImpriones.TabIndex = 0;
            this.chkListadoDeImpriones.Text = "Lista de impresiones de datos";
            this.chkListadoDeImpriones.UseVisualStyleBackColor = true;
            // 
            // gbPeriodo
            // 
            this.gbPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPeriodo.Controls.Add(this.label2);
            this.gbPeriodo.Controls.Add(this.cmbPeriodoCerrado);
            this.gbPeriodo.Controls.Add(this.cmbPeriodAños);
            this.gbPeriodo.Controls.Add(this.label1);
            this.gbPeriodo.Controls.Add(this.chkPeriodo);
            this.gbPeriodo.Location = new System.Drawing.Point(3, 3);
            this.gbPeriodo.Name = "gbPeriodo";
            this.gbPeriodo.Size = new System.Drawing.Size(334, 68);
            this.gbPeriodo.TabIndex = 0;
            this.gbPeriodo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Periodo Cerrado:";
            // 
            // cmbPeriodoCerrado
            // 
            this.cmbPeriodoCerrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoCerrado.FormattingEnabled = true;
            this.cmbPeriodoCerrado.Location = new System.Drawing.Point(7, 40);
            this.cmbPeriodoCerrado.Name = "cmbPeriodoCerrado";
            this.cmbPeriodoCerrado.Size = new System.Drawing.Size(321, 21);
            this.cmbPeriodoCerrado.TabIndex = 19;
            this.cmbPeriodoCerrado.SelectionChangeCommitted += new System.EventHandler(this.cmbPeriodoCerrado_SelectionChangeCommitted);
            // 
            // cmbPeriodAños
            // 
            this.cmbPeriodAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodAños.FormattingEnabled = true;
            this.cmbPeriodAños.Location = new System.Drawing.Point(261, 17);
            this.cmbPeriodAños.Name = "cmbPeriodAños";
            this.cmbPeriodAños.Size = new System.Drawing.Size(66, 21);
            this.cmbPeriodAños.TabIndex = 19;
            this.cmbPeriodAños.SelectionChangeCommitted += new System.EventHandler(this.cmbPeriodAños_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Años:";
            // 
            // chkPeriodo
            // 
            this.chkPeriodo.AutoSize = true;
            this.chkPeriodo.Location = new System.Drawing.Point(9, -1);
            this.chkPeriodo.Name = "chkPeriodo";
            this.chkPeriodo.Size = new System.Drawing.Size(136, 17);
            this.chkPeriodo.TabIndex = 0;
            this.chkPeriodo.Text = "Información del periodo";
            this.chkPeriodo.UseVisualStyleBackColor = true;
            // 
            // msmenu
            // 
            this.msmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFiltrarInformacion,
            this.toolStripButton1,
            this.tsbWindows,
            this.tsbDerecha});
            this.msmenu.Location = new System.Drawing.Point(0, 0);
            this.msmenu.Name = "msmenu";
            this.msmenu.Size = new System.Drawing.Size(356, 27);
            this.msmenu.TabIndex = 0;
            this.msmenu.Text = "toolStrip1";
            // 
            // tsbFiltrarInformacion
            // 
            this.tsbFiltrarInformacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltrarInformacion.Image = global::SisContador.Properties.Resources.filtrar22x22;
            this.tsbFiltrarInformacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFiltrarInformacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltrarInformacion.Name = "tsbFiltrarInformacion";
            this.tsbFiltrarInformacion.Size = new System.Drawing.Size(24, 24);
            this.tsbFiltrarInformacion.Text = "Filtar Información";
            this.tsbFiltrarInformacion.Click += new System.EventHandler(this.tsbFiltrarInformacion_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SisContador.Properties.Resources.if_chart_512543__1_;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbWindows
            // 
            this.tsbWindows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOcultarPanelDeDatos,
            this.ocultarGraficoToolStripMenuItem});
            this.tsbWindows.Image = global::SisContador.Properties.Resources.if_tools_1287509__2_;
            this.tsbWindows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWindows.Name = "tsbWindows";
            this.tsbWindows.Size = new System.Drawing.Size(29, 24);
            this.tsbWindows.Text = "Ventana";
            // 
            // tsbOcultarPanelDeDatos
            // 
            this.tsbOcultarPanelDeDatos.Image = global::SisContador.Properties.Resources.checked16x16;
            this.tsbOcultarPanelDeDatos.Name = "tsbOcultarPanelDeDatos";
            this.tsbOcultarPanelDeDatos.Size = new System.Drawing.Size(153, 22);
            this.tsbOcultarPanelDeDatos.Tag = "Mostrar";
            this.tsbOcultarPanelDeDatos.Text = "Ocultar Datos";
            // 
            // ocultarGraficoToolStripMenuItem
            // 
            this.ocultarGraficoToolStripMenuItem.Name = "ocultarGraficoToolStripMenuItem";
            this.ocultarGraficoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ocultarGraficoToolStripMenuItem.Text = "Ocultar grafico";
            // 
            // tsbDerecha
            // 
            this.tsbDerecha.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDerecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDerecha.Image = global::SisContador.Properties.Resources.rigtharrow20x20;
            this.tsbDerecha.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDerecha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDerecha.Name = "tsbDerecha";
            this.tsbDerecha.Size = new System.Drawing.Size(24, 24);
            this.tsbDerecha.Tag = "Mostrar";
            this.tsbDerecha.Text = "Ocultar";
            this.tsbDerecha.ToolTipText = "Ocultar Panel";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.gbPeriodo);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.gbFiltarPorFechas);
            this.flowLayoutPanel1.Controls.Add(this.gbCuentasBancarias);
            this.flowLayoutPanel1.Controls.Add(this.gbCuentas);
            this.flowLayoutPanel1.Controls.Add(this.gbTransacciones);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 584);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // gbCuentasBancarias
            // 
            this.gbCuentasBancarias.Controls.Add(this.dgvListarCuentas);
            this.gbCuentasBancarias.Controls.Add(this.chkCuentas);
            this.gbCuentasBancarias.Location = new System.Drawing.Point(3, 205);
            this.gbCuentasBancarias.Name = "gbCuentasBancarias";
            this.gbCuentasBancarias.Size = new System.Drawing.Size(334, 163);
            this.gbCuentasBancarias.TabIndex = 4;
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
            this.dgvListarCuentas.Size = new System.Drawing.Size(320, 138);
            this.dgvListarCuentas.TabIndex = 14;
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
            this.gbCuentas.Location = new System.Drawing.Point(3, 374);
            this.gbCuentas.Name = "gbCuentas";
            this.gbCuentas.Size = new System.Drawing.Size(332, 184);
            this.gbCuentas.TabIndex = 5;
            this.gbCuentas.TabStop = false;
            this.gbCuentas.Text = "Filtros de cuentas";
            // 
            // mskidCuenta
            // 
            this.mskidCuenta.Location = new System.Drawing.Point(110, 18);
            this.mskidCuenta.Name = "mskidCuenta";
            this.mskidCuenta.Size = new System.Drawing.Size(141, 20);
            this.mskidCuenta.TabIndex = 10;
            // 
            // cmbCategoriaDeCuentas
            // 
            this.cmbCategoriaDeCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDeCuentas.FormattingEnabled = true;
            this.cmbCategoriaDeCuentas.Location = new System.Drawing.Point(14, 107);
            this.cmbCategoriaDeCuentas.MaxDropDownItems = 10;
            this.cmbCategoriaDeCuentas.Name = "cmbCategoriaDeCuentas";
            this.cmbCategoriaDeCuentas.Size = new System.Drawing.Size(312, 21);
            this.cmbCategoriaDeCuentas.TabIndex = 14;
            // 
            // chkCategoriaDeCuentas
            // 
            this.chkCategoriaDeCuentas.Location = new System.Drawing.Point(14, 85);
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
            this.cmbGruposDeCuentas.Location = new System.Drawing.Point(14, 63);
            this.cmbGruposDeCuentas.Name = "cmbGruposDeCuentas";
            this.cmbGruposDeCuentas.Size = new System.Drawing.Size(312, 21);
            this.cmbGruposDeCuentas.TabIndex = 12;
            // 
            // chkGrupoDeCuentas
            // 
            this.chkGrupoDeCuentas.Location = new System.Drawing.Point(14, 41);
            this.chkGrupoDeCuentas.Name = "chkGrupoDeCuentas";
            this.chkGrupoDeCuentas.Size = new System.Drawing.Size(118, 24);
            this.chkGrupoDeCuentas.TabIndex = 11;
            this.chkGrupoDeCuentas.Text = "Grupo de Cuentas:";
            this.chkGrupoDeCuentas.UseVisualStyleBackColor = true;
            // 
            // txtDescCuenta
            // 
            this.txtDescCuenta.Location = new System.Drawing.Point(14, 150);
            this.txtDescCuenta.Name = "txtDescCuenta";
            this.txtDescCuenta.Size = new System.Drawing.Size(312, 20);
            this.txtDescCuenta.TabIndex = 16;
            // 
            // chkDescCuenta
            // 
            this.chkDescCuenta.Location = new System.Drawing.Point(14, 129);
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
            this.gbTransacciones.Location = new System.Drawing.Point(3, 564);
            this.gbTransacciones.Name = "gbTransacciones";
            this.gbTransacciones.Size = new System.Drawing.Size(332, 206);
            this.gbTransacciones.TabIndex = 7;
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
            this.cmbEstado.Location = new System.Drawing.Point(15, 174);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(295, 21);
            this.cmbEstado.TabIndex = 10;
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(15, 152);
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
            this.cmbTipoDeTransaccion.Location = new System.Drawing.Point(15, 131);
            this.cmbTipoDeTransaccion.Name = "cmbTipoDeTransaccion";
            this.cmbTipoDeTransaccion.Size = new System.Drawing.Size(295, 21);
            this.cmbTipoDeTransaccion.TabIndex = 8;
            // 
            // chkTipoDeTransaccion
            // 
            this.chkTipoDeTransaccion.Location = new System.Drawing.Point(15, 110);
            this.chkTipoDeTransaccion.Name = "chkTipoDeTransaccion";
            this.chkTipoDeTransaccion.Size = new System.Drawing.Size(137, 24);
            this.chkTipoDeTransaccion.TabIndex = 3;
            this.chkTipoDeTransaccion.Text = "Tipo de Transacción:";
            this.chkTipoDeTransaccion.UseVisualStyleBackColor = true;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(15, 83);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(295, 20);
            this.txtConcepto.TabIndex = 6;
            // 
            // chkConcepto
            // 
            this.chkConcepto.Location = new System.Drawing.Point(15, 61);
            this.chkConcepto.Name = "chkConcepto";
            this.chkConcepto.Size = new System.Drawing.Size(118, 24);
            this.chkConcepto.TabIndex = 4;
            this.chkConcepto.Text = "Concepto:";
            this.chkConcepto.UseVisualStyleBackColor = true;
            // 
            // txtNoTransaccion
            // 
            this.txtNoTransaccion.Location = new System.Drawing.Point(15, 39);
            this.txtNoTransaccion.Name = "txtNoTransaccion";
            this.txtNoTransaccion.Size = new System.Drawing.Size(295, 20);
            this.txtNoTransaccion.TabIndex = 7;
            // 
            // chkNoTransaccion
            // 
            this.chkNoTransaccion.Location = new System.Drawing.Point(15, 18);
            this.chkNoTransaccion.Name = "chkNoTransaccion";
            this.chkNoTransaccion.Size = new System.Drawing.Size(118, 24);
            this.chkNoTransaccion.TabIndex = 5;
            this.chkNoTransaccion.Text = "No. Transacción";
            this.chkNoTransaccion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTituloDelGrafico);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 776);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 91);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración del Grafico";
            // 
            // txtTituloDelGrafico
            // 
            this.txtTituloDelGrafico.Location = new System.Drawing.Point(10, 36);
            this.txtTituloDelGrafico.Name = "txtTituloDelGrafico";
            this.txtTituloDelGrafico.Size = new System.Drawing.Size(317, 20);
            this.txtTituloDelGrafico.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Titulo del Gráfico:";
            // 
            // frmGraficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 611);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGraficos";
            this.Text = "frmGraficos";
            this.Shown += new System.EventHandler(this.frmGraficos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chGraficos)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbFiltarPorFechas.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPeriodo.ResumeLayout(false);
            this.gbPeriodo.PerformLayout();
            this.msmenu.ResumeLayout(false);
            this.msmenu.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbCuentasBancarias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarCuentas)).EndInit();
            this.gbCuentas.ResumeLayout(false);
            this.gbCuentas.PerformLayout();
            this.gbTransacciones.ResumeLayout(false);
            this.gbTransacciones.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chGraficos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip msmenu;
        private System.Windows.Forms.ToolStripButton tsbFiltrarInformacion;
        private System.Windows.Forms.ToolStripDropDownButton tsbWindows;
        private System.Windows.Forms.ToolStripMenuItem tsbOcultarPanelDeDatos;
        private System.Windows.Forms.ToolStripButton tsbDerecha;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox gbPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPeriodoCerrado;
        private System.Windows.Forms.ComboBox cmbPeriodAños;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbListadoDeImpresiones;
        private System.Windows.Forms.CheckBox chkListadoDeImpriones;
        private System.Windows.Forms.GroupBox gbFiltarPorFechas;
        private System.Windows.Forms.DateTimePicker dtpkFecha2;
        private System.Windows.Forms.DateTimePicker dtpkFecha1;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.ToolStripMenuItem ocultarGraficoToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbCuentasBancarias;
        private System.Windows.Forms.DataGridView dgvListarCuentas;
        private System.Windows.Forms.CheckBox chkCuentas;
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
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.ComboBox cmbTipoDeTransaccion;
        private System.Windows.Forms.CheckBox chkTipoDeTransaccion;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.CheckBox chkConcepto;
        private System.Windows.Forms.TextBox txtNoTransaccion;
        private System.Windows.Forms.CheckBox chkNoTransaccion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTituloDelGrafico;
        private System.Windows.Forms.Label label3;
    }
}