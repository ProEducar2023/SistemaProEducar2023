using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class multiUsoBLL
    {
        multiUsoDAL mulDAL = new multiUsoDAL();

        public DataTable obtenerTablaPorGrupoBLL(multiUsoTo mulTo)
        {
            return mulDAL.obtenerTablaPorGrupoDAL(mulTo);
        }
        public bool insertaTablaPorGrupoBLL(multiUsoTo mulTo, ref string errMensaje)
        {
            bool result = true;
            if (!mulDAL.insertarTablaPorGrupoDAL(mulTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTablaPorGrupoBLL(multiUsoTo mulTo, ref string errMensaje)
        {
            bool result = true;
            if (!mulDAL.modificarTablaPorGrupoDAL(mulTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTablaPorGrupoBLL(multiUsoTo mulTo, ref string errMensaje)
        {
            bool result = true;
            if (!mulDAL.eliminarTablaPorGrupoDAL(mulTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
