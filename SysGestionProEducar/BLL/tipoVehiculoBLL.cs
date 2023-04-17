using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class tipoVehiculoBLL
    {
        tipoVehiculoDAL tpvDAL = new tipoVehiculoDAL();
        public DataTable obtenerTipoVehiculoBLL()
        {
            return tpvDAL.obtenerTipoVehiculoDAL();//OBTIENE
        }
        public bool insertarTipoVehiculoBLL(tipoVehiculoTo tpvTo, ref string errMensaje)
        {
            bool result = true;
            if (!tpvDAL.insertarTipoVehiculoDAL(tpvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTipoVehiculoBLL(tipoVehiculoTo tpvTo, ref string errMensaje)
        {
            bool result = true;
            if (!tpvDAL.modificarTipoVehiculoDAL(tpvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarTipoVehiculoBLL(tipoVehiculoTo tpvTo, ref string errMensaje)
        {
            bool result = true;
            if (!tpvDAL.eliminarTipoVehiculoDAL(tpvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificaTipoVehiculoBLL(tipoVehiculoTo tpvTo)
        {
            return tpvDAL.verificaTipoVehiculoDAL(tpvTo);
        }
    }
}
