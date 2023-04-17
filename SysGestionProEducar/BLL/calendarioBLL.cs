using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class calendarioBLL
    {
        calendarioDAL calDAL = new calendarioDAL();

        public DataTable obtenerCalendarioBLL(calendarioTo calTo)
        {
            return calDAL.obtenerCalendarioDAL(calTo);
        }
        public bool insertarCalendarioBLL(DataTable dt, string tipo, ref string errMensaje)
        {
            bool result = true;
            calendarioTo calTo = new calendarioTo();
            foreach (DataRow rw in dt.Rows)
            {
                calTo.NuAño = rw["NuAño"].ToString();
                calTo.NuMes = rw["NuMes"].ToString();
                calTo.NuDia = int.Parse(rw["NuDia"].ToString());
                calTo.FlFeriado = true;
                calTo.TIPO = tipo;
                if (!calDAL.insertarCalendarioDAL(calTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public bool modificarActualizarCalendarioBLL(calendarioTo calTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina
                if (!eliminarCalendarioBLL(calTo, ref errMensaje))
                    return result = false;
                //inserta
                if (!insertarCalendarioBLL(dt, calTo.TIPO, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminarCalendarioBLL(calendarioTo calTo, ref string errMensaje)
        {
            bool result = true;
            if (!calDAL.eliminarCalendarioDAL(calTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerCalendarioDiasBLL(calendarioTo calTo)
        {
            return calDAL.obtenerCalendarioDiasDAL(calTo);
        }
        public DateTime? obtenerFechaActivaBLL(calendarioTo calTo)
        {
            return calDAL.obtenerFechaActivaDAL(calTo);
        }
        public bool modificarFechaActivaBLL(calendarioTo calTo, ref string errMensaje)
        {
            bool result = true;
            if (!calDAL.modificarFechaActivaDAL(calTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool caeFeriadoBLL(calendarioTo calTo, ref string errMensaje)
        {
            bool result = true;
            if (!calDAL.caeFeriadoDAL(calTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
