using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class TansaccionDetalleTMPBancoEN
    {        /*idTransaccionDetalle, ReferenciaBanco*/
        public int idTansaccionDetalle_Banco { set; get; }
        public string ReferenciaBanco { set; get; }
        public string DescBanco { set; get; }
        public decimal Debe { set; get; }
        public decimal Haber { set; get; }

        public int IdUsuarioDeCreacion { set; get; }
        public DateTime FechaDeCreacion { set; get; }
        public int IdUsuarioDeModificacion { set; get; }
        public DateTime FechaDeModificacion { set; get; }

        public TransaccionDetalleTMPEN oTransaccionDetalleEN = new TransaccionDetalleTMPEN();
        public LoginEN oLoginEN = new LoginEN();
        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }

    }
}
