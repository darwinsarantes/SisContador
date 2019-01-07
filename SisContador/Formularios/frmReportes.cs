using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;
using Funciones;
using ImportacionesAExcel;

namespace SisContador.Formularios
{
    public partial class frmReportes : Form
    {
        frmVisor ofrmVisor1 = null;
        frmVisor ofrmVisorCatalogoDeCuentas = null;
        frmVisor ofrmVisorCatalogoDeCuentas1 = null;
        frmVisor ofrmVisorCatalogoDeCuentas2 = null;
        frmVisor ofrmMovimientosDeLasCuentas = null;
        frmVisor ofrmCuentasAxuliarMayor = null;
        frmVisor ofrmEstadoDeResultado = null;
        frmVisor ofrmEstadoDeResultadoDelMes = null;
        frmVisor ofrmBalanzaDeComprobacion = null;
        frmVisor ofrmRecapitulacion = null;
        public frmReportes()
        {
            InitializeComponent();
        }

        public string TituloVentana { set; get; }
        public Boolean VariosRegistros { set; get; }//Indica si se va a seleccionar uno o mas registros. true= varios, false=solo 1

        //DataTable DT;
        DataTable ListaImpresiones = new DataTable();
        BindingSource BD = new BindingSource();

        //frmVisor ofrmVisor = null;
        

        private void IniciarLaListaDeImpresiones()
        {
            ListaImpresiones.Columns.Add("No", typeof(Int32));
            ListaImpresiones.Columns.Add("Reporte", typeof(String));

            ListaImpresiones.Rows.Add(1, "Balance general detallado");
            ListaImpresiones.Rows.Add(2, "Estado de Resultado del mes");
            ListaImpresiones.Rows.Add(3, "Estado de Resultado Consolidado");
            ListaImpresiones.Rows.Add(4, "Balanze de comprobación");
            ListaImpresiones.Rows.Add(5, "Recapitulaciones");
            ListaImpresiones.Rows.Add(6, "Auxiliar del Mayor");
            ListaImpresiones.Rows.Add(7, "Estado de cuenta bancaria");
            ListaImpresiones.Rows.Add(8, "Estado de resultado para excel");
            ListaImpresiones.Rows.Add(9, "Imprimir catálogo de cuentas y sub-cuentas");
            ListaImpresiones.Rows.Add(10, "Imprimir catálogo de cuentas y sub-cuentas con saldos");
            ListaImpresiones.Rows.Add(11, "Imprimir catálogo de cuentas y sub-cuentas con saldos detallados");
            ListaImpresiones.Rows.Add(12, "Listado de Movimientos de las cuentas");
           
            
            BD.DataSource = ListaImpresiones;

        }

        private void EstablecerTituloDeVentana()
        {
            this.Text = "Reportes - " + this.TituloVentana;           
        }

        private void ListadoDeReportes()
        {
            IniciarLaListaDeImpresiones();

            dgvListadoDeReportes.DataSource = BD;
            FormatoDGVListaDeReportes();

        }

        private void FormatoDGVListaDeReportes()
        {
            try
            {
                this.dgvListadoDeReportes.AllowUserToResizeRows = false;
                this.dgvListadoDeReportes.AllowUserToAddRows = false;
                this.dgvListadoDeReportes.AllowUserToDeleteRows = false;
                this.dgvListadoDeReportes.DefaultCellStyle.BackColor = Color.White;
                this.dgvListadoDeReportes.MultiSelect = false;
                this.dgvListadoDeReportes.RowHeadersVisible = false;
                this.dgvListadoDeReportes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                this.dgvListadoDeReportes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);
                this.dgvListadoDeReportes.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvListadoDeReportes.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvListadoDeReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                this.dgvListadoDeReportes.Columns["No"].HeaderText = " ";
                this.dgvListadoDeReportes.Columns["Reporte"].HeaderText = "Reporte";

                this.dgvListadoDeReportes.Columns["No"].Width = 50;
                this.dgvListadoDeReportes.Columns["Reporte"].Width = 260;

                this.dgvListadoDeReportes.RowHeadersWidth = 25;

                this.dgvListadoDeReportes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvListadoDeReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvListadoDeReportes.StandardTab = true;
                this.dgvListadoDeReportes.ReadOnly = true;
                this.dgvListadoDeReportes.CellBorderStyle = DataGridViewCellBorderStyle.Raised;

                this.dgvListadoDeReportes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                DataGridViewColumn colPregunta = dgvListadoDeReportes.Columns["Reporte"];
                colPregunta.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGVListado de reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReportes_Shown(object sender, EventArgs e)
        {
            this.TituloVentana = "Reportes generales";
            
            EstablecerTituloDeVentana();

            ListadoDeReportes();

            DateTime fecha1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);            
            dtpkFecha1.Value = fecha1;

            gbCuentas.Visible = false;
            gbCuentasBancarias.Visible = false;
            gbFiltarPorFechas.Visible = false;
            gbTransacciones.Visible = false;

            ConfigurarMascarDeEntrada();

            LLenarGrupoDeCuentas();
            LLenarCategoriasParaLasCuentas();
            LLenarComboListadoTipoDetransacciones();

            tsbSimbolo.Checked = true;
            tsbSimbolo.Image = Properties.Resources.unchecked16x16;

        }

        private void ConfigurarMascarDeEntrada()
        {
            if (Program.oConfiguracionEN.NivelesDeLaCuenta > 0)
            {
                int i = 1;
                string cadena = "";
                while (i <= Program.oConfiguracionEN.NivelesDeLaCuenta)
                {
                    if (i == 1)
                    {
                        cadena = "000";
                    }
                    else
                    {
                        cadena = string.Format("{0}-00", cadena);
                    }
                    i++;
                }

                mskidCuenta.Mask = cadena;
            }
        }


        private void txtListadoDeReportes_TextChanged(object sender, EventArgs e)
        {
            BD.Filter = string.Format(" Reporte like '%{0}%' ", txtListadoDeReportes.Text);
        }

        private void dgvListadoDeReportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Reporte = dgvListadoDeReportes.Rows[dgvListadoDeReportes.CurrentRow.Index].Cells["Reporte"].Value.ToString();
            VisualizarControlesSegunReporteSeleccionado(Reporte);
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
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Auxiliar del Mayor":
                    gbFiltarPorFechas.Visible = true;
                    gbCuentas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Imprimir catálogo de cuentas y sub-cuentas":
                    gbCuentas.Visible = true;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Imprimir catálogo de cuentas y sub-cuentas con saldos":
                    gbCuentas.Visible = true;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Imprimir catálogo de cuentas y sub-cuentas con saldos detallados":
                    gbCuentas.Visible = true;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Listado de Movimientos de las cuentas":
                    gbFiltarPorFechas.Visible = true;
                    gbCuentas.Visible = true;
                    gbTransacciones.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    splitContainer2.Panel1Collapsed = false;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Balance general detallado":
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = true;
                    cmdExportarAExcel.Visible = false;

                    break;

                case "Estado de Resultado Consolidado":
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    splitContainer2.Panel1Collapsed = true;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Estado de Resultado del mes":
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = true;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Balanze de comprobación":
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;
                    
                    splitContainer2.Panel1Collapsed = true;
                    cmdExportarAExcel.Visible = false;
                    break;

                case "Recapitulaciones":
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = false;
                    gbCuentasBancarias.Visible = false;                    
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = true;
                    cmdExportarAExcel.Visible = false;

                    break;

                case "Estado de resultado para excel":
                    gbCuentas.Visible = false;
                    gbFiltarPorFechas.Visible = true;
                    gbCuentasBancarias.Visible = false;
                    gbTransacciones.Visible = false;

                    splitContainer2.Panel1Collapsed = false;
                    cmdExportarAExcel.Visible = true;

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

                if(oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexion))
                {

                    dgvListarCuentas.DataSource = oRegistroLN.TraerDatos();
                    FormatearDGV();

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }


            }catch(Exception ex)
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

        private void OcultarColumnasEnElDGV(DataGridView oDGV,String ColumnasDelDGV)
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
                                if (oFormato.ValorEncontrado)
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
                                if (oFormato.ValorEncontrado)
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

        private void dgvListarCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvListarCuentas.SelectedRows != null)
            {
                chkCuentas.CheckState = CheckState.Checked;
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            if (dgvListadoDeReportes.SelectedRows != null)
            {
                string Reporte = dgvListadoDeReportes.Rows[dgvListadoDeReportes.CurrentRow.Index].Cells["Reporte"].Value.ToString();
                if (tsbVerEnDolares.CheckState == CheckState.Unchecked)
                {
                    tsbTasaDeCambio.Visible = false;
                    tsbEtiquetaTasa.Visible = false;
                    SelecionarRegistroParaMostrarDGV(Reporte);
                    
                }
                else if(tsbVerEnDolares.CheckState == CheckState.Checked)
                {
                    tsbTasaDeCambio.Visible = true;
                    tsbEtiquetaTasa.Visible = true;
                    SelecionarRegistroParaMostrarDGVPorDolares(Reporte);
                    
                }
            }else
            {
                MessageBox.Show("Se debe de seleccionar un reporte para poder ver información");
            }
        }

        private void SeleccionarImpresion(string Reporte)
        {

            try
            {
                switch (Reporte)
                {
                    case "Estado de cuenta bancaria":

                        if (ofrmVisor1 == null || ofrmVisor1.IsDisposed)
                        {
                            ofrmVisor1 = new frmVisor();
                            ofrmVisor1.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                            ofrmVisor1.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                            ofrmVisor1.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                            ofrmVisor1.NombreReporte = "Reportes - Libro de banco";
                            ReportesEN oRegistroEN = new ReportesEN();
                            oRegistroEN.Where = WhereDinamicoCuenta();

                            DateTime Fecha1 = new DateTime(dtpkFecha1.Value.Year, dtpkFecha1.Value.Month, dtpkFecha1.Value.Day);
                            DateTime fecha2 = new DateTime(dtpkFecha2.Value.Year, dtpkFecha2.Value.Month, dtpkFecha2.Value.Day);

                            oRegistroEN.FechaInicial = Fecha1;
                            oRegistroEN.FechaFinal = fecha2;
                            oRegistroEN.OrderBy = " ";
                            oRegistroEN.TituloDelReporte = "";
                            oRegistroEN.SubTituloDelReporte = "";
                            ofrmVisor1.Entidad = oRegistroEN;

                            ofrmVisor1.MdiParent = this.ParentForm;
                            ofrmVisor1.Show();
                        }
                        else
                            ofrmVisor1.BringToFront();

                        break;

                    case "Auxiliar del Mayor":

                        if (SeDigitoEnLaMascara() == false)
                        {
                            MessageBox.Show("Se debe digitar el número de la cuenta");
                            mskidCuenta.Focus();
                            return;
                        }

                        if (ofrmCuentasAxuliarMayor == null || ofrmCuentasAxuliarMayor.IsDisposed)
                        {
                            ofrmCuentasAxuliarMayor = new frmVisor();
                            ofrmCuentasAxuliarMayor.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                            ofrmCuentasAxuliarMayor.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                            ofrmCuentasAxuliarMayor.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;

                            ofrmCuentasAxuliarMayor.NombreReporte = "Cuentas - Auxiliar del Mayor";
                            ReportesEN oRegistroEN = new ReportesEN();
                            oRegistroEN.Where = string.Format(" and c.NoCuenta in (Select c1.NoCuenta from cuenta c1 where c1.idCuenta like '{0}%') ", ExtraerCadenaDelaMascar());
                            oRegistroEN.OrderBy = " Order By t.Fecha , t.idTipoDeTransaccion asc ";

                            DateTime Fecha1 = new DateTime(dtpkFecha1.Value.Year, dtpkFecha1.Value.Month, dtpkFecha1.Value.Day);
                            DateTime fecha2 = new DateTime(dtpkFecha2.Value.Year, dtpkFecha2.Value.Month, dtpkFecha2.Value.Day);

                            oRegistroEN.FechaInicial = Fecha1;
                            oRegistroEN.FechaFinal = fecha2;
                            oRegistroEN.idCuenta = ExtraerCadenaDelaMascar();
                            oRegistroEN.OrderBy = " ";
                            oRegistroEN.TituloDelReporte = "";
                            oRegistroEN.SubTituloDelReporte = "";
                            ofrmCuentasAxuliarMayor.Entidad = oRegistroEN;

                            ofrmCuentasAxuliarMayor.MdiParent = this.ParentForm;
                            ofrmCuentasAxuliarMayor.Show();
                        }
                        else
                            ofrmCuentasAxuliarMayor.BringToFront();

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas":

                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas == null || ofrmVisorCatalogoDeCuentas.IsDisposed)
                            {
                                ofrmVisorCatalogoDeCuentas = new frmVisor();
                                ofrmVisorCatalogoDeCuentas.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmVisorCatalogoDeCuentas.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas.NombreReporte = "Cuentas - Catalogo";
                                CuentaEN oRegistroEN = new CuentaEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by c.idCuenta asc  ";
                                oRegistroEN.TituloDelReporte = "";
                                ofrmVisorCatalogoDeCuentas.Entidad = oRegistroEN;

                                ofrmVisorCatalogoDeCuentas.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir catálogo de cuentas y sub-cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos":

                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas1 == null || ofrmVisorCatalogoDeCuentas1.IsDisposed)
                            {
                                ofrmVisorCatalogoDeCuentas1 = new frmVisor();
                                ofrmVisorCatalogoDeCuentas1.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmVisorCatalogoDeCuentas1.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas1.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas1.NombreReporte = "Cuentas - Traer Saldos";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                                oRegistroEN.TituloDelReporte = "";
                                ofrmVisorCatalogoDeCuentas1.Entidad = oRegistroEN;

                                ofrmVisorCatalogoDeCuentas1.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas1.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas1.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos detallados":
                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas2 == null || ofrmVisorCatalogoDeCuentas2.IsDisposed)
                            {
                                ofrmVisorCatalogoDeCuentas2 = new frmVisor();
                                ofrmVisorCatalogoDeCuentas2.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmVisorCatalogoDeCuentas2.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas2.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas2.NombreReporte = "Cuentas - Traer Saldos Detallado";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                                oRegistroEN.TituloDelReporte = "";
                                ofrmVisorCatalogoDeCuentas2.Entidad = oRegistroEN;

                                ofrmVisorCatalogoDeCuentas2.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas2.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas2.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Listado de Movimientos de las cuentas":

                        try
                        {
                            if (ofrmMovimientosDeLasCuentas == null || ofrmMovimientosDeLasCuentas.IsDisposed)
                            {
                                ofrmMovimientosDeLasCuentas = new frmVisor();
                                ofrmMovimientosDeLasCuentas.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmMovimientosDeLasCuentas.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmMovimientosDeLasCuentas.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmMovimientosDeLasCuentas.NombreReporte = "Transacciones - Listado";
                                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                                oRegistroEN.Where = WhereDinamicoMovimientosDeCuentas();
                                oRegistroEN.OrderBy = " Order by t.NumeroDeTransaccion asc  ";
                                oRegistroEN.TituloDelReporte = "";
                                ofrmMovimientosDeLasCuentas.Entidad = oRegistroEN;

                                ofrmMovimientosDeLasCuentas.MdiParent = this.ParentForm;
                                ofrmMovimientosDeLasCuentas.Show();
                            }
                            else
                                ofrmMovimientosDeLasCuentas.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;

                    case "Balance general detallado":
                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas2 == null || ofrmVisorCatalogoDeCuentas2.IsDisposed)
                            {
                                ofrmVisorCatalogoDeCuentas2 = new frmVisor();
                                ofrmVisorCatalogoDeCuentas2.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmVisorCatalogoDeCuentas2.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas2.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                //para no cambiar el nombre el switch asi lo dejamos -- pero apunta al balance general detallado
                                ofrmVisorCatalogoDeCuentas2.NombreReporte = "Cuentas - Traer Saldos Detallado por categoria";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                                oRegistroEN.TituloDelReporte = string.Format( "Cortado al día {0} ", DateTime.Now.ToShortDateString());
                                ofrmVisorCatalogoDeCuentas2.Entidad = oRegistroEN;

                                ofrmVisorCatalogoDeCuentas2.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas2.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas2.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Estado de Resultado Consolidado":
                        try
                        {
                            if (ofrmEstadoDeResultado == null || ofrmEstadoDeResultado.IsDisposed)
                            {
                                ofrmEstadoDeResultado = new frmVisor();
                                ofrmEstadoDeResultado.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmEstadoDeResultado.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultado.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultado.NombreReporte = "Cuentas - Estado de Resultado";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = " and gc.idGrupoDeCuentas in (4,5) ";
                                oRegistroEN.OrderBy = " Order by idCuenta asc ";
                                oRegistroEN.TituloDelReporte = string.Format("Cortado al día {0}",DateTime.Now.ToShortDateString());
                                ofrmEstadoDeResultado.Entidad = oRegistroEN;

                                ofrmEstadoDeResultado.MdiParent = this.ParentForm;
                                ofrmEstadoDeResultado.Show();
                            }
                            else
                                ofrmEstadoDeResultado.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Estado de Resultado del mes":
                        try
                        {
                            if (ofrmEstadoDeResultadoDelMes == null || ofrmEstadoDeResultadoDelMes.IsDisposed)
                            {
                                ofrmEstadoDeResultadoDelMes = new frmVisor();
                                ofrmEstadoDeResultadoDelMes.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmEstadoDeResultadoDelMes.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultadoDelMes.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultadoDelMes.NombreReporte = "Cuentas - Estado de Resultado del mes";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = " ";
                               
                                oRegistroEN.TituloDelReporte = string.Format("Cortado al día {0}", DateTime.Now.ToShortDateString());
                                ofrmEstadoDeResultadoDelMes.Entidad = oRegistroEN;

                                ofrmEstadoDeResultadoDelMes.MdiParent = this.ParentForm;
                                ofrmEstadoDeResultadoDelMes.Show();
                            }
                            else
                                ofrmEstadoDeResultadoDelMes.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Balanze de comprobación":
                        try
                        {
                            if (ofrmBalanzaDeComprobacion == null || ofrmBalanzaDeComprobacion.IsDisposed)
                            {
                                ofrmBalanzaDeComprobacion = new frmVisor();
                                ofrmBalanzaDeComprobacion.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmBalanzaDeComprobacion.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmBalanzaDeComprobacion.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmBalanzaDeComprobacion.NombreReporte = "Cuentas - Balanza de comprobación";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = " ";

                                oRegistroEN.TituloDelReporte = string.Format("Cortado al día {0}", DateTime.Now.ToShortDateString());
                                ofrmBalanzaDeComprobacion.Entidad = oRegistroEN;

                                ofrmBalanzaDeComprobacion.MdiParent = this.ParentForm;
                                ofrmBalanzaDeComprobacion.Show();
                            }
                            else
                                ofrmBalanzaDeComprobacion.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Recapitulaciones":
                        try
                        {
                            if (ofrmRecapitulacion == null || ofrmRecapitulacion.IsDisposed)
                            {
                                ofrmRecapitulacion = new frmVisor();
                                ofrmRecapitulacion.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmRecapitulacion.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmRecapitulacion.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmRecapitulacion.NombreReporte = "Cuentas - Recapitulacion";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = " ";

                                oRegistroEN.TituloDelReporte = string.Format("Cortado al día {0}", DateTime.Now.ToShortDateString());
                                ofrmRecapitulacion.Entidad = oRegistroEN;

                                ofrmRecapitulacion.MdiParent = this.ParentForm;
                                ofrmRecapitulacion.Show();
                            }
                            else
                                ofrmRecapitulacion.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Selección de impresión de reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SeleccionarImpresionDolares(string Reporte)
        {

            try
            {
                switch (Reporte)
                {
                    case "Estado de cuenta bancaria":

                        if (ofrmVisor1 == null || ofrmVisor1.IsDisposed)
                        {
                            ofrmVisor1 = new frmVisor();

                            ValidarSiExisteTasaDeCambioPorFecha();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                            }

                            ofrmVisor1.NombreReporte = "Reportes - Libro de banco en Dolares";
                            ofrmVisor1.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                            ofrmVisor1.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                            ofrmVisor1.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                            ReportesEN oRegistroEN = new ReportesEN();
                            oRegistroEN.Where = WhereDinamicoCuenta();

                            DateTime Fecha1 = new DateTime(dtpkFecha1.Value.Year, dtpkFecha1.Value.Month, dtpkFecha1.Value.Day);
                            DateTime fecha2 = new DateTime(dtpkFecha2.Value.Year, dtpkFecha2.Value.Month, dtpkFecha2.Value.Day);

                            oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                            oRegistroEN.FechaInicial = Fecha1;
                            oRegistroEN.FechaFinal = fecha2;
                            oRegistroEN.OrderBy = " ";
                            oRegistroEN.TituloDelReporte = "LIBRO DE BANCO EN DOLARES";
                            oRegistroEN.SubTituloDelReporte = "";
                            ofrmVisor1.Entidad = oRegistroEN;

                            ofrmVisor1.MdiParent = this.ParentForm;
                            ofrmVisor1.Show();
                        }
                        else
                            ofrmVisor1.BringToFront();

                        break;

                    case "Auxiliar del Mayor":

                        if (SeDigitoEnLaMascara() == false)
                        {
                            MessageBox.Show("Se debe digitar el número de la cuenta");
                            mskidCuenta.Focus();
                            return;
                        }

                        if (ofrmCuentasAxuliarMayor == null || ofrmCuentasAxuliarMayor.IsDisposed)
                        {
                            ValidarSiExisteTasaDeCambioPorFecha();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                            }

                            ofrmCuentasAxuliarMayor = new frmVisor();
                            ofrmCuentasAxuliarMayor.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                            ofrmCuentasAxuliarMayor.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                            ofrmCuentasAxuliarMayor.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                            ofrmCuentasAxuliarMayor.NombreReporte = "Cuentas - Auxiliar del Mayor en Dolares";
                            ReportesEN oRegistroEN = new ReportesEN();
                            oRegistroEN.Where = string.Format(" and c.NoCuenta in (Select c1.NoCuenta from cuenta c1 where c1.idCuenta like '{0}%') ", ExtraerCadenaDelaMascar());
                            oRegistroEN.OrderBy = " Order By t.Fecha , t.idTipoDeTransaccion asc ";

                            DateTime Fecha1 = new DateTime(dtpkFecha1.Value.Year, dtpkFecha1.Value.Month, dtpkFecha1.Value.Day);
                            DateTime fecha2 = new DateTime(dtpkFecha2.Value.Year, dtpkFecha2.Value.Month, dtpkFecha2.Value.Day);

                            oRegistroEN.FechaInicial = Fecha1;
                            oRegistroEN.FechaFinal = fecha2;
                            oRegistroEN.idCuenta = ExtraerCadenaDelaMascar();
                            oRegistroEN.OrderBy = " ";
                            oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                            oRegistroEN.TituloDelReporte = "AUXILIAR DEL MAYOR EN DOLARES";
                            oRegistroEN.SubTituloDelReporte = "";
                            ofrmCuentasAxuliarMayor.Entidad = oRegistroEN;

                            ofrmCuentasAxuliarMayor.MdiParent = this.ParentForm;
                            ofrmCuentasAxuliarMayor.Show();
                        }
                        else
                            ofrmCuentasAxuliarMayor.BringToFront();

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas":

                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas == null || ofrmVisorCatalogoDeCuentas.IsDisposed)
                            {
                                ofrmVisorCatalogoDeCuentas = new frmVisor();
                                ofrmVisorCatalogoDeCuentas.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;

                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }
                                
                                ofrmVisorCatalogoDeCuentas.NombreReporte = "Cuentas - Catalogo en Dolares";
                                ofrmVisorCatalogoDeCuentas.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                CuentaEN oRegistroEN = new CuentaEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by c.idCuenta asc  ";
                                oRegistroEN.TituloDelReporte = "MOVIMIENTOS DE CUENTA EN EL MES EN DOLARES";
                                oRegistroEN.SubTituloDelReporte = "";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                ofrmVisorCatalogoDeCuentas.Entidad = oRegistroEN;
                                ofrmVisorCatalogoDeCuentas.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir catálogo de cuentas y sub-cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos":

                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas1 == null || ofrmVisorCatalogoDeCuentas1.IsDisposed)
                            {
                                ofrmVisorCatalogoDeCuentas1 = new frmVisor();
                                ofrmVisorCatalogoDeCuentas1.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;

                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }


                                ofrmVisorCatalogoDeCuentas1.NombreReporte = "Cuentas - Traer Saldos en Dolares";
                                ofrmVisorCatalogoDeCuentas1.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas1.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                oRegistroEN.TituloDelReporte = "SALDOS EN DOLARES";
                                oRegistroEN.SubTituloDelReporte = "";
                                ofrmVisorCatalogoDeCuentas1.Entidad = oRegistroEN;

                                ofrmVisorCatalogoDeCuentas1.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas1.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas1.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos detallados":
                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas2 == null || ofrmVisorCatalogoDeCuentas2.IsDisposed)
                            {
                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }
                                
                                ofrmVisorCatalogoDeCuentas2 = new frmVisor();
                                ofrmVisorCatalogoDeCuentas2.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmVisorCatalogoDeCuentas2.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas2.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;

                                ofrmVisorCatalogoDeCuentas2.NombreReporte = "Cuentas - Traer Saldos Detallado en Dalores";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                                oRegistroEN.TituloDelReporte = "SALDOS EN DOLARES";
                                oRegistroEN.SubTituloDelReporte = "";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                ofrmVisorCatalogoDeCuentas2.Entidad = oRegistroEN;

                                ofrmVisorCatalogoDeCuentas2.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas2.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas2.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Listado de Movimientos de las cuentas":

                        try
                        {
                            if (ofrmMovimientosDeLasCuentas == null || ofrmMovimientosDeLasCuentas.IsDisposed)
                            {
                                ofrmMovimientosDeLasCuentas = new frmVisor();
                                ofrmMovimientosDeLasCuentas.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmMovimientosDeLasCuentas.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmMovimientosDeLasCuentas.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;

                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }

                                ofrmMovimientosDeLasCuentas.NombreReporte = "Transacciones - Listado";
                                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                                oRegistroEN.Where = WhereDinamicoMovimientosDeCuentas();
                                oRegistroEN.OrderBy = " Order by t.NumeroDeTransaccion asc  ";
                                oRegistroEN.TituloDelReporte = "";
                                oRegistroEN.SubTituloDelReporte = "";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                ofrmMovimientosDeLasCuentas.Entidad = oRegistroEN;

                                ofrmMovimientosDeLasCuentas.MdiParent = this.ParentForm;
                                ofrmMovimientosDeLasCuentas.Show();
                            }
                            else
                                ofrmMovimientosDeLasCuentas.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;

                    case "Balance general detallado":
                        try
                        {
                            if (ofrmVisorCatalogoDeCuentas2 == null || ofrmVisorCatalogoDeCuentas2.IsDisposed)
                            {

                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                        
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }

                                ofrmVisorCatalogoDeCuentas2 = new frmVisor();
                                ofrmVisorCatalogoDeCuentas2.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmVisorCatalogoDeCuentas2.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmVisorCatalogoDeCuentas2.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                //para no cambiar el nombre el switch asi lo dejamos -- pero apunta al balance general detallado
                                ofrmVisorCatalogoDeCuentas2.NombreReporte = "Cuentas - Balance General en Dolares";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = WhereDinamicoCuentasDelCatalago();
                                oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                oRegistroEN.TituloDelReporte = string.Format("Balance general en Dolares - Cortado al día {0} ", DateTime.Now.ToShortDateString());
                                ofrmVisorCatalogoDeCuentas2.Entidad = oRegistroEN;

                                ofrmVisorCatalogoDeCuentas2.MdiParent = this.ParentForm;
                                ofrmVisorCatalogoDeCuentas2.Show();
                            }
                            else
                                ofrmVisorCatalogoDeCuentas2.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Estado de Resultado Consolidado":
                        try
                        {
                            if (ofrmEstadoDeResultado == null || ofrmEstadoDeResultado.IsDisposed)
                            {
                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }

                                ofrmEstadoDeResultado = new frmVisor();
                                ofrmEstadoDeResultado.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmEstadoDeResultado.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultado.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultado.NombreReporte = "Cuentas - Estado de Resultado Consolidado en dolares";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = " and gc.idGrupoDeCuentas in (4,5) ";
                                oRegistroEN.OrderBy = " Order by idCuenta asc ";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                oRegistroEN.TituloDelReporte = "ESTADO DE RESULTADO CONSOLIDADO EN DOLARES";
                                oRegistroEN.SubTituloDelReporte = string.Format("Cortado al día {0}", DateTime.Now.ToShortDateString());
                                ofrmEstadoDeResultado.Entidad = oRegistroEN;

                                ofrmEstadoDeResultado.MdiParent = this.ParentForm;
                                ofrmEstadoDeResultado.Show();
                            }
                            else
                                ofrmEstadoDeResultado.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Estado de Resultado del mes":
                        try
                        {
                            if (ofrmEstadoDeResultadoDelMes == null || ofrmEstadoDeResultadoDelMes.IsDisposed)
                            {

                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }

                                ofrmEstadoDeResultadoDelMes = new frmVisor();
                                ofrmEstadoDeResultadoDelMes.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmEstadoDeResultadoDelMes.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultadoDelMes.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmEstadoDeResultadoDelMes.NombreReporte = "Cuentas - Estado de Resultado del mes en dolares";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                oRegistroEN.Where = " ";
                                oRegistroEN.TituloDelReporte = "ESTADO DE RESULTADO DEL MES ACTUAL EN DOLARES";
                                oRegistroEN.SubTituloDelReporte = string.Format("Cortado al día {0}", DateTime.Now.ToShortDateString());
                                ofrmEstadoDeResultadoDelMes.Entidad = oRegistroEN;

                                ofrmEstadoDeResultadoDelMes.MdiParent = this.ParentForm;
                                ofrmEstadoDeResultadoDelMes.Show();
                            }
                            else
                                ofrmEstadoDeResultadoDelMes.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Balanze de comprobación":
                        try
                        {
                            if (ofrmBalanzaDeComprobacion == null || ofrmBalanzaDeComprobacion.IsDisposed)
                            {
                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }

                                ofrmBalanzaDeComprobacion = new frmVisor();
                                ofrmBalanzaDeComprobacion.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmBalanzaDeComprobacion.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmBalanzaDeComprobacion.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;
                                ofrmBalanzaDeComprobacion.NombreReporte = "Cuentas - Balanza de comprobación Dolares";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = " ";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;
                                oRegistroEN.TituloDelReporte = "BALANZA DE COMPROBACIÓN EN DOLARES";
                                oRegistroEN.SubTituloDelReporte = string.Format("Cortado al día {0}", DateTime.Now.ToShortDateString());
                                ofrmBalanzaDeComprobacion.Entidad = oRegistroEN;

                                ofrmBalanzaDeComprobacion.MdiParent = this.ParentForm;
                                ofrmBalanzaDeComprobacion.Show();
                            }
                            else
                                ofrmBalanzaDeComprobacion.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Recapitulaciones":
                        try
                        {
                            if (ofrmRecapitulacion == null || ofrmRecapitulacion.IsDisposed)
                            {

                                ValidarSiExisteTasaDeCambio();

                                if (TasaDeCambioALDia == 0)
                                {
                                    if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                    {
                                        if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                        {
                                            string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                            decimal.TryParse(Valor, out TasaDeCambioALDia);
                                            if (TasaDeCambioALDia == 0)
                                            {
                                                MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                                tsbTasaDeCambio.Text = string.Empty;
                                                tsbTasaDeCambio.Visible = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                    {
                                        decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                }

                                ofrmRecapitulacion = new frmVisor();
                                ofrmRecapitulacion.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                                ofrmRecapitulacion.VisualizarSimbolo = tsbSimbolo.CheckState == CheckState.Checked ? true : false;
                                ofrmRecapitulacion.VisualizarDolares = tsbVerEnDolares.CheckState == CheckState.Checked ? true : false;

                                ofrmRecapitulacion.NombreReporte = "Cuentas - Recapitulacion en Dolares";
                                ReportesEN oRegistroEN = new ReportesEN();
                                oRegistroEN.Where = " ";
                                oRegistroEN.TasaDeCambio = TasaDeCambioALDia;

                                System.Globalization.DateTimeFormatInfo formatoFecha = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
                                oRegistroEN.TituloDelReporte = string.Format("RECAPITULACIÓN DEL MES DE '{0}' EN DOLARES", formatoFecha.GetMonthName(DateTime.Now.Month).ToUpper());
                                oRegistroEN.SubTituloDelReporte = string.Format("Cortado al día {0}", DateTime.Now.ToShortDateString());
                                ofrmRecapitulacion.Entidad = oRegistroEN;

                                ofrmRecapitulacion.MdiParent = this.ParentForm;
                                ofrmRecapitulacion.Show();
                            }
                            else
                                ofrmRecapitulacion.BringToFront();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Selección de impresión de reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SelecionarRegistroParaMostrarDGV(string Reporte)
        {

            try
            {
                switch (Reporte)
                {
                    case "Estado de cuenta bancaria":

                        if (chkFecha.CheckState == CheckState.Unchecked)
                        {
                            MessageBox.Show("Se debe de seleccionar un rango de fechas");
                            dtpkFecha1.Focus();
                            return;
                        }

                        ReportesEN oRegistroEN = new ReportesEN();
                        ReportesLN oRegistroLN = new ReportesLN();

                        oRegistroEN.Where = WhereDinamicoCuenta();
                        oRegistroEN.FechaInicial = Convert.ToDateTime( dtpkFecha1.Value.ToShortDateString());
                        oRegistroEN.FechaFinal = Convert.ToDateTime( dtpkFecha2.Value.ToShortDateString());

                        if (oRegistroLN.TraerSaldoActualDeLaCuentaPorFecha(oRegistroEN, Program.oDatosDeConexion))
                        {
                            DataTable DTs = oRegistroLN.TraerDatos();                            

                            var groupedData = (from item in DTs.Rows.Cast<DataRow>()
                                               group item by new { NoCuenta = item["NoCuenta"]} into g select g.First());

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

                        if (oRegistroLN_1.TraerElAuxiliarDelMayorSobreLaCuenta(oRegistroEN_1, Program.oDatosDeConexion))
                        {
                            DataTable DTs = oRegistroLN_1.TraerDatos();
                            
                            dgvListar.Columns.Clear();
                            dgvListar.DataSource = DTs;
                            FormatearDGVListar(dgvListar, "DescripcionDeLaCuenta,SaldoTotalAuxiliar,TotalCreditos,TotalDebitos,Concepto,DescBanco,Debitos, Creditos,DescCuenta,FechaInicial,FechaFinal");

                            FormatearColumnasConTamaños(dgvListar, "idCuenta", 130);
                            dgvListar.Columns["Debe"].DefaultCellStyle.Format = "###,###,##0.00";
                            dgvListar.Columns["Haber"].DefaultCellStyle.Format = "###,###,##0.00";
                            dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";

                            dgvListar.Columns["Fecha"].HeaderText ="Fecha";
                            dgvListar.Columns["Fecha"].Width = 100;
                            dgvListar.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";


                        }
                        else
                        {
                            throw new ArgumentException(oRegistroLN_1.Error);
                        }

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            CuentaEN oRegistrosEN = new CuentaEN();
                            CuentaLN oRegistrosLN = new CuentaLN();

                            oRegistrosEN.Where = WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by c.idCuenta asc ";

                            if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();

                                string ocultarColumnas = @"DescCuentaContenido,EsCuentaDeBanco,DescTipoDeCuenta,FechaDeModificacion,IdUsuarioDeModificacion,FechaDeCreacion,IdUsuarioDeCreacion,CuentaMadre,NivelCuenta,DescCategoriaDeCuenta,DescGrupoDeCuentas,NoCuenta,idGrupoDeCuentas,idCategoriaDeCuenta,idTipoDeCuenta";
                                FormatearDGVListar(ocultarColumnas);
                                this.dgvListar.ClearSelection();
                                
                            }
                            else
                            {
                                throw new ArgumentException(oRegistrosLN.Error);
                            }

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Imprimir Catálogo de cuentas y sub-cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        break;

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";

                            if (oRegistrosLN.TraerSaldoActualDelasCuentas(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                /*idCuenta, DescCuenta, SaldoCuenta, NivelCuenta, CuentaMadre, NoCuenta, IdTipoDeCuenta,
                                SaldoAlUltimoCierre, DebeTMP, HaberTMP, SaldoActual, Debitos, Creditos */
                                string ocultarColumnas = @"idCategoriaDeCuenta,idGrupoDeCuentas,UitilidadBruta,DebeTMP,HaberTMP,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,SaldoAlUltimoCierre";
                                FormatearDGVListar(ocultarColumnas);
                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                    
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

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos detallados":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";

                            if (oRegistrosLN.TraerSaldoActualDelasCuentas(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();                                
                                string ocultarColumnas = @"idCategoriaDeCuenta,idGrupoDeCuentas,UitilidadBruta,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta";
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

                    case "Listado de Movimientos de las cuentas":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            TransaccionTMPEN oRegistrosEN = new TransaccionTMPEN();
                            TransaccionTMPLN oRegistrosLN = new TransaccionTMPLN();

                            oRegistrosEN.Where = WhereDinamicoMovimientosDeCuentas();
                            oRegistrosEN.OrderBy = " Order by  T.Fecha desc ";

                            if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexion))
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

                            oRegistrosEN.Where = "";// WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";

                            if (oRegistrosLN.CalcularBalanceGeneralDeManeraDetalla(oRegistrosEN, Program.oDatosDeConexion))
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

                    case "Estado de Resultado Consolidado":
                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = " and gc.idGrupoDeCuentas in (4,5)";
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";

                            if (oRegistrosLN.TraerSaldoActualDelasCuentasFull(oRegistrosEN, Program.oDatosDeConexion))
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

                            if (oRegistrosLN.TraerEstadoDeResultadoDelalMes(oRegistrosEN, Program.oDatosDeConexion))
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

                            oRegistrosEN.Where = "";

                            if (oRegistrosLN.CalCularBalanzaDeComprobacion(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"EvaluarSiEsCuentaPrincipal,UitilidadBruta,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,idCategoriaDeCuenta,DescCategoriaDeCuenta,idGrupoDeCuentas,DescGrupoDeCuentas";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["HaberTMP"].DefaultCellStyle.Format = "###,###,##0.00";

                                dgvListar.Columns["idCuenta"].Width = 60;
                                dgvListar.Columns["DescCuenta"].Width = 200;

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

                            if (oRegistrosLN.CalCularRecapitulaciones(oRegistrosEN, Program.oDatosDeConexion))
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

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Selección de impresión de reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SelecionarRegistroParaMostrarDGVPorDolares(string Reporte)
        {

            try
            {
                switch (Reporte)
                {
                    case "Estado de cuenta bancaria":

                        if (chkFecha.CheckState == CheckState.Unchecked)
                        {
                            MessageBox.Show("Se debe de seleccionar un rango de fechas");
                            dtpkFecha1.Focus();
                            return;
                        }

                        ValidarSiExisteTasaDeCambioPorFecha();

                        if (TasaDeCambioALDia == 0)
                        {
                            if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                            {
                                if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                {
                                    string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                    decimal.TryParse(Valor, out TasaDeCambioALDia);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    tsbTasaDeCambio.Visible = false;
                                    return;
                                }
                            }
                            else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                            {
                                //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                if (TasaDeCambioALDia == 0)
                                {
                                    MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                    tsbTasaDeCambio.Text = string.Empty;
                                    tsbTasaDeCambio.Visible = false;
                                }
                            }
                        }

                        tsbEtiquetaTasa.Visible = true;
                        tsbTasaDeCambio.Visible = true;
                        tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                        ReportesEN oRegistroEN = new ReportesEN();
                        ReportesLN oRegistroLN = new ReportesLN();

                        oRegistroEN.Where = WhereDinamicoCuenta();
                        oRegistroEN.FechaInicial = Convert.ToDateTime(dtpkFecha1.Value.ToShortDateString());
                        oRegistroEN.FechaFinal = Convert.ToDateTime(dtpkFecha2.Value.ToShortDateString());

                        if (oRegistroLN.TraerSaldoActualDeLaCuentaPorFecha(oRegistroEN, Program.oDatosDeConexion))
                        {
                            DataTable DTs = oRegistroLN.TraerDatos();

                            foreach (DataRow Fila in DTs.Rows)
                            {
                                decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                decimal SaldoActualDelCB = Convert.ToDecimal(Fila["SaldoActualDelCB"]) / TasaDeCambioALDia;
                                decimal TotalDebitos = Convert.ToDecimal(Fila["TotalDebitos"]) / TasaDeCambioALDia;
                                decimal TotalCredito = Convert.ToDecimal(Fila["TotalCredito"]) / TasaDeCambioALDia;
                                decimal SaldoFinal = Convert.ToDecimal(Fila["SaldoFinal"]) / TasaDeCambioALDia;

                                Fila["SaldoCuenta"] = SaldoCuenta;
                                Fila["SaldoActualDelCB"] = SaldoActualDelCB;
                                Fila["TotalDebitos"] = TotalDebitos;
                                Fila["TotalCredito"] = TotalCredito;
                                Fila["SaldoFinal"] = SaldoFinal;

                            }

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

                        ValidarSiExisteTasaDeCambioPorFecha();

                        if (TasaDeCambioALDia == 0)
                        {
                            if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                            {
                                if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                {
                                    string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                    decimal.TryParse(Valor, out TasaDeCambioALDia);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    tsbTasaDeCambio.Visible = false;
                                    return;
                                }
                            }
                            else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                            {
                                //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                if (TasaDeCambioALDia == 0)
                                {
                                    MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                    tsbTasaDeCambio.Text = string.Empty;
                                    tsbTasaDeCambio.Visible = false;
                                }
                            }
                        }

                        tsbEtiquetaTasa.Visible = true;
                        tsbTasaDeCambio.Visible = true;
                        tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                        ReportesEN oRegistroEN_1 = new ReportesEN();
                        ReportesLN oRegistroLN_1 = new ReportesLN();

                        oRegistroEN_1.Where = " ";
                        oRegistroEN_1.OrderBy = " ";
                        oRegistroEN_1.FechaInicial = Convert.ToDateTime(dtpkFecha1.Value.ToShortDateString());
                        oRegistroEN_1.FechaFinal = Convert.ToDateTime(dtpkFecha2.Value.ToShortDateString());
                        oRegistroEN_1.idCuenta = ExtraerCadenaDelaMascar();

                        oRegistroEN_1.TasaDeCambio = TasaDeCambioALDia;

                        if (oRegistroLN_1.TraerElAuxiliarDelMayorSobreLaCuenta(oRegistroEN_1, Program.oDatosDeConexion))
                        {
                            DataTable DTs = oRegistroLN_1.TraerDatos();

                            foreach (DataRow Fila in DTs.Rows)
                            {
                                decimal Debe = Convert.ToDecimal(Fila["Debe"]) / TasaDeCambioALDia;
                                decimal Haber = Convert.ToDecimal(Fila["Haber"]) / TasaDeCambioALDia;
                                decimal SaldoActual = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;
                                
                                Fila["Debe"] = Debe;
                                Fila["Haber"] = Haber;
                                Fila["SaldoActual"] = SaldoActual;

                            }

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

                    case "Imprimir catálogo de cuentas y sub-cuentas":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            CuentaEN oRegistrosEN = new CuentaEN();
                            CuentaLN oRegistrosLN = new CuentaLN();

                            oRegistrosEN.Where = WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by c.idCuenta asc ";

                            if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                DataTable oDatos = oRegistrosLN.TraerDatos().Copy();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoAlDia = Convert.ToDecimal(Fila["SaldoAlDia"]) / TasaDeCambioALDia;
                                    decimal MovimientosDelDia = Convert.ToDecimal(Fila["MovimientosDelDia"]) / TasaDeCambioALDia;
                                    decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                    
                                    Fila["SaldoAlDia"] = SaldoAlDia;
                                    Fila["MovimientosDelDia"] = MovimientosDelDia;
                                    Fila["SaldoCuenta"] = SaldoCuenta;                                    

                                }
                                
                                dgvListar.Columns.Clear();
                                //dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                dgvListar.DataSource = oDatos;

                                string ocultarColumnas = @"DescCuentaContenido,EsCuentaDeBanco,DescTipoDeCuenta,FechaDeModificacion,IdUsuarioDeModificacion,FechaDeCreacion,IdUsuarioDeCreacion,CuentaMadre,NivelCuenta,DescCategoriaDeCuenta,DescGrupoDeCuentas,NoCuenta,idGrupoDeCuentas,idCategoriaDeCuenta,idTipoDeCuenta";
                                FormatearDGVListar(ocultarColumnas);
                                this.dgvListar.ClearSelection();

                                dgvListar.Columns["SaldoAlDia"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["MovimientosDelDia"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoCuenta"].DefaultCellStyle.Format = "###,###,##0.00";                                

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

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";

                            if (oRegistrosLN.TraerSaldoActualDelasCuentas(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();

                                DataTable oDatos = oRegistrosLN.TraerDatos().Copy();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                    decimal SaldoAlUltimoCierre = Convert.ToDecimal(Fila["SaldoAlUltimoCierre"]) / TasaDeCambioALDia;
                                    decimal DebeTMP = Convert.ToDecimal(Fila["DebeTMP"]) / TasaDeCambioALDia;
                                    decimal HaberTMP = Convert.ToDecimal(Fila["HaberTMP"]) / TasaDeCambioALDia;
                                    decimal SaldoActual = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;

                                    Fila["SaldoCuenta"] = SaldoCuenta;
                                    Fila["SaldoAlUltimoCierre"] = SaldoAlUltimoCierre;
                                    Fila["DebeTMP"] = DebeTMP;
                                    Fila["SaldoActual"] = SaldoActual;

                                }

                                dgvListar.DataSource = oDatos;

                                /*idCuenta, DescCuenta, SaldoCuenta, NivelCuenta, CuentaMadre, NoCuenta, IdTipoDeCuenta,
                                SaldoAlUltimoCierre, DebeTMP, HaberTMP, SaldoActual, Debitos, Creditos */
                                string ocultarColumnas = @"idCategoriaDeCuenta,idGrupoDeCuentas,UitilidadBruta,DebeTMP,HaberTMP,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,SaldoAlUltimoCierre";
                                FormatearDGVListar(ocultarColumnas);
                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoCuenta"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";

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

                    case "Imprimir catálogo de cuentas y sub-cuentas con saldos detallados":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";

                            if (oRegistrosLN.TraerSaldoActualDelasCuentas(oRegistrosEN, Program.oDatosDeConexion))
                            {
                                DataTable oDatos = oRegistrosLN.TraerDatos().Copy();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                    decimal SaldoAlUltimoCierre = Convert.ToDecimal(Fila["SaldoAlUltimoCierre"]) / TasaDeCambioALDia;
                                    decimal DebeTMP = Convert.ToDecimal(Fila["DebeTMP"]) / TasaDeCambioALDia;
                                    decimal HaberTMP = Convert.ToDecimal(Fila["HaberTMP"]) / TasaDeCambioALDia;
                                    decimal SaldoActual = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;

                                    Fila["SaldoCuenta"] = SaldoCuenta;
                                    Fila["SaldoAlUltimoCierre"] = SaldoAlUltimoCierre;
                                    Fila["DebeTMP"] = DebeTMP;
                                    Fila["HaberTMP"] = HaberTMP;
                                    Fila["SaldoActual"] = SaldoActual;

                                }
                                
                                dgvListar.Columns.Clear();
                                dgvListar.DataSource = oDatos;
                                string ocultarColumnas = @"idCategoriaDeCuenta,idGrupoDeCuentas,UitilidadBruta,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta";
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

                    case "Listado de Movimientos de las cuentas":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            TransaccionTMPEN oRegistrosEN = new TransaccionTMPEN();
                            TransaccionTMPLN oRegistrosLN = new TransaccionTMPLN();

                            oRegistrosEN.Where = WhereDinamicoMovimientosDeCuentas();
                            oRegistrosEN.OrderBy = " Order by  T.Fecha desc ";

                            if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexion))
                            {
                                DataTable oDatos = oRegistrosLN.TraerDatos().Copy();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal Valor = Convert.ToDecimal(Fila["Valor"]) / TasaDeCambioALDia;
                                    
                                    Fila["Valor"] = Valor;                                    

                                }

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

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }else if(tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();
                            
                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = "";// WhereDinamicoCuentasDelCatalago();
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";
                            oRegistrosEN.TasaDeCambio = TasaDeCambioALDia;

                            if (oRegistrosLN.CalcularBalanceGeneralDeManeraDetalla(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                DataTable oDatos = oRegistrosLN.TraerDatos().Copy();

                                foreach(DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoActualDolares = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;
                                    decimal SaldoAlUltimoCierreDolares = Convert.ToDecimal(Fila["SaldoAlUltimoCierre"]) / TasaDeCambioALDia;
                                    decimal DebeTMPDolares = Convert.ToDecimal(Fila["DebeTMP"]) / TasaDeCambioALDia;
                                    decimal HaberTMPDolares = Convert.ToDecimal(Fila["HaberTMP"]) / TasaDeCambioALDia;
                                    Fila["SaldoActual"] = SaldoActualDolares;
                                    Fila["SaldoAlUltimoCierre"] = SaldoAlUltimoCierreDolares;
                                    Fila["DebeTMP"] = DebeTMPDolares;
                                    Fila["HaberTMP"] = HaberTMPDolares;

                                }

                                dgvListar.DataSource = oDatos;
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

                    case "Estado de Resultado Consolidado":
                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);

                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = " and gc.idGrupoDeCuentas in (4,5)";
                            oRegistrosEN.OrderBy = " Order by idCuenta asc ";

                            if (oRegistrosLN.TraerSaldoActualDelasCuentasFull(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();
                                DataTable oDatos = oRegistrosLN.TraerDatos();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                    decimal SaldoAlUltimoCierre = Convert.ToDecimal(Fila["SaldoAlUltimoCierre"]) / TasaDeCambioALDia;
                                    decimal DebeTMP = Convert.ToDecimal(Fila["DebeTMP"]) / TasaDeCambioALDia;
                                    decimal HaberTMP = Convert.ToDecimal(Fila["HaberTMP"]) / TasaDeCambioALDia;
                                    decimal UitilidadBruta = Convert.ToDecimal(Fila["UitilidadBruta"]) / TasaDeCambioALDia;
                                    decimal SaldoActual = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;

                                    Fila["SaldoCuenta"] = SaldoCuenta;
                                    Fila["SaldoAlUltimoCierre"] = SaldoAlUltimoCierre;
                                    Fila["DebeTMP"] = DebeTMP;
                                    Fila["HaberTMP"] = HaberTMP;
                                    Fila["SaldoActual"] = SaldoActual;
                                    Fila["UitilidadBruta"] = UitilidadBruta;

                                }

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

                            this.Cursor = Cursors.WaitCursor;

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = "";

                            if (oRegistrosLN.TraerEstadoDeResultadoDelalMes(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();

                                DataTable oDatos = oRegistrosLN.TraerDatos();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                    decimal SaldoAlUltimoCierre = Convert.ToDecimal(Fila["SaldoAlUltimoCierre"]) / TasaDeCambioALDia;
                                    decimal DebeTMP = Convert.ToDecimal(Fila["DebeTMP"]) / TasaDeCambioALDia;
                                    decimal HaberTMP = Convert.ToDecimal(Fila["HaberTMP"]) / TasaDeCambioALDia;
                                    decimal UitilidadBruta = Convert.ToDecimal(Fila["UitilidadBruta"]) / TasaDeCambioALDia;
                                    decimal SaldoActual = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;

                                    Fila["SaldoCuenta"] = SaldoCuenta;
                                    Fila["SaldoAlUltimoCierre"] = SaldoAlUltimoCierre;
                                    Fila["DebeTMP"] = DebeTMP;
                                    Fila["HaberTMP"] = HaberTMP;
                                    Fila["SaldoActual"] = SaldoActual;
                                    Fila["UitilidadBruta"] = UitilidadBruta;

                                }

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

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = "";

                            if (oRegistrosLN.CalCularBalanzaDeComprobacion(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();

                                DataTable oDatos = oRegistrosLN.TraerDatos();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                    decimal SaldoAlUltimoCierre = Convert.ToDecimal(Fila["SaldoAlUltimoCierre"]) / TasaDeCambioALDia;
                                    decimal DebeTMP = Convert.ToDecimal(Fila["DebeTMP"]) / TasaDeCambioALDia;
                                    decimal HaberTMP = Convert.ToDecimal(Fila["HaberTMP"]) / TasaDeCambioALDia;
                                    decimal UitilidadBruta = Convert.ToDecimal(Fila["UitilidadBruta"]) / TasaDeCambioALDia;
                                    decimal SaldoActual = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;

                                    Fila["SaldoCuenta"] = SaldoCuenta;
                                    Fila["SaldoAlUltimoCierre"] = SaldoAlUltimoCierre;
                                    Fila["DebeTMP"] = DebeTMP;
                                    Fila["HaberTMP"] = HaberTMP;
                                    Fila["SaldoActual"] = SaldoActual;
                                    Fila["UitilidadBruta"] = UitilidadBruta;

                                }

                                dgvListar.DataSource = oRegistrosLN.TraerDatos();
                                string ocultarColumnas = @"UitilidadBruta,EvaluarSiEsCuentaPrincipal,Debitos,Creditos,SaldoCuenta,NivelCuenta,CuentaMadre,NoCuenta,IdTipoDeCuenta,idCategoriaDeCuenta,DescCategoriaDeCuenta,idGrupoDeCuentas,DescGrupoDeCuentas";
                                FormatearDGVListar(ocultarColumnas);

                                dgvListar.Columns["SaldoActual"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["SaldoAlUltimoCierre"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["DebeTMP"].DefaultCellStyle.Format = "###,###,##0.00";
                                dgvListar.Columns["HaberTMP"].DefaultCellStyle.Format = "###,###,##0.00";

                                dgvListar.Columns["idCuenta"].Width = 60;
                                dgvListar.Columns["DescCuenta"].Width = 200;

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

                            ValidarSiExisteTasaDeCambio();

                            if (TasaDeCambioALDia == 0)
                            {
                                if (string.IsNullOrEmpty(tsbTasaDeCambio.Text) || tsbTasaDeCambio.Text.Trim().Length == 0)
                                {
                                    if (MessageBox.Show("No se ha registrado la tasa de cambio del mes en curso, para continuar debe ingresar un tasa de cambio, ¿Desea continuar?", "Validar tasa de cambio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                    {
                                        string Valor = Microsoft.VisualBasic.Interaction.InputBox("Agregar el valor del Cambio de Moneda", "Tasa de Cambio", "0.00", -1, -1);

                                        decimal.TryParse(Valor, out TasaDeCambioALDia);
                                        if (TasaDeCambioALDia == 0)
                                        {
                                            MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                            tsbTasaDeCambio.Text = string.Empty;
                                            tsbTasaDeCambio.Visible = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        tsbTasaDeCambio.Visible = false;
                                        return;
                                    }
                                }
                                else if (tsbTasaDeCambio.Text.Trim().Length > 0)
                                {
                                    //decimal.TryParse(tsbTasaDeCambio.Text, out TasaDeCambioALDia);
                                    TasaDeCambioALDia = decimal.Parse(tsbTasaDeCambio.Text);
                                    if (TasaDeCambioALDia == 0)
                                    {
                                        MessageBox.Show("No se ha ingresado un valor valido Intentelo mas tarde");
                                        tsbTasaDeCambio.Text = string.Empty;
                                        tsbTasaDeCambio.Visible = false;
                                    }
                                }
                            }

                            tsbEtiquetaTasa.Visible = true;
                            tsbTasaDeCambio.Visible = true;
                            tsbTasaDeCambio.Text = TasaDeCambioALDia.ToString();

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.Where = "";

                            if (oRegistrosLN.CalCularRecapitulaciones(oRegistrosEN, Program.oDatosDeConexion))
                            {

                                dgvListar.Columns.Clear();

                                DataTable oDatos = oRegistrosLN.TraerDatos();

                                foreach (DataRow Fila in oDatos.Rows)
                                {
                                    decimal SaldoCuenta = Convert.ToDecimal(Fila["SaldoCuenta"]) / TasaDeCambioALDia;
                                    decimal SaldoAlUltimoCierre = Convert.ToDecimal(Fila["SaldoAlUltimoCierre"]) / TasaDeCambioALDia;
                                    decimal DebeTMP = Convert.ToDecimal(Fila["DebeTMP"]) / TasaDeCambioALDia;
                                    decimal HaberTMP = Convert.ToDecimal(Fila["HaberTMP"]) / TasaDeCambioALDia;
                                    decimal UitilidadBruta = Convert.ToDecimal(Fila["UitilidadBruta"]) / TasaDeCambioALDia;
                                    decimal SaldoActual = Convert.ToDecimal(Fila["SaldoActual"]) / TasaDeCambioALDia;

                                    Fila["SaldoCuenta"] = SaldoCuenta;
                                    Fila["SaldoAlUltimoCierre"] = SaldoAlUltimoCierre;
                                    Fila["DebeTMP"] = DebeTMP;
                                    Fila["HaberTMP"] = HaberTMP;
                                    Fila["SaldoActual"] = SaldoActual;
                                    Fila["UitilidadBruta"] = UitilidadBruta;

                                }

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

                    case "Estado de resultado para excel":

                        try
                        {

                            this.Cursor = Cursors.WaitCursor;

                            ReportesEN oRegistrosEN = new ReportesEN();
                            ReportesLN oRegistrosLN = new ReportesLN();

                            oRegistrosEN.FechaInicial = dtpkFecha1.Value;
                            oRegistrosEN.FechaFinal = dtpkFecha2.Value;

                            if (oRegistrosLN.CalcularEstadoDeResultadoPorMesEnDolares(oRegistrosEN, Program.oDatosDeConexion))
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

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Selección de impresión de reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

                if( ColumnasAOcultar.Trim().Length > 0)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Formatear columnas dinamicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Where += string.Format(" and t.idTipoDeTransaccion = '{0}' ", cmbTipoDeTransaccion.SelectedValue);
            }

            if (Controles.IsNullOEmptyElControl(chkEstado) == false && Controles.IsNullOEmptyElControl(cmbEstado) == false)
            {
                Where += string.Format(" and Estado = '{0}' ", cmbEstado.Text);
            }

            if (Controles.IsNullOEmptyElControl(chkFecha) == false)
            {
                Where += string.Format(" and Fecha between '{0}' and '{1}' ", dtpkFecha1.Value.ToString("yyyy-MM-dd 00:00:00"), dtpkFecha2.Value.ToString("yyyy-MM-dd H:m:s"));
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

        private string ExtraerCuentasDelDataGrid()
        {
            string CuentasSeleccionada = "";

            if(dgvListarCuentas.SelectedRows != null)
            {
                foreach(DataGridViewRow Fila in dgvListarCuentas.SelectedRows)
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

        private void tsbPrinter_Click(object sender, EventArgs e)
        {
            if (dgvListadoDeReportes.SelectedRows != null)
            {
                string Reporte = dgvListadoDeReportes.Rows[dgvListadoDeReportes.CurrentRow.Index].Cells["Reporte"].Value.ToString();

                if (tsbVerEnDolares.CheckState == CheckState.Unchecked)
                    SeleccionarImpresion(Reporte);
                else if (tsbVerEnDolares.CheckState == CheckState.Checked)
                    SeleccionarImpresionDolares(Reporte);

            }else
            {
                MessageBox.Show("Se debe de seleccionar un tipo de reporte para poder imprimir información");
            }
            
        }

        private void dtpkFecha1_ValueChanged(object sender, EventArgs e)
        {
            chkFecha.CheckState = CheckState.Checked;
        }

        private void dtpkFecha2_ValueChanged(object sender, EventArgs e)
        {
            chkFecha.CheckState = CheckState.Checked;
        }

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


                    cmbGruposDeCuentas.DataSource = oRegistroLN.TraerDatos();
                    cmbGruposDeCuentas.DisplayMember = "DescGrupoDeCuentas";
                    cmbGruposDeCuentas.ValueMember = "idGrupoDeCuentas";
                    cmbGruposDeCuentas.SelectedIndex = -1;

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

        private void LLenarCategoriasParaLasCuentas()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                CategoriaDeCuentaEN oRegistroEN = new CategoriaDeCuentaEN();
                CategoriaDeCuentaLN oRegistroLN = new CategoriaDeCuentaLN();

                oRegistroEN.Where = "";

                if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGruposDeCuentas) == false)
                {
                    oRegistroEN.Where += string.Format(" and cc.idGrupoDeCuentas = {0} ", cmbGruposDeCuentas.SelectedValue);
                }

                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexion))
                {
                    cmbCategoriaDeCuentas.DataSource = oRegistroLN.TraerDatos();
                    cmbCategoriaDeCuentas.DisplayMember = "DescCategoriaDeCuenta";
                    cmbCategoriaDeCuentas.ValueMember = "idCategoriaDeCuenta";
                    cmbCategoriaDeCuentas.SelectedIndex = -1;

                }
                else { throw new ArgumentException(oRegistroLN.Error); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de la categoria asociada a grupos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void LLenarComboListadoTipoDetransacciones()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TipoDeTransaccionEN oRegistroEN = new TipoDeTransaccionEN();
                TipoDeTransaccionLN oRegistroLN = new TipoDeTransaccionLN();

                oRegistroEN.Where = "";
                
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexion))
                {

                    cmbTipoDeTransaccion.DataSource = oRegistroLN.TraerDatos();
                    cmbTipoDeTransaccion.DisplayMember = "DesTipoDeTransaccion";
                    cmbTipoDeTransaccion.ValueMember = "idTipoDeTransaccion";
                    cmbTipoDeTransaccion.SelectedIndex = -1;
                    

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Listado de Tipo de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void cmdMostarOcultarDatosPanelIzquierdo_Click(object sender, EventArgs e)
        {
            if (cmdMostarOcultarDatosPanelIzquierdo.Tag.ToString() == "OCULTAR")
            {
                splitContainer1.Panel1Collapsed = true;
                cmdMostarOcultarDatosPanelIzquierdo.Image = SisContador.Properties.Resources.rigtharrow16x16;
                cmdMostarOcultarDatosPanelIzquierdo.Tag = "MOSTRAR";
                cmdMostarOcultarDatosPanelIzquierdo.Text = "Mostrar panel";
            }
            else
            {
                if (cmdMostarOcultarDatosPanelIzquierdo.Tag.ToString() == "MOSTRAR")
                {
                    splitContainer1.Panel1Collapsed = false;
                    cmdMostarOcultarDatosPanelIzquierdo.Image = SisContador.Properties.Resources.leftarrows16x16;
                    cmdMostarOcultarDatosPanelIzquierdo.Tag = "OCULTAR";
                    cmdMostarOcultarDatosPanelIzquierdo.Text = "Ocultar panel";
                }
              
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvListadoDeReportes.SelectedRows != null)
            {
                string Reporte = dgvListadoDeReportes.Rows[dgvListadoDeReportes.CurrentRow.Index].Cells["Reporte"].Value.ToString();
                ImportacionesAExcel(Reporte);

            }
            else
            {
                MessageBox.Show("Se debe de seleccionar un tipo de reporte para poder imprimir información");
            }
        }

        private void ImportacionesAExcel(string Reporte)
        {
            try
            {
                switch (Reporte)
                {
                    case "Estado de resultado para excel":

                        ImportaEstadoDeResultadoDelMEs();                        

                        break;
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccione un tipo de busqeuda para poder aplicar la importación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
                
        private void ImportaEstadoDeResultadoDelMEs()
        {
            try
            {
             
                if (MessageBox.Show("¿Confirma que desea iniciar el proceso de exportación?", "Autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;

                CarpetaDeRespaldoDeArchivosDeExcel();

                DataTable DT;
                bool Res = false;

                //Acá vamos a poblar el excel con lo que esta cargado en la grilla
                if (dgvListar.Rows.Count > 0)
                {
                    Res = true;
                    //Esta tabla es necesaria para desvincular los datos del datagridview, sino se ve afectado en el proceso.
                    DT = ObtenerDataTableConRegistrosMarcadosDeLAGrilla();                    
                    
                    foreach(DataGridViewColumn Col in dgvListar.Columns)
                    {
                        if (Col.Visible == false && DT.Columns.Contains(Col.Name))
                        {
                            DT.Columns.Remove(Col.Name);
                        }
                    }
                    
                    //Actualizamos el nombre de la columna igual al titulo de la columna, sustituyendo los espacios por guiones bajos..
                    foreach (DataGridViewColumn Col in dgvListar.Columns)
                    {
                        if (Col.Visible == true)
                        {
                            if(EvaluarSiExisteLaColumna(DT, Col.Name))
                            {
                                DT.Columns[Col.Name].ColumnName = Col.HeaderText.Replace(" ", "_");
                            }
                        }
                    }

                }
                else
                {
                    Res = false;
                    DT = null;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Filtre los datos que desea exportar...", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.Cursor = Cursors.Default;
                if (Res == true)
                {
                    cmdExportarAExcel.Enabled = false;
                    tsbSearch.Enabled = false;
                    //txtBuscarPersona.Enabled = false;
                    //gbMostrarOcultar.Enabled = false;
                    clsExportar oExportar = new clsExportar();

                    //int [] Ejes;
                    string Titulo;
                    string Subtitulo;

                    Titulo = "Estado de Resultado Consolidado";
                    Subtitulo = string.Format("Estado de Resultado Consolidado");

                    oExportar.pty_prtFecha = true;
                    oExportar.pty_prtHora = true;
                    oExportar.pty_prtLogo = true;

                    oExportar.pty_prtNombreSistema = true;
                    oExportar.pty_prtNombreDelSistema = Program.NombreVersionSistema;
                    oExportar.pty_prtNombreHoja = "Estado";

                    /*Traemos los datos de la empresa para la generación*/
                    EmpresaEN oEmpresa_EN = new EmpresaEN();
                    EmpresaLN oEmpresa_LN = new EmpresaLN();
                    oEmpresa_EN.IdEmpresa = 1;
                    if (oEmpresa_LN.Listado(oEmpresa_EN, Program.oDatosDeConexion))
                    {
                        DataTable dtEmpresa = new DataTable();
                        dtEmpresa = oEmpresa_LN.TraerDatos();
                        
                        oExportar.pty_Empresa_Nombre = oEmpresa_EN.Nombre.Replace("\n", " ");
                        oExportar.pty_Empresa_Datos1 = oEmpresa_EN.Direccion;
                        oExportar.pty_Empresa_Datos2 = oEmpresa_EN.NRuc;

                        if (oEmpresa_EN.oLogo == DBNull.Value)
                        {

                        }
                        else
                        {
                            SaveImage_VB2008.SaveImage_VB2008 sv = new SaveImage_VB2008.SaveImage_VB2008();
                            sv.ProcesarImagenToBitMap(oEmpresa_EN.oLogo);
                            PictureBox pbxImagen = new PictureBox();
                            pbxImagen.Image = sv.ImagenGet();
                            sv = null;
                            if (Program.Exportar_Logo_Para_Excel(pbxImagen) == false)
                            {
                                MessageBox.Show("Error al intentar generar el logo para exportación a excel desde la base de datos.\nSi existe, se utilizará el último logo generado.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            pbxImagen = null;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oEmpresa_LN.Error, "Listado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    oEmpresa_EN = null;
                    oEmpresa_LN = null;
                    /*Fin de: Traemos los datos de la empresa para la generación*/                    

                    oExportar.pty_RutaParaExportacion = Program.oConfiguracionEN.RutaRespaldosDeExcel.ToString();
                    oExportar.pty_prtTitulo = Titulo;
                    oExportar.pty_prtSubtitulo = Subtitulo;
                    oExportar.pty_prtGraficoLinea = false;
                    oExportar.pty_prtGraficoBarra = false;
                    oExportar.pty_prtGraficoDeBarrasEjes = false;
                    oExportar.pty_prtTituloEjeX = "Ninguna columna";
                    oExportar.pty_prtTituloEjeY = "Valores";
                    oExportar.pty_prtTituloEjeX1 = "Ninguna columna";
                    oExportar.pty_prtTituloEjeY1 = "Valores";
                    //oExportar.pty_prtEjes = Ejes;

                    oExportar.pty_prtTituloGraficoBarra = Titulo + "\n" + Subtitulo;
                    oExportar.pty_prtTituloGraficoLinea = Titulo + "\n" + Subtitulo;
                    oExportar.pty_DT = DT;
                    oExportar.pty_StartupPath = Application.StartupPath;

                    try
                    {
                        int indice_progreso = 0;
                        Mostrar_Barra_de_progreso();
                        Inicializar_Barra_de_progreso(DT.Rows.Count, 0);

                        oExportar.CrearLibro();
                        oExportar.Configuracion_inicial_Excel();

                        foreach (DataRow DR in DT.Rows)
                        {
                            indice_progreso = indice_progreso + 1;
                            Incrementar_Barra_de_progreso(indice_progreso);
                            oExportar.Exportar_a_Excel(DR);
                        }
                        MessageBox.Show("Exportación finalizada satisfactoriamente", "Exportación a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        oExportar.Configuracion_final_Excel();
                        Ocultar_Barra_de_progreso();
                    }
                    catch (Exception ex)
                    {
                        Application.DoEvents();
                        Ocultar_Barra_de_progreso();
                        MessageBox.Show(ex.Message, "Exportando a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cmdExportarAExcel.Enabled = true;
                        tsbSearch.Enabled = true;
                        this.Cursor = Cursors.Default;
                        oExportar = null;
                    }
                    
                }
                else
                {
                    Application.DoEvents();
                    MessageBox.Show("Error", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DT = null;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable ObtenerDataTableConRegistrosMarcadosDeLAGrilla()
        {
            DataTable DT = (DataTable)dgvListar.DataSource;
            DataTable DTCopy = new DataTable();

            try
            {
                if (dgvListar.Rows.Count > 0)
                {
                    DTCopy = DT.AsEnumerable().Where(r => r.Field<string>("Descripcion").Length > 0 ).CopyToDataTable();

                }

                return DTCopy;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Evaluar si la fila en el DGV no esta Oculta", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return DTCopy;
            }

        }

        private bool EvaluarSiExisteLaColumna(DataTable DT, String Columna)
        {
            try
            {
                if (DT.Columns.Count > 0)
                {
                    foreach (DataColumn item in DT.Columns)
                    {
                        if (item.ColumnName.Trim().ToUpper() == Columna.Trim().ToUpper())
                        {
                            return true;
                        }
                    }

                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Evaluar si existe la columna", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }

        }

        private void CarpetaDeRespaldoDeArchivosDeExcel()
        {
            try
            {
                String RutaDeExcel = Program.oConfiguracionEN.RutaRespaldosDeExcel;
                if (!Directory.Exists(RutaDeExcel))
                {
                    Directory.CreateDirectory(RutaDeExcel);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caperta de respaldo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        decimal TasaDeCambioALDia = 0;

        private bool ValidarSiExisteTasaDeCambio()
        {
            try
            {

                TasaDeCambioEN oRegistroEN = new TasaDeCambioEN();
                TasaDeCambioLN oRegistroLN = new TasaDeCambioLN();

                if (oRegistroLN.TraerTasaDeCambioDelMesEnBaseATransacciones(oRegistroEN, Program.oDatosDeConexion))
                {
                    if(oRegistroLN.TraerDatos().Rows.Count > 0)
                    {
                        DataRow Fila = oRegistroLN.TraerDatos().Rows[0];
                        TasaDeCambioALDia = Convert.ToDecimal(Fila["Cambio"].ToString());
                    }
                    else
                    {
                        TasaDeCambioALDia = 0;
                    }
                }

                return true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Validar si existe la tasa de cambio", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
        }

        private bool ValidarSiExisteTasaDeCambioPorFecha()
        {
            try
            {

                TasaDeCambioEN oRegistroEN = new TasaDeCambioEN();
                TasaDeCambioLN oRegistroLN = new TasaDeCambioLN();

                oRegistroEN.Fecha = dtpkFecha2.Value;

                if (oRegistroLN.TraerTasaDeCambioDelMesPorFecha(oRegistroEN, Program.oDatosDeConexion))
                {
                    if (oRegistroLN.TraerDatos().Rows.Count > 0)
                    {
                        DataRow Fila = oRegistroLN.TraerDatos().Rows[0];
                        TasaDeCambioALDia = Convert.ToDecimal(Fila["Cambio"].ToString());
                    }
                    else
                    {
                        TasaDeCambioALDia = 0;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validar si existe la tasa de cambio", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
        }

        #region "Barra de progreso"

        private void Inicializar_Barra_de_progreso(int Maximo, int Minimo)
        {
            Barradeprogreso.Minimum = Minimo;
            Barradeprogreso.Maximum = Maximo;
            Barradeprogreso.Value = 0;
            lbaBarradeprogreso.Text = "Procesando " + Barradeprogreso.Value.ToString() + " de " + Barradeprogreso.Maximum + " registros";
            Application.DoEvents();
        }

        private void Mostrar_Barra_de_progreso()
        {
            //tsProgreso.Visible = true;
            Barradeprogreso.Visible = true;
            lbaBarradeprogreso.Visible = true;
        }

        private void Ocultar_Barra_de_progreso()
        {
            //tsProgreso.Visible = false;
            Barradeprogreso.Visible = false;
            lbaBarradeprogreso.Visible = false;
        }

        private void Incrementar_Barra_de_progreso(int incremento)
        {
            Barradeprogreso.Value = incremento;
            lbaBarradeprogreso.Text = "Procesando " + Barradeprogreso.Value.ToString() + " de " + Barradeprogreso.Maximum + " registros";
            Application.DoEvents();
        }

        #endregion

        private void tsbVerEnDolares_Click(object sender, EventArgs e)
        {
            tsbVerEnDolares.Checked = !tsbVerEnDolares.Checked;

            if (tsbVerEnDolares.Checked == true)
            {
                tsbVerEnDolares.Image = Properties.Resources.unchecked16x16;
            }
            else
            {
                tsbVerEnDolares.Image = Properties.Resources.checked16x16;
                tsbEtiquetaTasa.Visible = false;
                tsbTasaDeCambio.Visible = false;
                tsbTasaDeCambio.Text = string.Empty;
            }
        }

        private void tsbAplicarBorde_Click(object sender, EventArgs e)
        {
            tsbAplicarBorde.Checked = !tsbAplicarBorde.Checked;

            if (tsbAplicarBorde.Checked == true)
            {
                tsbAplicarBorde.Image = Properties.Resources.unchecked16x16;
            }
            else
            {
                tsbAplicarBorde.Image = Properties.Resources.checked16x16;               
            }
        }

        private void tsbSimbolo_Click(object sender, EventArgs e)
        {
            tsbSimbolo.Checked = !tsbSimbolo.Checked;
            if(tsbSimbolo.Checked == true)
            {
                tsbSimbolo.Image = Properties.Resources.unchecked16x16;
            }else
            {
                tsbSimbolo.Image = Properties.Resources.checked16x16;
            }
        }
    }
}
