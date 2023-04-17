using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class grupoBLL
    {
        grupoDAL gruDAL = new grupoDAL();
        grupoTo gruTo = new grupoTo();

        public DataTable obtenerGrupoBLL()
        {
            return gruDAL.obtenerGrupoDAL();
        }
        public bool insertarGrupoBLL(grupoTo gruTo, ref string errMensaje)
        {
            bool result = true;
            if (!gruDAL.insertarGrupoDAL(gruTo, ref errMensaje))
                return result = false;
            return result;

        }
        public bool modificaGrupoBLL(grupoTo gruTo, ref string errMensaje)
        {
            bool result = true;
            if (!gruDAL.modificaGrupoDAL(gruTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaGrupoBLL(grupoTo gruTo, ref string errMensaje)
        {
            bool result = true;
            if (!gruDAL.eliminaGrupoDAL(gruTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerGrupoClaseBLL(string codclase)
        {
            return gruDAL.obtenerGrupoClaseDAL(codclase);
        }
        public string obtieneCodGrupoBLL(string desgrupo, string codclase)
        {
            return gruDAL.obtieneCodGrupoDAL(desgrupo, codclase);
        }
        public int VerificarGrupoBLL(grupoTo gruTo)
        {
            return gruDAL.VerificarGrupoDAL(gruTo);
        }
    }
}
