namespace SisContador.Formularios
{
    partial class frmInformacionDeLaCuenta
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
            this.gpInformacion = new System.Windows.Forms.GroupBox();
            this.txtDescCuentaContenido = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskidCuenta = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdCuenta = new System.Windows.Forms.TextBox();
            this.txtDescCuenta = new System.Windows.Forms.TextBox();
            this.tsMenuClear = new System.Windows.Forms.ToolStrip();
            this.cmbGrupoDeCuenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.cmbCategoriaDeLaCuenta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.gpCuentaAsociada = new System.Windows.Forms.GroupBox();
            this.txtIdentificadorAsociado = new System.Windows.Forms.TextBox();
            this.txtDescricpcionDeLaCuentaAsociada = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCuentaAsociadaIdCuenta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gpInformacion.SuspendLayout();
            this.gpCuentaAsociada.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpInformacion
            // 
            this.gpInformacion.Controls.Add(this.txtDescCuentaContenido);
            this.gpInformacion.Controls.Add(this.label9);
            this.gpInformacion.Controls.Add(this.mskidCuenta);
            this.gpInformacion.Controls.Add(this.label6);
            this.gpInformacion.Controls.Add(this.txtIdCuenta);
            this.gpInformacion.Controls.Add(this.txtDescCuenta);
            this.gpInformacion.Controls.Add(this.tsMenuClear);
            this.gpInformacion.Controls.Add(this.cmbGrupoDeCuenta);
            this.gpInformacion.Controls.Add(this.label2);
            this.gpInformacion.Controls.Add(this.label5);
            this.gpInformacion.Controls.Add(this.label3);
            this.gpInformacion.Controls.Add(this.txtSaldo);
            this.gpInformacion.Controls.Add(this.cmbCategoriaDeLaCuenta);
            this.gpInformacion.Controls.Add(this.label4);
            this.gpInformacion.Controls.Add(this.label1);
            this.gpInformacion.Controls.Add(this.txtIdentificador);
            this.gpInformacion.Controls.Add(this.gpCuentaAsociada);
            this.gpInformacion.Location = new System.Drawing.Point(12, 12);
            this.gpInformacion.Name = "gpInformacion";
            this.gpInformacion.Size = new System.Drawing.Size(432, 458);
            this.gpInformacion.TabIndex = 19;
            this.gpInformacion.TabStop = false;
            // 
            // txtDescCuentaContenido
            // 
            this.txtDescCuentaContenido.Location = new System.Drawing.Point(11, 235);
            this.txtDescCuentaContenido.Multiline = true;
            this.txtDescCuentaContenido.Name = "txtDescCuentaContenido";
            this.txtDescCuentaContenido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescCuentaContenido.Size = new System.Drawing.Size(406, 83);
            this.txtDescCuentaContenido.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(268, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Descripción de la información que contendra la cuenta:";
            // 
            // mskidCuenta
            // 
            this.mskidCuenta.Location = new System.Drawing.Point(139, 15);
            this.mskidCuenta.Name = "mskidCuenta";
            this.mskidCuenta.Size = new System.Drawing.Size(276, 20);
            this.mskidCuenta.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "No. de Cuenta:";
            // 
            // txtIdCuenta
            // 
            this.txtIdCuenta.Location = new System.Drawing.Point(391, 173);
            this.txtIdCuenta.Name = "txtIdCuenta";
            this.txtIdCuenta.Size = new System.Drawing.Size(26, 20);
            this.txtIdCuenta.TabIndex = 33;
            this.txtIdCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCuenta.Visible = false;
            // 
            // txtDescCuenta
            // 
            this.txtDescCuenta.Location = new System.Drawing.Point(139, 95);
            this.txtDescCuenta.Multiline = true;
            this.txtDescCuenta.Name = "txtDescCuenta";
            this.txtDescCuenta.Size = new System.Drawing.Size(278, 72);
            this.txtDescCuenta.TabIndex = 24;
            // 
            // tsMenuClear
            // 
            this.tsMenuClear.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMenuClear.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsMenuClear.Location = new System.Drawing.Point(391, 39);
            this.tsMenuClear.Name = "tsMenuClear";
            this.tsMenuClear.Size = new System.Drawing.Size(1, 0);
            this.tsMenuClear.TabIndex = 32;
            this.tsMenuClear.Text = "toolStrip2";
            // 
            // cmbGrupoDeCuenta
            // 
            this.cmbGrupoDeCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoDeCuenta.FormattingEnabled = true;
            this.cmbGrupoDeCuenta.Location = new System.Drawing.Point(139, 42);
            this.cmbGrupoDeCuenta.Name = "cmbGrupoDeCuenta";
            this.cmbGrupoDeCuenta.Size = new System.Drawing.Size(276, 21);
            this.cmbGrupoDeCuenta.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Descripción de la cuenta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Saldo de la cuenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Grupo de Cuenta:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(139, 173);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(278, 31);
            this.txtSaldo.TabIndex = 26;
            // 
            // cmbCategoriaDeLaCuenta
            // 
            this.cmbCategoriaDeLaCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaDeLaCuenta.FormattingEnabled = true;
            this.cmbCategoriaDeLaCuenta.Location = new System.Drawing.Point(139, 68);
            this.cmbCategoriaDeLaCuenta.Name = "cmbCategoriaDeLaCuenta";
            this.cmbCategoriaDeLaCuenta.Size = new System.Drawing.Size(278, 21);
            this.cmbCategoriaDeLaCuenta.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Categoria de la cuenta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Identificador";
            this.label1.Visible = false;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(280, 15);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(64, 20);
            this.txtIdentificador.TabIndex = 25;
            this.txtIdentificador.Visible = false;
            // 
            // gpCuentaAsociada
            // 
            this.gpCuentaAsociada.Controls.Add(this.txtIdentificadorAsociado);
            this.gpCuentaAsociada.Controls.Add(this.txtDescricpcionDeLaCuentaAsociada);
            this.gpCuentaAsociada.Controls.Add(this.label8);
            this.gpCuentaAsociada.Controls.Add(this.txtCuentaAsociadaIdCuenta);
            this.gpCuentaAsociada.Controls.Add(this.label7);
            this.gpCuentaAsociada.Location = new System.Drawing.Point(9, 328);
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
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(327, 476);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(114, 23);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.Text = "Cerrar ventana";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmInformacionDeLaCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 506);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gpInformacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "frmInformacionDeLaCuenta";
            this.Text = "frmInformacionDeLaCuenta";
            this.Shown += new System.EventHandler(this.frmInformacionDeLaCuenta_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInformacionDeLaCuenta_KeyDown);
            this.gpInformacion.ResumeLayout(false);
            this.gpInformacion.PerformLayout();
            this.gpCuentaAsociada.ResumeLayout(false);
            this.gpCuentaAsociada.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpInformacion;
        private System.Windows.Forms.GroupBox gpCuentaAsociada;
        private System.Windows.Forms.TextBox txtIdentificadorAsociado;
        private System.Windows.Forms.TextBox txtDescricpcionDeLaCuentaAsociada;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCuentaAsociadaIdCuenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtDescCuentaContenido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskidCuenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdCuenta;
        private System.Windows.Forms.TextBox txtDescCuenta;
        private System.Windows.Forms.ToolStrip tsMenuClear;
        private System.Windows.Forms.ComboBox cmbGrupoDeCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.ComboBox cmbCategoriaDeLaCuenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentificador;
    }
}