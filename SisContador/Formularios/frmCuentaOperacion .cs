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
    public partial class frmCuentaOperacion : Form
    {
        public frmCuentaOperacion()
        {
            InitializeComponent();
        }

        public string OperacionARealizar { set; get; }
        public string NOMBRE_ENTIDAD_PRIVILEGIO { set; get; }
        public string NombreEntidad { set; get; }
        public int ValorLlavePrimariaEntidad { set; get; }

        private bool CerrarVentana = false;

        private int NivelCuenta;
        
        private int idTipoDeCuenta;

        private bool AplicarCambio = false;
        private bool PermitirModificarRegistrosVinculados = false;

        private void frmCuentaOperacion_Shown(object sender, EventArgs e)
        {
            ObtenerValoresDeConfiguracion();
            ConfigurarMascarDeEntrada();
            LLenarGrupoDeCuentas();
            LLenarCategoriasAsociadasAlasCuentas();
            LlamarMetodoSegunOperacion();
            EstablecerTituloDeVentana();
            DeshabilitarControlesSegunOperacionesARealizar();

            ConfiguracionDePantalla();
            CargarPrivilegiosDelUsuario();

        }

        private void ConfiguracionDePantalla()
        {
            try
            {

                int Alto = Screen.PrimaryScreen.Bounds.Height;
                int Ancho = Screen.PrimaryScreen.Bounds.Width;

                if (Ancho == 1024 && Alto == 768)
                {
                    tsbGuardar.DisplayStyle = ToolStripItemDisplayStyle.Image;

                    foreach (ToolStripItem item in toolStrip1.Items)
                    {
                        if (item.Name != null)
                        {
                            string Referencia = item.Name;
                            List<string> RDB = new List<string>(new string[] { "tsbGuardar", "tsbActualizar", "tsbEliminar", "tsbLimpiarCampos", "tsbImprimir", "tsbRecarRegistro", "tsbCerrarVentan" });

                            if (RDB.Contains(Referencia, StringComparer.OrdinalIgnoreCase) == true)
                            {
                                item.DisplayStyle = ToolStripItemDisplayStyle.Image;
                            }

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuraciona de pantalla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region "Funciones"

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

                if(Controles.IsNullOEmptyElControl(cmbGrupoDeCuenta) == false)
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

        private void EvaluarErrorParaMensajeAPantalla(String Error, string TipoOperacion)
        {
            if (string.IsNullOrEmpty(Error) || Error.Trim().Length == 0)
            {
                Error = string.Empty;
                MessageBox.Show(string.Format("Operación '{0}' realizada correctamente", TipoOperacion), string.Format("{0} Registro", TipoOperacion), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cadena = "";
                switch (TipoOperacion.ToUpper())
                {
                    case "GUARDAR":
                        cadena = "Registro Guardado correctamente pero con errores: ";
                        break;
                    case "ACTUALIZAR":
                        cadena = "Registros Actualizado correctamente pero con errores: ";
                        break;
                    case "ELIMINAR":
                        cadena = "Registro Eliminado Correctamente pero con errores: ";
                        break;
                }

                cadena = string.Format("{0} {1} {1} {2}", cadena, Environment.NewLine, Error);

                MessageBox.Show(cadena, string.Format("{0} Registro", TipoOperacion), MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void CargarPrivilegiosDelUsuario()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuariosEN oRegistroEN = new ModuloInterfazUsuariosEN();
                ModuloInterfazUsuariosLN oRegistroLN = new ModuloInterfazUsuariosLN();

                oRegistroEN.oUsuarioEN.idUsuario = Program.oLoginEN.idUsuario;
                oRegistroEN.oPrivilegioEN.oModuloInterfazEN.oInterfazEN.Nombre = NOMBRE_ENTIDAD_PRIVILEGIO;

                if (oRegistroLN.ListadoPrivilegiosDelUsuariosPorIntefaz(oRegistroEN, Program.oDatosDeConexion))
                {
                    if (OperacionARealizar.Trim().ToUpper() == "MODIFICAR")
                    {

                        tsbActualizar.Enabled = oRegistroLN.VerificarSiTengoAcceso("Actualizar");

                        if (tsbActualizar.Enabled == true)
                        {

                            DeshabilitarControlesSegunOperacionesARealizar();
                            PermitirModificarRegistrosVinculados = oRegistroLN.VerificarSiTengoAcceso("Permitir modificar registros vinculados");

                        }
                        else
                        {
                            MessageBox.Show("No tiene privilegio para modificar el registro, la ventana se cerrara", "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }

                    }

                }
                else
                {
                                        
                    throw new ArgumentException(oRegistroLN.Error);

                }

                oRegistroEN = null;
                oRegistroLN = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ObtenerValoresDeConfiguracion()
        {
            chkCerrarVentana.CheckState = (Properties.Settings.Default.CuentaVentanaDespuesDeOperacion == true ? CheckState.Checked : CheckState.Unchecked);
            this.CerrarVentana = (Properties.Settings.Default.CuentaVentanaDespuesDeOperacion == true ? true : false);
        }

        private void LlamarMetodoSegunOperacion()
        {
            switch (this.OperacionARealizar.ToUpper())
            {
                case "NUEVO":
                    Nuevo();
                    break;

                case "MODIFICAR":
                    Modificar();
                    break;

                case "ELIMINAR":
                    Eliminar();
                    break;

                case "CONSULTAR":
                    Consultar();
                    break;

                case "NUEVO A PARTIR DE REGISTRO SELECCIONADO":
                    NuevoAPartirDeRegistroSeleccionado();
                    break;

                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
        }

        private void DeshabilitarControlesSegunOperacionesARealizar()
        {
            switch (this.OperacionARealizar.ToUpper())
            {
                case "NUEVO":
                    tsbGuardar.Enabled = true;
                    tsbLimpiarCampos.Enabled = true;
                    tsbActualizar.Enabled = false;
                    tsbEliminar.Enabled = false;
                    tsbRecarRegistro.Enabled = false;

                    txtIdentificador.ReadOnly = true;
                    txtDescCuenta.Text = string.Empty;                    
                    cmbGrupoDeCuenta.SelectedIndex = -1;
                    txtSaldo.Text = "0.00";
                    txtSaldo.ReadOnly = true;
                    gpCuentaAsociada.Enabled = true;

                    txtIdentificadorAsociado.ReadOnly = true;
                    txtCuentaAsociadaIdCuenta.ReadOnly = true;
                    txtDescricpcionDeLaCuentaAsociada.ReadOnly = true;
                    mskidCuenta.Focus(); 
                   
                    break;

                case "MODIFICAR":
                    tsbGuardar.Enabled = false;
                    tsbLimpiarCampos.Enabled = true;
                    tsbActualizar.Enabled = true;
                    tsbEliminar.Enabled = false;
                    tsbRecarRegistro.Enabled = true;

                    txtIdentificador.ReadOnly = true;
                    txtSaldo.ReadOnly = true;
                    gpCuentaAsociada.Enabled = true;

                    txtIdentificadorAsociado.ReadOnly = true;
                    txtCuentaAsociadaIdCuenta.ReadOnly = true;
                    txtDescricpcionDeLaCuentaAsociada.ReadOnly = true;
                    mskidCuenta.Focus();

                    break;

                case "ELIMINAR":

                    tsbGuardar.Enabled = false;
                    tsbLimpiarCampos.Enabled = false;
                    tsbActualizar.Enabled = false;
                    tsbEliminar.Enabled = true;
                    tsbRecarRegistro.Enabled = false;

                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;
                    txtIdentificador.ReadOnly = true;

                    txtDescCuenta.ReadOnly = true;                    
                    cmbGrupoDeCuenta.Enabled = false;
                    txtSaldo.ReadOnly = true;
                    gpCuentaAsociada.Enabled = false;
                    flowLayoutPanel1.Enabled = false;

                    txtIdentificadorAsociado.ReadOnly = true;
                    txtCuentaAsociadaIdCuenta.ReadOnly = true;
                    txtDescricpcionDeLaCuentaAsociada.ReadOnly = true;

                    mskidCuenta.ReadOnly = true;
                    txtDescCuenta.ReadOnly = true;
                    cmbGrupoDeCuenta.Enabled = false;
                    cmbCategoriaDeLaCuenta.Enabled = false;

                    break;

                case "CONSULTAR":
                    tsbGuardar.Enabled = false;
                    tsbLimpiarCampos.Enabled = false;
                    tsbActualizar.Enabled = false;
                    tsbEliminar.Enabled = false;
                    tsbRecarRegistro.Enabled = false;
                    txtIdentificador.ReadOnly = true;
                    
                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;
                    txtDescCuenta.ReadOnly = true;
                    
                    cmbGrupoDeCuenta.Enabled = false;
                    flowLayoutPanel1.Enabled = false;

                    txtIdentificadorAsociado.ReadOnly = true;
                    txtCuentaAsociadaIdCuenta.ReadOnly = true;
                    txtDescricpcionDeLaCuentaAsociada.ReadOnly = true;

                    mskidCuenta.ReadOnly = true;
                    txtDescCuenta.ReadOnly = true;
                    cmbGrupoDeCuenta.Enabled = false;
                    cmbCategoriaDeLaCuenta.Enabled = false;

                    break;
                    
                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
        }

        private void Nuevo()
        {

        }

        private void Modificar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void Eliminar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void Consultar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void NuevoAPartirDeRegistroSeleccionado()
        {
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void LlenarCamposDesdeBaseDatosSegunID()
        {
            this.Cursor = Cursors.WaitCursor;

            CuentaEN oRegistrosEN = new CuentaEN();
            CuentaLN oRegistrosLN = new CuentaLN();

            oRegistrosEN.NoCuenta = ValorLlavePrimariaEntidad;

            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexion))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {
                    
                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    mskidCuenta.Text = Fila["idCuenta"].ToString();
                    txtIdCuenta.Text = ExtraerCadenaDelaMascar(mskidCuenta);
                    cmbGrupoDeCuenta.SelectedValue = Convert.ToInt32(Fila["idGrupoDeCuentas"].ToString());
                    cmbCategoriaDeLaCuenta.SelectedValue = Convert.ToInt32(Fila["idCategoriaDeCuenta"].ToString());
                    txtDescCuenta.Text = Fila["DescCuenta"].ToString();                    
                    cmbGrupoDeCuenta.SelectedValue = Convert.ToInt32( Fila["idGrupoDeCuentas"].ToString());
                    NivelCuenta = Convert.ToInt32(Fila["NivelCuenta"]);
                    txtIdentificadorAsociado.Text = Fila["CuentaMadre"].ToString();
                    idTipoDeCuenta = Convert.ToInt32(Fila["idTipoDeCuenta"].ToString());
                    txtSaldo.Text = string.Format("{0:###,###.0#}", Fila["SaldoCuenta"].ToString());
                    txtDescCuentaContenido.Text = Fila["DescCuentaContenido"].ToString();

                    //Traer informacion sobre la cuenta a la que esta asociada el registro.....
                    TraerInformacionDeLaCuentaAsociada();

                    if(NivelCuenta > 1)
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
                                            + "\n\r2. El listado no está actualizado.", NombreEntidad);

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
                if(Controles.IsNullOEmptyElControl(txtIdentificadorAsociado) == false && Convert.ToInt32(txtIdentificadorAsociado.Text) > 0)
                {
                    CuentaEN oRegistroEN = new CuentaEN();
                    oRegistroEN.NoCuenta = ValorLlavePrimariaEntidad;
                    oRegistroEN.CuentaMadre = txtIdentificadorAsociado.Text.Trim();

                    CuentaLN oRegistroLN = new CuentaLN();

                    if(oRegistroLN.TraerInformacionDelAsociado(oRegistroEN, Program.oDatosDeConexion))
                    {

                        if (oRegistroLN.TraerDatos().Rows.Count > 0)
                        {
                            gpCuentaAsociada.Visible = true;

                            DataRow Fila = oRegistroLN.TraerDatos().Rows[0];

                            txtDescricpcionDeLaCuentaAsociada.Text = Fila["DescCuenta"].ToString();
                            txtCuentaAsociadaIdCuenta.Text = Fila["idCuenta"].ToString();

                        }else
                        {
                            gpCuentaAsociada.Visible = false;
                        }

                    }else
                    {
                        throw new ArgumentException(oRegistroLN.Error);
                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de cuenta asociada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TraerInformacionDeCuentas()
        {
            try
            {
                if (SeDigitoEnLaMascara(mskBuscarFiltro))
                {
                    CuentaEN oRegistroEN = new CuentaEN();
                    oRegistroEN.Where = string.Format(" and c.idCuenta like '{0}%'", ExtraerCadenaDelaMascar(mskBuscarFiltro));
                    oRegistroEN.OrderBy = " Order by c.idCuenta asc";

                    CuentaLN oRegistroLN = new CuentaLN();

                    if (oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexion))
                    {
                        if (oRegistroLN.TraerDatos().Rows.Count > 0)
                        {
                            dgvLista.DataSource = AgregarColumnaSeleccionar(oRegistroLN.TraerDatos());
                            FormatearDGV();
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

        private DataTable AgregarColumnaSeleccionar(DataTable Datos)
        {
            DataColumn Seleccionar = new DataColumn("Seleccionar", Type.GetType("System.Boolean"));
            Seleccionar.Caption = " ";
            Seleccionar.DefaultValue = false;

            Datos.Columns.Add(Seleccionar);
            Seleccionar.SetOrdinal(0);

            return Datos;
        }

        private void FormatearDGV()
        {
            try
            {
                this.dgvLista.AllowUserToResizeRows = false;
                this.dgvLista.AllowUserToAddRows = false;
                this.dgvLista.AllowUserToDeleteRows = false;
                this.dgvLista.DefaultCellStyle.BackColor = Color.White;
              
                this.dgvLista.MultiSelect = false;
                this.dgvLista.RowHeadersVisible = true;
                
                this.dgvLista.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvLista.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                string OcultarColumnas = "NoCuenta,CuentaMadre,NivelCuenta,SaldoCuenta,DescCategoriaDeCuenta,DescGrupoDeCuentas,DescTipoDeCuenta,idTipoDeCuenta,idGrupoDeCuentas,idCategoriaDeCuenta,IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion";
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

        private void EstablecerTituloDeVentana()
        {
            this.Text = "Administración de " + this.NombreEntidad + " - " + this.OperacionARealizar.ToUpper();
            this.InformacionEntidadOperacion.Text = this.NombreEntidad + " - " + this.OperacionARealizar;
        }

        private void LimpiarCampos()
        {
            //txtId.Text = string.Empty;
            txtDescCuenta.Text = string.Empty;           
            cmbGrupoDeCuenta.SelectedIndex = -1;
           
        }

        private void GuardarValoresDeConfiguracion()
        {
            Properties.Settings.Default.CuentaVentanaDespuesDeOperacion = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
            Properties.Settings.Default.Save();
            
        }

        private void LimpiarEP()
        {
            EP.Clear();
        }

        private bool LosDatosIngresadosSonCorrectos()
        {
            LimpiarEP();

            if (SeDigitoEnLaMascara(mskidCuenta) == false)
            {
                EP.SetError(mskidCuenta, "Este campo no puede quedar vacío");
                mskidCuenta.Focus();
                return false;
            }

            int NivelDelaCuentaENMascara = ObtenerElNivelDelaCuenta(ExtraerCadenaDelaMascar(mskidCuenta));
            if (NivelDelaCuentaENMascara > 1)
            {
                
                if (Controles.IsNullOEmptyElControl(txtIdentificadorAsociado))
                {
                    MessageBox.Show(string.Format("Se debe de seleccionar la cuenta asociada, {0} ya que el Número de cuenta pertenese a una subcuenta", Environment.NewLine));
                    mskidCuenta.Focus();
                    BuscarInformacionDeLaCuentaAsociada(NivelDelaCuentaENMascara);
                    return false;
                }
            }

            if (Controles.IsNullOEmptyElControl(txtDescCuenta))
            {
                EP.SetError(txtDescCuenta, "Este campo no puede quedar vacío");
                txtDescCuenta.Focus();
                return false;
            }
                      

            if (Controles.IsNullOEmptyElControl(cmbGrupoDeCuenta))
            {
                EP.SetError(cmbGrupoDeCuenta, "Se debe seleccionar un valor");
                cmbGrupoDeCuenta.Focus();
                return false;
            }
            
            return true;

        }

        private void BuscarInformacionDeLaCuentaAsociada(int NivelDelaCuentaENMascara)
        {
            try
            {
                int Level = NivelDelaCuentaENMascara - 1;
                int i = 0;
                string cadena = ExtraerCadenaDelaMascar(mskidCuenta);
                string[] Acadena = cadena.Trim().Split('-');
                Level = Acadena.Length;
                string scadena = "";
                string s1;
                
                for(i=0; i< Level - 1; i++)
                {
                    s1 = Acadena[i].Trim();
                    if(string.IsNullOrEmpty(s1) == false || s1.Trim().Length > 0)
                    {
                        if(string.IsNullOrEmpty(scadena) || scadena.Trim().Length == 0)
                        {
                            scadena = s1.Trim();
                        }else
                        {
                            scadena = string.Format("{0}-{1}", scadena.Trim(), s1.Trim());
                        }
                    }
                }
                                
                mskBuscarFiltro.Text = scadena;
                TraerInformacionDeCuentas();
                
                if(dgvLista.Rows.Count > 0 )
                {
                    DataGridViewRow Fila = dgvLista.Rows[0];
                    Fila.Cells["Seleccionar"].Value = true;

                    gpCuentaAsociada.Visible = true;
                    txtIdentificadorAsociado.Text = Fila.Cells["NoCuenta"].Value.ToString();
                    txtCuentaAsociadaIdCuenta.Text = Fila.Cells["idCuenta"].Value.ToString();
                    txtDescricpcionDeLaCuentaAsociada.Text = Fila.Cells["DescCuenta"].Value.ToString();
                    cmbGrupoDeCuenta.SelectedValue = Convert.ToInt32(Fila.Cells["idGrupoDeCuentas"].Value.ToString());
                    cmbCategoriaDeLaCuenta.SelectedValue = Convert.ToInt32(Fila.Cells["idCategoriaDeCuenta"].Value.ToString());

                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Buscar informacion del asociado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool VerificarSiExisteElNivelAsociadoALaCuenta(int NivelDeLaMascara)
        {
            try
            {
                int Level = NivelDeLaMascara - 1;
                int i = 0;
                string cadena = ExtraerCadenaDelaMascar(mskidCuenta);
                string[] Acadena = cadena.Trim().Split('-');
                Level = Acadena.Length;
                string scadena = "";
                string s1;
                for (i = 0; i < Level - 1; i++)
                {
                    s1 = Acadena[i].Trim();
                    if (string.IsNullOrEmpty(s1) == false || s1.Trim().Length > 0)
                    {
                        if (string.IsNullOrEmpty(scadena) || scadena.Trim().Length == 0)
                        {
                            scadena = s1.Trim();
                        }
                        else
                        {
                            scadena = string.Format("{0}-{1}", scadena.Trim(), s1.Trim());
                        }
                    }
                }

                CuentaEN oRegistroEN = new CuentaEN();
                CuentaLN oRegistroLN = new CuentaLN();

                oRegistroEN.Where = string.Format(" and c.idCuenta = '{0}'", scadena.Trim());
                oRegistroEN.OrderBy = " Order By c.idCuenta asc ";

                if(oRegistroLN.Listado(oRegistroEN, Program.oDatosDeConexion))
                {

                    if (oRegistroLN.TraerDatos().Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }
                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Verificar información del Asociado  al cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool SeDigitoEnLaMascara(MaskedTextBox mascara)
        {
            bool Valor = false;

            string Cadena = mascara.Text;
            string[] ACadena = Cadena.Split('-');

            foreach (string cad in ACadena)
            {
                string scad = cad.Trim();

                if (string.IsNullOrEmpty(scad) || scad.Trim().Length == 0)
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

        private CuentaEN InformacionDelRegistro() {

            CuentaEN oRegistroEN = new CuentaEN();
            
            txtIdCuenta.Text = ExtraerCadenaDelaMascar(mskidCuenta);
            oRegistroEN.NoCuenta = Convert.ToInt32((txtIdentificador.Text.Length > 0 ? txtIdentificador.Text : "0"));            
            oRegistroEN.DescCuenta = txtDescCuenta.Text.Trim();
            oRegistroEN.idCuenta = txtIdCuenta.Text.Trim();
            oRegistroEN.SaldoCuenta = Convert.ToDecimal(txtSaldo.Text.Trim());
            oRegistroEN.NivelCuenta = ObtenerElNivelDelaCuenta(txtIdCuenta.Text);//obtener el nivel de la cuenta;
            oRegistroEN.oTipoDeCuentaEN.idTipoDeCuenta = oRegistroEN.NivelCuenta > 1 ? 2 : 1; //obtener el tipo de cuenta..
            oRegistroEN.CuentaMadre =  Controles.IsNullOEmptyElControl(txtIdentificadorAsociado) == false ? txtIdentificadorAsociado.Text.Trim() : "0" ; //obtener si tiene una dependencia...
            oRegistroEN.oCategoriaDeCuentaEN.idCategoriaDeCuenta = Convert.ToInt32(cmbCategoriaDeLaCuenta.SelectedValue);
            oRegistroEN.oCategoriaDeCuentaEN.DescCategoriaDeCuenta = cmbCategoriaDeLaCuenta.Text.Trim();
            oRegistroEN.DescCuentaContenido = txtDescCuentaContenido.Text.Trim();

            //partes generales.            
            oRegistroEN.oLoginEN = Program.oLoginEN;
            oRegistroEN.IdUsuarioDeCreacion = Program.oLoginEN.idUsuario;
            oRegistroEN.IdUsuarioDeModificacion = Program.oLoginEN.idUsuario;
            oRegistroEN.FechaDeCreacion = System.DateTime.Now;
            oRegistroEN.FechaDeModificacion = System.DateTime.Now;

            return oRegistroEN;

        }

        private int ObtenerElNivelDelaCuenta(string CadenaCompleta)
        {
            int NivelDeLaCuenta = 0;

            string Cadena = CadenaCompleta.Trim();
            string[] ACadena = Cadena.Split('-');
            
            if (ACadena.Length > 1)
            {
                foreach(string cad in ACadena){
                    string scad = cad.Trim();                    
                    if(string.IsNullOrEmpty(scad) == false && scad.Trim().Length > 0)
                    {
                        NivelDeLaCuenta++;
                    }

                }
            }else
            {
                NivelDeLaCuenta = 1;
            }

            return NivelDeLaCuenta;

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
                mskBuscarFiltro.Mask = cadena;

            }
        }

        #endregion

        private void tsbCerrarVentan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void chkCerrarVentana_CheckedChanged(object sender, EventArgs e)
        {
            this.CerrarVentana = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
        }

        private void frmCuentaOperacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarValoresDeConfiguracion();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (LosDatosIngresadosSonCorrectos())
                {

                    CuentaEN oRegistroEN = InformacionDelRegistro();
                    CuentaLN oRegistroLN = new CuentaLN();

                    if (oRegistroLN.ValidarRegistroDuplicadoPorElIdentificadorDeLaCuenta(oRegistroEN, Program.oDatosDeConexion, "AGREGAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Guardar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorDescripcionDeLaCuenta(oRegistroEN, Program.oDatosDeConexion, "AGREGAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Guardar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorCategoria(oRegistroEN, Program.oDatosDeConexion, "AGREGAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Guardar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroEN.NivelCuenta > 1)
                    {

                        if (VerificarSiExisteElNivelAsociadoALaCuenta(oRegistroEN.NivelCuenta) == false)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("No se encontro la cuenta asociada,para el Numero de Cuenta que esta digitando", "Guardar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            mskidCuenta.Focus();
                            return;
                        }

                    }

                    if (oRegistroLN.Agregar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.NoCuenta.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.NoCuenta;

                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Guardar");

                        oRegistroEN = null;
                        oRegistroLN = null;

                        this.Cursor = Cursors.Default;

                        if (CerrarVentana == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            OperacionARealizar = "Modificar";
                            ObtenerValoresDeConfiguracion();
                            LlamarMetodoSegunOperacion();
                            EstablecerTituloDeVentana();
                            DeshabilitarControlesSegunOperacionesARealizar();
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
                MessageBox.Show(ex.Message, "Guardar la información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (LosDatosIngresadosSonCorrectos())
                {
                    if (txtIdentificador.Text.Length == 0 || txtIdentificador.Text == "0")
                    {
                        MessageBox.Show("No se puede continuar. Ha ocurrido un error y el registro no ha sido cargado correctamente.", OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                    if (MessageBox.Show("¿Está seguro que desea aplicar los cambios al registro seleccionado?", "Actualizar la Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    CuentaEN oRegistroEN = InformacionDelRegistro();
                    CuentaLN oRegistroLN = new CuentaLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        if (PermitirModificarRegistrosVinculados == true && AplicarCambio == true)
                        {
                            if (MessageBox.Show(string.Format("¿Está seguro que desea guardar los cambios en el registro seleccionado ya que este se encuentra asociado a otras Entidades de manera interna? {0} {1}", System.Environment.NewLine, oRegistroLN.Error), "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                            {
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorElIdentificadorDeLaCuenta(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        if (PermitirModificarRegistrosVinculados == true && AplicarCambio == true)
                        {
                            if (MessageBox.Show(string.Format("¿Está seguro que desea guardar los cambios en el registro seleccionado ya que este se encuentra asociado a otras Entidades de manera interna? {0} {1}", System.Environment.NewLine, oRegistroLN.Error), "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                            {
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Cursor = Cursors.Default;
                            return;
                        }

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorDescripcionDeLaCuenta(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        if (PermitirModificarRegistrosVinculados == true && AplicarCambio == true)
                        {
                            if (MessageBox.Show(string.Format("¿Está seguro que desea guardar los cambios en el registro seleccionado ya que este se encuentra asociado a otras Entidades de manera interna? {0} {1}", System.Environment.NewLine, oRegistroLN.Error), "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                            {
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Cursor = Cursors.Default;
                            return;
                        }

                    }

                    if (oRegistroLN.ValidarRegistroDuplicadoPorCategoria(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        if (PermitirModificarRegistrosVinculados == true && AplicarCambio == true)
                        {
                            if (MessageBox.Show(string.Format("¿Está seguro que desea guardar los cambios en el registro seleccionado ya que este se encuentra asociado a otras Entidades de manera interna? {0} {1}", System.Environment.NewLine, oRegistroLN.Error), "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                            {
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Cursor = Cursors.Default;
                            return;
                        }

                    }

                    if (oRegistroEN.NivelCuenta > 1)
                    {

                        if (VerificarSiExisteElNivelAsociadoALaCuenta(oRegistroEN.NivelCuenta) == false)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("No se encontro la cuenta asociada,para el Numero de Cuenta que esta digitando", "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            mskidCuenta.Focus();
                            return;
                        }

                    }

                    if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexion))
                    {
                                                
                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Actualizar");

                        oRegistroEN = null;
                        oRegistroLN = null;

                        this.Cursor = Cursors.Default;

                        if (CerrarVentana == true)
                        {
                            this.Close();
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
                MessageBox.Show(ex.Message, "Actualizar la información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (LosDatosIngresadosSonCorrectos())
                {
                    if (txtIdentificador.Text.Length == 0 || txtIdentificador.Text == "0")
                    {
                        MessageBox.Show("No se puede continuar. Ha ocurrido un error y el registro no ha sido cargado correctamente.", OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                    if (MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Eliminar la Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    CuentaEN oRegistroEN = InformacionDelRegistro();
                    CuentaLN oRegistroLN = new CuentaLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexion, "ELIMINAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oRegistroLN.EvaluarSiElRegistrosEstaAsociado(oRegistroEN, Program.oDatosDeConexion, "ELIMINAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oRegistroLN.Eliminar(oRegistroEN, Program.oDatosDeConexion))
                    {
                                                
                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Eliminar");

                        oRegistroEN = null;
                        oRegistroLN = null;

                        this.Cursor = Cursors.Default;

                        if (CerrarVentana == true)
                        {
                            this.Close();
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
                MessageBox.Show(ex.Message, "Eliminar la información del registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tsbRecarRegistro_Click(object sender, EventArgs e)
        {
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void cmbGrupoDeCuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LLenarCategoriasAsociadasAlasCuentas();
        }

        private void tsbLimpiarCombo_Click(object sender, EventArgs e)
        {
            cmbGrupoDeCuenta.SelectedIndex = -1;
            LLenarCategoriasAsociadasAlasCuentas();
        }

        private void txtIdCuenta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIdCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (Controles.IsNullOEmptyElControl(txtIdCuenta) == false)
            {
                if (e.KeyCode != Keys.Back)
                {
                    if (txtIdCuenta.Text.Trim().Length == 3)
                    {
                        txtIdCuenta.Text = string.Format("{0}-", txtIdCuenta.Text.Trim());
                        txtIdCuenta.SelectionStart = txtIdCuenta.Text.Trim().Length;
                    }
                    else if (txtIdCuenta.Text.Trim().Length > 4)
                    {
                        int LastIndex = txtIdCuenta.Text.Trim().LastIndexOf('-') + 1;
                        int TamañoDelTexto = txtIdCuenta.Text.Trim().Length;

                        int Sobrante = TamañoDelTexto - LastIndex;

                        if (Sobrante == 2)
                        {
                            txtIdCuenta.Text = string.Format("{0}-", txtIdCuenta.Text.Trim());
                            txtIdCuenta.SelectionStart = txtIdCuenta.Text.Trim().Length;
                        }

                    }
                }
                                
            }
        }

        private void dgvLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLista.IsCurrentCellDirty)
            {
                dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.DataSource != null)
            {
                if (dgvLista.Rows.Count > 0)
                {
                    if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name == "Seleccionar")
                    {
                        if (Convert.ToBoolean(dgvLista.CurrentCell.Value) == true)
                        {
                            DesmarcarFilas(dgvLista.CurrentCell.RowIndex);
                            DataGridViewRow Fila = dgvLista.Rows[dgvLista.CurrentCell.RowIndex];

                            gpCuentaAsociada.Visible = true;
                            txtIdentificadorAsociado.Text = Fila.Cells["NoCuenta"].Value.ToString();
                            txtCuentaAsociadaIdCuenta.Text = Fila.Cells["idCuenta"].Value.ToString();
                            txtDescricpcionDeLaCuentaAsociada.Text = Fila.Cells["DescCuenta"].Value.ToString();
                            cmbGrupoDeCuenta.SelectedValue = Convert.ToInt32(Fila.Cells["idGrupoDeCuentas"].Value.ToString());
                            cmbCategoriaDeLaCuenta.SelectedValue = Convert.ToInt32(Fila.Cells["idCategoriaDeCuenta"].Value.ToString());
                            
                        }
                        else if(Convert.ToBoolean(dgvLista.CurrentCell.Value) == false)
                        {
                            gpCuentaAsociada.Visible = false;
                            txtIdentificadorAsociado.Text = string.Empty;
                            txtCuentaAsociadaIdCuenta.Text = string.Empty;
                            txtDescricpcionDeLaCuentaAsociada.Text = string.Empty;
                            cmbGrupoDeCuenta.SelectedIndex = -1;
                            cmbCategoriaDeLaCuenta.SelectedIndex = -1;
                                                       
                        } 

                    }
                }
            }
        }

        private void mskBuscarFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            TraerInformacionDeCuentas();
        }

        private void mskidCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                int nivel = ObtenerElNivelDelaCuenta(ExtraerCadenaDelaMascar(mskidCuenta));
                if(nivel > 1)
                {                    
                    cmbGrupoDeCuenta.Enabled = false;
                    cmbCategoriaDeLaCuenta.Enabled = false;
                    tsMenuClear.Enabled = false;                    
                    BuscarInformacionDeLaCuentaAsociada(nivel);
                }
                else
                {
                    cmbGrupoDeCuenta.Enabled = true;
                    cmbCategoriaDeLaCuenta.Enabled = true;
                    tsMenuClear.Enabled = true;
                    mskBuscarFiltro.Text = string.Empty;
                    dgvLista.DataSource = null;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Informacion del nivel de la cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmCuentaOperacion_KeyUp(object sender, KeyEventArgs e)
        {

           if(Convert.ToInt32(e.KeyData) == (Convert.ToInt32( (Keys.Control) + Convert.ToInt32(Keys.G))))
            {
                if (OperacionARealizar.ToUpper() == "NUEVO")
                {
                    tsbGuardar_Click(null, null);
                }else if(OperacionARealizar.ToUpper() == "MODIFICAR")
                {
                    tsbActualizar_Click(null, null);
                }
            }

            if (Convert.ToInt32(e.KeyData) == (Convert.ToInt32((Keys.Control) + Convert.ToInt32(Keys.E))))
            {
                tsbEliminar_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == (Convert.ToInt32((Keys.Control) + Convert.ToInt32(Keys.N))))
            {
                tsbLimpiarCampos_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == (Convert.ToInt32((Keys.Control) + Convert.ToInt32(Keys.R))))
            {
                tsbRecarRegistro_Click(null, null);
            }

            if (Convert.ToInt32(e.KeyData) == (Convert.ToInt32((Keys.Control) + Convert.ToInt32(Keys.P))))
            {
                //pendiente
            }

            if (Convert.ToInt32(e.KeyData) == (Convert.ToInt32((Keys.Control) + Convert.ToInt32(Keys.S))))
            {
                this.Close();
            }

        }

        private void tsbAutorizarModificación_Click(object sender, EventArgs e)
        {
            tsbAutorizarModificación.Checked = !tsbAutorizarModificación.Checked;
            AplicarCambio = tsbAutorizarModificación.Checked;

            if (tsbAutorizarModificación.Checked == true)
            {
                tsbAutorizarModificación.Image = Properties.Resources.unchecked16x16;
            }
            else
            {
                tsbAutorizarModificación.Image = Properties.Resources.checked16x16;
            }
        }
    }
}
