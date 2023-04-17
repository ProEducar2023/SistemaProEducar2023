using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class personaDireccionBLL
    {
        personaDireccionDAL pedDAL = new personaDireccionDAL();

        public DataTable obtenerPersonaDireccionBLL(personaDireccionTo pedTo)
        {
            return pedDAL.obtenerPersonalDireccionDAL(pedTo);
        }
        public bool insertarPersonaDireccionBLL(personaDireccionTo pedTo, ref string errMensaje)
        {
            bool result = true;
            if (!pedDAL.insertarPersonalDireccionDAL(pedTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPersonaDireccionBLL(personaDireccionTo pedTo, ref string errMensaje)
        {
            bool result = true;
            if (!pedDAL.eliminarPersonalDireccionDAL(pedTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
