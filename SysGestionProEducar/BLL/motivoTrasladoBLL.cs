using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class motivoTrasladoBLL
    {
        motivoTrasladoDAL mttDAL = new motivoTrasladoDAL();

        public DataTable obtenerMotivoTrasladoBLL()
        {
            return mttDAL.obtenerMotivoTrasladoDAL();
        }
        public bool insertarMotivoTrasladoBLL(motivoTrasladoTo mttTo, ref string errMensaje)
        {
            bool result = true;
            if (!mttDAL.insertarMotivoTrasladoDAL(mttTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarMotivoTrasladoBLL(motivoTrasladoTo mttTo, ref string errMensaje)
        {
            bool result = true;
            if (!mttDAL.modificarMotivoTrasladoDAL(mttTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarMotivoTrasladoBLL(motivoTrasladoTo mttTo, ref string errMensaje)
        {
            bool result = true;
            if (!mttDAL.eliminarMotivoTrasladoDAL(mttTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificaMotivoTrasladoBLL(motivoTrasladoTo mttTo)
        {
            return mttDAL.verificaMotivoTrasladoDAL(mttTo);
        }
    }
}
