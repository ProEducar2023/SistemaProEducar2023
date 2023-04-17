using DAL;
using Entidades;

namespace BLL
{
    public class mArticuloBLL
    {
        mArticuloDAL marDAL = new mArticuloDAL();
        mArticuloTo marTo = new mArticuloTo();

        public bool insertarArticuloaAlmacenBLL(mArticuloTo marTo, ref string errMensaje)
        {
            bool result = true;
            if (!marDAL.insertarArticuloaAlmacenDAL(marTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool verificarStockAlmacenesBLL(mArticuloTo marTo, ref string errMensaje)
        {
            bool result = true;
            if (!marDAL.verificarStockAlmacenesDAL(marTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionarSaldoxCambioAlmacenesBLL(mArticuloTo marTo, ref string errMensaje)
        {
            bool result = true;
            if (!marDAL.adicionarSaldoxCambioAlmacenesDAL(marTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool restarSaldoxCambioAlmacenesBLL(mArticuloTo marTo, ref string errMensaje)
        {
            bool result = true;
            if (!marDAL.restarSaldoxCambioAlmacenesDAL(marTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
