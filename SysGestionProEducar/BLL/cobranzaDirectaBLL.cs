using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class cobranzaDirectaBLL
    {
        cobranzaDirectaDAL codDAL = new cobranzaDirectaDAL();

        public bool insertarCobranzaDirectaBLL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool result = true;
            if (!codDAL.insertarCobranzaDirectaDAL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerCobranzaDirectaporLlaveBLL(cobranzaDirectaTo codTo)
        {
            return codDAL.obtenerCobranzaDirectaporLlaveDAL(codTo);
        }
        public bool eliminarCobranzaDirectaBLL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool result = true;
            if (!codDAL.eliminarCobranzaDirectaDAL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerCobranzaDirectaparaConfirmacionBLL(cobranzaDirectaTo codTo)
        {
            return codDAL.obtenerCobranzaDirectaparaConfirmacionDAL(codTo);
        }
        public DataTable MOSTRAR_CUENTA_BANCO_BLL()
        {
            return codDAL.MOSTRAR_CUENTA_BANCO_DAL();
        }
        public bool modificaTCobranzaDirectaporCorfirmacionBLL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            //bool result = true;
            ////cobranzaDirectaTo codTo=new cobranzaDirectaTo();
            //foreach (DataRow rw in dt.Rows)
            //{
            //    codTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
            //    codTo.NRO_DOC = rw["NRO_DOC"].ToString();
            //    codTo.NRO_OPERACION = rw["NRO_OPERACION"].ToString();
            //    codTo.FECHA_OPERACION = Convert.ToDateTime(rw["FECHA_OPERACION"]);
            //    codTo.COD_BANCO = rw["COD_BANCO"].ToString();
            //    codTo.COD_LLAMADA = rw["COD_LLAMADA"].ToString();
            //    codTo.FECHA_NUEVA_LLAMADA = rw["FECHA_NUEVA_LLAMADA"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA"]);
            //    codTo.IMPORTE_DEPOSITADO = rw["IMPORTE_DEPOSITADO"].ToString().Trim() == "" ? (Decimal?)null : Convert.ToDecimal(rw["IMPORTE_DEPOSITADO"]);
            //    if (!codDAL.modificaTCobranzaDirectaporCorfirmacionDAL(codTo, ref errMensaje))
            //        return result = false;
            //}
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //
                if (!codDAL.modificaTCobranzaDirectaporCorfirmacionDAL(codTo, ref errMensaje))
                    return result = false;
                //
                if (!adicionarPlanillaDirectaSeguimientoConfirmacionPagoBLL(codTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }

        }
        public bool modificaTCobranzaDirectaporCorfirmaciondeConfirmadasBLL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool result = true;
            if (!codDAL.modificaTCobranzaDirectaporCorfirmacionDAL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionarPlanillaDirectaSeguimientoConfirmacionPagoBLL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            planillaDirectaSeguimientoBLL plsBLL = new planillaDirectaSeguimientoBLL();
            planillaDirectaSeguimientoTo plsTo = new planillaDirectaSeguimientoTo();

            bool result = true;
            plsTo.NRO_CONTRATO = codTo.NRO_CONTRATO;
            plsTo.COD_PERSONA = codTo.COD_PERSONA;
            plsTo.NRO_CUOTA = codTo.NRO_CUOTA;
            plsTo.TIPO = "C"; //dt.Rows[0]["tip_pla_co"].ToString();
            plsTo.FECHA_LLAMADA = codTo.FECHA_LLAMADA;
            plsTo.COD_LLAMADA_LL = "";
            plsTo.DES_LLAMADA_LL = "";
            plsTo.FECHA_NUEVA_LLAMADA_LL = null;
            plsTo.OBS_LLAMADA_LL = "";
            plsTo.COD_LLAMADA_CO = codTo.COD_LLAMADA;
            plsTo.DES_LLAMADA_CO = HelpersBLL.OBTENER_DES_DIRECTORIO(plsTo.COD_LLAMADA_CO, "TPLAC");
            plsTo.FECHA_NUEVA_LLAMADA_CO = codTo.FECHA_NUEVA_LLAMADA;
            plsTo.OBS_LLAMADA_CO = codTo.OBSERVACIONES;
            plsTo.FECHA_ACTIVA = codTo.FECHA_LLAMADA;

            if (plsBLL.ExisteBLL(plsTo, ref errMensaje))
            {
                if (!plsBLL.eliminarPlanillaDirectaSeguimientoBLL(plsTo, ref errMensaje))
                    return result = true;
            }
            if (!plsBLL.insertarPlanillaDirectaSeguimientoBLL(plsTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaTCobranzaDirectaporCierreBLL(cobranzaDirectaTo codTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            //foreach(DataRow rw in dt.Rows)
            //{
            //    codTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
            //    codTo.NRO_DOC = rw["NRO_DOC"].ToString();
            //    codTo.COD_LLAMADA = rw["COD_LLAMADA"].ToString();
            //    //codTo.FECHA_CONFIRMADA = rw["FECHA_NUEVA_LLAMADA"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA"]);
            //    if (codTo.COD_LLAMADA == "02")//VOLVER A LLAMAR
            //    {
            //        codTo.FECHA_CONFIRMADA = Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA"]);
            //        codTo.FECHA_NUEVA_LLAMADA = null;
            //    }
            //    else
            //        codTo.FECHA_CONFIRMADA = null;

            //    codTo.STATUS_CONFIRMACION = "1";
            //    if (!codDAL.modificaTCobranzaDirectaporCierreDAL(codTo, ref errMensaje))
            //        return result = false;
            //}
            foreach (DataRow rw in dt.Rows)
            {
                codTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                codTo.NRO_DOC = rw["NRO_DOC"].ToString();
                codTo.COD_LLAMADA = rw["COD_LLAMADA"].ToString();
                if (codTo.COD_LLAMADA == "01")//VOLVER A LLAMAR
                {
                    codTo.STATUS_CONFIRMACION = "1";
                }
                else if (codTo.COD_LLAMADA == "02")//VOLVER A LLAMAR
                {
                    codTo.FECHA_CONFIRMADA = rw["FECHA_NUEVA_LLAMADA"].ToString() == "" ? codTo.FECHA_NUECVA_ACTIVA : Convert.ToDateTime(rw["FECHA_NUEVA_LLAMADA"]);
                    codTo.FECHA_NUEVA_LLAMADA = null;
                    codTo.STATUS_CONFIRMACION = null;
                }
                else //if (codTo.COD_LLAMADA != "01")//PAGO EFECTUADO
                {
                    codTo.FECHA_CONFIRMADA = codTo.FECHA_NUECVA_ACTIVA;
                    codTo.FECHA_NUEVA_LLAMADA = null;
                    codTo.STATUS_CONFIRMACION = null;
                }
                if (!codDAL.modificaTCobranzaDirectaporCierreDAL(codTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public DataTable obtenerCobranzaDirectaparaCobranzaBLL(cobranzaDirectaTo codTo)
        {
            return codDAL.obtenerCobranzaDirectaparaCobranzaDAL(codTo);
        }
        public bool exiseTCobranzaDirectaBLL(cobranzaDirectaTo codTo, ref string errMensaje)
        {
            bool result = true;
            if (!codDAL.exiseTCobranzaDirectaDAL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
