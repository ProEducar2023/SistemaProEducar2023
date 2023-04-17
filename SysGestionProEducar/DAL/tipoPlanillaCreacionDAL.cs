using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class tipoPlanillaCreacionDAL
    {
        SqlConnection conn;
        public tipoPlanillaCreacionDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerTipoPlanillaCreacionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TIPO_PLANILLA_CREACION", conn);
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
        public DataTable obtenerTipoPlanillaCreacionxStGeneracionDAL(tipoPlanillaCreacionTo tpllaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TIPO_PLANILLA_CREACION_ST_GENERACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATUS_GENERACION", tpllaTo.STATUS_GENERACION);
            cmd.Parameters.AddWithValue("@COD_VENTA", tpllaTo.COD_VENTA);
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
        public DataTable obtenerTipoPlanillaOperacionDAL(tipoPlanillaCreacionTo tpllaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TIPO_PLANILLA_OPERACION_ST_GENERACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATUS_GENERACION", tpllaTo.STATUS_GENERACION);
            cmd.Parameters.AddWithValue("@COD_VENTA", tpllaTo.COD_VENTA);
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

        public DataTable obtenerTipoPlanillaUbicacionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MUESTRA_TIPO_PLANILLA_UBICACION", conn);
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

        public DataTable obtenerTipoPlanillaCreacionGeneracionPllaDAL(tipoPlanillaCreacionTo tpllaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TIPO_PLANILLA_CREACION_GENERACION_PLLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATUS_CTACTE", tpllaTo.STATUS_CTACTE);
            cmd.Parameters.AddWithValue("@COD_VENTA", tpllaTo.COD_VENTA);
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
        public DataTable obtenerTipoPlanillaCreacionxTransferenciaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MUESTRA_TIPO_PLANILLA_TRANSFERENCIA", conn);
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
        public bool insertarTipoPlanillaCreacionDAL(tipoPlanillaCreacionTo tpllaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_TIPO_PLANILLA_CREACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", tpllaTo.CODIGO);
            cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", tpllaTo.COD_TIPO_PLLA);
            cmd.Parameters.AddWithValue("@COD_TIPO_OPERACION", tpllaTo.COD_TIPO_OPERACION);
            cmd.Parameters.AddWithValue("@DESC_TIPO", tpllaTo.DESC_TIPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", tpllaTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_VENTA", tpllaTo.COD_VENTA);
            cmd.Parameters.AddWithValue("@OBSERVACION", tpllaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_GENERACION", tpllaTo.STATUS_GENERACION);
            cmd.Parameters.AddWithValue("@STATUS_CTACTE", tpllaTo.STATUS_CTACTE);
            cmd.Parameters.AddWithValue("@COD_CREACION", tpllaTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FEC_CREACION", tpllaTo.FEC_CREACION);
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
        public bool modificarTipoPlanillaCreacionDAL(tipoPlanillaCreacionTo tpllaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_TIPO_PLANILLA_CREACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", tpllaTo.CODIGO);
            cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", tpllaTo.COD_TIPO_PLLA);
            cmd.Parameters.AddWithValue("@COD_TIPO_OPERACION", tpllaTo.COD_TIPO_OPERACION);
            cmd.Parameters.AddWithValue("@DESC_TIPO", tpllaTo.DESC_TIPO);
            cmd.Parameters.AddWithValue("@DESC_CORTA", tpllaTo.DESC_CORTA);
            cmd.Parameters.AddWithValue("@COD_VENTA", tpllaTo.COD_VENTA);
            cmd.Parameters.AddWithValue("@OBSERVACION", tpllaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_GENERACION", tpllaTo.STATUS_GENERACION);
            cmd.Parameters.AddWithValue("@STATUS_CTACTE", tpllaTo.STATUS_CTACTE);
            cmd.Parameters.AddWithValue("@COD_MODIFICACION", tpllaTo.COD_MODIFICACION);
            cmd.Parameters.AddWithValue("@FEC_MODIFICACION", tpllaTo.FEC_MODIFICACION);
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
        public bool eliminarTipoPlanillaCreacionDAL(tipoPlanillaCreacionTo tpllaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TIPO_PLANILLA_CREACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", tpllaTo.CODIGO);
            cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", tpllaTo.COD_TIPO_PLLA);
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

        public List<tipoPlanillaCreacionTo> ListarTipoVentaComision()
        {
            const string procedure = "dsp_ListarTipoVentaComision";
            try
            {
                List<tipoPlanillaCreacionTo> lista = new List<tipoPlanillaCreacionTo>();
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new tipoPlanillaCreacionTo
                    {
                        CODIGO = dr["CODIGO"].ToString(),
                        COD_TIPO_PLLA = dr["COD_TIPO_PLLA"].ToString(),
                        DESC_TIPO = dr["DESC_TIPO"].ToString(),
                        DESC_CORTA = dr["DESC_CORTA"].ToString()
                    });
                }
                return lista;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
