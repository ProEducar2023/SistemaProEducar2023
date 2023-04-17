using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class cargosVentaBLL
    {
        cargosVentaDAL cavDAL = new cargosVentaDAL();
        cargosVentaTo cavTo = new cargosVentaTo();

        public DataTable obtenerCargosVentaBLL()
        {
            return cavDAL.obtenerCargosVentaDAL();
        }
        public bool insertaCargosVentaBLL(string COD_CARGO, string DESC_CARGO, ref string errMensaje)
        {
            bool result = true;
            cavTo.COD_CARGO = COD_CARGO;
            cavTo.DESC_CARGO = DESC_CARGO;
            if (!cavDAL.insertaCargosVentaDAL(cavTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaCargosVentaBLL(string COD_CARGO, string DESC_CARGO, ref string errMensaje)
        {
            bool result = true;
            cavTo.COD_CARGO = COD_CARGO;
            cavTo.DESC_CARGO = DESC_CARGO;
            if (!cavDAL.modificaCargosVentaDAL(cavTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaCargosVentaBLL(string COD_CARGO, ref string errMensaje)
        {
            bool result = true;
            cavTo.COD_CARGO = COD_CARGO;
            if (!cavDAL.eliminaCargosVentaDAL(cavTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
