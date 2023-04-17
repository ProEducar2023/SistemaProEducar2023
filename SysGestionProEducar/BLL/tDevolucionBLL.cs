using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class tDevolucionBLL
    {
        tDevolucionDAL tdevDAL = new tDevolucionDAL();

        public DataTable obtenerTDevolucionBLL(tDevolucionTo tdevTo)
        {
            return tdevDAL.obtenerTDevolucionDAL();
        }
        public bool insertarTDevolucionBLL(tDevolucionTo tdevTo, ref string errMensaje)
        {
            bool result = true;
            if (!tdevDAL.insertarTDevolucionDAL(tdevTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTDevolucionBLL(tDevolucionTo tdevTo, ref string errMensaje)
        {
            bool result = true;
            if (!tdevDAL.eliminarTDevolucionDAL(tdevTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
