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
    public class ReportesLN
    {

        public string Error { set; get; }

        private ReportesAD oReportesAD = new ReportesAD();
        
        public bool TraerSaldoActualDeLaCuentaPorFecha(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.TraerSaldoActualDeLaCuentaPorFecha(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool TraerSaldoActualDelasCuentas(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.TraerSaldoActualDelasCuentas(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool TraerSaldoActualDelasCuentasFull(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.TraerSaldoActualDelasCuentasFull(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool TraerElEstadoDeResultadoPorRangoDeFecha(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.TraerElEstadoDeResultadoPorRangoDeFecha(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalcularBalanceGeneralDeManeraDetalla(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalcularBalanceGeneralDeManeraDetalla(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalcularBalanceGeneralParaELHistorico(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalcularBalanceGeneralParaELHistorico(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool TraerEstadoDeResultadoDelalMes(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.TraerEstadoDeResultadoDelalMes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CuentasDeResultadoAlMesCorrienteUsandoHistorico(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CuentasDeResultadoAlMesCorrienteUsandoHistorico(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool TraerElAuxiliarDelMayorSobreLaCuenta(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.TraerElAuxiliarDelMayorSobreLaCuenta(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool GenerarAuxiliarMayorDesdeElHistorico(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.GenerarAuxiliarMayorDesdeElHistorico(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalCularBalanzaDeComprobacion(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalCularBalanzaDeComprobacion(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalCularBalanzaDeComprobacionParaElHistorico(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalCularBalanzaDeComprobacionParaElHistorico(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalCularRecapitulaciones(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalCularRecapitulaciones(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalCularRecapitulacionesParaHistorico(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalCularRecapitulacionesParaHistorico(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalcularEstadoDeResultadoPorMes(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalcularEstadoDeResultadoPorMes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }
        }

        public bool CalcularEstadoDeResultadoPorMesEnDolares(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalcularEstadoDeResultadoPorMesEnDolares(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }
        }

        public bool CalcularBalanceGeneralPorMes(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalcularBalanceGeneralPorMes(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public bool CalcularBalanceGeneralPorMesEnDolares(ReportesEN oREgistroEN, DatosDeConexionEN oDatos)
        {

            if (oReportesAD.CalcularBalanceGeneralPorMesEnDolares(oREgistroEN, oDatos))
            {
                Error = string.Empty;
                return true;
            }
            else
            {
                Error = oReportesAD.Error;
                return false;
            }

        }

        public DataTable TraerDatos() {

            return oReportesAD.TraerDatos();

        }

        public int TotalRegistros()
        {

            return oReportesAD.TraerDatos().Rows.Count;

        }



    }
}
