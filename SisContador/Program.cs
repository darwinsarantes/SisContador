using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using SisContador.Formularios;

namespace SisContador
{
    static class Program
    {

        public static bool Iniciar = false;
        public static string NombreSistema = "Sistema de Cantibilidad";
        public static string NombreEmpresa = "Gasolinera shell <<Esquipullas>>";
        public static string EntidadIngSistemas = "Servicios TRIGERS";
        public static string VersionSistema = "1.0";
        public static string NombreVersionSistema = NombreSistema + " " + VersionSistema;
        public static DatosDeConexionEN oDatosDeConexion = null;
        public static LoginEN oLoginEN = null;
        public static ConfiguracionEN oConfiguracionEN = new ConfiguracionEN();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmSplash ofrmSplash = new frmSplash();
            ofrmSplash.ShowDialog();

            frmLogin oFrmLogin = new frmLogin();
            oFrmLogin.ShowDialog();

            if (Iniciar == true)
            {
                Application.Run(new Principal());
            }
        }
               
    }
}
