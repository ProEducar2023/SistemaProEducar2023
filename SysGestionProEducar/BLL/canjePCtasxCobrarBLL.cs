using DAL;
using Entidades;
using System;
using System.Data;
namespace BLL
{
    public class canjePCtasxCobrarBLL
    {
        canjePCtasxCobrarDAL cpcxDAL = new canjePCtasxCobrarDAL();
        canjePCtasxCobrarTo cpcxTo = new canjePCtasxCobrarTo();
        serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
        serieDocumentosTo sdoTo = new serieDocumentosTo();

        public string VERIFICAR_LETRA_CXC_BLL(canjePCtasxCobrarTo cpcxTo)
        {
            return cpcxDAL.VERIFICAR_LETRA_CXC_DAL(cpcxTo);
        }
        public bool insertarCanjePCtasxCobrarBLL(DataTable dtP, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dtP.Rows)
            {
                cpcxTo.COD_SUCURSAL = rw["COD_SUCURSAL"].ToString();
                cpcxTo.COD_CLASE = rw["COD_CLASE"].ToString();
                cpcxTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                cpcxTo.FE_AÑO = rw["FE_AÑO"].ToString();
                cpcxTo.FE_MES = rw["FE_MES"].ToString();
                cpcxTo.COD_PER = rw["COD_PER"].ToString();
                cpcxTo.COD_DOC = rw["COD_DOC"].ToString();
                cpcxTo.NRO_DOC = sdoBLL.OBTENER_SERIE_NRO_BLL(sdoTo).Rows[0]["dd"].ToString();
                //rw["NRO_DOC"] = cpcxTo.NRO_DOC;
                cpcxTo.FECHA_DOC = Convert.ToDateTime(rw["FECHA_DOC"]);
                cpcxTo.FECHA_VEN = Convert.ToDateTime(rw["FECHA_VEN"]);
                cpcxTo.IMP_INI = Convert.ToDecimal(rw["IMP_INI"]);
                cpcxTo.IMP_DOC = 0;
                cpcxTo.COD_D_H = rw["COD_D_H"].ToString();
                cpcxTo.OBSERVACION = rw["OBSERVACION"].ToString();
                cpcxTo.TIPO_OPE = rw["TIPO_OPE"].ToString();
                cpcxTo.NRO_LETRA = rw["NRO_LETRA"].ToString();
                cpcxTo.TOTAL_LETRA = rw["TOTAL_LETRA"].ToString();
                cpcxTo.COD_USU_CREA = rw["COD_USU_CREA"].ToString();
                cpcxTo.FECHA_CREA = Convert.ToDateTime(rw["FECHA_CREA"]);

                ////if(!sdoBLL.adicionaNroSerieBLL(sdoTo, ref errMensaje))
                ////    return result = false;
                //if (!cpcxDAL.insertarCanjePCtasxCobrarDAL(cpcxTo, ref errMensaje))
                //    return result = false;
            }

            return result;
        }
        public DataTable obtener_PCtasCobrar_por_NroContratoBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtener_PCtasCobrar_por_NroContratoDAL(pctaTo);
        }
        public DataTable obtener_PCtasCobrar_por_NroContrato_RecepcionBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtener_PCtasCobrar_por_NroContrato_RecepcionDAL(pctaTo);
        }
        public DataTable obtener_PCtasCobrar_por_NroContrato_para_TransferenciaBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtener_PCtasCobrar_por_NroContrato_para_TransferenciaDAL(pctaTo);
        }
        public DataTable obtener_PCtasCobrar_por_CodPerBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtener_PCtasCobrar_por_CodPerDAL(pctaTo);
        }
        public bool modifica_P_Ctas_por_Generacion_Planilla_BLL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcxDAL.modifica_P_Ctas_por_Generacion_Planilla_DAL(pctaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modifica_P_Ctas_por_Envio_Planilla_BLL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcxDAL.modifica_P_Ctas_por_Envio_Planilla_DAL(pctaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtener_PCtasCobrar_por_Fecha_Ven_BLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtener_PCtasCobrar_por_Fecha_Ven_DAL(pctaTo);
        }
        public bool modificaPCtasCobrarporContratosporVencerBLL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcxDAL.modificaPCtasCobrarporContratosporVencerDAL(pctaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modifica_P_Ctas_por_Transferencia_BLL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcxDAL.modifica_P_Ctas_por_Transferencia_DAL(pctaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPuntosCobranzaHastaFecVenBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerPuntosCobranzaHastaFecVenDAL(pctaTo);
        }
        public DataTable obtener_PCtasCobrar_por_CodDocBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtener_PCtasCobrar_por_CodDocDAL(pctaTo);
        }
        public DataTable obtener_PCtasCobrar_DetalleBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtener_PCtasCobrar_DetalleDAL(pctaTo);
        }
        public bool Verifica_Existe_Cuota_pagada_x_contratoBLL(canjePCtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool result = true;
            if (cpcxDAL.Verifica_Existe_Cuota_pagada_x_contratoDAL(cicxTo, ref errMensaje))
                return result = false;
            return result;
        }
        public string Verifica_Existe_Planilla_x_contratoBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.Verifica_Existe_Planilla_x_contratoDAL(pctaTo);
        }
        public DateTime obtenerPCtasxKardexContratoBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerPCtasxKardexContratoDAL(pctaTo);
        }
        public DataTable obtenerCuotasPendientesxContratoBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerCuotasPendientesxContratoDAL(pctaTo);
        }

        public DataTable obtenerCuotasPendientesxContratoSuspendidoBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerCuotasPendientesxContratoSuspendidoDAL(pctaTo);
        }
        public DataTable obtenerCuotasPendientesxContratoxIncluyendoCuotaComprometidasBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerCuotasPendientesxContratoxIncluyendoCuotaComprometidasBLL(pctaTo);
        }
        public DataTable obtenerCuotasComprometidasContratoBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerCuotasComprometidasContratoDAL(pctaTo);
        }
        public DataTable obtenerCuotasComprometidasContratoPllaDirectaBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerCuotasComprometidasContratoPllaDirectaDAL(pctaTo);
        }
        public DataTable obtenerCuotasComprometidasSoloContratoBLL(canjePCtasxCobrarTo pctaTo)
        {
            return cpcxDAL.obtenerCuotasComprometidasSoloContratoDAL(pctaTo);
        }
        public bool modificarPCtasxCambioPtoCobBLL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcxDAL.modificarPCtasxCambioPtoCobDAL(pctaTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPCtasCobrarBLL(canjePCtasxCobrarTo pctaTo, ref string errMensaje)
        {
            bool result = true;
            if (!cpcxDAL.eliminarPCtasCobrarDAL(pctaTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
