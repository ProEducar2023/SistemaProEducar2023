using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class tipoDocInvBLL
    {
        tipoDocInvDAL tdiDAL = new tipoDocInvDAL();
        tipoDocInvTo tdiTo = new tipoDocInvTo();

        public DataTable obtenerTipoDocInvBLL()
        {
            return tdiDAL.obtenerTipoDocInvDAL();
        }
        public bool insertarTipoDocInvBLL(tipoDocInvTo tdiTo, ref string errMensaje)
        {
            bool result = true;
            if (!tdiDAL.insertarTipoDocInvDAL(tdiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTipoDocInvBLL(tipoDocInvTo tdiTo, ref string errMensaje)
        {
            bool result = true;
            if (!tdiDAL.modificarTipoDocInvDAL(tdiTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTipoDocInvBLL(string COD_DOC_INV, ref string errMensaje)
        {
            bool result = true;
            if (!tdiDAL.eliminarTipoDocInvDAL(COD_DOC_INV, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerTipoDocGestionBLL()
        {
            return tdiDAL.obtenerTipoDocGestionDAL();
        }
        public int ValidarTipoDocumentoInventarioBLL(tipoDocInvTo tdiTo)
        {
            return tdiDAL.ValidarTipoDocumentoInventarioDAL(tdiTo);
        }
        public string obtieneCodDocInvxTipoDocBLL(tipoDocInvTo tdiTo)
        {
            return tdiDAL.obtieneCodDocInvxTipoDocDAL(tdiTo);
        }
    }
}
