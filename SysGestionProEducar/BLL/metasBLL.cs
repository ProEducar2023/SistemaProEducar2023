using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class metasBLL
    {
        metasDAL mtDAL = new metasDAL();

        public DataTable obtenerPreventasMetasMensualBLL(metasTo mtTo)
        {
            return mtDAL.obtenerPreventasMetasMensualDAL(mtTo);
        }
        public bool insertarMetasBLL(metasTo mtTo, ref string errMensaje)
        {
            bool result = true;
            if (!mtDAL.insertarMetasDAL(mtTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarMetasBLL(metasTo mtTo, ref string errMensaje)
        {
            bool result = true;
            if (!mtDAL.modificarMetasDAL(mtTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarMetasBLL(metasTo mtTo, ref string errMensaje)
        {
            bool result = true;
            if (!mtDAL.eliminarMetasDAL(mtTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPreventaMetasparaConsultaBLL(metasTo mtTo)
        {
            return mtDAL.obtenerPreventaMetasparaConsultaDAL(mtTo);
        }
        public DataTable obtenerPreventaMetasparaConsultaVendedorBLL(metasTo mtTo)
        {
            return mtDAL.obtenerPreventaMetasparaConsultaVendedorDAL(mtTo);
        }
    }
}
