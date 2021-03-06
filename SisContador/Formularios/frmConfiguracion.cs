﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;
using Funciones;

namespace SisContador.Formularios
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        int IdConfiguracion = 1;
        frmCuentaOtrasConfiguraciones ofrmCuentaOtrasConfiguraciones = null;


        #region "Funciones"

        private void TraerInformacionDelRegistro() {

            try
            {

                ConfiguracionEN oRegistroEN = new ConfiguracionEN();
                ConfiguracionLN oRegistroLN = new ConfiguracionLN();

                oRegistroEN.IdConfiguracion = IdConfiguracion;

                if (oRegistroLN.ListadoPorIdentificador(oRegistroEN, Program.oDatosDeConexion))
                {

                    DataRow Fila = oRegistroLN.TraerDatos().Rows[0];

                    txtRutaRespaldosBD.Text = Fila["RutaRespaldos"].ToString();
                    txtRutaExportacionArchivosExcel.Text = Fila["RutaRespaldosDeExcel"].ToString();
                    txtNivelesDeLaCuentas.Text = Fila["NivelesDeLaCuenta"].ToString();
                    txtMysqlDump.Text = Fila["PathMysSQLDump"].ToString();
                    txtPathMySQL.Text = Fila["PathMySQL"].ToString();
                    txtCuentaPrincipalDeBanco.Text = Fila["CuentaPrincipalDeBanco"].ToString();
                    txtNombreDelSistema.Text = Fila["NombreDelSistema"].ToString();
                    txtUtilidadOPerdidaDelEjercicio.Text = Fila["UtilidadOPerdidaDelEjercicio"].ToString();
                    txtTiempoDeRespaldo.Text = Fila["TiempoDeRespaldo"].ToString();
                    txtCuentaQueSeVaOcultarNivel.Text = Fila["CuentaQueSeVaOcultarNivel"].ToString();
                    cmbNivelDeLaCuentaAOcultar.Text = Fila["NivelDeLaCuentaAOcultar"].ToString();
                    txtCuentaQueSeVaAMostrar.Text = Fila["CuentaQueSeVaAMostrar"].ToString();
                    cmbNivelDelaCuentaQueSeVaAMostrar.Text = Fila["NivelDelaCuentaQueSeVaAMostrar"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0} ", ex.Message), "Traer información del Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarInformacionDeLaConfiguracion(){

            try
            {

                ConfiguracionEN oRegistroEN = new ConfiguracionEN();
                ConfiguracionLN oRegistroLN = new ConfiguracionLN();

                oRegistroEN.IdConfiguracion = IdConfiguracion;

                if (oRegistroLN.ListadoPorIdentificador(oRegistroEN, Program.oDatosDeConexion))
                {

                    DataRow Fila = oRegistroLN.TraerDatos().Rows[0];

                    Program.oConfiguracionEN.RutaRespaldos = Fila["RutaRespaldos"].ToString();
                    Program.oConfiguracionEN.RutaRespaldosDeExcel = Fila["RutaRespaldosDeExcel"].ToString();
                    Program.oConfiguracionEN.NivelesDeLaCuenta = Convert.ToInt32(Fila["NivelesDeLaCuenta"].ToString());
                    Program.oConfiguracionEN.PathMysSQLDump = Fila["PathMysSQLDump"].ToString();
                    Program.oConfiguracionEN.PathMySQL = Fila["PathMySQL"].ToString();
                    Program.oConfiguracionEN.CuentaPrincipalDeBanco = Fila["CuentaPrincipalDeBanco"].ToString();
                    Program.oConfiguracionEN.NombreDelSistema = Fila["NombreDelSistema"].ToString();
                    Program.oConfiguracionEN.UtilidadOPerdidaDelEjercicio = Fila["UtilidadOPerdidaDelEjercicio"].ToString();
                    Program.oConfiguracionEN.TiempoDeRespaldo = Convert.ToInt32( Fila["TiempoDeRespaldo"].ToString());
                    Program.oConfiguracionEN.NivelDeLaCuentaAOcultar = Convert.ToInt32(Fila["NivelDeLaCuentaAOcultar"].ToString());
                    Program.oConfiguracionEN.CuentaQueSeVaOcultarNivel = Fila["CuentaQueSeVaOcultarNivel"].ToString();
                    Program.oConfiguracionEN.CuentaQueSeVaAMostrar = Fila["CuentaQueSeVaAMostrar"].ToString();
                    Program.oConfiguracionEN.NivelDelaCuentaQueSeVaAMostrar = Convert.ToInt32(Fila["NivelDelaCuentaQueSeVaAMostrar"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0} ", ex.Message), "Traer información del Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private ConfiguracionEN InformacionDelRegistro() {

            ConfiguracionEN oRegistroEN = null;

            try
            {
                oRegistroEN = new ConfiguracionEN();
                oRegistroEN.IdConfiguracion = IdConfiguracion;
                oRegistroEN.RutaRespaldos = txtRutaRespaldosBD.Text.Trim();
                oRegistroEN.RutaRespaldosDeExcel = txtRutaExportacionArchivosExcel.Text.Trim();
                oRegistroEN.NivelesDeLaCuenta = Convert.ToInt32(txtNivelesDeLaCuentas.Text);
                oRegistroEN.PathMysSQLDump = txtMysqlDump.Text.Trim();
                oRegistroEN.PathMySQL = txtPathMySQL.Text.Trim();
                oRegistroEN.CuentaPrincipalDeBanco = txtCuentaPrincipalDeBanco.Text;
                oRegistroEN.NombreDelSistema = txtNombreDelSistema.Text;
                oRegistroEN.UtilidadOPerdidaDelEjercicio = txtUtilidadOPerdidaDelEjercicio.Text.Trim();
                oRegistroEN.TiempoDeRespaldo = Convert.ToInt32(txtTiempoDeRespaldo.Text);
                oRegistroEN.oLoginEN = Program.oLoginEN;
                oRegistroEN.CuentaQueSeVaOcultarNivel = txtCuentaQueSeVaOcultarNivel.Text.Trim();
                oRegistroEN.NivelDeLaCuentaAOcultar = Convert.ToInt32(cmbNivelDeLaCuentaAOcultar.Text);
                oRegistroEN.CuentaQueSeVaAMostrar = txtCuentaQueSeVaAMostrar.Text.Trim();
                oRegistroEN.NivelDelaCuentaQueSeVaAMostrar = Convert.ToInt32(cmbNivelDelaCuentaQueSeVaAMostrar.Text);


                return oRegistroEN;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return oRegistroEN;

            }

        }

        private bool EvaluarSiHayRegistro()
        {
            errorProvider1.Clear();

            if (Controles.IsNullOEmptyElControl(txtNivelesDeLaCuentas))
            {
                errorProvider1.SetError(txtNivelesDeLaCuentas, "ESTE CAMPO NO PUEDE QUEDAR VACIO");
                txtNivelesDeLaCuentas.Focus();
                return true;
            }

            if(Convert.ToInt32(txtNivelesDeLaCuentas.Text) <= 0)
            {
                errorProvider1.SetError(txtNivelesDeLaCuentas, "El campo no puede contener valores en '0' o Negativos");
                txtNivelesDeLaCuentas.Focus();
                return true;
            }

            if (Controles.IsNullOEmptyElControl(txtCuentaPrincipalDeBanco))
            {
                errorProvider1.SetError(txtCuentaPrincipalDeBanco, "ESTE CAMPO NO PUEDE QUEDAR VACIO");
                txtCuentaPrincipalDeBanco.Focus();
                return true;
            }

            if(txtCuentaPrincipalDeBanco.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtCuentaPrincipalDeBanco, "Se debe de completar los 3 digitos de la cuenta principal");
                txtCuentaPrincipalDeBanco.Focus();
                return true;
            }

            if (txtUtilidadOPerdidaDelEjercicio.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtUtilidadOPerdidaDelEjercicio, "Se debe de completar los 3 digitos de la cuenta principal");
                txtUtilidadOPerdidaDelEjercicio.Focus();
                return true;
            }

            if (Controles.IsNullOEmptyElControl(txtTiempoDeRespaldo))
            {
                errorProvider1.SetError(txtTiempoDeRespaldo, "ESTE CAMPO NO PUEDE QUEDAR VACIO");
                txtTiempoDeRespaldo.Focus();
                return true;
            }

            if(Convert.ToInt32(txtTiempoDeRespaldo.Text) <= 0)
            {
                errorProvider1.SetError(txtTiempoDeRespaldo, "NO SE ACEPTAN VALORES NEGATIVOS/0");
                txtTiempoDeRespaldo.Focus();
                return true;
            }

            if (cmbNivelDeLaCuentaAOcultar.SelectedIndex >= 0 && Controles.IsNullOEmptyElControl(txtCuentaQueSeVaOcultarNivel))
            {
                errorProvider1.SetError(txtCuentaQueSeVaOcultarNivel, "SE DEBE DE INGRESAR EL NUMERO DE CUENTA");
                txtCuentaQueSeVaOcultarNivel.Focus();
                return true;
            }

            if (cmbNivelDeLaCuentaAOcultar.SelectedIndex < 0 && Controles.IsNullOEmptyElControl(txtCuentaQueSeVaOcultarNivel) == false){

                errorProvider1.SetError(cmbNivelDeLaCuentaAOcultar, "SE DEBE DE SELECCIONAR EL NIVEL PARA LA CUENTA");
                cmbNivelDeLaCuentaAOcultar.Focus();
                return true;

            }

            return false;
        }

        #endregion


        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (EvaluarSiHayRegistro())
                {
                    return;
                }

                ConfiguracionEN oRegistroEN = InformacionDelRegistro();
                ConfiguracionLN oRegistroLN = new ConfiguracionLN();

                if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexion))
                {
                    MessageBox.Show("Registro actualizado correctamente", "Guardar inforamción del registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInformacionDeLaConfiguracion();
                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Guardar Información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmConfiguracion_Shown(object sender, EventArgs e)
        {
            TraerInformacionDelRegistro();
            CargarInformacionDeLaConfiguracion();

            int NivelDelaCuenta = Convert.ToInt32(txtNivelesDeLaCuentas.Text);
            if (NivelDelaCuenta > 0)
            {
                cmbNivelDeLaCuentaAOcultar.Items.Clear();
                for (int i = 1; i <= NivelDelaCuenta; i++)
                {
                    cmbNivelDeLaCuentaAOcultar.Items.Add(i.ToString());
                }
               
                if (Program.oConfiguracionEN.NivelDeLaCuentaAOcultar > 0)
                {                   
                    cmbNivelDeLaCuentaAOcultar.Text = Program.oConfiguracionEN.NivelDeLaCuentaAOcultar.ToString();
                }
                else
                {
                    cmbNivelDeLaCuentaAOcultar.SelectedIndex = -1;
                }

                cmbNivelDelaCuentaQueSeVaAMostrar.Items.Clear();
                for (int i = 1; i <= NivelDelaCuenta; i++)
                {
                    cmbNivelDelaCuentaQueSeVaAMostrar.Items.Add(i.ToString());
                }

                if (Program.oConfiguracionEN.NivelDelaCuentaQueSeVaAMostrar > 0)
                {
                    cmbNivelDelaCuentaQueSeVaAMostrar.Text = Program.oConfiguracionEN.NivelDelaCuentaQueSeVaAMostrar.ToString();
                }
                else
                {
                    cmbNivelDelaCuentaQueSeVaAMostrar.SelectedIndex = -1;
                }
                
            }
            else
            {
                cmbNivelDeLaCuentaAOcultar.Items.Clear();
                cmbNivelDelaCuentaQueSeVaAMostrar.Items.Clear();
            }

        }

        private void cmdBuscarRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                txtRutaRespaldosBD.Text = folderBrowserDialog1.SelectedPath;
        }

        private void cmdBuscarRuta2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                txtRutaExportacionArchivosExcel.Text = folderBrowserDialog1.SelectedPath;
        }

        private void txtNivelesDeLaCuentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta (todo OK)
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta (si pulsas cualquier otra cosa pues no se envia)
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                txtMysqlDump.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnPathMySQL_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                txtPathMySQL.Text = folderBrowserDialog1.SelectedPath;
        }

        private void txtCuentaPrincipalDeBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta (todo OK)
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta (si pulsas cualquier otra cosa pues no se envia)
            }
        }

        private void txtUtilidadOPerdidaDelEjercicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta (todo OK)
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta (si pulsas cualquier otra cosa pues no se envia)
            }
        }

        private void txtTiempoDeRespaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta (todo OK)
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta (si pulsas cualquier otra cosa pues no se envia)
            }
        }

        private void mostrarCuentasEnElReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            if (ofrmCuentaOtrasConfiguraciones == null || ofrmCuentaOtrasConfiguraciones.IsDisposed)
            {
                ofrmCuentaOtrasConfiguraciones = new frmCuentaOtrasConfiguraciones();
                //ofrmCuentaOtrasConfiguraciones.MdiParent = this.MdiParent;                
                ofrmCuentaOtrasConfiguraciones.StartPosition = FormStartPosition.CenterScreen;
                ofrmCuentaOtrasConfiguraciones.WindowState = FormWindowState.Normal;
                ofrmCuentaOtrasConfiguraciones.ActivarFiltros = true;
                ofrmCuentaOtrasConfiguraciones.VariosRegistros = true;
                ofrmCuentaOtrasConfiguraciones.TituloVentana = "Mostrar cuentas en el reporte";
                ofrmCuentaOtrasConfiguraciones.TituloParaGroupoBox = "Filtro para Mostrar cuentas que van hacer agregadas al reporte";
                ofrmCuentaOtrasConfiguraciones.idTiposDeConfiguracion = 1;
                ofrmCuentaOtrasConfiguraciones.ShowDialog();
                ofrmCuentaOtrasConfiguraciones = null;

            }
            else
                ofrmCuentaOtrasConfiguraciones.BringToFront();

            this.Cursor = Cursors.Default;

        }

        private void noMostrarCuentasEnElReoprteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            if (ofrmCuentaOtrasConfiguraciones == null || ofrmCuentaOtrasConfiguraciones.IsDisposed)
            {
                ofrmCuentaOtrasConfiguraciones = new frmCuentaOtrasConfiguraciones();
                //ofrmCuentaOtrasConfiguraciones.MdiParent = this.MdiParent;                
                ofrmCuentaOtrasConfiguraciones.StartPosition = FormStartPosition.CenterScreen;
                ofrmCuentaOtrasConfiguraciones.WindowState = FormWindowState.Normal;
                ofrmCuentaOtrasConfiguraciones.ActivarFiltros = true;
                ofrmCuentaOtrasConfiguraciones.VariosRegistros = true;
                ofrmCuentaOtrasConfiguraciones.TituloVentana = "No Mostrar cuentas en el reporte";
                ofrmCuentaOtrasConfiguraciones.TituloParaGroupoBox = "Filtro para No Mostrar cuentas que van hacer agregadas al reporte";
                ofrmCuentaOtrasConfiguraciones.idTiposDeConfiguracion = 2;
                ofrmCuentaOtrasConfiguraciones.ShowDialog();
                ofrmCuentaOtrasConfiguraciones = null;

            }
            else
                ofrmCuentaOtrasConfiguraciones.BringToFront();

            this.Cursor = Cursors.Default;
        }
    }
}
