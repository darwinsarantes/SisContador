using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Entidad;
using Logica;
using Funciones;

namespace SisContador.Formularios
{
    public partial class frmGraficos : Form
    {
        public frmGraficos()
        {
            InitializeComponent();
        }

        public string TipoDeGrafico { set; get; }

        private void GenerarElGrafico()
        {

            chGraficos.Titles.Add("Prueba de graficos");

        }

        private void LlenarPeriodosEnAños()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                PeriodoEN oRegistroEN = new PeriodoEN();
                PeriodoLN oRegistroLN = new PeriodoLN();
                oRegistroEN.Where = "";

                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoDeLosAñosEnPeriodosCerrasdos(oRegistroEN, Program.oDatosDeConexion))
                {

                    if (oRegistroLN.TraerDatos().Rows.Count > 0)
                    {
                        cmbPeriodAños.DataSource = oRegistroLN.TraerDatos();
                        cmbPeriodAños.DisplayMember = "Ano";
                        cmbPeriodAños.ValueMember = "Ano";
                        cmbPeriodAños.SelectedIndex = 0;
                        cmbPeriodAños.Enabled = true;
                        cmbPeriodAños.SelectedIndex = -1;
                    }
                    else
                    {
                        cmbPeriodAños.DataSource = null;
                        cmbPeriodAños.Enabled = false;
                    }

                }
                else { throw new ArgumentException(oRegistroLN.Error); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del años de periodos ya cerrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void CargarPeriodosQuieEstenCerrados()
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;

                PeriodoEN oRegistrosEN = new PeriodoEN();
                PeriodoLN oRegistrosLN = new PeriodoLN();

                if (cmbPeriodAños.Enabled == true && cmbPeriodAños.SelectedIndex != -1)
                {
                    oRegistrosEN.Where = string.Format(" and Estado = 'CERRADO' and year(SoloFecha(Hasta)) = {0} ", cmbPeriodAños.SelectedValue);
                }
                else
                {
                    oRegistrosEN.Where = " and Estado = 'CERRADO' ";
                }

                oRegistrosEN.OrderBy = " Order by Hasta desc ";

                if (oRegistrosLN.ListadoParaCombos(oRegistrosEN, Program.oDatosDeConexion))
                {

                    if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                    {
                        cmbPeriodoCerrado.DataSource = oRegistrosLN.TraerDatos();
                        cmbPeriodoCerrado.DisplayMember = "PeriodoCerrado";
                        cmbPeriodoCerrado.ValueMember = "idPeriodo";
                        cmbPeriodoCerrado.SelectedIndex = 0;
                        cmbPeriodoCerrado.DropDownWidth = 250;
                        cmbPeriodoCerrado.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbPeriodoCerrado.SelectedIndex = -1;
                        
                    }
                    else
                    {
                        cmbPeriodoCerrado.DataSource = null;                       
                    }                 
                    

                }
                else
                {
                    throw new ArgumentException(oRegistrosLN.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Llenar listado de registro en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LlenarInformacionDelPeriodo()
        {
            try
            {
                if (cmbPeriodoCerrado.SelectedIndex == -1) return;

                this.Cursor = Cursors.WaitCursor;

                PeriodoEN oRegistrosEN = new PeriodoEN();
                PeriodoLN oRegistrosLN = new PeriodoLN();

                oRegistrosEN.Where = string.Format(" and idPeriodo = {0}", cmbPeriodoCerrado.SelectedValue);
                oRegistrosEN.OrderBy = " ";

                if (oRegistrosLN.ListadoParaCombos(oRegistrosEN, Program.oDatosDeConexion))
                {

                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    DateTime Fecha1 = Convert.ToDateTime(Fila["Desde"]);
                    DateTime Fecha2 = Convert.ToDateTime(Fila["Hasta"]);

                    dtpkFecha1.Value = Fecha1;
                    dtpkFecha2.Value = Fecha2;

                }
                else
                {
                    throw new ArgumentException(oRegistrosLN.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Llenar listado de registro en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void IniciarLaListaDeImpresiones()
        {
            
            cmbListadoDeImpresiones.Items.Add("Balance general detallado");
            cmbListadoDeImpresiones.Items.Add("Estado de Resultado del mes");
            cmbListadoDeImpresiones.Items.Add("Estado de Resultado");
            cmbListadoDeImpresiones.Items.Add("Balanze de comprobación");
            cmbListadoDeImpresiones.Items.Add("Recapitulaciones");
            cmbListadoDeImpresiones.Items.Add("Auxiliar del Mayor");
            cmbListadoDeImpresiones.Items.Add("Estado de cuenta bancaria");
            cmbListadoDeImpresiones.Items.Add("Estado de resultado para excel");
            cmbListadoDeImpresiones.Items.Add("Balance general Mensuales");
            cmbListadoDeImpresiones.Items.Add("Listado de Movimientos de las cuentas");
            cmbListadoDeImpresiones.SelectedIndex = -1;
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GenerarElGrafico();
        }

        private void frmGraficos_Shown(object sender, EventArgs e)
        {
            LlenarPeriodosEnAños();
            CargarPeriodosQuieEstenCerrados();
            IniciarLaListaDeImpresiones();
        }

        private void cmbPeriodAños_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarPeriodosQuieEstenCerrados();
        }

        private void tsbFiltrarInformacion_Click(object sender, EventArgs e)
        {
            try
            {


                if (cmbListadoDeImpresiones.SelectedIndex == -1)
                {
                    MessageBox.Show("Debemos seleccionar el tipo de reporte que queremos mostrar", "Filtrar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbListadoDeImpresiones.Focus();
                    return;
                }

                string Reporte = cmbListadoDeImpresiones.Text;

                if (chkPeriodo.CheckState == CheckState.Checked)
                {
                    SelecionarRegistroParaMostrarDGVPorPeriodoCerrado(Reporte);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Filtrar Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void SelecionarRegistroParaMostrarDGVPorPeriodoCerrado(string Reporte)
        {

            try
            {
                switch (Reporte)
                {
                    case "Estado de cuenta bancaria":
                        
                        ReportesEN oRegistroEN = new ReportesEN();
                        ReportesLN oRegistroLN = new ReportesLN();

                        oRegistroEN.Where = WhereDinamicoCuenta();
                        oRegistroEN.FechaInicial = Convert.ToDateTime(dtpkFecha1.Value.ToShortDateString());
                        oRegistroEN.FechaFinal = Convert.ToDateTime(dtpkFecha2.Value.ToShortDateString());

                        if (oRegistroLN.TraerSaldoActualDeLaCuentaPorFecha(oRegistroEN, Program.oDatosDeConexion))
                        {
                            DataTable DTs = oRegistroLN.TraerDatos();

                            var groupedData = (from item in DTs.Rows.Cast<DataRow>()
                                               group item by new { NoCuenta = item["NoCuenta"] } into g
                                               select g.First());

                            dgvListar.Columns.Clear();
                            dgvListar.DataSource = groupedData.CopyToDataTable();
                            FormatearDGVListar();

                            dgvListar.Columns["SaldoActualDelCB"].DefaultCellStyle.Format = "###,###,##0.00";
                            dgvListar.Columns["TotalDebitos"].DefaultCellStyle.Format = "###,###,##0.00";
                            dgvListar.Columns["TotalCredito"].DefaultCellStyle.Format = "###,###,##0.00";
                            dgvListar.Columns["SaldoFinal"].DefaultCellStyle.Format = "###,###,##0.00";

                        }
                        else
                        {
                            throw new ArgumentException(oRegistroLN.Error);
                        }

                        break;

                    case "Auxiliar del Mayor":
                        
                        ReportesEN oRegistroEN_1 = new ReportesEN();
                        ReportesLN oRegistroLN_1 = new ReportesLN();

                        oRegistroEN_1.Where = " ";
                        oRegistroEN_1.OrderBy = " ";
                        oRegistroEN_1.FechaInicial = Convert.ToDateTime(dtpkFecha1.Value.ToShortDateString());
                        oRegistroEN_1.FechaFinal = Convert.ToDateTime(dtpkFecha2.Value.ToShortDateString());
                        oRegistroEN_1.idCuenta = ExtraerCadenaDelaMascar();

                        if (oRegistroLN_1.GenerarAuxiliarMayorDesdeElHistorico(oRegistroEN_1, Program.oDatosDeConexion))
                        {
                            DataTable DTs = oRegistroLN_1.TraerDatos();

                            dgvListar.Columns.Clear();
                            dgvListar.DataSource = DTs;
                            FormatearDGVListar(dgvListar, "DescripcionDeLaCuenta,SaldoTotalAuxiliar,TotalCreditos,TotalDebitos,Concepto,DescBanco,Debitos, Creditos,DescCuenta,FechaInicial,FechaFinal");

                            FormatearColumnasConTamaños(dgvListar, "idCuenta", 130);
                            dgvListar.Columns["Debe"].DefaultCellStyle.Format = "###,###,##0.00";
                            dgvListar.Columns["Haber"].DefaultCellStyle.Format = "###,###,##0.00";
                            dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";

                            dgvListar.Columns["Fecha"].HeaderText = "Fecha";
                            dgvListar.Columns["Fecha"].Width = 100;
                            dgvListar.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";


                        }
                        else
                        {
                            throw new ArgumentException(oRegistroLN_1.Error);
                        }

                        break;

                    case "Listado de Movimientos de las cuentas":

                        try
                        {
                            
                            this.Cursor = Cursors.WaitCursor;

                            TransaccionTMPEN oRegistrosEN = new TransaccionTMPEN();
                            TransaccionTMPLN oRegistrosLN = new TransaccionTMPLN();

                            oRegistrosEN.Where = "";// WhereDinamicoMovimientosDeCuentas();
                            oRegistrosEN.OrderBy = " Order by  T.Fecha desc ";

                            if (oRegistrosLN.ListadoDeMovimientoAlCierreDePeriodo(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string OcultarColumnas = "idTransacciones,idTipoDeTransaccion,NombreTabla,RegistroTMP";
                                FormatearDGVListar(OcultarColumnas);

                                dgvListar.Columns["Valor"].DefaultCellStyle.Format = "###,###,##0.00";

                                this.dgvListar.ClearSelection();
                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Llenar listado de registro en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        break;

                    case "Balance general detallado":
                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = "";
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";
                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.CalcularBalanceGeneralParaELHistorico(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"UitilidadBruta,TotalActivo,EvaluarSiEsCuentaPrincipal,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,idCategoriaDeCuenta,DescCategoriaDeCuenta,idGrupoDeCuentas,DescGrupoDeCuentas";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["HaberTMP"].DefaultCellStyle.Format = "###,###,##0.00";

                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas con saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                        break;

                    case "Estado de Resultado":
                        try
                        {
                            
                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = " and gc.idGrupoDeCuentas in (4,5)";
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";
                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.TraerElEstadoDeResultadoPorRangoDeFecha(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"EvaluarSiEsCuentaPrincipal,UitilidadBruta,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,idCategoriaDeCuenta,DescCategoriaDeCuenta,idGrupoDeCuentas,DescGrupoDeCuentas";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["HaberTMP"].DefaultCellStyle.Format = "###,###,##0.00";

                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas con saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                        break;

                    case "Estado de Resultado del mes":
                        try
                        {
                           
                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = "";
                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.CuentasDeResultadoAlMesCorrienteUsandoHistorico(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"UitilidadBruta,EvaluarSiEsCuentaPrincipal,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,idCategoriaDeCuenta,DescCategoriaDeCuenta,idGrupoDeCuentas,DescGrupoDeCuentas";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["HaberTMP"].DefaultCellStyle.Format = "###,###,##0.00";

                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas con saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                        break;

                    case "Balanze de comprobación":
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.CalCularBalanzaDeComprobacionParaElHistorico(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"UitilidadBruta,EvaluarSiEsCuentaPrincipal,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,idCategoriaDeCuenta,DescCategoriaDeCuenta,idGrupoDeCuentas,DescGrupoDeCuentas";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["HaberTMP"].DefaultCellStyle.Format = "###,###,##0.00";

                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        break;

                    case "Recapitulaciones":
                        try
                        {
                           
                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = "";
                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.CalCularRecapitulacionesParaHistorico(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"EvaluarSiEsCuentaPrincipal,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,idCategoriaDeCuenta,DescCategoriaDeCuenta,idGrupoDeCuentas,DescGrupoDeCuentas";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["HaberTMP"].DefaultCellStyle.Format = "###,###,##0.00";

                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                        break;

                    case "Estado de resultado para excel":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.CalcularEstadoDeResultadoPorMes(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["Descripcion"].HeaderText = "Descripcion";
                                dgvListar.Columns[2].Width = 100;
                                dgvListar.Columns[2].HeaderText = dgvListar.Columns[2].Name.ToString();


                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        break;

                    case "Balance general Mensuales":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.CalcularBalanceGeneralPorMes(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"NoCuenta";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["Descripcion"].HeaderText = "Descripción";

                                this.dgvListar.ClearSelection();

                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        break;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Selección de impresión de reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private string WhereDinamicoCuenta()
        {
            string Where = "";

            if (Controles.IsNullOEmptyElControl(chkCuentas) == false)
            {
                Where += string.Format(" and c.NoCuenta in ({0}) ", ExtraerCuentasDelDataGrid());
            }

            return Where;
        }

        private string ExtraerCuentasDelDataGrid()
        {
            string CuentasSeleccionada = "";

            if (dgvListarCuentas.SelectedRows != null)
            {
                foreach (DataGridViewRow Fila in dgvListarCuentas.SelectedRows)
                {
                    CuentasSeleccionada = string.Format("{0}, ", Fila.Cells["NoCuenta"].Value.ToString());
                }
            }

            if (CuentasSeleccionada.Length > 0)
            {
                CuentasSeleccionada = CuentasSeleccionada.Substring(0, CuentasSeleccionada.Length - 2);
            }

            return CuentasSeleccionada;
        }

        private string WhereDinamicoCuentasDelCatalago()
        {

            string Where = "";

            if (Controles.IsNullOEmptyElControl(chkIdCuenta) == false && SeDigitoEnLaMascara())
            {
                Where += string.Format(" and c.idCuenta like '%{0}%' ", ExtraerCadenaDelaMascar());
            }

            if (Controles.IsNullOEmptyElControl(chkDescCuenta) == false && Controles.IsNullOEmptyElControl(txtDescCuenta) == false)
            {
                Where += string.Format(" and c.DescCuenta like '%{0}%' ", txtDescCuenta.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGruposDeCuentas) == false)
            {
                Where += string.Format(" and cc.idGrupoDeCuentas = '{0}' ", cmbGruposDeCuentas.SelectedValue);
            }

            if (Controles.IsNullOEmptyElControl(chkCategoriaDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbCategoriaDeCuentas) == false)
            {
                Where += string.Format(" and c.idCategoriaDeCuenta = '{0}' ", cmbCategoriaDeCuentas.SelectedValue);
            }

            return Where;

        }

        private string WhereDinamicoMovimientosDeCuentas()
        {

            string Where = "";

            if (Controles.IsNullOEmptyElControl(chkNoTransaccion) == false && Controles.IsNullOEmptyElControl(txtNoTransaccion) == false)
            {
                Where += string.Format(" and NumeroDeTransaccion like '%{0}%' ", txtNoTransaccion.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkConcepto) == false && Controles.IsNullOEmptyElControl(txtConcepto) == false)
            {
                Where += string.Format(" and Concepto like '%{0}%' ", txtConcepto.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkTipoDeTransaccion) == false && Controles.IsNullOEmptyElControl(cmbTipoDeTransaccion) == false)
            {
                Where += string.Format(" and idTipoDeTransaccion = '{0}' ", cmbTipoDeTransaccion.SelectedValue);
            }

            if (Controles.IsNullOEmptyElControl(chkEstado) == false && Controles.IsNullOEmptyElControl(cmbEstado) == false)
            {
                Where += string.Format(" and Estado = '{0}' ", cmbEstado.Text);
            }

            if (Controles.IsNullOEmptyElControl(chkFecha) == false)
            {
                Where += string.Format(" and SoloFecha(Fecha) between SoloFecha('{0}') and SoloFecha('{1}') ", dtpkFecha1.Value.ToString("yyyy-MM-dd 00:00:00"), dtpkFecha2.Value.ToString("yyyy-MM-dd H:m:s"));
            }

            if (Controles.IsNullOEmptyElControl(chkIdCuenta) == false && SeDigitoEnLaMascara())
            {
                Where += string.Format(@" and (Select count(tt1.idTransaccionDetalle) from transacciondetalle as tt1 
                inner join cuenta as c on c.NoCuenta = tt1.NoCuenta where c.idCuenta like '{0}%' and c.NivelCuenta > 1 ) > 0 ", ExtraerCadenaDelaMascar());
            }

            if (Controles.IsNullOEmptyElControl(chkCategoriaDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbCategoriaDeCuentas))
            {
                Where += string.Format(@" and (Select count(tt1.idTransaccionDetalle) from transacciondetalle as tt1 
                inner join cuenta as c on c.NoCuenta = tt1.NoCuenta 
                where c.idCategoriaDeCuenta > {0} and c.NivelCuenta > 1 ) > 0", cmbCategoriaDeCuentas.SelectedValue);
            }

            if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGruposDeCuentas))
            {
                Where += string.Format(@" and (Select count(tt1.idTransaccionDetalle) from transacciondetalle as tt1 
                inner join cuenta as c on c.NoCuenta = tt1.NoCuenta 
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                where cc.idGrupoDeCuentas > {0} and c.NivelCuenta > 1 ) > 0 ", cmbGruposDeCuentas.SelectedValue);
            }

            if (cmbPeriodoCerrado.SelectedIndex != -1)
            {               
                Where += string.Format(@" and idPeriodo = {0} ",cmbPeriodoCerrado.SelectedValue);
            }

            return Where;

        }

        private bool SeDigitoEnLaMascara()
        {
            bool Valor = false;

            string Cadena = mskidCuenta.Text;
            string[] ACadena = Cadena.Split('-');

            foreach (string cad in ACadena)
            {
                if (string.IsNullOrEmpty(cad) || cad.Trim().Length == 0)
                {
                    Valor = false;
                }
                else
                {
                    Valor = true;
                    return Valor;
                }
            }

            return Valor;
        }

        private string ExtraerCadenaDelaMascar()
        {
            string valor = "";

            string Cadena = mskidCuenta.Text;
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

        private void FormatearDGVListar()
        {
            try
            {
                this.dgvListar.AllowUserToResizeRows = false;
                this.dgvListar.AllowUserToAddRows = false;
                this.dgvListar.AllowUserToDeleteRows = false;
                this.dgvListar.DefaultCellStyle.BackColor = Color.White;

                this.dgvListar.MultiSelect = true;
                this.dgvListar.RowHeadersVisible = true;

                this.dgvListar.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListar.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvListar.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvListar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                string OcultarColumnas = @"Referencia,FechaDelSaldoFinal,Concepto,Debito,Credito,Saldo,NivelCuenta,FechaInicialB,FechaFinalB,CuentaMadre,Fecha,idCategoriaDeCuenta,idTipoDeCuenta,NoCuenta,DescCategoriaDeCuenta,SaldoCuenta";
                OcultarColumnasEnElDGV(this.dgvListar, OcultarColumnas);

                FormatearColumnasDelDGV(this.dgvListar);

                dgvListar.Columns["idCuenta"].Width = 130;
                dgvListar.Columns["SaldoFinal"].DefaultCellStyle.Format = "###,###,##0.00";

                this.dgvListar.RowHeadersWidth = 25;

                this.dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvListar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvListar.StandardTab = true;
                this.dgvListar.ReadOnly = false;
                this.dgvListar.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                this.dgvListar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearDGVListar(string ColumnasAOcultar)
        {
            try
            {
                this.dgvListar.AllowUserToResizeRows = false;
                this.dgvListar.AllowUserToAddRows = false;
                this.dgvListar.AllowUserToDeleteRows = false;
                this.dgvListar.DefaultCellStyle.BackColor = Color.White;

                this.dgvListar.MultiSelect = true;
                this.dgvListar.RowHeadersVisible = true;

                this.dgvListar.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListar.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvListar.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvListar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                OcultarColumnasEnElDGV(this.dgvListar, ColumnasAOcultar);

                FormatearColumnasDelDGV(this.dgvListar);

                //dgvListar.Columns["idCuenta"].Width = 130;
                FormatearColumnasConTamaños(dgvListar, "idCuenta", 130);

                this.dgvListar.RowHeadersWidth = 25;

                this.dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvListar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvListar.StandardTab = true;
                this.dgvListar.ReadOnly = false;
                this.dgvListar.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                this.dgvListar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormatearDGVListar(DataGridView DGV, string ColumnasAOcultar)
        {
            try
            {
                DGV.AllowUserToResizeRows = false;
                DGV.AllowUserToAddRows = false;
                DGV.AllowUserToDeleteRows = false;
                DGV.DefaultCellStyle.BackColor = Color.White;

                DGV.MultiSelect = true;
                DGV.RowHeadersVisible = true;

                DGV.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                DGV.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                DGV.BackgroundColor = System.Drawing.SystemColors.Window;
                DGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                if (ColumnasAOcultar.Trim().Length > 0)
                    OcultarColumnasEnElDGV(DGV, ColumnasAOcultar);

                FormatearColumnasDelDGV(DGV);

                //FormatearColumnasConTamaños(dgvListar, "idCuenta", 130);

                DGV.RowHeadersWidth = 25;

                DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGV.StandardTab = true;
                DGV.ReadOnly = false;
                DGV.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormatearColumnasDelDGV(DataGridView oDGV)
        {
            if (oDGV.Columns.Count > 0)
            {

                foreach (DataGridViewColumn c1 in oDGV.Columns)
                {
                    if (c1.Visible == true)
                    {

                        if (c1.Name.Trim().ToUpper() != "Seleccionar".ToUpper())
                        {
                            FormatoDGV oFormato = new FormatoDGV(c1.Name.Trim());
                            if (oFormato.ValorEncontrado == false)
                            {
                                oFormato = new FormatoDGV(c1.Name.Trim(), "Cuenta");
                            }

                            if (oFormato != null)
                            {
                                if (oFormato.ValorEncontrado == true)
                                {
                                    c1.HeaderText = oFormato.Descripcion;
                                    c1.Width = oFormato.Tamano;
                                    c1.DefaultCellStyle.Alignment = oFormato.Alineacion;
                                    c1.HeaderCell.Style.Alignment = oFormato.AlineacionDelEncabezado;
                                    c1.ReadOnly = oFormato.SoloLectura;
                                }

                            }
                        }
                    }
                }

            }
        }

        private void FormatearColumnasConTamaños(DataGridView oDGV, string ColumnasDelDGV, int size)
        {
            try
            {

                if (oDGV.Columns.Count > 0)
                {
                    String[] ArrayColumnasDGV = ColumnasDelDGV.Split(',');
                    foreach (String c in ArrayColumnasDGV)
                    {

                        foreach (DataGridViewColumn c1 in oDGV.Columns)
                        {
                            if (c1.Name.Trim().ToUpper() == c.Trim().ToUpper())
                            {
                                c1.Width = size;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formatear columnas dinamicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void OcultarColumnasEnElDGV(DataGridView oDGV, String ColumnasDelDGV)
        {
            if (oDGV.Columns.Count > 0)
            {
                String[] ArrayColumnasDGV = ColumnasDelDGV.Split(',');
                foreach (String c in ArrayColumnasDGV)
                {

                    foreach (DataGridViewColumn c1 in oDGV.Columns)
                    {
                        if (c1.Name.Trim().ToUpper() == c.Trim().ToUpper())
                        {
                            c1.Visible = false;
                        }
                    }

                }
            }
        }

        private void VisualizarControlesSegunReporteSeleccionado(string Reporte)
        {
            dgvListar.Columns.Clear();
            dgvListar.DataSource = null;

            switch (Reporte)
            {
                case "Estado de cuenta bancaria":
                    
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = true;
                    gbTransacciones.Visible = false;
                    gbCuentas.Visible = false;
                    CargarCuentasBancarias();
                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Auxiliar del Mayor":
                    
                    gbFiltarPorFechas.Visible = true;
                    gbCuentas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Listado de Movimientos de las cuentas":
                    
                    gbFiltarPorFechas.Visible = true;
                    gbCuentas.Visible = true;
                    gbTransacciones.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Balance general detallado":

                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Estado de Resultado":

                    
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Estado de Resultado del mes":
                    
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Balanze de comprobación":

                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Recapitulaciones":
                    
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Estado de resultado para excel":
                    
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = false;
                    
                    break;

                case "Balance general Mensuales":
                    
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = false;
                    
                    break;
            }

        }

        private void CargarCuentasBancarias()
        {
            try
            {

                CuentaEN oRegistroEN = new CuentaEN();
                CuentaLN oRegistroLN = new CuentaLN();

                oRegistroEN.Where = " and EvaLuarSiEsCuentaDeBanco(c.NoCuenta) = 1 and EvaluarSiEsCuentaPrincipal(c.NoCuenta) = 0 ";
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexion))
                {

                    dgvListarCuentas.DataSource = oRegistroLN.TraerDatos();
                    FormatearDGV();

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cargar información de la cuenta de banco", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormatearDGV()
        {
            try
            {
                this.dgvListarCuentas.AllowUserToResizeRows = false;
                this.dgvListarCuentas.AllowUserToAddRows = false;
                this.dgvListarCuentas.AllowUserToDeleteRows = false;
                this.dgvListarCuentas.DefaultCellStyle.BackColor = Color.White;

                this.dgvListarCuentas.MultiSelect = true;
                this.dgvListarCuentas.RowHeadersVisible = true;

                this.dgvListarCuentas.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListarCuentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListarCuentas.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvListarCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvListarCuentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                string OcultarColumnas = "NoCuenta,DescCategoriaDeCuenta,SaldoCuenta,CuentaMadre,NivelCuenta,DescGrupoDeCuentas,DescTipoDeCuenta,idTipoDeCuenta,idGrupoDeCuentas,idCategoriaDeCuenta,IdUsuarioDeCreacion,FechaDeCreacion,IdUsuarioDeModificacion,FechaDeModificacion,EsCuentaDeBanco";
                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasDelDGV();

                dgvListarCuentas.Columns["idCuenta"].Width = 130;

                this.dgvListarCuentas.RowHeadersWidth = 25;

                this.dgvListarCuentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvListarCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvListarCuentas.StandardTab = true;
                this.dgvListarCuentas.ReadOnly = false;
                this.dgvListarCuentas.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                this.dgvListarCuentas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearColumnasDelDGV()
        {
            if (dgvListarCuentas.Columns.Count > 0)
            {

                foreach (DataGridViewColumn c1 in dgvListarCuentas.Columns)
                {
                    if (c1.Visible == true)
                    {
                        if (c1.Name.Trim().ToUpper() != "Seleccionar".ToUpper())
                        {
                            FormatoDGV oFormato = new FormatoDGV(c1.Name.Trim());
                            if (oFormato.ValorEncontrado == false)
                            {
                                oFormato = new FormatoDGV(c1.Name.Trim(), "Cuenta");
                            }

                            if (oFormato != null)
                            {
                                c1.HeaderText = oFormato.Descripcion;
                                c1.Width = oFormato.Tamano;
                                c1.DefaultCellStyle.Alignment = oFormato.Alineacion;
                                c1.HeaderCell.Style.Alignment = oFormato.AlineacionDelEncabezado;
                                c1.ReadOnly = oFormato.SoloLectura;
                            }
                        }
                    }
                }

            }
        }

        private void OcultarColumnasEnElDGV(String ColumnasDelDGV)
        {
            if (dgvListarCuentas.Columns.Count > 0)
            {
                String[] ArrayColumnasDGV = ColumnasDelDGV.Split(',');
                foreach (String c in ArrayColumnasDGV)
                {

                    foreach (DataGridViewColumn c1 in dgvListarCuentas.Columns)
                    {
                        if (c1.Name.Trim().ToUpper() == c.Trim().ToUpper())
                        {
                            c1.Visible = false;
                        }
                    }

                }
            }
        }

        private void cmbPeriodoCerrado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkPeriodo.CheckState = CheckState.Checked;
            LlenarInformacionDelPeriodo();
        }

        private void cmbListadoDeImpresiones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkListadoDeImpriones.CheckState = CheckState.Checked;
            string Reporte = cmbListadoDeImpresiones.Text.Trim();
            VisualizarControlesSegunReporteSeleccionado(Reporte);
        }

        private void dtpkFecha1_ValueChanged(object sender, EventArgs e)
        {
            chkFecha.CheckState = CheckState.Checked;
        }

        private void dtpkFecha2_ValueChanged(object sender, EventArgs e)
        {
            chkFecha.CheckState = CheckState.Checked;
        }
    }

}
