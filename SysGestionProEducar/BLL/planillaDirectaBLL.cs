using DAL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Transactions;
namespace BLL
{
    public class planillaDirectaBLL
    {
        planillaDirectaDAL pldDAL = new planillaDirectaDAL();
        cobranzaDirectaBLL codBLL = new cobranzaDirectaBLL();
        cobranzaDirectaTo codTo = new cobranzaDirectaTo();
        public DataTable mostrar_Contratos_Vencidos_a_la_FechaBLL(planillaDirectaTo pldTo)
        {
            return pldDAL.mostrar_Contratos_Vencidos_a_la_FechaDAL(pldTo);
        }
        public DataTable obtenerPlanillaDirectaBLL(planillaDirectaTo pldTo)
        {
            return pldDAL.obtenerPlanillaDirectaDAL(pldTo);
        }
        public DataTable obtenerPlanillaDirectaporLlaveBLL(planillaDirectaTo pldTo)
        {
            return pldDAL.obtenerPlanillaDirectaporLlaveDAL(pldTo);
        }
        public bool cierraPlanillaDirectaBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cierra los registros del dia de T_Planilla_Directa
                if (!modificaTPlanillaDirectaporCierreBLL(pldTo, ref errMensaje))//De las llamadas que se registraron ese dia, se filtran las que tuvieron codllamada 02, pues esas son volver a llamar y en su fecha llamada se actualiza con la fecha nueva llamada que puso en el formulario llamadas y las codllamada diferente 02 se actualiza la fecha llamada al a la fecha del dia siguiente
                    return result = false;
                //
                if (!generaPlanillaDirectaBLL(pldTo, ref errMensaje))
                    return result = false;
                //
                if (!pldDAL.modificaPCtasCobrarporLlamadaConfirmadaDAL(pldTo, ref errMensaje))
                    return result = false;
                //cierre de llamadas confirmadas
                if (pldTo.TIPO == "D")
                {
                    if (!modificaTCobranzaDirectaporCierreBLL(pldTo, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        private bool modificaTCobranzaDirectaporCierreBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            cobranzaDirectaBLL codBLL = new cobranzaDirectaBLL();
            cobranzaDirectaTo codTo = new cobranzaDirectaTo();
            bool result = true;
            codTo.FECHA_CONFIRMADA = pldTo.FECHA_LLAMADA;
            codTo.FECHA_NUECVA_ACTIVA = pldTo.FECHA_NUEVA_LLAMADA;
            codTo.COD_MOD = pldTo.COD_CREACION;
            codTo.FECHA_MOD = pldTo.FECHA_CREACION;
            DataTable dt = codBLL.obtenerCobranzaDirectaparaConfirmacionBLL(codTo);
            if (!codBLL.modificaTCobranzaDirectaporCierreBLL(codTo, dt, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificaTPlanillaDirectaporCierreBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.modificaTPlanillaDirectaporCierre1BLL(pldTo, ref errMensaje))
                return result = false;
            //actualizacion de la fecha Activa
            if (!actualizaFechaActivaBLL(pldTo, ref errMensaje))
                return result = false;
            //
            if (!pldDAL.modificaTPlanillaDirectaporCierre2BLL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool actualizaFechaActivaBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            calendarioBLL calBLL = new calendarioBLL();
            calendarioTo calTo = new calendarioTo();
            DateTime fec = pldTo.FECHA_VEN;
            fec = fec.AddDays(1);
            while (esFeriado(fec, pldTo, ref errMensaje))
            {
                fec = fec.AddDays(1);
            }
            if (errMensaje == "")
            {
                calTo.FECHA_ACTIVA = fec;
                calTo.COD_MOD = pldTo.COD_CREACION;
                calTo.FECHA_MOD = pldTo.FECHA_CREACION;
                //pldTo.FECHA_LLAMADA = calTo.FECHA_ACTIVA;//para que cuando cierre la fecha llamada en T_Planilla_Directa sea esa fecha del dia siguiente
                pldTo.FECHA_NUEVA_LLAMADA = fec;//se  prepara para actualizar las llamadas que no se hicieron en T_Planilla_Directa de la fecha activa actual
                calTo.TIPO = pldTo.TIPO;
                if (!calBLL.modificarFechaActivaBLL(calTo, ref errMensaje))
                    return result = false;
            }
            else
            {
                return result = false;
            }

            return result;
        }
        private bool esFeriado(DateTime fec, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.esFeriadoDAL(fec, pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool generaPlanillaDirectaBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL pcoBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pcoTo = new canjePCtasxCobrarTo();
            DataTable dt = mostrar_Contratos_Vencidos_a_la_FechaBLL(pldTo);
            DataTable dt1 = obtenerResumenPlanillaDirecta(dt);//sumariza las cuotas del mismo contrato
            if (dt1.Rows.Count > 0)
            {
                //if (!crearPlanillaDirectaContratosporVencerBLL(pldTo, dt, ref errMensaje))
                //    return result = false;

                foreach (DataRow rw in dt1.Rows)
                {
                    pldTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    pldTo.COD_PERSONA = rw["COD_PER"].ToString();
                    if (existeTPlanillaDirectaBLL(pldTo, ref errMensaje))
                    {
                        //modifica T_PLANILLA_DIRECTA
                        pldTo.IMPORTE_CUOTA = Convert.ToDecimal(rw["IMP_INI"]);
                        if (!modificaTPlanillaDirectaporContratosporCierreBLL(pldTo, ref errMensaje))
                            return result = false;
                    }
                    else
                    {
                        if (errMensaje == "")
                        {
                            //adiciona T_PLANILLA_DIRECTA
                            pldTo.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_CONTRATO"]);
                            //pldTo.FECHA_LLAMADA = DateTime.Now;
                            //pldTo.IMPORTE_CUOTA = Convert.ToDecimal(rw["IMPORTE_CUOTA"]);
                            pldTo.CANT_CUOTA = Convert.ToInt32(rw["CANT_CUOTA"]);
                            pldTo.IMPORTE_CUOTA = Convert.ToDecimal(rw["IMP_INI"]);
                            if (!insertaTPlanillaDirectaporContratosporVencerBLL(pldTo, ref errMensaje))
                                return result = false;
                        }
                        else
                        {
                            return result = false;
                        }
                    }

                }
            }
            else
            {
                errMensaje = "0000";//NO EXISTEN REGISTROS CON FECHA VENCIMIENTO DEL DIA
                //return result = false;
            }
            ////
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    //modifica PCTAS_COBRAR
                    pcoTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    pcoTo.NRO_DOC = rw["NRO_DOC"].ToString();
                    pcoTo.FECHA_VEN = pldTo.FECHA_VEN;//esto creo que no va
                    pcoTo.COD_USU_MOD = pldTo.COD_CREACION;
                    pcoTo.FECHA_MOD = pldTo.FECHA_CREACION;
                    if (!pcoBLL.modificaPCtasCobrarporContratosporVencerBLL(pcoTo, ref errMensaje))
                        return result = false;
                }
            }

            return result;
        }
        private DataTable obtenerResumenPlanillaDirecta(DataTable dt)
        {
            DataTable dtTPD = new DataTable();
            if (dt.Rows.Count > 0)
            {
                dtTPD = dt.AsEnumerable()
                .GroupBy(r => new { NRO_CONTRATO = r.Field<string>("NRO_CONTRATO"), COD_PER = r.Field<string>("COD_PER"), FECHA_CONTRATO = r.Field<DateTime>("FECHA_CONTRATO") })
                .Select(g =>
                {
                    var row = dt.NewRow();

                    row["NRO_CONTRATO"] = g.Key.NRO_CONTRATO;
                    row["COD_PER"] = g.Key.COD_PER;
                    row["FECHA_CONTRATO"] = g.Key.FECHA_CONTRATO;
                    row["IMP_INI"] = g.Sum(r => r.Field<decimal>("IMP_INI"));
                    row["CANT_CUOTA"] = g.Sum(r => r.Field<int>("CANT_CUOTA"));

                    return row;
                }).CopyToDataTable();
            }
            return dtTPD;
        }
        public DataTable Mostrar_Cobranza_Planilla_por_Llamada_BLL(planillaDirectaTo pldTo)
        {
            return pldDAL.Mostrar_Cobranza_Planilla_por_Llamada_DAL(pldTo);
        }
        public bool crearPlanillaDirectaBLL(planillaDirectaTo pldTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //
                //int cant = dt.AsEnumerable().Where(x => x.Field<string>("respuesta") == "01").Count();
                if (!adicionarPlanillaDirecta(pldTo, dt, ref errMensaje))
                    return result = false;
                //
                if (!adicionarPlanillaDirectaSeguimientoConfirmacionLlamadaBLL(pldTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        private bool adicionarPlanillaDirectaSeguimientoConfirmacionLlamadaBLL(planillaDirectaTo pldTo, DataTable dt, ref string errMensaje)
        {
            planillaDirectaSeguimientoBLL plsBLL = new planillaDirectaSeguimientoBLL();
            planillaDirectaSeguimientoTo plsTo = new planillaDirectaSeguimientoTo();

            bool result = true;
            plsTo.NRO_CONTRATO = dt.Rows[0]["nrocontrato"].ToString();
            plsTo.COD_PERSONA = dt.Rows[0]["codpersona"].ToString();
            plsTo.NRO_CUOTA = dt.Rows[0]["letra"].ToString();
            plsTo.TIPO = "L"; //dt.Rows[0]["tip_pla_co"].ToString();
            plsTo.FECHA_LLAMADA = Convert.ToDateTime(dt.Rows[0]["fechallamada"]);
            plsTo.COD_LLAMADA_LL = dt.Rows[0]["respuesta"].ToString();
            plsTo.DES_LLAMADA_LL = HelpersBLL.OBTENER_DES_DIRECTORIO(plsTo.COD_LLAMADA_LL, "TPLAD");
            plsTo.FECHA_NUEVA_LLAMADA_LL = Convert.ToDateTime(dt.Rows[0]["fechaconfirmada"]);
            plsTo.OBS_LLAMADA_LL = dt.Rows[0]["observaciones"].ToString();
            plsTo.COD_LLAMADA_CO = "";
            plsTo.DES_LLAMADA_CO = "";
            plsTo.FECHA_NUEVA_LLAMADA_CO = null;
            plsTo.OBS_LLAMADA_CO = "";
            plsTo.FECHA_ACTIVA = pldTo.FECHA_LLAMADA;

            if (plsBLL.ExisteBLL(plsTo, ref errMensaje))
            {
                if (!plsBLL.eliminarPlanillaDirectaSeguimientoBLL(plsTo, ref errMensaje))
                    return result = true;
            }
            if (!plsBLL.insertarPlanillaDirectaSeguimientoBLL(plsTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificaPCtasCobrarBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            if (!pccBLL.modifica_P_Ctas_por_Generacion_Planilla_BLL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionarPlanillaDirecta(planillaDirectaTo pldTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            bool op = false;
            foreach (DataRow rw in dt.Rows)
            {
                if (rw["respuesta"].ToString() == "01")
                {
                    pldTo.VISTO_CONFIRMADO = true;
                    if (existeTCobranzaDirectaBLL(rw, ref errMensaje))//si existe actualiza sino agrega
                    {
                        //actualiza T_Cobranza_Directa
                        if (!modificaTCobranzaDirectaporConfirmacionBLL(rw, pldTo, ref errMensaje))
                            return result = false;
                        //Actualiza T_PLANILLA_DIRECTA pues se debe poner un visto para avisar que hay una cuota confirmada
                        if (!actualizaTPlanillaDirectaporConfirmacionBLL(rw, pldTo, ref errMensaje))
                            return result = false;
                    }
                    else
                    {
                        if (errMensaje == "")
                        {
                            if (!adicionaCobranzaDirecta(rw, pldTo, ref errMensaje))
                                return result = false;
                            //DISMINUYE EN UNO LA CANTIDAD DE CUOTAS QUE TENIA Y SE RESTA EL IMPORTE SE VA A PAGAR
                            if (!actualizaPlanillaDirectaporLlamadaConfirmada(rw, pldTo, ref errMensaje))
                                return result = false;
                        }
                        else
                            return result = false;

                    }
                    op = true;
                }
                else
                {
                    if (rw["respuesta"].ToString().Trim() != "")
                    {
                        if (op)//si ya ingreso cod_llamada 01 entonces no debe chancar la observacion del siguiente registro
                        {
                            //rw["fechaconfirmada"] = null;
                            //rw["observaciones"] = null;
                            pldTo.VISTO_CONFIRMADO = null;
                        }
                        else
                        {
                            pldTo.VISTO_CONFIRMADO = false;
                        }
                        if (!actualizaPlanillaDirectaporLlamadaNoConfirmada(rw, pldTo, ref errMensaje))
                            return result = false;
                        op = false;
                    }
                    break;
                }
            }
            return result;
        }
        public bool modificaTCobranzaDirectaporConfirmacionBLL(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            codTo.NRO_CONTRATO = rw["nrocontrato"].ToString();
            codTo.COD_PERSONA = rw["codpersona"].ToString();
            codTo.COD_DOC = rw["coddoc"].ToString();
            codTo.NRO_DOC = rw["nrodoc"].ToString();
            codTo.FECHA_CONTRATO = Convert.ToDateTime(rw["fechacontrato"]);
            codTo.COD_LLAMADA = rw["respuesta"].ToString();
            codTo.FECHA_LLAMADA = rw["fechallamada"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["fechallamada"]);
            codTo.FECHA_CONFIRMADA = rw["fechaconfirmada"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["fechaconfirmada"]);
            codTo.IMPORTE_PAGO = Convert.ToDecimal(rw["importe"]);
            codTo.TIPO_PLA_ORIGEN = "D";
            codTo.TIPO_PLA_COBRANZA = "D";
            codTo.NRO_LETRA = rw["letra"].ToString().Substring(0, 3);
            codTo.TOTAL_LETRA = rw["letra"].ToString().Substring(6, 3);
            codTo.OBSERVACIONES = rw["observaciones"].ToString();
            codTo.COD_MOD = pldTo.COD_CREACION;
            codTo.FECHA_MOD = pldTo.FECHA_MOD;
            if (!codBLL.modificaTCobranzaDirectaporCorfirmaciondeConfirmadasBLL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool existeTCobranzaDirectaBLL(DataRow rw, ref string errMensaje)
        {
            bool result = true;
            codTo.NRO_CONTRATO = rw["nrocontrato"].ToString();
            codTo.COD_PERSONA = rw["codpersona"].ToString();
            codTo.COD_DOC = rw["coddoc"].ToString();
            codTo.NRO_DOC = rw["nrodoc"].ToString();
            if (!codBLL.exiseTCobranzaDirectaBLL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool actualizaPlanillaDirectaporLlamadaNoConfirmada(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            pldTo.NRO_CONTRATO = rw["nrocontrato"].ToString();
            pldTo.COD_PERSONA = rw["codpersona"].ToString();
            pldTo.COD_LLAMADA = rw["respuesta"].ToString();
            //pldTo.FECHA_NUEVA_LLAMADA = rw["fechaconfirmada"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["fechaconfirmada"]);
            pldTo.FECHA_NUEVA_LLAMADA = rw["fechaconfirmada"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rw["fechaconfirmada"]);
            //pldTo.OBSERVACIONES = Environment.NewLine + Environment.NewLine + rw["observaciones"].ToString();
            //pldTo.OBSERVACIONES = rw["observaciones"].ToString();
            pldTo.OBSERVACIONES = rw["observaciones"] == null ? null : rw["observaciones"].ToString();
            pldTo.COD_MOD = pldTo.COD_CREACION;
            pldTo.FECHA_MOD = pldTo.FECHA_MOD;
            if (!modificarPlanillaDirectaBLL(pldTo, ref errMensaje))
                return result;
            return result;
        }
        private bool actualizaPlanillaDirectaporLlamadaNoConfirmadaRehacer(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            pldTo.NRO_CONTRATO = rw["nrocontrato"].ToString();
            pldTo.COD_PERSONA = rw["codpersona"].ToString();
            pldTo.COD_LLAMADA = null;
            pldTo.FECHA_NUEVA_LLAMADA = null;
            pldTo.OBSERVACIONES = null;
            pldTo.COD_MOD = pldTo.COD_CREACION;
            pldTo.FECHA_MOD = pldTo.FECHA_MOD;
            if (!modificarPlanillaDirectaRehacerBLL(pldTo, ref errMensaje))
                return result;
            return result;
        }
        private bool actualizaPCtasCobrarporLlamadaConfirmada(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL pccBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pccTo = new canjePCtasxCobrarTo();
            //aqui se tendria que poner la sucursal y cambiar el sp y poner isnull
            pccTo.COD_SUCURSAL = null;
            pccTo.NRO_CONTRATO = rw["nrocontrato"].ToString();
            pccTo.NRO_DOC = rw["nrodoc"].ToString();
            pccTo.STATUS_GENERADO = "1";
            pccTo.COD_USU_MOD = pldTo.COD_CREACION;
            pccTo.FECHA_MOD = pldTo.FECHA_MOD;
            if (!pccBLL.modifica_P_Ctas_por_Generacion_Planilla_BLL(pccTo, ref errMensaje))
                return result = false;

            return result;
        }
        private bool actualizaPlanillaDirectaporLlamadaConfirmada(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            pldTo.IMPORTE_CUOTA = Convert.ToDecimal(rw["importe"]);
            pldTo.COD_PERSONA = rw["codpersona"].ToString();
            //pldTo.FECHA_NUEVA_LLAMADA = Convert.ToDateTime(rw["fechaconfirmada"]);
            //pldTo.OBSERVACIONES = rw["observaciones"].ToString();
            if (!pldDAL.modificarPlanillaDirectaporLlamadaDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool adicionaCobranzaDirecta(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;

            codTo.NRO_CONTRATO = rw["nrocontrato"].ToString();
            codTo.COD_PERSONA = rw["codpersona"].ToString();
            codTo.COD_DOC = rw["coddoc"].ToString();
            codTo.NRO_DOC = rw["nrodoc"].ToString();
            codTo.FECHA_CONTRATO = Convert.ToDateTime(rw["fechacontrato"]);
            codTo.FECHA_LLAMADA = rw["fechallamada"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["fechallamada"]);
            codTo.FECHA_CONFIRMADA = rw["fechaconfirmada"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(rw["fechaconfirmada"]);
            codTo.IMPORTE_PAGO = Convert.ToDecimal(rw["importe"]);
            codTo.TIPO_PLA_ORIGEN = "D";
            codTo.TIPO_PLA_COBRANZA = "D";
            codTo.NRO_LETRA = rw["letra"].ToString().Substring(0, 3);
            codTo.TOTAL_LETRA = rw["letra"].ToString().Substring(6, 3);
            codTo.OBSERVACIONES = rw["observaciones"].ToString();
            codTo.COD_CREACION = pldTo.COD_CREACION;
            codTo.FECHA_CREACION = pldTo.FECHA_MOD;
            if (!codBLL.insertarCobranzaDirectaBLL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarPlanillaDirectaBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.modificarPlanillaDirectaDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarPlanillaDirectaRehacerBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.modificarPlanillaDirectaRehacerDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarRehacerBLL(planillaDirectaTo pldTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                if (!rehacerPlanillaDirectaBLL(pldTo, dt, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool rehacerPlanillaDirectaBLL(planillaDirectaTo pldTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                if (rw["respuesta"].ToString() == "01")
                {
                    if (!eliminaCobranzaDirecta(rw, pldTo, ref errMensaje))
                        return result = false;
                    //
                    if (!actualizaPlanillaDirectaporLlamadaConfirmadaRehacer(rw, pldTo, ref errMensaje))
                        return result = false;
                }
                else
                {
                    if (rw["respuesta"].ToString().Trim() != "")
                    {
                        if (!actualizaPlanillaDirectaporLlamadaNoConfirmadaRehacer(rw, pldTo, ref errMensaje))
                            return result = false;
                    }
                }
            }
            return result;
        }
        private bool eliminaCobranzaDirecta(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            cobranzaDirectaBLL codBLL = new cobranzaDirectaBLL();
            cobranzaDirectaTo codTo = new cobranzaDirectaTo();
            codTo.NRO_CONTRATO = rw["nrocontrato"].ToString();
            codTo.COD_PERSONA = rw["codpersona"].ToString();
            codTo.COD_DOC = rw["coddoc"].ToString();
            codTo.NRO_DOC = rw["nrodoc"].ToString();

            if (!codBLL.eliminarCobranzaDirectaBLL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool actualizaPlanillaDirectaporLlamadaConfirmadaRehacer(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            pldTo.IMPORTE_CUOTA = Convert.ToDecimal(rw["importe"]);
            pldTo.COD_PERSONA = rw["codpersona"].ToString();
            //pldTo.OBSERVACIONES = rw["observaciones"].ToString();
            if (!pldDAL.modificarPlanillaDirectaporLlamadaRehacerDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool crearPlanillaDirectaContratosporVencerBLL(planillaDirectaTo pldTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //int cant = dt.AsEnumerable().Where(x => x.Field<string>("respuesta") == "01").Count();

                foreach (DataRow rw in dt.Rows)
                {
                    pldTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    pldTo.COD_PERSONA = rw["COD_PER"].ToString();
                    if (existeTPlanillaDirectaBLL(pldTo, ref errMensaje))
                    {
                        //modifica T_PLANILLA_DIRECTA
                        pldTo.IMPORTE_CUOTA = Convert.ToDecimal(rw["IMP_INI"]);
                        if (!modificaTPlanillaDirectaporContratosporVencerBLL(pldTo, ref errMensaje))
                            return result = false;
                    }
                    else
                    {
                        if (errMensaje == "")
                        {
                            //adiciona T_PLANILLA_DIRECTA
                            pldTo.FECHA_CONTRATO = Convert.ToDateTime(rw["FECHA_CONTRATO"]);
                            //pldTo.FECHA_LLAMADA = DateTime.Now;
                            pldTo.CANT_CUOTA = 1;
                            pldTo.IMPORTE_CUOTA = Convert.ToDecimal(rw["IMPORTE_CUOTA"]);
                            if (!insertaTPlanillaDirectaporContratosporVencerBLL(pldTo, ref errMensaje))
                                return result = false;
                        }
                        else
                        {
                            return result = false;
                        }
                    }
                    //modifica PCTAS_COBRAR
                    canjePCtasxCobrarBLL pcoBLL = new canjePCtasxCobrarBLL();
                    canjePCtasxCobrarTo pcoTo = new canjePCtasxCobrarTo();
                    pcoTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    pcoTo.NRO_DOC = rw["NRO_DOC"].ToString();
                    pcoTo.FECHA_VEN = pldTo.FECHA_VEN;
                    pcoTo.COD_USU_MOD = pldTo.COD_CREACION;
                    pcoTo.FECHA_MOD = pldTo.FECHA_CREACION;
                    if (!pcoBLL.modificaPCtasCobrarporContratosporVencerBLL(pcoTo, ref errMensaje))
                        return result = false;

                }
                ts.Complete();
                return result;
            }
        }
        public bool existeTPlanillaDirectaBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.existeTPlanillaDirectaDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaTPlanillaDirectaporContratosporVencerBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.modificaTPlanillaDirectaporContratosporVencerDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaTPlanillaDirectaporContratosporCierreBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.modificaTPlanillaDirectaporContratosporCierreDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertaTPlanillaDirectaporContratosporVencerBLL(planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldDAL.insertaTPlanillaDirectaporContratosporVencerDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaTPlanillaDirectaporConfirmacionBLL(DataRow rw, planillaDirectaTo pldTo, ref string errMensaje)
        {
            bool result = true;
            //pldTo.FECHA_NUEVA_LLAMADA = Convert.ToDateTime(rw["fechaconfirmada"]);
            //pldTo.OBSERVACIONES = rw["observaciones"].ToString();
            if (!pldDAL.actualizaTPlanillaDirectaporConfirmacionDAL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
