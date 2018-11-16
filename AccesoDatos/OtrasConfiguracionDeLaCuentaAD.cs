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
    public class OtrasConfiguracionDeLaCuentaAD
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

        public bool Agregar(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos) {

            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"
                                
                insert into otrasconfiguraciondelacuenta
                (idConfiguracion, idTiposDeConfiguracion, idCuenta, NoCuenta, NivelCuenta, 
                idUsuarioDeCreacion, FechaDeCreacion, idUsuarioModificacion, FechaDeModificacion)
                values
                (@idConfiguracion, @idTiposDeConfiguracion, @idCuenta, @NoCuenta, @NivelCuenta, 
                @idUsuarioDeCreacion, current_timestamp(), @idUsuarioModificacion, current_timestamp());

                Select last_insert_id() as 'ID';";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@idConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idConfiguracion;
                Comando.Parameters.Add(new MySqlParameter("@idTiposDeConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idTiposDeConfiguracion;
                Comando.Parameters.Add(new MySqlParameter("@NoCuenta", MySqlDbType.Int32)).Value = oRegistroEN.NoCuenta;                
                Comando.Parameters.Add(new MySqlParameter("@idCuenta", MySqlDbType.VarChar, oRegistroEN.idCuenta.Trim().Length)).Value = oRegistroEN.idCuenta.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NivelCuenta", MySqlDbType.Int32)).Value = oRegistroEN.NivelCuenta;

                Comando.Parameters.Add(new MySqlParameter("@idUsuarioDeCreacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;
                Comando.Parameters.Add(new MySqlParameter("@idUsuarioModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;

                Adaptador = new MySqlDataAdapter();
                DT = new DataTable();

                Adaptador.SelectCommand = Comando;
                Adaptador.Fill(DT);

                oRegistroEN.idOtrasConfiguracionDeLaCuenta = Convert.ToInt32(DT.Rows[0].ItemArray[0].ToString());
                
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

        public bool Actualizar(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"UPDATE otrasconfiguraciondelacuenta SET
	                idConfiguracion = @idConfiguracion, idTiposDeConfiguracion = QidTiposDeConfiguracion, 
                    idCuenta = @idCuenta, NoCuenta = @NoCuenta, NivelCuenta = @NivelCuenta, 
	                idUsuarioModificacion = @idUsuarioModificacion, FechaDeModificacion = current_timestamp()
                WHERE idOtrasConfiguracionDeLaCuenta = @idOtrasConfiguracionDeLaCuenta;";

                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@idOtrasConfiguracionDeLaCuenta", MySqlDbType.Int32)).Value = oRegistroEN.idOtrasConfiguracionDeLaCuenta;
                Comando.Parameters.Add(new MySqlParameter("@idConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idConfiguracion;
                Comando.Parameters.Add(new MySqlParameter("@idTiposDeConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idTiposDeConfiguracion;
                Comando.Parameters.Add(new MySqlParameter("@NoCuenta", MySqlDbType.Int32)).Value = oRegistroEN.NoCuenta;
                Comando.Parameters.Add(new MySqlParameter("@idCuenta", MySqlDbType.VarChar, oRegistroEN.idCuenta.Trim().Length)).Value = oRegistroEN.idCuenta.Trim();
                Comando.Parameters.Add(new MySqlParameter("@NivelCuenta", MySqlDbType.Int32)).Value = oRegistroEN.NivelCuenta;

                Comando.Parameters.Add(new MySqlParameter("@idUsuarioModificacion", MySqlDbType.Int32)).Value = oRegistroEN.oLoginEN.idUsuario;

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

        public bool Eliminar(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos)
        {
            oTransaccionesAD = new TransaccionesAD();

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = @"Delete from OtrasConfiguracionDeLaCuenta where idOtrasConfiguracionDeLaCuenta = @idOtrasConfiguracionDeLaCuenta;";
                Comando.CommandText = Consultas;

                Comando.Parameters.Add(new MySqlParameter("@idOtrasConfiguracionDeLaCuenta", MySqlDbType.Int32)).Value = oRegistroEN.idOtrasConfiguracionDeLaCuenta;
                
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

        public bool Listado(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT oc.idOtrasConfiguracionDeLaCuenta, oc.idConfiguracion, oc.NoCuenta, oc.idTiposDeConfiguracion, 
                oc.idCuenta, c.DescCuenta, 
                oc.NivelCuenta, cc.DescCategoriaDeCuenta,tc.Nombre as 'TipoDeConfiguracion', oc.idUsuarioDeCreacion, oc.FechaDeCreacion, 
                oc.idUsuarioModificacion, oc.FechaDeModificacion 
                FROM otrasconfiguraciondelacuenta as oc
                inner join cuenta as c on c.NoCuenta = oc.NoCuenta
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                inner join tiposdeconfiguracion as tc on tc.idTiposDeConfiguracion = oc.idTiposDeConfiguracion
                inner join configuracion as cn on cn.IdConfiguracion = oc.idConfiguracion

                where oc.idOtrasConfiguracionDeLaCuenta > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoPorIdentificador(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT oc.idOtrasConfiguracionDeLaCuenta, oc.idConfiguracion, oc.NoCuenta, oc.idTiposDeConfiguracion, 
                oc.idCuenta, c.DescCuenta, 
                oc.NivelCuenta, cc.DescCategoriaDeCuenta,tc.Nombre as 'TipoDeConfiguracion', oc.idUsuarioDeCreacion, oc.FechaDeCreacion, 
                oc.idUsuarioModificacion, oc.FechaDeModificacion 
                FROM otrasconfiguraciondelacuenta as oc
                inner join cuenta as c on c.NoCuenta = oc.NoCuenta
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                inner join tiposdeconfiguracion as tc on tc.idTiposDeConfiguracion = oc.idTiposDeConfiguracion
                inner join configuracion as cn on cn.IdConfiguracion = oc.idConfiguracion

                where oc.idOtrasConfiguracionDeLaCuenta = {0} ", oRegistroEN.idOtrasConfiguracionDeLaCuenta);
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

        public bool ListadoParaCombos(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT oc.idOtrasConfiguracionDeLaCuenta, oc.idConfiguracion, oc.NoCuenta, oc.idTiposDeConfiguracion, 
                oc.idCuenta, c.DescCuenta, 
                oc.NivelCuenta, cc.DescCategoriaDeCuenta,tc.Nombre as 'TipoDeConfiguracion', oc.idUsuarioDeCreacion, oc.FechaDeCreacion, 
                oc.idUsuarioModificacion, oc.FechaDeModificacion 
                FROM otrasconfiguraciondelacuenta as oc
                inner join cuenta as c on c.NoCuenta = oc.NoCuenta
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                inner join tiposdeconfiguracion as tc on tc.idTiposDeConfiguracion = oc.idTiposDeConfiguracion
                inner join configuracion as cn on cn.IdConfiguracion = oc.idConfiguracion

                where oc.idOtrasConfiguracionDeLaCuenta > 0 {0} {1} ; ", oRegistroEN.Where, oRegistroEN.OrderBy);
                Comando.CommandText = Consultas;

                System.Diagnostics.Debug.Print("Consultas de Tipo de transaccion: " + Consultas);

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

        public bool ListadoParaReportes(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"SELECT oc.idOtrasConfiguracionDeLaCuenta, oc.idConfiguracion, oc.NoCuenta, oc.idTiposDeConfiguracion, 
                oc.idCuenta, c.DescCuenta, 
                oc.NivelCuenta, cc.DescCategoriaDeCuenta,tc.Nombre as 'TipoDeConfiguracion', oc.idUsuarioDeCreacion, oc.FechaDeCreacion, 
                oc.idUsuarioModificacion, oc.FechaDeModificacion 
                FROM otrasconfiguraciondelacuenta as oc
                inner join cuenta as c on c.NoCuenta = oc.NoCuenta
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                inner join tiposdeconfiguracion as tc on tc.idTiposDeConfiguracion = oc.idTiposDeConfiguracion
                inner join configuracion as cn on cn.IdConfiguracion = oc.idConfiguracion

                where oc.idOtrasConfiguracionDeLaCuenta > 0 {0} {1} ", oRegistroEN.Where, oRegistroEN.OrderBy);
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

        public bool ListadoDeCuentasAsociadasAConfiguracion(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos)
        {

            try
            {

                Cnn = new MySqlConnection(TraerCadenaDeConexion(oDatos));
                Cnn.Open();

                Comando = new MySqlCommand();
                Comando.Connection = Cnn;
                Comando.CommandType = CommandType.Text;

                Consultas = string.Format(@"Select idOtrasConfiguracionDeLaCuenta, idConfiguracion,NoCuenta, idTiposDeConfiguracion, idCategoriaDeCuenta, idGrupoDeCuentas, idCuenta, DescCuenta, NivelCuenta,
                DescCategoriaDeCuenta, TipoDeConfiguracion, idUsuarioDeCreacion, FechaDeCreacion,idUsuarioModificacion,FechaDeModificacion
                from (

                SELECT oc.idOtrasConfiguracionDeLaCuenta, oc.idConfiguracion, oc.NoCuenta, oc.idTiposDeConfiguracion, cc.idCategoriaDeCuenta,cc.idGrupoDeCuentas,
                oc.idCuenta, c.DescCuenta, 
                oc.NivelCuenta, cc.DescCategoriaDeCuenta,tc.Nombre as 'TipoDeConfiguracion', oc.idUsuarioDeCreacion, oc.FechaDeCreacion, 
                oc.idUsuarioModificacion, oc.FechaDeModificacion 
                FROM otrasconfiguraciondelacuenta as oc
                inner join cuenta as c on c.NoCuenta = oc.NoCuenta
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                inner join tiposdeconfiguracion as tc on tc.idTiposDeConfiguracion = oc.idTiposDeConfiguracion
                inner join configuracion as cn on cn.IdConfiguracion = oc.idConfiguracion

                where oc.idOtrasConfiguracionDeLaCuenta > 0 and oc.idTiposDeConfiguracion = {1}

                union all

                Select  0 as 'idOtrasConfiguracionDeLaCuenta', 0 as 'idConfiguracion', c.NoCuenta, 0 as 'idTiposDeConfiguracion', cc.idCategoriaDeCuenta,cc.idGrupoDeCuentas, 
                c.idCuenta, c.DescCuenta, c.NivelCuenta, cc.DescCategoriaDeCuenta, '' as 'TipoDeConfiguracion', 
                c.IdUsuarioDeCreacion as 'idTiposDeConfiguracion', c.FechaDeCreacion, 
                c.IdUsuarioDeModificacion as 'idUsuarioModificacion', c.FechaDeModificacion  
                from cuenta as c
                inner join categoriadecuenta as cc on cc.idCategoriaDeCuenta = c.idCategoriaDeCuenta
                Where c.NoCuenta not in (Select oc1.NoCuenta from otrasconfiguraciondelacuenta as oc1 where oc1.idTiposDeConfiguracion = {1} ) ) as T 
                Where NoCuenta > 0 {0}
                order by idCuenta ", oRegistroEN.Where,oRegistroEN.idTiposDeConfiguracion);

                System.Diagnostics.Debug.Print(Consultas);
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

        public bool ValidarSiElRegistroEstaVinculado(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
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

                Comando.Parameters.Add(new MySqlParameter("@CampoABuscar_", MySqlDbType.VarChar, 200)).Value = "idOtrasConfiguracionDeLaCuenta";
                Comando.Parameters.Add(new MySqlParameter("@ValorCampoABuscar", MySqlDbType.Int32)).Value = oRegistroEN.idOtrasConfiguracionDeLaCuenta;
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

        public bool ValidarRegistroDuplicado(OtrasConfiguracionDeLaCuentaEN oRegistroEN, DatosDeConexionEN oDatos, string TipoDeOperacion)
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

                        Consultas = @"SELECT CASE WHEN EXISTS(Select idOtrasConfiguracionDeLaCuenta from otrasconfiguraciondelacuenta where idConfiguracion = @idConfiguracion and idTiposDeConfiguracion = @idTiposDeConfiguracion and NoCuenta = @NoCuenta) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@idConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idConfiguracion;
                        Comando.Parameters.Add(new MySqlParameter("@idTiposDeConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idTiposDeConfiguracion;
                        Comando.Parameters.Add(new MySqlParameter("@NoCuenta", MySqlDbType.Int32)).Value = oRegistroEN.NoCuenta;

                        break;

                    case "ACTUALIZAR":

                        Consultas = @"SELECT CASE WHEN EXISTS(Select idOtrasConfiguracionDeLaCuenta from otrasconfiguraciondelacuenta where idConfiguracion = @idConfiguracion and idTiposDeConfiguracion = @idTiposDeConfiguracion and NoCuenta = @NoCuenta and idOtrasConfiguracionDeLaCuenta <> @idOtrasConfiguracionDeLaCuenta) THEN 1 ELSE 0 END AS 'RES'";
                        Comando.Parameters.Add(new MySqlParameter("@idConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idConfiguracion;
                        Comando.Parameters.Add(new MySqlParameter("@idTiposDeConfiguracion", MySqlDbType.Int32)).Value = oRegistroEN.idTiposDeConfiguracion;
                        Comando.Parameters.Add(new MySqlParameter("@NoCuenta", MySqlDbType.Int32)).Value = oRegistroEN.NoCuenta;
                        Comando.Parameters.Add(new MySqlParameter("@idOtrasConfiguracionDeLaCuenta", MySqlDbType.Int32)).Value = oRegistroEN.idOtrasConfiguracionDeLaCuenta;

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

        private TransaccionesEN InformacionDelaTransaccion(OtrasConfiguracionDeLaCuentaEN oOtrasConfiguracionDeLaCuenta, String TipoDeOperacion, String Descripcion, String Estado)
        {
            TransaccionesEN oRegistroEN = new TransaccionesEN();

            oRegistroEN.idregistro = oOtrasConfiguracionDeLaCuenta.idOtrasConfiguracionDeLaCuenta;
            oRegistroEN.Modelo = "TransaccionAD";
            oRegistroEN.Modulo = "Transacciones";
            oRegistroEN.Tabla = "OtrasConfiguracionDeLaCuentaes";
            oRegistroEN.tipodeoperacion = TipoDeOperacion;
            oRegistroEN.Estado = Estado;
            oRegistroEN.ip = oOtrasConfiguracionDeLaCuenta.oLoginEN.NumeroIP;
            oRegistroEN.idusuario = oOtrasConfiguracionDeLaCuenta.oLoginEN.idUsuario;
            oRegistroEN.idusuarioaprueba = oOtrasConfiguracionDeLaCuenta.oLoginEN.idUsuario;
            oRegistroEN.descripciondelusuario = DescripcionDeOperacion;
            oRegistroEN.descripcioninterna = Descripcion;
            oRegistroEN.NombreDelEquipo = oOtrasConfiguracionDeLaCuenta.oLoginEN.NombreDelComputador;

            return oRegistroEN;
        }


        private string InformacionDelRegistro(OtrasConfiguracionDeLaCuentaEN oRegistroEN) {
            string Cadena = @"idOtrasConfiguracionDeLaCuenta: {0}, idConfiguracion: {1}, idTiposDeConfiguracion: {2}, idCuenta: {3}, NoCuenta: {4}, NivelCuenta: {5}, idUsuarioDeCreacion: {6}, FechaDeCreacion: {7}, idUsuarioModificacion: {8}, FechaDeModificacion: {9}";
            Cadena = string.Format(Cadena, oRegistroEN.idOtrasConfiguracionDeLaCuenta, oRegistroEN.idConfiguracion, oRegistroEN.idTiposDeConfiguracion, oRegistroEN.idCuenta, oRegistroEN.NoCuenta, oRegistroEN.NivelCuenta, oRegistroEN.IdUsuarioDeCreacion, oRegistroEN.FechaDeCreacion, oRegistroEN.IdUsuarioDeModificacion, oRegistroEN.FechaDeModificacion);
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
