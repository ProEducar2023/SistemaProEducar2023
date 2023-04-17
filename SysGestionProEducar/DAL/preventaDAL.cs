using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class preventaDAL
    {
        SqlConnection conn;
        public preventaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable mostrarPreventaDAL(preventaTo prvTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_PEDIDO_SERVICIO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", prvTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", prvTo.FE_MES);
            //cmd.Parameters.AddWithValue("@TIPO_USU", prvTo.TIPO_USU);
            //cmd.Parameters.AddWithValue("@COD_USU", prvTo.COD_USU);
            //cmd.Parameters.AddWithValue("@TIPO", prvTo.TIPO);
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
        public bool insertarPreventaDAL(preventaTo prvTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("INSERTAR_PEDIDO_INVENTARIO", conn);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", prvTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_PRESUPUESTO", prvTo.NRO_PRESUPUESTO);
            cmd.Parameters.AddWithValue("@COD_PER", prvTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_CLASE", prvTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", prvTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", prvTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_PRE", prvTo.FECHA_PRE);
            cmd.Parameters.AddWithValue("@COD_MONEDA", prvTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", prvTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@FORMA_PAGO", prvTo.FORMA_PAGO);
            cmd.Parameters.AddWithValue("@STATUS_PV", prvTo.STATUS_PV);
            cmd.Parameters.AddWithValue("@NRO_DIAS", prvTo.NRO_DIAS);
            cmd.Parameters.AddWithValue("@COD_PER_ELAB", prvTo.COD_PER_ELAB);
            cmd.Parameters.AddWithValue("@COD_PER_APROB", prvTo.COD_PER_APROB);
            cmd.Parameters.AddWithValue("@STATUS_APROB", prvTo.STATUS_APROB);
            cmd.Parameters.AddWithValue("@STATUS_ANUL", prvTo.STATUS_ANUL);
            cmd.Parameters.AddWithValue("@STATUS_CIERRE", prvTo.STATUS_CIERRE);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", prvTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@CONDICION_VENTA", prvTo.CONDICION_VENTA);
            cmd.Parameters.AddWithValue("@COD_CONTACTO", prvTo.COD_CONTACTO);
            cmd.Parameters.AddWithValue("@FECHA_APROB", prvTo.FECHA_APROB);
            cmd.Parameters.AddWithValue("@TIPO_PRECIO", prvTo.TIPO_PRECIO);
            cmd.Parameters.AddWithValue("@OBSERVACION", prvTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", prvTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@FEC_REPORTE", prvTo.FEC_REPORTE);
            cmd.Parameters.AddWithValue("@COD_PROGRAMA", prvTo.COD_PROGRAMA);
            cmd.Parameters.AddWithValue("@PERIODO", prvTo.PERIODO);
            cmd.Parameters.AddWithValue("@PERIODO", prvTo.PERIODO);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", prvTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_ALMACEN", prvTo.COD_ALMACEN);
            cmd.Parameters.AddWithValue("@COD_NIVEL1", prvTo.COD_NIVEL1);
            cmd.Parameters.AddWithValue("@COD_NIVEL2", prvTo.COD_NIVEL2);
            cmd.Parameters.AddWithValue("@COD_NIVEL3", prvTo.COD_NIVEL3);
            cmd.Parameters.AddWithValue("@SUELDO_BASICO", prvTo.SUELDO_BASICO);
            cmd.Parameters.AddWithValue("@SUELDO_BRUTO", prvTo.SUELDO_BRUTO);
            cmd.Parameters.AddWithValue("@TOTAL_CONTRATO", prvTo.TOTAL_CONTRATO);
            cmd.Parameters.AddWithValue("@NRO_CUOTAS", prvTo.NRO_CUOTAS);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_INICIAL", prvTo.IMP_CUOTA_INICIAL);
            cmd.Parameters.AddWithValue("@IMP_CUOTA_MES", prvTo.IMP_CUOTA_MES);
            if (prvTo.FEC_PRIMER_VENC == null)
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FEC_PRIMER_VENC", prvTo.FEC_PRIMER_VENC);
            cmd.Parameters.AddWithValue("@NRO_DIAS_VENC", prvTo.NRO_DIAS_VENC);
            cmd.Parameters.AddWithValue("@FEC_CUO_MEN", prvTo.FEC_CUO_MEN);
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
