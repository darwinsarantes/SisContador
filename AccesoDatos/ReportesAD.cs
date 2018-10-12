using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Entidad;
namespace AccesoDatos
{
    public class ReportesAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        //private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        //string DescripcionDeOperacion;
        private DataTable DT { set; get; }
        
        #region "Funciones para datos dll"
        
        public bool TraerSaldoActualDeLaCuentaPorFecha(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;                
                Comando.CommandText = "TrearSaldoActualDelaCuentaPorFecha";
                
                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();
                Comando.Parameters.Add(new MySqlParameter("@FechaIncial", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@FechaFinal", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
                
                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;              

            }

        }

        public bool TraerSaldoActualDelasCuentas(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "TraerElSaldoActual";
                
                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();
                Comando.Parameters.Add(new MySqlParameter("@SOrder", MySqlDbType.VarChar, oRegistroEN.OrderBy.Trim().Length)).Value = oRegistroEN.OrderBy.Trim();
                
                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool TraerSaldoActualDelasCuentasFull(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "TraerElSaldoActual_V1";

                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();
                Comando.Parameters.Add(new MySqlParameter("@SOrder", MySqlDbType.VarChar, oRegistroEN.OrderBy.Trim().Length)).Value = oRegistroEN.OrderBy.Trim();

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool TraerElEstadoDeResultadoPorRangoDeFecha(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "TraerElEstadoDeResultadoPorRangoDeFecha";

                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();
                Comando.Parameters.Add(new MySqlParameter("@SOrder", MySqlDbType.VarChar, oRegistroEN.OrderBy.Trim().Length)).Value = oRegistroEN.OrderBy.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalcularBalanceGeneralDeManeraDetalla(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalcularBalanceGeneral";

                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();
                Comando.Parameters.Add(new MySqlParameter("@SOrder", MySqlDbType.VarChar, oRegistroEN.OrderBy.Trim().Length)).Value = oRegistroEN.OrderBy.Trim();

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalcularBalanceGeneralParaELHistorico(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalcularBalanceGeneralParaELHistorico";
                
                Comando.Parameters.Add(new MySqlParameter("@SOrder", MySqlDbType.VarChar, oRegistroEN.OrderBy.Trim().Length)).Value = oRegistroEN.OrderBy.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool TraerEstadoDeResultadoDelalMes(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CuentasDeResultadoAlMesCorriente";

                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();                

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CuentasDeResultadoAlMesCorrienteUsandoHistorico(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CuentasDeResultadoAlMesCorrienteUsandoHistorico";

                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalCularBalanzaDeComprobacion(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalCularBalanzaDeComprobacion";

                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalCularBalanzaDeComprobacionParaElHistorico(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalCularBalanzaDeComprobacionParaElHistorico";
                
                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalCularRecapitulaciones(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalCularRecapitulaciones";

                Comando.Parameters.Add(new MySqlParameter("@SWhere", MySqlDbType.VarChar, oRegistroEN.Where.Trim().Length)).Value = oRegistroEN.Where.Trim();

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalCularRecapitulacionesParaHistorico(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalCularRecapitulacionesParaHistorico";

                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalcularEstadoDeResultadoPorMes(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalcularEstadoDeResultadoPorMes";

                Comando.Parameters.Add(new MySqlParameter("@FechaInicial", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fechafinal", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalcularEstadoDeResultadoPorMesEnDolares(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalcularEstadoDeResultadoPorMesEnDolares";

                Comando.Parameters.Add(new MySqlParameter("@FechaInicial", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fechafinal", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalcularBalanceGeneralPorMes(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalcularBalanceGeneralPorMes";

                Comando.Parameters.Add(new MySqlParameter("@FechaInicial", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fechafinal", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool CalcularBalanceGeneralPorMesEnDolares(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "CalcularBalanceGeneralPorMesEnDolares";

                Comando.Parameters.Add(new MySqlParameter("@FechaInicial", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fechafinal", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool TraerElAuxiliarDelMayorSobreLaCuenta(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "GenerarAuxiliarMayor";

                Comando.Parameters.Add(new MySqlParameter("@idCuenta_", MySqlDbType.VarChar, oRegistroEN.idCuenta.Trim().Length)).Value = oRegistroEN.idCuenta.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool GenerarAuxiliarMayorDesdeElHistorico(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "GenerarAuxiliarMayorDesdeElHistorico";

                Comando.Parameters.Add(new MySqlParameter("@idCuenta_", MySqlDbType.VarChar, oRegistroEN.idCuenta.Trim().Length)).Value = oRegistroEN.idCuenta.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.DateTime)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.DateTime)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        public bool TraerElAuxiliarDelMayorSobreLaCuentaBACK(ReportesEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                this.Consultas =  string.Format(@"
                Select Fecha, AgregarNumeroDelaTransaccionPorTipo( t.idTipoDeTransaccion,NumeroDeTransaccion) as 'Trans', c.idCuenta, Concepto, 
                (Select concat(c2.idCuenta, ' - ', c2.DescCuenta) from cuenta as c2 where c2.idCuenta = '{0}') as 'DescCuenta',td.Debe, td.Haber, 
                case when gc.Debitos = '+' then td.Debe - td.haber + c.SaldoCuenta else td.Haber - td.Debe + c.SaldoCuenta end as 'SaldoActual',                
                ifnull((Select ifnull( concat(tdb.ReferenciaBanco, ' - ', tdb.DescBanco) ,' ') as 'DescBanco' from tansacciondetalle_banco as tdb where tdb.idTransaccionDetalle = td.idTransaccionDetalle),'') as 'DescBanco',    
                @Fecha1 as 'FechaInicial', @Fecha2 as 'FechaFinal'
                from transacciondetalle as td
                inner join transacciones as t on t.idTransacciones = td.idTransacciones
                inner join cuenta as c on c.NoCuenta = td.NoCuenta
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                inner join grupodecuentas as gc on gc.idGrupoDeCuentas = cc.idGrupoDeCuentas
                where SoloFecha( t.Fecha ) between SoloFecha( @Fecha1 ) and SoloFecha( @Fecha2 ) {1} {2} ", oRegistroEN.idCuenta, oRegistroEN.Where, oRegistroEN.OrderBy);

                Comando.CommandText = this.Consultas;
                
                Comando.Parameters.Add(new MySqlParameter("@Fecha1", MySqlDbType.Date)).Value = oRegistroEN.FechaInicial;
                Comando.Parameters.Add(new MySqlParameter("@Fecha2", MySqlDbType.Date)).Value = oRegistroEN.FechaFinal;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                return false;
            }
            finally
            {

                if (Cnn != null)
                {

                    if (Cnn.State == ConnectionState.Open)
                    {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;

            }

        }

        #endregion

        #region "Funciones que retornan información"

        private string TraerCadenaDeConexion(DatosDeConexionEN oDatos) {
            string cadena = string.Format("Data Source='{0}';Initial Catalog='{1}';Persist Security Info=True;User ID='{2}';Password='{3}'", oDatos.Servidor, oDatos.BaseDeDatos, oDatos.Usuario, oDatos.Contraseña);
            return cadena;
        }

        public DataTable TraerDatos() {
            return DT;
        }

        #endregion


    }
}
