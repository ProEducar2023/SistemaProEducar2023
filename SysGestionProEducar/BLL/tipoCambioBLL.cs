using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class tipoCambioBLL
    {
        tipoCambioDAL tpcDAL = new tipoCambioDAL();
        public DataTable obtenerMonedasBLL()
        {
            return tpcDAL.obtenerMonedasDAL();
        }
        public DataTable obtenerAnnioBLL()
        {
            return tpcDAL.obtenerAnnioDAL();
        }
        public DataTable mostrarTipoCambioBLL(tipoCambioTo tpcTo)
        {
            return tpcDAL.mostrarTipoCambioDAL(tpcTo);
        }
        public bool insertarTipoCambioBLL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!tpcDAL.insertarTipoCambioDAL(tpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VerificarTipoCambioBLL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool result = true;
            if (tpcDAL.VerificarTipoCambioDAL(tpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarTipoCambioBLL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!tpcDAL.modificarTipoCambioDAL(tpcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public string SACAR_CAMBIO(tipoCambioTo tpcTo)
        {
            return tpcDAL.SACAR_CAMBIO(tpcTo);
        }
        public bool eliminaTipodeCambioBLL(tipoCambioTo tpcTo, ref string errMensaje)
        {
            bool result = true;
            if (!tpcDAL.eliminaTipodeCambioDAL(tpcTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
