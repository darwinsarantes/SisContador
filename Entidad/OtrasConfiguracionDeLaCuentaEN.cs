using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class OtrasConfiguracionDeLaCuentaEN
    {
        
        public int idOtrasConfiguracionDeLaCuenta { set; get; }
        public int idConfiguracion { set; get; }
        public int idTiposDeConfiguracion { set; get; }
        public string idCuenta { set; get; }
        public int NoCuenta { set; get; }
        public int NivelCuenta { set; get; }
        public string DescTipoDeCuenta { set; get; }
        
        public int IdUsuarioDeCreacion { set; get; }
        public DateTime FechaDeCreacion { set; get; }
        public int IdUsuarioDeModificacion { set; get; }
        public DateTime FechaDeModificacion { set; get; }

        public LoginEN oLoginEN = new LoginEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }

    }
}
