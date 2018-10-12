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
    public class TransaccionTMPLN
    {

        public string Error { set; get; }

        private TransaccionTMPAD oTransaccionAD = new TransaccionTMPAD();

        public bool Agregar(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.Agregar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool Actualizar(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTransacciones.ToString()) || oREgistroEN.idTransacciones == 0) {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTransaccionAD.Actualizar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool GrabarDatos(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTransacciones.ToString()) || oREgistroEN.idTransacciones == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTransaccionAD.GrabarDatos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool CargarRegistro(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTransacciones.ToString()) || oREgistroEN.idTransacciones == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTransaccionAD.CargarRegistro(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool Eliminar(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idTransacciones.ToString()) || oREgistroEN.idTransacciones == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oTransaccionAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool Listado(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool ListadoDeMovimientoAlCierreDePeriodo(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.ListadoDeMovimientoAlCierreDePeriodo(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool ListadoPorIdentificador(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.ListadoPorIdentificador(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportesParaMostrarELHistorico(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.ListadoParaReportesParaMostrarELHistorico(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oTransaccionAD.Error;
                return false;
            }

        }

        public bool EvaluarSiHayDatosEnLaTablaTMP(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.EvaluarSiHayDatosEnLaTablaTMP(oREgistroEN, oDatos))
            {
                Error = oTransaccionAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool TraerNumeroDeLaTransaccion(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oTransaccionAD.TraerNumeroDeLaTransaccion(oREgistroEN, oDatos))
            {
                Error = oTransaccionAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool EvaluarSiHayDatosEnLaTablaTMP(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos, DateTime Fecha1, DateTime Fecha2)
        {

            if (oTransaccionAD.EvaluarSiHayDatosEnLaTablaTMP(oREgistroEN, oDatos, Fecha1, Fecha2))
            {
                Error = oTransaccionAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool ValidarRegistroDuplicadoDeLaTransaccion(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oTransaccionAD.ValidarRegistroDuplicadoDeLaTransaccion(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oTransaccionAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool ValidarSiElRegistroEstaVinculado(TransaccionTMPEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oTransaccionAD.ValidarSiElRegistroEstaVinculado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oTransaccionAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public DataTable TraerDatos() {

            return oTransaccionAD.TraerDatos();

        }

        public int TotalRegistros() {
            return oTransaccionAD.TraerDatos().Rows.Count;
        }
        
    }
}
