using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class progNivelBLL
    {
        progNivelDAL prniDAL = new progNivelDAL();
        //progNivelTo prniTo = new progNivelTo();

        public DataTable obtenerProgramaNivelBLL()
        {
            return prniDAL.obtenerProgramaNivelDAL();
        }
        public DataTable obtenerProgramaNivelporCodigoBLL(progNivelTo prniTo)
        {
            return prniDAL.obtenerProgramaNivelporCodigoDAL(prniTo);
        }
        public bool insertarProgramaNivelBLL(progNivelTo prniTo, ref string errMensaje)
        {
            bool result = true;
            if (!prniDAL.insertarProgramaNivelDAL(prniTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarProgramaNivelBLL(progNivelTo prniTo, ref string errMensaje)
        {
            bool result = true;
            if (!prniDAL.modificarProgramaNivelDAL(prniTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarProgramaNivelBLL(progNivelTo prniTo, ref string errMensaje)
        {
            bool result = true;
            if (!prniDAL.eliminarProgramaNivelDAL(prniTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarProgramaNivelporCodPerBLL(progNivelTo prniTo, ref string errMensaje)
        {
            bool result = true;
            if (!prniDAL.eliminarProgramaNivelporCodPerDAL(prniTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPersonalparaCrearEqVentaBLL()
        {
            return prniDAL.obtenerPersonalparaCrearEqVentaDAL();
        }
        public DataTable obtenerVendedoresparaCrearEqVentasBLL()
        {
            return prniDAL.obtenerVendedoresparaCrearEqVentasDAL();
        }
        public DataTable obtenerDirectoresparaCrearEqVentasBLL()
        {
            return prniDAL.obtenerDirectoresparaCrearEqVentasDAL();
        }
        public DataTable obtenerPersonasParaConsultaMetasBLL(progNivelTo prniTo)
        {
            return prniDAL.obtenerPersonasParaConsultaMetasDAL(prniTo);
        }
        public DataTable obtenerPersonalparaRelacionarBLL(string codpro)
        {
            return prniDAL.obtenerPersonalparaRelacionarDAL(codpro);
        }
        public DataTable obtenerPersonalparaCrearEqCobranzaBLL()
        {
            return prniDAL.obtenerPersonalparaCrearEqCobranzaDAL();
        }
        //public bool insertarProgramaNivelDAL(progNivelTo prniTo, ref string errMensaje)
        //{
        //    bool result = true;
        //    if (!prniDAL.insertarProgramaNivelDAL(prniTo, ref errMensaje))
        //        return result = false;
        //    return result;
        //}
        public bool insertarProgramaNivelCobranzaBLL(progNivelTo prniTo, ref string errMensaje)
        {
            bool result = true;
            if (!prniDAL.insertarProgramaNivelCobranzaDAL(prniTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarProgramaNivelporCodPerCobranzaBLL(progNivelTo prniTo, ref string errMensaje)
        {
            bool result = true;
            if (!prniDAL.eliminarProgramaNivelporCodPerCobranzaDAL(prniTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerProgramaNivelporCodigoCobranzaBLL(progNivelTo prniTo)
        {
            return prniDAL.obtenerProgramaNivelporCodigoCobranzaDAL(prniTo);
        }
        public DataTable obtenerSectoristasparaCrearEqCobradoresBLL(string codni)
        {
            return prniDAL.obtenerSectoristasparaCrearEqCobradoresDAL(codni);
        }
        public DataTable obtenerPersonalparaRelacionarCobradoresBLL(string codn)
        {
            return prniDAL.obtenerPersonalparaRelacionarCobradoresDAL(codn);
        }
        public DataTable obtenerCobradoresxSectoristaBLL(progNivelTo prniTo)
        {
            return prniDAL.obtenerCobradoresxSectoristaDAL(prniTo);
        }
    }
}
