using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class cuentaBancariaBLL
    {
        cuentaBancariaDAL ctcDAL = new cuentaBancariaDAL();

        public DataTable obtenerCuentasBancariasBLL()
        {
            return ctcDAL.obtenerCuentasBancariasDAL();
        }
        public bool insertarCuentasBancariasDAL(cuentaBancariaTo ctcTo, ref string errMensaje)
        {
            bool result = true;
            if (!ctcDAL.insertarCuentasBancariasDAL(ctcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarCuentasBancariasDAL(cuentaBancariaTo ctcTo, ref string errMensaje)
        {
            bool result = true;
            if (!ctcDAL.modificarCuentasBancariasDAL(ctcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarCuentasBancariasDAL(cuentaBancariaTo ctcTo, ref string errMensaje)
        {
            bool result = true;
            if (!ctcDAL.eliminarCuentasBancariasDAL(ctcTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
