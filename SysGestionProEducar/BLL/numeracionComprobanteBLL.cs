using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class numeracionComprobanteBLL
    {
        numeracionComprobanteDAL ncDAL = new numeracionComprobanteDAL();
        public DataTable obtenerNumeracionComprobanteBLL(numeracionComprobanteTo ncTo)
        {
            return ncDAL.obtenerNumeracionComprobanteDAL(ncTo);
        }

        public bool insertarNumeracionComprobanteBLL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool result = true;
            if (!ncDAL.insertarNumeracionComprobanteDAL(ncTo, ref errMensaje))
                return result = false;

            return result;
        }
        public bool modificarNumeracionComprobanteBLL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool result = true;
            if (!ncDAL.modificarNumeracionComprobanteDAL(ncTo, ref errMensaje))
                return result = false;

            return result;
        }
        public bool eliminarNumeracionComprobanteBLL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool result = true;
            if (!ncDAL.eliminarNumeracionComprobanteDAL(ncTo, ref errMensaje))
                return result = false;

            return result;
        }
        public DataTable obtenerNumeracionporVendedorBLL(numeracionComprobanteTo ncTo)
        {
            return ncDAL.obtenerNumeracionporVendedorDAL(ncTo);
        }
        public DataTable obtenerTodasNumeracionesBLL()
        {
            return ncDAL.obtenerTodasNumeracionesDAL();
        }
        public DataTable obtenerNumeracionporVendedorconNumeracionVendedorBLL(numeracionComprobanteTo ncTo)
        {
            return ncDAL.obtenerNumeracionporVendedorconNumeracionVendedorDAL(ncTo);
        }
        public DataTable obtenerNumeracionporDirectorBLL(numeracionComprobanteTo ncTo)
        {
            return ncDAL.obtenerNumeracionporDirectorDAL(ncTo);
        }
        public int verificaNumeracionComprobanteBLL(numeracionComprobanteTo ncTo)
        {
            return ncDAL.verificaNumeracionComprobanteDAL(ncTo);
        }
        public bool desSustituirNumeracionComprobanteBLL(numeracionComprobanteTo ncTo, ref string errMensaje)
        {
            bool result = true;
            if (!ncDAL.desSustituirNumeracionComprobanteDAL(ncTo, ref errMensaje))
                return result = false;

            return result;
        }
    }
}
