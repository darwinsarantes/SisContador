namespace SisContador.Formularios
{
    partial class frmCuentaOperacion
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescCuentaContenido = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskidCuenta = new System.Windows.Forms.MaskedTextBox();
            this.gpCuentaAsociada = new System.Windows.Forms.GroupBox();
            this.txtIdentificadorAsociado = new System.Windows.Forms.TextBox();
            this.txtDescricpcionDeLaCuentaAsociada = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCuentaAsociadaIdCuenta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdCuenta = new System.Windows.Forms.TextBox();
            this.txtDescCuenta = new System.Windows.Forms.TextBox();
            this.tsMenuClear = new System.Windows.Forms.ToolStrip();
            this.tsbLimpiarCombo = new System.Windows.Forms.ToolStripButton();
            this.cmbGrupoDeCuenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.cmbCategoriaDeLaCuenta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mskBuscarFiltro = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbLimpiarCampos = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrarVentan = new System.Windows.Forms.ToolStripButton();
            this.tsbRecarRegistro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbAutorizarModificación = new System.Windows.Forms.ToolStripButton();
            this.chkCerrarVentana = new System.Windows.Forms.CheckBox();
            this.EP = new System.Windows.Forms.ErrorProvider(this.components);
            this.InformacionEntidadOperacion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpCuentaAsociada.SuspendLayout();
            this.tsMenuClear.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(991, 444);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(13, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 382);
            this.panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 14);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(934, 352);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescCuentaContenido);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.mskidCuenta);
            this.groupBox2.Controls.Add(this.gpCuentaAsociada);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIdCuenta);
            this.groupBox2.Controls.Add(this.txtDescCuenta);
            this.groupBox2.Controls.Add(this.tsMenuClear);
            this.groupBox2.Controls.Add(this.cmbGrupoDeCuenta);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtSaldo);
            this.groupBox2.Controls.Add(this.cmbCategoriaDeLaCuenta);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtIdentificador);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 439);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // txtDescCuentaContenido
            // 
            this.txtDescCuentaContenido.Location = new System.Drawing.Point(9, 220);
            this.txtDescCuentaContenido.Multiline = true;
            this.txtDescCuentaContenido.Name = "txtDescCuentaContenido";
            this.txtDescCuentaContenido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescCuentaContenido.Size = new System.Drawing.Size(406, 83);
            this.txtDescCuentaContenido.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(268, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Descripción de la información que contendra la cuenta:";
            // 
            // mskidCuenta
            // 
            this.mskidCuenta.Location = new System.Drawing.Point(137, 12);
            this.mskidCuenta.Name = "mskidCuenta";
            this.mskidCuenta.Size = new System.Drawing.Size(276, 20);
            this.mskidCuenta.TabIndex = 1;
            this.mskidCuenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mskidCuenta_KeyUp);
            // 
            // gpCuentaAsociada
            // 
            this.gpCuentaAsociada.Controls.Add(this.txtIdentificadorAsociado);
            this.gpCuentaAsociada.Controls.Add(this.txtDescricpcionDeLaCuentaAsociada);
            this.gpCuentaAsociada.Controls.Add(this.label8);
            this.gpCuentaAsociada.Controls.Add(this.txtCuentaAsociadaIdCuenta);
            this.gpCuentaAsociada.Controls.Add(this.label7);
            this.gpCuentaAsociada.Location = new System.Drawing.Point(9, 309);
            this.gpCuentaAsociada.Name = "gpCuentaAsociada";
            this.gpCuentaAsociada.Size = new System.Drawing.Size(415, 120);
            this.gpCuentaAsociada.TabIndex = 18;
            this.gpCuentaAsociada.TabStop = false;
            this.gpCuentaAsociada.Text = "La Cuenta es asociada:";
            this.gpCuentaAsociada.Visible = false;
            // 
            // txtIdentificadorAsociado
            // 
            this.txtIdentificadorAsociado.Location = new System.Drawing.Point(211, 18);
            this.txtIdentificadorAsociado.Name = "txtIdentificadorAsociado";
            this.txtIdentificadorAsociado.Size = new System.Drawing.Size(61, 20);
            this.txtIdentificadorAsociado.TabIndex = 22;
            this.txtIdentificadorAsociado.Visible = false;
            // 
            // txtDescricpcionDeLaCuentaAsociada
            // 
            this.txtDescricpcionDeLaCuentaAsociada.Location = new System.Drawing.Point(144, 43);
            this.txtDescricpcionDeLaCuentaAsociada.Multiline = true;
            this.txtDescricpcionDeLaCuentaAsociada.Name = "txtDescricpcionDeLaCuentaAsociada";
            this.txtDescricpcionDeLaCuentaAsociada.Size = new System.Drawing.Size(262, 72);
            this.txtDescricpcionDeLaCuentaAsociada.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Descripción de la cuenta:";
            // 
            // txtCuentaAsociadaIdCuenta
            // 
            this.txtCuentaAsociadaIdCuenta.Location = new System.Drawing.Point(144, 18);
            this.txtCuentaAsociadaIdCuenta.Name = "txtCuentaAsociadaIdCuenta";
            this.txtCuentaAsociadaIdCuenta.Size = new System.Drawing.Size(61, 20);
            this.txtCuentaAsociadaIdCuenta.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "No. de Cuenta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "No. de Cuenta:";
            // 
            // txtIdCuenta
            // 
            this.txtIdCuenta.Location = new System.Drawing.Point(230, 170);
            this.txtIdCuenta.Name = "txtIdCuenta";
            this.txtIdCuenta.Size = new System.Drawing.Size(185, 20);
            this.txtIdCuenta.TabIndex = 16;
            this.txtIdCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCuenta.Visible = false;
            this.txtIdCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCuenta_KeyPress);
            this.txtIdCuenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtIdCuenta_KeyUp);
            // 
            // txtDescCuenta
            // 
            this.txtDescCuenta.Location = new System.Drawing.Point(137, 92);
            this.txtDescCuenta.Multiline = true;
            this.txtDescCuenta.Name = "txtDescCuenta";
            this.txtDescCuenta.Size = new System.Drawing.Size(278, 72);
            this.txtDescCuenta.TabIndex = 4;
            // 
            // tsMenuClear
            // 
            this.tsMenuClear.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMenuClear.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLimpiarCombo});
            this.tsMenuClear.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsMenuClear.Location = new System.Drawing.Point(389, 36);
            this.tsMenuClear.Name = "tsMenuClear";
            this.tsMenuClear.Size = new System.Drawing.Size(25, 27);
            this.tsMenuClear.TabIndex = 15;
            this.tsMenuClear.Text = "toolStrip2";
            // 
            // tsbLimpiarCombo
            // 
            this.tsbLimpiarCombo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLimpiarCombo.Image = global::SisContador.Properties.Resources.clear20x20;
            this.tsbLimpiarCombo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLimpiarCombo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLimpiarCombo.Name = "tsbLimpiarCombo";
            this.tsbLimpiarCombo.Size = new System.Drawing.Size(24, 24);
            this.tsbLimpiarCombo.Text = "toolStripButton1";
            this.tsbLimpiarCombo.Click += new System.EventHandler(this.tsbLimpiarCombo_Click);
            // 
            // cmbGrupoDeCuenta
            // 
            this.cmbGrupoDeCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoDeCuenta.FormattingEnabled = true;
            this.cmbGrupoDeCuenta.Location = new System.Drawing.Point(137, 39);
            this.cmbGrupoDeCuenta.Name = "cmbGrupoDeCuenta";
            this.cmbGrupoDeCuenta.Size = new System.Drawing.Size(249, 21);
            this.cmbGrupoDeCuenta.TabIndex = 2;
            this.cmbGrupoDeCuenta.SelectionChangeCommitted += new System.EventHandler(this.cmbGrupoDeCuenta_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción de la cuenta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Saldo de la cuenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Grupo de Cuenta:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(137, 170);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(64, 20);
            this.txtSaldo.TabIndex = 5;
            // 
            // cmbCategoriaDeLaCuenta
            // 
            this.cmbCategoriaDeLaCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDeLaCuenta.FormattingEnabled = true;
            this.cmbCategoriaDeLaCuenta.Location = new System.Drawing.Point(137, 65);
            this.cmbCategoriaDeLaCuenta.Name = "cmbCategoriaDeLaCuenta";
            this.cmbCategoriaDeLaCuenta.Size = new System.Drawing.Size(278, 21);
            this.cmbCategoriaDeLaCuenta.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Categoria de la cuenta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Identificador";
            this.label1.Visible = false;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(278, 12);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(64, 20);
            this.txtIdentificador.TabIndex = 4;
            this.txtIdentificador.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mskBuscarFiltro);
            this.groupBox1.Controls.Add(this.toolStrip3);
            this.groupBox1.Controls.Add(this.dgvLista);
            this.groupBox1.Location = new System.Drawing.Point(459, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 190);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cuentas: ";
            // 
            // mskBuscarFiltro
            // 
            this.mskBuscarFiltro.Location = new System.Drawing.Point(138, 19);
            this.mskBuscarFiltro.Name = "mskBuscarFiltro";
            this.mskBuscarFiltro.Size = new System.Drawing.Size(276, 20);
            this.mskBuscarFiltro.TabIndex = 6;
            this.mskBuscarFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mskBuscarFiltro_KeyUp);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(444, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(124, 22);
            this.toolStripLabel1.Text = "Filtar cuenta a asociar:";
            // 
            // dgvLista
            // 
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(6, 44);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(438, 140);
            this.dgvLista.TabIndex = 7;
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            this.dgvLista.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLista_CurrentCellDirtyStateChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardar,
            this.tsbActualizar,
            this.tsbEliminar,
            this.tsbLimpiarCampos,
            this.tsbCerrarVentan,
            this.tsbRecarRegistro,
            this.toolStripSeparator1,
            this.tsbImprimir,
            this.tsbAutorizarModificación});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(991, 31);
            this.toolStrip1.TabIndex = 5;
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
            this.tsbGuardar.ToolTipText = "Guardar registro (Ctrl + G)";
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
            this.tsbActualizar.ToolTipText = "Actualizar registro (Ctrl + G)";
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
            this.tsbEliminar.ToolTipText = "Eliminar registro (Ctrl + E)";
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
            this.tsbLimpiarCampos.ToolTipText = "Nuevo registro (Ctrl + N)";
            this.tsbLimpiarCampos.Click += new System.EventHandler(this.tsbLimpiarCampos_Click);
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
            this.tsbImprimir.ToolTipText = "Imprimir (Ctrl + P)";
            this.tsbImprimir.Visible = false;
            // 
            // tsbAutorizarModificación
            // 
            this.tsbAutorizarModificación.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAutorizarModificación.Image = global::SisContador.Properties.Resources.checked16x16;
            this.tsbAutorizarModificación.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutorizarModificación.Name = "tsbAutorizarModificación";
            this.tsbAutorizarModificación.Size = new System.Drawing.Size(148, 28);
            this.tsbAutorizarModificación.Text = "Autorizar modificación";
            this.tsbAutorizarModificación.ToolTipText = "Autorizar modificación de registros vinculados";
            this.tsbAutorizarModificación.Click += new System.EventHandler(this.tsbAutorizarModificación_Click);
            // 
            // chkCerrarVentana
            // 
            this.chkCerrarVentana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCerrarVentana.AutoSize = true;
            this.chkCerrarVentana.Location = new System.Drawing.Point(12, 487);
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
            // frmCuentaOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1015, 515);
            this.Controls.Add(this.InformacionEntidadOperacion);
            this.Controls.Add(this.chkCerrarVentana);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmCuentaOperacion";
            this.Text = "frmCuentaOperacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCuentaOperacion_FormClosing);
            this.Shown += new System.EventHandler(this.frmCuentaOperacion_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCuentaOperacion_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpCuentaAsociada.ResumeLayout(false);
            this.gpCuentaAsociada.PerformLayout();
            this.tsMenuClear.ResumeLayout(false);
            this.tsMenuClear.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbGrupoDeCuenta;
        private System.Windows.Forms.TextBox txtDescCuenta;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider EP;
        private System.Windows.Forms.Label InformacionEntidadOperacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategoriaDeLaCuenta;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.ToolStrip tsMenuClear;
        private System.Windows.Forms.ToolStripButton tsbLimpiarCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdCuenta;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gpCuentaAsociada;
        private System.Windows.Forms.TextBox txtIdentificadorAsociado;
        private System.Windows.Forms.TextBox txtDescricpcionDeLaCuentaAsociada;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCuentaAsociadaIdCuenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.MaskedTextBox mskidCuenta;
        private System.Windows.Forms.MaskedTextBox mskBuscarFiltro;
        private System.Windows.Forms.ToolStripButton tsbAutorizarModificación;
        private System.Windows.Forms.TextBox txtDescCuentaContenido;
        private System.Windows.Forms.Label label9;
    }
}