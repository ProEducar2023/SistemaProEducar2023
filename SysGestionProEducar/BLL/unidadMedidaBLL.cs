using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class unidadMedidaBLL
    {
        unidadMedidaDAL umDAL = new unidadMedidaDAL();
        unidadMedidaTo umTo = new unidadMedidaTo();

        public DataTable obtenerUnidadMedidaBLL()
        {
            return umDAL.obtenerUnidadMedidaDAL();
        }
        public bool insertaUnidadMedidaBLL(unidadMedidaTo umTo, ref string errMensaje)
        {
            bool result = true;
            if (!umDAL.insertaUnidadMedidaDAL(umTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaUnidadMedidaBLL(unidadMedidaTo umTo, ref string errMensaje)
        {
            bool result = true;
            if (!umDAL.modificaUnidadMedidaDAL(umTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaUnidadMedidaBLL(unidadMedidaTo umTo, ref string errMensaje)
        {
            bool result = true;
            if (!umDAL.eliminaUnidadMedidaDAL(umTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int CONTAR_REGBLL(string CODIGO)
        {
            return umDAL.CONTAR_REGDAL(CODIGO);
        }
        public int ValidarUnidadMedidaBLL(unidadMedidaTo umTo)
        {
            return umDAL.ValidarUnidadMedidaDAL(umTo);
        }
    }
}
