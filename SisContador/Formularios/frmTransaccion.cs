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
    public partial class frmTransaccion : Form
    {
        public frmTransaccion()
        {
            InitializeComponent();
        }

        private string NOMBRE_ENTIDAD_PRIVILEGIO = "Transacciones";
        private string NOMBRE_ENTIDAD = "Administrar las transacciones";
        private string NOMBRE_LLAVE_PRIMARIA = "idTransacciones";
        private int ValorLlavePrimariaEntidad;
        private int IndiceSeleccionado;
        public int IdTipoDeTransaccion { set; get; }      

        private frmVisor ofrmVisor = null;
        private frmVisor ofrmVisor_1 = null;

        private frmTransaccionOperacionBack ofrmEgresos = null;
        private frmTransaccionOperacionBack ofrmIngresos = null;
        private frmTransaccionOperacionBack ofrmDiarios = null;

        private frmTransaccionOperacionBack ofrmEgresos1 = null;
        private frmTransaccionOperacionBack ofrmIngresos1 = null;
        private frmTransaccionOperacionBack ofrmDiarios1 = null;

        #region "Funciones del programador"

        public bool ActivarFiltros { set; get; }
        public bool VariosRegistros { set; get; }
        public string TituloVentana { set; get; }
        public TransaccionTMPEN[] oTransacciones = new TransaccionTMPEN[0];

        public string Columnas { set; get; }

        public DataTable DTRegistros;

        public bool Activar_btn_imprimir { set; get; }
        /// <summary>
        /// Activa o Desactiva la opcion de ingresar un registro de la barra de menus.
        /// </summary>
        public bool Activar_btn_Nuevo { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de desplegar el menu contextual de la ventana.
        /// </summary>
        public bool Activar_MenuContextual { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de ingresar un nuevo registro dentro del menu contextual.
        /// </summary>
        public bool Activar_MenuContextual_Nuevo { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de ingresar un nuevo registro a partir de uno ya existente, dentro del menu contextual
        /// </summary>
        public bool Activar_MenuContextual_NuevoApartirDe { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción de Modifcar un registro, dentro del menu contextual
        /// </summary>
        public bool Activar_MenuContextual_Modificar { set; get; }
        /// <summary>
        /// Activa o Desactiva la opcioón de Eliminar un registro, dentro del menu contextual.
        /// </summary>
        public bool Activar_MenuContextual_Eliminar { set; get; }
        /// <summary>
        /// Activa o Desactiva la opción la de Consultar, dentro del menu contextual.
        /// </summary>
        public bool Activar_MenuContextual_Consultar { set; get; }

        public bool Activar_Exportacion { set; get; }

        public bool EvaluarSiHayRegistrosEnLaTablaTMP()
        {
            try
            {

                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                if (oRegistroLN.EvaluarSiHayDatosEnLaTablaTMP(oRegistroEN, Program.oDatosDeConexion))
                {
                    throw new ArgumentException(oRegistroLN.Error);                      
                }else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Evaluar si hay registro pendiente en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
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
                                
                if (IdTipoDeTransaccion > 0)
                {
                    oRegistroEN.Where = string.Format(" and idTipoDeTransaccion = {0}", IdTipoDeTransaccion);
                }
                
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexion))
                {

                    cmbTipoDeTransaccion.DataSource = oRegistroLN.TraerDatos();
                    cmbTipoDeTransaccion.DisplayMember = "DesTipoDeTransaccion";
                    cmbTipoDeTransaccion.ValueMember = "idTipoDeTransaccion";
                    
                    if (oRegistroLN.TraerDatos().Rows.Count == 1)
                    {
                        cmbTipoDeTransaccion.Enabled = false;
                    }else
                    {
                        cmbTipoDeTransaccion.SelectedIndex = -1;
                    }


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

        private void LLenarComboListadoGrupoDeCuentas()
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

                    cmbGrupoDeCuentas.DataSource = oRegistroLN.TraerDatos();
                    cmbGrupoDeCuentas.DisplayMember = "DescGrupoDeCuentas";
                    cmbGrupoDeCuentas.ValueMember = "idGrupoDeCuentas";
                    cmbGrupoDeCuentas.SelectedIndex = -1;

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Listado de Grupo de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void LLenarComboListadoDeCategoriaDeCuentas()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                CategoriaDeCuentaEN oRegistroEN = new CategoriaDeCuentaEN();
                CategoriaDeCuentaLN oRegistroLN = new CategoriaDeCuentaLN();

                oRegistroEN.Where = "";

                if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGrupoDeCuentas) == false)
                {
                    oRegistroEN.Where = string.Format(" and  cc.idGrupoDeCuentas = {0}", cmbGrupoDeCuentas.SelectedValue);
                }
                                
                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexion))
                {

                    cmbCategoriaDeLasCuentas.DataSource = oRegistroLN.TraerDatos();
                    cmbCategoriaDeLasCuentas.DisplayMember = "DescCategoriaDeCuenta";
                    cmbCategoriaDeLasCuentas.ValueMember = "idCategoriaDeCuenta";
                    cmbCategoriaDeLasCuentas.SelectedIndex = -1;

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Listado de Categoria asociadas a las cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ActivarFiltrosDelaBusqueda()
        {
            if (ActivarFiltros == false)
            {
                
                tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbNuevoRegistro.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbMarcarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbSeleccionarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                tsbMarcarTodos.Visible = false;
                tsbSeleccionarTodos.Visible = false;

                VariosRegistros = false;

                Activar_MenuContextual = true;

                Activar_MenuContextual_Consultar = true;
                Activar_MenuContextual_Nuevo = true;
                Activar_MenuContextual_NuevoApartirDe = true;
                Activar_MenuContextual_Eliminar = true;
                Activar_MenuContextual_Modificar = true;

                this.Text = TituloVentana;           
                
                if(IdTipoDeTransaccion == 0)
                {
                    dgvLista.ContextMenuStrip = null;
                    tsbNuevoRegistro.Visible = false;
                }else
                {
                    if(IdTipoDeTransaccion > 0)
                    {
                        chkTipoDeTransaccion.CheckState = CheckState.Checked;
                    }
                }
                
            }
            else
            {
                if (ActivarFiltros == true)
                {

                    tsbFiltrar.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbNuevoRegistro.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbImprimir.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbMarcarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    tsbSeleccionarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                    tsbSeleccionarTodos.Visible = true;

                    if (VariosRegistros == false)
                    {
                        tsbMarcarTodos.Visible = false;
                    }
                    else
                    {
                        tsbMarcarTodos.Visible = true;
                    }

                    this.Text = TituloVentana;

                    if (tsbNuevoRegistro.Enabled == true)
                    {
                        tsbNuevoRegistro.Visible = Activar_btn_Nuevo;
                    }
                    if (tsbImprimir.Visible == true)
                        tsbImprimir.Visible = Activar_btn_imprimir;

                    mcsMenu.Enabled = Activar_MenuContextual;
                    AgregrarColumnasAlDTRegistros();

                }
            }
        }

        private void AgregrarColumnasAlDTRegistros()
        {
            if (Columnas == null) return;

            if (DTRegistros == null)
            {

                string[] arrayColumnas = Columnas.Split(',');

                DTRegistros = new DataTable();

                foreach (string item in arrayColumnas)
                {
                    DataColumn c = DTRegistros.Columns.Add();
                    c.ColumnName = item.Trim();

                }
            }
        }

        private void DesmarcarFilas(int FilaMarcada)
        {
            try
            {

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    if (Fila.Index != FilaMarcada && Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                    {
                        Fila.Cells["Seleccionar"].Value = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desmarcar filas. \n" + ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarRegistrosAlDTUsuario()
        {
            if (Columnas == null) return;

            if (oTransacciones.Length > 0)
            {
                //DataTable DTClass = ConvertirClassADT();
                DataTable DTClass = TraerInformacionDDGV();

                foreach (DataRow Fila in DTClass.Rows)
                {
                    bool Existe = false;

                    if (DTRegistros.Rows.Count > 0)
                    {
                        foreach (DataRow Item in DTRegistros.Rows)
                        {
                            int IdRegistro;
                            int.TryParse(Item[NOMBRE_LLAVE_PRIMARIA].ToString(), out IdRegistro);

                            if (IdRegistro == Convert.ToInt32(Fila[NOMBRE_LLAVE_PRIMARIA]))
                            {
                                Existe = true;
                            }
                        }
                    }
                    else
                    {
                        Existe = false;
                    }

                    if (Existe == false)
                    {
                        DataRow row = DTRegistros.Rows.Add();

                        String[] ArrayColumnas = Columnas.Split(',');

                        foreach (string c in ArrayColumnas)
                        {
                            row[c.Trim()] = Fila[c.Trim()];
                        }

                        Application.DoEvents();

                    }

                }
            }
        }

        private DataTable ConvertirClassADT()
        {
            DataTable DTClass = new DataTable();

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(oTransacciones.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serializer.Serialize(sw, oTransacciones);

            DataSet ds = new DataSet(NOMBRE_ENTIDAD_PRIVILEGIO);
            System.IO.StringReader reader = new System.IO.StringReader(sw.ToString());
            ds.ReadXml(reader);

            DTClass = ds.Tables[0];
            return DTClass;

        }

        private DataTable TraerInformacionDDGV()
        {
            DataTable DT = (DataTable)dgvLista.DataSource;
            DataTable DTCopy = new DataTable();

            if (dgvLista.Rows.Count > 0)
            {
                DTCopy = DT.AsEnumerable().Where(r => r.Field<bool>("Seleccionar") == true).CopyToDataTable();
            }

            return DTCopy;
        }

        private DataTable AgregarColumnaSeleccionar(DataTable Datos)
        {
            DataColumn Seleccionar = new DataColumn("Seleccionar", Type.GetType("System.Boolean"));
            Seleccionar.Caption = " ";
            Seleccionar.DefaultValue = false;

            Datos.Columns.Add(Seleccionar);
            Seleccionar.SetOrdinal(0);

            return Datos;
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
        private string WhereDinamico() {

            string Where = "";

            if (Controles.IsNullOEmptyElControl(chkNoTransaccion) == false && Controles.IsNullOEmptyElControl(txtNoTransaccion) == false) {
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
                Where += string.Format(" and SoloFecha( Fecha ) between SoloFecha('{0}') and SoloFecha('{1}') ", dtpkFecha1.Value.ToString("yyyy-MM-dd 00:00:00"), dtpkFecha2.Value.ToString("yyyy-MM-dd H:m:s"));                
            }

            if (Controles.IsNullOEmptyElControl(chkIdCuenta) == false && SeDigitoEnLaMascara())
            {
                Where += string.Format(@" and (Select count(tt1.idTransaccionDetalle) from transacciondetalle as tt1 
                inner join cuenta as c on c.NoCuenta = tt1.NoCuenta where c.idCuenta like '{0}%' and c.NivelCuenta > 1 ) > 0 ", ExtraerCadenaDelaMascar());
            }

            if(Controles.IsNullOEmptyElControl(chkCategoriaDeLasCuentas) == false && Controles.IsNullOEmptyElControl(cmbCategoriaDeLasCuentas))
            {
                Where += string.Format(@" and (Select count(tt1.idTransaccionDetalle) from transacciondetalle as tt1 
                inner join cuenta as c on c.NoCuenta = tt1.NoCuenta 
                where c.idCategoriaDeCuenta > {0} and c.NivelCuenta > 1 ) > 0", cmbCategoriaDeLasCuentas.SelectedValue);
            }

            if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGrupoDeCuentas))
            {
                Where += string.Format(@" and (Select count(tt1.idTransaccionDetalle) from transacciondetalle as tt1 
                inner join cuenta as c on c.NoCuenta = tt1.NoCuenta 
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                where cc.idGrupoDeCuentas > {0} and c.NivelCuenta > 1 ) > 0 ", cmbGrupoDeCuentas.SelectedValue);
            }

            return Where;

        }

        private string TituloDinamico()
        {

            string Titulo = "";

            if (Controles.IsNullOEmptyElControl(chkNoTransaccion) == false && Controles.IsNullOEmptyElControl(txtNoTransaccion) == false)
            {
                Titulo += string.Format(" No. Transacción: '{0}', ", txtNoTransaccion.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkConcepto) == false && Controles.IsNullOEmptyElControl(txtConcepto) == false)
            {
                Titulo += string.Format(" Concepto: '{0}', ", txtConcepto.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkTipoDeTransaccion) == false && Controles.IsNullOEmptyElControl(cmbTipoDeTransaccion) == false)
            {
                Titulo += string.Format(" Tipo de Transacción: '{0}', ", cmbTipoDeTransaccion.Text);
            }

            if (Controles.IsNullOEmptyElControl(chkEstado) == false && Controles.IsNullOEmptyElControl(cmbEstado) == false)
            {
                Titulo += string.Format(" Estado: '{0}', ", cmbEstado.Text);
            }

            if (Controles.IsNullOEmptyElControl(chkFecha) == false )
            {
                Titulo += string.Format(" Fecha: '{0}' - '{1}', ", dtpkFecha1.Value, dtpkFecha2.Value);
            }

            if (Controles.IsNullOEmptyElControl(chkIdCuenta) == false && SeDigitoEnLaMascara())
            {
                Titulo += string.Format(" No. Cuenta: '{0}', ", ExtraerCadenaDelaMascar());
            }

            if (Controles.IsNullOEmptyElControl(chkCategoriaDeLasCuentas) == false && Controles.IsNullOEmptyElControl(cmbCategoriaDeLasCuentas))
            {
                Titulo += string.Format(" Categoria de la Cuenta: '{0}', ", cmbCategoriaDeLasCuentas.Text);
            }

            if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGrupoDeCuentas))
            {
                Titulo += string.Format(" Grupo de Cuenta: '{0}', ", cmbGrupoDeCuentas.Text);
            }

            if (Titulo.Length > 0)
            {
                Titulo = Titulo.Substring(0, Titulo.Length - 2);
            }
                        
            return Titulo;
                        

        }

        private void LLenarListado() {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                TransaccionTMPEN oRegistrosEN = new TransaccionTMPEN();
                TransaccionTMPLN oRegistrosLN = new TransaccionTMPLN();

                oRegistrosEN.Where = WhereDinamico();
                oRegistrosEN.OrderBy = " Order by idTipoDeTransaccion asc,Fecha desc ";

                if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexion)) {

                    dgvLista.Columns.Clear();
                    
                    if (ActivarFiltros == true)
                    {
                        dgvLista.DataSource = AgregarColumnaSeleccionar(oRegistrosLN.TraerDatos());
                    }
                    else {
                        dgvLista.DataSource = oRegistrosLN.TraerDatos();
                    }

                    FormatearDGV();                   
                    this.dgvLista.ClearSelection();

                    tsbNoRegistros.Text = "No. Registros: " + oRegistrosLN.TotalRegistros().ToString();
                    

                }
                else
                {
                    throw new ArgumentException(oRegistrosLN.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Llenar listado de registro en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }                

        }

        private void FormatearDGV()
        {
            try
            {
                this.dgvLista.AllowUserToResizeRows = false;
                this.dgvLista.AllowUserToAddRows = false;
                this.dgvLista.AllowUserToDeleteRows = false;
                this.dgvLista.DefaultCellStyle.BackColor = Color.White;

                if (VariosRegistros == true)
                {
                    this.dgvLista.MultiSelect = VariosRegistros;
                    this.dgvLista.RowHeadersVisible = false;
                }
                else
                {
                    this.dgvLista.MultiSelect = false;
                    this.dgvLista.RowHeadersVisible = true;
                }

                this.dgvLista.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvLista.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                string OcultarColumnas = "idTransacciones,idTipoDeTransaccion,NombreTabla,RegistroTMP";
                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasDelDGV();

                dgvLista.Columns["Valor"].DefaultCellStyle.Format = "###,###,##0.00";

                this.dgvLista.RowHeadersWidth = 25;

                this.dgvLista.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvLista.StandardTab = true;
                this.dgvLista.ReadOnly = false;
                this.dgvLista.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnasEnElDGV(String ColumnasDelDGV)
        {
            if (dgvLista.Columns.Count > 0)
            {
                String[] ArrayColumnasDGV = ColumnasDelDGV.Split(',');
                foreach (String c in ArrayColumnasDGV)
                {

                    foreach (DataGridViewColumn c1 in dgvLista.Columns)
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
            if (dgvLista.Columns.Count > 0)
            {

                foreach (DataGridViewColumn c1 in dgvLista.Columns)
                {
                    if (c1.Visible == true)
                    {
                        if (c1.Name.Trim().ToUpper() != "Seleccionar".ToUpper())
                        {
                            FormatoDGV oFormato = new FormatoDGV(c1.Name.Trim());
                            if (oFormato.ValorEncontrado == false)
                            {
                                oFormato = new FormatoDGV(c1.Name.Trim(), "Transacciones");
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

        private void CargarPrivilegiosDelUsuario(){

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuariosEN oRegistroEN = new ModuloInterfazUsuariosEN();
                ModuloInterfazUsuariosLN oRegistroLN = new ModuloInterfazUsuariosLN();

                oRegistroEN.oUsuarioEN.idUsuario = Program.oLoginEN.idUsuario;
                oRegistroEN.oPrivilegioEN.oModuloInterfazEN.oInterfazEN.Nombre = NOMBRE_ENTIDAD_PRIVILEGIO;

                if (oRegistroLN.ListadoPrivilegiosDelUsuariosPorIntefaz(oRegistroEN, Program.oDatosDeConexion))
                {

                    foreach (ToolStripItem item in mcsMenu.Items)
                    {
                        if (item.Tag != null)
                        {
                            if (item.GetType() == typeof(ToolStripMenuItem))
                            {
                                item.Enabled = oRegistroLN.VerificarSiTengoAcceso(item.Tag.ToString());
                            }
                        }
                    }

                    tsbImprimir.Enabled = oRegistroLN.VerificarSiTengoAcceso("Imprimir");
                    tsbNuevoRegistro.Enabled = oRegistroLN.VerificarSiTengoAcceso("Nuevo");

                    EvaluarRegistros();



                }
                else
                {

                    mcsMenu.Enabled = false;
                    tsbImprimir.Enabled = false;
                    tsbNuevoRegistro.Enabled = false;
                    throw new ArgumentException(oRegistroLN.Error);

                }

                oRegistroEN = null;
                oRegistroLN = null;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void EvaluarRegistros()
        {
            if (dgvLista.Rows.Count > 0)
            {
                if (dgvLista.CurrentRow != null)
                {
                    DataGridViewRow Fila = dgvLista.CurrentRow;
                    string Estado = Fila.Cells["Estado"].Value.ToString();
                    string NombreTabla = Fila.Cells["NombreTabla"].Value.ToString();
                    int RegistroTMP = Convert.ToInt32(Fila.Cells["RegistroTMP"].Value.ToString());

                    if(NombreTabla.Trim().ToUpper() == "transacciones".ToUpper() && RegistroTMP == 1)
                    {
                        actualizarToolStripMenuItem.Enabled = false;
                        eliminarToolStripMenuItem.Enabled = false;
                    }else
                    {
                        actualizarToolStripMenuItem.Enabled = true;
                        eliminarToolStripMenuItem.Enabled = true;
                    }

                    if(Estado.ToUpper() == "GRABADA")
                    {
                        tsmGrabarDatos.Enabled = false;
                    }

                }
            }
            
        }

        private void AbrirVentanasOperaconesBak(string OperacionesARealizar)
        {
            
            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (IdTipoDeTransaccion)
                {

                    case 1:

                        if(ofrmEgresos == null || ofrmEgresos.IsDisposed)
                        {
                            ofrmEgresos = new frmTransaccionOperacionBack();
                            ofrmEgresos.OperacionARealizar = OperacionesARealizar;
                            ofrmEgresos.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
                            ofrmEgresos.NombreEntidad = NOMBRE_ENTIDAD;
                            ofrmEgresos.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
                            ofrmEgresos.MdiParent = this.ParentForm;
                            ofrmEgresos.IdTipoDeTransaccion_ = this.IdTipoDeTransaccion;
                            ofrmEgresos.Show();
                        }else
                        {
                            MessageBox.Show("Actualmente la ventana se encuentra en una operacion de '" + ofrmEgresos.OperacionARealizar + "'");
                            ofrmEgresos.BringToFront();
                            
                        }

                        break;

                    case 2:

                        if (ofrmIngresos == null || ofrmIngresos.IsDisposed)
                        {
                            ofrmIngresos = new frmTransaccionOperacionBack();
                            ofrmIngresos.OperacionARealizar = OperacionesARealizar;
                            ofrmIngresos.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
                            ofrmIngresos.NombreEntidad = NOMBRE_ENTIDAD;
                            ofrmIngresos.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
                            ofrmIngresos.MdiParent = this.ParentForm;
                            ofrmIngresos.IdTipoDeTransaccion_ = this.IdTipoDeTransaccion;
                            ofrmIngresos.Show();
                        }
                        else
                        {
                            MessageBox.Show("Actualmente la ventana se encuentra en una operacion de '" + ofrmIngresos.OperacionARealizar + "'");
                            ofrmIngresos.BringToFront();
                            
                        }

                        break;

                    case 3:

                        if (ofrmDiarios == null || ofrmDiarios.IsDisposed)
                        {
                            ofrmDiarios = new frmTransaccionOperacionBack();
                            ofrmDiarios.OperacionARealizar = OperacionesARealizar;
                            ofrmDiarios.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
                            ofrmDiarios.NombreEntidad = NOMBRE_ENTIDAD;
                            ofrmDiarios.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
                            ofrmDiarios.MdiParent = this.ParentForm;
                            ofrmDiarios.IdTipoDeTransaccion_ = this.IdTipoDeTransaccion;
                            ofrmDiarios.Show();
                        }
                        else
                        {
                            MessageBox.Show("Actualmente la ventana se encuentra en una operacion de '" + ofrmDiarios.OperacionARealizar + "'");
                            ofrmDiarios.BringToFront();
                            
                        }

                        break;


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ventana de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void AbrirVentanasOperacones(string OperacionesARealizar)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (IdTipoDeTransaccion)
                {

                    case 1:

                        if (ofrmEgresos1 == null || ofrmEgresos1.IsDisposed)
                        {
                            ofrmEgresos1 = new frmTransaccionOperacionBack();
                            ofrmEgresos1.OperacionARealizar = OperacionesARealizar;
                            ofrmEgresos1.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
                            ofrmEgresos1.NombreEntidad = NOMBRE_ENTIDAD;
                            ofrmEgresos1.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
                            ofrmEgresos1.MdiParent = this.ParentForm;
                            ofrmEgresos1.IdTipoDeTransaccion_ = this.IdTipoDeTransaccion;
                            ofrmEgresos1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Actualmente la ventana se encuentra en una operacion de '" + ofrmEgresos1.OperacionARealizar + "'");
                            ofrmEgresos1.BringToFront();                            
                        }

                        break;

                    case 2:

                        if (ofrmIngresos1 == null || ofrmIngresos1.IsDisposed)
                        {
                            ofrmIngresos1 = new frmTransaccionOperacionBack();
                            ofrmIngresos1.OperacionARealizar = OperacionesARealizar;
                            ofrmIngresos1.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
                            ofrmIngresos1.NombreEntidad = NOMBRE_ENTIDAD;
                            ofrmIngresos1.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
                            ofrmIngresos1.MdiParent = this.ParentForm;
                            ofrmIngresos1.IdTipoDeTransaccion_ = this.IdTipoDeTransaccion;
                            ofrmIngresos1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Actualmente la ventana se encuentra en una operacion de '" + ofrmIngresos1.OperacionARealizar + "'");
                            ofrmIngresos1.BringToFront();
                            
                        }

                        break;

                    case 3:

                        if (ofrmDiarios1 == null || ofrmDiarios1.IsDisposed)
                        {
                            ofrmDiarios1 = new frmTransaccionOperacionBack();
                            ofrmDiarios1.OperacionARealizar = OperacionesARealizar;
                            ofrmDiarios1.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
                            ofrmDiarios1.NombreEntidad = NOMBRE_ENTIDAD;
                            ofrmDiarios1.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
                            ofrmDiarios1.MdiParent = this.ParentForm;
                            ofrmDiarios1.IdTipoDeTransaccion_ = this.IdTipoDeTransaccion;
                            ofrmDiarios1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Actualmente la ventana se encuentra en una operacion de '" + ofrmDiarios1.OperacionARealizar + "'");
                            ofrmDiarios1.BringToFront();                            
                        }

                        break;


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ventana de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void MostrarFormularioParaOperacion(string OperacionesARealizar)
        {
            //AbrirVentanasOperacones(OperacionesARealizar);                                    
            AbrirVentanasOperaconesBak(OperacionesARealizar);

        }

        private void AsignarLlavePrimaria()
        {
            this.ValorLlavePrimariaEntidad = Convert.ToInt32(this.dgvLista.Rows[this.IndiceSeleccionado].Cells[this.NOMBRE_LLAVE_PRIMARIA].Value);
        }

        #endregion

        private void frmTransaccion_Shown(object sender, EventArgs e)
        {
            dgvLista.ContextMenuStrip = mcsMenu;
            LLenarComboListadoTipoDetransacciones();
            LLenarComboListadoGrupoDeCuentas();
            LLenarComboListadoDeCategoriaDeCuentas();
            CargarPrivilegiosDelUsuario();

            ActivarFiltrosDelaBusqueda();
            tsbFiltroAutomatico_Click(null, null);

            ConfiguracionesDeLaVentana();

            if (tsbFiltroAutomatico.CheckState == CheckState.Checked)
                LLenarListado();


        }

        private void ConfiguracionesDeLaVentana()
        {
            try
            {

                DateTime fecha1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpkFecha1.Value = fecha1;
                chkFecha.CheckState = CheckState.Checked;

                DateTime Fecha2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                dtpkFecha2.Value = Fecha2;


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuración generales dentro de la ventana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            LLenarListado();
        }

        private void tsbSeleccionarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                tsbSeleccionarTodos.Checked = !tsbMarcarTodos.Checked;

                if (tsbSeleccionarTodos.Checked == true)
                {
                    tsbSeleccionarTodos.Image = Properties.Resources.unchecked16x16;
                }
                else
                {
                    tsbSeleccionarTodos.Image = Properties.Resources.checked16x16;
                }

                int a = 0;
                this.Cursor = Cursors.WaitCursor;
                if (dgvLista.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvLista.Rows)
                    {
                        if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                        {
                            a++;
                            Array.Resize(ref oTransacciones, a);

                            oTransacciones[a - 1] = new TransaccionTMPEN();
                            oTransacciones[a - 1].idTransacciones = Convert.ToInt32(Fila.Cells["idTransacciones"].Value);
                            oTransacciones[a - 1].Concepto = Fila.Cells["Concepto"].Value.ToString();
                            oTransacciones[a - 1].oTipoDeTransaccionEN.idTipoDeTransaccion = Convert.ToInt32( Fila.Cells["idTipoDeTransaccion"].Value.ToString());
                            oTransacciones[a - 1].oTipoDeTransaccionEN.DesTipoDeTransaccion = Fila.Cells["DesTipoDeTransaccion"].Value.ToString();
                            oTransacciones[a - 1].Fecha = Convert.ToDateTime( Fila.Cells["Fecha"].Value.ToString());
                            oTransacciones[a - 1].Estado = Fila.Cells["Estado"].Value.ToString();
                            oTransacciones[a - 1].Valor = Convert.ToDecimal(Fila.Cells["Valor"].Value.ToString());


                        }
                    }
                }
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccionar registros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                AgregarRegistrosAlDTUsuario();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ActivarFiltros == true)
            {
                if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name == "Seleccionar" && VariosRegistros == false)
                {
                    if (Convert.ToBoolean(dgvLista.CurrentCell.Value) == true)
                    {
                        DesmarcarFilas(dgvLista.CurrentCell.RowIndex);
                    }

                }
            }
        }

        private void dgvLista_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            this.IndiceSeleccionado = e.RowIndex;
        }

        private void dgvLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLista.IsCurrentCellDirty)
            {
                dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            if (ActivarFiltros == true)
            {
                int a = 0;
                this.Cursor = Cursors.WaitCursor;

                dgvLista.CurrentRow.Cells["Seleccionar"].Value = true;

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                    {
                        a++;
                        Array.Resize(ref oTransacciones, a);

                        oTransacciones[a - 1] = new TransaccionTMPEN();
                        oTransacciones[a - 1].idTransacciones = Convert.ToInt32(Fila.Cells["idTransacciones"].Value);
                        oTransacciones[a - 1].Concepto = Fila.Cells["Concepto"].Value.ToString();
                        oTransacciones[a - 1].oTipoDeTransaccionEN.idTipoDeTransaccion = Convert.ToInt32(Fila.Cells["idTipoDeTransaccion"].Value.ToString());
                        oTransacciones[a - 1].oTipoDeTransaccionEN.DesTipoDeTransaccion = Fila.Cells["DesTipoDeTransaccion"].Value.ToString();
                        oTransacciones[a - 1].Fecha = Convert.ToDateTime(Fila.Cells["Fecha"].Value.ToString());
                        oTransacciones[a - 1].Estado = Fila.Cells["Estado"].Value.ToString();
                        oTransacciones[a - 1].Valor = Convert.ToDecimal(Fila.Cells["Valor"].Value.ToString());

                    }
                }

                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void dgvLista_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo Hitest = dgvLista.HitTest(e.X, e.Y);

                if (Hitest.Type == DataGridViewHitTestType.Cell)
                {
                    dgvLista.CurrentCell = dgvLista.Rows[Hitest.RowIndex].Cells[Hitest.ColumnIndex];
                }

            }
        }

        private void tsbMarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                tsbMarcarTodos.Checked = !tsbMarcarTodos.Checked;

                if (tsbMarcarTodos.Checked == true)
                {
                    tsbMarcarTodos.Image = Properties.Resources.unchecked16x16;
                }
                else
                {
                    tsbMarcarTodos.Image = Properties.Resources.checked16x16;
                }

                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    Fila.Cells["Seleccionar"].Value = true;
                    //Si se llamo a la interfaz para seleccionar un solo registro, despues de marcar el primero, llamamos al que desmarca y terminamos
                    if (VariosRegistros == false)
                    {
                        DesmarcarFilas(Fila.Index);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al marcar filas. \n" + ex.Message, "Marcar todas las filas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmTransaccion_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F2) && nuevoToolStripMenuItem.Enabled == true)
            {
                nuevoToolStripMenuItem_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F3) && actualizarToolStripMenuItem.Enabled == true)
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    IndiceSeleccionado = dgvLista.CurrentRow.Index;
                    actualizarToolStripMenuItem_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Actualizar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F4) && eliminarToolStripMenuItem.Enabled == true)
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    IndiceSeleccionado = dgvLista.CurrentRow.Index;
                    eliminarToolStripMenuItem_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Eliminar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F5))
            {
                tsbFiltrar_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F6) && visualizarToolStripMenuItem.Enabled == true && dgvLista.SelectedRows.Count > 0)
            {
                if (dgvLista.SelectedRows.Count > 0)
                {
                    IndiceSeleccionado = dgvLista.CurrentRow.Index;
                    visualizarToolStripMenuItem_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Se debe de seleccionar un registro de la lista", "Consultar Registro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                        

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (EvaluarSiHayRegistrosEnLaTablaTMP())
            {
                return;
            }

            MostrarFormularioParaOperacion("Nuevo");

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Modificar");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Eliminar");
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Consultar");
        }

        private void tsmGrabarDatos_Click(object sender, EventArgs e)
        {
            AsignarLlavePrimaria();
            MostrarFormularioParaOperacion("Grabar Datos");
        }

        private void mcsMenu_Opened(object sender, EventArgs e)
        {
            if (dgvLista.DataSource == null || dgvLista.Rows.Count <= 0 || dgvLista.SelectedRows.Count <= 0)
            {
                eliminarToolStripMenuItem.Enabled = false;
                actualizarToolStripMenuItem.Enabled = false;
                visualizarToolStripMenuItem.Enabled = false;
                imprimirToolStripMenuItem.Enabled = false;                
            }
            else
            {
                CargarPrivilegiosDelUsuario();

            }
        }

        private void txtIdentificador_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtNoTransaccion))
            {
                chkNoTransaccion.CheckState = CheckState.Unchecked;
            }
            else { chkNoTransaccion.CheckState = CheckState.Checked; }

            if (chkNoTransaccion.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {                
                LLenarListado();
            }
        }

        private void txtDescTransacciones_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtConcepto))
            {
                chkConcepto.CheckState = CheckState.Unchecked;
            }
            else { chkConcepto.CheckState = CheckState.Checked; }

            if (chkConcepto.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void cmbDebito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbTipoDeTransaccion))
            {
                chkTipoDeTransaccion.CheckState = CheckState.Unchecked;
            }
            else { chkTipoDeTransaccion.CheckState = CheckState.Checked; }

            if (chkTipoDeTransaccion.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }

        }
        
        private void tsbNuevoRegistro_Click(object sender, EventArgs e)
        {
            if (EvaluarSiHayRegistrosEnLaTablaTMP())
            {
                return;
            }

            MostrarFormularioParaOperacion("Nuevo");
        }

        private void tsbFiltroAutomatico_Click(object sender, EventArgs e)
        {
            tsbFiltroAutomatico.Checked = !tsbFiltroAutomatico.Checked;            

            if (tsbFiltroAutomatico.Checked == true)
            {
                tsbFiltroAutomatico.Image = Properties.Resources.unchecked16x16;
            }
            else {
                tsbFiltroAutomatico.Image = Properties.Resources.checked16x16;
            }
            
        }

        private void cmbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbEstado))
            {
                chkEstado.CheckState = CheckState.Unchecked;
            }
            else { chkEstado.CheckState = CheckState.Checked; }

            if (chkEstado.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void dtpkFecha1_ValueChanged(object sender, EventArgs e)
        {
            chkFecha.CheckState = CheckState.Checked;

            if (tsbAplicarRangoDeFecha.CheckState == CheckState.Checked)
            {
                DateTime Fecha2 = new DateTime(dtpkFecha1.Value.Year, dtpkFecha1.Value.Month, DateTime.DaysInMonth(dtpkFecha1.Value.Year, dtpkFecha1.Value.Month));
                dtpkFecha2.Value = Fecha2;
            }

            if (tsbFiltroAutomatico.Checked == true)
            {

                LLenarListado();
            }

        }

        private void dtpkFecha2_ValueChanged(object sender, EventArgs e)
        {
            chkFecha.CheckState = CheckState.Checked;

            if (tsbAplicarRangoDeFecha.CheckState == CheckState.Checked)
            {
                DateTime fecha1 = new DateTime(dtpkFecha2.Value.Year, dtpkFecha2.Value.Month, 1);
                dtpkFecha1.Value = fecha1;
            }

            if (tsbFiltroAutomatico.Checked == true)
            {
                LLenarListado();
            }
        }

        private void cmbGrupoDeCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbGrupoDeCuentas))
            {
                chkGrupoDeCuentas.CheckState = CheckState.Unchecked;
            }
            else { chkGrupoDeCuentas.CheckState = CheckState.Checked; }

            if (chkGrupoDeCuentas.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void cmbCategoriaDeLasCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbCategoriaDeLasCuentas))
            {
                chkCategoriaDeLasCuentas.CheckState = CheckState.Unchecked;
            }
            else { chkCategoriaDeLasCuentas.CheckState = CheckState.Checked; }

            if (chkCategoriaDeLasCuentas.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void mskidCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
                
        private void tsmListado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofrmVisor == null || ofrmVisor.IsDisposed)
                {
                    ofrmVisor = new frmVisor();
                    ofrmVisor.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                    ofrmVisor.NombreReporte = "Transacciones - Listado";
                    TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                    oRegistroEN.Where = WhereDinamico();
                    oRegistroEN.OrderBy = " Order by t.NumeroDeTransaccion asc  ";
                    oRegistroEN.TituloDelReporte = TituloDinamico();
                    ofrmVisor.Entidad = oRegistroEN;

                    ofrmVisor.MdiParent = this.ParentForm;
                    ofrmVisor.Show();
                }
                else
                    ofrmVisor.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void transacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLista.Rows.Count > 0)
                {
                    
                    if (ofrmVisor_1 == null || ofrmVisor_1.IsDisposed)
                    {
                        ofrmVisor_1 = new frmVisor();
                        ofrmVisor_1.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                        ofrmVisor_1.NombreReporte = "Transacciones - Imprimir comprobante";
                        TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                        oRegistroEN.Where = "";
                        oRegistroEN.OrderBy = " ";
                        oRegistroEN.TituloDelReporte = " ";                            
                        ofrmVisor_1.Entidad = oRegistroEN;

                        ofrmVisor_1.MdiParent = this.ParentForm;
                        ofrmVisor_1.Show();
                    }
                    else
                        ofrmVisor_1.BringToFront();                   

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLista.Rows.Count > 0)
                {
                    if (dgvLista.CurrentRow != null)
                    {
                        int idTransacciones = Convert.ToInt32(dgvLista.CurrentRow.Cells["idTransacciones"].Value);
                        string TipoDeTransaccion = dgvLista.CurrentRow.Cells["DesTipoDeTransaccion"].Value.ToString();

                        string TituloDelReporte = "";
                        switch (TipoDeTransaccion.Trim().ToUpper())
                        {
                            case "EGRESO":
                                TituloDelReporte = "COMPROBANTE DE EGRESO";
                                break;

                            case "INGRESO":
                                TituloDelReporte = "COMPROBANTE DE INGRESO";
                                break;

                            case "DIARIO":
                                TituloDelReporte = "COMPROBANTE DE DIARIO";
                                break;

                        }


                        if (ofrmVisor_1 == null || ofrmVisor_1.IsDisposed)
                        {
                            ofrmVisor_1 = new frmVisor();
                            ofrmVisor_1.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                            ofrmVisor_1.NombreReporte = "Transacciones - Imprimir comprobante";
                            TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                            oRegistroEN.Where = string.Format(" AND t.idTransacciones = {0} ", idTransacciones);
                            oRegistroEN.OrderBy = " ";
                            oRegistroEN.TituloDelReporte = TituloDelReporte;
                            ofrmVisor_1.Entidad = oRegistroEN;

                            ofrmVisor_1.MdiParent = this.ParentForm;
                            ofrmVisor_1.Show();
                        }
                        else
                            ofrmVisor_1.BringToFront();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir Listado de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbAplicarRangoDeFecha_Click(object sender, EventArgs e)
        {
            tsbAplicarRangoDeFecha.Checked = !tsbAplicarRangoDeFecha.Checked;

            if (tsbAplicarRangoDeFecha.Checked == true)
            {
                tsbAplicarRangoDeFecha.Image = Properties.Resources.unchecked16x16;
            }
            else
            {
                tsbAplicarRangoDeFecha.Image = Properties.Resources.checked16x16;
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

        private void frmTransaccion_Enter(object sender, EventArgs e)
        {
            if(tsbFiltroAutomatico.CheckState == CheckState.Checked)
                LLenarListado();
        }

    }
}
