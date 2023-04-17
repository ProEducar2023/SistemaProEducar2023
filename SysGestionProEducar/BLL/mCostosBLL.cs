using DAL;
using Entidades;
namespace BLL
{
    public class mCostosBLL
    {
        mCostosDAL mCosDAL = new mCostosDAL();

        public bool modificaMCostosSaldoInicialBLL(mCostosTo mCosTo, ref string errMensaje)
        {
            bool result = true;
            if (!mCosDAL.modificaMCostosSaldoInicialDAL(mCosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificadesMCostosSaldoInicialBLL(mCostosTo mCosTo, ref string errMensaje)
        {
            bool result = true;
            if (!mCosDAL.modificadesMCostosSaldoInicialDAL(mCosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaIniMCostosSaldoInicialBLL(ref string errMensaje)
        {
            bool result = true;
            if (!mCosDAL.eliminaIniMCostosSaldoInicialDAL(ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarIniMCostosSaldoInicialBLL(mCostosTo mCosTo, ref string errMensaje)
        {
            bool result = true;
            if (!mCosDAL.insertarIniMCostosSaldoInicialDAL(mCosTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
