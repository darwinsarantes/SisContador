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
using System.Diagnostics;

namespace SisContador.Formularios
{
    public partial class Principal : Form
    {

        frmConfiguracion ofrmConfiguracion = null;
        frmRespaldo ofrmRespaldo = null;
        frmRestaurar ofrmRestaurar = null;
        frmEmpresa ofrmEmpresa = null;
        frmGruposDeCuentas ofrmGruposDeCuentas = null;
        frmCategoriaDeCuenta ofrmCategoriaDeCuenta = null;
        frmUsuario ofrmUsuario = null;
        frmCuenta ofrmCuenta = null;
        frmRol ofrmRol = null;
        frmTipoDeTransaccion ofrmTipoDeTransaccion = null;
        frmTransaccion oMovimientos = null;
        frmTransaccion oEgresos = null;
        frmTransaccion oIngresos = null;
        frmTransaccion oDiarios = null;
        frmPeriodo ofrmPeriodo = null;
        frmReportes ofrmReportes = null;
        frmReportesHistorico ofrmReportesHistorico = null;
        frmTasaDeCambio ofrmTasaDeCambio = null;
        frmGraficos ofrmGraficos = null;

        static string ETiempo = "";
        
        public Principal()
        {
            InitializeComponent();
        }

        private void tsmRespaldarBaseDeDatos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmRespaldo == null || ofrmRespaldo.IsDisposed)
            {
                ofrmRespaldo = new frmRespaldo();
                ofrmRespaldo.MdiParent = this;
                ofrmRespaldo.Show();
            }
            else
            {
                ofrmRespaldo.BringToFront();
                
            }

            this.Cursor = Cursors.Default;
        }

        private void tsmRestaurar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmRestaurar == null || ofrmRestaurar.IsDisposed)
            {
                ofrmRestaurar = new frmRestaurar();
                ofrmRestaurar.MdiParent = this;
                ofrmRestaurar.Show();
            }
            else
                ofrmRestaurar.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void configuraciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmConfiguracion == null || ofrmConfiguracion.IsDisposed)
            {
                ofrmConfiguracion = new frmConfiguracion();
                ofrmConfiguracion.MdiParent = this;
                ofrmConfiguracion.Show();
            }
            else
                ofrmConfiguracion.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void informaciónDeLaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmEmpresa == null || ofrmEmpresa.IsDisposed)
            {
                ofrmEmpresa = new frmEmpresa();
                ofrmEmpresa.MdiParent = this;
                ofrmEmpresa.Show();
            }
            else
                ofrmEmpresa.BringToFront();

            this.Cursor = Cursors.Default;

        }

        private void Principal_Shown(object sender, EventArgs e)
        {            
            tsbEtiqueta.Text = string.Format(" {0}", Program.oConfiguracionEN.NombreDelSistema);
            this.Text = string.Format("{0} | {1} | {2} | ip: {3}", Program.NombreVersionSistema, Program.oLoginEN.Usuario, Program.oLoginEN.TipoDeCuenta, Program.oLoginEN.NumeroIP);

            ConfigurarHoraYFecha();

            CargarPrivilegiosDelUsuario();

            tsMenu.Items["tsbGruposDeCuentas"].Select();          
               

        }

        private void tsbGruposDeCuentas_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmGruposDeCuentas == null || ofrmGruposDeCuentas.IsDisposed)
            {
                ofrmGruposDeCuentas = new frmGruposDeCuentas();
                ofrmGruposDeCuentas.MdiParent = this;
                ofrmGruposDeCuentas.Show();
                ofrmGruposDeCuentas.StartPosition = FormStartPosition.CenterScreen;
                ofrmGruposDeCuentas.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmGruposDeCuentas.BringToFront();

            this.Cursor = Cursors.Default;
        }

        #region "Funciones"

        private void CargarPrivilegiosDelUsuario()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                ModuloInterfazUsuariosEN oRegistroEN = new ModuloInterfazUsuariosEN();
                ModuloInterfazUsuariosLN oRegistroLN = new ModuloInterfazUsuariosLN();

                oRegistroEN.oUsuarioEN.idUsuario = Program.oLoginEN.idUsuario;

                if (oRegistroLN.ListadoPrivilegiosDelUsuariosPorModulo(oRegistroEN, Program.oDatosDeConexion))
                {

                    //PRIVILEGIOS A BARRA DE MENÚS
                    foreach (ToolStripMenuItem item in this.menuStrip.Items)
                    {
                        if (item.Tag != null)
                        {

                            if (item.Tag.ToString().Trim().Length > 0)
                            {

                                //item.Enabled = oRegistroLN.VerificarSiTengoAcceso(item.Tag.ToString());
                                if (item.DropDownItems.Count > 0)
                                {
                                    foreach (ToolStripItem Subitem in item.DropDownItems)
                                    {
                                        if (Subitem.GetType() == typeof(ToolStripMenuItem))
                                        {
                                            if (Subitem.Tag != null)
                                            {
                                                if (Subitem.Tag.ToString().Length > 0)
                                                {
                                                    Subitem.Enabled = oRegistroLN.VerificarSiTengoAccesoDeInterfaz(Subitem.Tag.ToString());
                                                }
                                            }
                                            else
                                            {
                                                Subitem.Enabled = false;
                                            }
                                        }
                                    }
                                }
                            }

                        }

                    }

                    foreach (ToolStripItem item in tsMenu.Items)
                    {
                        if (item.Tag != null)
                        {
                            if (item.GetType() == typeof(ToolStripButton))
                            {
                                item.Enabled = oRegistroLN.VerificarSiTengoAccesoDeInterfaz(item.Tag.ToString());
                            }
                        }
                        else {
                            item.Enabled = false;
                        }
                    }


                }
                else
                {
                    throw new ArgumentException(oRegistroLN.Error);
                }


                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Verificacion de Privilegios del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally {
                this.Cursor = Cursors.Default;
            }

        }

        #endregion

        private void tsbCategoriaDeCuenta_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmCategoriaDeCuenta == null || ofrmCategoriaDeCuenta.IsDisposed)
            {
                ofrmCategoriaDeCuenta = new frmCategoriaDeCuenta();
                ofrmCategoriaDeCuenta.MdiParent = this;
                ofrmCategoriaDeCuenta.Show();
                ofrmCategoriaDeCuenta.StartPosition = FormStartPosition.CenterScreen;
                ofrmCategoriaDeCuenta.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmCategoriaDeCuenta.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmUsuario == null || ofrmUsuario.IsDisposed)
            {
                ofrmUsuario = new frmUsuario();
                ofrmUsuario.MdiParent = this;
                ofrmUsuario.Show();
                ofrmUsuario.StartPosition = FormStartPosition.CenterScreen;
                ofrmUsuario.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmUsuario.BringToFront();

            this.Cursor = Cursors.Default;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmCuenta == null || ofrmCuenta.IsDisposed)
            {
                ofrmCuenta = new frmCuenta();
                ofrmCuenta.MdiParent = this;
                ofrmCuenta.Show();
                ofrmCuenta.StartPosition = FormStartPosition.CenterScreen;
                ofrmCuenta.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmCuenta.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void tiposDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmRol == null || ofrmRol.IsDisposed)
            {
                ofrmRol = new frmRol();
                ofrmRol.MdiParent = this;
                ofrmRol.Show();
                ofrmRol.StartPosition = FormStartPosition.CenterScreen;
                ofrmRol.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmRol.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void tsbTipoDeTransaccion_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            if (ofrmTipoDeTransaccion == null || ofrmTipoDeTransaccion.IsDisposed)
            {
                ofrmTipoDeTransaccion = new frmTipoDeTransaccion();
                ofrmTipoDeTransaccion.MdiParent = this;
                ofrmTipoDeTransaccion.Show();
                ofrmTipoDeTransaccion.StartPosition = FormStartPosition.CenterScreen;
                ofrmTipoDeTransaccion.WindowState = FormWindowState.Maximized;

            }
            else
                ofrmTipoDeTransaccion.BringToFront();

            this.Cursor = Cursors.Default;

        }

        private void tsbMovimientos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (oMovimientos == null || oMovimientos.IsDisposed)
            {
                oMovimientos = new frmTransaccion();
                oMovimientos.MdiParent = this;
                oMovimientos.TituloVentana = "Movimientos movimientos";
                oMovimientos.Show();
                oMovimientos.StartPosition = FormStartPosition.CenterScreen;
                oMovimientos.WindowState = FormWindowState.Maximized;

            }
            else
                oMovimientos.BringToFront();

            this.Cursor = Cursors.Default;

        }

        private void tsbEgresos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (oEgresos == null || oEgresos.IsDisposed)
            {
                oEgresos = new frmTransaccion();
                oEgresos.MdiParent = this;
                oEgresos.TituloVentana = "Administrar los movimientos de egresos";
                oEgresos.IdTipoDeTransaccion = 1;
                oEgresos.Show();
                oEgresos.StartPosition = FormStartPosition.CenterScreen;
                oEgresos.WindowState = FormWindowState.Maximized;

            }
            else
            {
                oEgresos.BringToFront();
                oEgresos.Refresh();                
            }

            this.Cursor = Cursors.Default;
        }

        private void tsbIngresos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (oIngresos == null || oIngresos.IsDisposed)
            {
                oIngresos = new frmTransaccion();
                oIngresos.MdiParent = this;
                oIngresos.TituloVentana = "Administrar los movimientos de ingresos";
                oIngresos.IdTipoDeTransaccion = 2;
                oIngresos.Show();
                oIngresos.StartPosition = FormStartPosition.CenterScreen;
                oIngresos.WindowState = FormWindowState.Maximized;

            }
            else
                oIngresos.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void tsbDiarios_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (oDiarios == null || oDiarios.IsDisposed)
            {
                oDiarios = new frmTransaccion();
                oDiarios.MdiParent = this;
                oDiarios.TituloVentana = "Administrar los movimientos de diarios";
                oDiarios.IdTipoDeTransaccion = 3;
                oDiarios.Show();
                oDiarios.StartPosition = FormStartPosition.CenterScreen;
                oDiarios.WindowState = FormWindowState.Maximized;
            }
            else
                oDiarios.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void tsbPeriodo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmPeriodo == null || ofrmPeriodo.IsDisposed)
            {
                ofrmPeriodo = new frmPeriodo();
                ofrmPeriodo.MdiParent = this;
                ofrmPeriodo.Show();
                ofrmPeriodo.StartPosition = FormStartPosition.CenterScreen;
                ofrmPeriodo.WindowState = FormWindowState.Maximized;
            }
            else
                ofrmPeriodo.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            if (ofrmReportes == null || ofrmReportes.IsDisposed)
            {
                ofrmReportes = new frmReportes();
                ofrmReportes.MdiParent = this;
                ofrmReportes.Show();
                ofrmReportes.StartPosition = FormStartPosition.CenterScreen;
                ofrmReportes.WindowState = FormWindowState.Maximized;
            }
            else
                ofrmReportes.BringToFront();

            this.Cursor = Cursors.Default;

        }

        private void ConfigurarHoraYFecha()
        {
            timer1.Interval = 1000;
            timer1.Start();

            timer2.Interval = 300000;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ETiempo = DateTime.Now.ToString("G");
            //tsbHorayFecha.Text = string.Format("{0} {1}", DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString());
            tsbHorayFecha.Text = ETiempo;
        }

        private void AplicarColorAFormularios()
        {
            try
            {
                this.BackColor = Properties.Settings.Default.MyColorSetting;

                foreach (Form Items in Application.OpenForms.Cast<Form>())
                {
                    Items.BackColor = Properties.Settings.Default.MyColorSetting;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aplicar color a la ventanas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AplicarColorAFormularios(Color oColor)
        {
            try
            {
                this.BackColor = oColor;

               /* System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

                List<Form> formList = asm.GetTypes()
                                            .Where(x => x.IsSubclassOf(typeof(Form)))
                                            .Select(x => (Form)Activator.CreateInstance(x))
                                            .ToList();*/

                foreach (Form Items in Application.OpenForms.Cast<Form>())
                {                    
                    Items.BackColor = oColor;
                }

                Properties.Settings.Default.MyColorSetting = oColor;
                Properties.Settings.Default.Save();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aplicar color a la ventanas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void colorDeLaVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog CDColor = new ColorDialog();

                if (CDColor.ShowDialog() == DialogResult.OK)
                {
                    AplicarColorAFormularios(CDColor.Color);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aplicar color a la ventanas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void colorPorDefectoEnLaVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.BackColor = Properties.Settings.Default.DefaultColor;

                foreach (Form Items in Application.OpenForms.Cast<Form>())
                {
                    Items.BackColor = Properties.Settings.Default.DefaultColor;
                }

                this.BackColor = Properties.Settings.Default.DefaultColor;
                Properties.Settings.Default.MyColorSetting = Properties.Settings.Default.DefaultColor;
                Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aplicar color a la ventanas por defecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            if (ofrmReportesHistorico == null || ofrmReportesHistorico.IsDisposed)
            {
                ofrmReportesHistorico = new frmReportesHistorico();
                ofrmReportesHistorico.MdiParent = this;
                ofrmReportesHistorico.Show();
                ofrmReportesHistorico.StartPosition = FormStartPosition.CenterScreen;
                ofrmReportesHistorico.WindowState = FormWindowState.Maximized;
            }
            else
                ofrmReportesHistorico.BringToFront();

            this.Cursor = Cursors.Default;

        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                RespaldarBaseDeDatos();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Cerrando la ventana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        #region "Respaldo de la base de datos"

        private void RespaldarBaseDeDatos()
        {
            try
            {
                CarpetaDeRespaldo();

                //String NombreDelfichero = string.Format("{0}\\{1}_{2}.sql", Program.oConfiguracionEN.RutaRespaldos.Trim(), Program.oDatosDeConexion.BaseDeDatos.Trim().ToUpper(), System.DateTime.Now.ToString("yyyyMMdd_hms"));
                String NombreDelfichero = string.Format("{0}\\{1}_{2}.sql", Program.oConfiguracionEN.RutaRespaldos.Trim(), Program.oDatosDeConexion.BaseDeDatos.Trim().ToUpper(), System.DateTime.Now.ToString("yyyyMMdd"));

                ValidarSiExisteElFichero(NombreDelfichero);

                System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                cmd.StartInfo.FileName = "cmd.exe";//string.Format(@"{0}mysqldump", Program.oConfiguracionEN.PathMysSQLDump);
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine(@"c:");
                cmd.StandardInput.Flush();
                cmd.StandardInput.WriteLine(string.Format(@"cd {0}", Program.oConfiguracionEN.PathMysSQLDump.Trim()));
                cmd.StandardInput.Flush();
                cmd.StandardInput.WriteLine(string.Format("mysqldump -h{0} -P{1} -u{2} -p{3} --opt --routines --add-drop-database --databases {4} > {5}",
                    Program.oDatosDeConexion.Servidor, Program.oDatosDeConexion.PuertoDeConexionDelServidor, Program.oDatosDeConexion.Usuario, Program.oDatosDeConexion.Contraseña,
                    Program.oDatosDeConexion.BaseDeDatos, NombreDelfichero));
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.Close();
                cmd = null;

                tsbEtiquetaDeRespaldo.Text = "Respaldo Realizado correctamente";
                
            }
            catch (Exception ex)
            {
                string mensaje = string.Format("Se ha produccido un error al realizar la copia de seguridad: {0} {1}", Environment.NewLine, ex.Message);
                MessageBox.Show(mensaje, "Respaldo de base datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarpetaDeRespaldo()
        {
            try
            {
                if (!System.IO.Directory.Exists(Program.oConfiguracionEN.RutaRespaldos.Trim()))
                {
                    System.IO.Directory.CreateDirectory(Program.oConfiguracionEN.RutaRespaldos.Trim());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caperta de respaldo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ValidarSiExisteElFichero(string Archivo)
        {
            try
            {
                if (System.IO.File.Exists(Archivo))
                {
                    System.IO.File.Delete(Archivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validar si existe el FicheroDeRespaldo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            tsbEtiquetaDeRespaldo.Visible = true;
            RespaldarBaseDeDatos();            
            timer3.Interval = (( Program.oConfiguracionEN.TiempoDeRespaldo * 60) * 1000);
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tsbEtiquetaDeRespaldo.Visible = false;
        }

        private void tsbTasaDeCambio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmTasaDeCambio == null || ofrmTasaDeCambio.IsDisposed)
            {
                ofrmTasaDeCambio = new frmTasaDeCambio();
                ofrmTasaDeCambio.MdiParent = this;
                ofrmTasaDeCambio.Show();
                ofrmTasaDeCambio.StartPosition = FormStartPosition.CenterScreen;
                ofrmTasaDeCambio.WindowState = FormWindowState.Maximized;
            }
            else
                ofrmTasaDeCambio.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void graficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ofrmGraficos == null || ofrmGraficos.IsDisposed)
            {
                ofrmGraficos = new frmGraficos();
                ofrmGraficos.MdiParent = this;
                ofrmGraficos.Show();
                ofrmGraficos.StartPosition = FormStartPosition.CenterScreen;
                ofrmGraficos.WindowState = FormWindowState.Maximized;
            }
            else
                ofrmGraficos.BringToFront();

            this.Cursor = Cursors.Default;
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
