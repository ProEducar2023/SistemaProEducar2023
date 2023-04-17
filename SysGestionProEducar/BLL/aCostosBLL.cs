using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class aCostosBLL
    {
        aCostosDAL acosDAL = new aCostosDAL();
        public DataTable obtenerACostosBLL()
        {
            return acosDAL.obtenerACostosDAL();
        }
        public bool insertarACostosBLL(aCostosTo acosTo, ref string errMensaje)
        {
            bool result = true;
            if (!acosDAL.insertarACostosDAL(acosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarACostosSaldoInicialBLL(aCostosTo acosTo, ref string errMensaje)
        {
            bool result = true;
            if (!acosDAL.modificarACostosSaldoInicialDAL(acosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaIniACostosSaldoInicialBLL(aCostosTo acosTo, ref string errMensaje)
        {
            bool result = true;
            if (!acosDAL.eliminaIniACostosSaldoInicialDAL(acosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarIniACostosSaldoInicialBLL(aCostosTo acosTo, ref string errMensaje)
        {
            bool result = true;
            if (!acosDAL.insertarIniACostosSaldoInicialDAL(acosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool saldoInicialCostoBLL(aCostosTo acosTo, ref string errMensaje)
        {
            bool result = true;
            if (!acosDAL.saldoInicialCostoDAL(acosTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
