using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisContador.Formularios
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        int Segundos = 10;
        bool Iniciado = true;

        private void frmSplash_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                this.Close();
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            VerificarVersion();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Segundos == 0)
            {
                this.Close();
            }
            else
            {
                Segundos = Segundos - 1;
                lbaTiempoRestante.Text = "Enter para omitir ( " + Segundos.ToString() + " )";
            }
        }

        private void VerificarVersion()
        {

            string Version = "";
            Version = Application.ProductVersion;
            if (Version.Trim().Length > 0)
            {
                lbaVersion.Text = Version;
            }
            else
                lbaVersion.Text = "" + Program.VersionSistema;

        }

        private void lbaTiempoRestante_MouseMove(object sender, MouseEventArgs e)
        {
            if (Iniciado == true)
            {
                timer1.Stop();
                Iniciado = false;
            }
        }

        private void frmSplash_MouseMove(object sender, MouseEventArgs e)
        {
            if (Iniciado == false)
            {
                timer1.Start();
                Iniciado = true;
            }
        }

        private void frmSplash_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
