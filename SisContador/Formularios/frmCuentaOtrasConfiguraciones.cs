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
    public partial class frmCuentaOtrasConfiguraciones : Form
    {
        public frmCuentaOtrasConfiguraciones()
        {
            InitializeComponent();
        }

        private string NOMBRE_ENTIDAD_PRIVILEGIO = "Cuentas";
        private string NOMBRE_ENTIDAD = "Administrar y categorizar las cuentas contables";
        private string NOMBRE_LLAVE_PRIMARIA = "idOtrasConfiguracionDeLaCuenta";
        private int ValorLlavePrimariaEntidad;
        private int IndiceSeleccionado;
        private BindingSource BD = null; 
        
        #region "Funciones del programador"

        public bool ActivarFiltros { set; get; }
        public bool VariosRegistros { set; get; }
        public string TituloVentana { set; get; }
        public string TituloParaGroupoBox { set; get; }
        public int idTiposDeConfiguracion { set; get; }
        public OtrasConfiguracionDeLaCuentaEN[] oOtrasConfiguracionDeLaCuenta = new OtrasConfiguracionDeLaCuentaEN[0];

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
                tsbMarcarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsbMarcarTodos.Visible = false;
                

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
                    tsbMarcarTodos.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    
                    if (VariosRegistros == false)
                    {
                        tsbMarcarTodos.Visible = false;
                    }
                    else
                    {
                        tsbMarcarTodos.Visible = true;
                    }

                    this.Text = TituloVentana;
                    groupBox1.Text = TituloParaGroupoBox;
                    
                    AgregrarColumnasAlDTRegistros();
                    
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

            if (oOtrasConfiguracionDeLaCuenta.Length > 0)
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

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(oOtrasConfiguracionDeLaCuenta.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serializer.Serialize(sw, oOtrasConfiguracionDeLaCuenta);

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

            string Where = " NoCuenta > 0 ";

            if (Controles.IsNullOEmptyElControl(chkIdentificador) == false && Controles.IsNullOEmptyElControl(txtIdentificador) == false) {
                Where += string.Format(" and c.NoCuenta like '%{0}%' ", txtIdentificador.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkIdCuenta) == false && SeDigitoEnLaMascara())
            {
                Where += string.Format(" and idCuenta like '%{0}%' ", ExtraerCadenaDelaMascar());
            }

            if (Controles.IsNullOEmptyElControl(chkDescCuenta) == false && Controles.IsNullOEmptyElControl(txtDescCuenta) == false)
            {
                Where += string.Format(" and DescCuenta like '%{0}%' ", txtDescCuenta.Text.Trim());
            }

            if (Controles.IsNullOEmptyElControl(chkGrupoDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbGruposDeCuentas) == false)
            {
                Where += string.Format(" and idGrupoDeCuentas = {0} ", cmbGruposDeCuentas.SelectedValue);
            }

            if (Controles.IsNullOEmptyElControl(chkCategoriaDeCuentas) == false && Controles.IsNullOEmptyElControl(cmbCategoriaDeCuentas) == false)
            {
                Where += string.Format(" and idCategoriaDeCuenta = {0} ", cmbCategoriaDeCuentas.SelectedValue);
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
        
        private void LLenarListado() {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                OtrasConfiguracionDeLaCuentaEN oRegistrosEN = new OtrasConfiguracionDeLaCuentaEN();
                OtrasConfiguracionDeLaCuentaLN oRegistrosLN = new OtrasConfiguracionDeLaCuentaLN();

                oRegistrosEN.Where = "";
                oRegistrosEN.idTiposDeConfiguracion = idTiposDeConfiguracion;
                oRegistrosEN.OrderBy = " Order by c.idCuenta asc";

                if (oRegistrosLN.ListadoDeCuentasAsociadasAConfiguracion(oRegistrosEN, Program.oDatosDeConexion)) {

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
                    BD = new BindingSource();
                    BD.DataSource = RegistrosDT;

                    dgvLista.DataSource = BD;//AgregarColumnaDeInterrogacion(RegistrosDT);

                    FormatearDGV();                   

                    this.dgvLista.ClearSelection();

                    tsbNoRegistros.Text = "No. Registros: " + oRegistrosLN.TotalRegistros().ToString();

                    dgvLista.Columns["Seleccionar"].HeaderText = "Marcar";
                    
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
                
                string OcultarColumnas = "idCategoriaDeCuenta, idGrupoDeCuentas,idOtrasConfiguracionDeLaCuenta, idConfiguracion,NoCuenta, idTiposDeConfiguracion,,TipoDeConfiguracion, idUsuarioDeCreacion, FechaDeCreacion,idUsuarioModificacion,FechaDeModificacion";
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
                                oFormato = new FormatoDGV(c1.Name.Trim(), "OtrasConfiguracionDeLaCuenta");
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

        private void AsignarLlavePrimaria()
        {
            this.ValorLlavePrimariaEntidad = Convert.ToInt32(this.dgvLista.Rows[this.IndiceSeleccionado].Cells[this.NOMBRE_LLAVE_PRIMARIA].Value);
        }

        #endregion

        private void frmCuentaOtrasConfiguraciones_Shown(object sender, EventArgs e)
        {
            
            ConfigurarMascarDeEntrada();            
            LLenarGrupoDeCuentas();
            LLenarCategoriasParaLasCuentas();
            ActivarFiltrosDelaBusqueda();            
            ValidarNivelesParaLasCuentas();

            mskidCuenta.Focus();

            this.BackColor = Properties.Settings.Default.MyColorSetting;
            
            LLenarListado();

        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbSeleccionarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                int a = 0;
                this.Cursor = Cursors.WaitCursor;
                if (dgvLista.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in dgvLista.Rows)
                    {
                        if (Convert.ToBoolean(Fila.Cells["Seleccionar"].Value) == true)
                        {
                            
                            a++;
                            Array.Resize(ref oOtrasConfiguracionDeLaCuenta, a);

                            oOtrasConfiguracionDeLaCuenta[a - 1] = new OtrasConfiguracionDeLaCuentaEN();
                            oOtrasConfiguracionDeLaCuenta[a - 1].idOtrasConfiguracionDeLaCuenta = Convert.ToInt32( Fila.Cells["idOtrasConfiguracionDeLaCuenta"].Value.ToString());
                            oOtrasConfiguracionDeLaCuenta[a - 1].NoCuenta = Convert.ToInt32(Fila.Cells["NoCuenta"].Value.ToString());
                            oOtrasConfiguracionDeLaCuenta[a - 1].idCuenta = Fila.Cells["idCuenta"].Value.ToString();
                            oOtrasConfiguracionDeLaCuenta[a - 1].idConfiguracion = Convert.ToInt32( Fila.Cells["idConfiguracion"].Value.ToString());
                            oOtrasConfiguracionDeLaCuenta[a - 1].idTiposDeConfiguracion = Convert.ToInt32(Fila.Cells["idTiposDeConfiguracion"].Value.ToString());
                            oOtrasConfiguracionDeLaCuenta[a - 1].NivelCuenta = Convert.ToInt32(Fila.Cells["NivelCuenta"].Value.ToString());


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
                        Array.Resize(ref oOtrasConfiguracionDeLaCuenta, a);

                        oOtrasConfiguracionDeLaCuenta[a - 1] = new OtrasConfiguracionDeLaCuentaEN();
                        oOtrasConfiguracionDeLaCuenta[a - 1].idOtrasConfiguracionDeLaCuenta = Convert.ToInt32(Fila.Cells["idOtrasConfiguracionDeLaCuenta"].Value.ToString());
                        oOtrasConfiguracionDeLaCuenta[a - 1].NoCuenta = Convert.ToInt32(Fila.Cells["NoCuenta"].Value.ToString());
                        oOtrasConfiguracionDeLaCuenta[a - 1].idCuenta = Fila.Cells["idCuenta"].Value.ToString();
                        oOtrasConfiguracionDeLaCuenta[a - 1].idConfiguracion = Convert.ToInt32(Fila.Cells["idConfiguracion"].Value.ToString());
                        oOtrasConfiguracionDeLaCuenta[a - 1].idTiposDeConfiguracion = Convert.ToInt32(Fila.Cells["idTiposDeConfiguracion"].Value.ToString());
                        oOtrasConfiguracionDeLaCuenta[a - 1].NivelCuenta = Convert.ToInt32(Fila.Cells["NivelCuenta"].Value.ToString());

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
                    
                    //Si se llamo a la interfaz para seleccionar un solo registro, despues de marcar el primero, llamamos al que desmarca y terminamos
                    if (VariosRegistros == false)
                    {
                        Fila.Cells["Seleccionar"].Value = true;
                        DesmarcarFilas(Fila.Index);
                        return;
                    }else
                    {
                        Fila.Cells["Seleccionar"].Value = tsbMarcarTodos.Checked;
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

        private void frmCuentaOtrasConfiguraciones_KeyUp(object sender, KeyEventArgs e)
        {
         
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F5))
            {
                tsbFiltrar_Click(null, null);
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
        
        private void txtIdentificador_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtIdentificador))
            {
                chkIdentificador.CheckState = CheckState.Unchecked;
            }
            else { chkIdentificador.CheckState = CheckState.Checked; }
            
        }

        private void txtDescCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtDescCuenta))
            {
                chkDescCuenta.CheckState = CheckState.Unchecked;
            }
            else { chkDescCuenta.CheckState = CheckState.Checked; }

            AplicarBindingSource();

        }
       
        private void cmbGruposDeCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbGruposDeCuentas))
            {
                chkGrupoDeCuentas.CheckState = CheckState.Unchecked;
            }
            else { chkGrupoDeCuentas.CheckState = CheckState.Checked; LLenarCategoriasParaLasCuentas(); }

            AplicarBindingSource();

        }

        private void cmbCategoriaDeCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(cmbCategoriaDeCuentas))
            {
                chkCategoriaDeCuentas.CheckState = CheckState.Unchecked;
            }
            else { chkCategoriaDeCuentas.CheckState = CheckState.Checked; }

            AplicarBindingSource();

        }

        private void chkGrupoDeCuentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGrupoDeCuentas.CheckState == CheckState.Unchecked)
            {
                LLenarCategoriasParaLasCuentas();
                
            }
        }

        private void chkCategoriaDeCuentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoriaDeCuentas.CheckState == CheckState.Unchecked )
            {

               
            }
        }

        private void frmCuentaOtrasConfiguraciones_Load(object sender, EventArgs e)
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

            AplicarBindingSource();

        }

        private void AplicarBindingSource()
        {
            string Where = WhereDinamico();
            BD.Filter = Where;
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
                
    }
}
