using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using AccesoDatos;
using System.Data;

namespace Logica
{
    public class TansaccionDetalle_BancoLN
    {

        public string Error { set; get; }

        private TansaccionDetalleTMPBancoAD oTansaccionDetalle_BancoAD = new TansaccionDetalleTMPBancoAD();

        public bool Agregar(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTansaccionDetalle_BancoAD.Agregar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool Actualizar(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTansaccionDetalle_Banco.ToString()) || oREgistroEN.idTansaccionDetalle_Banco == 0) {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTansaccionDetalle_BancoAD.Actualizar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool Eliminar(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTansaccionDetalle_Banco.ToString()) || oREgistroEN.idTansaccionDetalle_Banco == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTansaccionDetalle_BancoAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool Listado(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTansaccionDetalle_BancoAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool ListadoPorIdentificador(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTansaccionDetalle_BancoAD.ListadoPorIdentificador(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTansaccionDetalle_BancoAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTansaccionDetalle_BancoAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportesDesdeElHistorico(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTansaccionDetalle_BancoAD.ListadoParaReportesDesdeElHistorico(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return false;
            }

        }

        public bool ValidarRegistroDuplicado(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oTansaccionDetalle_BancoAD.ValidarRegistroDuplicado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool ValidarSiElRegistroEstaVinculado(TansaccionDetalleTMPBancoEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oTansaccionDetalle_BancoAD.ValidarSiElRegistroEstaVinculado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oTansaccionDetalle_BancoAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public DataTable TraerDatos() {

            return oTansaccionDetalle_BancoAD.TraerDatos();

        }

        public int TotalRegistros() {
            return oTansaccionDetalle_BancoAD.TraerDatos().Rows.Count;
        }



    }
}
