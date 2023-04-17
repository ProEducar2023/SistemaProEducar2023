using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class tLiquidacionBLL
    {
        tLiquidacionDAL tliqDAL = new tLiquidacionDAL();

        public DataTable obtenerTLiquidacionBLL()
        {
            return tliqDAL.obtenerTLiquidacionDAL();
        }
        public bool insertarTLiquidacionBLL(tLiquidacionTo tliqTo, ref string errMensaje)
        {
            bool result = true;
            if (!tliqDAL.insertarTLiquidacionDAL(tliqTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTLiquidacionBLL(tLiquidacionTo tliqTo, ref string errMensaje)
        {
            bool result = true;
            if (!tliqDAL.eliminarTLiquidacionDAL(tliqTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
