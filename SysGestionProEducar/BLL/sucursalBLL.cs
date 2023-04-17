using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class sucursalBLL
    {
        sucursalDAL sucDAL = new sucursalDAL();
        sucursalTo sucTo = new sucursalTo();

        public DataTable obtenerSucursalBLL()
        {
            return sucDAL.obtenerSucursalDAL();
        }
        public bool insertaSucursalBLL(sucursalTo sucTo, ref string errMensaje)
        {
            bool result = true;
            if (!sucDAL.insertaSucursalDAL(sucTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaSucursalBLL(sucursalTo sucTo, ref string errMensaje)
        {
            bool result = true;
            if (!sucDAL.modificaSucursalDAL(sucTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaSucursalBLL(sucursalTo sucTo, ref string errMensaje)
        {
            bool result = true;
            if (!sucDAL.eliminaSucursalDAL(sucTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificaSucursalBLL(sucursalTo sucTo, ref string errMensaje)
        {
            int cant = sucDAL.verificaSucursalDAL(sucTo, ref errMensaje);
            if (cant < 0)
                return cant = -1;
            else if (cant > 0)
                errMensaje = "EL CODIGO DE SUCURSAL YA EXISTE !!!";
            return cant;
        }
    }
}
