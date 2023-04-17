using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class resumenPlanillaDAL
    {
        SqlConnection conn;
        public resumenPlanillaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public bool insertarResumenPlanillaDAL(resumenPlanillaTo rplaTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_RECEPCIONA_R_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", rplaTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", rplaTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", rplaTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", rplaTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", rplaTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", rplaTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", rplaTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", rplaTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", rplaTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@FECHA_RECEPCION", rplaTo.FECHA_RECEPCION);
            cmd.Parameters.AddWithValue("@OBSERVACION", rplaTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rplaTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MOD", rplaTo.COD_MOD);
            cmd.Parameters.AddWithValue("@IMP_ENV", rplaTo.IMP_ENV);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_INI", rplaTo.IMP_RECEPCION_INI);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_DOC", rplaTo.IMP_RECEPCION_DOC);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_DEV", rplaTo.IMP_RECEPCION_DEV);
            cmd.Parameters.AddWithValue("@COD_CREACION", rplaTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", rplaTo.FECHA_CREACION);

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
