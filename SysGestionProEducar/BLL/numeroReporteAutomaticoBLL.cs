using DAL;
using Entidades;

namespace BLL
{
    public class numeroReporteAutomaticoBLL
    {
        numeroReporteAutomaticoDAL nraDAL = new numeroReporteAutomaticoDAL();
        numeroReporteAutomaticoTo nraTo = new numeroReporteAutomaticoTo();

        public string obtener_Numero_Reporte_AutomaticoBLL()
        {
            return nraDAL.obtener_Numero_Reporte_AutomaticoDAL();
        }
        public bool actualizar_Numero_Reporte_AutomaticoBLL(numeroReporteAutomaticoTo nraTo, ref string errMensaje)
        {
            bool result = true;
            if (!nraDAL.actualizar_Numero_Reporte_AutomaticoDAL(nraTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
