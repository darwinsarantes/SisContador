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
    public partial class frmPeriodoOperacion : Form
    {
        public frmPeriodoOperacion()
        {
            InitializeComponent();
        }

        public string OperacionARealizar { set; get; }
        public string NOMBRE_ENTIDAD_PRIVILEGIO { set; get; }
        public string NombreEntidad { set; get; }
        public int ValorLlavePrimariaEntidad { set; get; }

        private bool CerrarVentana = false;

        private void frmPeriodoOperacion_Shown(object sender, EventArgs e)
        {
            HabilitarOpcionesDeComboSegunCorresponda();
            ObtenerValoresDeConfiguracion();
            LlamarMetodoSegunOperacion();
            EstablecerTituloDeVentana();
            DeshabilitarControlesSegunOperacionesARealizar();
                        
        }

        #region "Funciones"

        private void EvaluarSiExistenTransacciones()
        {

            try
            {

                PeriodoLN oRegistroLN = new PeriodoLN();

                if (oRegistroLN.EvaluarSiHayRegistrosEnTransacciones(Program.oDatosDeConexion) == false)
                {
                    MessageBox.Show("No se encontraron movimientos de cuentas a afectar", "Evaluar si existen movimientos de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Evaluar si Existen transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void TraerFechaParaElInicioDelPeriodo()
        {
            PeriodoLN oPeriodoLN = new PeriodoLN();

            try
            {
                if (oPeriodoLN.ListarFechaInicialDelPeriodo(Program.oDatosDeConexion))
                {
                    if (oPeriodoLN.TraerDatos().Rows.Count > 0)
                    {
                        DataRow Fila = oPeriodoLN.TraerDatos().Rows[0];
                        dtpDesde.Value = Convert.ToDateTime(Fila["Res"].ToString());

                        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

                        txtNombre.Text = string.Format("Periodo de Cierre al Mes de: '{0}'", mfi.GetMonthName(dtpDesde.Value.Month));
                        txtObservacion.Text = string.Format("Periodo de Cierre al Mes de: '{0}', con rago de fecha: '{1}' -{2}", mfi.GetMonthName(dtpDesde.Value.Month), dtpDesde.Value.ToLongDateString(), dtpHasta.Value.ToLongDateString());

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información de la fecha de inicio del periodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                oPeriodoLN = null;
            }

        }

        private void EvaluarCuantosMovimientosCeranAfectadosporElCierre()
        {
            PeriodoEN oPeriodoEN = new PeriodoEN();
            PeriodoLN oPeriodoLN = new PeriodoLN();

            try
            {

                oPeriodoEN.Desde = dtpDesde.Value;
                oPeriodoEN.Hasta = dtpHasta.Value;

                if (oPeriodoLN.EvaluarCuantosMovimientosCeranAfectadosPorElCierreDePeriodo(oPeriodoEN, Program.oDatosDeConexion))
                {
                    if (oPeriodoLN.TraerDatos().Rows.Count > 0)
                    {
                        lbContar.Text = string.Format("Número ({0}) de registros incluidos en el periodo: '{1}' en el Rago de Fechas: {2} - {3} ", oPeriodoLN.TraerDatos().Rows[0]["TotalDeRegistros"].ToString(), txtNombre.Text, dtpDesde.Value.ToLongDateString(), dtpHasta.Value.ToLongDateString());
                    }
                }
                else
                {
                    lbContar.Text = string.Format("Número ({0}) de registros incluidos en el periodo: '{1}' en el Rago de Fechas: {2} - {3} ", 0, txtNombre.Text, dtpDesde.Value.ToLongDateString(), dtpHasta.Value.ToLongDateString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, string.Format("Evaluar cuantos movimientos de cuentas se van afectar con el '{0}' ", cmbEstado.Text), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                oPeriodoLN = null;
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

                    case "CERRAR":
                        cadena = "Registro Cerrado Correctamente pero con errores: ";
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
            chkCerrarVentana.CheckState = (Properties.Settings.Default.PeriodoVentanaDespuesDeOperacion == true ? CheckState.Checked : CheckState.Unchecked);
            this.CerrarVentana = (Properties.Settings.Default.PeriodoVentanaDespuesDeOperacion == true ? true : false);
        }

        private void HabilitarOpcionesDeComboSegunCorresponda()
        {
            switch (this.OperacionARealizar.ToUpper())
            {
                case "NUEVO":

                    /*ABIERTO REVISIÓN CERRADO*/
                    cmbEstado.Items.Clear();
                    cmbEstado.Items.Add("ABIERTO");
                    //cmbEstado.Items.Add("REVISIÓN");
                    cmbEstado.SelectedIndex = 0;

                    break;

                case "MODIFICAR":

                    /*ABIERTO REVISIÓN CERRADO*/
                    cmbEstado.Items.Clear();
                    cmbEstado.Items.Add("ABIERTO");
                    //cmbEstado.Items.Add("REVISIÓN");

                    break;

                case "ELIMINAR":
                case "CONSULTAR":

                    /*ABIERTO REVISIÓN CERRADO*/
                    cmbEstado.Items.Clear();
                    cmbEstado.Items.Add("ABIERTO");
                   // cmbEstado.Items.Add("REVISIÓN");
                    cmbEstado.Items.Add("CERRADO");

                    break;

                case "NUEVO A PARTIR DE REGISTRO SELECCIONADO":

                    /*ABIERTO REVISIÓN CERRADO*/
                    cmbEstado.Items.Clear();
                    cmbEstado.Items.Add("ABIERTO");
                    //cmbEstado.Items.Add("REVISIÓN");
                    cmbEstado.SelectedIndex = 0;

                    break;

                case "CERRAR":


                    /*ABIERTO REVISIÓN CERRADO*/
                    cmbEstado.Items.Clear();
                    cmbEstado.Items.Add("CERRADO");
                    cmbEstado.SelectedIndex = 0;

                    break;

                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
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

                case "CERRAR":
                    Cerrar();
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
                    txtCodigo.Text = string.Empty;

                    tsbAplicarCierre.Visible = false;
                    cmbEstado.Text = "ABIERTO";
                    tabControl1.TabPages.Remove(tabControl1.TabPages[tabControl1.TabPages.Count - 1]);

                    tsbAplicarCierre.Visible = false;

                    break;

                case "MODIFICAR":
                    tsbGuardar.Enabled = false;
                    tsbLimpiarCampos.Enabled = true;
                    tsbActualizar.Enabled = true;
                    tsbEliminar.Enabled = false;
                    tsbRecarRegistro.Enabled = true;

                    txtIdentificador.ReadOnly = true;

                    if (tabControl1.TabPages.Count == 2)
                    {
                        tabControl1.TabPages.Remove(tabControl1.TabPages[tabControl1.TabPages.Count - 1]);
                    }

                    tsbAplicarCierre.Visible = false;

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

                    txtCodigo.ReadOnly = true;

                    if (tabControl1.TabPages.Count == 2)
                    {
                        tabControl1.TabPages.Remove(tabControl1.TabPages[tabControl1.TabPages.Count - 1]);
                    }

                    tsbAplicarCierre.Visible = false;

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
                    txtCodigo.ReadOnly = true;
                   

                    break;

                case "CERRAR":

                    tsbGuardar.Visible = false;
                    tsbActualizar.Visible = false;
                    tsbEliminar.Visible = false;
                    tsbLimpiarCampos.Visible = false;

                    tsbRecarRegistro.Visible = false;
                    txtIdentificador.ReadOnly = true;

                    txtCodigo.ReadOnly = true;
                    txtObservacion.ReadOnly = true;
                    txtNombre.ReadOnly = true;

                    cmbEstado.Text = "CERRADO";
                    cmbEstado.Enabled = false;
                    dtpDesde.Enabled = false;
                    dtpHasta.Enabled = false;

                    chkCerrarVentana.CheckState = CheckState.Checked;
                    chkCerrarVentana.Enabled = false;
                    
                    gbCerrarPeriodo.Visible = true;
                    
                    tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    tsbAplicarCierre.Visible = true;

                    break;

                default:
                    MessageBox.Show("La operación solicitada no está disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

            }
        }

        private void Nuevo()
        {
            EvaluarSiExistenTransacciones();
            TraerFechaParaElInicioDelPeriodo();
        }

        private void Modificar()
        {
            txtIdentificador.Text = ValorLlavePrimariaEntidad.ToString();
            LlenarCamposDesdeBaseDatosSegunID();
        }

        private void Cerrar()
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

            PeriodoEN oRegistrosEN = new PeriodoEN();
            PeriodoLN oRegistrosLN = new PeriodoLN();

            oRegistrosEN.idPeriodo = ValorLlavePrimariaEntidad;

            if (oRegistrosLN.ListadoPorIdentificador(oRegistrosEN, Program.oDatosDeConexion))
            {
                if (oRegistrosLN.TraerDatos().Rows.Count > 0)
                {
                    //idPeriodo, Codigo, Desde, Hasta, Nombre, Obsevaciones, Estado, 
                    DataRow Fila = oRegistrosLN.TraerDatos().Rows[0];
                    txtCodigo.Text = Fila["Codigo"].ToString();
                    txtNombre.Text = Fila["Nombre"].ToString();
                    txtObservacion.Text = Fila["Obsevaciones"].ToString();
                    cmbEstado.Text = Fila["Estado"].ToString();
                    dtpDesde.Value = Convert.ToDateTime(Fila["Desde"].ToString());
                    dtpHasta.Value = Convert.ToDateTime(Fila["Hasta"].ToString());

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
            txtCodigo.Text = string.Empty;            
           
        }

        private void GuardarValoresDeConfiguracion()
        {
            Properties.Settings.Default.PeriodoVentanaDespuesDeOperacion = (chkCerrarVentana.CheckState == CheckState.Checked ? true : false);
            Properties.Settings.Default.Save();
        }

        private void LimpiarEP()
        {
            EP.Clear();
        }

        private bool LosDatosIngresadosSonCorrectos()
        {
            LimpiarEP();

            if (txtNombre.Text.Length == 0 || string.IsNullOrEmpty(txtNombre.Text))
            {
                EP.SetError(txtNombre, "Este campo no puede estar vacío.");
                txtNombre.Focus();
                return false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                EP.SetError(cmbEstado, "Se debe de seleccionar un valor");
                cmbEstado.Focus();
                return false;
            }


            DateTime Fecha1 = dtpDesde.Value;
            DateTime Fecha2 = dtpHasta.Value;

            if (Fecha1 > Fecha2)
            {
                EP.SetError(dtpHasta, "La fecha inicial del periodo no puede ser mayor que la final");
                dtpHasta.Focus();
                return false;
            }

            if (Fecha2 < Fecha1)
            {
                EP.SetError(dtpDesde, "La fecha de fin de periodo no puede ser menor que la inicial");
                dtpDesde.Focus();
                return false;
            }

            if (cmbEstado.Text.Trim().ToUpper() == "CERRADO".ToUpper())
            {
                DateTime FechaCierre = dtpFechaDeCierre.Value;

                if (FechaCierre < Fecha2)
                {
                    EP.SetError(dtpFechaDeCierre, "La fecha de del cierre del perio no pude ser menos que la fecha de finalización del Periodo");
                    dtpFechaDeCierre.Focus();
                    return false;
                }

                if (txtDescripcion.Text.Length == 0 || string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    EP.SetError(txtDescripcion, "Este campo no puede estar vacío.");
                    txtDescripcion.Focus();
                    return false;
                }

                tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;

            }


            return true;

        }

        private PeriodoEN InformacionDelRegistro() {

            PeriodoEN oRegistroEN = new PeriodoEN();

            oRegistroEN.idPeriodo = Convert.ToInt32((txtIdentificador.Text.Length > 0 ? txtIdentificador.Text : "0"));
            oRegistroEN.Codigo = txtCodigo.Text.Trim();
            oRegistroEN.Desde = dtpDesde.Value;
            oRegistroEN.Hasta = dtpHasta.Value;
            oRegistroEN.Obsevaciones = txtObservacion.Text.Trim();
            oRegistroEN.Estado = cmbEstado.Text;
            oRegistroEN.Nombre = txtNombre.Text.Trim();

            //partes generales.            
            oRegistroEN.oLoginEN = Program.oLoginEN;
            oRegistroEN.IdUsuarioDeCreacion = Program.oLoginEN.idUsuario;
            oRegistroEN.IdUsuarioDeModificacion = Program.oLoginEN.idUsuario;
            oRegistroEN.FechaDeCreacion = System.DateTime.Now;
            oRegistroEN.FechaDeModificacion = System.DateTime.Now;

            return oRegistroEN;

        }

        private CierreDePeriodoEN InformacionSobreELCierreDePeriodo()
        {

            CierreDePeriodoEN oRegistroEN = new CierreDePeriodoEN();
            oRegistroEN.Descripcion = txtDescripcion.Text.Trim();
            oRegistroEN.FechaDeCierre = dtpFechaDeCierre.Value;
            oRegistroEN.oPeriodoEN = InformacionDelRegistro();
            oRegistroEN.oUsuarioDeCierre.idUsuario = Program.oLoginEN.idUsuario;
            oRegistroEN.oUsuarioDeCierre.Nombre = Program.oLoginEN.Usuario;

            //partes generales.            
            oRegistroEN.oLoginEN = Program.oLoginEN;
            oRegistroEN.IdUsuarioDeCreacion = Program.oLoginEN.idUsuario;
            oRegistroEN.IdUsuarioDeModificacion = Program.oLoginEN.idUsuario;
            oRegistroEN.FechaDeCreacion = System.DateTime.Now;
            oRegistroEN.FechaDeModificacion = System.DateTime.Now;


            return oRegistroEN;
            
        }

        private void AplicarCierreDelPeriodo()
        {
            try
            {

                if (LosDatosIngresadosSonCorrectos())
                {

                    LimpiarEP();
                    if (string.IsNullOrEmpty(txtDescripcion.Text) || txtDescripcion.Text.Trim().Length == 0)
                    {
                        EP.SetError(txtDescripcion, "El valor del campo no puede quedar vacío");
                        txtDescripcion.Focus();
                        return;
                    }

                    CierreDePeriodoEN oRegistroEN = InformacionSobreELCierreDePeriodo();
                    CierreDePeriodoLN oRegistroLN = new CierreDePeriodoLN();

                    if(oRegistroLN.AgregarUtilizandoLaMismaConexion(oRegistroEN, Program.oDatosDeConexion))
                    {
                        EvaluarErrorParaMensajeAPantalla(oRegistroLN.Error, "CERRAR");

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aplicar cierre de periodo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void frmPeriodoOperacion_FormClosing(object sender, FormClosingEventArgs e)
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

                    PeriodoEN oRegistroEN = InformacionDelRegistro();
                    PeriodoLN oRegistroLN = new PeriodoLN();

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexion, "AGREGAR"))
                    {

                        MessageBox.Show(oRegistroLN.Error, "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Agregar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idPeriodo.ToString();
                        txtCodigo.Text = oRegistroEN.Codigo;
                        ValorLlavePrimariaEntidad = oRegistroEN.idPeriodo;

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

                    PeriodoEN oRegistroEN = InformacionDelRegistro();
                    PeriodoLN oRegistroLN = new PeriodoLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oRegistroLN.ValidarRegistroDuplicado(oRegistroEN, Program.oDatosDeConexion, "ACTUALIZAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, "Actualizar la información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                    if (oRegistroLN.Actualizar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idPeriodo.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.idPeriodo;

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

                    PeriodoEN oRegistroEN = InformacionDelRegistro();
                    PeriodoLN oRegistroLN = new PeriodoLN();

                    if (oRegistroLN.ValidarSiElRegistroEstaVinculado(oRegistroEN, Program.oDatosDeConexion, "ELIMINAR"))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(oRegistroLN.Error, this.OperacionARealizar, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oRegistroLN.Eliminar(oRegistroEN, Program.oDatosDeConexion))
                    {

                        txtIdentificador.Text = oRegistroEN.idPeriodo.ToString();
                        ValorLlavePrimariaEntidad = oRegistroEN.idPeriodo;

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

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            EvaluarCuantosMovimientosCeranAfectadosporElCierre();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            EvaluarCuantosMovimientosCeranAfectadosporElCierre();
        }

        private void tsbAplicarCierre_Click(object sender, EventArgs e)
        {
            string mensaje = @"¿Está seguro que desea continuar con el cierre del Período seleccionado. Esta acción no podrá revertirse y todos los Movimientos de las Cuentas cuya fecha de registro esté dentro del rango del período quedarán bloqueados para modificación o eliminación?";

            if (MessageBox.Show(mensaje, "Confirmación del Cierre de Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                AplicarCierreDelPeriodo();
            }

        }
    }
}
