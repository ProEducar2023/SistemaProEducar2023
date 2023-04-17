using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class HelpersDAL
    {
        SqlConnection conn, conn2;
        public HelpersDAL()
        {
            conn = new SqlConnection(conexion.con);
            conn2 = new SqlConnection(conexion.con2);
        }
        public DataTable obtenerTipo_Doc_PersonalDAL()
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
        public DataTable obtenerTipo_PersonaDAL()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("des", typeof(string));
            DataRow rw = dt.NewRow();
            rw["cod"] = "N";
            rw["des"] = "NATURAL";
            dt.Rows.Add(rw);
            //
            DataRow rw1 = dt.NewRow();
            rw1["cod"] = "J";
            rw1["des"] = "JURIDICA";
            dt.Rows.Add(rw1);
            //
            DataRow rw2 = dt.NewRow();
            rw2["cod"] = "D";
            rw2["des"] = "SUJETOS NO DOMICILIADOS";
            dt.Rows.Add(rw2);

            return dt;
        }
        public DataTable obtenerTipo_FonoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_TIPO_FONO2", conn2);
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
        public DataTable obtenerPaisDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_PAIS2", conn2);
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
        public DataTable obtenerDepartamentoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_DEP2", conn2);
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
        public DataTable obtenerPro_PaisDAL(HelpersTo helTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_PRO_DEP2", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DEP", helTo.CODIGO);
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
        public DataTable obtenerDist_Pro_PaisDAL(HelpersTo helTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_DIST_PRO_DEP2", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DEP", helTo.CODIGO);
            cmd.Parameters.AddWithValue("@COD_PRO", helTo.CODIGO2);
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
        public DataTable obtenerTIpo_DirDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_TIPO_DIR2", conn2);
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
        public DataTable obtenerClaseDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CLASE_PER2", conn2);
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
        public DataTable obtenerCategoriaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CAT_PER2", conn2);
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
        public DataTable obtenerFormaPagoDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_FORMAS_PAGO2", conn2);
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
        public DataTable obtenerCondicionVentaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CONDICION_VENTA2", conn2);
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
        public DataTable obtenerFormaPago_PER_CL_CAT_DAL(HelpersTo helTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_FORMA_PAGO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", helTo.CODIGO);//Codigo Per
            cmd.Parameters.AddWithValue("@COD_CLASE", helTo.CODIGO2);//Codigo Clase
            cmd.Parameters.AddWithValue("@COD_CAT", helTo.CODIGO3);//Codigo Categoria
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
        public DataTable CBO_CLASE_USU_TIPO_DAL(HelpersTo helTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CLASE_TIPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_USU", helTo.CODIGO);//Codigo Per
            cmd.Parameters.AddWithValue("@COD_USU", helTo.CODIGO2);//Codigo Clase
            cmd.Parameters.AddWithValue("@ST_TIPO", helTo.CODIGO3);//Codigo Categoria
            cmd.Parameters.AddWithValue("@TIPO", helTo.CODIGO4);
            cmd.Parameters.AddWithValue("@ST_D_H", helTo.CODIGO5);
            cmd.Parameters.AddWithValue("@COD_D_H", helTo.CODIGO6);
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
        public DataTable CBO_SUCURSALDAL(HelpersTo helTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_SUCURSAL_USU", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_USU", helTo.CODIGO);
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
        public DataTable MOSTRAR_PERSONAS_XCOBRAR_DAL(HelpersTo helTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_XCOBRAR", conn);
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
        public DataTable MOSTRAR_PERSONAS_XPAGAR_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_XPAGAR", conn);
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
        public DataTable MOSTRAR_PERSONAS_XPAGAR_PERSONAL_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_XPAGAR_PERSONAL", conn);
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
        public DataTable obtenerMonedaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_MONEDA_VTA", conn2);
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
        public string obtenerTipoCambioDAL(string annio, string mes, string dia, string cod_mon)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("sacar_cambio", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@año", annio);
            cmd.Parameters.AddWithValue("@mes", mes);
            cmd.Parameters.AddWithValue("@dia", dia);
            cmd.Parameters.AddWithValue("@tipo", cod_mon);
            try
            {
                conn2.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "";
            }
            finally
            {
                conn2.Close();
            }
            return val;
        }
        public decimal obtenerImpuestoDAL(string CODIGO)
        {
            decimal val = -1;
            SqlCommand cmd = new SqlCommand("HALLAR_IMPUESTO", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", CODIGO);
            try
            {
                conn2.Open();
                val = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                val = -1;
            }
            finally
            {
                conn2.Close();
            }
            return val;
        }
        public bool insertarBulkCopyDAL(DataTable dt, ref string errMensaje)
        {
            bool flag = false;
            try
            {
                conn.Open();
                int num = dt.Rows.Count - 1;
                SqlBulkCopy copy = new SqlBulkCopy(conn);
                copy.BatchSize = num;
                copy.DestinationTableName = "dbo.[T_PRESUPUESTO2]";
                copy.WriteToServer(dt);
                dt.Rows.Clear();
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
        public string NRO_DIAS_CONDICION_VENTADAL(string cod_ven)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("MOSTRAR_NRO_DIAS_CONDICION_VENTA", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_TIPO", cod_ven);
            try
            {
                conn2.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "";
            }
            finally
            {
                conn2.Close();
            }
            return val;
        }
        public DataTable obtenerDesc_Doc_GestionDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("cbo_tipo_doc", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn2.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception e)
            {
                dt = null;
            }
            finally
            {
                conn2.Close();
            }
            return dt;
        }

        public string SACAR_CAMBIO(string annio, string mes, string dia, string tipo)
        {
            string valor = "";
            SqlCommand cmd = new SqlCommand("sacar_cambio", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@año", annio);
            cmd.Parameters.AddWithValue("@mes", mes);
            cmd.Parameters.AddWithValue("@dia", dia);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            try
            {
                conn2.Open();
                valor = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                valor = "";
            }
            finally
            {
                conn2.Close();
            }
            return valor;

        }
        public bool ELIMINAR_TEMPORAL(string tipo, string nombre_pc, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_TEMPORAL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO", tipo);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", nombre_pc);
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
        public string ValidarUsuarioEliminacionAnulacionDAL(string claveEncriptada, string usuarioNick)
        {
            string usuario = "";
            object us = null;
            //string texto = "select Cod_usu from USUARIO where Clave='"+claveEncriptada+"' AND Nick='"+usuarioNick+"'";
            string texto = "select Cod_usu from USUARIO where Clave=@Clave AND Nick=@USUARIO";
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
            string texto = "select COUNT(*) from DIRECTORIO where TABLA_COD='TA_D' AND TIPO<>'T' AND SUBSTRING(CODIGO,0,4)=@COD_MOD AND SUBSTRING(CODIGO,4,4)=@CODIGO";
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
        public DataTable CARGAR_LABEL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_LABELS", conn);
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
        public DataTable CBO_CLASE_USU_TIPO(bool validarTipo, string TIPO_USU, string COD_USU, string tipo = "", bool validarDebeHaber = false, string debeHaber = "")
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CBO_CLASE_TIPO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_USU", TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", COD_USU);
            cmd.Parameters.AddWithValue("@ST_TIPO", validarTipo ? "0" : "1");
            cmd.Parameters.AddWithValue("@TIPO", tipo);
            cmd.Parameters.AddWithValue("@ST_D_H", validarDebeHaber ? "0" : "1");
            cmd.Parameters.AddWithValue("@COD_D_H", debeHaber);
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
        public string COD_D_H(string COD_DOC)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("d_h_COD_DOC", conn2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_DOC", COD_DOC);
            try
            {
                conn2.Open();
                val = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "";
            }
            finally
            {
                conn2.Close();
            }
            return val;
        }
        public DataTable MOSTRAR_PERSONAS_X_DEVOLUCION_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_X_DEVOLUCION", conn);
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
        public DataTable MOSTRAR_PERSONAS_X_DEVOLUCION_TODOS_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_X_DEVOLUCION_TODOS", conn);
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
        public DataTable MOSTRAR_PERSONAS_X_DSCTO_DIRECTA_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_X_DSCTO_DIRECTA", conn);
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
        public DataTable MOSTRAR_PERSONAS_PARA_CAMBIO_PTO_COB_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_PARA_CAMBIO_PTO_COB", conn);
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
        public DataTable MOSTRAR_PERSONAS_X_AUMENTAR_CUOTA_DAL(HelpersTo helTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_X_AUMENTAR_CUOTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", helTo.CODIGO);
            //cmd.Parameters.AddWithValue("@COD_SECTORISTA", helTo.CODIGO2);
            //cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", helTo.CODIGO3);
            //cmd.Parameters.AddWithValue("@TIPO_PLLA", helTo.CODIGO4);
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
        public DataTable MOSTRAR_PERSONAS_X_CONSULTA_KARDEX_DAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_X_CONSULTA_KARDEX", conn);
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
    }
}
