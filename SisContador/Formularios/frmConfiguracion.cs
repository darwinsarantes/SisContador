using System;
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
                oRegistroEN.oLoginEN = Program.oLoginEN;
                
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
    }
}
