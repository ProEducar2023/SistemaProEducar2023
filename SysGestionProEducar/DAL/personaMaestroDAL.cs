using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaMaestroDAL
    {
        SqlConnection conn;
        public personaMaestroDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerMaestroPersonaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA", conn);
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
        public DataTable obtenerMaestroPersonaporCOD_PERDAL(personaMaestroTo pemTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_POR_COD_PER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pemTo.COD_PER);
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
        public string obtenerNombrePersonaporCOD_PERDAL(personaMaestroTo pemTo)
        {
            string valor = "";
            SqlCommand cmd = new SqlCommand("MOSTRAR_NOMBREPERSONA_POR_COD_PER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pemTo.COD_PER);
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
        public bool insertarMaestroPersonaDAL(personaMaestroTo pemTo, ref string cod_persona, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PERSONA2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pemTo.COD_PER);
            cmd.Parameters.AddWithValue("@TIPO_PER", pemTo.TIPO_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", pemTo.DESC_PER);
            cmd.Parameters.AddWithValue("@NOM", pemTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PAT", pemTo.PATERNO);
            cmd.Parameters.AddWithValue("@MAT", pemTo.MATERNO);
            cmd.Parameters.AddWithValue("@COD_TIPO_DOC", pemTo.COD_TIPO_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", pemTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@MAIL", pemTo.MAIL);
            cmd.Parameters.AddWithValue("@NRO_BENEFICIARIOS", pemTo.NRO_BENEFICIARIOS);
            cmd.Parameters.AddWithValue("@NOM_COMERCIAL", pemTo.NOM_COMERCIAL);
            cmd.Parameters.AddWithValue("@NOM_AVAL", pemTo.NOM_AVAL);
            cmd.Parameters.AddWithValue("@NRO_DOC_AVAL", pemTo.NRO_DOC_AVAL);
            cmd.Parameters.AddWithValue("@DIR_AVAL", pemTo.DIR_AVAL);
            cmd.Parameters.AddWithValue("@FONO_AVAL", pemTo.FONO_AVAL);
            cmd.Parameters.AddWithValue("@ST_CONTRIBUYENTE", pemTo.ST_CONTRIBUYENTE);
            cmd.Parameters.AddWithValue("@ST_RETENEDOR", pemTo.ST_RETENEDOR);
            cmd.Parameters.AddWithValue("@ST_PERCEPTOR", pemTo.ST_PERCEPTOR);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pemTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_IDENTIDAD", pemTo.COD_IDENTIDAD);
            cmd.Parameters.AddWithValue("@DES_IDENTIDAD", pemTo.DES_IDENTIDAD);
            cmd.Parameters.AddWithValue("@COD_PROCESO", pemTo.COD_PROCESO);
            cmd.Parameters.AddWithValue("@DES_PROCESO", pemTo.DES_PROCESO);
            cmd.Parameters.AddWithValue("@COD_SITUACION", pemTo.COD_SITUACION);
            cmd.Parameters.AddWithValue("@COD_USUARIO", pemTo.COD_USUARIO);
            cmd.Parameters.AddWithValue("@PWD_USUARIO", pemTo.PWD_USUARIO);
            cmd.Parameters.AddWithValue("@COD_CARGO", pemTo.COD_CARGO);
            cmd.Parameters.AddWithValue("@COD_VIVIENDA", pemTo.COD_VIVIENDA);
            cmd.Parameters.AddWithValue("@COD_CONDICION", pemTo.COD_CONDICION);
            cmd.Parameters.AddWithValue("@IMAGEN", pemTo.IMAGEN);
            SqlParameter param = new SqlParameter("@COD_PER_REAL", SqlDbType.VarChar, 5);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
                cod_persona = param.Value.ToString();
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
        public bool modificarMaestroPersonaDAL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PERSONA2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pemTo.COD_PER);
            cmd.Parameters.AddWithValue("@TIPO_PER", pemTo.TIPO_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", pemTo.DESC_PER);
            cmd.Parameters.AddWithValue("@NOM", pemTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PAT", pemTo.PATERNO);
            cmd.Parameters.AddWithValue("@MAT", pemTo.MATERNO);
            cmd.Parameters.AddWithValue("@COD_TIPO_DOC", pemTo.COD_TIPO_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", pemTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@MAIL", pemTo.MAIL);
            cmd.Parameters.AddWithValue("@NRO_BENEFICIARIOS", pemTo.NRO_BENEFICIARIOS);
            cmd.Parameters.AddWithValue("@NOM_COMERCIAL", pemTo.NOM_COMERCIAL);
            cmd.Parameters.AddWithValue("@NOM_AVAL", pemTo.NOM_AVAL);
            cmd.Parameters.AddWithValue("@NRO_DOC_AVAL", pemTo.NRO_DOC_AVAL);
            cmd.Parameters.AddWithValue("@DIR_AVAL", pemTo.DIR_AVAL);
            cmd.Parameters.AddWithValue("@FONO_AVAL", pemTo.FONO_AVAL);
            cmd.Parameters.AddWithValue("@ST_CONTRIBUYENTE", pemTo.ST_CONTRIBUYENTE);
            cmd.Parameters.AddWithValue("@ST_RETENEDOR", pemTo.ST_RETENEDOR);
            cmd.Parameters.AddWithValue("@ST_PERCEPTOR", pemTo.ST_PERCEPTOR);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pemTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_IDENTIDAD", pemTo.COD_IDENTIDAD);
            cmd.Parameters.AddWithValue("@DES_IDENTIDAD", pemTo.DES_IDENTIDAD);
            cmd.Parameters.AddWithValue("@COD_PROCESO", pemTo.COD_PROCESO);
            cmd.Parameters.AddWithValue("@DES_PROCESO", pemTo.DES_PROCESO);
            cmd.Parameters.AddWithValue("@COD_SITUACION", pemTo.COD_SITUACION);
            cmd.Parameters.AddWithValue("@COD_USUARIO", pemTo.COD_USUARIO);
            cmd.Parameters.AddWithValue("@COD_CARGO", pemTo.COD_CARGO);
            cmd.Parameters.AddWithValue("@COD_VIVIENDA", pemTo.COD_VIVIENDA);
            cmd.Parameters.AddWithValue("@COD_CONDICION", pemTo.COD_CONDICION);
            cmd.Parameters.AddWithValue("@PWD_USUARIO", pemTo.PWD_USUARIO);
            cmd.Parameters.AddWithValue("@IMAGEN", pemTo.IMAGEN);
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
        public bool eliminarMaestroPersonaDAL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PERSONA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pemTo.COD_PER);

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
        public bool verificaCodigoIdentidadDAL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_MAESTRO_PERSONA_COD_IDENTIDAD", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_IDENTIDAD", pemTo.COD_IDENTIDAD);
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
        public bool verificaNroRucDniPersonaDAL(personaMaestroTo pemTo, ref bool val, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_MAESTRO_PERSONA_NRO_DOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_DOC", pemTo.NRO_DOC);
            try
            {
                conn.Open();
                val = Convert.ToBoolean(cmd.ExecuteScalar());
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
        public string obtenerNuevoCodPerDAL()
        {
            string valor = "";
            SqlCommand cmd = new SqlCommand("OBTENER_NUEVO_COD_PER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public bool modificaMaestroPersonaxCambioPtoCobDAL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_MAESTRO_PERSONA_X_CAMBIO_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pemTo.COD_PER);
            cmd.Parameters.AddWithValue("@DES_PROCESO", pemTo.DES_PROCESO);

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

        public DataTable ListarMaestroPersonaXNivel(string codNivel)
        {
            try
            {
                const string function = "SELECT * FROM fn_ListarMaestroPersonaXNivel(@COD_NIVEL)";
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@COD_NIVEL", codNivel);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ObtenerPersonasXPuntoCobranza(string codPtoCob)
        {
            try
            {
                const string procedure = "dsp_ObtenerPersonasXPuntoCobranza";
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
