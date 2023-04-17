using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class pResumenComisionBLL
    {
        pResumenComisionDAL presDAL = new pResumenComisionDAL();

        public DataTable obtenerResumenComisionBLL(pResumenComisionTo presTo)
        {
            return presDAL.obtenerResumenComisionDAL(presTo);
        }
        public bool insertarResumenComisionBLL(pResumenComisionTo presTo, ref string errMensaje)
        {
            bool result = true;
            if (!presDAL.insertarResumenComisionDAL(presTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
