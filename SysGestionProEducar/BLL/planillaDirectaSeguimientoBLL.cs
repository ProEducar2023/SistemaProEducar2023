using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class planillaDirectaSeguimientoBLL
    {
        planillaDirectaSeguimientoDAL plsDAL = new planillaDirectaSeguimientoDAL();
        cambioTipoPllaHistoricoBLL ctpBLL = new cambioTipoPllaHistoricoBLL();
        cambioTipoPllaHistoricoTo ctpTo = new cambioTipoPllaHistoricoTo();
        public DataTable obtenerPlanillaDirectaSeguimientoLlamadaBLL(planillaDirectaSeguimientoTo plsTo)
        {
            return plsDAL.obtenerPlanillaDirectaSeguimientoLlamadaDAL(plsTo);
        }
        public DataTable obtenerPlanillaDirectaSeguimientoConfirmacionPagoBLL(planillaDirectaSeguimientoTo plsTo)
        {
            return plsDAL.obtenerPlanillaDirectaSeguimientoConfirmacionPagoDAL(plsTo);
        }
        public bool insertarPlanillaDirectaSeguimientoBLL(planillaDirectaSeguimientoTo plsTo, ref string errMensaje)
        {
            bool result = true;
            if (!plsDAL.insertarPlanillaDirectaSeguimientoDAL(plsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ExisteBLL(planillaDirectaSeguimientoTo plsTo, ref string errMensaje)
        {
            bool result = true;
            if (!plsDAL.ExisteDAL(plsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPlanillaDirectaSeguimientoBLL(planillaDirectaSeguimientoTo plsTo, ref string errMensaje)
        {
            bool result = true;
            if (!plsDAL.eliminarPlanillaDirectaSeguimientoDAL(plsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool Grabar_Transferencia_CtasBLL(planillaDirectaSeguimientoTo plsTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                if (!modificaPCtasporTransferenciaBLL(plsTo, dt, ref errMensaje))
                    return result = false;
                //cambio de tipo historico
                if (!grabarCambioTipoHistorico(plsTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool grabarCambioTipoHistorico(planillaDirectaSeguimientoTo plsTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            ctpTo.NRO_CONTRATO = plsTo.NRO_CONTRATO;
            ctpTo.FECHA_CAMBIO = plsTo.FECHA_CAMBIO;
            ctpTo.TIPO_PLANILLA_CAMBIADA = plsTo.TIPO_PLA_DESTINO;
            ctpTo.COD_MOTIVO = plsTo.COD_MOTIVO;
            ctpTo.COD_AUTORIZADOR = plsTo.COD_AUTORIZADOR;
            ctpTo.CUOTAS_CAMBIADAS = plsTo.CUOTAS_CAMBIADAS;
            ctpTo.OBSERVACIONES = plsTo.OBSERVACIONES;
            ctpTo.COD_CREAR = plsTo.COD_USU_MOD;
            ctpTo.FECHA_CREAR = plsTo.FECHA_MOD;
            if (!ctpBLL.insertarCambioTipoPllaHistoricoBLL(ctpTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaPCtasporTransferenciaBLL(planillaDirectaSeguimientoTo plsTo, DataTable dt, ref string errMensaje)
        {
            canjePCtasxCobrarBLL pctasBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctasTo = new canjePCtasxCobrarTo();
            canjeTCtasxCobrarBLL tctasBLL = new canjeTCtasxCobrarBLL();
            canjeTCtasxCobrarTo tctasTo = new canjeTCtasxCobrarTo();
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                if (rw["OP"].ToString() == "True")
                {
                    //pctas por cobrar
                    pctasTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    pctasTo.NRO_LETRA = rw["LETRA"].ToString().Substring(0, 3);
                    pctasTo.TIPO_PLA_COBRANZA = plsTo.TIPO_PLA_COBRANZA;
                    pctasTo.COD_USU_MOD = plsTo.COD_USU_MOD;
                    pctasTo.FECHA_MOD = plsTo.FECHA_MOD;
                    if (!pctasBLL.modifica_P_Ctas_por_Transferencia_BLL(pctasTo, ref errMensaje))
                        return result = false;
                    //tctas por cobrar
                    tctasTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    tctasTo.NRO_LETRA = rw["LETRA"].ToString().Substring(0, 3);
                    tctasTo.TIPO_PLA_COBRANZA = plsTo.TIPO_PLA_COBRANZA;
                    tctasTo.COD_USU_MOD = plsTo.COD_USU_MOD;
                    tctasTo.FECHA_MOD = plsTo.FECHA_MOD;
                    if (!tctasBLL.modifica_T_Ctas_por_Transferencia_BLL(tctasTo, ref errMensaje))
                        return result = false;
                    //esto me dijo Miguel que lo sacara 
                    //if(pctasTo.TIPO_PLA_COBRANZA == "PD")//cuando se cambia de planilla a directa
                    //{
                    //    //seguimiento
                    //    plsTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    //    plsTo.COD_PERSONA = rw["COD_PER"].ToString();
                    //    plsTo.NRO_CUOTA = rw["LETRA"].ToString();
                    //    plsTo.TIPO = "T";
                    //    plsTo.FECHA_LLAMADA = DateTime.Now;
                    //    plsTo.COD_LLAMADA_LL = "";
                    //    plsTo.DES_LLAMADA_LL = "";
                    //    plsTo.FECHA_NUEVA_LLAMADA_LL = null;
                    //    //plsTo.OBS_LLAMADA_LL = "Transferencia";
                    //    plsTo.COD_LLAMADA_CO = "";
                    //    plsTo.DES_LLAMADA_CO = "";
                    //    plsTo.FECHA_NUEVA_LLAMADA_CO = null;
                    //    plsTo.OBS_LLAMADA_CO = "";
                    //    plsTo.FECHA_ACTIVA = DateTime.Now;
                    //    if (ExisteBLL(plsTo, ref errMensaje))
                    //    {
                    //        if (!eliminarPlanillaDirectaSeguimientoBLL(plsTo, ref errMensaje))
                    //            return result = true;
                    //    }
                    //    if (!insertarPlanillaDirectaSeguimientoBLL(plsTo, ref errMensaje))
                    //        return result = false;
                    //}
                }
            }
            return result;
        }
    }
}
