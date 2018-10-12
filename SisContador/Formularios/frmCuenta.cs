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
    public partial class frmCuenta : Form
    {
        public frmCuenta()
        {
            InitializeComponent();
        }

        private string NOMBRE_ENTIDAD_PRIVILEGIO = "Cuentas";
        private string NOMBRE_ENTIDAD = "Administrar y categorizar las cuentas contables";
        private string NOMBRE_LLAVE_PRIMARIA = "NoCuenta";
        private int ValorLlavePrimariaEntidad;
        private int IndiceSeleccionado;
        private frmVisor ofrmVisor = null;
        private frmVisor ofrmVisor_1 = null;
        private frmVisor ofrmVisor_2 = null;
        private frmVisor ofrmVisor_3 = null;
        private frmVisor ofrmVisor_4 = null;

        frmCuentaOperacion ofrmCuentaOperacion = null;

        #region "Funciones del programador"

        public bool ActivarFiltros { set; get; }
        public bool VariosRegistros { set; get; }
        public string TituloVentana { set; get; }
        public CuentaEN[] oCuenta = new CuentaEN[0];

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

        public string AgregarAlWhere { set; get; }

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

                    tsbFiltroAutomatico.Checked = false;
                    tsbFiltroAutomatico.Image = Properties.Resources.unchecked16x16;

                }
            }
        }

        private void ValidarNivelesParaLasCuentas()
        {
            if (Program.oConfiguracionEN.NivelesDeLaCuenta == 0)
            {
                MessageBox.Show("No se ha configurado la niveles que se estableceran para la cuentas", "Validar niveles de las cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
                
        private void LLenarGrupoDeCuentas() {

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
            finally {
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

            if (oCuenta.Length > 0)
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

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(oCuenta.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serializer.Serialize(sw, oCuenta);

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

        private DataTable AgregarColumnaDeInterrogacion(DataTable Datos)
        {
            try
            {
                
                if(VerificarQueSeHayaIngresadoUnaDescripcion(Datos) == true)
                {
                    DataColumn Seleccionar = new DataColumn("Help", Type.GetType("System.Byte[]"));
                    Seleccionar.Caption = " ";//Imagenes.ProcesarImagenToByte((Bitmap)(pbxImagen.Image));
                    Seleccionar.DefaultValue = Funciones.Imagenes.ProcesarImagenToByte((Bitmap)( SisContador.Properties.Resources.if_help_browser_118806));
                    Datos.Columns.Add(Seleccionar);

                    if (Datos.Columns.Contains("Seleccionar")){                      
                        Seleccionar.SetOrdinal(1);                        
                    }else{
                        Seleccionar.SetOrdinal(0);
                    }

                    return Datos;

                }
                else
                {
                    return Datos;
                }


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Agregar columna de interrogación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Datos;
            }
        }

        private bool VerificarQueSeHayaIngresadoUnaDescripcion(DataTable DT)
        {
            bool Verificar = false;
            
            DataTable DTCopy = new DataTable();

            try
            {
                if (DT.Rows.Count > 0)
                {
                    DTCopy = DT.AsEnumerable().Where(r => r.Field<string>("DescCuentaContenido").Trim().Length > 0).CopyToDataTable();

                    if (DTCopy.Rows.Count > 0)
                    {
                        Verificar = true;
                    }
                    else
                    {
                        Verificar = false;
                    }

                }

                return Verificar;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Evaluar si la fila en el DGV no esta Oculta", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }

        }

        private string WhereDinamico() {

            string Where = "";

            if (Controles.IsNullOEmptyElControl(chkIdentificador) == false && Controles.IsNullOEmptyElControl(txtIdentificador) == false) {
                Where += string.Format(" and c.NoCuenta like '%{0}%' ", txtIdentificador.Text.Trim());
            }

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

            if (AgregarAlWhere != null)
            {
                if(string.IsNullOrEmpty(AgregarAlWhere) == false && AgregarAlWhere.Trim().Length > 0)
                {
                    Where += AgregarAlWhere;
                }
            }

            return Where;

        }

        private string TituloDinamico()
        {
            
            string Titulo = "";

            if (Controles.IsNullOEmptyElControl(chkIdentificador) == false && Controles.IsNullOEmptyElControl(txtIdentificador) == false)
            {
                Titulo += string.Format(" c.NoCuenta: '{0}', ", txtIdentificador.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkIdCuenta) == false && mskidCuenta.TextLength > 0)
            {
                Titulo += string.Format(" c.idCuenta: '{0}', ", mskidCuenta.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkDescCuenta) == false && Controles.IsNullOEmptyElControl(txtDescCuenta) == false)
            {
                Titulo += string.Format(" Descripción: '{0}', ", txtDescCuenta.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGruposDeCuentas) == false)
            {
                Titulo += string.Format(" Grupo de cuenta: '{0}', ", cmbGruposDeCuentas.Text);
            }

            if (Controles.IsNullOEmptyElControl(chkCategoriaDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbCategoriaDeCuentas) == false)
            {
                Titulo += string.Format(" Categoria de la cuenta: '{0}', ", cmbGruposDeCuentas.Text);
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

                CuentaEN oRegistrosEN = new CuentaEN();
                CuentaLN oRegistrosLN = new CuentaLN();

                oRegistrosEN.Where = WhereDinamico();
                oRegistrosEN.OrderBy = " Order by c.idCuenta asc";

                if (oRegistrosLN.Listado(oRegistrosEN, Program.oDatosDeConexion)) {

                    dgvLista.Columns.Clear();
                    dgvLista.DataSource = null;
                    
                    DataTable RegistrosDT = new DataTable();

                    if (ActivarFiltros == true)
                    {
                        RegistrosDT = AgregarColumnaSeleccionar(oRegistrosLN.TraerDatos()).Copy();
                    }
                    else {
                        RegistrosDT = oRegistrosLN.TraerDatos().Copy();
                    }

                    //RegistrosDT = DTRegistros;//AgregarColumnaDeInterrogacion(DTRegistros);

                    dgvLista.DataSource = RegistrosDT;//AgregarColumnaDeInterrogacion(RegistrosDT);

                    FormatearDGV();
                    dgvLista.Columns["SaldoCuenta"].DefaultCellStyle.Format = "###,###,##0.00";
                    dgvLista.Columns["MovimientosDelDia"].DefaultCellStyle.Format = "###,###,##0.00";
                    dgvLista.Columns["SaldoAlDia"].DefaultCellStyle.Format = "###,###,##0.00";

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
                
                string OcultarColumnas = "DescCuentaContenido,NoCuenta,CuentaMadre,NivelCuenta,DescGrupoDeCuentas,DescTipoDeCuenta,idTipoDeCuenta,idGrupoDeCuentas,idCategoriaDeCuenta,IdUsuarioDeCreacion,FechaDeCreacion,IdUsuarioDeModificacion,FechaDeModificacion,EsCuentaDeBanco";
                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasDelDGV();

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

        private void MostrarFormularioParaOperacion(string OperacionesARealizar)
        {
            if (ofrmCuentaOperacion == null || ofrmCuentaOperacion.IsDisposed)
            {
                ofrmCuentaOperacion = new frmCuentaOperacion();
                ofrmCuentaOperacion.OperacionARealizar = OperacionesARealizar;
                ofrmCuentaOperacion.NOMBRE_ENTIDAD_PRIVILEGIO = NOMBRE_ENTIDAD_PRIVILEGIO;
                ofrmCuentaOperacion.NombreEntidad = NOMBRE_ENTIDAD;
                ofrmCuentaOperacion.ValorLlavePrimariaEntidad = this.ValorLlavePrimariaEntidad;
                ofrmCuentaOperacion.MdiParent = this.ParentForm;
                ofrmCuentaOperacion.Show();
            }else
            {
                MessageBox.Show("Actualmente la ventana se encuentra abierta y esta realizandose una operación de '"+ofrmCuentaOperacion.OperacionARealizar+"'", "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ofrmCuentaOperacion.BringToFront();
            }

        }

        private void AsignarLlavePrimaria()
        {
            this.ValorLlavePrimariaEntidad = Convert.ToInt32(this.dgvLista.Rows[this.IndiceSeleccionado].Cells[this.NOMBRE_LLAVE_PRIMARIA].Value);
        }

        #endregion

        private void frmCuenta_Shown(object sender, EventArgs e)
        {
            dgvLista.ContextMenuStrip = mcsMenu;
            ConfigurarMascarDeEntrada();
            CargarPrivilegiosDelUsuario();
            LLenarGrupoDeCuentas();
            LLenarCategoriasParaLasCuentas();
            ActivarFiltrosDelaBusqueda();
            tsbFiltroAutomatico_Click(null, null);

            ValidarNivelesParaLasCuentas();

            mskidCuenta.Focus();           

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
                            Array.Resize(ref oCuenta, a);
                            
                            oCuenta[a - 1] = new CuentaEN();
                            oCuenta[a - 1].idCuenta = Fila.Cells["idCuenta"].Value.ToString();
                            oCuenta[a - 1].NoCuenta = Convert.ToInt32(Fila.Cells["NoCuenta"].Value.ToString());
                            oCuenta[a - 1].DescCuenta = Fila.Cells["DescCuenta"].Value.ToString();
                            oCuenta[a - 1].SaldoCuenta = Convert.ToDecimal( Fila.Cells["SaldoCuenta"].Value.ToString());
                            oCuenta[a - 1].oCategoriaDeCuentaEN.idCategoriaDeCuenta = Convert.ToInt32(Fila.Cells["idCategoriaDeCuenta"].Value.ToString());
                            oCuenta[a - 1].oCategoriaDeCuentaEN.DescCategoriaDeCuenta = Fila.Cells["DescCategoriaDeCuenta"].Value.ToString();
                            oCuenta[a - 1].oTipoDeCuentaEN.idTipoDeCuenta = Convert.ToInt32(Fila.Cells["idTipoDeCuenta"].Value.ToString());
                            oCuenta[a - 1].oTipoDeCuentaEN.DescTipoDeCuenta = Fila.Cells["DescTipoDeCuenta"].Value.ToString();
                            oCuenta[a - 1].EsCuentaDeBanco = Convert.ToInt32( Fila.Cells["EsCuentaDeBanco"].Value.ToString());

                        }
                    }
                }
                                                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccionar los registros", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Array.Resize(ref oCuenta, a);

                        oCuenta[a - 1] = new CuentaEN();
                        oCuenta[a - 1].idCuenta = Fila.Cells["idCuenta"].Value.ToString();
                        oCuenta[a - 1].NoCuenta = Convert.ToInt32(Fila.Cells["NoCuenta"].Value.ToString());
                        oCuenta[a - 1].DescCuenta = Fila.Cells["DescCuenta"].Value.ToString();
                        oCuenta[a - 1].SaldoCuenta = Convert.ToDecimal(Fila.Cells["SaldoCuenta"].Value.ToString());
                        oCuenta[a - 1].oCategoriaDeCuentaEN.idCategoriaDeCuenta = Convert.ToInt32(Fila.Cells["idCategoriaDeCuenta"].Value.ToString());
                        oCuenta[a - 1].oCategoriaDeCuentaEN.DescCategoriaDeCuenta = Fila.Cells["DescCategoriaDeCuenta"].Value.ToString();
                        oCuenta[a - 1].oTipoDeCuentaEN.idTipoDeCuenta = Convert.ToInt32(Fila.Cells["idTipoDeCuenta"].Value.ToString());
                        oCuenta[a - 1].oTipoDeCuentaEN.DescTipoDeCuenta = Fila.Cells["DescTipoDeCuenta"].Value.ToString();
                        oCuenta[a - 1].EsCuentaDeBanco = Convert.ToInt32(Fila.Cells["EsCuentaDeBanco"].Value.ToString());

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

        private void frmCuenta_KeyUp(object sender, KeyEventArgs e)
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

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F12))
            {
                if(dgvLista.RowCount > 0)
                {
                    dgvLista.Focus();
                    dgvLista.ClearSelection();
                    dgvLista.FirstDisplayedScrollingRowIndex = dgvLista.Rows[0].Index;                   
                    
                }
            }


        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            if (Controles.IsNullOEmptyElControl(txtIdentificador))
            {
                chkIdentificador.CheckState = CheckState.Unchecked;
            }
            else { chkIdentificador.CheckState = CheckState.Checked; }

            if (chkIdentificador.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {                
                LLenarListado();
            }
        }

        private void txtDescCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtDescCuenta))
            {
                chkDescCuenta.CheckState = CheckState.Unchecked;
            }
            else { chkDescCuenta.CheckState = CheckState.Checked; }

            if (chkDescCuenta.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }
                           

        private void tsbNuevoRegistro_Click(object sender, EventArgs e)
        {
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

        private void cmbGruposDeCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbGruposDeCuentas))
            {
                chkGrupoDeCuentas.CheckState = CheckState.Unchecked;
            }
            else { chkGrupoDeCuentas.CheckState = CheckState.Checked; LLenarCategoriasParaLasCuentas(); }

            if (chkGrupoDeCuentas.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }           

        }

        private void cmbCategoriaDeCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbCategoriaDeCuentas))
            {
                chkCategoriaDeCuentas.CheckState = CheckState.Unchecked;
            }
            else { chkCategoriaDeCuentas.CheckState = CheckState.Checked; }

            if (chkCategoriaDeCuentas.CheckState == CheckState.Checked && tsbFiltroAutomatico.CheckState == CheckState.Checked)
            {
                LLenarListado();
            }
        }

        private void chkGrupoDeCuentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGrupoDeCuentas.CheckState == CheckState.Unchecked)
            {
                LLenarCategoriasParaLasCuentas();
                if (tsbFiltroAutomatico.CheckState == CheckState.Checked)
                {
                    LLenarListado();
                }
            }
        }

        private void chkCategoriaDeCuentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoriaDeCuentas.CheckState == CheckState.Unchecked )
            {

                if (tsbFiltroAutomatico.CheckState == CheckState.Checked) {
                    LLenarListado();
                }
            }
        }

        private void frmCuenta_Load(object sender, EventArgs e)
        {
            
        }

        private void ConfigurarMascarDeEntrada()
        {
            if (Program.oConfiguracionEN.NivelesDeLaCuenta > 0)
            {
                int i = 1;
                string cadena = "";
                while(i <= Program.oConfiguracionEN.NivelesDeLaCuenta)
                {
                    if (i == 1)
                    {
                        cadena = "000";
                    }else
                    {
                        cadena = string.Format("{0}-00", cadena);
                    }
                    i++;
                }

                mskidCuenta.Mask = cadena;
            }
        }

        private void mskidCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (SeDigitoEnLaMascara())
            {
                chkIdCuenta.CheckState = CheckState.Checked;
            }
            else
            {
                chkIdCuenta.CheckState = CheckState.Unchecked;
            }

            if(chkIdCuenta.CheckState == CheckState.Checked && tsbFiltroAutomatico.Checked == true)
            {
                LLenarListado();
            }
           
        }

        private bool SeDigitoEnLaMascara()
        {
            bool Valor = false;

            string Cadena = mskidCuenta.Text;
            string[] ACadena = Cadena.Split('-');

            foreach(string cad in ACadena)
            {
                if(string.IsNullOrEmpty(cad) || cad.Trim().Length == 0)
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
        
        private void tsbCatalogoDeCuentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofrmVisor == null || ofrmVisor.IsDisposed)
                {
                    ofrmVisor = new frmVisor();
                    ofrmVisor.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                    ofrmVisor.NombreReporte = "Cuentas - Catalogo";
                    CuentaEN oRegistroEN = new CuentaEN();
                    oRegistroEN.Where = WhereDinamico();
                    oRegistroEN.OrderBy = " Order by c.idCuenta asc  ";
                    oRegistroEN.TituloDelReporte = TituloDinamico();
                    ofrmVisor.Entidad = oRegistroEN;

                    ofrmVisor.MdiParent = this.ParentForm;
                    ofrmVisor.Show();
                }
                else
                    ofrmVisor.BringToFront();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir catálogo de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listadoDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofrmVisor_1 == null || ofrmVisor_1.IsDisposed)
                {
                    ofrmVisor_1 = new frmVisor();

                    ofrmVisor_1.NombreReporte = "Cuentas - Listado completo";
                    ofrmVisor_1.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                    CuentaEN oRegistroEN = new CuentaEN();
                    oRegistroEN.Where = WhereDinamico();
                    oRegistroEN.OrderBy = " Order by c.idCuenta asc  ";
                    oRegistroEN.TituloDelReporte = TituloDinamico();
                    ofrmVisor_1.Entidad = oRegistroEN;

                    ofrmVisor_1.MdiParent = this.ParentForm;
                    ofrmVisor_1.Show();
                }
                else
                    ofrmVisor_1.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbMostrarSaldos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofrmVisor_2 == null || ofrmVisor_2.IsDisposed)
                {
                    ofrmVisor_2 = new frmVisor();

                    ofrmVisor_2.NombreReporte = "Cuentas - Traer Saldos";
                    ofrmVisor_2.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                    ReportesEN oRegistroEN = new ReportesEN();
                    oRegistroEN.Where = WhereDinamico();
                    oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                    oRegistroEN.TituloDelReporte = TituloDinamico();
                    ofrmVisor_2.Entidad = oRegistroEN;

                    ofrmVisor_2.MdiParent = this.ParentForm;
                    ofrmVisor_2.Show();
                }
                else
                    ofrmVisor_2.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbMostrarSaldoDetallado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofrmVisor_3 == null || ofrmVisor_3.IsDisposed)
                {
                    ofrmVisor_3 = new frmVisor();

                    ofrmVisor_3.NombreReporte = "Cuentas - Traer Saldos Detallado";
                    ofrmVisor_3.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;
                    ReportesEN oRegistroEN = new ReportesEN();
                    oRegistroEN.Where = WhereDinamico();
                    oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                    oRegistroEN.TituloDelReporte = TituloDinamico();
                    ofrmVisor_3.Entidad = oRegistroEN;

                    ofrmVisor_3.MdiParent = this.ParentForm;
                    ofrmVisor_3.Show();
                }
                else
                    ofrmVisor_3.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir listado de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void movimientosDeLaCuentaDuranteElMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLista.RowCount <= 0)
                {
                    throw new ArgumentException("No se encontraron registro dentro de la lista de información");
                }

                if (dgvLista.SelectedRows == null)
                {
                    throw new ArgumentException("Se debe seleccionar un registro de la lista de información");
                }

                if (ofrmVisor_4 == null || ofrmVisor_4.IsDisposed)
                {
                    ofrmVisor_4 = new frmVisor();
                    ofrmVisor_4.AplicarBorder = tsbAplicarBorde.CheckState == CheckState.Checked ? 1 : 0;

                    int NoCuenta = Convert.ToInt32(dgvLista.CurrentRow.Cells["NoCuenta"].Value.ToString());

                    ofrmVisor_4.NombreReporte = "Cuentas - Movimientos del Mes";
                    CuentaEN oRegistroEN = new CuentaEN();
                    oRegistroEN.Where = string.Format(" and td.NoCuenta = {0}", NoCuenta);
                    oRegistroEN.OrderBy = " Order by idCuenta asc  ";
                    oRegistroEN.TituloDelReporte = "MOVIMIENTOS DEL MES POR CUENTA";
                    ofrmVisor_4.Entidad = oRegistroEN;

                    ofrmVisor_4.MdiParent = this.ParentForm;
                    ofrmVisor_4.Show();
                }
                else
                    ofrmVisor_4.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir movimientos del mes de la cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
