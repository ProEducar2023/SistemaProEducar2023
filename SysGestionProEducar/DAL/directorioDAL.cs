using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class directorioDAL
    {
        SqlConnection conn;
        public directorioDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerDirectorioDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECTORIO_TABLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public bool insertarDirectorioDAL(directorioTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DIRECTORIO_TABLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
            //cmd.Parameters.AddWithValue("@TIPO", dirTo.TIPO);
            //cmd.Parameters.AddWithValue("@CODIGO", dirTo.CODIGO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", dirTo.DESCRIPCION);
            cmd.Parameters.AddWithValue("@OBSERVACION", dirTo.OBSERVACION);
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
        public bool insertarDirectorioDatoDAL(directorioTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DIRECTORIO_DATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
            //cmd.Parameters.AddWithValue("@TIPO", dirTo.TIPO);
            cmd.Parameters.AddWithValue("@CODIGO", dirTo.CODIGO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", dirTo.DESCRIPCION);
            cmd.Parameters.AddWithValue("@OBSERVACION", dirTo.OBSERVACION);
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

        public DataTable obtenerCodigoDescripcionDirectorioDAL(directorioTo dirTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CODIGO_DESCRIPCION_DIRECTORIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
            cmd.Parameters.AddWithValue("@TIPO", dirTo.TIPO);
            cmd.Parameters.AddWithValue("@SUB_TIPO", DBNull.Value);

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
        public DataTable obtenerCodigoDescripcionDirectorioDirectaDAL(directorioTo dirTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CODIGO_DESCRIPCION_DIRECTORIO_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
            cmd.Parameters.AddWithValue("@TIPO", dirTo.TIPO);

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
        public bool modificarDirectorioDAL(directorioTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DIRECTORIO_TABLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tabla_cod", dirTo.TABLA_COD);
            //cmd.Parameters.AddWithValue("@TIPO", dirTo.TIPO);
            cmd.Parameters.AddWithValue("@CODIGO", dirTo.CODIGO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", dirTo.DESCRIPCION);
            cmd.Parameters.AddWithValue("@OBSERVACION", dirTo.OBSERVACION);
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
        public DataTable MOSTRAR_DIRECTORIO_DATO_DAL(directorioTo dirTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DIRECTORIO_DATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
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
        public DataTable MOSTRAR_MOTIVOS_RECEPCION_DESCUENTO_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_MOTIVOS_RECEPCION_DESCUENTO", conn);

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
        public int VERIFICAR_DIRECTORIO_TABLA_DAL(directorioTo dirTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_DIRECTORIO_TABLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
            try
            {
                conn.Open();
                val = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception)
            {
                val = -1;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public bool eliminarDirectorioDAL(directorioTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DIRECTORIO_TABLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
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
        public bool eliminarDirectorioDetDAL(directorioTo dirTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DIRECTORIO_TABLA_DET", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
            cmd.Parameters.AddWithValue("@CODIGO", dirTo.CODIGO);
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
        public decimal obtenerPorcentajeEvalContratoDAL()
        {
            decimal val = -1;
            SqlCommand cmd = new SqlCommand("MOSTRAR_PORCENTAJE_EVAL_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                val = Convert.ToDecimal(cmd.ExecuteScalar());

            }
            catch (Exception)
            {
                val = -1;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public string DIR_TABLA_DESC(directorioTo dirTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("DESC_TABLA_DIR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (dirTo.CODIGO == null)
                cmd.Parameters.AddWithValue("@CODIGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@CODIGO", dirTo.CODIGO);
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
            try
            {
                conn.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                val = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public DataTable MOSTRAR_APROBADORES_CAMBIO_PTO_COB_DAL(directorioTo dirTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_APROBADORES_CAMBIO_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABLA_COD", dirTo.TABLA_COD);
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

        public List<directorioTo> ListarDirectorioXParametros(directorioTo dir)
        {
            const string procedure = "dsp_ListarDirectorioParam";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@TABLA_COD", dir.TABLA_COD);
                _ = cmd.Parameters.AddWithValue("@TIPO", dir.TIPO);

                conn.Open();
                List<directorioTo> lstDir = new List<directorioTo>();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstDir.Add(new directorioTo
                        {
                            TABLA_COD = dr["TABLA_COD"].ToString(),
                            TIPO = dr["TIPO"].ToString(),
                            CODIGO = dr["CODIGO"].ToString(),
                            DESCRIPCION = dr["DESCRIPCION"].ToString(),
                            OBSERVACION = dr["OBSERVACION"].ToString(),
                            DESCRIP_CORTA = dr["DESCRIP_CORTA"].ToString()
                        });
                    }
                }
                return lstDir;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
