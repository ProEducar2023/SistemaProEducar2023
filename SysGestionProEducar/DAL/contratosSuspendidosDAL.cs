using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class contratosSuspendidosDAL
    {
        SqlConnection conn;
        public contratosSuspendidosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerContratosSuspendidosxPtoCobDAL(contratosSuspendidosTo csTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_SUSPENDIDO_X_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", csTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", csTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", csTo.COD_PTO_COB);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable obtenerContratosSuspendidosActivosDAL(contratosSuspendidosTo csTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_SUSPENDIDO_ACTIVOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ST_SUSPENSION", csTo.ST_SUSPENSION);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable obtenerContratosSuspendidosActivosxContratoDAL(contratosSuspendidosTo csTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_SUSPENDIDO_ACTIVOS_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable obtenerContratosSuspendidosxContratoDAL(contratosSuspendidosTo csTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_SUSPENDIDO_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool insertarContratosSuspendidosDAL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CONTRATOS_SUSPENDIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", csTo.COD_SUCURSAL);//**
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", csTo.COD_INSTITUCION);//**
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);//**
            cmd.Parameters.AddWithValue("@FECHA_SUSPENSION", csTo.FECHA_SUSPENSION);//**
            cmd.Parameters.AddWithValue("@COD_PER", csTo.COD_PER);//**
            cmd.Parameters.AddWithValue("@COD_PTO_COB", csTo.COD_PTO_COB);//**
            cmd.Parameters.AddWithValue("@FECHA_INI_SUS", csTo.FECHA_INI_SUS);//**
            cmd.Parameters.AddWithValue("@FECHA_FIN_SUS", csTo.FECHA_FIN_SUS);//**
            cmd.Parameters.AddWithValue("@COD_MOTIVO", csTo.COD_MOTIVO);//**
            cmd.Parameters.AddWithValue("@OBSERVACIONES", csTo.OBSERVACIONES);//**
            cmd.Parameters.AddWithValue("@ST_SUSPENSION", csTo.ST_SUSPENSION);//**
            cmd.Parameters.AddWithValue("@ST_ANULACION", csTo.ST_ANULACION);//**
            cmd.Parameters.AddWithValue("@COD_CREACION", csTo.COD_CREACION);//**
            cmd.Parameters.AddWithValue("@FECHA_CREACION", csTo.FECHA_CREACION);//**

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarContratosSuspendidosDAL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_CONTRATOS_SUSPENDIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", csTo.COD_SUCURSAL);//**
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", csTo.COD_INSTITUCION);//**
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);//**
            cmd.Parameters.AddWithValue("@FECHA_SUSPENSION", csTo.FECHA_SUSPENSION);//**
            cmd.Parameters.AddWithValue("@COD_PER", csTo.COD_PER);//**
            cmd.Parameters.AddWithValue("@COD_PTO_COB", csTo.COD_PTO_COB);//**
            cmd.Parameters.AddWithValue("@FECHA_INI_SUS", csTo.FECHA_INI_SUS);//**
            cmd.Parameters.AddWithValue("@FECHA_FIN_SUS", csTo.FECHA_FIN_SUS);//**
            cmd.Parameters.AddWithValue("@COD_MOTIVO", csTo.COD_MOTIVO);//**
            cmd.Parameters.AddWithValue("@OBSERVACIONES", csTo.OBSERVACIONES);//**
            cmd.Parameters.AddWithValue("@ST_SUSPENSION", csTo.ST_SUSPENSION);//**
            cmd.Parameters.AddWithValue("@ST_ANULACION", csTo.ST_ANULACION);//**
            cmd.Parameters.AddWithValue("@COD_MODIFICACION", csTo.COD_MODIFICACION);//**
            cmd.Parameters.AddWithValue("@FECHA_MODIFICACION", csTo.FECHA_MODIFICACION);//**

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarContratosSuspendidosDAL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CONTRATOS_SUSPENDIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", csTo.COD_SUCURSAL);//**
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", csTo.COD_INSTITUCION);//**
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);//**
            cmd.Parameters.AddWithValue("@FECHA_SUSPENSION", csTo.FECHA_SUSPENSION);//**

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool anularContratosSuspendidosDAL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ANULAR_CONTRATOS_SUSPENDIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", csTo.COD_SUCURSAL);//**
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", csTo.COD_INSTITUCION);//**
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);//**
            cmd.Parameters.AddWithValue("@FECHA_SUSPENSION", csTo.FECHA_SUSPENSION);//**
            cmd.Parameters.AddWithValue("@FECHA_ANULACION", csTo.FECHA_ANULACION);//**
            cmd.Parameters.AddWithValue("@COD_ANULACION", csTo.COD_ANULACION);//**
            cmd.Parameters.AddWithValue("@OBS_ANULACION", csTo.OBS_ANULACION);//**

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool desactivarContratosSuspendidosDAL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("DESACTIVAR_CONTRATOS_SUSPENDIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_SUSPENSION", csTo.FECHA_SUSPENSION);//**
            cmd.Parameters.AddWithValue("@ST_SUSPENSION", csTo.ST_SUSPENSION);//**
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool aprobarContratosSuspendidosDAL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("APROBAR_CONTRATOS_SUSPENDIDOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", csTo.COD_SUCURSAL);//**
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", csTo.COD_INSTITUCION);//**
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);//**
            cmd.Parameters.AddWithValue("@FECHA_SUSPENSION", csTo.FECHA_SUSPENSION);//**
            cmd.Parameters.AddWithValue("@COD_APROBACION", csTo.COD_APROBACION);//**
            cmd.Parameters.AddWithValue("@FECHA_APROBACION", csTo.FECHA_APROBACION);//**
            cmd.Parameters.AddWithValue("@ST_APROBACION", csTo.ST_APROBACION);//**
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool verificaExistenciaContratoSuspendidoDAL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTENCIA_CONTRATO_SUSPENDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", csTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA", csTo.FECHA_SUSPENSION);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
    }
}
