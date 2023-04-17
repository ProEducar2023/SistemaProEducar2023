using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class vendedorBLL
    {
        vendedorDAL venDAL = new vendedorDAL();
        vendedorTo venTo = new vendedorTo();

        public DataTable obtenerVendedorBLL()
        {
            return venDAL.obtenerVendedorDAL();
        }
        public bool insertarVendedorBLL(vendedorTo venTo, ref string errMensaje)
        {
            bool result = true;
            if (!venDAL.insertarVendedorDAL(venTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarVendedorBLL(vendedorTo venTo, ref string errMensaje)
        {
            bool result = true;
            if (!venDAL.modificarVendedorDAL(venTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarVendedorBLL(vendedorTo venTo, ref string errMensaje)
        {
            bool result = true;
            if (!venDAL.eliminarVendedorDAL(venTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
