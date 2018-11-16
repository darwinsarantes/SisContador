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
    public class OtrasConfiguracionDeLaCuentaLN
    {

        public string Error { set; get; }

        private OtrasConfiguracionDeLaCuentaAD oOtrasConfiguracionDeLaCuentaAD = new OtrasConfiguracionDeLaCuentaAD();

        public bool Agregar(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.Agregar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool Actualizar(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idOtrasConfiguracionDeLaCuenta.ToString()) || oREgistroEN.idOtrasConfiguracionDeLaCuenta == 0) {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oOtrasConfiguracionDeLaCuentaAD.Actualizar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool Eliminar(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (string.IsNullOrEmpty(oREgistroEN.idOtrasConfiguracionDeLaCuenta.ToString()) || oREgistroEN.idOtrasConfiguracionDeLaCuenta == 0)
            {

                this.Error = @"Se debe de seleccionar un elemento de la lista";
                return false;
            }

            if (oOtrasConfiguracionDeLaCuentaAD.Eliminar(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool Listado(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.Listado(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool ListadoPorIdentificador(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.ListadoPorIdentificador(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool ListadoParaCombos(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.ListadoParaCombos(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool ListadoParaReportes(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.ListadoParaReportes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool ListadoDeCuentasAsociadasAConfiguracion(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.ListadoDeCuentasAsociadasAConfiguracion(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return false;
            }

        }

        public bool ValidarRegistroDuplicado(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.ValidarRegistroDuplicado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public bool ValidarSiElRegistroEstaVinculado(OtrasConfiguracionDeLaCuentaEN oREgistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {

            if (oOtrasConfiguracionDeLaCuentaAD.ValidarSiElRegistroEstaVinculado(oREgistroEN, oDatos, TipoDeOperacion))
            {
                Error = oOtrasConfiguracionDeLaCuentaAD.Error;
                return true;
            }
            else
            {
                Error = string.Empty;
                return false;
            }

        }

        public DataTable TraerDatos() {

            return oOtrasConfiguracionDeLaCuentaAD.TraerDatos();

        }

        public int TotalRegistros() {
            return oOtrasConfiguracionDeLaCuentaAD.TraerDatos().Rows.Count;
        }
                
    }
}
