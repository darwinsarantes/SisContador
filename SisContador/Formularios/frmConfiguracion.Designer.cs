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
            this.tsbOtrasConfiguraciones = new System.Windows.Forms.ToolStripDropDownButton();
            this.mostrarCuentasEnElReporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noMostrarCuentasEnElReoprteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasParaElTotalDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasParaElTotalDeCostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreDelSistema = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPathMySQL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPathMySQLDump = new System.Windows.Forms.Button();
            this.btnPathMySQL = new System.Windows.Forms.Button();
            this.txtMysqlDump = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtCuentaQueSeVaAMostrar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbNivelDelaCuentaQueSeVaAMostrar = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCuentaQueSeVaOcultarNivel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbNivelDeLaCuentaAOcultar = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTiempoDeRespaldo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUtilidadOPerdidaDelEjercicio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsBarraHarramientas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsBarraHarramientas
            // 
            this.tsBarraHarramientas.BackColor = System.Drawing.Color.Transparent;
            this.tsBarraHarramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBarraHarramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdGuardar,
            this.tsbOtrasConfiguraciones});
            this.tsBarraHarramientas.Location = new System.Drawing.Point(0, 0);
            this.tsBarraHarramientas.Name = "tsBarraHarramientas";
            this.tsBarraHarramientas.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsBarraHarramientas.Size = new System.Drawing.Size(801, 31);
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
            // tsbOtrasConfiguraciones
            // 
            this.tsbOtrasConfiguraciones.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbOtrasConfiguraciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOtrasConfiguraciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarCuentasEnElReporteToolStripMenuItem,
            this.noMostrarCuentasEnElReoprteToolStripMenuItem,
            this.cuentasParaElTotalDeVentaToolStripMenuItem,
            this.cuentasParaElTotalDeCostoToolStripMenuItem});
            this.tsbOtrasConfiguraciones.Image = global::SisContador.Properties.Resources.ajustes16x16;
            this.tsbOtrasConfiguraciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOtrasConfiguraciones.Name = "tsbOtrasConfiguraciones";
            this.tsbOtrasConfiguraciones.Size = new System.Drawing.Size(29, 28);
            this.tsbOtrasConfiguraciones.Text = "Mas Configuraciones";
            // 
            // mostrarCuentasEnElReporteToolStripMenuItem
            // 
            this.mostrarCuentasEnElReporteToolStripMenuItem.Name = "mostrarCuentasEnElReporteToolStripMenuItem";
            this.mostrarCuentasEnElReporteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.mostrarCuentasEnElReporteToolStripMenuItem.Text = "Mostrar cuentas en el reporte";
            this.mostrarCuentasEnElReporteToolStripMenuItem.Click += new System.EventHandler(this.mostrarCuentasEnElReporteToolStripMenuItem_Click);
            // 
            // noMostrarCuentasEnElReoprteToolStripMenuItem
            // 
            this.noMostrarCuentasEnElReoprteToolStripMenuItem.Name = "noMostrarCuentasEnElReoprteToolStripMenuItem";
            this.noMostrarCuentasEnElReoprteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.noMostrarCuentasEnElReoprteToolStripMenuItem.Text = "No Mostrar cuentas en el reoprte";
            this.noMostrarCuentasEnElReoprteToolStripMenuItem.Click += new System.EventHandler(this.noMostrarCuentasEnElReoprteToolStripMenuItem_Click);
            // 
            // cuentasParaElTotalDeVentaToolStripMenuItem
            // 
            this.cuentasParaElTotalDeVentaToolStripMenuItem.Name = "cuentasParaElTotalDeVentaToolStripMenuItem";
            this.cuentasParaElTotalDeVentaToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.cuentasParaElTotalDeVentaToolStripMenuItem.Text = "Cuentas para el total de venta";
            // 
            // cuentasParaElTotalDeCostoToolStripMenuItem
            // 
            this.cuentasParaElTotalDeCostoToolStripMenuItem.Name = "cuentasParaElTotalDeCostoToolStripMenuItem";
            this.cuentasParaElTotalDeCostoToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.cuentasParaElTotalDeCostoToolStripMenuItem.Text = "Cuentas para el total de costo";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 479);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtNombreDelSistema);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox5.Location = new System.Drawing.Point(3, 386);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(771, 67);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Información del Sistema";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(5, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nombre interno del Sistema";
            // 
            // txtNombreDelSistema
            // 
            this.txtNombreDelSistema.Location = new System.Drawing.Point(7, 32);
            this.txtNombreDelSistema.Name = "txtNombreDelSistema";
            this.txtNombreDelSistema.ReadOnly = true;
            this.txtNombreDelSistema.Size = new System.Drawing.Size(670, 20);
            this.txtNombreDelSistema.TabIndex = 16;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(8, 32);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(33, 20);
            this.textBox4.TabIndex = 16;
            this.textBox4.Visible = false;
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
            this.groupBox4.Location = new System.Drawing.Point(3, 275);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(771, 111);
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
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.txtTiempoDeRespaldo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtUtilidadOPerdidaDelEjercicio);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtCuentaPrincipalDeBanco);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtNivelesDeLaCuentas);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(3, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(771, 148);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información de la cuenta:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtCuentaQueSeVaAMostrar);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.cmbNivelDelaCuentaQueSeVaAMostrar);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Location = new System.Drawing.Point(552, 10);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(204, 103);
            this.groupBox7.TabIndex = 26;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Nivel de la cuenta que mostraremos";
            // 
            // txtCuentaQueSeVaAMostrar
            // 
            this.txtCuentaQueSeVaAMostrar.Location = new System.Drawing.Point(118, 60);
            this.txtCuentaQueSeVaAMostrar.MaxLength = 3;
            this.txtCuentaQueSeVaAMostrar.Name = "txtCuentaQueSeVaAMostrar";
            this.txtCuentaQueSeVaAMostrar.Size = new System.Drawing.Size(76, 20);
            this.txtCuentaQueSeVaAMostrar.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(6, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Número de Cuenta:";
            // 
            // cmbNivelDelaCuentaQueSeVaAMostrar
            // 
            this.cmbNivelDelaCuentaQueSeVaAMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelDelaCuentaQueSeVaAMostrar.FormattingEnabled = true;
            this.cmbNivelDelaCuentaQueSeVaAMostrar.Location = new System.Drawing.Point(118, 35);
            this.cmbNivelDelaCuentaQueSeVaAMostrar.Name = "cmbNivelDelaCuentaQueSeVaAMostrar";
            this.cmbNivelDelaCuentaQueSeVaAMostrar.Size = new System.Drawing.Size(76, 21);
            this.cmbNivelDelaCuentaQueSeVaAMostrar.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(6, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Nivel de la Cuenta";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtCuentaQueSeVaOcultarNivel);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.cmbNivelDeLaCuentaAOcultar);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Location = new System.Drawing.Point(342, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(204, 103);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Asociar el nivel de la cuenta que no quiere mostrar";
            // 
            // txtCuentaQueSeVaOcultarNivel
            // 
            this.txtCuentaQueSeVaOcultarNivel.Location = new System.Drawing.Point(118, 60);
            this.txtCuentaQueSeVaOcultarNivel.MaxLength = 3;
            this.txtCuentaQueSeVaOcultarNivel.Name = "txtCuentaQueSeVaOcultarNivel";
            this.txtCuentaQueSeVaOcultarNivel.Size = new System.Drawing.Size(76, 20);
            this.txtCuentaQueSeVaOcultarNivel.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(6, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Número de Cuenta:";
            // 
            // cmbNivelDeLaCuentaAOcultar
            // 
            this.cmbNivelDeLaCuentaAOcultar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelDeLaCuentaAOcultar.FormattingEnabled = true;
            this.cmbNivelDeLaCuentaAOcultar.Location = new System.Drawing.Point(118, 35);
            this.cmbNivelDeLaCuentaAOcultar.Name = "cmbNivelDeLaCuentaAOcultar";
            this.cmbNivelDeLaCuentaAOcultar.Size = new System.Drawing.Size(76, 21);
            this.cmbNivelDeLaCuentaAOcultar.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(6, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Nivel de la Cuenta";
            // 
            // txtTiempoDeRespaldo
            // 
            this.txtTiempoDeRespaldo.Location = new System.Drawing.Point(209, 93);
            this.txtTiempoDeRespaldo.MaxLength = 3;
            this.txtTiempoDeRespaldo.Name = "txtTiempoDeRespaldo";
            this.txtTiempoDeRespaldo.Size = new System.Drawing.Size(100, 20);
            this.txtTiempoDeRespaldo.TabIndex = 25;
            this.txtTiempoDeRespaldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiempoDeRespaldo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(11, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Tiempo de respaldo de la base datos:";
            // 
            // txtUtilidadOPerdidaDelEjercicio
            // 
            this.txtUtilidadOPerdidaDelEjercicio.Location = new System.Drawing.Point(209, 67);
            this.txtUtilidadOPerdidaDelEjercicio.MaxLength = 3;
            this.txtUtilidadOPerdidaDelEjercicio.Name = "txtUtilidadOPerdidaDelEjercicio";
            this.txtUtilidadOPerdidaDelEjercicio.Size = new System.Drawing.Size(100, 20);
            this.txtUtilidadOPerdidaDelEjercicio.TabIndex = 23;
            this.txtUtilidadOPerdidaDelEjercicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUtilidadOPerdidaDelEjercicio_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(11, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Cuenta - Utilidad o perdida del ejercicio:";
            // 
            // txtCuentaPrincipalDeBanco
            // 
            this.txtCuentaPrincipalDeBanco.Location = new System.Drawing.Point(209, 41);
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
            this.txtNivelesDeLaCuentas.Location = new System.Drawing.Point(209, 16);
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
            this.groupBox2.Size = new System.Drawing.Size(771, 111);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SisContador.Properties.Resources.ajustes16x16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 521);
            this.Controls.Add(this.tsBarraHarramientas);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConfiguracion";
            this.Text = "Configuración general";
            this.Shown += new System.EventHandler(this.frmConfiguracion_Shown);
            this.tsBarraHarramientas.ResumeLayout(false);
            this.tsBarraHarramientas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreDelSistema;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtUtilidadOPerdidaDelEjercicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTiempoDeRespaldo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtCuentaQueSeVaOcultarNivel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbNivelDeLaCuentaAOcultar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtCuentaQueSeVaAMostrar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbNivelDelaCuentaQueSeVaAMostrar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripDropDownButton tsbOtrasConfiguraciones;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem mostrarCuentasEnElReporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noMostrarCuentasEnElReoprteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentasParaElTotalDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentasParaElTotalDeCostoToolStripMenuItem;
    }
}