using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class tAdelantoBLL
    {
        tAdelantoDAL tadeDAL = new tAdelantoDAL();
        public DataTable obtenerTAdelantoBLL(tAdelantoTo tadeTo)
        {
            return tadeDAL.obtenerTAdelantoDAL(tadeTo);
        }
        public bool insertarTAdelantoBLL(tAdelantoTo tadeTo, ref string errMensaje)
        {
            bool result = true;
            if (!tadeDAL.insertarTAdelantoDAL(tadeTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTAdelantoBLL(tAdelantoTo tadeTo, ref string errMensaje)
        {
            bool result = true;
            if (!tadeDAL.eliminarTAdelantoDAL(tadeTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
