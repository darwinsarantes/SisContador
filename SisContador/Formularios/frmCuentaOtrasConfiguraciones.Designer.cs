namespace SisContador.Formularios
{
    partial class frmCuentaOtrasConfiguraciones
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mskidCuenta = new System.Windows.Forms.MaskedTextBox();
            this.cmbCategoriaDeCuentas = new System.Windows.Forms.ComboBox();
            this.chkCategoriaDeCuentas = new System.Windows.Forms.CheckBox();
            this.chkIdCuenta = new System.Windows.Forms.CheckBox();
            this.cmbGruposDeCuentas = new System.Windows.Forms.ComboBox();
            this.chkGrupoDeCuentas = new System.Windows.Forms.CheckBox();
            this.txtDescCuenta = new System.Windows.Forms.TextBox();
            this.chkDescCuenta = new System.Windows.Forms.CheckBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.chkIdentificador = new System.Windows.Forms.CheckBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbNoRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbFiltrar = new System.Windows.Forms.ToolStripButton();
            this.tsbMarcarTodos = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(926, 533);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.mskidCuenta);
            this.groupBox1.Controls.Add(this.cmbCategoriaDeCuentas);
            this.groupBox1.Controls.Add(this.chkCategoriaDeCuentas);
            this.groupBox1.Controls.Add(this.chkIdCuenta);
            this.groupBox1.Controls.Add(this.cmbGruposDeCuentas);
            this.groupBox1.Controls.Add(this.chkGrupoDeCuentas);
            this.groupBox1.Controls.Add(this.txtDescCuenta);
            this.groupBox1.Controls.Add(this.chkDescCuenta);
            this.groupBox1.Controls.Add(this.txtIdentificador);
            this.groupBox1.Controls.Add(this.chkIdentificador);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar informacion de los grupos de cuentas";
            // 
            // mskidCuenta
            // 
            this.mskidCuenta.Location = new System.Drawing.Point(149, 31);
            this.mskidCuenta.Name = "mskidCuenta";
            this.mskidCuenta.Size = new System.Drawing.Size(237, 20);
            this.mskidCuenta.TabIndex = 2;
            this.mskidCuenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mskidCuenta_KeyUp);
            // 
            // cmbCategoriaDeCuentas
            // 
            this.cmbCategoriaDeCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDeCuentas.FormattingEnabled = true;
            this.cmbCategoriaDeCuentas.Location = new System.Drawing.Point(573, 31);
            this.cmbCategoriaDeCuentas.MaxDropDownItems = 10;
            this.cmbCategoriaDeCuentas.Name = "cmbCategoriaDeCuentas";
            this.cmbCategoriaDeCuentas.Size = new System.Drawing.Size(237, 21);
            this.cmbCategoriaDeCuentas.TabIndex = 6;
            this.cmbCategoriaDeCuentas.SelectionChangeCommitted += new System.EventHandler(this.cmbCategoriaDeCuentas_SelectionChangeCommitted);
            // 
            // chkCategoriaDeCuentas
            // 
            this.chkCategoriaDeCuentas.Location = new System.Drawing.Point(436, 29);
            this.chkCategoriaDeCuentas.Name = "chkCategoriaDeCuentas";
            this.chkCategoriaDeCuentas.Size = new System.Drawing.Size(141, 24);
            this.chkCategoriaDeCuentas.TabIndex = 5;
            this.chkCategoriaDeCuentas.Text = "Categoria de Cuentas:";
            this.chkCategoriaDeCuentas.UseVisualStyleBackColor = true;
            this.chkCategoriaDeCuentas.CheckedChanged += new System.EventHandler(this.chkCategoriaDeCuentas_CheckedChanged);
            // 
            // chkIdCuenta
            // 
            this.chkIdCuenta.Location = new System.Drawing.Point(25, 29);
            this.chkIdCuenta.Name = "chkIdCuenta";
            this.chkIdCuenta.Size = new System.Drawing.Size(92, 24);
            this.chkIdCuenta.TabIndex = 1;
            this.chkIdCuenta.Text = "No. Cuenta:";
            this.chkIdCuenta.UseVisualStyleBackColor = true;
            // 
            // cmbGruposDeCuentas
            // 
            this.cmbGruposDeCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGruposDeCuentas.FormattingEnabled = true;
            this.cmbGruposDeCuentas.Location = new System.Drawing.Point(149, 59);
            this.cmbGruposDeCuentas.Name = "cmbGruposDeCuentas";
            this.cmbGruposDeCuentas.Size = new System.Drawing.Size(237, 21);
            this.cmbGruposDeCuentas.TabIndex = 4;
            this.cmbGruposDeCuentas.SelectionChangeCommitted += new System.EventHandler(this.cmbGruposDeCuentas_SelectionChangeCommitted);
            // 
            // chkGrupoDeCuentas
            // 
            this.chkGrupoDeCuentas.Location = new System.Drawing.Point(25, 57);
            this.chkGrupoDeCuentas.Name = "chkGrupoDeCuentas";
            this.chkGrupoDeCuentas.Size = new System.Drawing.Size(118, 24);
            this.chkGrupoDeCuentas.TabIndex = 3;
            this.chkGrupoDeCuentas.Text = "Grupo de Cuentas:";
            this.chkGrupoDeCuentas.UseVisualStyleBackColor = true;
            this.chkGrupoDeCuentas.CheckedChanged += new System.EventHandler(this.chkGrupoDeCuentas_CheckedChanged);
            // 
            // txtDescCuenta
            // 
            this.txtDescCuenta.Location = new System.Drawing.Point(573, 59);
            this.txtDescCuenta.Name = "txtDescCuenta";
            this.txtDescCuenta.Size = new System.Drawing.Size(237, 20);
            this.txtDescCuenta.TabIndex = 8;
            this.txtDescCuenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescCuenta_KeyUp);
            // 
            // chkDescCuenta
            // 
            this.chkDescCuenta.Location = new System.Drawing.Point(436, 57);
            this.chkDescCuenta.Name = "chkDescCuenta";
            this.chkDescCuenta.Size = new System.Drawing.Size(92, 24);
            this.chkDescCuenta.TabIndex = 7;
            this.chkDescCuenta.Text = "Descripcion:";
            this.chkDescCuenta.UseVisualStyleBackColor = true;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(573, 97);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(237, 20);
            this.txtIdentificador.TabIndex = 1;
            this.txtIdentificador.Visible = false;
            this.txtIdentificador.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtIdentificador_KeyUp);
            // 
            // chkIdentificador
            // 
            this.chkIdentificador.Location = new System.Drawing.Point(436, 95);
            this.chkIdentificador.Name = "chkIdentificador";
            this.chkIdentificador.Size = new System.Drawing.Size(92, 24);
            this.chkIdentificador.TabIndex = 0;
            this.chkIdentificador.Text = "Identificador:";
            this.chkIdentificador.UseVisualStyleBackColor = true;
            this.chkIdentificador.Visible = false;
            // 
            // dgvLista
            // 
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(0, 31);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(926, 365);
            this.dgvLista.TabIndex = 10;
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            this.dgvLista.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvLista_CellContextMenuStripNeeded);
            this.dgvLista.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvLista_CurrentCellDirtyStateChanged);
            this.dgvLista.DoubleClick += new System.EventHandler(this.dgvLista_DoubleClick);
            this.dgvLista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvLista_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNoRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(926, 22);
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
            this.tsbMarcarTodos});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(926, 31);
            this.tsMenu.TabIndex = 9;
            this.tsMenu.Text = "Filtrar";
            // 
            // tsbFiltrar
            // 
            this.tsbFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltrar.Image = global::SisContador.Properties.Resources.Save24x24;
            this.tsbFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltrar.Name = "tsbFiltrar";
            this.tsbFiltrar.Size = new System.Drawing.Size(28, 28);
            this.tsbFiltrar.Text = "Filtrar";
            this.tsbFiltrar.ToolTipText = "Filtrar (F5)";
            this.tsbFiltrar.Click += new System.EventHandler(this.tsbFiltrar_Click);
            // 
            // tsbMarcarTodos
            // 
            this.tsbMarcarTodos.Image = global::SisContador.Properties.Resources.checked16x16;
            this.tsbMarcarTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMarcarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMarcarTodos.Name = "tsbMarcarTodos";
            this.tsbMarcarTodos.Size = new System.Drawing.Size(93, 28);
            this.tsbMarcarTodos.Text = "Marca todos";
            this.tsbMarcarTodos.Click += new System.EventHandler(this.tsbMarcarTodos_Click);
            // 
            // frmCuentaOtrasConfiguraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 533);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "frmCuentaOtrasConfiguraciones";
            this.Text = "Grupos de cuentas";
            this.Load += new System.EventHandler(this.frmCuentaOtrasConfiguraciones_Load);
            this.Shown += new System.EventHandler(this.frmCuentaOtrasConfiguraciones_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCuentaOtrasConfiguraciones_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGruposDeCuentas;
        private System.Windows.Forms.CheckBox chkGrupoDeCuentas;
        private System.Windows.Forms.TextBox txtDescCuenta;
        private System.Windows.Forms.CheckBox chkDescCuenta;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.CheckBox chkIdentificador;
        private System.Windows.Forms.ToolStripButton tsbMarcarTodos;
        private System.Windows.Forms.ComboBox cmbCategoriaDeCuentas;
        private System.Windows.Forms.CheckBox chkCategoriaDeCuentas;
        private System.Windows.Forms.CheckBox chkIdCuenta;
        private System.Windows.Forms.MaskedTextBox mskidCuenta;
    }
}