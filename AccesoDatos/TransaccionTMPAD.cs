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
    public class TransaccionTMPAD
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

        public bool Agregar(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos) {

            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"
                                
                insert into transacciontmp
                (NumeroDeTransaccion, Fecha, Concepto, Valor, idTipoDeTransaccion, Estado, 
                IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion)
                values
                (IdentificadorDeLaTransaccionPorTipoDeTransaccion(@idTipoDeTransaccion), @Fecha, @Concepto, @Valor, @idTipoDeTransaccion, @Estado, 
                @IdUsuarioDeCreacion, current_timestamp(), @IdUsuarioDeModificacion, current_timestamp());

                Select idTransacciones, NumeroDeTransaccion from transacciontmp where idTransacciones = last_insert_id();";

                Comando.CommandText = Consultas;                               
                                
                Comando.Parameters.Add(new MySqlParameter("@Fecha", MySqlDbType.DateTime)).Value = oRegistroEN.Fecha;
                Comando.Parameters.Add(new MySqlParameter("@Concepto", MySqlDbType.VarChar, oRegistroEN.Concepto.Trim().Length)).Value = oRegistroEN.Concepto.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Valor", MySqlDbType.Decimal)).Value = oRegistroEN.Valor;                
                Comando.Parameters.Add(new MySqlParameter("@idTipoDeTransaccion", MySqlDbType.Int32)).Value = oRegistroEN.oTipoDeTransaccionEN.idTipoDeTransaccion;
                Comando.Parameters.Add(new MySqlParameter("@Estado", MySqlDbType.VarChar, oRegistroEN.Estado.Trim().Length)).Value = oRegistroEN.Estado.Trim();
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                oRegistroEN.idTransacciones = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());
                oRegistroEN.NumeroDeTransaccion = DT.Rows[0].ItemArray[0].ToString();
                
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
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Agregar", "Error al agregar el registro", "ERROR");
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

        public bool GrabarDatos(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "call GrabarDatosEnTablasDeTransacciones();";
                
                Comando.ExecuteNonQuery();                

                DescripcionDeOperacion = string.Format("El registro fue Grabado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Grabar", "Grabar Datos", "CORRECTO");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return true;


            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al grabar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Grabar", "Error al grabar el registro", "ERROR");
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
                oTransaccionesAD = null;

            }

        }

        public bool CargarRegistro(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = string.Format("call CargarRegistros({0});", oRegistroEN.idTransacciones);

                System.Diagnostics.Debug.Print(string.Format("Valor del identificador: {0}", oRegistroEN.idTransacciones));

                Adaptador = new MySqlDataAdapter();
                Adaptador.SelectCommand = Comando;
                DT = new DataTable();
                Adaptador.Fill(DT);

                oRegistroEN.idTransacciones = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());

                DescripcionDeOperacion = string.Format("El registro fue Cargado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Cargar", "Cargar Datos", "CORRECTO");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return true;


            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al Cargar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Cargar", "Error al cargar el registro", "ERROR");
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
                oTransaccionesAD = null;

            }

        }

        public bool Actualizar(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"update transacciontmp set	                
                    Fecha = @Fecha, 
                    Concepto = @Concepto, 
                    Valor = @Valor, 
                    idTipoDeTransaccion = @idTipoDeTransaccion, 
                    Estado = @Estado, IdUsuarioDeModificacion = @IdUsuarioDeModificacion, 
                    FechaDeModificacion = current_timestamp()
                where idTransacciones = @idTransacciones;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@idTransacciones", MySqlDbType.Int32)).Value = oRegistroEN.idTransacciones;                
                Comando.Parameters.Add(new MySqlParameter("@Fecha", MySqlDbType.DateTime)).Value = oRegistroEN.Fecha;
                Comando.Parameters.Add(new MySqlParameter("@Concepto", MySqlDbType.VarChar, oRegistroEN.Concepto.Trim().Length)).Value = oRegistroEN.Concepto.Trim();
                Comando.Parameters.Add(new MySqlParameter("@Valor", MySqlDbType.Decimal)).Value = oRegistroEN.Valor;
                Comando.Parameters.Add(new MySqlParameter("@Estado", MySqlDbType.VarChar, oRegistroEN.Estado.Trim().Length)).Value = oRegistroEN.Estado.Trim();
                Comando.Parameters.Add(new MySqlParameter("@idTipoDeTransaccion", MySqlDbType.Int32)).Value = oRegistroEN.oTipoDeTransaccionEN.idTipoDeTransaccion;                
                Comando.Parameters.Add(new MySqlParameter("@IdUsuarioDeModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;

                Comando.ExecuteNonQuery();
                
                DescripcionDeOperacion = string.Format("El registro fue Actualizado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Actualizar", "Registro Actualizado", "CORRECTO");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al actualizar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                
                //Agregamos la transacción
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Actualizar", "Error al Actualizar", "CORRECTO");
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

        public bool Eliminar(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"Delete from transacciontmp where idTransacciones = @idTransacciones;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@idTransacciones", MySqlDbType.Int32)).Value = oRegistroEN.idTransacciones;
                
                Comando.ExecuteNonQuery();

                DescripcionDeOperacion = string.Format("El registro fue Eliminado Correctamente. {0} {1}", Environment.NewLine, InformacionDelRegistro(oRegistroEN));

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Elminar", "Eliminar Registro", "CORRECTO");
                oTransaccionesAD.Agregar(oTran, oDatos);

                return true;

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al eliminar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);
                
                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Eliminar", "Error al eliminar el registro", "CORRECTO");
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

        public bool Listado(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"Select * from (
                Select idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, tt.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado,
                'transacciontmp' as 'NombreTabla', 1 as 'RegistroTMP'
                from transacciontmp as t
                inner join TipoDeTransaccion tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion
                where idTransacciones > 0
                union
                Select 
                idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, tt.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado,
                'transacciones' as 'NombreTabla', case when exists(select tmp.idTransacciones from transacciontmp as tmp) then 1 else 0 end as 'RegistroTMP'
                from transacciones as t
                inner join TipoDeTransaccion tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion
                where idTransacciones > 0 ) as T Where idTransacciones > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool ListadoPorIdentificador(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"Select idTransacciones, idTipoDeTransaccion, NumeroDeTransaccion, DesTipoDeTransaccion , Fecha, Concepto, Valor, Estado, 
                IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion from (
                Select 
                idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, tt.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado, 
                t.IdUsuarioDeCreacion, t.FechaDeCreacion, t.IdUsuarioDeModificacion, t.FechaDeModificacion
                from transacciontmp as t
                inner join TipoDeTransaccion tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion
                Where t.idTransacciones = {0} 

                union

                Select 
                idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, tt.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado, 
                t.IdUsuarioDeCreacion, t.FechaDeCreacion, t.IdUsuarioDeModificacion, t.FechaDeModificacion
                from transacciones as t
                inner join TipoDeTransaccion tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion 
                Where t.idTransacciones = {0}    
                ) as T ", oRegistroEN.idTransacciones);
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

        public bool ListadoParaCombos(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"Select 
                idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, tt.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado, 
                t.IdUsuarioDeCreacion, t.FechaDeCreacion, t.IdUsuarioDeModificacion, t.FechaDeModificacion
                from transacciontmp as t
                inner join TipoDeTransaccion tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion
                where idTransacciones > 0  {0} {1} ; ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoParaReportes(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"Select idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, t.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado, 
                t.IdUsuarioDeCreacion, t.FechaDeCreacion, t.IdUsuarioDeModificacion, t.FechaDeModificacion from (
                Select 
                idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, tt.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado, 
                t.IdUsuarioDeCreacion, t.FechaDeCreacion, t.IdUsuarioDeModificacion, t.FechaDeModificacion
                from transacciontmp as t
                inner join TipoDeTransaccion tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion
                where idTransacciones > 0 {0}
                union
                Select 
                idTransacciones, t.idTipoDeTransaccion, t.NumeroDeTransaccion, tt.DesTipoDeTransaccion , t.Fecha, t.Concepto, t.Valor, t.Estado, 
                t.IdUsuarioDeCreacion, t.FechaDeCreacion, t.IdUsuarioDeModificacion, t.FechaDeModificacion
                from transacciones as t
                inner join TipoDeTransaccion tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion
                where idTransacciones > 0 {0} ) as t  {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);

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

        public bool EvaluarSiHayDatosEnLaTablaTMP(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"SELECT CASE WHEN EXISTS(SELECT idTransacciones FROM transacciontmp) THEN 1 ELSE 0 END AS 'RES' ";

                Comando.CommandText = Consultas;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                if(Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString()) == 1)
                {

                    Consultas = @"Select t.idTransacciones,t.idTipoDeTransaccion, t.NumeroDeTransaccion, t.Fecha, t.Concepto, t.Valor, t.Estado, tt.DesTipoDeTransaccion
                    from transacciontmp as t 
                    inner join TipoDeTransaccion as tt on tt.idTipoDeTransaccion = t.idTipoDeTransaccion ";

                    Comando.CommandText = Consultas;
                    Adaptador.SelectCommand = null;
                    Adaptador.SelectCommand = Comando;

                    DT.Clear();

                    Adaptador.Fill(DT);
                    DataRow Fila = DT.Rows[0];

                    this.Error = string.Format(@"No se puede continuar por qué Existe un Movimiento - {0} en proceso ", Fila["DesTipoDeTransaccion"]);
                    return true;

                }
                else
                {
                    return false;
                }
                
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

        public bool ValidarSiElRegistroEstaVinculado(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
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

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "idTransacciones";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.idTransacciones;
                Comando.Parameters.Add(new MySqlParameter("@ExcluirTabla_", MySqlDbType.VarChar, 200)).Value = "transacciondetalletmp";

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
                    TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Validar", "Validar Si el registro se encunentra vinculado", "CORRECTO");
                    oTransaccionesAD.Agregar(oTran, oDatos);

                    return true;
                }

            }
            catch (Exception ex)
            {
                this.Error = ex.Message;

                DescripcionDeOperacion = string.Format("Se produjo el seguiente error: '{2}' al validar el registro. {0} {1} ", Environment.NewLine, InformacionDelRegistro(oRegistroEN), ex.Message);

                //Agregamos la Transacción....
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "Validar", "Validar Si el registro se encunentra vinculado", "ERROR");
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

        public bool ValidarRegistroDuplicadoDeLaTransaccion(TransaccionTMPEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
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

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT idTransacciones FROM transacciontmp WHERE upper(trim(NumeroDeTransaccion)) = upper(@NumeroDeTransaccion)) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@NumeroDeTransaccion", MySqlDbType.VarChar, oRegistroEN.NumeroDeTransaccion.Trim().Length)).Value = oRegistroEN.NumeroDeTransaccion.Trim();

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(SELECT idTransacciones FROM transacciontmp WHERE upper(trim(NumeroDeTransaccion)) = upper(@NumeroDeTransaccion) and idTransacciones <> @idTransacciones) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@NumeroDeTransaccion", MySqlDbType.VarChar, oRegistroEN.NumeroDeTransaccion.Trim().Length)).Value = oRegistroEN.NumeroDeTransaccion.Trim();
                        Comando.Parameters.Add(new MySqlParameter("@idTransacciones", MySqlDbType.Int32)).Value = oRegistroEN.idTransacciones;

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
                TransaccionesEN oTran = InformacionDelaTransaccion(oRegistroEN, "VALIDAR", "DUPLICACIÓN DE REGISTRO", "ERROR");
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

        private TransaccionesEN InformacionDelaTransaccion(TransaccionTMPEN oTransaccion, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.idregistro = oTransaccion.idTransacciones;
            oRegistroEN.Modelo = "TransaccionTMPAD";
            oRegistroEN.Modulo = "Transacciones";
            oRegistroEN.Tabla = "TransaccionesTMP";
            oRegistroEN.tipodeoperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.ip = oTransaccion.oLoginEN.NumeroIP;
            oRegistroEN.idusuario = oTransaccion.oLoginEN.idUsuario;
            oRegistroEN.idusuarioaprueba = oTransaccion.oLoginEN.idUsuario;
            oRegistroEN.descripciondelusuario = DescripcionDeOperacion;
            oRegistroEN.descripcioninterna = Descripcion;
            oRegistroEN.NombreDelEquipo = oTransaccion.oLoginEN.NombreDelComputador;

            return oRegistroEN;
        }

        private string InformacionDelRegistro(TransaccionTMPEN oRegistroEN) {
            string Cadena = @"idTransacciones: {0}, NumeroDeTransaccion: {1}, Fecha: {2}, Concepto: {3}, Valor: {4}, idTipoDeTransaccion: {5}, Estado: {6}, IdUsuarioDeCreacion: {7}, FechaDeCreacion: {8}, IdUsuarioDeModificacion: {9}, FechaDeModificacion: {10}";
            Cadena = string.Format(Cadena, oRegistroEN.idTransacciones, oRegistroEN.NumeroDeTransaccion, oRegistroEN.Fecha, oRegistroEN.Concepto, oRegistroEN.Valor, oRegistroEN.oTipoDeTransaccionEN.idTipoDeTransaccion, oRegistroEN.Estado, oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeModificacion, oRegistroEN.FechaDeModificacion);
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
