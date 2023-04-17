using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class personaFonoBLL
    {
        personaFonoDAL pefDAL = new personaFonoDAL();

        public DataTable obtenerPersonaFonoBLL(personaFonoTo pefTo)
        {
            return pefDAL.obtenerPersonaFonoDAL(pefTo);
        }
        public bool insertarPersonaFonoBLL(personaFonoTo pefTo, ref string errMensaje)
        {
            bool result = true;
            if (!pefDAL.insertarPersonaFonoDAL(pefTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPersonaFonoBLL(personaFonoTo pefTo, ref string errMensaje)
        {
            bool result = true;
            if (!pefDAL.eliminarPersonaFonoDAL(pefTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable ObtenerTelefonoPuntoCobranzaFono(string codPtoCob)
        {
            return pefDAL.ObtenerTelefonoPuntoCobranzaFono(codPtoCob);
        }
    }
}
