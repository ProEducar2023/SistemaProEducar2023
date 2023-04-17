using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class cargosAbonosComisionesBLL
    {
        cargosAbonosComisionesDAL cacDAL = new cargosAbonosComisionesDAL();

        public DataTable obtenerCargosAbonosComisionesBLL()
        {
            return cacDAL.obtenerCargosAbonosComisionesDAL();
        }
        public bool insertarCargosAbonosComisionesBLL(cargosAbonosComisionesTo cacTo, ref string errMensaje)
        {
            bool result = true;
            if (!cacDAL.insertarCargosAbonosComisionesDAL(cacTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarCargosAbonosComisionesBLL(cargosAbonosComisionesTo cacTo, ref string errMensaje)
        {
            bool result = true;
            if (!cacDAL.modificarCargosAbonosComisionesDAL(cacTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarCargosAbonosComisionesBLL(cargosAbonosComisionesTo cacTo, ref string errMensaje)
        {
            bool result = true;
            if (!cacDAL.eliminarCargosAbonosComisionesDAL(cacTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
