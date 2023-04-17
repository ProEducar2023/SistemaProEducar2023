using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class personaDAL
    {
        SqlConnection conn, conn2;
        public personaDAL()
        {
            conn = new SqlConnection(conexion.con);
            conn2 = new SqlConnection(conexion.con2);
        }
        public DataTable obtenerPersonaUsuariosCargoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_VENTA", conn);
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
        public DataTable obtenerPersonalPedidoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_PERSONAL_PEDIDO", conn);
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

        public DataTable obtenerTipoDocDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_TIPO_DOC_PERSONAL2", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn2.Open();
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
                conn2.Close();
            }
            return dt;
        }
        public string obtenerCodTipoDocDAL(string desc)
        {
            string str = "";
            SqlCommand cmd = new SqlCommand("COD_TIPO_DOC_PER", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DESC_TIPO", desc);
            try
            {
                conn2.Open();
                str = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                str = "";
            }
            finally
            {
                conn2.Close();
            }
            return str;
        }
        public bool insertaPersonaUsuariosCargoDAL(personaTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PERSONA_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", perTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", perTo.DESC_PER);
            cmd.Parameters.AddWithValue("@NOM", perTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PAT", perTo.PATERNO);
            cmd.Parameters.AddWithValue("@MAT", perTo.MATERNO);
            cmd.Parameters.AddWithValue("@COD_TIPO_DOC", perTo.COD_TIPO_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", perTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@MAIL", perTo.MAIL);
            cmd.Parameters.AddWithValue("@COD_USUARIO", perTo.COD_USUARIO);
            cmd.Parameters.AddWithValue("@NICK", perTo.NICK);
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
        public bool modificaPersonaUsuariosCargoDAL(personaTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PERSONA_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", perTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", perTo.DESC_PER);
            cmd.Parameters.AddWithValue("@NOM", perTo.NOMBRE);
            cmd.Parameters.AddWithValue("@PAT", perTo.PATERNO);
            cmd.Parameters.AddWithValue("@MAT", perTo.MATERNO);
            cmd.Parameters.AddWithValue("@COD_TIPO_DOC", perTo.COD_TIPO_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", perTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@MAIL", perTo.MAIL);
            cmd.Parameters.AddWithValue("@COD_USUARIO", perTo.COD_USUARIO);
            cmd.Parameters.AddWithValue("@NICK", perTo.NICK);
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

        public DataTable ObtenerSubUbicacion(string table, string tipo, string codigo, string codNivel)
        {
            const string function = "SELECT * FROM fn_ObtenerSubUbicacion(@TABLE,@TIPO,@CODIGO,@COD_NIVEL)";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@TABLE", table);
                cmd.Parameters.AddWithValue("@TIPO", tipo);
                cmd.Parameters.AddWithValue("@CODIGO", codigo);
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

        public DataTable obtenerGestoresUbicacionDAL(personaTo perTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_GESTORES_COBRANZA_UBICACION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (perTo.CODIGO == null)
                cmd.Parameters.AddWithValue("@CODIGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@CODIGO", perTo.CODIGO);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable obtenerGestoresUbicacionDirectaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_GESTORES_COBRANZA_UBICACION_PD", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
        public bool eliminaPersonaUsuariosDAL(personaTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PERSONA_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", perTo.COD_PER);
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
        public DataTable obtenerCargoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CARGO_VENTA", conn);
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
        public DataTable obtenerEquipoVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_VENTA", conn);
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
        public DataTable obtieneCargoporUsuarioDAL(personaTo perTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_equipo_venta", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", perTo.COD_PER);
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
        public bool insertaCargoPersonaUsuariosCargoDAL(personaTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_EQUIPO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", perTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CARGO", perTo.COD_TIPO_DOC);
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
        public string obtenerCodCargoVentaDAL(personaTo perTo)
        {
            string cad = string.Empty;
            SqlCommand cmd = new SqlCommand("cod_CARGO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DESC_CARGO", perTo.DESC_PER);
            try
            {
                conn.Open();
                cad = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                cad = "";
            }
            finally
            {
                conn.Close();
            }
            return cad;
        }
        public DataTable obtenerUsuariosparaDesaprobarDAL(string TABLA_COD, string COD_MOD)
        {
            DataTable dt = new DataTable();
            //string text = "SELECT CODIGO,DESCRIPCION FROM DIRECTORIO WHERE TABLA_COD=@TABLA_COD AND SUBSTRING(CODIGO,0,4)=@COD_MOD AND TIPO<>'T'";
            string text = "SELECT CODIGO,DESCRIPCION FROM DIRECTORIO WHERE TABLA_COD=@TABLA_COD AND TIPO<>'T'";
            SqlCommand cmd = new SqlCommand(text, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@COD_MOD", COD_MOD);
            cmd.Parameters.AddWithValue("@TABLA_COD", TABLA_COD);
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
        public DataTable obtenerUsuariosparaDesaprobarVentasDAL()
        {
            DataTable dt = new DataTable();
            //string text = "SELECT CODIGO,DESCRIPCION FROM DIRECTORIO WHERE TABLA_COD=@TABLA_COD AND SUBSTRING(CODIGO,0,4)=@COD_MOD AND TIPO<>'T'";
            SqlCommand cmd = new SqlCommand("MOSTRAR_DESAPROBADORES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@COD_MOD",COD_MOD);
            //cmd.Parameters.AddWithValue("@TABLA_COD",TABLA_COD);
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
        public string ValidarUsuarioEliminacionAnulacionDAL(string claveEncriptada, string usuarioNick)
        {
            string usuario = "";
            object us = null;
            //string texto = "select Cod_usu from USUARIO where Cod_usu=@Clave AND Nick=@USUARIO";
            string texto = "select Cod_usu from USUARIO where Clave=@Clave AND Nick=@USUARIO";//revisar la encriptacion
            SqlCommand cmd = new SqlCommand(texto, conn2);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Clave", claveEncriptada);
            cmd.Parameters.AddWithValue("@USUARIO", usuarioNick);
            try
            {
                conn2.Open();
                us = cmd.ExecuteScalar();
                if (us != null)
                    usuario = us.ToString();
                else
                    usuario = "";
            }
            catch (Exception)
            {
                usuario = "";
            }
            finally
            {
                conn2.Close();
            }
            return usuario;
        }
        public int ValidarDirectorioDesaprobarDAL(string codigo, string MODULO)
        {
            int usuario = -1;
            //string texto = "select COUNT(*) from DIRECTORIO where TABLA_COD='TA_D' AND TIPO<>'T' AND SUBSTRING(CODIGO,0,4)=@COD_MOD AND SUBSTRING(CODIGO,4,4)=@CODIGO";
            string texto = "select COUNT(*) from DIRECTORIO where TABLA_COD='TA_D' AND TIPO<>'T'";
            SqlCommand cmd = new SqlCommand(texto, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CODIGO", codigo);
            cmd.Parameters.AddWithValue("@COD_MOD", MODULO);
            try
            {
                conn.Open();
                usuario = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                usuario = -1;
            }
            finally
            {
                conn.Close();
            }
            return usuario;
        }
        public bool eliminarCargoPersonaUsuariosCargoDAL(personaTo perTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_EQUIPO_VENTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", perTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CARGO", perTo.COD_TIPO_DOC);
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
        public DataTable obtenerPersonaparaReporteDAL(personaTo perTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_PARA_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLASE", perTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_CAT", perTo.COD_CAT);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
        public DataTable obtenerPersonaxCodPerDAL(personaTo perTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONA_X_COD_PER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", perTo.COD_PER);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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
        public DataTable obtenerGestoresDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_GESTORES_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
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

        public DataTable ObtenerMaestroPersonaProgNivel()
        {
            const string function = "SELECT * FROM fn_ListarMaestroPersonaProgNivel()";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable ObtenerMaestroPersonaXNivel(string codNivel)
        {
            const string function = "SELECT * FROM fn_ListarMaestroPersonaProgNivel() WHERE COD_NIVEL = @COD_NIVEL";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("COD_NIVEL", codNivel);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        
        public DataTable ObtenerGestoresXAreaTrabajo()
        {
            const string function = "SELECT * FROM fn_ObtenerGestoresXAreaTrabajo()";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

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

        public DataTable ObtenerVendedoresXSupervisor(string codSupervisor)
        {
            const string function = "usp_ObtenerVendedoresXSupervisor";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUPERVISOR", codSupervisor);

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

        public DataTable ObtenerPersonaNivelVentaHijoXPadre(string codDirNacional, string codDirVentas, string codSupervisor, string codNivelMostrar)
        {
            const string function = "dsp_ObtenerPersonasNivelHijoXPadre";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_DIR_NACIONAL", codDirNacional);
                _ = cmd.Parameters.AddWithValue("@COD_DIR_VNTAS", codDirVentas);
                _ = cmd.Parameters.AddWithValue("@COD_SUPERVISOR", codSupervisor);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL_MOSTRAR", codNivelMostrar);

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

        /// <summary>
        /// Obtiene vendedores por superior(supervisor, director de ventas, director nacional)
        /// </summary>
        /// <param name="codSuperior">código de superior(supervisor, director de ventas, director nacional)</param>
        /// <param name="codNivel">código de nivel de superior(supervisor, director de ventas, director nacional)</param>
        /// <returns>Lista de vendedores en DataTable</returns>
        public DataTable ObtenerVendedoresXSuperior(string codSuperior, string codNivel)
        {
            const string procedure = "dsp_ObtenerVendedoresXSuperior";
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@COD_SUPERIOR", codSuperior);
                _ = cmd.Parameters.AddWithValue("@COD_NIVEL_SUPERIOR", codNivel);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public DataTable ObtenerMaestroPersonaXNivelSinAnonimos(string codNivel)
        {
            const string function = "SELECT * FROM fn_ListarMaestroPersonaProgNivel() a " +
                                    "LEFT JOIN VPERSONA_ANONIMO p ON(p.COD_PER = a.COD_PER) " +
                                    "WHERE a.COD_NIVEL = @COD_NIVEL AND p.COD_PER IS NULL";
            try
            {
                SqlCommand cmd = new SqlCommand(function, conn)
                {
                    CommandType = CommandType.Text
                };

                _ = cmd.Parameters.AddWithValue("@COD_NIVEL", codNivel);

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
