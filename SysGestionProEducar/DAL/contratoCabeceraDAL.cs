using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class contratoCabeceraDAL
    {
        SqlConnection conn;
        public contratoCabeceraDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerContratoDAL()
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

        public bool insertarContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PRES_CAB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC", ccTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FECHA_PRE", ccTo.FECHA_PRE);
            cmd.Parameters.AddWithValue("@COD_MONEDA", ccTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", ccTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", ccTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@STATUS_PV", ccTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@NRO_DIAS", ccTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", ccTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", ccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@STATUS_APROB", ccTo.STATUS_APROB);
            cmd.Parameters.AddWithValue("@STATUS_ANUL", ccTo.STATUS_ANUL);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", ccTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", ccTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", ccTo.CONDICION_VENTA);
            cmd.Parameters.AddWithValue("@COD_CONTACTO", ccTo.COD_CONTACTO);
            if (ccTo.FECHA_APROB == null)
                cmd.Parameters.AddWithValue("@FECHA_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROB", ccTo.FECHA_APROB);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", ccTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", ccTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_MOV", ccTo.COD_MOV);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", ccTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", ccTo.FEC_REPORTE);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", ccTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@PERIODO", ccTo.PERIODO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", ccTo.NRO_SEMANA);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION", ccTo.TIPO_OPERACION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", ccTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", ccTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_NIVEL1", ccTo.COD_NIVEL1);
            cmd.Parameters.AddWithValue("@COD_NIVEL2", ccTo.COD_NIVEL2);
            cmd.Parameters.AddWithValue("@COD_NIVEL3", ccTo.COD_NIVEL3);
            cmd.Parameters.AddWithValue("@SUELDO_NETO", ccTo.SUELDO_NETO);
            cmd.Parameters.AddWithValue("@PRESTAMOS", ccTo.PRESTAMOS);
            cmd.Parameters.AddWithValue("@OTROS_DSCTOS", ccTo.OTROS_DSCTOS);
            cmd.Parameters.AddWithValue("@JUDICIALES", ccTo.JUDICIALES);
            cmd.Parameters.AddWithValue("@NETO_COBRAR", ccTo.NETO_COBRAR);
            cmd.Parameters.AddWithValue("@TOTAL_CONTRATO", ccTo.TOTAL_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_CUOTAS", ccTo.NRO_CUOTAS);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_INICIAL", ccTo.IMP_CUOTA_INICIAL);
            cmd.Parameters.AddWithValue("@IMP_COUTA_MES", ccTo.IMP_CUOTA_MES);
            if (ccTo.FEC_PRIMER_VENC == null)
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", ccTo.FEC_PRIMER_VENC);
            cmd.Parameters.AddWithValue("@NRO_DIAS_VENC", ccTo.NRO_DIAS_VENC);
            cmd.Parameters.AddWithValue("@FEC_CUO_MEN", ccTo.FEC_CUO_MEN);
            cmd.Parameters.AddWithValue("@STATUS_FAC", ccTo.STATUS_FAC);
            cmd.Parameters.AddWithValue("@TIPO_PEDIDO", ccTo.TIPO_PEDIDO);
            cmd.Parameters.AddWithValue("@STATUS_GUIA", ccTo.STATUS_GUIA);
            cmd.Parameters.AddWithValue("@COD_REF", ccTo.COD_REF);
            cmd.Parameters.AddWithValue("@NRO_REF", ccTo.NRO_REF);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", ccTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@SERIE", ccTo.SERIE);
            cmd.Parameters.AddWithValue("@COD_SUB_PTO_VEN", ccTo.COD_SUB_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", ccTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", ccTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", ccTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@COD_LUG_VTA", ccTo.COD_LUG_VTA);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ccTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@IMPORTE_PROTECCION", ccTo.IMPORTE_PROTECCION);
            cmd.Parameters.AddWithValue("@STATUS_PRE_APROB", ccTo.STATUS_PRE_APROB);
            cmd.Parameters.AddWithValue("@COD_KIT", ccTo.COD_KIT);
            cmd.Parameters.AddWithValue("@DSCTO_TOTAL", ccTo.DSCTO_TOTAL);
            cmd.Parameters.AddWithValue("@COD_USU", ccTo.COD_USU);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", ccTo.COD_NIVEL_INSTITUCION);
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
        public bool insertarContratoOrdDevVtasDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PRES_CAB_ORD_DEV_VTAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC", ccTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FECHA_PRE", ccTo.FECHA_PRE);
            cmd.Parameters.AddWithValue("@COD_MONEDA", ccTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", ccTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", ccTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@STATUS_PV", ccTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@NRO_DIAS", ccTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", ccTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", ccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@STATUS_APROB", ccTo.STATUS_APROB);
            cmd.Parameters.AddWithValue("@STATUS_ANUL", ccTo.STATUS_ANUL);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", ccTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", ccTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", ccTo.CONDICION_VENTA);
            cmd.Parameters.AddWithValue("@COD_CONTACTO", ccTo.COD_CONTACTO);
            if (ccTo.FECHA_APROB == null)
                cmd.Parameters.AddWithValue("@FECHA_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROB", ccTo.FECHA_APROB);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", ccTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", ccTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_MOV", ccTo.COD_MOV);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", ccTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", ccTo.FEC_REPORTE);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", ccTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@PERIODO", ccTo.PERIODO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", ccTo.NRO_SEMANA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", ccTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", ccTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_NIVEL1", ccTo.COD_NIVEL1);
            cmd.Parameters.AddWithValue("@COD_NIVEL2", ccTo.COD_NIVEL2);
            cmd.Parameters.AddWithValue("@COD_NIVEL3", ccTo.COD_NIVEL3);
            cmd.Parameters.AddWithValue("@SUELDO_NETO", ccTo.SUELDO_NETO);
            cmd.Parameters.AddWithValue("@PRESTAMOS", ccTo.PRESTAMOS);
            cmd.Parameters.AddWithValue("@OTROS_DSCTOS", ccTo.OTROS_DSCTOS);
            cmd.Parameters.AddWithValue("@JUDICIALES", ccTo.JUDICIALES);
            cmd.Parameters.AddWithValue("@NETO_COBRAR", ccTo.NETO_COBRAR);
            cmd.Parameters.AddWithValue("@TOTAL_CONTRATO", ccTo.TOTAL_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_CUOTAS", ccTo.NRO_CUOTAS);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_INICIAL", ccTo.IMP_CUOTA_INICIAL);
            cmd.Parameters.AddWithValue("@IMP_COUTA_MES", ccTo.IMP_CUOTA_MES);
            if (ccTo.FEC_PRIMER_VENC == null)
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", ccTo.FEC_PRIMER_VENC);
            cmd.Parameters.AddWithValue("@NRO_DIAS_VENC", ccTo.NRO_DIAS_VENC);
            cmd.Parameters.AddWithValue("@FEC_CUO_MEN", ccTo.FEC_CUO_MEN);
            cmd.Parameters.AddWithValue("@STATUS_FAC", ccTo.STATUS_FAC);
            cmd.Parameters.AddWithValue("@TIPO_PEDIDO", ccTo.TIPO_PEDIDO);
            cmd.Parameters.AddWithValue("@STATUS_GUIA", ccTo.STATUS_GUIA);
            cmd.Parameters.AddWithValue("@COD_REF", ccTo.COD_REF);
            cmd.Parameters.AddWithValue("@NRO_REF", ccTo.NRO_REF);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", ccTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@SERIE", ccTo.SERIE);
            cmd.Parameters.AddWithValue("@COD_SUB_PTO_VEN", ccTo.COD_SUB_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", ccTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", ccTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", ccTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", ccTo.NRO_FAC_PRE_UNI);
            if (ccTo.FECHA_FAC_PRE_UNI == null)
                cmd.Parameters.AddWithValue("@FECHA_FAC_PRE_UNI", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_FAC_PRE_UNI", ccTo.FECHA_FAC_PRE_UNI);
            cmd.Parameters.AddWithValue("@TIPO_ORIGEN", ccTo.TIPO_ORIGEN);
            cmd.Parameters.AddWithValue("@COD_KIT", ccTo.COD_KIT);
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
        public DataTable obtenerContratoCabeceraDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (ccTo.FE_AÑO == null)
                cmd.Parameters.AddWithValue("@FE_AÑO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            if (ccTo.FE_MES == null)
                cmd.Parameters.AddWithValue("@FE_MES", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            //cmd.Parameters.AddWithValue("@TIPO_USU", ccTo.TIPO_USU);
            ////cmd.Parameters.AddWithValue("@TIPO_PRESUPUESTO", pccTo.TIPO_PRESUPUESTO);
            //cmd.Parameters.AddWithValue("@COD_USU", ccTo.COD_USU);
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
        public DataTable obtenerContratoCabecera_para_Fact_Elect_DAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_PEDIDO_PARA_FACT_ELECT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            ////cmd.Parameters.AddWithValue("@TIPO_USU", ccTo.TIPO_USU);
            //////cmd.Parameters.AddWithValue("@TIPO_PRESUPUESTO", pccTo.TIPO_PRESUPUESTO);
            ////cmd.Parameters.AddWithValue("@COD_USU", ccTo.COD_USU);
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
        public bool modificarContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_MOV", ccTo.COD_MOV);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", ccTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@FECHA_DOC", ccTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", ccTo.FEC_PRIMER_VENC);
            cmd.Parameters.AddWithValue("@FEC_CUO_MEN", ccTo.FEC_CUO_MEN);
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
        public bool ELIMINAR_PEDIDO_PRESUPUESTO_DAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PEDIDO_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            //cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public bool modificaApruebaContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("APROBAR_I_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", ccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@FECHA_APROB", ccTo.FECHA_APROB);
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
        public bool modificaPreApruebaContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("PRE_APROBAR_I_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", ccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@FECHA_APROB", ccTo.FECHA_APROB);
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
        public bool VALIDAR_DESAPROBAR_CONTRATODAL(contratoCabeceraTo ccTo, ref bool flag2, ref string errMensaje)
        {
            bool flag = false;
            decimal num = -1;
            SqlCommand cmd = new SqlCommand("VALIDAR_DESAPROBAR_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            try
            {
                conn.Open();
                num = Convert.ToDecimal(cmd.ExecuteScalar());
                flag = true;
                flag2 = decimal.Compare(num, decimal.Zero) == 0 ? true : false;
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
        public bool VALIDAR_DESPREAPROBAR_CONTRATODAL(contratoCabeceraTo ccTo, ref bool flag2, ref string errMensaje)
        {
            bool flag = false;
            decimal num = -1;
            SqlCommand cmd = new SqlCommand("VALIDAR_DESPREAPROBAR_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            try
            {
                conn.Open();
                num = Convert.ToDecimal(cmd.ExecuteScalar());
                flag = true;
                flag2 = decimal.Compare(num, decimal.Zero) == 0 ? true : false;
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
        public bool DESAPROBAR_PEDIDODAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("DESAPROBAR_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public bool DESPREAPROBAR_PEDIDODAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("DESPREAPROBAR_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public bool cerrarContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("CERRAR_I_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
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
        public bool insertarBulkCopyPedDetDAL(DataTable dt, ref string errMensaje)
        {
            bool flag = false;
            try
            {
                conn.Open();
                int num = dt.Rows.Count - 1;
                SqlBulkCopy copy = new SqlBulkCopy(conn);
                copy.BatchSize = num;
                copy.DestinationTableName = "dbo.[T_PEDIDO_2]";
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
        public bool actualizaPedido_Status_Cta_DAL(string COD_SUCURSAL, string NRO_PRESUPUESTO, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO_STATUS_CTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", NRO_PRESUPUESTO);

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
        public DataTable obtenerContratosparaFacturacionDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PEDIDOS_PTES_FACT2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public DataTable obtenerContratosparaFacturacion3DAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PEDIDOS_PTES_FACT3", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public DataTable obtenerContratosDevolucionparaFacturacionDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_INGRESO_PTES_FACT2", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public DataTable obtenerObsequiosDevolucionparaFacturacionDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_INGRESO_PTES_FACT3", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public DataTable MOSTRAR_ORD_DEV_VTA_DAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ORD_DEV_VTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public DataTable obtenerOrdenDevVentasPendientesDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_ORD_DEV_VTA_PENDIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public bool modificaApruebaOrdDevVtasDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("APROBAR_ORDEN_DEV_VENTAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@STATUS_NC", ccTo.STATUS_NC);
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", ccTo.NRO_FAC_PRE_UNI);
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
        public bool modificaActualizaIPedidoporDevolucionDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO_POR_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            if (ccTo.NRO_FAC_PRE_UNI == null)
                cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", ccTo.NRO_FAC_PRE_UNI);
            if (ccTo.NRO_PRESUPUESTO == null)
                cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);

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
        public DataTable obtenerFacturacionCabeceraparaConsultaOrdDevFactporContratoDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_FACT_VTA_PARA_CONSULTA_ORD_DEV_FACT_POR_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
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
        public DataTable obtenerContratoCabeceraparaComisionesDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_PARA_COMISIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", ccTo.COD_PROGRAMA);
            if (ccTo.TIPO_PLANILLA == null)
                cmd.Parameters.AddWithValue("@TIPO_PLANILLA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@TIPO_PLANILLA", ccTo.TIPO_PLANILLA);
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
        public DataTable obtenerContratoCabeceraparaDevolucionesDAL()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_PARA_DEVOLUCIONES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public DataTable obtenerContratoCabeceraparaComisionesxNroContratoDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_PARA_COMISIONES_POR_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ccTo.NRO_PRESUPUESTO);
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
        public DataTable obtenerDatosdeContratoDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DATOS_DE_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ccTo.NRO_PRESUPUESTO);
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
        public bool modificarIPedidoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO_POR_COMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);

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
        public bool modificar_IPedido_por_NroContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO_POR_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);

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
        public bool modificarIPedidoxLiqComisionDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO_X_LIQ_COMISION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ccTo.NRO_PRESUPUESTO);
            if (ccTo.FECHA_APROB == null)
                cmd.Parameters.AddWithValue("@FECHA_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROB", ccTo.FECHA_APROB);
            cmd.Parameters.AddWithValue("@STATUS_APROB", ccTo.STATUS_APROB);
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
        public bool modificarIPedidoxGeneracionDevolucionDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO_X_GENERACION_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", ccTo.NRO_FAC_PRE_UNI);
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
        public bool modificarIPedidoxDevolucionGeneradaDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO_X_DEVOLUCION_GENERADA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", ccTo.NRO_FAC_PRE_UNI);
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
        public bool VERIFICA_NRO_CONTRATO_DAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_NRO_CONTRATO_I_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public bool ELIMINAR_PEDIDODAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_I_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            if (ccTo.FE_AÑO == null)
                cmd.Parameters.AddWithValue("@FE_AÑO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            if (ccTo.FE_MES == null)
                cmd.Parameters.AddWithValue("@FE_MES", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public bool ELIMINAR_PEDID_X_NRO_CONTRATO_DAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_PEDIDO_X_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public DataTable repContratosRegistradosDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REPORTE_CONTRATOS_REGISTRADOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ccTo.COD_INSTITUCION);
            if (ccTo.COD_PTO_COB == null)
                cmd.Parameters.AddWithValue("@COD_PTO_COB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PTO_COB", ccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            if (ccTo.NRO_SEMANA == null)
                cmd.Parameters.AddWithValue("@NRO_SEMANA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_SEMANA", ccTo.NRO_SEMANA);
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
        public DataTable repContratosRegistrados_Resumen_DAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REPORTE_RESUMEN_CONTRATOS_REGISTRADOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ccTo.COD_INSTITUCION);
            if (ccTo.COD_PTO_COB == null)
                cmd.Parameters.AddWithValue("@COD_PTO_COB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PTO_COB", ccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            if (ccTo.NRO_SEMANA == null)
                cmd.Parameters.AddWithValue("@NRO_SEMANA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_SEMANA", ccTo.NRO_SEMANA);
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
        public DataTable repContratosRegistrados_x_PtoCons_DAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REPORTE_CONTRATOS_REGISTRADOS_PTO_COB_CONSOLIDADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ccTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", ccTo.NRO_SEMANA);
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
        public DataTable repContratosRegistrados_x_PtoCons_Resumen_DAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("REPORTE_RESUMEN_CONTRATOS_REGISTRADOS_PTO_COB_CONSOLIDADO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ccTo.COD_INSTITUCION);
            if (ccTo.COD_PTO_COB == null)
                cmd.Parameters.AddWithValue("@ COD_PTO_COB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PTO_COB", ccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            if (ccTo.NRO_SEMANA == null)
                cmd.Parameters.AddWithValue("@NRO_SEMANA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_SEMANA", ccTo.NRO_SEMANA);
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
        public bool modificarContratoDirectoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_PEDIDO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_DOC", ccTo.FECHA_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FECHA_PRE", ccTo.FECHA_PRE);
            cmd.Parameters.AddWithValue("@COD_MONEDA", ccTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", ccTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", ccTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@STATUS_PV", ccTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@NRO_DIAS", ccTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", ccTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", ccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@STATUS_APROB", ccTo.STATUS_APROB);
            cmd.Parameters.AddWithValue("@STATUS_ANUL", ccTo.STATUS_ANUL);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", ccTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", ccTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", ccTo.CONDICION_VENTA);
            cmd.Parameters.AddWithValue("@COD_CONTACTO", ccTo.COD_CONTACTO);
            if (ccTo.FECHA_APROB == null)
                cmd.Parameters.AddWithValue("@FECHA_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROB", ccTo.FECHA_APROB);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", ccTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", ccTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@COD_MOV", ccTo.COD_MOV);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", ccTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", ccTo.FEC_REPORTE);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", ccTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@PERIODO", ccTo.PERIODO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", ccTo.NRO_SEMANA);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", ccTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", ccTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_NIVEL1", ccTo.COD_NIVEL1);
            cmd.Parameters.AddWithValue("@COD_NIVEL2", ccTo.COD_NIVEL2);
            cmd.Parameters.AddWithValue("@COD_NIVEL3", ccTo.COD_NIVEL3);
            cmd.Parameters.AddWithValue("@SUELDO_NETO", ccTo.SUELDO_NETO);
            cmd.Parameters.AddWithValue("@PRESTAMOS", ccTo.PRESTAMOS);
            cmd.Parameters.AddWithValue("@OTROS_DSCTOS", ccTo.OTROS_DSCTOS);
            cmd.Parameters.AddWithValue("@JUDICIALES", ccTo.JUDICIALES);
            cmd.Parameters.AddWithValue("@NETO_COBRAR", ccTo.NETO_COBRAR);
            cmd.Parameters.AddWithValue("@TOTAL_CONTRATO", ccTo.TOTAL_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_CUOTAS", ccTo.NRO_CUOTAS);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_INICIAL", ccTo.IMP_CUOTA_INICIAL);
            cmd.Parameters.AddWithValue("@IMP_COUTA_MES", ccTo.IMP_CUOTA_MES);
            if (ccTo.FEC_PRIMER_VENC == null)
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", ccTo.FEC_PRIMER_VENC);
            cmd.Parameters.AddWithValue("@NRO_DIAS_VENC", ccTo.NRO_DIAS_VENC);
            cmd.Parameters.AddWithValue("@FEC_CUO_MEN", ccTo.FEC_CUO_MEN);
            cmd.Parameters.AddWithValue("@STATUS_FAC", ccTo.STATUS_FAC);
            cmd.Parameters.AddWithValue("@TIPO_PEDIDO", ccTo.TIPO_PEDIDO);
            cmd.Parameters.AddWithValue("@STATUS_GUIA", ccTo.STATUS_GUIA);
            cmd.Parameters.AddWithValue("@COD_REF", ccTo.COD_REF);
            cmd.Parameters.AddWithValue("@NRO_REF", ccTo.NRO_REF);
            //cmd.Parameters.AddWithValue("@NOMBRE_PC", ccTo.NOMBRE_PC);
            //cmd.Parameters.AddWithValue("@SERIE", ccTo.SERIE);
            cmd.Parameters.AddWithValue("@COD_SUB_PTO_VEN", ccTo.COD_SUB_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", ccTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", ccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", ccTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", ccTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@COD_LUG_VTA", ccTo.COD_LUG_VTA);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", ccTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@IMPORTE_PROTECCION", ccTo.IMPORTE_PROTECCION);
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
        public DataTable obtenerContratosparaReporteContratosDirectosDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_DIRECTOS_PARA_FACTURACION", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.FE_MES);
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
        public DataTable obtenerContratosCuentaCorrienteDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_REG_CONTRATO_CC_BLOQUE", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
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
        public bool actualizaIPedidoporOrdenDevolucionDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_IPEDIDO_X_ORDEN_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.AÑO_DOC);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.MES_DOC);
            cmd.Parameters.AddWithValue("@NRO_FAC_PRE_UNI", "");
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public DataTable obtenerDatosDescuentoIndebidoxContratoDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_DATOS_DESCUENTO_INDEBIDO_X_CONTRATO", conn);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", ccTo.NRO_PRESUPUESTO);
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
        public DataTable obtenerContratosxCodPersonaDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CONTRATOS_X_COD_PERSONA", conn);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
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
        public bool eliminarDetalleContratoOrdDevDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_TPEDIDO_X_ORDEN_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.AÑO_DOC);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.MES_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public bool eliminarCabeceraContratoOrdDevDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_IPEDIDO_X_ORDEN_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.AÑO_DOC);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.MES_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public bool modificarEliminarCabezaContratoOrdDevDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_ELIMINAR_IPEDIDO_X_ORDEN_DEVOLUCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.AÑO_DOC);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.MES_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public bool modificarEliminarFacturacionOrdDevDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_ELIMINA_I_FACT_VTA_ORDEN_DEV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_DOC", ccTo.NRO_DOC);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", ccTo.AÑO_DOC);
            cmd.Parameters.AddWithValue("@FE_MES", ccTo.MES_DOC);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public DataTable obtener_Personas_para_Plla_Directa_VariosDAL(contratoCabeceraTo ccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PERSONAS_PARA_PLLA_DIRECTA_VARIOS", conn);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public bool eliminaContratoDetalleDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CONTRATO_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
        public bool eliminaContratoCabeceraDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_CONTRATO_CABECERA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", ccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", ccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", ccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", ccTo.NRO_PRESUPUESTO);
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
    }
}
