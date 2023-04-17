using DAL;
using Entidades;
using System;
using System.Data;
namespace BLL
{
    public class canjeTCtasxCobrarBLL
    {
        canjeTCtasxCobrarDAL ctcxDAL = new canjeTCtasxCobrarDAL();
        canjeTCtasxCobrarTo ctcxTo = new canjeTCtasxCobrarTo();

        public bool insertarCanjeTCtasxCobrarBLL(DataTable dtT, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dtT.Rows)
            {
                ctcxTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
                ctcxTo.COD_CLASE = rw["COD_CLASE"].ToString();
                ctcxTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                ctcxTo.FE_AÑO = rw["FE_AÑO"].ToString();
                ctcxTo.FE_MES = rw["FE_MES"].ToString();
                ctcxTo.COD_PER = rw["COD_PER"].ToString();
                ctcxTo.COD_DOC = rw["COD_DOC"].ToString();
                ctcxTo.NRO_DOC = rw["NRO_DOC"].ToString();
                ctcxTo.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_CONTRATO"]);
                ctcxTo.FECHA_DOC = Convert.ToDateTime(rw["FECHA_DOC"]);
                ctcxTo.FECHA_VEN = Convert.ToDateTime(rw["FECHA_VEN"]);
                ctcxTo.COD_P_COBRANZA = rw["COD_P_COBRANZA"].ToString();
                ctcxTo.COD_COBRADOR = rw["COD_COBRADOR"].ToString();
                ctcxTo.NRO_PLANILLA = rw["NRO_PLANILLA"].ToString();
                ctcxTo.FECHA_PLANILLA = Convert.ToDateTime(rw["FECHA_PLANILLA"]);
                ctcxTo.COD_D_H = rw["COD_D_H"].ToString();
                ctcxTo.COD_MONEDA = rw["COD_MONEDA"].ToString();
                ctcxTo.TIPO_CAMBIO = Convert.ToDecimal(rw["TIPO_CAMBIO"]);
                ctcxTo.IMP_DOC = Convert.ToDecimal(rw["IMP_DOC"]);
                ctcxTo.OBSERVACION = rw["OBSERVACION"].ToString();
                ctcxTo.TIPO_OPE = rw["TIPO_OPE"].ToString();
                ctcxTo.NRO_LETRA = rw["NRO_LETRA"].ToString();
                ctcxTo.TOTAL_LETRA = rw["TOTAL_LETRA"].ToString();
                ctcxTo.COD_CONCEPTO = rw["COD_CONCEPTO"].ToString();
                ctcxTo.COD_USU_CREA = rw["COD_USU_CREA"].ToString();
                ctcxTo.FECHA_CREA = Convert.ToDateTime(rw["FECHA_CREA"]);

                if (!ctcxDAL.insertarCanjeTCtasxCobrarDAL(ctcxTo, ref errMensaje))
                    return result = false;
            }
            return result;
            //if (ctcxDAL.insertarCanjeTCtasxCobrarDAL(dtT, ref errMensaje))
            //    return result = false;
        }
        public DataTable obtenerCanjeDetalleBLL(canjeTCtasxCobrarTo ctcxTo)
        {
            return ctcxDAL.obtenerCanjeDetalleDAL(ctcxTo);
        }
        public DataTable obtenerKardexporContratoBLL(canjeTCtasxCobrarTo ctxTo)
        {
            return ctcxDAL.obtenerKardexporContratoDAL(ctxTo);
        }
        public DataTable obtenerTctasxKardexContratoBLL(canjeTCtasxCobrarTo ctxTo)
        {
            return ctcxDAL.obtenerTctasxKardexContratoDAL(ctxTo);
        }
        public decimal obtenerMontoPagadoxContratoBLL(canjeTCtasxCobrarTo ctxTo, ref string errMensaje)
        {
            return ctcxDAL.obtenerMontoPagadoxContratoDAL(ctxTo, ref errMensaje);
        }
        public bool modifica_T_Ctas_por_Transferencia_BLL(canjeTCtasxCobrarTo ctxTo, ref string errMensaje)
        {
            bool result = true;
            if (!ctcxDAL.modifica_T_Ctas_por_Transferencia_DAL(ctxTo, ref errMensaje))
                return result = false;
            return result;
        }
        public decimal obtenerSumaImporteComprometidosBLL(canjeTCtasxCobrarTo ctxTo, ref string errMensaje)
        {
            return ctcxDAL.obtenerSumaImporteComprometidosDAL(ctxTo, ref errMensaje);
        }
        public bool modificarPCtasxCambioPtoCobBLL(canjeTCtasxCobrarTo ctxTo, ref string errMensaje)
        {
            bool result = true;
            if (!ctcxDAL.modificarPCtasxCambioPtoCobDAL(ctxTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTCtasCobrarBLL(canjeTCtasxCobrarTo ctxTo, ref string errMensaje)
        {
            bool result = true;
            if (!ctcxDAL.eliminarTCtasCobrarDAL(ctxTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
