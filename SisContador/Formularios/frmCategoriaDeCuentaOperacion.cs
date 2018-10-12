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
    public partial class frmCategoriaDeCuentaOperacion : Form
    {
        public frmCategoriaDeCuentaOperacion()
        {
            InitializeComponent();
        }

        public string OperacionARealizar { set; get; }
        public string NOMBRE_ENTIDAD_PRIVILEGIO { set; get; }
        public string NombreEntidad { set; get; }
        public int ValorLlavePrimariaEntidad { set; get; }

        private bool CerrarVentana = false;

        private bool AplicarCambio = false;
        private bool PermitirModificarRegistrosVinculados = false;

        private void frmCategoriaDeCuentaOperacion_Shown(object sender, EventArgs e)
        {
            ObtenerValoresDeConfiguracion();
            LLenarGrupoDeCuentas();
            LlamarMetodoSegunOperacion();
            EstablecerTituloDeVentana();
            DeshabilitarControlesSegunOperacionesARealizar();

            CargarPrivilegiosDelUsuario();
            ConfiguracionDePantalla();
            
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
            chkCerrarVentana.CheckState = (Properties.Settings.Default.CategoriaDeCuentaVentanaDespuesDeOperacion == true ? CheckState.Checked : CheckState.Unchecked);
            this.CerrarVentana = (Properties.Settings.Default.CategoriaDeCuentaVentanaDespuesDeOperacion == true ? true : false);
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
                    txtDescCategoriaDeCuenta.Text = string.Empty;                    
                    cmbGrupoDeCuenta.SelectedIndex = -1;                    
                    

                    break;

                case "MODIFICAR":
                    tsbGuardar.Enabled = false;
                    tsbLimpiarCampos.Enabled = true;
                    tsbActualizar.Enabled = true;
                    tsbEliminar.Enabled = false;
                    tsbRecarRegistro.Enabled = true;

                    txtIdentificador.ReadOnly = true;
                    tsbAutorizarModificación.Enabled = true;
                    
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

                    txtDescCategoriaDeCuenta.ReadOnly = true;                    
                    cmbGrupoDeCuenta.Enabled = false;

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
                    txtDescCategoriaDeCuenta.ReadOnly = true;
                    
                    cmbGrupoDeCuenta.Enabled = false;

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

            CategoriaDeCuentaEN oRegistrosEN = new CategoriaDeCuentaEN();
            CategoriaDeCuentaLN oRegistrosLN = new CategoriaDeCuentaLN();

            oRegistrosEN.idCategoriaDeCuenta = ValorLlavePrimariaEntidad;

            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexion))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {
                    /*idCategoriaDeCuenta,cc.idGrupoDeCuentas, DescCategoriaDeCuenta, gc.DescGrupoDeCuentas, 
                cc.IdUsuarioDeCreacion, cc.FechaDeCreacion, cc.IdUsuarioDeModificacion, cc.FechaDeModificacion */

                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtDescCategoriaDeCuenta.Text = Fila["DescCategoriaDeCuenta"].ToString();                    
                    cmbGrupoDeCuenta.SelectedValue = Convert.ToInt32( Fila["idGrupoDeCuentas"].ToString());
                    
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
            this.Text = "Administración de " + this.NombreEntidad + " - " + this.OperacionARealizar.ToUpper();
            this.InformacionEntidadOperacion.Text = this.NombreEntidad + " - " + this.OperacionARealizar;
        }

        private void LimpiarCampos()
        {
            //txtId.Text = string.Empty;
            txtDescCategoriaDeCuenta.Text = string.Empty;           
            cmbGrupoDeCuenta.SelectedIndex = -1;
           
        }

        private void GuardarValoresDeConfiguracion()
        {
            Properties.Settings.Default.CategoriaDeCuentaVentanaDespuesDeOperacion = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
            Properties.Settings.Default.Save();
        }

        private void LimpiarEP()
        {
            EP.Clear();
        }

        private bool LosDatosIngresadosSonCorrectos()
        {
            LimpiarEP();

            if (Controles.IsNullOEmptyElControl(txtDescCategoriaDeCuenta))
            {
                EP.SetError(txtDescCategoriaDeCuenta, "Este campo no puede quedar vacío");
                txtDescCategoriaDeCuenta.Focus();
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

        private CategoriaDeCuentaEN InformacionDelRegistro() {

            CategoriaDeCuentaEN oRegistroEN = new CategoriaDeCuentaEN();

            oRegistroEN.idCategoriaDeCuenta = Convert.ToInt32((txtIdentificador.Text.Length > 0 ? txtIdentificador.Text : "0"));
            oRegistroEN.DescCategoriaDeCuenta = txtDescCategoriaDeCuenta.Text.Trim();
            oRegistroEN.oGrupoDeCuentasEN.idGrupoDeCuentas = Convert.ToInt32(cmbGrupoDeCuenta.SelectedValue);
            oRegistroEN.oGrupoDeCuentasEN.DescGrupoDeCuentas = cmbGrupoDeCuenta.Text.Trim();

            //partes generales.            
            oRegistroEN.oLoginEN = Program.oLoginEN;
            oRegistroEN.IdUsuarioDeCreacion = Program.oLoginEN.idUsuario;
            oRegistroEN.IdUsuarioDeModificacion = Program.oLoginEN.idUsuario;
            oRegistroEN.FechaDeCreacion = System.DateTime.Now;
            oRegistroEN.FechaDeModificacion = System.DateTime.Now;

            return oRegistroEN;

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

        private void frmCategoriaDeCuentaOperacion_FormClosing(object sender, FormClosingEventArgs e)
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

                    CategoriaDeCuentaEN oRegistroEN = InformacionDelRegistro();
                    CategoriaDeCuentaLN oRegistroLN = new CategoriaDeCuentaLN();

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexion, "AGREGAR"))
                    {

                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Agregar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idCategoriaDeCuenta.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.idCategoriaDeCuenta;

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

                    CategoriaDeCuentaEN oRegistroEN = InformacionDelRegistro();
                    CategoriaDeCuentaLN oRegistroLN = new CategoriaDeCuentaLN();

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

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idCategoriaDeCuenta.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.idCategoriaDeCuenta;

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

                    CategoriaDeCuentaEN oRegistroEN = InformacionDelRegistro();
                    CategoriaDeCuentaLN oRegistroLN = new CategoriaDeCuentaLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexion, "ELIMINAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oRegistroLN.Eliminar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idCategoriaDeCuenta.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.idCategoriaDeCuenta;

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

        private void tsbImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
