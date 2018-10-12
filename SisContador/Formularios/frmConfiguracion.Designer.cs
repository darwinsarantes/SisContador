namespace SisContador.Formularios
{
    partial class frmConfiguracion
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
            this.tsBarraHarramientas = new System.Windows.Forms.ToolStrip();
            this.cmdGuardar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPathMySQL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPathMySQLDump = new System.Windows.Forms.Button();
            this.btnPathMySQL = new System.Windows.Forms.Button();
            this.txtMysqlDump = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCuentaPrincipalDeBanco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNivelesDeLaCuentas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdBuscarRuta = new System.Windows.Forms.Button();
            this.cmdBuscarRuta2 = new System.Windows.Forms.Button();
            this.txtRutaRespaldosBD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRutaExportacionArchivosExcel = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsBarraHarramientas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBarraHarramientas
            // 
            this.tsBarraHarramientas.BackColor = System.Drawing.Color.Transparent;
            this.tsBarraHarramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBarraHarramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdGuardar});
            this.tsBarraHarramientas.Location = new System.Drawing.Point(0, 0);
            this.tsBarraHarramientas.Name = "tsBarraHarramientas";
            this.tsBarraHarramientas.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsBarraHarramientas.Size = new System.Drawing.Size(751, 31);
            this.tsBarraHarramientas.TabIndex = 6;
            this.tsBarraHarramientas.Text = "toolStrip1";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = global::SisContador.Properties.Resources.Save24x24;
            this.cmdGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 28);
            this.cmdGuardar.Tag = "Guardar configuración";
            this.cmdGuardar.Text = "Guardar Datos";
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 329);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPathMySQL);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnPathMySQLDump);
            this.groupBox4.Controls.Add(this.btnPathMySQL);
            this.groupBox4.Controls.Add(this.txtMysqlDump);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox4.Location = new System.Drawing.Point(3, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(721, 111);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rutas para ejecutar los respaldos";
            // 
            // txtPathMySQL
            // 
            this.txtPathMySQL.Location = new System.Drawing.Point(8, 78);
            this.txtPathMySQL.Name = "txtPathMySQL";
            this.txtPathMySQL.Size = new System.Drawing.Size(670, 20);
            this.txtPathMySQL.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Configurar ruta del mysqldump:";
            // 
            // btnPathMySQLDump
            // 
            this.btnPathMySQLDump.Location = new System.Drawing.Point(683, 30);
            this.btnPathMySQLDump.Name = "btnPathMySQLDump";
            this.btnPathMySQLDump.Size = new System.Drawing.Size(24, 23);
            this.btnPathMySQLDump.TabIndex = 18;
            this.btnPathMySQLDump.Text = "...";
            this.btnPathMySQLDump.UseVisualStyleBackColor = true;
            this.btnPathMySQLDump.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPathMySQL
            // 
            this.btnPathMySQL.Location = new System.Drawing.Point(683, 76);
            this.btnPathMySQL.Name = "btnPathMySQL";
            this.btnPathMySQL.Size = new System.Drawing.Size(24, 23);
            this.btnPathMySQL.TabIndex = 18;
            this.btnPathMySQL.Text = "...";
            this.btnPathMySQL.UseVisualStyleBackColor = true;
            this.btnPathMySQL.Click += new System.EventHandler(this.btnPathMySQL_Click);
            // 
            // txtMysqlDump
            // 
            this.txtMysqlDump.Location = new System.Drawing.Point(7, 32);
            this.txtMysqlDump.Name = "txtMysqlDump";
            this.txtMysqlDump.Size = new System.Drawing.Size(670, 20);
            this.txtMysqlDump.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Configurar Ruta del mysql:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(33, 20);
            this.textBox3.TabIndex = 16;
            this.textBox3.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCuentaPrincipalDeBanco);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtNivelesDeLaCuentas);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(3, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(721, 78);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información de la cuenta:";
            // 
            // txtCuentaPrincipalDeBanco
            // 
            this.txtCuentaPrincipalDeBanco.Location = new System.Drawing.Point(180, 41);
            this.txtCuentaPrincipalDeBanco.MaxLength = 3;
            this.txtCuentaPrincipalDeBanco.Name = "txtCuentaPrincipalDeBanco";
            this.txtCuentaPrincipalDeBanco.Size = new System.Drawing.Size(100, 20);
            this.txtCuentaPrincipalDeBanco.TabIndex = 21;
            this.txtCuentaPrincipalDeBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuentaPrincipalDeBanco_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(11, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Cuenta principal de banco:";
            // 
            // txtNivelesDeLaCuentas
            // 
            this.txtNivelesDeLaCuentas.Location = new System.Drawing.Point(180, 16);
            this.txtNivelesDeLaCuentas.Name = "txtNivelesDeLaCuentas";
            this.txtNivelesDeLaCuentas.Size = new System.Drawing.Size(100, 20);
            this.txtNivelesDeLaCuentas.TabIndex = 19;
            this.txtNivelesDeLaCuentas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNivelesDeLaCuentas_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cantidad de niveles de la cuenta:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmdBuscarRuta);
            this.groupBox2.Controls.Add(this.cmdBuscarRuta2);
            this.groupBox2.Controls.Add(this.txtRutaRespaldosBD);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtRutaExportacionArchivosExcel);
            this.groupBox2.Controls.Add(this.txtId);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(721, 111);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rutas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(5, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(498, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ruta de red de Respaldos de base de datos (Ejemplo: \'\\\\SERVIDOR\\Carpeta Respaldos" +
    "\\SisContador\'):";
            // 
            // cmdBuscarRuta
            // 
            this.cmdBuscarRuta.Location = new System.Drawing.Point(683, 30);
            this.cmdBuscarRuta.Name = "cmdBuscarRuta";
            this.cmdBuscarRuta.Size = new System.Drawing.Size(24, 23);
            this.cmdBuscarRuta.TabIndex = 18;
            this.cmdBuscarRuta.Text = "...";
            this.cmdBuscarRuta.UseVisualStyleBackColor = true;
            this.cmdBuscarRuta.Click += new System.EventHandler(this.cmdBuscarRuta_Click);
            // 
            // cmdBuscarRuta2
            // 
            this.cmdBuscarRuta2.Location = new System.Drawing.Point(683, 76);
            this.cmdBuscarRuta2.Name = "cmdBuscarRuta2";
            this.cmdBuscarRuta2.Size = new System.Drawing.Size(24, 23);
            this.cmdBuscarRuta2.TabIndex = 18;
            this.cmdBuscarRuta2.Text = "...";
            this.cmdBuscarRuta2.UseVisualStyleBackColor = true;
            this.cmdBuscarRuta2.Click += new System.EventHandler(this.cmdBuscarRuta2_Click);
            // 
            // txtRutaRespaldosBD
            // 
            this.txtRutaRespaldosBD.Location = new System.Drawing.Point(7, 32);
            this.txtRutaRespaldosBD.Name = "txtRutaRespaldosBD";
            this.txtRutaRespaldosBD.Size = new System.Drawing.Size(670, 20);
            this.txtRutaRespaldosBD.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ruta de Exportación de archivos excel (Por defecto: \'C:\\SisContador_EXCEL\'):";
            // 
            // txtRutaExportacionArchivosExcel
            // 
            this.txtRutaExportacionArchivosExcel.Location = new System.Drawing.Point(8, 78);
            this.txtRutaExportacionArchivosExcel.Name = "txtRutaExportacionArchivosExcel";
            this.txtRutaExportacionArchivosExcel.Size = new System.Drawing.Size(670, 20);
            this.txtRutaExportacionArchivosExcel.TabIndex = 16;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(8, 32);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(33, 20);
            this.txtId.TabIndex = 16;
            this.txtId.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 371);
            this.Controls.Add(this.tsBarraHarramientas);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConfiguracion";
            this.Text = "Configuración general";
            this.Shown += new System.EventHandler(this.frmConfiguracion_Shown);
            this.tsBarraHarramientas.ResumeLayout(false);
            this.tsBarraHarramientas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBarraHarramientas;
        private System.Windows.Forms.ToolStripButton cmdGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdBuscarRuta;
        private System.Windows.Forms.Button cmdBuscarRuta2;
        private System.Windows.Forms.TextBox txtRutaRespaldosBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRutaExportacionArchivosExcel;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNivelesDeLaCuentas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPathMySQLDump;
        private System.Windows.Forms.Button btnPathMySQL;
        private System.Windows.Forms.TextBox txtMysqlDump;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPathMySQL;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCuentaPrincipalDeBanco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}