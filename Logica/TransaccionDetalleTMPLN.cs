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
    public class TransaccionDetalleTMPLN
    {

        public string Error { set; get; }

        private TransaccionDetalleTMPAD oTransaccionDetalleAD = new TransaccionDetalleTMPAD();

        public bool Agregar(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionDetalleAD.Agregar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool Actualizar(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTransaccionDetalle.ToString()) || oREgistroEN.idTransaccionDetalle == 0) {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTransaccionDetalleAD.Actualizar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool Eliminar(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTransaccionDetalle.ToString()) || oREgistroEN.idTransaccionDetalle == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTransaccionDetalleAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool Listado(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionDetalleAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool ListadoPorIdentificadorDeLaTransaccion(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionDetalleAD.ListadoPorIdentificadorDeLaTransaccion(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool ListadoPorIdentificador(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionDetalleAD.ListadoPorIdentificador(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionDetalleAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionDetalleAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionDetalleAD.Error;
                return false;
            }

        }

        public bool ValidarRegistroDuplicado(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oTransaccionDetalleAD.ValidarRegistroDuplicado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oTransaccionDetalleAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool ValidarSiElRegistroEstaVinculado(TransaccionDetalleTMPEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oTransaccionDetalleAD.ValidarSiElRegistroEstaVinculado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oTransaccionDetalleAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public DataTable TraerDatos() {

            return oTransaccionDetalleAD.TraerDatos();

        }

        public int TotalRegistros() {
            return oTransaccionDetalleAD.TraerDatos().Rows.Count;
        }



    }
}
