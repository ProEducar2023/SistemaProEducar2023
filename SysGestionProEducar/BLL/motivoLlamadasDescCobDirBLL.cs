using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class motivoLlamadasDescCobDirBLL
    {
        motivoLlamadasDescCobDirDAL mlDAL = new motivoLlamadasDescCobDirDAL();

        public DataTable obtenerMotivoLlamadasDescCobDirBLL(motivoLlamadasDescCobDirTo mlTo)
        {
            return mlDAL.obtenerMotivoLlamadasDescCobDirDAL(mlTo);
        }
        public bool insertarMotivoLlamadaDescCobDirBLL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            bool result = true;
            if (!mlDAL.insertarMotivoLlamadaDescCobDirDAL(mlTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarMotivoLlamadaDescCobDirBLL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            bool result = true;
            if (!mlDAL.modificarMotivoLlamadaDescCobDirDAL(mlTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarMotivoLlamadaDescCobDirBLL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            bool result = true;
            if (!mlDAL.eliminarMotivoLlamadaDescCobDirDAL(mlTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int verificaMotivoLlamadaDescCobDirBLL(motivoLlamadasDescCobDirTo mlTo, ref string errMensaje)
        {
            int cant = mlDAL.verificaMotivoLlamadaDescCobDirDAL(mlTo, ref errMensaje);
            if (cant < 0)
                return cant = -1;
            else if (cant > 0)
                errMensaje = "El codigo del Motivo ya existe !!!";
            return cant;
        }
    }
}
