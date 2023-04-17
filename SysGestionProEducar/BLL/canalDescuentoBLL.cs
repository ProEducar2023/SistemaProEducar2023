using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class canalDescuentoBLL
    {
        canalDescuentoDAL cadDAL = new canalDescuentoDAL();
        canalDescuentoTo cadTo = new canalDescuentoTo();

        public DataTable ObtenerCanalDescuentoBLL()
        {
            return cadDAL.ObtenerCanalDescuentoDAL();
        }
        public bool insertaCanalDescuentoBLL(canalDescuentoTo cadTo, ref string errMensaje)
        {
            bool result = true;
            if (!cadDAL.insertaCanalDescuentoDAL(cadTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaCanalDescuentoBLL(canalDescuentoTo cadTo, ref string errMensaje)
        {
            bool result = true;
            if (!cadDAL.actualizaCanalDescuentoDAL(cadTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaCanalDescuentoBLL(string COD, ref string errMensaje)
        {
            bool result = true;
            cadTo.COD = COD;
            if (!cadDAL.eliminaCanalDescuentoDAL(cadTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
