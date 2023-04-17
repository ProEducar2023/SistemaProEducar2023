using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class puntoCobranzaDAL
    {
        SqlConnection conn;
        public puntoCobranzaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }

        private const int TIME_OUT_1 = 7000;

        public DataTable obtenerTodosPuntosCobranzaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_TODOS_PUNTOS_COBRANZA", conn);
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
        public DataTable obtenerPuntosCobranzaVisaDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PTO_COBRANZA_VISA", conn);
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
        public DataTable obtenerPuntosCobranzaDAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_COBRANZA_CONSOLIDADOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", ptoTo.STATUS_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptoTo.COD_INSTITUCION);
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
        public DataTable obtenerPuntosCobranza_x_Inst_DAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_COBRANZA_X_INSTITUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (ptoTo.STATUS_CONSOLIDADO == null)
                cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", ptoTo.STATUS_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptoTo.COD_INSTITUCION);
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
        public DataTable obtenerPuntosCobranzaConsolidadoInformativoDAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_COBRANZA_CONSOLIDADOS_INFORMATIVO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO_INFORMATIVO", ptoTo.STATUS_CONSOLIDADO_INFORMATIVO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptoTo.COD_INSTITUCION);
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
        public DataTable obtenerPuntosCobranzaConsolidadoInformativo_x_Inst_DAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_COBRANZA_CONSOLIDADOS_INFORMATIVO_X_INST", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO_INFORMATIVO", ptoTo.STATUS_CONSOLIDADO_INFORMATIVO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptoTo.COD_INSTITUCION);
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
        public bool insertarPuntoCobranzaDAL(puntoCobranzaTo pcob, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pcob.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@DESC_PTO_COB", pcob.DESC_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pcob.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@DESC_CANAL_DSCTO", pcob.DESC_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pcob.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@DESC_INSTITUCION", pcob.DESC_INSTITUCION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pcob.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@PAIS", pcob.PAIS);
            cmd.Parameters.AddWithValue("@DEPARTAMENTO", pcob.DEPARTAMENTO);
            cmd.Parameters.AddWithValue("@PROVINCIA", pcob.PROVINCIA);
            cmd.Parameters.AddWithValue("@DISTRITO", pcob.DISTRITO);
            cmd.Parameters.AddWithValue("@DIRECCION", pcob.DIRECCION);
            cmd.Parameters.AddWithValue("@SITUACION", pcob.SITUACION);
            cmd.Parameters.AddWithValue("@CONVENIO", pcob.CONVENIO);
            cmd.Parameters.AddWithValue("@DIA_PRESENTACION", pcob.DIA_PRESENTACION);
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", pcob.STATUS_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO_INFORMATIVO", pcob.STATUS_CONSOLIDADO_INFORMATIVO);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", pcob.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_FORMATO", pcob.COD_FORMATO);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pcob.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@DESC_SUCURSAL", pcob.DESC_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_ZONA", pcob.COD_ZONA);
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
        public DataTable obtenerSectoristaPuntosCobranzaDAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_COBRANZA_POR_COD_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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
        public DataTable obtenerPtoCobranzaxPtoCobConsolidadoDAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PTO_COBRANZA_X_PTO_COB_CONSOLIDADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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
        public DataTable obtenerPtoCobranzaxPtoCobDAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PTO_COBRANZA_X_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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

        public bool modificarPuntoCobranzaDAL(puntoCobranzaTo pcob, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pcob.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@DESC_PTO_COB", pcob.DESC_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pcob.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@DESC_CANAL_DSCTO", pcob.DESC_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pcob.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@DESC_INSTITUCION", pcob.DESC_INSTITUCION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pcob.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@PAIS", pcob.PAIS);
            cmd.Parameters.AddWithValue("@DEPARTAMENTO", pcob.DEPARTAMENTO);
            cmd.Parameters.AddWithValue("@PROVINCIA", pcob.PROVINCIA);
            cmd.Parameters.AddWithValue("@DISTRITO", pcob.DISTRITO);
            cmd.Parameters.AddWithValue("@DIRECCION", pcob.DIRECCION);
            cmd.Parameters.AddWithValue("@SITUACION", pcob.SITUACION);
            cmd.Parameters.AddWithValue("@CONVENIO", pcob.CONVENIO);
            cmd.Parameters.AddWithValue("@DIA_PRESENTACION", pcob.DIA_PRESENTACION);
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO", pcob.STATUS_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@STATUS_CONSOLIDADO_INFORMATIVO", pcob.STATUS_CONSOLIDADO_INFORMATIVO);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", pcob.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_FORMATO", pcob.COD_FORMATO);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pcob.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@DESC_SUCURSAL", pcob.DESC_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_ZONA", pcob.COD_ZONA);
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
        public bool eliminarPuntoCobranzaDAL(puntoCobranzaTo pcob, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pcob.COD_PTO_COB);
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
        public DataTable obtenerPuntoCobranzaVinculadosDAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_COBRANZA_VINCULADOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB);
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
        public DataTable obtenerPuntoCobranzaVinculadosInformativoDAL(puntoCobranzaTo ptoTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PUNTOS_COBRANZA_VINCULADOS_INFORMATIVO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB);
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
        public bool insertarPtoCobVinculadosDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PUNTO_COBRANZA_VINCULADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB_CONS);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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
        public bool insertarPtoCobVinculadosInformativoDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PUNTO_COBRANZA_VINCULADO_INFORMATIVO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB_CONS);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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
        public bool eliminaPuntoCobranzaVinculadosDAL(string cod_cons, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_COBRANZA_VINCULADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", cod_cons);
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
        public bool eliminaPuntoCobranzaVinculadosInformativoDAL(string cod_cons, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_COBRANZA_VINCULADO_INFORMATIVO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", cod_cons);
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
        //public bool eliminaSucursalVinculadosDAL(string cod_cons, ref string errMensaje)
        //{
        //    bool flag = false;
        //    SqlCommand cmd = new SqlCommand("ELIMINAR_SUCURSAL_VINCULADO", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@COD_SUCURSAL", cod_cons);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        flag = true;
        //    }
        //    catch (Exception e)
        //    {
        //        flag = false;
        //        errMensaje = e.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return flag;
        //}
        //public bool insertarSucursalVinculadosDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        //{
        //    bool flag = false;
        //    SqlCommand cmd = new SqlCommand("INSERTAR_SUCURSAL_VINCULADO", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@COD_SUCURSAL", ptoTo.COD_SUCURSAL);
        //    cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB_CONS);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        flag = true;
        //    }
        //    catch (Exception e)
        //    {
        //        flag = false;
        //        errMensaje = e.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return flag;
        //}
        //public bool eliminarInstitucionVinculadaDAL(string cod_cons, ref string errMensaje)
        //{
        //    bool flag = false;
        //    SqlCommand cmd = new SqlCommand("ELIMINAR_INSTITUCION_VINCULADA", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@COD_INSTITUCION", cod_cons);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        flag = true;
        //    }
        //    catch (Exception e)
        //    {
        //        flag = false;
        //        errMensaje = e.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return flag;
        //}
        //public bool insertarInstitucionVinculadaDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        //{
        //    bool flag = false;
        //    SqlCommand cmd = new SqlCommand("INSERTAR_INSTITUCION_VINCULADA", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@COD_INSTITUCION", ptoTo.COD_INSTITUCION);
        //    cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB_CONS);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        flag = true;
        //    }
        //    catch (Exception e)
        //    {
        //        flag = false;
        //        errMensaje = e.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return flag;
        //}
        //public bool eliminarCanalDsctoVinculadoDAL(string cod_cons, ref string errMensaje)
        //{
        //    bool flag = false;
        //    SqlCommand cmd = new SqlCommand("ELIMINAR_CANAL_DSCTO_VINCULADO", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", cod_cons);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        flag = true;
        //    }
        //    catch (Exception e)
        //    {
        //        flag = false;
        //        errMensaje = e.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return flag;
        //}
        //public bool insertarCanalDsctoVinculadoDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        //{
        //    bool flag = false;
        //    SqlCommand cmd = new SqlCommand("INSERTAR_CANAL_DSCTO_VINCULADO", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", ptoTo.COD_CANAL_DSCTO);
        //    cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB_CONS);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        flag = true;
        //    }
        //    catch (Exception e)
        //    {
        //        flag = false;
        //        errMensaje = e.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return flag;
        //}
        public int verificaPuntoCobranzaDAL(puntoCobranzaTo ptoTo)
        {
            int val = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_PUNTO_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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
        public bool validaHistoricoPedidoDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_PUNTO_COBRANZA_HISTORICO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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
        public bool eliminaPuntoCobranzaVinculadodeConsolidadoDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_COBRANZA_DE_CONSOLIDADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ptoTo.COD_PTO_COB);
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
        public bool eliminaPuntoCobranzaVinculadoTodosDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_COBRANZA_VINCULADO_TODOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB_CONS);
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
        public bool eliminaPuntoCobranzaVinculadoTodosInformativoDAL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PUNTO_COBRANZA_VINCULADO_TODOS_INFORMATIVO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONS", ptoTo.COD_PTO_COB_CONS);
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

        public DataTable ObtenerPtoCobranzaCantPlanillaDAL(string año, string mes)
        {
            const string procedure = "usp_ObtenerPtoCobranza";

            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@AÑO", año);
            _ = cmd.Parameters.AddWithValue("@MES", mes);
            try
            {
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

        public DataTable ObtenerPuntoCobranzaXPlanillasTrasnferidasDAL(string codPais)
        {
            const string procedure = "usp_ObtenerPtoCobranzaTransferidos";

            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

            try
            {
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

        public DataTable ListarPtoCobranzaCheques(string codPais)
        {
            const string procedure = "usp_ListarPuntoCobranzaCheques";

            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = TIME_OUT_1
            };

            _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

            try
            {
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

        public DataTable ListarPtoCobranza()
        {
            const string query = "SELECT * FROM PUNTO_COBRANZA ORDER BY DESC_PTO_COB ASC";

            SqlCommand cmd = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            };

            try
            {
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

        public DataTable ObtenerPtoCobranzaCheques(string codPais, string codPtoCob)
        {
            const string procedure = "usp_ObtenerPuntoCobranzaCheques";

            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);
            _ = cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);

            try
            {
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

        public DataTable ListarPtoCobranzaXPais(string codPais)
        {
            const string procedure = "dsp_ListarPtoCobranzaxPais";

            SqlCommand cmd = new SqlCommand(procedure, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            _ = cmd.Parameters.AddWithValue("@COD_PAIS", codPais);

            try
            {
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
    }
}
