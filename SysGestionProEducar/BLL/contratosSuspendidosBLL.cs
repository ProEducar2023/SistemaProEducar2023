using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class contratosSuspendidosBLL
    {
        contratosSuspendidosDAL csDAL = new contratosSuspendidosDAL();
        public DataTable obtenerContratosSuspendidosxPtoCobBLL(contratosSuspendidosTo csTo)
        {
            return csDAL.obtenerContratosSuspendidosxPtoCobDAL(csTo);
        }
        public DataTable obtenerContratosSuspendidosActivosBLL(contratosSuspendidosTo csTo)
        {
            return csDAL.obtenerContratosSuspendidosActivosDAL(csTo);
        }
        public DataTable obtenerContratosSuspendidosActivosxContratoBLL(contratosSuspendidosTo csTo)
        {
            return csDAL.obtenerContratosSuspendidosActivosxContratoDAL(csTo);
        }
        public DataTable obtenerContratosSuspendidosxContratoBLL(contratosSuspendidosTo csTo)
        {
            return csDAL.obtenerContratosSuspendidosxContratoDAL(csTo);
        }
        public bool insertarContratosSuspendidosBLL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool result = true;
            if (!csDAL.insertarContratosSuspendidosDAL(csTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarContratosSuspendidosBLL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool result = true;
            if (!csDAL.modificarContratosSuspendidosDAL(csTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarContratosSuspendidosBLL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool result = true;
            if (!csDAL.eliminarContratosSuspendidosDAL(csTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool anularContratosSuspendidosBLL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool result = true;
            if (!csDAL.anularContratosSuspendidosDAL(csTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool desactivarContratosSuspendidosBLL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool result = true;
            if (!csDAL.desactivarContratosSuspendidosDAL(csTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool aprobarContratosSuspendidosBLL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool result = true;
            if (!csDAL.aprobarContratosSuspendidosDAL(csTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool verificaExistenciaContratoSuspendidoBLL(contratosSuspendidosTo csTo, ref string errMensaje)
        {
            bool result = true;
            if (!csDAL.verificaExistenciaContratoSuspendidoDAL(csTo, ref errMensaje))
                return result = false;
            return result;
        }
    }

}
