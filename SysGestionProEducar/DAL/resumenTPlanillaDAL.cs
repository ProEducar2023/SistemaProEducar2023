using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class resumenTPlanillaDAL
    {
        SqlConnection conn;
        public resumenTPlanillaDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public bool insertarResumenTPlanillaDAL(resumenTPlanillaTo rtplTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_RECEPCIONA_RT_PLANILLA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_PLANILLA_COB", rtplTo.NRO_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@COD_INSTITUCION", rtplTo.COD_INSTITUCION);
            cmd.Parameters.AddWithValue("@COD_PTO_COB_CONSOLIDADO", rtplTo.COD_PTO_COB_CONSOLIDADO);
            cmd.Parameters.AddWithValue("@COD_CANAL_DSCTO", rtplTo.COD_CANAL_DSCTO);
            cmd.Parameters.AddWithValue("@FE_AÑO", rtplTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", rtplTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", rtplTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", rtplTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@FECHA_PLANILLA_COB", rtplTo.FECHA_PLANILLA_COB);
            cmd.Parameters.AddWithValue("@FECHA_RECEPCION", rtplTo.FECHA_RECEPCION);
            cmd.Parameters.AddWithValue("@COD_DOCUMENTO_PAGO", rtplTo.COD_DOCUMENTO_PAGO);
            cmd.Parameters.AddWithValue("@NRO_DOCUMENTO_PAGO", rtplTo.NRO_DOCUMENTO_PAGO);
            if (rtplTo.FECHA_PAGO == null)
                cmd.Parameters.AddWithValue("@FECHA_PAGO", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_PAGO", rtplTo.FECHA_PAGO);
            cmd.Parameters.AddWithValue("@OBSERVACION", rtplTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_PLANILLA", rtplTo.TIPO_PLANILLA);
            cmd.Parameters.AddWithValue("@COD_MOD", rtplTo.COD_MOD);
            cmd.Parameters.AddWithValue("@IMP_RECEPCION_DOC", rtplTo.IMP_RECEPCION_DOC);
            cmd.Parameters.AddWithValue("@COD_D_H", rtplTo.COD_D_H);
            cmd.Parameters.AddWithValue("@TIPO_OPE", rtplTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_CREACION", rtplTo.COD_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", rtplTo.FECHA_CREACION);

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
