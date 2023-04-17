using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class lugarVentaBLL
    {
        lugarVentaDAL lgvDAL = new lugarVentaDAL();

        public DataTable obtenerLugarVentaBLL()
        {
            return lgvDAL.obtenerLugarVentaDAL();
        }
        public bool insertarLugarVentaBLL(lugarVentaTo lgvTo, ref string errMensaje)
        {
            bool result = true;
            if (!lgvDAL.insertarLugarVentaDAL(lgvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarLugarVentaBLL(lugarVentaTo lgvTo, ref string errMensaje)
        {
            bool result = true;
            if (!lgvDAL.modificarLugarVentaDAL(lgvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public string obtenerCodLugVenBLL(lugarVentaTo lgvTo)
        {
            return lgvDAL.obtenerCodLugVenBLL(lgvTo);
        }
        public bool eliminarLugarVentaBLL(lugarVentaTo lgvTo, ref string errMensaje)
        {
            bool result = true;
            if (lgvDAL.eliminarLugarVentaDAL(lgvTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerLugarVentaCodInsCodPtoVtaBLL(lugarVentaTo lgvTo)
        {
            return lgvDAL.obtenerLugarVentaCodInsCodPtoVtaDAL(lgvTo);
        }
        public DataTable obtenerLugVentaPtoVentaBLL()
        {
            return lgvDAL.obtenerLugVentaPtoVentaDAL();
        }
    }
}
