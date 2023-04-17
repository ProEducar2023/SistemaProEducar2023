using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class precontratoCabeceraDAL
    {
        SqlConnection conn;
        public precontratoCabeceraDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerPrecontratoCabeceraDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@FE_AÑO",pccTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_GRAL", pccTo.FECHA_GRAL);
            cmd.Parameters.AddWithValue("@TIPO_USU", pccTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", pccTo.COD_USU);
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
        public DataTable obtenerPrecontratoCabeceraTodosPeriodosDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_PRESUPUESTO_TODOS_PERIODOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_USU", pccTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", pccTo.COD_USU);
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
        public bool insertarPreContratoCabeceraDAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_PRE", pccTo.FECHA_PRE);
            cmd.Parameters.AddWithValue("@COD_MONEDA", pccTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", pccTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", pccTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACION", pccTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_PV", pccTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@NRO_DIAS", pccTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", pccTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", pccTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", pccTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", pccTo.CONDICION_VENTA);
            cmd.Parameters.AddWithValue("@COD_CONTACTO", pccTo.COD_CONTACTO);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", pccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@STATUS_APROB", pccTo.STATUS_APROB);
            cmd.Parameters.AddWithValue("@STATUS_ANUL", pccTo.STATUS_ANUL);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", pccTo.STATUS_CIERRE);
            if (pccTo.FECHA_APROB == null)
                cmd.Parameters.AddWithValue("@FECHA_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROB", pccTo.FECHA_APROB);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", pccTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", pccTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", pccTo.FEC_REPORTE);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pccTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@PERIODO", pccTo.PERIODO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", pccTo.NRO_SEMANA);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION", pccTo.TIPO_OPERACION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pccTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", pccTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_NIVEL1", pccTo.COD_NIVEL1);
            cmd.Parameters.AddWithValue("@COD_NIVEL2", pccTo.COD_NIVEL2);
            cmd.Parameters.AddWithValue("@COD_NIVEL3", pccTo.COD_NIVEL3);
            cmd.Parameters.AddWithValue("@SUELDO_BASICO", pccTo.SUELDO_BASICO);
            cmd.Parameters.AddWithValue("@SUELDO_BRUTO", pccTo.SUELDO_BRUTO);
            cmd.Parameters.AddWithValue("@OTROS_DSCTOS", pccTo.OTROS_DSCTOS);
            cmd.Parameters.AddWithValue("@JUDICIALES", pccTo.JUDICIALES);
            cmd.Parameters.AddWithValue("@NETO_COBRAR", pccTo.NETO_COBRAR);
            cmd.Parameters.AddWithValue("@TOTAL_CONTRATO", pccTo.TOTAL_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_CUOTAS", pccTo.NRO_CUOTAS);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_INICIAL", pccTo.IMP_CUOTA_INICIAL);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_MES", pccTo.IMP_CUOTA_MES);
            if (pccTo.FEC_PRIMER_VENC == null)
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", pccTo.FEC_PRIMER_VENC);
            cmd.Parameters.AddWithValue("@NRO_DIAS_VENC", pccTo.NRO_DIAS_VENC);
            cmd.Parameters.AddWithValue("@FEC_CUO_MEN", pccTo.FEC_CUO_MEN);
            cmd.Parameters.AddWithValue("@COD_SUB_PTO_VEN", pccTo.COD_SUB_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pccTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", pccTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", pccTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@COD_LUG_VTA", pccTo.COD_LUG_VTA);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pccTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@IMPORTE_PROTECCION", pccTo.IMPORTE_PROTECCION);
            cmd.Parameters.AddWithValue("@COD_KIT", pccTo.COD_KIT);
            cmd.Parameters.AddWithValue("@DSCTO_TOTAL", pccTo.DSCTO_TOTAL);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", pccTo.COD_USU_CREA);
            cmd.Parameters.AddWithValue("@FECHA_CREA", pccTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", pccTo.COD_NIVEL_INSTITUCION);
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
        public bool modificarPreContratoCabeceraDAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_PRE", pccTo.FECHA_PRE);
            cmd.Parameters.AddWithValue("@COD_MONEDA", pccTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", pccTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", pccTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACION", pccTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@STATUS_PV", pccTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@NRO_DIAS", pccTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", pccTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", pccTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@NOMBRE_PC", pccTo.NOMBRE_PC);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", pccTo.CONDICION_VENTA);
            cmd.Parameters.AddWithValue("@COD_CONTACTO", pccTo.COD_CONTACTO);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", pccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@STATUS_APROB", pccTo.STATUS_APROB);
            cmd.Parameters.AddWithValue("@STATUS_ANUL", pccTo.STATUS_ANUL);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", pccTo.STATUS_CIERRE);
            if (pccTo.FECHA_APROB == null)
                cmd.Parameters.AddWithValue("@FECHA_APROB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROB", pccTo.FECHA_APROB);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", pccTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", pccTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", pccTo.FEC_REPORTE);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pccTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@PERIODO", pccTo.PERIODO);
            cmd.Parameters.AddWithValue("@NRO_SEMANA", pccTo.NRO_SEMANA);
            cmd.Parameters.AddWithValue("@TIPO_OPERACION", pccTo.TIPO_OPERACION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pccTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", pccTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_NIVEL1", pccTo.COD_NIVEL1);
            cmd.Parameters.AddWithValue("@COD_NIVEL2", pccTo.COD_NIVEL2);
            cmd.Parameters.AddWithValue("@COD_NIVEL3", pccTo.COD_NIVEL3);
            cmd.Parameters.AddWithValue("@SUELDO_BASICO", pccTo.SUELDO_BASICO);
            cmd.Parameters.AddWithValue("@SUELDO_BRUTO", pccTo.SUELDO_BRUTO);
            cmd.Parameters.AddWithValue("@OTROS_DSCTOS", pccTo.OTROS_DSCTOS);
            cmd.Parameters.AddWithValue("@JUDICIALES", pccTo.JUDICIALES);
            cmd.Parameters.AddWithValue("@NETO_COBRAR", pccTo.NETO_COBRAR);
            cmd.Parameters.AddWithValue("@TOTAL_CONTRATO", pccTo.TOTAL_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_CUOTAS", pccTo.NRO_CUOTAS);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_INICIAL", pccTo.IMP_CUOTA_INICIAL);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_MES", pccTo.IMP_CUOTA_MES);
            if (pccTo.FEC_PRIMER_VENC == null)
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", pccTo.FEC_PRIMER_VENC);
            cmd.Parameters.AddWithValue("@NRO_DIAS_VENC", pccTo.NRO_DIAS_VENC);
            cmd.Parameters.AddWithValue("@FEC_CUO_MEN", pccTo.FEC_CUO_MEN);
            cmd.Parameters.AddWithValue("@COD_SUB_PTO_VEN", pccTo.COD_SUB_PTO_VEN);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", pccTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", pccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", pccTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", pccTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@COD_LUG_VTA", pccTo.COD_LUG_VTA);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", pccTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@IMPORTE_PROTECCION", pccTo.IMPORTE_PROTECCION);
            cmd.Parameters.AddWithValue("@COD_KIT", pccTo.COD_KIT);
            cmd.Parameters.AddWithValue("@DSCTO_TOTAL", pccTo.DSCTO_TOTAL);
            cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", pccTo.COD_NIVEL_INSTITUCION);
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
        public bool modificaApruebaPreContratoDAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("APROBAR_I_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", pccTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@FECHA_APROB", pccTo.FECHA_APROB);

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
        public bool modificaDesapruebaPreContratoDAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("DESAPROBAR_I_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            //cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);


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
        public bool VALIDAR_DESAPROBAR_PRECONTRATODAL(precontratoCabeceraTo pccTo, ref bool flag2, ref string errMensaje)
        {
            bool flag = false;
            decimal num = -1;
            SqlCommand cmd = new SqlCommand("VALIDAR_DESAPROBAR_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
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
        public bool DESAPROBAR_PEDIDODAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("DESAPROBAR_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
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
        public bool ELIMINAR_PEDIDODAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_I_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
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
        public bool VERIFICA_ORDEN_PEDIDODAL(precontratoCabeceraTo pccTo, ref bool flag2, ref string errMensaje)
        {
            bool flag = false;
            decimal num = -1;
            SqlCommand cmd = new SqlCommand("VERIFICAR_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            try
            {
                conn.Open();
                num = cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToDecimal(cmd.ExecuteScalar());
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
        public bool VERIFICA_NRO_CONTROTATO_DAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_NRO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
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
        public bool CERRAR_PEDIDODAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("CERRAR_I_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
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
        public bool ANULAR_PEDIDODAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ANULAR_I_PRESUPUESTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@TIPOUSU", pccTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@OBS", pccTo.OBSERVACION);
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
        public DataTable CARGAR_PRECONTRATOS_PENDIENTESDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CARGAR_PRESUPUESTO_PENDIENTES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
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
        public DataTable MOSTRAR_I_PRESUPUESTO_PARA_CANJE(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_I_PRESUPUESTO_PARA_CANJE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);

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
        public DataTable obtieneRegContratoDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_REG_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            ////cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            //cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            //cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
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
        public decimal obtenerPorcentajeEvalContratoDAL()
        {
            decimal val = 0;
            SqlCommand cmd = new SqlCommand("MOSTRAR_PORCENTAJE_EVAL_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                val = Convert.ToDecimal(cmd.ExecuteScalar());

            }
            catch (Exception)
            {
                val = 0;
            }
            finally
            {
                conn.Close();
            }
            return val;
        }
        public bool actualizaPreContratoStatusCierreDAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_I_PRESUPUESTO_STATUS_CIERRE", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public bool actualizaPreContratoStatusCierre_x_NroContrato_DAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_I_PRESUPUESTO_STATUS_CIERRE_X_NRO_CONTRATO", conn);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable obtenerReporteControlCalidadDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (pccTo.NRO_REPORTE == null)
                cmd.Parameters.AddWithValue("@NRO_REPORTE", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_REPORTE", pccTo.NRO_REPORTE);
            if (pccTo.NRO_PRESUPUESTO == null)
                cmd.Parameters.AddWithValue("@NRO_CONTRATO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@NRO_CONTRATO", pccTo.NRO_PRESUPUESTO);
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
        public DataTable obtenerReporteCambioUbicacionADAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CAMBIO_UBICACION_A", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_DESDE", pccTo.FECHA_REPORTE_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_HASTA", pccTo.FECHA_REPORTE_HASTA);
            if (pccTo.COD_INSTITUCION == null)
                cmd.Parameters.AddWithValue("@COD_INSTITUCION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_INSTITUCION", pccTo.COD_INSTITUCION);
            if (pccTo.COD_PTO_COB == null)
                cmd.Parameters.AddWithValue("@COD_PTO_COB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PTO_COB", pccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@OP_APROB", pccTo.OP_APROB);
            cmd.Parameters.AddWithValue("@OP_CONTR", pccTo.OP_CONTR);
            if (pccTo.TIPO_PLANILLA == null)
                cmd.Parameters.AddWithValue("@TIPO_PLANILLA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pccTo.TIPO_PLANILLA);
            cmd.CommandTimeout = 90;
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
        public DataTable obtenerReporteCambioUbicacionResumenDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CAMBIO_UBICACION_A_RESUMEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FECHA_DESDE", pccTo.FECHA_REPORTE_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_HASTA", pccTo.FECHA_REPORTE_HASTA);
            if (pccTo.COD_INSTITUCION == null)
                cmd.Parameters.AddWithValue("@COD_INSTITUCION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_INSTITUCION", pccTo.COD_INSTITUCION);
            if (pccTo.COD_PTO_COB == null)
                cmd.Parameters.AddWithValue("@COD_PTO_COB", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@COD_PTO_COB", pccTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@OP_APROB", pccTo.OP_APROB);
            cmd.Parameters.AddWithValue("@OP_CONTR", pccTo.OP_CONTR);
            if (pccTo.TIPO_PLANILLA == null)
                cmd.Parameters.AddWithValue("@TIPO_PLANILLA", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@TIPO_PLANILLA", pccTo.TIPO_PLANILLA);
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
        public DataTable obtenerReporteControlCalidadxFechaReporteDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD_X_FECHA_REPORTE", conn);
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD_X_FECHAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATUS_REPORTE", pccTo.STATUS_REPORTE);
            cmd.Parameters.AddWithValue("@FECHA_REPORTE_DESDE", pccTo.FECHA_REPORTE_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_REPORTE_HASTA", pccTo.FECHA_REPORTE_HASTA);
            cmd.Parameters.AddWithValue("@STATUS_CONTRATO", pccTo.STATUS_CONTRATO);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO_DESDE", pccTo.FECHA_CONTRATO_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO_HASTA", pccTo.FECHA_CONTRATO_HASTA);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pccTo.COD_PROGRAMA);
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
        public DataTable obtenerReporteControlCalidadContratoxFechaAprobDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD_X_FECHA_REPORTE", conn);
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD_CONTRATO_X_FECHAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pccTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FECHA_REPORTE_DESDE", pccTo.FECHA_REPORTE_DESDE);
            cmd.Parameters.AddWithValue("@FECHA_REPORTE_HASTA", pccTo.FECHA_REPORTE_HASTA);
            cmd.Parameters.AddWithValue("@OP_APROB", pccTo.OP_APROB);
            cmd.Parameters.AddWithValue("@OP_REPO", pccTo.OP_REPO);
            cmd.Parameters.AddWithValue("@OP_CONTR", pccTo.OP_CONTR);
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
        public DataTable obtenerReporteControlCalidadxPeriodo_y_Semana_ContratoDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD_X_FECHA_REPORTE", conn);
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD_X_PERIODO_Y_SEMANA_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", pccTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            if (pccTo.NRO_SEMANA == null)
                cmd.Parameters.AddWithValue("@SEMANA_CONTRATO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@SEMANA_CONTRATO", pccTo.NRO_SEMANA);
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
        public DataTable obtenerReporteControlCalidadxPeriodoDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_REPORTE_CONTROL_CALIDAD_X_PERIODO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MES", pccTo.FE_MES);
            cmd.Parameters.AddWithValue("@ANNIO", pccTo.FE_AÑO);
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
        public DataTable obtenerPreContratoCabeceraparaCrearContratoDAL(precontratoCabeceraTo pccTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("OBTENER_PRE_CONTRATO_CABECERA_PARA_CREAR_CONTRATO", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", pccTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", pccTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", pccTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", pccTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", pccTo.FE_MES);
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
        public bool actualizaI_PresupuestoxContratoxDigitadorDAL(precontratoCabeceraTo pccTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ACTUALIZAR_I_PRESUPUESTO_X_CONTRATO_X_DIGITADOR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", pccTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", pccTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", pccTo.NRO_REPORTE);
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
