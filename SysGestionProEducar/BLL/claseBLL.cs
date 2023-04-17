using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class claseBLL
    {
        claseDAL claDAL = new claseDAL();
        claseTo claTo = new claseTo();

        public DataTable obtenerClaseArticuloBLL()
        {
            return claDAL.obtenerClaseArticuloDAL();
        }
        public bool insertaClaseArticuloBLL(string COD_CLASE, string DESC_CLASE, string DESC_CORTA, string COD_TIPO, string COD_D_H, string COD_TIPO_COMPRAS, ref string errMensaje)
        {
            bool result = true;
            claTo.COD_CLASE = COD_CLASE;
            claTo.DESC_CLASE = DESC_CLASE;
            claTo.DESC_CORTA = DESC_CORTA;
            claTo.COD_TIPO = COD_TIPO;
            claTo.COD_D_H = COD_D_H;
            claTo.COD_TIPO_COMPRAS = COD_TIPO_COMPRAS;
            if (!claDAL.insertaClaseArticuloDAL(claTo, ref errMensaje))
                return result = false;
            return result;

        }
        public bool modificaClaseArticuloBLL(claseTo claTo, ref string errMensaje)
        {
            bool result = true;
            if (!claDAL.modificaClaseArticuloDAL(claTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaClaseArticuloBLL(claseTo claTo, ref string errMensaje)
        {
            bool result = true;
            if (!claDAL.eliminaClaseArticuloDAL(claTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerClaseArticuloparaGrupoBLL()
        {
            return claDAL.obtenerClaseArticuloparaGrupoDAL();
        }
        public string HALLAR_CLASE_COD_BLL(string cod_clase)
        {
            return claDAL.HALLAR_CLASE_COD_DAL(cod_clase);
        }
        public int ValidaClaseBLL(claseTo claTo)
        {
            return claDAL.ValidaClaseDAL(claTo);
        }
    }
}
