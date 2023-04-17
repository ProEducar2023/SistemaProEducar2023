using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class pAdelantoBLL
    {
        pAdelantoDAL padeDAL = new pAdelantoDAL();
        public DataTable obtenerP_AdelantoBLL()
        {
            return padeDAL.obtenerP_AdelantoDAL();
        }
        public bool modificarPAdelantoporLiquidacionBLL(pAdelantoTo padeTo, ref string errMensaje)
        {
            bool result = true;
            if (!padeDAL.modificarPAdelantoporLiquidacionDAL(padeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarPAdelantoporLiquidacion2BLL(pAdelantoTo padeTo, ref string errMensaje)
        {
            bool result = true;
            if (!padeDAL.modificarPAdelantoporLiquidacion2DAL(padeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool revertirPAdelantoporLiquidacionBLL(pAdelantoTo padeTo, ref string errMensaje)
        {
            bool result = true;
            if (!padeDAL.revertirPAdelantoporLiquidacionDAL(padeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool validaCierrePeriodoAdelantoGeneradoBLL(pAdelantoTo padeTo, ref bool val, ref string errMensaje)
        {
            bool result = true;
            if (!padeDAL.validaCierrePeriodoAdelantoGeneradoDAL(padeTo, ref val, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
