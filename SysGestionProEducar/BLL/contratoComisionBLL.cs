using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class contratoComisionBLL
    {
        contratoComisionDAL ccnDAL = new contratoComisionDAL();
        contratoComisionTo ccnTo = new contratoComisionTo();

        public DataTable obtenerContratoComisionBLL(contratoComisionTo ccnTo)
        {
            return ccnDAL.obtenerContratoComisionDAL(ccnTo);
        }
        public bool insertarContratoComisionBLL(contratoComisionTo ccnTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccnDAL.insertarContratoComisionDAL(ccnTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
