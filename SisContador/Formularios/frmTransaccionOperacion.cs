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
    public partial class frmTransaccionOperacion : Form
    {
        public frmTransaccionOperacion()
        {
            InitializeComponent();
        }

        public string OperacionARealizar { set; get; }
        public string NOMBRE_ENTIDAD_PRIVILEGIO { set; get; }
        public string NombreEntidad { set; get; }
        public int ValorLlavePrimariaEntidad { set; get; }

        public int IdTipoDeTransaccion_ { set; get; }

        private bool CerrarVentana = false;

        private MaskedTextBox Mask;
        private ListView Listas;
        private ComboBox Combo;
        private frmVisor ofrmVisor_1 = null;

        private Decimal TotalHaber = 0;
        private Decimal TotalDebe = 0;

        #region Funciones               

        private bool EvaluarSiHayFilasDisponiblesEnLaGrilla()
        {

            bool Valor = false;
            
            int Numero = dgvLista.Rows.Cast<DataGridViewRow>().Select(row => row.Cells["Ocupada"].Value).Count(s => Convert.ToInt32(s) == 0);

            if(Numero == 0)
            {
                Valor = false;
            }else if(Numero > 0)
            {
                Valor = true;
            }
            
            return Valor;
                       
        }

        private int IndicieDelRegistroBasioEnLaGrilla()
        {
            int valor = -1;
            try
            {
                if (dgvLista.Rows.Count > 0)
                {
                    List<DataGridViewRow> rows = (from item in dgvLista.Rows.Cast<DataGridViewRow>()
                                                  let Ocupada = Convert.ToInt32(item.Cells["Ocupada"].Value)
                                                  //let Ocupada = Convert.ToString(item.Cells["Ocupada"].Value ?? string.Empty).ToUpper()
                                                  where Ocupada == 0
                                                  select item).ToList<DataGridViewRow>();                    

                    if (rows.Count > 0)
                    {
                        valor = rows[0].Index;
                    }
                    else
                    {
                        valor = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar indice Basio. \n" + ex.Message, "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valor = -1;
            }

            return valor;
        }

        frmCuenta oObjFrm = null;
        private void BuscarCuentasAsociadas()
        {
            
            try
            {
                                               

                if (oObjFrm == null || oObjFrm.IsDisposed)
                {
                    oObjFrm = new frmCuenta();
                }else
                {
                    oObjFrm.BringToFront();
                }

                CuentaEN[] oRegistroEN = new CuentaEN[0];

                oObjFrm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                oObjFrm.TituloVentana = string.Format("Seleccione las cuentas a asociar con la transacción {0} ", txtNumeroDeTransaccion.Text);
                oObjFrm.VariosRegistros = true;
                oObjFrm.ActivarFiltros = true;
                oObjFrm.AgregarAlWhere = " and EvaluarSiEsCuentaPrincipal(c.NoCuenta) = 0 ";
                oObjFrm.ShowDialog();

                oRegistroEN = oObjFrm.oCuenta;

                if (oRegistroEN.Length > 0)
                {
                    foreach (CuentaEN Fila in oRegistroEN) {

                        if (EvaluarSiHayFilasDisponiblesEnLaGrilla())
                        {

                            int Index = IndicieDelRegistroBasioEnLaGrilla();

                            if (Index == -1)
                            {
                                dgvLista.Rows.Add(0, 0,0, Fila.NoCuenta, Fila.idCuenta, Fila.DescCuenta, 0, 0,"","",Fila.EsCuentaDeBanco, 1, 0);
                            }else
                            {
                                DataGridViewRow Row = dgvLista.Rows[Index];
                                Row.Cells["idTransaccionDetalle"].Value = 0;
                                Row.Cells["NoCuenta"].Value = Fila.NoCuenta;
                                Row.Cells["idCuenta"].Value = Fila.idCuenta;
                                Row.Cells["DescCuenta"].Value = Fila.DescCuenta;
                                Row.Cells["Debe"].Value = 0;
                                Row.Cells["Haber"].Value = 0;
                                Row.Cells["RefBanco"].Value = "";
                                Row.Cells["ConceptoDeBanco"].Value = "";
                                Row.Cells["EsCuentaDeBanco"].Value = Fila.EsCuentaDeBanco;
                                Row.Cells["Ocupada"].Value = 1;
                                Row.Cells["Actualizar"].Value = true;
                                Row.Cells["Eliminar"].Value = false;
                            }

                        } else
                        {
                            dgvLista.Rows.Add(0, 0,0, Fila.NoCuenta, Fila.idCuenta, Fila.DescCuenta, 0, 0,"", "", Fila.EsCuentaDeBanco, 1, 0);
                        }
                        
                    }

                    ActivarColumnas();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Buscar información de las cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ActivarColumnas()
        {
            if (EvaluarSiHayCuentasDeBanco())
            {

                int Opcion = 0;

                if (cmbTipoDeTransacción.SelectedIndex > -1)
                {
                    Opcion = Convert.ToInt32(cmbTipoDeTransacción.SelectedValue);
                } else Opcion = 0;

                switch (Opcion)
                {
                    case 1:
                        dgvLista.Columns["ConceptoDeBanco"].HeaderText = "Concepto de Emisión de CK o Nota de Debito";
                        break;

                    case 2:
                        dgvLista.Columns["ConceptoDeBanco"].HeaderText = "Concepto de Emisión de CK o Nota de Crédito";
                        break;

                    case 3:
                        dgvLista.Columns["ConceptoDeBanco"].HeaderText = "Concepto de Crédito o Debito";
                        break;

                    default:
                        dgvLista.Columns["ConceptoDeBanco"].HeaderText = "Concepto de Emisión de CK";
                        break;

                }

                dgvLista.Columns["ConceptoDeBanco"].Visible = true;
                dgvLista.Columns["RefBanco"].Visible = true;

            }else
            {
                dgvLista.Columns["ConceptoDeBanco"].Visible = false;
                dgvLista.Columns["RefBanco"].Visible = false;
            }
        }

        private bool EvaluarSiHayCuentasDeBanco()
        {
            bool Valor = false;

            List<DataGridViewRow> rows = (from item in dgvLista.Rows.Cast<DataGridViewRow>()
                                          let Ocupada = Convert.ToInt32(item.Cells["Ocupada"].Value)
                                          let EsCuentaDeBanco = Convert.ToInt32(item.Cells["EsCuentaDeBanco"].Value)
                                          //let Ocupada = Convert.ToString(item.Cells["Ocupada"].Value ?? string.Empty).ToUpper() 
                                          //let EsCuentaDeBanco = Convert.ToString(item.Cells["Ocupada"].Value ?? string.Empty).ToUpper()
                                          where Ocupada == 1 && EsCuentaDeBanco == 1
                                          select item).ToList<DataGridViewRow>();

            if (rows.Count > 0) Valor = true; else Valor = false;

            return Valor;

        }

        private void LLenarComboListadoTipoDetransacciones()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                TipoDeTransaccionEN oRegistroEN = new TipoDeTransaccionEN();
                TipoDeTransaccionLN oRegistroLN = new TipoDeTransaccionLN();

                oRegistroEN.Where = "";

                if (IdTipoDeTransaccion_ > 0)
                {
                    oRegistroEN.Where = string.Format(" and idTipoDeTransaccion = {0} ", IdTipoDeTransaccion_);
                }

                oRegistroEN.OrderBy = "";

                if (oRegistroLN.ListadoParaCombos(oRegistroEN, Program.oDatosDeConexion))
                {

                    cmbTipoDeTransacción.DataSource = oRegistroLN.TraerDatos();
                    cmbTipoDeTransacción.DisplayMember = "DesTipoDeTransaccion";
                    cmbTipoDeTransacción.ValueMember = "idTipoDeTransaccion";
                    cmbTipoDeTransacción.SelectedIndex = 0;
                    cmbTipoDeTransacción.Enabled = false;                   

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Listado de Tipo de transacciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    case "GRABAR DATOS":
                        cadena = "Registro Grabado Correctamente pero con errores: ";
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
                    
                    tsbActualizar.Enabled = oRegistroLN.VerificarSiTengoAcceso("Actualizar");

                    if (tsbActualizar.Enabled == true) {

                        DeshabilitarControlesSegunOperacionesARealizar();

                    }
                    else
                    {
                        MessageBox.Show("No tiene privilegio para modificar el registro, la ventana se cerrara", "Privilegios de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
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
            chkCerrarVentana.CheckState = (Properties.Settings.Default.TransaccionVentanaDespuesDeOperacion == true ? CheckState.Checked : CheckState.Unchecked);
            this.CerrarVentana = (Properties.Settings.Default.TransaccionVentanaDespuesDeOperacion == true ? true : false);
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

                case "GRABAR DATOS":
                    GrabarDatos();
                    break;

                case "ELIMINAR":
                    Eliminar();
                    break;

                case "CONSULTAR":
                    LlenarCamposDesdeBaseDatosSegunIDParaVisualizar();
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
                    tsbGrabarDatos.Visible = false;

                    txtIdentificador.ReadOnly = true;
                    txtConcepto.Text = string.Empty;
                    txtNumeroDeTransaccion.Text = string.Empty;
                    txtNumeroDeTransaccion.ReadOnly = true;
                    dtpkFecha.Value = System.DateTime.Now;
                    cmbEstado.SelectedIndex = 0;         
                   
                    break;

                case "MODIFICAR":
                    tsbGuardar.Enabled = false;
                    tsbLimpiarCampos.Enabled = true;
                    tsbActualizar.Enabled = true;
                    tsbEliminar.Enabled = false;
                    tsbRecarRegistro.Enabled = true;

                    txtIdentificador.ReadOnly = true;
                    txtNumeroDeTransaccion.ReadOnly = true;
                    tsbGrabarDatos.Visible = false;
                    cmbEstado.Enabled = false;

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

                    txtNumeroDeTransaccion.ReadOnly = true;
                    txtConcepto.ReadOnly = true;
                    dtpkFecha.Enabled = false;
                    cmbEstado.Enabled = false;
                    cmbTipoDeTransacción.Enabled = false;
                    txtNumeroDeTransaccion.ReadOnly = true;
                    tsbCuentas.Enabled = false;
                    tsbGrabarDatos.Visible = false;
                    txtValor.ReadOnly = true;

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

                    txtNumeroDeTransaccion.ReadOnly = true;
                    txtConcepto.ReadOnly = true;
                    dtpkFecha.Enabled = false;
                    cmbEstado.Enabled = false;
                    cmbTipoDeTransacción.Enabled = false;
                    tsbCuentas.Enabled = false;
                    tsbGrabarDatos.Visible = false;
                    txtValor.ReadOnly = true;

                    break;

                case "GRABAR DATOS":

                    tsbGuardar.Visible = false;
                    tsbLimpiarCampos.Visible = false;
                    tsbActualizar.Visible = false;
                    tsbEliminar.Visible = false;
                    tsbRecarRegistro.Enabled = true;
                    tsbGrabarDatos.Visible = true;

                    txtIdentificador.ReadOnly = true;

                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;

                    txtNumeroDeTransaccion.ReadOnly = true;
                    txtConcepto.ReadOnly = true;
                    dtpkFecha.Enabled = false;
                    cmbEstado.Enabled = false;
                    cmbTipoDeTransacción.Enabled = false;
                    txtValor.ReadOnly = true;
                    tsbCuentas.Enabled = false;

                    break;
                    
                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
        }

        private void Nuevo()
        {
            CrearColumnasDDGV();
            PrecargarDGV();
        }

        private void Modificar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void GrabarDatos()
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

            TransaccionTMPEN oRegistrosEN = new TransaccionTMPEN();
            TransaccionTMPLN oRegistrosLN = new TransaccionTMPLN();

            oRegistrosEN.idTransacciones = ValorLlavePrimariaEntidad;

            oRegistrosLN.CargarRegistro(oRegistrosEN, Program.oDatosDeConexion);

            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexion))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {

                    ValorLlavePrimariaEntidad = oRegistrosEN.idTransacciones;
                                        
                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
                    
                    txtConcepto.Text = Fila["Concepto"].ToString();
                    txtNumeroDeTransaccion.Text = Fila["NumeroDeTransaccion"].ToString();
                    dtpkFecha.Value = Convert.ToDateTime(Fila["Fecha"].ToString());
                    cmbTipoDeTransacción.SelectedValue = Convert.ToInt32(Fila["idTipoDeTransaccion"].ToString());
                    cmbEstado.Text = Fila["Estado"].ToString();
                    txtValor.Text = Fila["Valor"].ToString();

                    CrearColumnasyPoblarlas();

                    Calcular_Bebe();
                    Calcular_Haber();

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

        private void LlenarCamposDesdeBaseDatosSegunIDParaVisualizar()
        {
            this.Cursor = Cursors.WaitCursor;

            TransaccionTMPEN oRegistrosEN = new TransaccionTMPEN();
            TransaccionTMPLN oRegistrosLN = new TransaccionTMPLN();

            oRegistrosEN.idTransacciones = ValorLlavePrimariaEntidad;

            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexion))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {

                    ValorLlavePrimariaEntidad = oRegistrosEN.idTransacciones;

                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();

                    txtConcepto.Text = Fila["Concepto"].ToString();
                    txtNumeroDeTransaccion.Text = Fila["NumeroDeTransaccion"].ToString();
                    dtpkFecha.Value = Convert.ToDateTime(Fila["Fecha"].ToString());
                    cmbTipoDeTransacción.SelectedValue = Convert.ToInt32(Fila["idTipoDeTransaccion"].ToString());
                    cmbEstado.Text = Fila["Estado"].ToString();
                    txtValor.Text = Fila["Valor"].ToString();

                    CrearColumnasyPoblarlas();

                    Calcular_Bebe();
                    Calcular_Haber();

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

        private void EstablecerTituloDeVentana()
        {
            this.Text = "" + this.NombreEntidad + " - " + this.OperacionARealizar.ToUpper();
            this.InformacionEntidadOperacion.Text = this.NombreEntidad + " - " + this.OperacionARealizar;
        }

        private void LimpiarCampos()
        {
            //txtId.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            txtNumeroDeTransaccion.Text = String.Empty;
            cmbEstado.SelectedIndex = -1;
            cmbTipoDeTransacción.SelectedIndex = -1;
            dtpkFecha.Value = System.DateTime.Now;
           
        }

        private void GuardarValoresDeConfiguracion()
        {
            Properties.Settings.Default.TransaccionVentanaDespuesDeOperacion = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
            Properties.Settings.Default.Save();
        }

        private void LimpiarEP()
        {
            EP.Clear();
        }

        private bool LosDatosIngresadosSonCorrectos()
        {
            LimpiarEP();
            

            if (Controles.IsNullOEmptyElControl(cmbTipoDeTransacción))
            {
                EP.SetError(cmbTipoDeTransacción, "Se debe seleccionar un valor");
                cmbTipoDeTransacción.Focus();
                return false;
            }

            if (Controles.IsNullOEmptyElControl(txtValor))
            {
                EP.SetError(txtValor, "Este campo no puede quedar vacío");
                txtValor.Focus();
                return false;
            }

            if(Convert.ToDecimal(txtValor.Text) <= 0)
            {
                EP.SetError(txtValor, "no se pueden agregar valores en Ceros o Negativos");
                txtValor.Focus();
                return false;
            }

            if (Controles.IsNullOEmptyElControl(cmbEstado))
            {
                EP.SetError(cmbEstado, "Se debe seleccionar un valor");
                cmbEstado.Focus();
                return false;
            }


            return true;

        }

        private TransaccionTMPEN InformacionDelRegistro() {

            TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();

            oRegistroEN.idTransacciones = Convert.ToInt32((txtIdentificador.Text.Length > 0 ? txtIdentificador.Text : "0"));
            oRegistroEN.NumeroDeTransaccion = txtNumeroDeTransaccion.Text.Trim();
            oRegistroEN.Estado = cmbEstado.Text.Trim();
            oRegistroEN.oTipoDeTransaccionEN.idTipoDeTransaccion = Convert.ToInt32(cmbTipoDeTransacción.SelectedValue);
            oRegistroEN.oTipoDeTransaccionEN.DesTipoDeTransaccion = cmbTipoDeTransacción.Text;
            oRegistroEN.Fecha = dtpkFecha.Value;
            oRegistroEN.Valor = Convert.ToDecimal(txtValor.Text);
            oRegistroEN.Concepto = txtConcepto.Text.Trim();

            //partes generales.            
            oRegistroEN.oLoginEN = Program.oLoginEN;
            oRegistroEN.IdUsuarioDeCreacion = Program.oLoginEN.idUsuario;
            oRegistroEN.IdUsuarioDeModificacion = Program.oLoginEN.idUsuario;
            oRegistroEN.FechaDeCreacion = System.DateTime.Now;
            oRegistroEN.FechaDeModificacion = System.DateTime.Now;

            return oRegistroEN;

        }

        #endregion

        #region Funciones del Datagrid

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cuando se completa la nueva selección de la lista, cargamos el id en la columna idtiposdecontratacion
            if (Combo != null)
            {

                if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name.ToUpper() == "RefBanco".ToUpper())
                {
                    MessageBox.Show(Combo.Text);
                    dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["RefBanco"].Value = Combo.Text;
                    dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Actualizar"].Value = true;
                }
            }
        }

        private void cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Combo != null)
            {

                if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name.ToUpper() == "RefBanco".ToUpper())
                {                    
                    dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["RefBanco"].Value = Combo.Text;
                    dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Actualizar"].Value = true;
                }
            }
        }

        private void cmb_Leave(object sender, EventArgs e)
        {
            //Cuando el combobox pierde el foco, lo ocultamos y liberamos.
            if (Combo != null)
            {
                Combo.Visible = false;
                Combo = null;
                dgvLista.Focus();
            }
        }

        private void cmb_DropDownClosed(object sender, EventArgs e)
        {
            //Cuando el combobox se cierra, es decir, se oculta el combo, lo ocultamos y este al ocultarlo desencadena el evento leave, que libera el objeto  
            if (Combo != null)
            {
                Combo.Visible = true;
            }
        }

        private void cmb_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmb_KeyUp(object sender, KeyEventArgs e)
        {

            if (string.IsNullOrEmpty(Combo.Text) == false || Combo.Text.Trim().Length > 0)
            {
                dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["RefBanco"].Value = Combo.Text;
                dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Actualizar"].Value = true;

            }
            else
            {
                dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["Actualizar"].Value = false;
            }
             

        }

        private void CrearColumnasDDGV()
        {
            try
            {
                //string columnas = @"idTransaccionDetalle,idTansaccionDetalle_Banco,NoCuenta,idCuenta,DescCuenta,Debe,Haber,RefBanco,ConceptoDeBanco,EsCuentaDeBanco,Ocupada";
                string columnas = @"idTransaccionDetalle,idTansaccionDetalle_Banco,NoCuenta,DescCuenta,Debe,Haber,RefBanco,ConceptoDeBanco,EsCuentaDeBanco,Ocupada";
                dgvLista.Columns.Clear();
                Controles.CraerColumnasDGV(dgvLista, columnas, ConfigurarMascaraDeEntradaString());
                dgvLista.Columns[1].Name = "idCuenta";                

                FormatearDGV();

                                          

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la lista. \n" + ex.Message, "Crear columnas en el datagridview", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnlazarComboCargoParaListaNivelAcademico(ref ComboBox Combito)
        {
            int TipoDeTransaccion = Convert.ToInt32(cmbTipoDeTransacción.SelectedValue);

            switch (TipoDeTransaccion)
            {
                case 1:
                    Combito.Items.Add("Nota de Débito");
                    Combito.SelectedIndex = 0;
                    break;

                case 2:
                    Combito.Items.Add("Depósito");
                    Combito.SelectedIndex = 0;
                    break;

                case 3:
                    Combito.Items.Add("Nota de Débito");
                    Combito.Items.Add("Depósito");
                    Combito.Items.Add("Nota de Crédito");                                        
                    break;

            }

        }

        private void CrearColumnasyPoblarlas()
        {
            try
            {

                CrearColumnasDDGV();
                
                TransaccionDetalleTMPEN oRegistroEN = new TransaccionDetalleTMPEN();
                TransaccionDetalleTMPLN oRegistroLN = new TransaccionDetalleTMPLN();

                oRegistroEN.oTransaccionesEN.idTransacciones = ValorLlavePrimariaEntidad;
                oRegistroEN.OrderBy = " Order by idCuenta asc ";

                if(oRegistroLN.ListadoPorIdentificadorDeLaTransaccion(oRegistroEN, Program.oDatosDeConexion))
                {

                    DataTable Datos = oRegistroLN.TraerDatos();

                    int idTransaccionDetalle = 0;
                    int idTansaccionDetalle_Banco = 0;

                    Boolean valor = false;
                    if (OperacionARealizar == "Eliminar") { valor = true; } else { valor = false; }

                    if (!(Datos == null) && Datos.Rows.Count > 0)
                    {
                        foreach (DataRow row in Datos.Rows)
                        {
                            if (OperacionARealizar.ToUpper() == "NUEVO A PARTIR DE REGISTRO SELECCIONADO")
                            {
                                idTransaccionDetalle = 0;
                                idTansaccionDetalle_Banco = 0;

                            }
                            else
                            {
                                int.TryParse(row["idTransaccionDetalle"].ToString(), out idTransaccionDetalle);
                                int.TryParse(row["idTansaccionDetalle_Banco"].ToString(), out idTansaccionDetalle_Banco);
                            }

                            dgvLista.Rows.Add(
                                valor,
                                row["idCuenta"].ToString(),
                                idTransaccionDetalle,
                                idTansaccionDetalle_Banco,
                                Convert.ToInt32(row["NoCuenta"].ToString()),                                
                                row["DescCuenta"].ToString(),
                                string.Format("{0:###,##0.00}", row["Debe"].ToString()),
                                string.Format("{0:###,##0.00}", row["Haber"].ToString()),
                                row["RefBanco"].ToString(),
                                row["ConceptoDeBanco"].ToString(),
                                row["EsCuentaDeBanco"].ToString(),
                                1,
                                valor
                                );                          

                        }
                    }

                    PrecargarDGV();
                    ActivarColumnas();

                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al llenar la lista. \n" + ex.Message, "Craer Columnas y poblarlas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                               
                this.dgvLista.MultiSelect = false;
                this.dgvLista.RowHeadersVisible = true;
               
                this.dgvLista.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvLista.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvLista.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                string OcultarColumnas = "idTransaccionDetalle,idTansaccionDetalle_Banco,NoCuenta,EsCuentaDeBanco,Ocupada, Actualizar";
                OcultarColumnasEnElDGV(OcultarColumnas);

                FormatearColumnasDelDGV();

                dgvLista.Columns["idCuenta"].ReadOnly = false;
                dgvLista.Columns["ConceptoDeBanco"].ReadOnly = false;
                dgvLista.Columns["ConceptoDeBanco"].Visible = false;
                dgvLista.Columns["RefBanco"].Visible = false;

                dgvLista.Columns["Debe"].DefaultCellStyle.Format = "N2";
                dgvLista.Columns["Haber"].DefaultCellStyle.Format = "N2";

                this.dgvLista.RowHeadersWidth = 25;

                this.dgvLista.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvLista.SelectionMode = DataGridViewSelectionMode.CellSelect;
                this.dgvLista.StandardTab = true;
                this.dgvLista.ReadOnly = false;
                this.dgvLista.CellBorderStyle = DataGridViewCellBorderStyle.Raised;

                if (OperacionARealizar.ToUpper() == "ELIMINAR" || OperacionARealizar.ToUpper() == "CONSULTAR" || OperacionARealizar.ToUpper() == "GRABAR DATOS".ToUpper())
                {
                    dgvLista.Columns["Debe"].ReadOnly = true;
                    dgvLista.Columns["Haber"].ReadOnly = true;
                    dgvLista.Columns["ConceptoDeBanco"].ReadOnly = true;
                    dgvLista.Columns["RefBanco"].ReadOnly = true;
                    dgvLista.Columns["Eliminar"].ReadOnly = true;

                }

                if (OperacionARealizar == "Eliminar")
                {
                    dgvLista.DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Strikeout);
                    dgvLista.DefaultCellStyle.ForeColor = Color.Red;
                    dgvLista.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                else
                {
                    dgvLista.DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Regular);
                    dgvLista.DefaultCellStyle.ForeColor = Color.Black;
                    dgvLista.DefaultCellStyle.SelectionForeColor = Color.Black;
                }

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
                                oFormato = new FormatoDGV(c1.Name.Trim(), "TransaccionesDetalle");
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

        private void PrecargarDGV()
        {
            try
            {
                int NumeroFilas = 15;

                if(dgvLista.Rows.Count == 0)
                {
                    int i = 1; 
                    while (i < NumeroFilas)
                    {
                        dgvLista.Rows.Add(false, "",0,0, 0, "", 0,0,"","",0,0, false);
                        i++;
                    }
                }else if (dgvLista.Rows.Count < NumeroFilas)
                {
                    int i = dgvLista.Rows.Count;
                    while(i < NumeroFilas)
                    {
                        dgvLista.Rows.Add(false, "",0,0, 0, "", 0, 0, "", "", 0, 0, false);
                        i++;
                    }
                }else if (dgvLista.Rows.Count >= NumeroFilas)
                {
                    dgvLista.Rows.Add(false, "",0, 0,0, "", 0, 0, "", "", 0, 0, false);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Precargar DGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TransaccionDetalleTMPEN InformacionDelRegistroDelDetalle(DataGridViewRow Fila)
        {
            TransaccionDetalleTMPEN oRegitroEN = new TransaccionDetalleTMPEN();

            oRegitroEN.idTransaccionDetalle = Convert.ToInt32(Fila.Cells["idTransaccionDetalle"].Value);
            oRegitroEN.oTransaccionesEN = InformacionDelRegistro();
            oRegitroEN.oCuentaEN.NoCuenta = Convert.ToInt32(Fila.Cells["NoCuenta"].Value.ToString());
            oRegitroEN.oCuentaEN.idCuenta = Fila.Cells["idCuenta"].Value.ToString();
            oRegitroEN.oCuentaEN.DescCuenta = Fila.Cells["DescCuenta"].Value.ToString();
            oRegitroEN.Debe = Convert.ToDecimal(Fila.Cells["Debe"].Value);
            oRegitroEN.Haber = Convert.ToDecimal(Fila.Cells["Haber"].Value);
            
            oRegitroEN.IdUsuarioDeCreacion = Program.oLoginEN.idUsuario;
            oRegitroEN.IdUsuarioDeModificacion = Program.oLoginEN.idUsuario;
            oRegitroEN.FechaDeCreacion = System.DateTime.Now;
            oRegitroEN.FechaDeModificacion = System.DateTime.Now;
            oRegitroEN.oLoginEN = Program.oLoginEN;

            return oRegitroEN;

        }

        private bool LosDatosIngresadosEnGrillaSonCorrectos(DataGridViewRow Fila)
        {
            try
            {
                if (Convert.ToBoolean(Fila.Cells["Eliminar"].Value) == false)
                {
                    object ValorAEvaluar = null;
                    DataGridViewCell CeldaAEvaluar = null;
                    string NombreCampoId, NombreCampoNombre;

                    //Evaluar la cuenta
                    NombreCampoId = "NoCuenta";
                    NombreCampoNombre = "idCuenta";
                    ValorAEvaluar = Fila.Cells[NombreCampoId].Value;
                    CeldaAEvaluar = Fila.Cells[NombreCampoNombre];

                    if (ValorAEvaluar == null || string.IsNullOrEmpty(ValorAEvaluar.ToString()) || Convert.ToInt32(ValorAEvaluar) == 0)
                    {
                        Fila.Selected = true;
                        dgvLista.CurrentCell = CeldaAEvaluar;
                        dgvLista.CurrentCell.ErrorText = "Es necesario seleccionar una cuenta";
                        MessageBox.Show(String.Format("Es requerido seleccionar o ingresar un cuenta "), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                    {
                        ValorAEvaluar = Fila.Cells[NombreCampoNombre].Value;
                        if (ValorAEvaluar == null || string.IsNullOrEmpty(ValorAEvaluar.ToString()))
                        {
                            Fila.Selected = true;
                            dgvLista.CurrentCell = CeldaAEvaluar;
                            dgvLista.CurrentCell.ErrorText = "Es necesario seleccionar una cuenta";
                            MessageBox.Show(String.Format("Es requerido seleccionar o ingresar un cuenta "), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                      
                    //Debe
                    NombreCampoId = "Debe";
                    NombreCampoNombre = "Debe";
                    ValorAEvaluar = Fila.Cells[NombreCampoId].Value;
                    CeldaAEvaluar = Fila.Cells[NombreCampoNombre];

                    if (ValorAEvaluar == null || string.IsNullOrEmpty(ValorAEvaluar.ToString()) || Convert.ToDecimal(ValorAEvaluar) == -1)
                    {
                        Fila.Selected = true;
                        dgvLista.CurrentCell = CeldaAEvaluar;
                        dgvLista.CurrentCell.ErrorText = "Es requerido ingresar un valor";
                        MessageBox.Show(String.Format("Es requerido ingresar el valor del haber {0} {0} Cuenta: {1} - {2}", Environment.NewLine, Fila.Cells["idCuenta"].Value,Fila.Cells["DescCuenta"].Value), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    //Debe
                    NombreCampoId = "Haber";
                    NombreCampoNombre = "Haber";
                    ValorAEvaluar = Fila.Cells[NombreCampoId].Value;
                    CeldaAEvaluar = Fila.Cells[NombreCampoNombre];

                    if (ValorAEvaluar == null || string.IsNullOrEmpty(ValorAEvaluar.ToString()) || Convert.ToDecimal(ValorAEvaluar) == -1)
                    {
                        Fila.Selected = true;
                        dgvLista.CurrentCell = CeldaAEvaluar;
                        dgvLista.CurrentCell.ErrorText = "Es requerido ingresar un valor";
                        MessageBox.Show(String.Format("Es requerido ingresar el valor del haber {0} {0} Cuenta: {1} - {2}", Environment.NewLine, Fila.Cells["idCuenta"].Value, Fila.Cells["DescCuenta"].Value), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    int EsCuentaDeBanco = Convert.ToInt32(Fila.Cells["EsCuentaDeBanco"].Value);

                    if(EsCuentaDeBanco > 0)
                    {
                        string Referencia = Fila.Cells["RefBanco"].Value.ToString();
                        List<string> RDB = new List<string>(new string[] { "Nota de Crédito", "Nota de Débito", "Deposito" });
                        /*RDB.Add("Nota de Crédito"); RDB.Add("Nota de Débito"); RDB.Add("Deposito");*/

                        if(RDB.Contains(Referencia, StringComparer.OrdinalIgnoreCase) == false)
                        {
                            NombreCampoId = "RefBanco";
                            NombreCampoNombre = "RefBanco";
                            ValorAEvaluar = Fila.Cells[NombreCampoId].Value;
                            CeldaAEvaluar = Fila.Cells[NombreCampoNombre];

                            if (ValorAEvaluar == null || string.IsNullOrEmpty(ValorAEvaluar.ToString()) || Convert.ToDecimal(ValorAEvaluar) <= 0 )
                            {
                                Fila.Selected = true;
                                dgvLista.CurrentCell = CeldaAEvaluar;
                                dgvLista.CurrentCell.ErrorText = "Debe Seleccionar una elemento de la lista o escribir el Numero de Referencia de Ck.";
                                MessageBox.Show(String.Format("Debe Seleccionar una elemento de la lista o escribir el Numero de Referencia de Ck. {0} {0} Para la Cuenta: {1} - {2}", Environment.NewLine, Fila.Cells["idCuenta"].Value, Fila.Cells["DescCuenta"].Value), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }

                            NombreCampoId = "ConceptoDeBanco";
                            NombreCampoNombre = "ConceptoDeBanco";
                            ValorAEvaluar = Fila.Cells[NombreCampoId].Value;
                            CeldaAEvaluar = Fila.Cells[NombreCampoNombre];

                            if (ValorAEvaluar == null || string.IsNullOrEmpty(ValorAEvaluar.ToString()) || ValorAEvaluar.ToString().Trim().Length <= 0)
                            {
                                Fila.Selected = true;
                                dgvLista.CurrentCell = CeldaAEvaluar;
                                dgvLista.CurrentCell.ErrorText = "La celda no puede quedar vacio se debe ingresar el concepto de la referencia bancario de Ck";
                                MessageBox.Show(String.Format("La celda no puede quedar vacio se debe ingresar el concepto de la referencia bancario de Ck. {0} {0} Para la Cuenta: {1} - {2}", Environment.NewLine, Fila.Cells["idCuenta"].Value, Fila.Cells["DescCuenta"].Value), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }

                        }

                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Fila.Selected = true;
                dgvLista.CurrentCell = Fila.Cells["idCuenta"];
                MessageBox.Show(ex.Message, "Buscar Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private TansaccionDetalleTMPBancoEN InformacionDelaCuentaDeBanco(DataGridViewRow Fila)
        {
            TansaccionDetalleTMPBancoEN oCuentaDeBanco = new TansaccionDetalleTMPBancoEN();

            oCuentaDeBanco.Debe = Convert.ToDecimal(Fila.Cells["Debe"].Value);
            oCuentaDeBanco.Haber = Convert.ToDecimal(Fila.Cells["Haber"].Value);
            oCuentaDeBanco.idTansaccionDetalle_Banco = Convert.ToInt32(Fila.Cells["idTansaccionDetalle_Banco"].Value);
            oCuentaDeBanco.oTransaccionDetalleEN = InformacionDelRegistroDelDetalle(Fila);
            oCuentaDeBanco.ReferenciaBanco = Fila.Cells["RefBanco"].Value.ToString();
            oCuentaDeBanco.DescBanco = Fila.Cells["ConceptoDeBanco"].Value.ToString();

            oCuentaDeBanco.IdUsuarioDeCreacion = Program.oLoginEN.idUsuario;
            oCuentaDeBanco.IdUsuarioDeModificacion = Program.oLoginEN.idUsuario;
            oCuentaDeBanco.FechaDeCreacion = System.DateTime.Now;
            oCuentaDeBanco.FechaDeModificacion = System.DateTime.Now;
            oCuentaDeBanco.oLoginEN = Program.oLoginEN;

            return oCuentaDeBanco;
        }

        private bool InsertarActualizarOEliminarDetalleDelaTransaccion()
        {
            try
            {
                if (EvaluarDataGridView(dgvLista) == false) { return true; }

                if (dgvLista.Rows.Count > 0)
                {
                    MostrarBarraDeProgreso();
                    InicializarBarraDeProgreso(dgvLista.Rows.Count, 0);
                    int indice = 0;
                    int IndiceProgreso = 0;
                    int TotalDeFilasMarcadasParaEliminar = 0;

                    TotalDeFilasMarcadasParaEliminar = TotalDeFilasMarcadas("Eliminar");
                    
                    /*Fin de la información general*/

                    while (indice <= dgvLista.Rows.Count - 1)
                    {
                        IncrementarBarraDeProgreso(IndiceProgreso + 1);
                        DataGridViewRow Fila = dgvLista.Rows[indice];

                        int Ocupada = Convert.ToInt32(Fila.Cells["Ocupada"].Value);

                        if(Ocupada == 0)
                        {
                            indice++;
                            IndiceProgreso++;
                            continue;
                        }

                        if (LosDatosIngresadosEnGrillaSonCorrectos(Fila) == false)
                        {
                            if (indice < dgvLista.Rows.Count - 1)
                            {
                                if (MessageBox.Show("¿Desea continuar con los restantes registros a procesar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                                {
                                    OcultarBarraDeProgreso();
                                    return false;
                                }
                                else
                                {
                                    indice++;
                                    IndiceProgreso++;
                                    continue;
                                }
                            }
                            else
                            {
                                OcultarBarraDeProgreso();
                                return false;
                            }
                        }

                        this.Cursor = Cursors.WaitCursor;

                        TransaccionDetalleTMPEN oRegistrosEN = InformacionDelRegistroDelDetalle(Fila);
                        TransaccionDetalleTMPLN oRegistrosLN = new TransaccionDetalleTMPLN();                        

                        //DETERMINAMOS LA OPERACION A REALIZAR
                        string Operacion = "";
                        string NombreLavePrimariaDetalle = "idTransaccionDetalle";

                        //El orden es importante porque si un usuario agrego una nueva persona pero lo marco para eliminar, no hacemos nada, solo lo quitamos de la lista.
                        if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) == 0 && Convert.ToBoolean(Fila.Cells["Eliminar"].Value) == true) { Operacion = "ELIMINAR FILA EN GRILLA"; }
                        //El orden es importante porque si un usuario agrego una nueva persona aunque lo modifique en la grilla, sigue siendo una inserción
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) == 0) { Operacion = "AGREGAR"; }
                        //El orden es importante porque si un usuario modificó una nueva persona y despues lo marco para eliminación, predomina la eliminación
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) > 0 && Convert.ToBoolean(Fila.Cells["Eliminar"].Value) == true) { Operacion = "ELIMINAR"; }
                        //El orden es importante porque si un usuario modifico una nueva persona esta se ejecuta de último en orden de prioridades con respecto a la eliminación
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) > 0 && Convert.ToBoolean(Fila.Cells["Actualizar"].Value) == true) { Operacion = "ACTUALIZAR"; }
                        //Si la fila se cargo de la base de datos y no se indico ninguna acción sobre ella, no hacemos nada
                        else if (Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value) > 0 && Convert.ToBoolean(Fila.Cells["Actualizar"].Value) == false && Convert.ToBoolean(Fila.Cells["Eliminar"].Value) == false) { Operacion = "NINGUNA"; }

                        //VALIDACIONES
                        if (Operacion == "ELIMINAR FILA EN GRILLA")
                        {
                            dgvLista.Rows.Remove(Fila);
                            //Cuando eliminamos una fila y hay filas en la grilla, no incrementamos el indice porque al eliminar la fila, la
                            //siguiente ocupa la posicióin de la fila eliminada, entonces no se necesita incrementar, pero si ya no hay filas 
                            //en la grilla si lo incrementamos para que el ciclo pare.
                            if (dgvLista.RowCount <= 0) { indice++; IndiceProgreso++; }
                            continue;
                        }

                        if (Operacion == "NINGUNA")
                        {
                            indice++;
                            IndiceProgreso++;
                            continue;
                        }
                        if (Operacion == "AGREGAR")
                        {
                            //pendiente
                        }
                        if (Operacion == "ACTUALIZAR")
                        {
                            //pendiente
                        }
                        if (Operacion == "ELIMINAR")
                        {
                            //Pendiente
                        }
                        //OPERACIONES
                        if (Operacion == "AGREGAR")
                        {
                            if (oRegistrosLN.Agregar(oRegistrosEN, Program.oDatosDeConexion))
                            {
                                Fila.Cells[NombreLavePrimariaDetalle].Value = oRegistrosEN.idTransaccionDetalle;
                                Fila.Cells["Actualizar"].Value = false;
                                
                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                indice++;
                                IndiceProgreso++;

                                int EsCuentaDeBanco = Convert.ToInt32(Fila.Cells["EsCuentaDeBanco"].Value);
                                if (EsCuentaDeBanco > 0)
                                {

                                    TansaccionDetalleTMPBancoEN oCuentaDeBancoEN = InformacionDelaCuentaDeBanco(Fila);
                                    TansaccionDetalle_BancoLN oCuentaDeBancoLN = new TansaccionDetalle_BancoLN();

                                    if(oCuentaDeBancoLN.Agregar(oCuentaDeBancoEN, Program.oDatosDeConexion))
                                    {
                                        Fila.Cells["idTansaccionDetalle_Banco"].Value = oCuentaDeBancoEN.idTansaccionDetalle_Banco;
                                    }else
                                    {
                                        MessageBox.Show(string.Format("Ocurrio un error al agregar la cuenta de banco: {0} {1}", Environment.NewLine, oCuentaDeBancoLN.Error), "Agregar Cuenta de banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }

                                }

                                continue;
                                                                
                            }
                            else
                            {
                                OcultarBarraDeProgreso();
                                this.Cursor = Cursors.Default;
                                MessageBox.Show(oRegistrosLN.Error, OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                oRegistrosLN = null;
                                oRegistrosEN = null;
                                return false;
                            }
                        }

                        if (Operacion == "ACTUALIZAR")
                        {
                            oRegistrosEN.idTransaccionDetalle = Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value);

                            if (oRegistrosLN.Actualizar(oRegistrosEN, Program.oDatosDeConexion))
                            {
                                dgvLista.Rows[Fila.Index].Cells["Actualizar"].Value = false;

                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                indice++;
                                IndiceProgreso++;

                                int EsCuentaDeBanco = Convert.ToInt32(Fila.Cells["EsCuentaDeBanco"].Value);
                                int idTansaccionDetalle_Banco = Convert.ToInt32(Fila.Cells["idTansaccionDetalle_Banco"].Value);
                                if (idTansaccionDetalle_Banco > 0 && EsCuentaDeBanco > 0)
                                {

                                    TansaccionDetalleTMPBancoEN oCuentaDeBancoEN = InformacionDelaCuentaDeBanco(Fila);
                                    TansaccionDetalle_BancoLN oCuentaDeBancoLN = new TansaccionDetalle_BancoLN();

                                    if (oCuentaDeBancoLN.Actualizar(oCuentaDeBancoEN, Program.oDatosDeConexion) == false) {                                     
                                        MessageBox.Show(string.Format("Ocurrio un error al actualizar la cuenta de banco: {0} {1}", Environment.NewLine, oCuentaDeBancoLN.Error), "Actualizar Cuenta de banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }

                                }else if(idTansaccionDetalle_Banco > 0 && EsCuentaDeBanco == 0)
                                {

                                    TansaccionDetalleTMPBancoEN oCuentaDeBancoEN = InformacionDelaCuentaDeBanco(Fila);
                                    TansaccionDetalle_BancoLN oCuentaDeBancoLN = new TansaccionDetalle_BancoLN();

                                    if (oCuentaDeBancoLN.Eliminar(oCuentaDeBancoEN, Program.oDatosDeConexion) == false)
                                    {
                                        MessageBox.Show(string.Format("Ocurrio un error al eliminar la cuenta de banco: {0} {1}", Environment.NewLine, oCuentaDeBancoLN.Error), "Actualizar Cuenta de banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }

                                }else if (idTansaccionDetalle_Banco == 0 && EsCuentaDeBanco > 0)
                                {
                                    TansaccionDetalleTMPBancoEN oCuentaDeBancoEN = InformacionDelaCuentaDeBanco(Fila);
                                    TansaccionDetalle_BancoLN oCuentaDeBancoLN = new TansaccionDetalle_BancoLN();

                                    if (oCuentaDeBancoLN.Agregar(oCuentaDeBancoEN, Program.oDatosDeConexion))
                                    {
                                        Fila.Cells["idTansaccionDetalle_Banco"].Value = oCuentaDeBancoEN.idTansaccionDetalle_Banco;
                                    }
                                    else
                                    {
                                        MessageBox.Show(string.Format("Ocurrio un error al agregar la cuenta de banco: {0} {1}", Environment.NewLine, oCuentaDeBancoLN.Error), "Actualizar Cuenta de banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }

                                continue;
                                              
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show(oRegistrosLN.Error, OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                OcultarBarraDeProgreso();
                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                return false;
                            }
                        }

                        if (Operacion == "ELIMINAR")
                        {
                            oRegistrosEN.idTransaccionDetalle = Convert.ToInt32(Fila.Cells[NombreLavePrimariaDetalle].Value);

                            int EsCuentaDeBanco = Convert.ToInt32(Fila.Cells["EsCuentaDeBanco"].Value);
                            int idTansaccionDetalle_Banco = Convert.ToInt32(Fila.Cells["idTansaccionDetalle_Banco"].Value);

                            if (EsCuentaDeBanco > 0 && idTansaccionDetalle_Banco > 0)
                            {

                                TansaccionDetalleTMPBancoEN oCuentaDeBancoEN = InformacionDelaCuentaDeBanco(Fila);
                                TansaccionDetalle_BancoLN oCuentaDeBancoLN = new TansaccionDetalle_BancoLN();

                                if (oCuentaDeBancoLN.Eliminar(oCuentaDeBancoEN, Program.oDatosDeConexion))
                                {
                                    Fila.Cells["idTansaccionDetalle_Banco"].Value = oCuentaDeBancoEN.idTansaccionDetalle_Banco;
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Ocurrio un error al eliminar la cuenta de banco: {0} {1}", Environment.NewLine, oCuentaDeBancoLN.Error), "Eliminar Cuenta de banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                            }

                            if (oRegistrosLN.Eliminar(oRegistrosEN, Program.oDatosDeConexion))
                            {
                                dgvLista.Rows.Remove(Fila);

                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                //Cuando eliminamos una fila y hay filas en la grilla, no incrementamos el indice porque al eliminar la fila, la
                                //siguiente ocupa la posicióin de la fila eliminada, entonces no se necesita incrementar, pero si ya no hay filas 
                                //en la grilla si lo incrementamos para que el ciclo pare.
                                if (dgvLista.RowCount <= 0) { indice++; }
                                IndiceProgreso++;
                                continue;                                
                            }
                            else
                            {
                                OcultarBarraDeProgreso();
                                this.Cursor = Cursors.Default;
                                MessageBox.Show(oRegistrosLN.Error, OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                oRegistrosEN = null;
                                oRegistrosLN = null;
                                return false;
                            }
                        }
                        this.Cursor = Cursors.Default;
                    }
                                        
                    //lblCantidadRegistros.Text = "No. Registros: " + dgvListaProductos.RowCount.ToString();
                    OcultarBarraDeProgreso();
                    return true;
                }
                else { return true; }
            }
            catch (Exception ex)
            {
                OcultarBarraDeProgreso();
                MessageBox.Show("Error al intentar " + OperacionARealizar + " \n Error: " + ex.Message, "Insertar, Actualizar o Eliminar un privilegio del usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private int TotalDeFilasMarcadas(String Columna)
        {
            try
            {
                int numero = 0;
                foreach (DataGridViewRow Fila in dgvLista.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells[Columna].Value) == true)
                    {
                        numero++;
                    }
                }
                return (numero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contabilizar las columnas (" + Columna + ") marcadas. \n" + ex.Message, "Total de filas marcadas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0);
            }
        }

        private bool EvaluarDataGridView(DataGridView dgv)
        {

            if (OperacionARealizar.Trim().ToUpper() == "MODIFICAR".ToUpper())
            {
                if (dgv.Rows.Count > 0)
                {

                    List<DataGridViewRow> rows = (from item in dgv.Rows.Cast<DataGridViewRow>()
                                                  let Actualizar = Convert.ToBoolean(item.Cells["Actualizar"].Value ?? false)
                                                  let Eliminar = Convert.ToBoolean(item.Cells["Eliminar"].Value ?? false)
                                                  let Ocupada = Convert.ToInt32(item.Cells["Ocupada"].Value)
                                                  where (Actualizar.Equals(true) || Eliminar.Equals(true)) && Ocupada == 1
                                                  select item).ToList<DataGridViewRow>();

                    if (rows.Count > 0)
                    {

                        return true;
                    }
                    else
                    {
                        /*
                        List<DataGridViewRow> rows1 = (from item in dgv.Rows.Cast<DataGridViewRow>()
                                                       let Eliminar = Convert.ToBoolean(item.Cells["Eliminar"].Value ?? false)
                                                       where Eliminar.Equals(true)
                                                       select item).ToList<DataGridViewRow>();

                        if (rows1.Count > 0)
                        {
                            return true;
                        }*/

                        return false;

                    }


                }
                else
                {

                    return false;
                }

            }
            else
            {
                return true;
            }
        }

        private void dgvLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLista.IsCurrentCellDirty)
            {
                dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Mask_Leave(object sender, EventArgs e)
        {
            //Cuando el combobox pierde el foco, lo ocultamos y liberamos.
            if (Mask != null)
            {
                Mask.Visible = false;
                Mask = null;
                dgvLista.Focus();
            }                      

        }

        private void Listas_Leave(object sender, EventArgs e)
        {
            //Cuando el combobox pierde el foco, lo ocultamos y liberamos.
            if (Listas != null)
            {                
                Listas.Visible = false;
                Listas = null;
                dgvLista.Focus();
            }
            
        }

        private void Listas_DoubleClick(object sender, EventArgs e)
        {
            if (Listas.Items.Count > 0)
            {
                foreach (ListViewItem Item in Listas.SelectedItems)
                {
                    DataGridViewRow Fila = dgvLista.CurrentRow;

                    Fila.Cells["NoCuenta"].Value = Item.SubItems[3].Text;
                    Fila.Cells["idCuenta"].Value = Item.SubItems[4].Text;
                    Fila.Cells["DescCuenta"].Value = Item.SubItems[5].Text;
                    Fila.Cells["Actualizar"].Value = true;
                    Fila.Cells["Ocupada"].Value = 1;

                    int EsCuentaDeBanco = Convert.ToInt32(Item.SubItems[16].Text);

                    if (EsCuentaDeBanco == 1)
                    {
                        Fila.Cells["EsCuentaDeBanco"].Value = EsCuentaDeBanco;
                    }
                    else
                    {
                        Fila.Cells["EsCuentaDeBanco"].Value = 0;
                    }

                    ActivarColumnas();

                    Fila.Cells["Debe"].Selected = true;
                    
                }

                if (Listas != null)
                {
                    Listas.Visible = false;
                    Listas = null;
                }

            }
        }
        
       /* private void Mask_KeyUp(object sender, KeyEventArgs e)
        {            
            BuscarInformacionDeLaCuenta(ref mskIdCliente);
        }*/
        
        private void dgvLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Las celdas que solo acepta números les vinculamos el evento para la validación de solo números
            string Columname = dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name;
            if (Columname == "Debe" || Columname == "Haber")
            {
                //referencia a la celda          
                TextBox txt = (TextBox)e.Control;

                //Indicamos con cuantos decimales trabajará los números
                txt.MaxLength = 18;
                txt.Tag = 2;
                //agregar el controlador de eventos para el KeyPress  

                if (txt != null)
                {
                    txt.KeyPress -= dgvLista_KeyPress;
                    txt.KeyPress += dgvLista_KeyPress;
                    txt.KeyDown += dgvLista_KeyDown;
                }
            }

        }

        private void dgvLista_Scroll(object sender, ScrollEventArgs e)
        {
            Mask_Leave(null, null);
            Listas_Leave(null, null);
            cmb_Leave(null, null);
            
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name == "Eliminar")
                {
                    if (Convert.ToBoolean(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Eliminar"].Value) == true)
                    {
                        dgvLista.Rows[dgvLista.CurrentCell.RowIndex].DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Strikeout);
                        dgvLista.Rows[dgvLista.CurrentCell.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        dgvLista.Rows[dgvLista.CurrentCell.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;

                        Calcular_Bebe();
                        Calcular_Haber();
                        
                    }
                    else
                    {
                        dgvLista.Rows[dgvLista.CurrentCell.RowIndex].DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Regular);
                        dgvLista.Rows[dgvLista.CurrentCell.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        dgvLista.Rows[dgvLista.CurrentCell.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

                        Calcular_Bebe();
                        Calcular_Haber();

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:", ex.Message);
            }
        }

        private void dgvLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ColumName = dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name;

            if(ColumName.ToUpper() == "Debe".ToUpper())
            {
                dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Haber"].Value = "0.00";
            }

            if (ColumName.ToUpper() == "Haber".ToUpper())
            {
                dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Debe"].Value = "0.00";
            }

            if (ColumName == "Debe" || ColumName == "Haber")
            {
                //Obtener caracter  
                char caracter = e.KeyChar;
                TextBox txt = (TextBox)sender;                
                e.Handled = Numeros.EnterosYDecimales(e, txt, 2);

            }
            else
            {
                e.Handled = false;
            }
        }

        private void Calcular_Bebe()
        {

            List<DataGridViewRow> rows = (from item in dgvLista.Rows.Cast<DataGridViewRow>()
                                          let Ocupada = Convert.ToInt32(item.Cells["Ocupada"].Value)
                                          where Ocupada == 1
                                          select item).ToList<DataGridViewRow>();

            decimal Sumar = 0;

            if (rows.Count > 0)
            {
                foreach (DataGridViewRow Item in rows)
                {
                    Sumar = Sumar + Convert.ToDecimal(Item.Cells["Debe"].Value);
                }
            }

            dgvLista.Columns["Debe"].HeaderText = string.Format("Debe {0} ____________________ {0} {1:###,##0.00}", Environment.NewLine, Sumar);
            TotalDebe = Sumar;

        }

        private void Calcular_Haber()
        {

            List<DataGridViewRow> rows = (from item in dgvLista.Rows.Cast<DataGridViewRow>()
                                          let Ocupada = Convert.ToInt32(item.Cells["Ocupada"].Value)
                                          where Ocupada == 1
                                          select item).ToList<DataGridViewRow>();

            decimal Sumar = 0;

            if (rows.Count > 0)
            {
                foreach (DataGridViewRow Item in rows)
                {
                    Sumar = Sumar + Convert.ToDecimal(Item.Cells["Haber"].Value);
                }
            }

            dgvLista.Columns["Haber"].HeaderText = string.Format("Haber {0} ____________________ {0} {1:###,##0.00}", Environment.NewLine, Sumar);
            TotalHaber = Sumar;

        }

        private void dgvLista_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvLista.CurrentCell.ColumnIndex >= 0 && dgvLista.CurrentCell.ColumnIndex < dgvLista.Columns.Count - 2 && dgvLista.CurrentCell.Visible == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvLista.CurrentRow.Cells[dgvLista.CurrentCell.ColumnIndex].Visible == true)
                    {
                        if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name.ToUpper() == "Debe".ToUpper())
                        {
                            decimal Debe = Convert.ToDecimal(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Debe"].Value.ToString());

                            if (Debe > 0)
                            {                               
                                dgvLista.CurrentCell = dgvLista.CurrentRow.Cells[1];
                            }

                        }

                                         
                    }
                }
            }
        }

        private void RealizarSaltoCorrespondiente()
        {
            if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name.ToUpper() == "Debe".ToUpper())
            {
                decimal Debe = Convert.ToDecimal(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Debe"].Value.ToString());

                if(Debe == 0)
                {
                    dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Haber"].Selected = true;
                }
                
            }

            if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name.ToUpper() == "Haber".ToUpper())
            {
                decimal Haber = Convert.ToDecimal(dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Haber"].Value.ToString());

                if (Haber == 0)
                {
                    dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["Debe"].Selected = true;
                }

            }
            
        }

        private void dgvLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }

            if (OperacionARealizar.ToUpper() != "Eliminar".ToUpper() && OperacionARealizar.ToUpper() != "Consultar".ToUpper() || OperacionARealizar.ToUpper() != "GRABAR DATOS".ToUpper())
            {

                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "idCuenta".ToUpper())
                {                    
                    BuscarInformacionDeLaCuentaPorIdCuenta();
                    dgvLista.Rows[e.RowIndex].Cells["Actualizar"].Value = true;  
                    
                    KeyEventArgs enterKeyDown = new KeyEventArgs(Keys.Enter);                         
                    dgvLista_KeyDown(dgvLista, enterKeyDown);

                }

                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "RefBanco".ToUpper())
                {
                    if (Combo != null)
                    {
                        if (Combo.Visible == true)
                        {
                            dgvLista.CurrentCell.Value = Combo.Text;
                            Combo.Visible = false;
                            Combo = null;
                            dgvLista.Rows[e.RowIndex].Cells["Actualizar"].Value = true;
                        }
                    }
                }
                
                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "ConceptoDeBanco".ToUpper())
                {
                    dgvLista.Rows[e.RowIndex].Cells["Actualizar"].Value = true;
                }

                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "Haber".ToUpper())
                {
                    Calcular_Haber();
                    dgvLista.Rows[e.RowIndex].Cells["Actualizar"].Value = true;
                }

                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "Debe".ToUpper())
                {
                    Calcular_Bebe();
                    dgvLista.Rows[e.RowIndex].Cells["Actualizar"].Value = true;
                }

            }

        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dgvLista_CellEnter(sender, e);
        }

        private void dgvLista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {                
                return;
            }

            if (OperacionARealizar.ToUpper() != "Eliminar".ToUpper() && OperacionARealizar.ToUpper() != "Consultar".ToUpper() || OperacionARealizar.ToUpper() != "GRABAR DATOS".ToUpper())
            {
                               
                int EsCuentaDeBanco = Convert.ToInt32( dgvLista.Rows[e.RowIndex].Cells["EsCuentaDeBanco"].Value );
                int Ocupada = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["Ocupada"].Value);

                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "RefBanco".ToUpper() && EsCuentaDeBanco == 1 && Ocupada == 1)
                {

                    try
                    {
                        if (cmbTipoDeTransacción.SelectedIndex == -1)
                        {
                            MessageBox.Show("Se debe de seleccionar el Tipo de Transacción a realizar", "Referencia de banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbTipoDeTransacción.Focus();
                            return;
                        }

                        if (Combo != null)
                        {
                            Combo.Visible = false;
                            Combo = null;
                        }

                        Combo = new ComboBox();
                        Combo.DropDownStyle = ComboBoxStyle.DropDown;

                        EnlazarComboCargoParaListaNivelAcademico(ref Combo);

                        dgvLista.Controls.Add(Combo);

                        Combo.Visible = false;

                        Rectangle Rectangle2 = dgvLista.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        Combo.Size = new Size(Rectangle2.Width, Rectangle2.Height);
                        Combo.Location = new Point(Rectangle2.X, Rectangle2.Y);

                        //Combo.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
                        Combo.SelectedValueChanged += new EventHandler(cmb_SelectedValueChanged);
                        Combo.DropDownClosed += new EventHandler(cmb_DropDownClosed);
                        Combo.Leave += new EventHandler(cmb_Leave);
                        Combo.KeyPress += new KeyPressEventHandler(cmb_KeyPress);
                        Combo.KeyUp += new KeyEventHandler(cmb_KeyUp);

                        Combo.Text = dgvLista.CurrentCell.Value.ToString();

                        Combo.Visible = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Información de la referencia del banco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
        }

        private void dgvLista_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {

                if (OperacionARealizar.ToUpper() != "Eliminar".ToUpper() && OperacionARealizar.ToUpper() != "Consultar".ToUpper() || OperacionARealizar.ToUpper() != "GRABAR DATOS".ToUpper())
                {

                    if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "idCuenta".ToUpper())
                    {
                        
                        KeyEventArgs enterKeyDown = new KeyEventArgs(Keys.Enter);
                        dgvLista_KeyDown(dgvLista, enterKeyDown);
                        

                    }

                    if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "Debe".ToUpper() || dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "Haber".ToUpper())
                    {

                        decimal Valor;
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()) || !Decimal.TryParse(e.FormattedValue.ToString(), out Valor) || Valor < 0)
                        {
                            e.Cancel = true;
                            MessageBox.Show("Ingrese un valor numérico válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }

                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Validacion - CellValidating", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvLista_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }

            if (OperacionARealizar.ToUpper() != "Eliminar".ToUpper() && OperacionARealizar.ToUpper() != "Consultar".ToUpper() || OperacionARealizar.ToUpper() != "GRABAR DATOS".ToUpper())
            {
                
                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "Debe".ToUpper())
                {
                    int NoCuenta = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["NoCuenta"].Value.ToString());
                    if(NoCuenta == 0)
                    {
                        MessageBox.Show("Se debe seleccionar una cuenta para poder ingresar valores");
                        dgvLista.Rows[e.RowIndex].Cells["idCuenta"].Selected = true;
                        return;
                    }
                }

                if (dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "Haber".ToUpper())
                {
                    int NoCuenta = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["NoCuenta"].Value.ToString());
                    if (NoCuenta == 0)
                    {
                        MessageBox.Show("Se debe seleccionar una cuenta para poder ingresar valores");
                        dgvLista.Rows[e.RowIndex].Cells["idCuenta"].Selected = true;
                    }
                }

            }

        }
        
        private void BuscarInformacionDeLaCuenta()
        {

            try
            {

                if(SeDigitoEnLaMascara())
                {
                    string Cadena = ExtraerCadenaDelaMascar();

                    CuentaEN oRegistroEN = new CuentaEN();
                    CuentaLN oRegistroLN = new CuentaLN();

                    oRegistroEN.Where = string.Format(" and idCuenta like '{0}%' and EvaluarSiEsCuentaPrincipal(c.NoCuenta) = 0 ", Cadena);
                    oRegistroEN.OrderBy = "";
                    
                    if(oRegistroLN.ListadoDetallado(oRegistroEN, Program.oDatosDeConexion))
                    {

                        if (Listas != null)
                        {
                            Listas.Visible = false;
                            Listas = null;
                        }

                        Listas = new ListView();
                        Listas.Clear();
                        Listas.View = View.Details;
                        Listas.FullRowSelect = true;
                        Listas.GridLines = true;

                        //agregamos las columnas al listview...
                        //1. debemos crear un datatable...

                        DataTable Datos = oRegistroLN.TraerDatos();
                        /*Ahora debemos agregar las columnas al listview*/
                        Datos.Columns.Cast<DataColumn>().ToList().ForEach(column => Listas.Columns.Add(column.Caption, -2));

                        OrganizarColumnasLV(ref Listas);

                        string columnas = @"idCategoriaDeCuenta,idTipoDeCuenta,idGrupoDeCuentas,NoCuenta,DescCategoriaDeCuenta,DescGrupoDeCuentas,SaldoCuenta,NivelCuenta,CuentaMadre,IdUsuarioDeCreacion,FechaDeCreacion,IdUsuarioDeModificacion,FechaDeModificacion,DescTipoDeCuenta,EsCuentaDeBanco";
                        OcultarColumnasEnElListView(columnas);

                        FormatearLV(ref Listas);                        

                        Listas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
                        
                        if (oRegistroLN.TraerDatos().Rows.Count > 0)
                        {

                            if (dgvLista.CurrentCell != null)
                            {
                                
                                /*Ahora debemos meter la informacion dento del listview*/                                
                                Datos.AsEnumerable().ToList().ForEach(row =>
                                {
                                    ListViewItem item = new ListViewItem(Convert.ToString(row[0]));
                                    row.ItemArray.ToList().Skip(1).ToList().ForEach(value => item.SubItems.Add(Convert.ToString(value)));
                                    Listas.Items.Add(item);
                                });

                                Listas.Visible = false;
                                dgvLista.Controls.Add(Listas);

                                                                               
                                
                            }

                        }else
                        {
                            Listas.Visible = false;
                            dgvLista.Controls.Add(Listas);
                            
                        }

                        Rectangle Rectangle = dgvLista.GetCellDisplayRectangle(dgvLista.CurrentCell.ColumnIndex, dgvLista.CurrentCell.RowIndex, true);
                        Listas.Size = new Size(Rectangle.Width + 300, Rectangle.Height + 100);
                        Listas.Location = new Point(Rectangle.X, Rectangle.Y + Rectangle.Height);

                        Listas.Leave += new EventHandler(Listas_Leave);
                        Listas.DoubleClick += new EventHandler(Listas_DoubleClick);

                        Listas.Visible = true;
                    }

                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Buscar información de la cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BuscarInformacionDeLaCuentaPorIdCuenta()
        {

            try
            {

                if (SeDigitoEnLaMascara())
                {
                    string Cadena = ExtraerCadenaDelaMascar();

                    CuentaEN oRegistroEN = new CuentaEN();
                    CuentaLN oRegistroLN = new CuentaLN();

                    oRegistroEN.Where = string.Format(" and idCuenta like '{0}%' and EvaluarSiEsCuentaPrincipal(c.NoCuenta) = 0 ", Cadena);
                    oRegistroEN.OrderBy = "";

                    if (oRegistroLN.ListadoDetallado(oRegistroEN, Program.oDatosDeConexion))
                    {
                        if (oRegistroLN.TotalRegistros() > 0 && oRegistroLN.TotalRegistros() <= 1)
                        {
                            DataRow Row = oRegistroLN.TraerDatos().Rows[0];

                            DataGridViewRow Fila = dgvLista.CurrentRow;

                            Fila.Cells["NoCuenta"].Value = Row["NoCuenta"].ToString();
                            Fila.Cells["idCuenta"].Value = Row["idCuenta"].ToString();
                            Fila.Cells["DescCuenta"].Value = Row["DescCuenta"].ToString();
                            Fila.Cells["Actualizar"].Value = true;
                            Fila.Cells["Ocupada"].Value = 1;

                            int EsCuentaDeBanco = Convert.ToInt32(Row["EsCuentaDeBanco"].ToString());

                            if (EsCuentaDeBanco == 1)
                            {
                                Fila.Cells["EsCuentaDeBanco"].Value = EsCuentaDeBanco;
                            }
                            else
                            {
                                Fila.Cells["EsCuentaDeBanco"].Value = 0;
                            }

                            ActivarColumnas();

                            int TotalDeFilas = dgvLista.Rows.Count;
                            int FilaActual = dgvLista.CurrentRow.Index;

                            if(FilaActual == TotalDeFilas - 1)
                            {
                                dgvLista.CurrentCell = dgvLista.Rows[FilaActual - 2].Cells[dgvLista.CurrentCell.ColumnIndex + 4];
                            }else
                            {
                                dgvLista.CurrentCell = dgvLista.CurrentRow.Cells[dgvLista.CurrentCell.ColumnIndex + 4];
                            }

                            
                            
                        }                        
                    }

                }

                if(Listas != null)
                {
                    Listas.Visible = false;
                    Listas = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Buscar información de la cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OrganizarColumnasLV(ref ListView LVListas)
        {
            try
            {

                if (LVListas != null)
                {
                    if (LVListas.Columns.Count > 0)
                    {
                        int i = 0;

                        for(i= 0; i < LVListas.Columns.Count; i++)
                        {
                            string NCol = LVListas.Columns[i].Text.Trim();
                            LVListas.Columns[i].Name = NCol;
                        }                        

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Organizar las Columnas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnasEnElListView(String Columnas)
        {
            try
            {

                if(Listas != null)
                {
                    if(Listas.Columns.Count > 0)
                    {

                        String[] AColumnas = Columnas.Split(',');
                        System.Diagnostics.Debug.Print(Listas.Columns[0].Text);
                        foreach (string col in AColumnas)
                        {
                            Listas.Columns[col.Trim()].Width = 0;                           
                            
                        }

                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocultar columnas en la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearLV(ref ListView ListarLV)
        {
            try
            {

                if (ListarLV != null)
                {
                    if (ListarLV.Columns.Count > 0)
                    {

                        ListarLV.Columns["idCuenta"].Text = "No. Cuenta";
                        ListarLV.Columns["idCuenta"].Width = 80;
                        ListarLV.Columns["DescCuenta"].Text = "Descripción de la cuenta";
                        ListarLV.Columns["DescCuenta"].Width = 320;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formatear columnas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private bool SeDigitoEnLaMascara()
        {
            bool Valor = false;

            string Cadena = dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["idCuenta"].Value.ToString();
            string[] ACadena = Cadena.Split('-');

            foreach (string cad in ACadena)
            {
                string CadenaS = cad.Replace("_", "").Trim();                
                if (string.IsNullOrEmpty(CadenaS) || CadenaS.Trim().Length == 0)
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

            string Cadena = dgvLista.Rows[dgvLista.CurrentCell.RowIndex].Cells["idCuenta"].Value.ToString();
            string[] ACadena = Cadena.Split('-');

            foreach (string cad in ACadena)
            {
                string cad1 = cad.Replace("_", "").Trim();
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

        private void ConfigurarMascarDeEntrada(ref MaskedTextBox Mascara)
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

                Mascara.Mask = cadena;
            }
        }

        private string ConfigurarMascaraDeEntradaString()
        {
            string cadena = "";

            if (Program.oConfiguracionEN.NivelesDeLaCuenta > 0)
            {
                int i = 1;
                
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
                                
            }

            return cadena;
        }
        
        #endregion

        #region Barra de Progreso

        private void InicializarBarraDeProgreso(int Maximo, int Minimo)
        {
            Barradeprogreso.Minimum = Minimo;
            Barradeprogreso.Maximum = Maximo;
        }

        private void MostrarBarraDeProgreso()
        {
            Barradeprogreso.Visible = true;
            lbaBarradeprogreso.Visible = true;
        }

        private void OcultarBarraDeProgreso()
        {
            Barradeprogreso.Visible = false;
            lbaBarradeprogreso.Visible = false;
        }

        private void IncrementarBarraDeProgreso(int incremento)
        {
            Barradeprogreso.Value = incremento;
            lbaBarradeprogreso.Text = Barradeprogreso.Value.ToString() + " de " + Barradeprogreso.Maximum;
            Application.DoEvents();
        }

        #endregion

        #region Eventos del Formulario

        private void tsbOcultarPanelIzquierdo_Click(object sender, EventArgs e)
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
                else
                {

                }
            }
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            int idTransacciones = Convert.ToInt32(txtIdentificador.Text);

            if (ofrmVisor_1 == null || ofrmVisor_1.IsDisposed)
            {
                ofrmVisor_1 = new frmVisor();

                ofrmVisor_1.NombreReporte = "Transacciones - Imprimir comprobante";
                TransaccionTMPEN oRegistroEN = new TransaccionTMPEN();
                oRegistroEN.Where = string.Format(" AND t.idTransacciones = {0} ", idTransacciones);
                oRegistroEN.OrderBy = " ";
                oRegistroEN.TituloDelReporte = " ";
                ofrmVisor_1.Entidad = oRegistroEN;

                ofrmVisor_1.MdiParent = this.ParentForm;
                ofrmVisor_1.Show();
            }
            else
                ofrmVisor_1.BringToFront();
        }
        private void frmTransaccionOperacion_Shown(object sender, EventArgs e)
        {
            ObtenerValoresDeConfiguracion();
            LLenarComboListadoTipoDetransacciones();
            LlamarMetodoSegunOperacion();
            EstablecerTituloDeVentana();
            DeshabilitarControlesSegunOperacionesARealizar();
            OcultarBarraDeProgreso();            

        }

        /*private void ConfigurarMascaraDeEntradaDeDatos()
        {
            ConfigurarMascarDeEntrada(ref mskIdCliente);            
        }*/

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

        private void frmTransaccionOperacion_FormClosing(object sender, FormClosingEventArgs e)
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

                    TransaccionTMPEN oRegistroEN = InformacionDelRegistro();
                    TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                    /*if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexion, "AGREGAR"))
                    {

                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }*/

                    if (oRegistroLN.Agregar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idTransacciones.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.idTransacciones;

                        if (InsertarActualizarOEliminarDetalleDelaTransaccion())
                        {

                            EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Guardar");
                            
                            this.Cursor = Cursors.Default;

                            if (CerrarVentana == true)
                            {
                                this.Close();
                            }                            

                        }

                        OperacionARealizar = "Modificar";
                        ObtenerValoresDeConfiguracion();
                        LlamarMetodoSegunOperacion();
                        EstablecerTituloDeVentana();
                        DeshabilitarControlesSegunOperacionesARealizar();

                        oRegistroEN = null;
                        oRegistroLN = null;

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

                    TransaccionTMPEN oRegistroEN = InformacionDelRegistro();
                    TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    /*if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }*/

                    if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idTransacciones.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.idTransacciones;

                        if (InsertarActualizarOEliminarDetalleDelaTransaccion())
                        {

                            EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Actualizar");
                                                        
                            this.Cursor = Cursors.Default;

                            if (CerrarVentana == true)
                            {
                                this.Close();
                            }

                        }

                        oRegistroEN = null;
                        oRegistroLN = null;


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

                    TransaccionTMPEN oRegistroEN = InformacionDelRegistro();
                    TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexion, "ELIMINAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (InsertarActualizarOEliminarDetalleDelaTransaccion())
                    {
                        
                        if (oRegistroLN.Eliminar(oRegistroEN, Program.oDatosDeConexion))
                        {

                            txtIdentificador.Text = oRegistroEN.idTransacciones.ToString();
                            ValorLlavePrimariaEntidad = oRegistroEN.idTransacciones;

                            EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Eliminar");
                                                        
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

                    oRegistroEN = null;
                    oRegistroLN = null;


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

        private void tsbCuentas_Click(object sender, EventArgs e)
        {
            BuscarCuentasAsociadas();
        }
        
        #endregion

        private void tsbGrabarDatos_Click(object sender, EventArgs e)
        {
            try
            {

                if (LosDatosIngresadosSonCorrectos())
                {

                    decimal Valor = Convert.ToDecimal(txtValor.Text);

                    if (TotalDebe != Valor)
                    {
                        MessageBox.Show(string.Format("El Total de la Columna Debe: '{0:###,##0.00}' no coincide con Total del Valor de la Transaferencia: '{1:###,##0.00}'", TotalDebe, Valor), "Grabar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TotalHaber != Valor)
                    {
                        MessageBox.Show(string.Format("El Total de la Columna Haber: '{0:###,##0.00}' no coincide con Total del Valor de la Transaferencia: '{1:###,##0.00}'", TotalHaber, Valor), "Grabar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    TransaccionTMPEN oRegistroEN = InformacionDelRegistro();
                    TransaccionTMPLN oRegistroLN = new TransaccionTMPLN();

                    if (oRegistroLN.GrabarDatos(oRegistroEN, Program.oDatosDeConexion))
                    {

                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "Grabar Datos");

                        this.Cursor = Cursors.Default;

                        if (CerrarVentana == true)
                        {
                            this.Close();
                        }

                        oRegistroEN = null;
                        oRegistroLN = null;

                    }
                    else
                    {
                        throw new ArgumentException(oRegistroLN.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grabar registros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvLista_KeyDown(object sender, KeyEventArgs e)
        {

            if (dgvLista.CurrentCell.ColumnIndex >= 0 && dgvLista.CurrentCell.ColumnIndex < dgvLista.Columns.Count - 2 && dgvLista.CurrentCell.Visible == true)
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (dgvLista.CurrentRow.Cells[dgvLista.CurrentCell.ColumnIndex + 1].Visible == true)
                    {
                        e.SuppressKeyPress = true;                        
                        dgvLista.CurrentCell = dgvLista.CurrentRow.Cells[dgvLista.CurrentCell.ColumnIndex + 1];
                    }
                    else
                    {
                        if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name.ToUpper() == "ConceptoDeBanco".ToUpper())
                        {
                            dgvLista.CurrentCell = dgvLista.CurrentRow.Cells[1];
                        }
                        else if (dgvLista.Columns[dgvLista.CurrentCell.ColumnIndex].Name.ToUpper() == "Haber".ToUpper())
                        {
                            dgvLista.CurrentCell = dgvLista.CurrentRow.Cells[1];
                        }
                    }
                }
            }

        }
        
        private void dgvLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 ||  e.ColumnIndex == -1)
                return;

            if(dgvLista.Columns[e.ColumnIndex].Name.ToUpper() == "idCuenta".ToUpper())
            {
                BuscarInformacionDeLaCuenta();
            }
            
        }
    }
}
