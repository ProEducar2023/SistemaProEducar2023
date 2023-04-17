using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class serieDocumentosDAL
    {
        SqlConnection conn;
        public serieDocumentosDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerSerieDocumentoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_SERIE_DOC", conn);
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
        public bool insertarSerieDocumentoDAL(serieDocumentosTo sdoTo, ref string errMensaje)
        {
            bool flag = false;
            //SqlCommand cmd = new SqlCommand("INSERTAR_MOVIMIENTOS_SERIE", conn);
            SqlCommand cmd = new SqlCommand("INSERTAR_SERIE_DOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdoTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@STATUS_DOC", sdoTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", sdoTo.COD_DOC);
            cmd.Parameters.AddWithValue("@SERIE", sdoTo.SERIE);
            cmd.Parameters.AddWithValue("@NUMERO", sdoTo.NUMERO);
            cmd.Parameters.AddWithValue("@COD_OPCION", sdoTo.COD_OPCION);
            cmd.Parameters.AddWithValue("@STATUS_SERIE", sdoTo.STATUS_SERIE);
            cmd.Parameters.AddWithValue("@STATUS_BLOQUE", sdoTo.STATUS_BLOQUE);
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
        public bool modificarSerieDocumentoDAL(serieDocumentosTo sdoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_SERIE_DOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdoTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@status_doc", sdoTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", sdoTo.COD_DOC);
            cmd.Parameters.AddWithValue("@SERIE", sdoTo.SERIE);
            cmd.Parameters.AddWithValue("@NUMERO", sdoTo.NUMERO);
            cmd.Parameters.AddWithValue("@COD_OPCION", sdoTo.COD_OPCION);
            cmd.Parameters.AddWithValue("@STATUS_SERIE", sdoTo.STATUS_SERIE);
            cmd.Parameters.AddWithValue("@STATUS_BLOQUE", sdoTo.STATUS_BLOQUE);
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
        public bool eliminarSerieDocumentoDAL(serieDocumentosTo sdoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_SERIE_DOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdoTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@status_doc", sdoTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", sdoTo.COD_DOC);
            cmd.Parameters.AddWithValue("@SERIE", sdoTo.SERIE);
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
        public int obtenerNro_IngDAL(serieDocumentosTo sdoTo)
        {
            int valor = -1;
            SqlCommand cmd = new SqlCommand("HALLAR_NRO_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdoTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@SERIE", sdoTo.SERIE);
            cmd.Parameters.AddWithValue("@COD_DOC", sdoTo.COD_DOC);
            try
            {
                conn.Open();
                valor = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                valor = -1;
            }
            finally
            {
                conn.Close();
            }
            return valor;
        }
        public string obtenerNro_Ing2DAL(serieDocumentosTo sdoTo)
        {
            string valor = "";
            SqlCommand cmd = new SqlCommand("HALLAR_NRO_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdoTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@SERIE", sdoTo.SERIE);
            cmd.Parameters.AddWithValue("@COD_DOC", sdoTo.COD_DOC);
            try
            {
                conn.Open();
                valor = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                valor = "";
            }
            finally
            {
                conn.Close();
            }
            return valor;
        }
        public string HALLAR_NRO_ACTUAL(serieDocumentosTo sdoTo)
        {
            string valor = "";
            SqlCommand cmd = new SqlCommand("HALLAR_NRO_ACTUAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdoTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_DOC", sdoTo.COD_DOC);
            cmd.Parameters.AddWithValue("@STATUS_DOC", sdoTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@SERIE", sdoTo.SERIE);
            try
            {
                conn.Open();
                valor = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                valor = "";
            }
            finally
            {
                conn.Close();
            }
            return valor;
        }
        public DataTable OBTENER_SERIE_NRO_DAL(serieDocumentosTo sdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_SERIE_NRO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@STATUS_DOC", sdTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", sdTo.COD_DOC);
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

        public bool adicionaNroSerieDAL(serieDocumentosTo sdTo, ref string errMensaje)
        {
            bool flag = false; ;
            SqlCommand cmd = new SqlCommand("AUMENTA_NRO_SERIE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@STATUS_DOC", sdTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", sdTo.COD_DOC);
            cmd.Parameters.AddWithValue("@SERIE", sdTo.SERIE);
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

        public bool adicionaNroSerieDAL(serieDocumentosTo sdTo, SqlConnection con, ref string errMensaje)
        {
            bool flag = false; ;
            SqlCommand cmd = new SqlCommand("AUMENTA_NRO_SERIE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@STATUS_DOC", sdTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", sdTo.COD_DOC);
            cmd.Parameters.AddWithValue("@SERIE", sdTo.SERIE);
            try
            {
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            return flag;
        }

        public bool AdicionaNroSerieDAL(serieDocumentosTo sdTo, SqlConnection con, SqlTransaction tr)
        {
            using (SqlCommand cmd = new SqlCommand("dsp_AUMENTA_NRO_SERIE", con, tr))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdTo.COD_SUCURSAL);
                cmd.Parameters.AddWithValue("@STATUS_DOC", sdTo.STATUS_DOC);
                cmd.Parameters.AddWithValue("@COD_DOC", sdTo.COD_DOC);
                cmd.Parameters.AddWithValue("@SERIE", sdTo.SERIE);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int verificaSerieDocumentoDAL(serieDocumentosTo sdoTo)
        {
            int valor = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_SERIE_DOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdoTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@STATUS_DOC", sdoTo.STATUS_DOC);
            cmd.Parameters.AddWithValue("@COD_DOC", sdoTo.COD_DOC);
            cmd.Parameters.AddWithValue("@SERIE", sdoTo.SERIE);
            cmd.Parameters.AddWithValue("@NUMERO", sdoTo.NUMERO);
            try
            {
                conn.Open();
                valor = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                valor = -1;
            }
            finally
            {
                conn.Close();
            }
            return valor;
        }
        public DataTable CBO_NRO_NOTAS_TRANS(serieDocumentosTo sdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_NRO_NOTAS_TRANS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdTo.COD_SUCURSAL);
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
        public DataTable obtenerSerieDocumentoparaFacturacionDAL(serieDocumentosTo sdTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_SERIE_DOC_SUNAT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_DOC", sdTo.COD_DOC);
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
        public int obtenerNumeroSerieDocumentoparaFacturacionDAL(serieDocumentosTo sdTo)
        {
            int num = -1;
            SqlCommand cmd = new SqlCommand("HALLAR_NRO_SERIE_SUNAT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", sdTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@SERIE", sdTo.SERIE);
            cmd.Parameters.AddWithValue("@COD_DOC", sdTo.COD_DOC);
            try
            {
                conn.Open();
                num = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                num = -1;
            }
            finally
            {
                conn.Close();
            }
            return num;
        }

        public serieDocumentosTo ObtenerSerieDocumentoTo(string codTipoPla, SqlConnection con)
        {
            const string procedure = "dsp_ObtenerSerieDocumento";
            SqlDataReader dr = null;
            try
            {
                serieDocumentosTo serieDocumentosTo = null;
                SqlCommand cmd = new SqlCommand(procedure, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPla);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return serieDocumentosTo = new serieDocumentosTo
                    {
                        COD_DOC = dr["COD_DOC"].ToString(),
                        COD_OPCION = dr["COD_OPCION"].ToString(),
                        COD_SUCURSAL = dr["COD_SUCURSAL"].ToString(),
                        STATUS_BLOQUE = dr["STATUS_BLOQUE"].ToString(),
                        SERIE = dr["SERIE"].ToString(),
                        NUMERO = dr["NUMERO"].ToString(),
                        STATUS_DOC = dr["STATUS_DOC"].ToString(),
                        STATUS_SERIE = dr["STATUS_SERIE"].ToString()
                    };
                }
                return serieDocumentosTo;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
        }

        public serieDocumentosTo ObtenerSerieDocumentoTo(string codTipoPla, SqlConnection con, SqlTransaction tr)
        {
            const string procedure = "dsp_ObtenerSerieDocumento";
            SqlDataReader dr = null;
            try
            {
                serieDocumentosTo serieDocumentosTo = null;
                SqlCommand cmd = new SqlCommand(procedure, con, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_TIPO_PLLA", codTipoPla);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return serieDocumentosTo = new serieDocumentosTo
                    {
                        COD_DOC = dr["COD_DOC"].ToString(),
                        COD_OPCION = dr["COD_OPCION"].ToString(),
                        COD_SUCURSAL = dr["COD_SUCURSAL"].ToString(),
                        STATUS_BLOQUE = dr["STATUS_BLOQUE"].ToString(),
                        SERIE = dr["SERIE"].ToString(),
                        NUMERO = dr["NUMERO"].ToString(),
                        STATUS_DOC = dr["STATUS_DOC"].ToString(),
                        STATUS_SERIE = dr["STATUS_SERIE"].ToString()
                    };
                }
                return serieDocumentosTo;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
        }

        public serieDocumentosTo ObtenerCorrelativoDoc(serieDocumentosTo doc, SqlConnection con, SqlTransaction tr)
        {
            const string procedure = "dsp_ObtenerCorrelativoDoc";
            SqlDataReader dr = null;
            try
            {
                serieDocumentosTo serieDocumentosTo = null;
                SqlCommand cmd = new SqlCommand(procedure, con, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUCURSAL", doc.COD_SUCURSAL);
                _ = cmd.Parameters.AddWithValue("@COD_DOC", doc.COD_DOC);
                _ = cmd.Parameters.AddWithValue("@SERIE", doc.SERIE);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return serieDocumentosTo = new serieDocumentosTo
                    {
                        COD_DOC = dr["COD_DOC"].ToString(),
                        COD_OPCION = dr["COD_OPCION"].ToString(),
                        COD_SUCURSAL = dr["COD_SUCURSAL"].ToString(),
                        STATUS_BLOQUE = dr["STATUS_BLOQUE"].ToString(),
                        SERIE = dr["SERIE"].ToString(),
                        NUMERO = dr["NUMERO"].ToString(),
                        STATUS_DOC = dr["STATUS_DOC"].ToString(),
                        STATUS_SERIE = dr["STATUS_SERIE"].ToString()
                    };
                }
                return serieDocumentosTo;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
        }
    }
}
