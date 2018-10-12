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

                case "Cuentas - Listado completo":
                    ImprimirListadoDeCuentasCompletos();
                    break;

                case "Transacciones - Listado":
                    ImprimirTransaccionesListado();
                    break;

                case "Transacciones - Imprimir comprobante":
                    ImprimirTransaccionesImprimirComprobante();
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

                if (oRegistroLN.ListadoParaReportes(oRegistroEN, Program.oDatosDeConexion))
                {
                    RPT = new rptListaDeCuentas();
                    AgregarTablaEmpresaADataSet();
                    RPT.SetDataSource(AgregarTablaADataSet(oRegistroLN.TraerDatos(), "ListadoDeCuentas"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "CATÁLOGO DE CUENTAS Y SUB-CUENTAS" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte } });
                    this.Text = "Catálogo de cuentas";
                    crvVista.ReportSource = RPT;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(oRegistroLN.Error, "Catálogo de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "LISTADO DE CUENTAS COMPLETO" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte } });
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
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", "LISTADO DE TRANSACCIONES" }, { "SubTituloDeReporte", oRegistroEN.TituloDelReporte } });
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
                    oDetalleLN.ListadoParaReportes(oDetalleEN, Program.oDatosDeConexion);

                    AgregarTablaADataSet(oDetalleLN.TraerDatos(), "ListadoDeTransanccionesDetalle");

                    TansaccionDetalleTMPBancoEN oCuentasDeBancoEN = new TansaccionDetalleTMPBancoEN();
                    TansaccionDetalle_BancoLN oCuentasDeBancoLN = new TansaccionDetalle_BancoLN();

                    oCuentasDeBancoEN.Where = oRegistroEN.Where;

                    oCuentasDeBancoLN.ListadoParaReportes(oCuentasDeBancoEN, Program.oDatosDeConexion);

                    RPT.SetDataSource(AgregarTablaADataSet(oCuentasDeBancoLN.TraerDatos(), "ListadoDeTransanccionesDetalleBanco"));
                    LlenarParametros(new string[,] { { "NombreDelSistema", Program.NombreVersionSistema }, { "TituloDelReporte", oRegistroEN.TituloDelReporte }, { "SubTituloDeReporte", " " } });
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

    }
}
