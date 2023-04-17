using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class personaBeneficiarioBLL
    {
        personaBeneficiarioDAL pebDAL = new personaBeneficiarioDAL();

        public DataTable obtenerPersonaBeneficiarioBLL(personaBeneficiarioTo pebTo)
        {
            return pebDAL.obtenerPersonaBeneficiarioDAL(pebTo);
        }
        public bool insertarPersonaBeneficiarioBLL(personaBeneficiarioTo pebTo, ref string errMensaje)
        {
            bool result = true;
            if (!pebDAL.insertarPersonaBeneficiarioDAL(pebTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPersonaBeneficiarioBLL(personaBeneficiarioTo pebTo, ref string errMensaje)
        {
            bool result = true;
            if (!pebDAL.eliminarPersonaBeneficiarioDAL(pebTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
