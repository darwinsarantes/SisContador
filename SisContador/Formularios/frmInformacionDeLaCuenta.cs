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
    public partial class frmInformacionDeLaCuenta : Form
    {
        public String idCuenta { set; get; }
        public Int32 NoCuenta { set; get; }

        #region Funciones Propias

        private void LLenarGrupoDeCuentas()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                GrupoDeCuentasEN oRegistroEN = new GrupoDeCuentasEN();
                GrupoDeCuentasLN oRegistroLN = new GrupoDeCuentasLN();
                oRegistroEN.Where = "";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexion))
                {
                    cmbGrupoDeCuenta.DataSource = oRegistroLN.TraerDatos();
                    cmbGrupoDeCuenta.DisplayMember = "DescGrupoDeCuentas";
                    cmbGrupoDeCuenta.ValueMember = "idGrupoDeCuentas";
                    cmbGrupoDeCuenta.SelectedIndex = -1;

                }
                else { throw new ArgumentException(oRegistroLN.Error); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del grupo de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void LLenarCategoriasAsociadasAlasCuentas()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                CategoriaDeCuentaEN oRegistroEN = new CategoriaDeCuentaEN();
                CategoriaDeCuentaLN oRegistroLN = new CategoriaDeCuentaLN();
                oRegistroEN.Where = "";

                if (Controles.IsNullOEmptyElControl(cmbGrupoDeCuenta) == false)
                {
                    oRegistroEN.Where += string.Format(" and cc.idGrupoDeCuentas = {0}", cmbGrupoDeCuenta.SelectedValue);
                }

                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexion))
                {
                    cmbCategoriaDeLaCuenta.DataSource = oRegistroLN.TraerDatos();
                    cmbCategoriaDeLaCuenta.DisplayMember = "DescCategoriaDeCuenta";
                    cmbCategoriaDeLaCuenta.ValueMember = "idCategoriaDeCuenta";
                    cmbCategoriaDeLaCuenta.SelectedIndex = -1;

                }
                else { throw new ArgumentException(oRegistroLN.Error); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de las categorias asociadas a los grupos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void LlenarCamposDesdeBaseDatosSegunID()
        {
            this.Cursor = Cursors.WaitCursor;

            CuentaEN oRegistrosEN = new CuentaEN();
            CuentaLN oRegistrosLN = new CuentaLN();

            oRegistrosEN.idCuenta = idCuenta;

            if (oRegistrosLN.ListadoPorIdCuenta(oRegistrosEN, Program.oDatosDeConexion))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {
                    int NivelCuenta;
                    int idTipoDeCuenta;

                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtIdentificador.Text = Fila["NoCuenta"].ToString();
                    mskidCuenta.Text = Fila["idCuenta"].ToString();
                    txtIdCuenta.Text = ExtraerCadenaDelaMascar(mskidCuenta);
                    cmbGrupoDeCuenta.SelectedValue = Convert.ToInt32(Fila["idGrupoDeCuentas"].ToString());
                    cmbCategoriaDeLaCuenta.SelectedValue = Convert.ToInt32(Fila["idCategoriaDeCuenta"].ToString());
                    txtDescCuenta.Text = Fila["DescCuenta"].ToString();
                    cmbGrupoDeCuenta.SelectedValue = Convert.ToInt32(Fila["idGrupoDeCuentas"].ToString());
                    NivelCuenta = Convert.ToInt32(Fila["NivelCuenta"]);
                    txtIdentificadorAsociado.Text = Fila["CuentaMadre"].ToString();
                    idTipoDeCuenta = Convert.ToInt32(Fila["idTipoDeCuenta"].ToString());
                    txtSaldo.Text = string.Format("{0:###,###,###.0#}",Convert.ToDecimal( Fila["SaldoCuenta"].ToString()));
                    txtDescCuentaContenido.Text = Fila["DescCuentaContenido"].ToString();

                    //Traer informacion sobre la cuenta a la que esta asociada el registro.....
                    TraerInformacionDeLaCuentaAsociada();

                    if (NivelCuenta > 1)
                    {
                        cmbCategoriaDeLaCuenta.Enabled = false;
                        cmbGrupoDeCuenta.Enabled = false;
                    }

                    oRegistrosEN = null;
                    oRegistrosLN = null;

                }
                else
                {
                    string Mensaje;
                    Mensaje = string.Format("El registro solicitado de {0} no ha sido encontrado."
                                            + "\n\r-----Causas---- "
                                            + "\n\r1. Este registro pudo haber sido eliminado por otro usuario."
                                            + "\n\r2. El listado no está actualizado.", idCuenta);

                    MessageBox.Show(Mensaje, "Listado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    oRegistrosEN = null;
                    oRegistrosLN = null;

                    this.Close();
                }

            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(oRegistrosLN.Error, "Listado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                oRegistrosEN = null;
                oRegistrosLN = null;
            }

            this.Cursor = Cursors.Default;
        }

        private void TraerInformacionDeLaCuentaAsociada()
        {
            try
            {
                if (Controles.IsNullOEmptyElControl(txtIdentificadorAsociado) == false && Convert.ToInt32(txtIdentificadorAsociado.Text) > 0)
                {
                    CuentaEN oRegistroEN = new CuentaEN();
                    oRegistroEN.NoCuenta = Convert.ToInt32(txtIdentificador.Text);
                    oRegistroEN.CuentaMadre = txtIdentificadorAsociado.Text.Trim();

                    CuentaLN oRegistroLN = new CuentaLN();

                    if (oRegistroLN.TraerInformacionDelAsociado(oRegistroEN, Program.oDatosDeConexion))
                    {

                        if (oRegistroLN.TraerDatos().Rows.Count > 0)
                        {
                            gpCuentaAsociada.Visible = true;

                            DataRow Fila = oRegistroLN.TraerDatos().Rows[0];

                            txtDescricpcionDeLaCuentaAsociada.Text = Fila["DescCuenta"].ToString();
                            txtCuentaAsociadaIdCuenta.Text = Fila["idCuenta"].ToString();

                        }
                        else
                        {
                            gpCuentaAsociada.Visible = false;
                        }

                    }
                    else
                    {
                        throw new ArgumentException(oRegistroLN.Error);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de cuenta asociada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtraerCadenaDelaMascar(MaskedTextBox mascara)
        {
            string valor = "";

            string Cadena = mascara.Text;
            string[] ACadena = Cadena.Split('-');

            foreach (string cad in ACadena)
            {
                string cad1 = cad.Trim();
                if (string.IsNullOrEmpty(cad1) == false || cad1.Trim().Length > 0)
                {
                    if (string.IsNullOrEmpty(valor) || valor.Trim().Length == 0)
                    {
                        valor = cad1.Trim();
                    }
                    else
                    {
                        valor = string.Format("{0}-{1}", valor.Trim(), cad1.Trim());
                    }

                }

            }

            return valor;
        }



        #endregion

        private void ConfigurarVentana()
        {
            try
            {
                gpInformacion.Enabled = false;

                LLenarGrupoDeCuentas();
                LLenarCategoriasAsociadasAlasCuentas();

                LlenarCamposDesdeBaseDatosSegunID();



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Información sobre las cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public frmInformacionDeLaCuenta()
        {
            InitializeComponent();
        }

        private void frmInformacionDeLaCuenta_Shown(object sender, EventArgs e)
        {
            ConfigurarVentana();
        }

        private void frmInformacionDeLaCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
