using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class movimientoSerieBLL
    {
        movimientoSerieDAL mosDAL = new movimientoSerieDAL();

        public DataTable obtenerMovimientoSerieBLL(string COD_MOV)
        {
            return mosDAL.obtenerMovimientoSerieDAL(COD_MOV);
        }
        public bool insertarMovimientoSerieBLL(movimientoSerieTo mosTo, ref string errMensaje)
        {
            bool result = true;
            if (!mosDAL.insertarMovimientoSerieDAL(mosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarMovimientoSerieBLL(movimientoSerieTo mosTo, ref string errMensaje)
        {
            bool result = true;
            if (!mosDAL.eliminarMovimientoSerieDAL(mosTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerMovimientoSerieparaInventarioBLL(movimientoSerieTo mosTo)
        {
            return mosDAL.obtenerMovimientoSerieparaInventarioDAL(mosTo);
        }
        public DataTable CBO_NRO_MOVIMIENTO_SERIE_BLL(movimientoSerieTo mosTo)
        {
            return mosDAL.CBO_NRO_MOVIMIENTO_SERIE_DAL(mosTo);
        }
    }
}
