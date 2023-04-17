using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class eq_vta_nivel_progBLL
    {
        eq_vta_nivel_progDAL eqvDAL = new eq_vta_nivel_progDAL();
        eq_vta_nivel_progTo eqvTo = new eq_vta_nivel_progTo();

        public DataTable obtenerEquipoBLL()
        {
            return eqvDAL.obtenerEquipoDAL();
        }
        public DataTable obtenerEquipoCobBLL()
        {
            return eqvDAL.obtenerEquipoCobDAL();
        }
        public bool adicionaEqVentasProgNivBLL(eq_vta_nivel_progTo eqvTo, DataTable dtProgNiv, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Cabecera
                if (!insertarEquipoBLL(eqvTo, ref errMensaje))
                    return result = false;
                //adiciona en Detalle
                if (!adicionaProgNivelBLL(eqvTo.COD_EQVTA, dtProgNiv, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificaActualizaEqVentasProgNivBLL(eq_vta_nivel_progTo eqvTo, DataTable dtProgNiv, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina ProgNivel para volver a crearlo
                if (!eliminaProgNivelporCodPerBLL(eqvTo.COD_EQVTA, ref errMensaje))
                    return result = false;
                //adiciona en Cabecera
                if (!modificarEquipoBLL(eqvTo, ref errMensaje))
                    return result = false;
                //adiciona en Detalle
                if (!adicionaProgNivelBLL(eqvTo.COD_EQVTA, dtProgNiv, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool insertarEquipoBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool result = true;
            if (!eqvDAL.insertarEquipoDAL(eqvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaProgNivelBLL(string codper, DataTable dt, ref string errMensaje)
        {
            progNivelBLL prniBLL = new progNivelBLL();
            progNivelTo prniTo = new progNivelTo();
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                prniTo.COD_PER = codper;
                prniTo.COD_PROGRAMA = rw["codp"].ToString();
                prniTo.DESC_PROGRAMA = rw["desp"].ToString();
                prniTo.COD_NIVEL = rw["codni"].ToString();
                prniTo.DESC_NIVEL = rw["desni"].ToString();
                prniTo.ACTIVIDAD = Convert.ToBoolean(rw["actprogni"]);
                prniTo.TIPO_PLANILLA = rw["tip"].ToString();
                prniTo.NUMERACION = Convert.ToBoolean(rw["numeracion"]);
                if (!prniBLL.insertarProgramaNivelBLL(prniTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool eliminaProgNivelporCodPerBLL(string codper, ref string errMensaje)
        {
            progNivelBLL prniBLL = new progNivelBLL();
            progNivelTo prniTo = new progNivelTo();
            bool result = true;
            prniTo.COD_PER = codper;
            if (!prniBLL.eliminarProgramaNivelporCodPerBLL(prniTo, ref errMensaje))//tabla PROG_NIVEL
                return result = false;
            return result;
        }
        public bool modificarEquipoBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool result = true;
            if (!eqvDAL.modificarEquipoDAL(eqvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarEquipoBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)/////////////tabla EQ_VTA_NIVEL_PROG
        {
            bool result = true;
            if (!eqvDAL.eliminarEquipoDAL(eqvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaEqCobranzaProgNivBLL(eq_vta_nivel_progTo eqvTo, DataTable dtProgNiv, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Cabecera
                if (!insertarEquipoCobranzaBLL(eqvTo, ref errMensaje))
                    return result = false;
                //adiciona en Detalle
                if (!adicionaProgNivelCobranzaBLL(eqvTo.COD_EQVTA, dtProgNiv, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }

        public bool insertarEquipoCobranzaBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool result = true;
            if (!eqvDAL.insertarEquipoCobranzaDAL(eqvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaProgNivelCobranzaBLL(string codper, DataTable dt, ref string errMensaje)
        {
            progNivelBLL prniBLL = new progNivelBLL();
            progNivelTo prniTo = new progNivelTo();
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                prniTo.COD_PER = codper;
                prniTo.COD_PROGRAMA = rw["codp"].ToString();
                prniTo.DESC_PROGRAMA = rw["desp"].ToString();
                prniTo.COD_NIVEL = rw["codni"].ToString();
                prniTo.DESC_NIVEL = rw["desni"].ToString();
                prniTo.TIPO_PLANILLA = rw["tip"].ToString();
                prniTo.ACTIVIDAD = Convert.ToBoolean(rw["actprogni"]);
                if (!prniBLL.insertarProgramaNivelCobranzaBLL(prniTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool modificaActualizaEqCobranzaProgNivBLL(eq_vta_nivel_progTo eqvTo, DataTable dtProgNiv, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina ProgNivel para volver a crearlo
                if (!eliminaProgNivelporCodPerCobranzaBLL(eqvTo.COD_EQVTA, ref errMensaje))
                    return result = false;
                //adiciona en Cabecera
                if (!modificarEquipoCobranzaBLL(eqvTo, ref errMensaje))
                    return result = false;
                //adiciona en Detalle
                if (!adicionaProgNivelCobranzaBLL(eqvTo.COD_EQVTA, dtProgNiv, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminaProgNivelporCodPerCobranzaBLL(string codper, ref string errMensaje)
        {
            progNivelBLL prniBLL = new progNivelBLL();
            progNivelTo prniTo = new progNivelTo();
            bool result = true;
            prniTo.COD_PER = codper;
            if (!prniBLL.eliminarProgramaNivelporCodPerCobranzaBLL(prniTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarEquipoCobranzaBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool result = true;
            if (!eqvDAL.modificarEquipoCobranzaDAL(eqvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaEqVentaBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //
                if (!eliminarEquipoBLL(eqvTo, ref errMensaje))
                    return result = false;
                //
                if (!eliminaProg_Nivel_RelacionBLL(eqvTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool eliminaProg_Nivel_RelacionBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            bool result = true;
            progNivelRelacionBLL pnrBLL = new progNivelRelacionBLL();
            progNivelRelacionTo pnrTo = new progNivelRelacionTo();
            pnrTo.COD_VEND = eqvTo.COD_EQVTA;

            if (!pnrBLL.eliminarProgNivelRelacionBLL(pnrTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaEqCobranzaProgNivBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina PROG_NIVEL_COBRANZA
                if (!eliminaProg_Nivel_CobranzaBLL(eqvTo, ref errMensaje))
                    return result = false;
                //elimina EQ_COB_NIVEL_PROG
                if (!eliminaEqCobranzaNivProgBLL(eqvTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }

        }
        public bool eliminaProg_Nivel_CobranzaBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)/////////////tabla PROG_NIVEL_COBRANZA 
        {
            bool result = true;
            progNivelRelacionBLL pnrBLL = new progNivelRelacionBLL();
            progNivelRelacionTo pnrTo = new progNivelRelacionTo();
            pnrTo.COD_VEND = eqvTo.COD_EQVTA;
            if (!pnrBLL.eliminarProgNivelCobranzaBLL(pnrTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaEqCobranzaNivProgBLL(eq_vta_nivel_progTo eqvTo, ref string errMensaje)/////////////tabla EQ_COB_NIVEL_PROG
        {
            bool result = true;
            if (!eqvDAL.eliminaEqCobranzaNivProgDAL(eqvTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
