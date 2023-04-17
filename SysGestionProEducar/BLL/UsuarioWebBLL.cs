using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class UsuarioWebBLL
    {
        UsuarioWebDAL uswDAL = new UsuarioWebDAL();
        usuarioWebTo uswTo = new usuarioWebTo();

        public DataTable obtenerUsuarioWebBLL(usuarioWebTo uswTo)
        {
            return uswDAL.obtenerUsuarioWebDAL(uswTo);
        }
        public bool insertarUsuarioWebBLL(usuarioWebTo uswTo, ref string errMensaje)
        {
            bool result = true;
            if (!uswDAL.insertarUsuarioWebDAL(uswTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarUsuarioWebBLL(usuarioWebTo uswTo, ref string errMensaje)
        {
            bool result = true;
            if (!uswDAL.modificarUsuarioWebDAL(uswTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarUsuarioWebBLL(usuarioWebTo uswTo, ref string errMensaje)
        {
            bool result = true;
            if (!uswDAL.eliminarUsuarioWebDAL(uswTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
