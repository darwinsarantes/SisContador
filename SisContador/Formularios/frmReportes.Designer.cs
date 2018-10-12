namespace SisContador.Formularios
{
    partial class frmReportes
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
            this.ssBarraDeEstado = new System.Windows.Forms.StatusStrip();
            this.lblCantidadRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtListadoDeReportes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListadoDeReportes = new System.Windows.Forms.DataGridView();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Consultar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDesmarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbFiltarPorFechas = new System.Windows.Forms.GroupBox();
            this.dtpkFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpkFecha1 = new System.Windows.Forms.DateTimePicker();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCuentas = new System.Windows.Forms.CheckBox();
            this.dgvListarCuentas = new System.Windows.Forms.DataGridView();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ssBarraDeEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDeReportes)).BeginInit();
            this.MenuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbFiltarPorFechas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtListadoDeReportes);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvListadoDeReportes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(896, 526);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 0;
            // 
            // ssBarraDeEstado
            // 
            this.ssBarraDeEstado.BackColor = System.Drawing.Color.White;
            this.ssBarraDeEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCantidadRegistros});
            this.ssBarraDeEstado.Location = new System.Drawing.Point(0, 531);
            this.ssBarraDeEstado.Name = "ssBarraDeEstado";
            this.ssBarraDeEstado.Size = new System.Drawing.Size(896, 22);
            this.ssBarraDeEstado.TabIndex = 7;
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(86, 17);
            this.lblCantidadRegistros.Text = "№. Registros: 0";
            // 
            // txtListadoDeReportes
            // 
            this.txtListadoDeReportes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListadoDeReportes.Location = new System.Drawing.Point(12, 26);
            this.txtListadoDeReportes.Name = "txtListadoDeReportes";
            this.txtListadoDeReportes.Size = new System.Drawing.Size(315, 20);
            this.txtListadoDeReportes.TabIndex = 15;
            this.txtListadoDeReportes.TextChanged += new System.EventHandler(this.txtListadoDeReportes_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filtrar reporte por nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Listado de Reportes";
            // 
            // dgvListadoDeReportes
            // 
            this.dgvListadoDeReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListadoDeReportes.BackgroundColor = System.Drawing.Color.White;
            this.dgvListadoDeReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListadoDeReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoDeReportes.Location = new System.Drawing.Point(12, 70);
            this.dgvListadoDeReportes.Name = "dgvListadoDeReportes";
            this.dgvListadoDeReportes.Size = new System.Drawing.Size(315, 443);
            this.dgvListadoDeReportes.TabIndex = 12;
            this.dgvListadoDeReportes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoDeReportes_CellClick);
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
            this.splitContainer2.Panel2.Controls.Add(this.dgvListar);
            this.splitContainer2.Size = new System.Drawing.Size(553, 526);
            this.splitContainer2.SplitterDistance = 251;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.gbFiltarPorFechas);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(553, 251);
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
            // 
            // dtpkFecha1
            // 
            this.dtpkFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFecha1.Location = new System.Drawing.Point(10, 23);
            this.dtpkFecha1.Name = "dtpkFecha1";
            this.dtpkFecha1.Size = new System.Drawing.Size(146, 20);
            this.dtpkFecha1.TabIndex = 6;
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
            this.groupBox1.Controls.Add(this.dgvListarCuentas);
            this.groupBox1.Controls.Add(this.chkCuentas);
            this.groupBox1.Location = new System.Drawing.Point(3, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
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
            this.dgvListarCuentas.Size = new System.Drawing.Size(315, 138);
            this.dgvListarCuentas.TabIndex = 14;
            // 
            // dgvListar
            // 
            this.dgvListar.BackgroundColor = System.Drawing.Color.White;
            this.dgvListar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListar.Location = new System.Drawing.Point(0, 0);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.Size = new System.Drawing.Size(553, 271);
            this.dgvListar.TabIndex = 15;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 553);
            this.Controls.Add(this.ssBarraDeEstado);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Shown += new System.EventHandler(this.frmReportes_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ssBarraDeEstado.ResumeLayout(false);
            this.ssBarraDeEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDeReportes)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbFiltarPorFechas.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtListadoDeReportes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListarCuentas;
        private System.Windows.Forms.CheckBox chkCuentas;
        private System.Windows.Forms.DataGridView dgvListar;
    }
}