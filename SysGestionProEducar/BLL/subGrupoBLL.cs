using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class subGrupoBLL
    {
        subGrupoDAL sgruDAL = new subGrupoDAL();
        subGrupoTo sgruTo = new subGrupoTo();

        public DataTable obtenerSubGrupoBLL()
        {
            return sgruDAL.obtenerSubGrupoDAL();
        }
        public bool insertaSubGrupoBLL(subGrupoTo sgruTo, ref string errMensaje)
        {
            bool result = true;
            if (!sgruDAL.insertaSubGrupoDAL(sgruTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaSubGrupoBLL(subGrupoTo sgruTo, ref string errMensaje)
        {
            bool result = true;
            if (!sgruDAL.modificaSubGrupoDAL(sgruTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaSubGrupoBLL(subGrupoTo sgruTo, ref string errMensaje)
        {
            bool result = true;
            if (!sgruDAL.eliminaSubGrupoDAL(sgruTo, ref errMensaje))
                return result = false;
            return result;
        }
        public string obtenerCodSubGrupoBLL(string codcla, string codgru)
        {
            return sgruDAL.obtenerCodSubGrupoDAL(codcla, codgru);
        }
        public DataTable obtenerSubGrupoClaseGrupoDAL(subGrupoTo sgruTo)
        {
            return sgruDAL.obtenerSubGrupoClaseGrupoDAL(sgruTo);
        }
        public int ValidarSubGrupoBLL(subGrupoTo sgruTo)
        {
            return sgruDAL.ValidarSubGrupoDAL(sgruTo);
        }
    }
}
