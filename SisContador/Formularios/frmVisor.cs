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
using SisContador.Reportes;

namespace SisContador.Formularios
{
    public partial class frmVisor : Form
    {
        public frmVisor()
        {
            InitializeComponent();
        }

        private CrystalDecisions.CrystalReports.Engine.ReportDocument RPT;
        public string NombreReporte { get; set; }
        public string SubTituloFiltros { set; get; }
        public object Entidad { set; get; }
        public int AplicarBorder { set; get; }

        public DataTable oTablas { set; get; }

        DataSet DS;
        private void LlenarParametros(string[,] Parametros)
        {
            
            for (int i = 0; i < Parametros.GetLength(0); i++) //Recorremos la dimención de la primera dimensión
                for (int j = 0; j < Parametros.GetLength(1);) //Recorremos la dimensión de la segunda dimensión
                {
                    //Asignamos los parámetros a la variable RPT, que contiene una instancia del reporte a mostrar
                    RPT.SetParameterValue(Parametros[i, j], Parametros[i, j + 1]);
                    break;
                }

        }

        private DataSet AgregarTablaADataSet(DataTable DT, string Tabla)
        {
            if (DS == null)
            {
                DS = new DataSet("DataSet");
            }

            DS.Tables.Add(DT);
            DS.Tables[DS.Tables.Count - 1].TableName = Tabla;
            return DS;
        }

        private void AgregarTablaEmpresaADataSet()
        {
            EmpresaEN oRegistroEN = new EmpresaEN();
            EmpresaLN oRegistroLN = new EmpresaLN();
            DataSet DS = new DataSet();
                        
            oRegistroEN.IdEmpresa = 1;
            oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexion);

            AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoEmpresa");
        }

        private void frmVista_Load(object sender, EventArgs e)
        {

            switch (this.NombreReporte)
            {

                case "Cuentas - Catalogo":
                    ImprimirCuentasCatalogoDeCuentas();
                    break;

                case "Cuentas - Catalogo en Dolares":
                    ImprimirCuentasCatalogoDeCuentasEnDolares();
                    break;

                case "Cuentas - Movimientos del Mes":
                    ImprimirCuentasCatalogoDeCuentas();
                    break;

                case "Cuentas - Listado completo":
                    ImprimirListadoDeCuentasCompletos();
                    break;

                case "Cuentas - Traer Saldos":
                    ImprimirListadoDeCuentasConSuSaldo();
                    break;

                case "Cuentas - Traer Saldos en Dolares":
                    ImprimirListadoDeCuentasConSuSaldoEnDolares();
                    break;

                case "Cuentas - Traer Saldos Detallado":
                    ImprimirListadoDeCuentasConSuSaldoDetallado();
                    break;

                case "Cuentas - Traer Saldos Detallado en Dalores":
                    ImprimirListadoDeCuentasConSuSaldoDetalladoEnDolares();
                    break;

                case "Cuentas - Auxiliar del Mayor":
                    ImprimirAuxiliarDelMayor();
                    break;

                case "Cuentas - Auxiliar del Mayor en Dolares":
                    ImprimirAuxiliarDelMayorEnDolares();
                    break;

                case "Cuentas - Auxiliar del Mayor desde el Historico":
                    ImprimirAuxiliarDelMayorDesdeElHistorico();
                    break;

                case "Cuentas - Auxiliar del Mayor desde el Historico en Dolares":
                    ImprimirAuxiliarDelMayorDesdeElHistoricoEnDolares();
                    break;

                case "Transacciones - Listado":
                    ImprimirTransaccionesListado();
                    break;

                case "Transacciones - Listado en Dolares":
                    ImprimirTransaccionesListadoEnDolares();
                    break;

                case "Historico - Listado en Dolares":
                    ImprimirHistoricoListadoEnDolares();
                    break;

                case "Historico - Listado de movimientos":
                    ImprimirHistoricoListado();
                    break;

                case "Transacciones - Imprimir comprobante":
                    ImprimirTransaccionesImprimirComprobante();
                    break;

                case "Reportes - Libro de banco":
                    ImprimirLibroDeBanco();
                    break;

                case "Reportes - Libro de banco en Dolares":
                    ImprimirLibroDeBancoEnDolares();
                    break;

                case "Cuentas - Traer Saldos Detallado por categoria":
                    ImpirmirBalanceGeneralDetallado();
                    break;

                case "Cuentas - Balance General en Dolares":
                    ImpirmirBalanceGeneralDetalladoEnDolares();
                    break;

                case "Cuentas - Estado de Resultado":
                    ImprimirEstadoDeResultado();
                    break;

                case "Cuentas - Estado de Resultado Consolidado en dolares":
                    ImprimirEstadoDeResultadoEnDolares();
                    break;

                case "Historioco - Estado de Resultado":
                    ImprimirEstadoDeResultadoHistorico();
                    break;

                case "Historioco - Estado de Resultado en dolares":
                    ImprimirEstadoDeResultadoHistoricoEnDolares();
                    break;

                case "Cuentas - Estado de Resultado del mes":
                    ImprimirEstadoDeResultadoDelMes();
                    break;

                case "Cuentas - Estado de Resultado del mes en dolares":
                    ImprimirEstadoDeResultadoDelMesEnDolares();
                    break;

                case "Historico - Estado de Resultado del mes":
                    ImprimirEstadoDeResultadoDelMesHistorico();
                    break;

                case "Historico - Estado de Resultado del mes en Dolares":
                    ImprimirEstadoDeResultadoDelMesHistoricoEnDolares();
                    break;

                case "Historico - Balance General Historico":
                    ImpirmirBalanceGeneralDetalladoParaHistorico();
                    break;

                case "Historico - Balance General Historico en Dolares":
                    ImpirmirBalanceGeneralDetalladoParaHistoricoEnDolares();
                    break;

                case "Historico - Balanza de comprobación":
                    ImprimirBalanzaDeComprobacionParaELHistorico();
                    break;

                case "Historico - Balanza de comprobación en dolares":
                    ImprimirBalanzaDeComprobacionParaELHistoricoEnDolares();
                    break;

                case "Historico - Recapitulacion":
                    ImprimirRecapitulacionesDelHistorico();
                    break;

                case "Historico - Recapitulacion en dolares":
                    ImprimirRecapitulacionesDelHistoricoEnDolares();
                    break;

                case "Cuentas - Balanza de comprobación":
                    ImprimirBalanzaDeComprobacion();
                    break;

                case "Cuentas - Balanza de comprobación Dolares":
                    ImprimirBalanzaDeComprobacionEnDolares();
                    break;

                case "Cuentas - Recapitulacion":
                    ImprimirRecapitulaciones();
                    break;
                    
                case "Cuentas - Recapitulacion en Dolares":
                    ImprimirRecapitulacionesEnDolares();
                    break;

                case "Movimientos - Imprimir comprobante Historico":
                    ImprimirTransaccionesImprimirComprobanteParaRegistroDelHistorico();
                    break;

                case "Movimientos - Imprimir comprobante Historico en Dolares":
                    ImprimirTransaccionesImprimirComprobanteParaRegistroDelHistoricoEnDolares();
                    break;

                default:
                    MessageBox.Show("No existe código asociado al reporte solicitado: " + this.NombreReporte, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }

        }

        private void ImprimirCuentasCatalogoDeCuentas()
        {
            try
            {

                CuentaEN oRegistroEN = new CuentaEN();
                CuentaLN oRegistroLN = new CuentaLN();

                oRegistroEN = (CuentaEN)this.Entidad;

                if (oRegistroLN.ListadoDeMovimientosDelDiaPorCuenta(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptListadoDeMovimientosDelMesPorCuenta();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoDeMovimientosDelDiaPorCuenta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "MOVIMIENTOS DE CUENTA EN EL MES" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString()} });
                    this.Text = "Movimientos del Mes";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Movimientos del mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirCuentasCatalogoDeCuentasEnDolares()
        {
            try
            {

                CuentaEN oRegistroEN = new CuentaEN();
                CuentaLN oRegistroLN = new CuentaLN();

                oRegistroEN = (CuentaEN)this.Entidad;

                if (oRegistroLN.ListadoDeMovimientosDelDiaPorCuenta(oRegistroEN, Program.oDatosDeConexion))
                {
                    DataTable oDatosTabla = oRegistroLN.TraerDatos();

                    foreach (DataRow Fila in oDatosTabla.Rows)
                    {

                        decimal Debe = Convert.ToDecimal(Fila["Debe"]) / oRegistroEN.TasaDeCambio;
                        decimal Haber = Convert.ToDecimal(Fila["Haber"]) / oRegistroEN.TasaDeCambio;
                        
                        Fila["Debe"] = Debe;
                        Fila["Haber"] = Haber;                       

                    }


                    RPT = new rptListadoDeMovimientosDelMesPorCuenta();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "ListadoDeMovimientosDelDiaPorCuenta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Movimientos del Mes";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Movimientos del mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirListadoDeCuentasCompletos()
        {
            try
            {

                CuentaEN oRegistroEN = new CuentaEN();
                CuentaLN oRegistroLN = new CuentaLN();

                oRegistroEN = (CuentaEN)this.Entidad;

                if (oRegistroLN.ListadoCompletoDeLasCuentas(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptListaDeCuentasCompleta();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoCompletoDeLasCuentas"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "LISTADO DE CUENTAS COMPLETO" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de cuentas completo";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de cuentas completo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirListadoDeCuentasConSuSaldo()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDelasCuentas(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerElSaldoActual();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "TraerElSaldoActual"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "LISTADO DE SALDOS" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de saldos";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de saldos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirListadoDeCuentasConSuSaldoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDelasCuentas(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual";
                    DataTable oDatosTabla = FormatearADolares( oRegistroLN.TraerDatos(), Columnas,oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptTraerElSaldoActual();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "TraerElSaldoActual"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de saldos";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de saldos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirListadoDeCuentasConSuSaldoDetallado()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDelasCuentas(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerElSaldoActualDetallado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "TraerElSaldoActual"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "LISTADO DE SALDOS" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de saldos";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de saldos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirListadoDeCuentasConSuSaldoDetalladoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDelasCuentas(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptTraerElSaldoActualDetallado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "TraerElSaldoActual"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de saldos";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de saldos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirListadoDeCuentasConSuSaldoDetalladoFull()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDelasCuentasFull(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerElSaldoActualDetalladoPorGrupo();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "SALDOS POR CUENTA" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "SALDOS POR CUENTA";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Saldos por cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImpirmirBalanceGeneralDetallado()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalcularBalanceGeneralDeManeraDetalla(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptBalanceGeneralDetallado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "BalanceGeneralCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "BALACEN GENERAL" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "BALANCE GENERAL DETALLADO";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balance general detallado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImpirmirBalanceGeneralDetalladoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalcularBalanceGeneralDeManeraDetalla(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptBalanceGeneralDetallado();
                    AgregarTablaEmpresaADataSet();

                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,TotalActivo";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "BalanceGeneralCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "BALACEN GENERAL" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "BALANCE GENERAL DETALLADO";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balance general detallado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImpirmirBalanceGeneralDetalladoParaHistorico()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalcularBalanceGeneralParaELHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptBalanceGeneralDetallado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "BalanceGeneralCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "BALACEN GENERAL" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format( "Balance General al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balance general detallado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImpirmirBalanceGeneralDetalladoParaHistoricoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalcularBalanceGeneralParaELHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "UitilidadBruta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,TotalActivo";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptBalanceGeneralDetallado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "BalanceGeneralCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balance General al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balance general detallado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultado()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDelasCuentasFull(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "ESTADO DE RESULTADO ACUMULADO" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado ACUMULADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultadoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDelasCuentasFull(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();

                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,UitilidadBruta";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte}, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado ACUMULADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultadoHistorico()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerElEstadoDeResultadoPorRangoDeFecha(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "ESTADO DE RESULTADO ACUMULADO" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado ACUMULADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultadoHistoricoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerElEstadoDeResultadoPorRangoDeFecha(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoActual,UitilidadBruta,HaberTMP,DebeTMP,SaldoAlUltimoCierre";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado ACUMULADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultadoDelMes()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerEstadoDeResultadoDelalMes(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "ESTADO DE RESULTADO DEL MES ACTUAL" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado del mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultadoDelMesEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerEstadoDeResultadoDelalMes(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();

                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,UitilidadBruta";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado del mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultadoDelMesHistorico()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CuentasDeResultadoAlMesCorrienteUsandoHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "ESTADO DE RESULTADO DEL MES ACTUAL" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado del mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirEstadoDeResultadoDelMesHistoricoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CuentasDeResultadoAlMesCorrienteUsandoHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoActual,UitilidadBruta,HaberTMP,DebeTMP,SaldoAlUltimoCierre";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptTraerEstadoDeResultado();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "TraerElSaldoActualCompleta"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Estado de Resultado al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Estado de resultado del mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ImprimirBalanzaDeComprobacion()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularBalanzaDeComprobacion(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptBalanzaDeComprobacion();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "BalanzaDeComprobacion"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "BALANZA DE COMPROBACIÓN" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balanza de comprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirBalanzaDeComprobacionEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularBalanzaDeComprobacion(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,UitilidadBruta";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptBalanzaDeComprobacion();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "BalanzaDeComprobacion"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balanza de comprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirBalanzaDeComprobacionParaELHistorico()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularBalanzaDeComprobacionParaElHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptBalanzaDeComprobacion();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "BalanzaDeComprobacion"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "BALANZA DE COMPROBACIÓN" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balanza de comprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirBalanzaDeComprobacionParaELHistoricoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularBalanzaDeComprobacionParaElHistorico(oRegistroEN, Program.oDatosDeConexion))
                {

                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,UitilidadBruta";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);

                    RPT = new rptBalanzaDeComprobacion();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "BalanzaDeComprobacion"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Balanza de comprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirRecapitulaciones()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularRecapitulaciones(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptRecapitulaciones();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "CalCularRecapitulaciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", string.Format( "RECAPITULACIÓN DEL MES DE {0}" , DateTime.Now.Month) }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Recapitulaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirRecapitulacionesEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularRecapitulaciones(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,UitilidadBruta";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);

                    RPT = new rptRecapitulaciones();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "CalCularRecapitulaciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", DateTime.Now.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Recapitulaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirRecapitulacionesDelHistorico()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularRecapitulacionesParaHistorico(oRegistroEN, Program.oDatosDeConexion))
                {

                    RPT = new rptRecapitulaciones();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "CalCularRecapitulaciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Recapitulaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirRecapitulacionesDelHistoricoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.CalCularRecapitulacionesParaHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    string columnas = "SaldoCuenta,SaldoAlUltimoCierre,DebeTMP,HaberTMP,SaldoActual,UitilidadBruta";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), columnas, oRegistroEN.TasaDeCambio);

                    RPT = new rptRecapitulaciones();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "CalCularRecapitulaciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = string.Format("Balanza de Comprobación al {0}", oRegistroEN.FechaFinal.ToShortDateString());
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Recapitulaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirAuxiliarDelMayor()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerElAuxiliarDelMayorSobreLaCuenta(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptAuxiliarDelMayor();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "AuxiliarDelMayor"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "AUXILIAR DEL MAYOR" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Auxiliar del mayor";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Auxiliar del mayor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirAuxiliarDelMayorEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerElAuxiliarDelMayorSobreLaCuenta(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "TotalDebitos,TotalCreditos,Debe,Haber,SaldoActual,SaldoTotalAuxiliar";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptAuxiliarDelMayor();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "AuxiliarDelMayor"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte",oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Auxiliar del mayor";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Auxiliar del mayor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirAuxiliarDelMayorDesdeElHistorico()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.GenerarAuxiliarMayorDesdeElHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptAuxiliarDelMayor();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "AuxiliarDelMayor"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", "AUXILIAR DEL MAYOR" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Auxiliar del mayor";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Auxiliar del mayor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirAuxiliarDelMayorDesdeElHistoricoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.GenerarAuxiliarMayorDesdeElHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoActual,Debe,Haber,TotalDebitos,TotalCreditos,SaldoTotalAuxiliar";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptAuxiliarDelMayor();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "AuxiliarDelMayor"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.oConfiguracionEN.NombreDelSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Auxiliar del mayor";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Auxiliar del mayor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirTransaccionesListado()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                oRegistroEN = (TransaccionTMPEN)this.Entidad;

                if (oRegistroLN.ListadoParaReportes(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptListadoDeTransancciones();
                    AgregarTablaEmpresaADataSet();                    
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoDeTransancciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "LISTADO DE TRANSACCIONES" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de transacciones";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirTransaccionesListadoEnDolares()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                oRegistroEN = (TransaccionTMPEN)this.Entidad;

                if (oRegistroLN.ListadoParaReportes(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "Valor";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptListadoDeTransancciones();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "ListadoDeTransancciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "LISTADO DE TRANSACCIONES" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de transacciones";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirHistoricoListadoEnDolares()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                oRegistroEN = (TransaccionTMPEN)this.Entidad;

                if (oRegistroLN.ListadoDeMovimientoAlCierreDePeriodo(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "Valor";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptListadoDeTransancciones();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "ListadoDeTransancciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de transacciones";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirHistoricoListado()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                oRegistroEN = (TransaccionTMPEN)this.Entidad;

                if (oRegistroLN.ListadoDeMovimientoAlCierreDePeriodo(oRegistroEN, Program.oDatosDeConexion))
                {
                   
                    RPT = new rptListadoDeTransancciones();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoDeTransancciones"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Listado de transacciones";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirLibroDeBanco()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDeLaCuentaPorFecha(oRegistroEN, Program.oDatosDeConexion))
                {
                    
                    RPT = new rptLibroDeBanco();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "LibroDeBanco"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "LIBRO DE BANCO" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Libro de banco";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Libro de banco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirLibroDeBancoEnDolares()
        {
            try
            {

                ReportesEN oRegistroEN = new ReportesEN();
                ReportesLN oRegistroLN = new ReportesLN();

                oRegistroEN = (ReportesEN)this.Entidad;

                if (oRegistroLN.TraerSaldoActualDeLaCuentaPorFecha(oRegistroEN, Program.oDatosDeConexion))
                {
                    string Columnas = "SaldoCuenta,SaldoActualDelCB,TotalDebitos,TotalCredito,SaldoFinal";
                    DataTable oDatosTabla = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    
                    RPT = new rptLibroDeBanco();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oDatosTabla, "LibroDeBanco"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", oRegistroEN.SubTituloDelReporte }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = "Libro de banco";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Libro de banco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirTransaccionesImprimirComprobante()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                oRegistroEN = (TransaccionTMPEN)this.Entidad;

                if (oRegistroLN.ListadoParaReportes(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptImprimirTransaccion();
                    AgregarTablaEmpresaADataSet();
                    //AGREGAMOS LA INFORMACION DE LA TRANSACCION
                    AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoDeTransancciones");

                    //TRAEREMOSLA INFORMACION DEL DETALLDE AL TRANSACCIÓN....
                    TransaccionDetalleTMPEN oDetalleEN = new TransaccionDetalleTMPEN();
                    TransaccionDetalleTMPLN oDetalleLN = new TransaccionDetalleTMPLN();

                    oDetalleEN.Where = oRegistroEN.Where;
                    oDetalleEN.OrderBy = " Order by idTransaccionDetalle asc ";
                    oDetalleLN.ListadoParaReportes(oDetalleEN, Program.oDatosDeConexion);

                    AgregarTablaADataSet(oDetalleLN.TraerDatos(), "ListadoDeTransanccionesDetalle");

                    TansaccionDetalleTMPBancoEN oCuentasDeBancoEN = new TansaccionDetalleTMPBancoEN();
                    TansaccionDetalle_BancoLN oCuentasDeBancoLN = new TansaccionDetalle_BancoLN();

                    oCuentasDeBancoEN.Where = oRegistroEN.Where;

                    oCuentasDeBancoLN.ListadoParaReportes(oCuentasDeBancoEN, Program.oDatosDeConexion);

                    RPT.SetDataSource(AgregarTablaADataSet(oCuentasDeBancoLN.TraerDatos(), "ListadoDeTransanccionesDetalleBanco"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", " " }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = oRegistroEN.TituloDelReporte;
                    crvVista.ReportSource = RPT;
                    
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Imprimir comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirTransaccionesImprimirComprobanteParaRegistroDelHistorico()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                oRegistroEN = (TransaccionTMPEN)this.Entidad;

                if (oRegistroLN.ListadoParaReportesParaMostrarELHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptImprimirTransaccion();
                    AgregarTablaEmpresaADataSet();
                    //AGREGAMOS LA INFORMACION DE LA TRANSACCION
                    AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoDeTransancciones");

                    //TRAEREMOSLA INFORMACION DEL DETALLDE AL TRANSACCIÓN....
                    TransaccionDetalleTMPEN oDetalleEN = new TransaccionDetalleTMPEN();
                    TransaccionDetalleTMPLN oDetalleLN = new TransaccionDetalleTMPLN();

                    oDetalleEN.Where = oRegistroEN.Where;
                    oDetalleLN.ListadoParaReportesDesdeELHistorico(oDetalleEN, Program.oDatosDeConexion);

                    AgregarTablaADataSet(oDetalleLN.TraerDatos(), "ListadoDeTransanccionesDetalle");

                    TansaccionDetalleTMPBancoEN oCuentasDeBancoEN = new TansaccionDetalleTMPBancoEN();
                    TansaccionDetalle_BancoLN oCuentasDeBancoLN = new TansaccionDetalle_BancoLN();

                    oCuentasDeBancoEN.Where = oRegistroEN.Where;

                    oCuentasDeBancoLN.ListadoParaReportesDesdeElHistorico(oCuentasDeBancoEN, Program.oDatosDeConexion);

                    RPT.SetDataSource(AgregarTablaADataSet(oCuentasDeBancoLN.TraerDatos(), "ListadoDeTransanccionesDetalleBanco"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", " " }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = oRegistroEN.TituloDelReporte;
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Imprimir comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirTransaccionesImprimirComprobanteParaRegistroDelHistoricoEnDolares()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                oRegistroEN = (TransaccionTMPEN)this.Entidad;

                if (oRegistroLN.ListadoParaReportesParaMostrarELHistorico(oRegistroEN, Program.oDatosDeConexion))
                {
                    
                    RPT = new rptImprimirTransaccion();
                    AgregarTablaEmpresaADataSet();
                    //AGREGAMOS LA INFORMACION DE LA TRANSACCION
                    string Columnas = "Valor";
                    DataTable oDatosTable = FormatearADolares(oRegistroLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    AgregarTablaADataSet(oDatosTable, "ListadoDeTransancciones");

                    //TRAEREMOSLA INFORMACION DEL DETALLDE AL TRANSACCIÓN....
                    TransaccionDetalleTMPEN oDetalleEN = new TransaccionDetalleTMPEN();
                    TransaccionDetalleTMPLN oDetalleLN = new TransaccionDetalleTMPLN();

                    oDetalleEN.Where = oRegistroEN.Where;
                    oDetalleLN.ListadoParaReportesDesdeELHistorico(oDetalleEN, Program.oDatosDeConexion);

                    oDatosTable = null;
                    Columnas = null;
                    Columnas = "Debe,Haber";
                    oDatosTable = FormatearADolares(oDetalleLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    AgregarTablaADataSet(oDatosTable, "ListadoDeTransanccionesDetalle");

                    TansaccionDetalleTMPBancoEN oCuentasDeBancoEN = new TansaccionDetalleTMPBancoEN();
                    TansaccionDetalle_BancoLN oCuentasDeBancoLN = new TansaccionDetalle_BancoLN();

                    oCuentasDeBancoEN.Where = oRegistroEN.Where;

                    oCuentasDeBancoLN.ListadoParaReportesDesdeElHistorico(oCuentasDeBancoEN, Program.oDatosDeConexion);

                    oDatosTable = null;
                    Columnas = null;
                    Columnas = "Debe,Haber";
                    oDatosTable = FormatearADolares(oDetalleLN.TraerDatos(), Columnas, oRegistroEN.TasaDeCambio);
                    RPT.SetDataSource(AgregarTablaADataSet(oCuentasDeBancoLN.TraerDatos(), "ListadoDeTransanccionesDetalleBanco"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", " " }, { "AplicarBorde", this.AplicarBorder.ToString() } });
                    this.Text = oRegistroEN.TituloDelReporte;
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Imprimir comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                oRegistroLN = null;
                this.Entidad = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private DataTable FormatearADolares(DataTable oDatosTabla,string ColumnasAFormatear, decimal TasaDeCambio)
        {
            String[] ArrayColumnasDGV = ColumnasAFormatear.Split(',');

            foreach (String c in ArrayColumnasDGV)
            {
                string NombreDeLaColumna = c.Trim();
                foreach (DataRow Fila in oDatosTabla.Rows)
                {
                    decimal ValorSobreLaColumna = Convert.ToDecimal(Fila[NombreDeLaColumna]);
                    if (ValorSobreLaColumna > 0 && TasaDeCambio > 0)
                    {
                        ValorSobreLaColumna = ValorSobreLaColumna / TasaDeCambio;
                        Fila[NombreDeLaColumna] = ValorSobreLaColumna;
                    }

                }

            }

            return oDatosTabla;
        }

    }
}
