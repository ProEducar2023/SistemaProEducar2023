using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class devPCtasCobrarDAL
    {
        SqlConnection conn;
        public devPCtasCobrarDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerDevPCtasCobrarDAL(devPCtasCobrarTo dpcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", conn);
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
        public DataTable obtenerDevPCtasCobrarContratosExcesoCuotaDAL(devPCtasCobrarTo dpcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MUESTRA_DEV_PCTAS_COBRAR_CONTRATOS_EXCESO_CUOTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
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
        public bool insertarDevPCtasCobrarDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_DEV_PCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", dpcTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", dpcTo.DESC_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", dpcTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dpcTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC", dpcTo.FECHA_DOC);
            if (dpcTo.FECHA_VEN == null)
                cmd.Parameters.AddWithValue("FECHA_VEN", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", dpcTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@IMP_INI", dpcTo.IMP_INI);
            cmd.Parameters.AddWithValue("@IMP_DOC", dpcTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@COD_MOTIVO_NO_DESCONTADO", dpcTo.COD_MOTIVO_NO_DESCONTADO);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@OBSERVACION", dpcTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_MONEDA", dpcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_OPE", dpcTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dpcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TOTAL_LETRA", dpcTo.TOTAL_LETRA);
            cmd.Parameters.AddWithValue("@STATUS_GENERADO", dpcTo.STATUS_GENERADO);
            cmd.Parameters.AddWithValue("@STATUS_CANCELADO", dpcTo.STATUS_CANCELADO);
            cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", dpcTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@CUOTA_COMPROMETIDA", dpcTo.CUOTA_COMPROMETIDA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA_ORIGEN", dpcTo.TIPO_PLANILLA_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", dpcTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", dpcTo.FECHA_CREA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool modificarDevPCtasCobrarDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DEV_PCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER", dpcTo.COD_PER);
            cmd.Parameters.AddWithValue("@DESC_PER", dpcTo.DESC_PER);
            cmd.Parameters.AddWithValue("@COD_DOC", dpcTo.COD_DOC);
            cmd.Parameters.AddWithValue("@NRO_DOC", dpcTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FECHA_DOC", dpcTo.FECHA_DOC);
            if (dpcTo.FECHA_VEN == null)
                cmd.Parameters.AddWithValue("FECHA_VEN", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_VEN", dpcTo.FECHA_VEN);
            cmd.Parameters.AddWithValue("@IMP_INI", dpcTo.IMP_INI);
            cmd.Parameters.AddWithValue("@IMP_DOC", dpcTo.IMP_DOC);
            cmd.Parameters.AddWithValue("COD_MOTIVO_NO_DESCONTADO", dpcTo.COD_MOTIVO_NO_DESCONTADO);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@OBSERVACION", dpcTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_MONEDA", dpcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_OPE", dpcTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dpcTo.NRO_LETRA);
            //cmd.Parameters.AddWithValue("@TOTAL_LETRA", dpcTo.TOTAL_LETRA);
            //cmd.Parameters.AddWithValue("@STATUS_GENERADO", dpcTo.STATUS_GENERADO);
            //cmd.Parameters.AddWithValue("@STATUS_CANCELADO", dpcTo.STATUS_CANCELADO);
            //cmd.Parameters.AddWithValue("@TIPO_PLA_ORIGEN", dpcTo.TIPO_PLA_ORIGEN);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", dpcTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", dpcTo.FECHA_MOD);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool Verifica_Contratos_Exceso_CuotaDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_CONTRATOS_EXCESO_CUOTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());

            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public decimal mostrar_suma_exceso_contrato_kardexDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            decimal suma = 0;
            SqlCommand cmd = new SqlCommand("MOSTRAR_SUMA_EXCESO_CONTRATO_KARDEX", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                suma = Convert.ToDecimal(cmd.ExecuteScalar());

            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                suma = 0;
            }
            finally
            {
                conn.Close();
            }
            return suma;
        }
        public DataTable obtenerDevPCtasCobrarTransferenciaDAL(devPCtasCobrarTo dpcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DEVPCTASCOBRAR_TRANSFERENCIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@DESC_PER", dpcTo.DESC_PER);
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
        public bool Grabar_Transferencia_DevolucionesDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DEVPCTASCOBRAR_TRANSFERENCIAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dpcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", dpcTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", dpcTo.FECHA_MOD);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public DataTable obtenerDevPCtasCobrarIngresoOtrosDevDsctosDAL(devPCtasCobrarTo dpcTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_INPUT_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
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
        public bool eliminarDevPCtasCobrarDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DEV_PCTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dpcTo.NRO_LETRA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool actualizaDevPCtasCobrarOtrasDevDsctosDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZAR_DEV_PCTAS_COBRAR_OTRAS_DEV_DSCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dpcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool actualizaDevPCtasCobrarOtrasDevDsctosxCierreDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZAR_DEV_PCTAS_COBRAR_OTRAS_DEV_DSCTOS_X_CIERRE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@NRO_LETRA", dpcTo.NRO_LETRA);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", dpcTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", dpcTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@IMP_DOC", dpcTo.IMP_DOC);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }

        public bool actualizaDevPctasCobrarxEliminacionPllaDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_DEV_PCTAS_COBRAR_X_ELIMINACION_PLLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@IMP_DOC", dpcTo.IMP_DOC);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }

        public bool eliminarDevTctasCobrarxEliminacionPllaDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_DEV_TCTAS_COBRAR_X_ELIMINACION_PLLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", dpcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", dpcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_D_H", dpcTo.COD_D_H);
            cmd.Parameters.AddWithValue("@TIPO_PLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }

        public bool ActualizarDevPctasCobrarDAL(devPCtasCobrarTo dpcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("usp_ActualizarDevPctasCobrar", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", dpcTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", dpcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", dpcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", dpcTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_PLLA_COBRANZA", dpcTo.TIPO_PLA_COBRANZA);
            cmd.Parameters.AddWithValue("@IMP_DOC", dpcTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@IMP_INI", dpcTo.IMP_INI);

            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                    flag = true;
                else
                    flag = false;
            }
            catch (Exception e)
            {
                errMensaje = e.Message;
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
    }
}
