using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class canjePCtasxCobrarDAL
    {
        SqlConnection conn;
        public canjePCtasxCobrarDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public string VERIFICAR_LETRA_CXC_DAL(canjePCtasxCobrarTo cpccTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("VERIFICAR_LETRA_CXC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cpccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", cpccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", cpccTo.NRO_DOC);

            try
            {
                conn.Open();
                val = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "error";
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public bool insertarCanjePCtasxCobrarDAL(canjeTCtasxCobrarTo cpcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CANJEA_P_CTAS_X_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cpcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", cpcxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cpcxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", cpcxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cpcxTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", cpcxTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", cpcxTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", cpcxTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC", cpcxTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FECHA_VEN", cpcxTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@IMP_INI", cpcxTo.IMP_INI);
            cmd.Parameters.AddWithValue("@IMP_DOC", cpcxTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@COD_D_H", cpcxTo.COD_D_H);
            cmd.Parameters.AddWithValue("@OBSERVACION", cpcxTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_MONEDA", cpcxTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_OPE", cpcxTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", cpcxTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOTAL_LETRA", cpcxTo.TOTAL_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", cpcxTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", cpcxTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", cpcxTo.COD_USU_CREA);
            //cmd.Parameters.AddWithValue("@COD_USU_MOD", cpcxTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_CREA", cpcxTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", cpcxTo.COD_P_COBRANZA);
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
        public DataTable obtener_PCtasCobrar_por_NroContratoDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PCTAS_COBRAR_POR_NROCONTRATO_PARA_I_GENERACION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pctaTo.NRO_LETRA);
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
        public DataTable obtener_PCtasCobrar_por_NroContrato_RecepcionDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PCTAS_COBRAR_POR_NROCONTRATO_PARA_I_GENERACION_COBRANZA_RECEPCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_VEN", pctaTo.FECHA_VEN);
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
        public DataTable obtener_PCtasCobrar_por_NroContrato_para_TransferenciaDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_PARA_TRANSFERENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
        public DataTable obtener_PCtasCobrar_por_CodPerDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PCTAS_COBRAR_POR_CODPER_PARA_I_GENERACION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            //cmd.Parameters.AddWithValue("@NRO_LETRA", pctaTo.NRO_LETRA);
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
        public bool modifica_P_Ctas_por_Generacion_Planilla_DAL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_P_CTAS_COBRAR_POR_GENERACION_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (pctaTo.COD_SUCURSAL == null)
                cmd.Parameters.AddWithValue("@COD_SUCURSAL", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_DOC", pctaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@STATUS_GENERADO", pctaTo.STATUS_GENERADO);
            cmd.Parameters.AddWithValue("@STATUS_ENVIADO", pctaTo.STATUS_ENVIADO);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", pctaTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pctaTo.FECHA_MOD);
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
        public bool modifica_P_Ctas_por_Envio_Planilla_DAL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_P_CTAS_COBRAR_POR_ENVIO_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (pctaTo.COD_SUCURSAL == null)
                cmd.Parameters.AddWithValue("@COD_SUCURSAL", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_DOC", pctaTo.NRO_DOC);
            if (pctaTo.STATUS_GENERADO == null)
                cmd.Parameters.AddWithValue("@STATUS_GENERADO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@STATUS_GENERADO", pctaTo.STATUS_GENERADO);
            if (pctaTo.STATUS_ENVIADO == null)
                cmd.Parameters.AddWithValue("@STATUS_ENVIADO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@STATUS_ENVIADO", pctaTo.STATUS_ENVIADO);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", pctaTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pctaTo.FECHA_MOD);
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
        public bool Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle_DAL(canjePCtasxCobrarTo cpcxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_P_CTAS_COBRAR_POR_APROBAR_RECEPCION_PLANILLA_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cpcxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", cpcxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cpcxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", cpcxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cpcxTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_DOC", cpcxTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@IMP_DOC", cpcxTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@IMP_COB_CTA_CTE", cpcxTo.IMP_COB_CTA_CTE);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", cpcxTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", cpcxTo.FECHA_MOD);
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
        public DataTable obtener_PCtasCobrar_por_Fecha_Ven_DAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_VENCIDOS_A_FECHA_VENCIMIENTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_INI", pctaTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@FECHA_VEN", pctaTo.FECHA_VEN);
            //cmd.Parameters.AddWithValue("@NRO_LETRA", pctaTo.NRO_LETRA);
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
        public bool modificaPCtasCobrarporContratosporVencerDAL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PCTAS_COBRAR_POR_CONTRATOS_POR_VENCER", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_DOC", pctaTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_VEN", pctaTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", pctaTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pctaTo.FECHA_MOD);
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
        public bool modifica_P_Ctas_por_Transferencia_DAL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PCTAS_COBRAR_TRANSFERENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_LETRA", pctaTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", pctaTo.TIPO_PLA_COBRANZA);
            //cmd.Parameters.AddWithValue("@TIPO_PLA_DESTINO", pctaTo.TIPO_PLA_DESTINO);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", pctaTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pctaTo.FECHA_MOD);
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
        public DataTable obtenerPuntosCobranzaHastaFecVenDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PTOS_COB_HASTA_FECHA_VEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_VEN", pctaTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", pctaTo.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pctaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pctaTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pctaTo.COD_PROGRAMA);
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
        public DataTable obtener_PCtasCobrar_por_CodDocDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PCTAS_COBRAR_POR_COD_DOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_DOC", pctaTo.NRO_DOC);
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
        public DataTable obtener_PCtasCobrar_DetalleDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PCTAS_COBRAR_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            //cmd.Parameters.AddWithValue("@COD_CLASE", pctaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
        public bool Verifica_Existe_Cuota_pagada_x_contratoDAL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VALIDA_EXISTENCIA_DE_CUOTA_PAGADA_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
        public string Verifica_Existe_Planilla_x_contratoDAL(canjePCtasxCobrarTo cpccTo)
        {
            string val = "";
            SqlCommand cmd = new SqlCommand("VERIFICA_EXISTENCIA_DE_PLANILLA_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cpccTo.NRO_CONTRATO);

            try
            {
                conn.Open();
                val = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                val = "error";
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public DateTime obtenerPCtasxKardexContratoDAL(canjePCtasxCobrarTo cpccTo)
        {
            DateTime fec = DateTime.Now;
            SqlCommand cmd = new SqlCommand("MOSTRAR_PCTAS_KARDEX_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cpccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", cpccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cpccTo.NRO_CONTRATO);

            try
            {
                conn.Open();
                fec = cmd.ExecuteScalar() == null ? DateTime.Now.AddDays(1000) : Convert.ToDateTime(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                fec = DateTime.Now.AddDays(1000);
            }
            finally
            {
                conn.Close();
            }
            return fec;
        }
        public DataTable obtenerCuotasPendientesxContratoDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_PENDIENTES_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pctaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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

        public DataTable obtenerCuotasPendientesxContratoSuspendidoDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_PENDIENTES_X_CONTRATO_SUSPENDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pctaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
        public DataTable obtenerCuotasPendientesxContratoxIncluyendoCuotaComprometidasBLL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_PENDIENTES_X_CONTRATO_INCLUYENTO_CUOTAS_COMPROMETIDAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pctaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
        public DataTable obtenerCuotasComprometidasContratoDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_COMPROMETIDAS_X_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_PLANILLA", pctaTo.NRO_PLANILLA);
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
        public DataTable obtenerCuotasComprometidasContratoPllaDirectaDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CUOTAS_COMPROMETIDAS_X_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
        public DataTable obtenerCuotasComprometidasSoloContratoDAL(canjePCtasxCobrarTo pctaTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CUOTAS_COMPROMETIDAS_SOLO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pctaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
        public bool modificarPCtasxCambioPtoCobDAL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PCTAS_COBRAR_X_CAMBIO_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", pctaTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pctaTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", pctaTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", pctaTo.FECHA_MOD);
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
        public bool eliminarPCtasCobrarDAL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_PCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pctaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pctaTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", pctaTo.NRO_CONTRATO);
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
    }
}
