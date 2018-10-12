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
    public class TansaccionDetalleTMPBancoAD
    {

        public string Error { set; get; }
        private MySqlConnection Cnn = null;
        private MySqlCommand Comando = null;
        private MySqlDataAdapter Adaptador = null;
        private TransaccionesAD oTransaccionesAD = null;
        string Consultas;
        string DescripcionDeOperacion;
        private DataTable DT { set; get; }
              

        #region "Funciones para datos dll"

        public bool Agregar(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos) {

            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"
                                
                insert into transacciondetalletmpbanco
                (idTransaccionDetalle, ReferenciaBanco, DescBanco, Debe, Haber, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion)
                values
                (@idTransaccionDetalle, @ReferenciaBanco, @DescBanco, @Debe, @Haber, @IdUsuarioDeCreacion, current_timestamp(), @IdUsuarioDeModificacion, current_timestamp());

                Select last_insert_id() as 'ID';";

                Comando.CommandText = Consultas;                               

                Comando.Parameters.Add(new MySqlParameter("@idTransaccionDetalle", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.idTransaccionDetalle;
                Comando.Parameters.Add(new MySqlParameter("@ReferenciaBanco", MySqlDbType.VarChar, oRegistroEN.ReferenciaBanco.Trim().Length)).Value = oRegistroEN.ReferenciaBanco.Trim();
                Comando.Parameters.Add(new MySqlParameter("@DescBanco", MySqlDbType.VarChar, oRegistroEN.DescBanco.Trim().Length)).Value = oRegistroEN.DescBanco.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Debe", MySqlDbType.Decimal)).Value = oRegistroEN.Debe;
                Comando.Parameters.Add(new MySqlParameter("@Haber", MySqlDbType.Decimal)).Value = oRegistroEN.Haber;

                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                oRegistroEN.idTansaccionDetalle_Banco = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());
                
                DescripcionDeOperacion = string.Format("El registro fue Insertado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return true;


            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al insertar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Agregar Nuevo Registro", "ERROR");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return false;
            }
            finally {

                if (Cnn != null) {

                    if (Cnn.State == ConnectionState.Open) {

                        Cnn.Close();

                    }

                }

                Cnn = null;
                Comando = null;
                Adaptador = null;
                oTransaccionesAD = null;

            }

        }

        public bool Actualizar(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"UPDATE transacciondetalletmpbanco SET
	                idTransaccionDetalle = @idTransaccionDetalle, ReferenciaBanco = @ReferenciaBanco, 
                    DescBanco = @DescBanco, Debe = @Debe, Haber = @Haber, IdUsuarioDeModificacion = @IdUsuarioDeModificacion, FechaDeModificacion = current_timestamp()
                WHERE idTansaccionDetalle_Banco = @idTansaccionDetalle_Banco;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@idTansaccionDetalle_Banco", MySqlDbType.Int32)).Value = oRegistroEN.idTansaccionDetalle_Banco;
                Comando.Parameters.Add(new MySqlParameter("@idTransaccionDetalle", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.idTransaccionDetalle;
                Comando.Parameters.Add(new MySqlParameter("@ReferenciaBanco", MySqlDbType.VarChar, oRegistroEN.ReferenciaBanco.Trim().Length)).Value = oRegistroEN.ReferenciaBanco.Trim();
                Comando.Parameters.Add(new MySqlParameter("@DescBanco", MySqlDbType.VarChar, oRegistroEN.DescBanco.Trim().Length)).Value = oRegistroEN.DescBanco.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Debe", MySqlDbType.Decimal)).Value = oRegistroEN.Debe;
                Comando.Parameters.Add(new MySqlParameter("@Haber", MySqlDbType.Decimal)).Value = oRegistroEN.Haber;
                
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;

                Comando.ExecuteNonQuery();
                
                DescripcionDeOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Actualizar", "Actualizar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTran, oDatos);

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
                oTransaccionesAD = null;

            }

        }

        public bool Eliminar(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"Delete from transacciondetalletmpbanco where idTansaccionDetalle_Banco = @idTansaccionDetalle_Banco;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@idTansaccionDetalle_Banco", MySqlDbType.Int32)).Value = oRegistroEN.idTansaccionDetalle_Banco;
                
                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Eliminar", "Elminar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Eliminar", "Eliminar Registro", "ERROR");
                oTransaccionesAD.Agregar(oTran, oDatos);

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
                oTransaccionesAD = null;

            }

        }

        public bool Listado(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT 
                idTansaccionDetalle_Banco, tdb.idTransaccionDetalle, c.NoCuenta, c.idCuenta, c.DescCuenta, 
                tdb.ReferenciaBanco, tdb.DescBanco, tdb.Debe, tdb.Haber
                FROM transacciondetalletmpbanco AS tdb
                inner join transacciondetalletmp as td on td.idTransaccionDetalle = tdb.idTransaccionDetalle
                inner join cuenta as c on c.NoCuenta = td.NoCuenta
                where idTansaccionDetalle_Banco > 0  {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;
                
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

        public bool ListadoPorIdentificador(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT 
                idTansaccionDetalle_Banco, tdb.idTransaccionDetalle, c.NoCuenta, c.idCuenta, c.DescCuenta, 
                tdb.ReferenciaBanco, tdb.DescBanco, tdb.Debe, tdb.Haber
                FROM transacciondetalletmpbanco AS tdb
                inner join transacciondetalletmp as td on td.idTransaccionDetalle = tdb.idTransaccionDetalle
                inner join cuenta as c on c.NoCuenta = td.NoCuenta
                where idTansaccionDetalle_Banco  ={0} ", oRegistroEN.idTansaccionDetalle_Banco);
                Comando.CommandText = Consultas;

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

        public bool ListadoParaCombos(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT 
                idTansaccionDetalle_Banco, tdb.idTransaccionDetalle, c.NoCuenta, c.idCuenta, c.DescCuenta, 
                tdb.ReferenciaBanco, tdb.DescBanco, tdb.Debe, tdb.Haber
                FROM transacciondetalletmpbanco AS tdb
                inner join transacciondetalletmp as td on td.idTransaccionDetalle = tdb.idTransaccionDetalle
                inner join cuenta as c on c.NoCuenta = td.NoCuenta
                where idTansaccionDetalle_Banco > 0  {0} {1} ; ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

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

        public bool ListadoParaReportes(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"Select idTansaccionDetalle_Banco,idTransaccionDetalle, idTransacciones, NoCuenta, idCuenta, DescCuenta, 
                ReferenciaBanco, DescBanco, Debe, Haber from (
                SELECT 
                idTansaccionDetalle_Banco, tdb.idTransaccionDetalle, tt.idTransacciones, c.NoCuenta, c.idCuenta, c.DescCuenta, 
                tdb.ReferenciaBanco, tdb.DescBanco, tdb.Debe, tdb.Haber
                FROM transacciondetalletmpbanco AS tdb
                inner join transacciondetalletmp as tt on tt.idTransaccionDetalle = tdb.idTransaccionDetalle
                inner join transacciontmp as t on t.idTransacciones = tt.idTransacciones
                inner join cuenta as c on c.NoCuenta = tt.NoCuenta
                where idTansaccionDetalle_Banco > 0 {0}

                union

                SELECT 
                idTansaccionDetalle_Banco, tdb.idTransaccionDetalle, tt.idTransacciones, c.NoCuenta, c.idCuenta, c.DescCuenta, 
                tdb.ReferenciaBanco, tdb.DescBanco, tdb.Debe, tdb.Haber
                FROM tansacciondetalle_banco AS tdb
                inner join transacciondetalle as tt on tt.idTransaccionDetalle = tdb.idTransaccionDetalle
                inner join transacciones as t on t.idTransacciones = tt.idTransacciones
                inner join cuenta as c on c.NoCuenta = tt.NoCuenta
                where idTansaccionDetalle_Banco > 0 {0}
                ) as T  {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

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

        #region "Funciones de Validación"

        public bool ValidarSiElRegistroEstaVinculado(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "ValidarSiElRegistroEstaVinculado";

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "idTansaccionDetalle_Banco";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.idTansaccionDetalle_Banco;
                Comando.Parameters.Add(new MySqlParameter("@ExcluirTabla_", MySqlDbType.VarChar, 200)).Value = string.Empty;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                if (DT.Rows[0].ItemArray[0].ToString().ToUpper() == "NINGUNA".ToUpper())
                {
                    return false;
                }
                else
                {

                    this.Error = String.Format("La Operación: '{1}', {0} no se puede completar por que el registro: {0} '{2}', {0} se encuentra asociado con: {0} {3}",Environment.NewLine, TipoDeOperacion, InformacionDelRegistro(oRegistroEN), oTransaccionesAD.ConvertirValorDeLaCadena(DT.Rows[0].ItemArray[0].ToString()));
                    DescripcionDeOperacion = this.Error;

                    //Agregamos la Transacción....
                    TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "CORRECTO");
                    oTransaccionesAD.Agregar(oTran, oDatos);

                    return true;
                }

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "VALIDAR SI EL REGISTRO ESTA VINCULADO", "ERROR");
                oTransaccionesAD.Agregar(oTran, oDatos);

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
                oTransaccionesAD = null;

            }

        }

        public bool ValidarRegistroDuplicado(TansaccionDetalleTMPBancoEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                switch (TipoDeOperacion.Trim().ToUpper()){

                    case "AGREGAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT 
                        idTansaccionDetalle_Banco 
                        FROM transacciondetalletmpbanco AS tdb
                        inner join transacciondetalletmp as td on td.idTransaccionDetalle = tdb.idTransaccionDetalle
                        inner join cuenta as c on c.NoCuenta = td.NoCuenta
                        inner join transacciontmp as t on t.idTransacciones = td.idTransacciones
                        where c.NoCuenta = @NoCuenta and t.idTransacciones = @idTransacciones and t.idTipoDeTransaccion = @idTipoDeTransaccion) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@NoCuenta", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.oCuentaEN.NoCuenta;
                        Comando.Parameters.Add(new MySqlParameter("@idTransacciones", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.oTransaccionesEN.idTransacciones;
                        Comando.Parameters.Add(new MySqlParameter("@idTipoDeTransaccion", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.oTransaccionesEN.oTipoDeTransaccionEN.idTipoDeTransaccion;

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT 
                        idTansaccionDetalle_Banco 
                        FROM transacciondetalletmpbanco AS tdb
                        inner join transacciondetalletmp as td on td.idTransaccionDetalle = tdb.idTransaccionDetalle
                        inner join cuenta as c on c.NoCuenta = td.NoCuenta
                        inner join transacciontmp as t on t.idTransacciones = td.idTransacciones
                        where c.NoCuenta = @NoCuenta and t.idTransacciones = @idTransacciones and t.idTipoDeTransaccion = @idTipoDeTransaccion
                        and idTansaccionDetalle_Banco <> @idTansaccionDetalle_Banco) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@NoCuenta", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.oCuentaEN.NoCuenta;
                        Comando.Parameters.Add(new MySqlParameter("@idTransacciones", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.oTransaccionesEN.idTransacciones;
                        Comando.Parameters.Add(new MySqlParameter("@idTipoDeTransaccion", MySqlDbType.Int32)).Value = oRegistroEN.oTransaccionDetalleEN.oTransaccionesEN.oTipoDeTransaccionEN.idTipoDeTransaccion;
                        Comando.Parameters.Add(new MySqlParameter("@idTansaccionDetalle_Banco", MySqlDbType.Int32)).Value = oRegistroEN.idTansaccionDetalle_Banco;

                        break;

                    default:
                        throw new ArgumentException( "La aperación solicitada no esta disponible");                        

                }
                
                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                if (Convert.ToInt32(DT.Rows[0]["RES"].ToString()) > 0) {
                    
                    DescripcionDeOperacion = string.Format("Ya existe información del Registro dentro de nuestro sistema: {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));
                    this.Error = DescripcionDeOperacion;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "REGISTRO DUPLICADO DENTRO DE LA BASE DE DATOS", "ERROR");
                oTransaccionesAD.Agregar(oTran, oDatos);

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
                oTransaccionesAD = null;

            }

        }

        #endregion

        #region "Funciones que retornan información"

        private TransaccionesEN InformacionDelaTransaccion(TansaccionDetalleTMPBancoEN oTansaccionDetalle_Banco, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.idregistro = oTansaccionDetalle_Banco.idTansaccionDetalle_Banco;
            oRegistroEN.Modelo = "TansaccionDetalleTMPBancoAD";
            oRegistroEN.Modulo = "Transacciones";
            oRegistroEN.Tabla = "TansaccionDetalleTMPBanco";
            oRegistroEN.tipodeoperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.ip = oTansaccionDetalle_Banco.oLoginEN.NumeroIP;
            oRegistroEN.idusuario = oTansaccionDetalle_Banco.oLoginEN.idUsuario;
            oRegistroEN.idusuarioaprueba = oTansaccionDetalle_Banco.oLoginEN.idUsuario;
            oRegistroEN.descripciondelusuario = DescripcionDeOperacion;
            oRegistroEN.descripcioninterna = Descripcion;
            oRegistroEN.NombreDelEquipo = oTansaccionDetalle_Banco.oLoginEN.NombreDelComputador;

            return oRegistroEN;
        }


        private string InformacionDelRegistro(TansaccionDetalleTMPBancoEN oRegistroEN) {
            string Cadena = @"idTansaccionDetalle_Banco: {0}, idTransaccionDetalle: {1}, ReferenciaBanco: {2}, DescBanco: {3}, Debe: {4}, Haber: {5}, 
            IdUsuarioDeCreacion: {6}, FechaDeCreacion: {7}, IdUsuarioDeModificacion: {8}, FechaDeModificacion: {9}";
            Cadena = string.Format(Cadena, oRegistroEN.idTansaccionDetalle_Banco, oRegistroEN.oTransaccionDetalleEN.idTransaccionDetalle, oRegistroEN.ReferenciaBanco, oRegistroEN.DescBanco, oRegistroEN.Debe, oRegistroEN.Haber,oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeModificacion, oRegistroEN.FechaDeModificacion);
            Cadena = Cadena.Replace(",", Environment.NewLine);
            return Cadena;            
        }

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
