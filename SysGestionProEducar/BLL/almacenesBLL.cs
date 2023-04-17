using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class almacenesBLL
    {
        almacenDAL almDAL = new almacenDAL();
        almacenTo almTo = new almacenTo();
        //PARA TIPO ALMACEN
        public DataTable obtenerTipoAlmacenesBLL()
        {
            return almDAL.obtenerTipoAlmacenesDAL();
        }
        public bool insertaTipoAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            bool result = true;
            if (!almDAL.insertaTipoAlmacenDAL(almTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaTipoAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            bool result = true;
            if (!almDAL.modificaTipoAlmacenDAL(almTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaTipoAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            bool result = true;
            if (!almDAL.eliminaTipoAlmacenDAL(almTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificaTipoAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            int cant = almDAL.verificaTipoAlmacenDAL(almTo, ref errMensaje);
            if (cant < 0)
                return cant = -1;
            else if (cant > 0)
                errMensaje = "EL CODIGO DE TIPO DE ALMACEN YA EXISTE !!!";
            return cant;
        }
        //PARA ALMACEN
        public DataTable obtenerAlmacenesBLL()
        {
            return almDAL.obtenerAlmacenesDAL();
        }
        public bool insertaAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            bool result = true;
            if (!almDAL.insertaAlmacenDAL(almTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            bool result = true;
            if (!almDAL.modificaAlmacenDAL(almTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            bool result = true;
            if (!almDAL.eliminaAlmacenDAL(almTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificaAlmacenBLL(almacenTo almTo, ref string errMensaje)
        {
            int cant = almDAL.verificaAlmacenDAL(almTo, ref errMensaje);
            if (cant < 0)
                return cant = -1;
            else if (cant > 0)
                errMensaje = "EL CODIGO DE ALMACEN YA EXISTE !!!";
            return cant;
        }
        public DataTable obtenerAlmacenesparaArticuloBLL()
        {
            return almDAL.obtenerAlmacenesparaArticuloDAL();
        }
        public DataTable obtenerAlmacenesparaInventarioBLL(almacenTo almTo)
        {
            return almDAL.obtenerAlmacenesparaInventarioDAL(almTo);
        }
        public DataTable obtenerUbicacionArticuloBLL(almacenTo almTo)
        {
            return almDAL.obtenerUbicacionArticuloDAL(almTo);
        }
    }

}
