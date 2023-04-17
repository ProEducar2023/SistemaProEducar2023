using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class temporal_Nro_ReporteBLL
    {
        temporal_Nro_ReporteDAL tnrDAL = new temporal_Nro_ReporteDAL();
        temporal_Nro_ReporteTo tnrTo = new temporal_Nro_ReporteTo();

        public DataTable obtener_Temporal_Nro_ReporteBLL(temporal_Nro_ReporteTo tnrTo)
        {
            return tnrDAL.obtener_Temporal_Nro_ReporteDAL(tnrTo);
        }
        public DataTable obtener_Temporal_Nro_Reporte_x_DigitadorBLL(temporal_Nro_ReporteTo tnrTo)
        {
            return tnrDAL.obtener_Temporal_Nro_Reporte_x_DigitadorDAL(tnrTo);
        }
        public bool insertar_Temporal_Nro_ReporteBLL(temporal_Nro_ReporteTo tnrTo, ref string errMensaje)
        {
            bool result = true;
            if (!tnrDAL.insertar_Temporal_Nro_ReporteDAL(tnrTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminar_Temporal_Nro_ReporteBLL(temporal_Nro_ReporteTo tnrTo, ref string errMensaje)
        {
            bool result = true;
            if (!tnrDAL.eliminar_Temporal_Nro_ReporteDAL(tnrTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool verifica_existencia_contratos_sin_nro_reporte_x_cod_digitadorBLL(temporal_Nro_ReporteTo tnrTo, ref string errMensaje)
        {
            bool result = true;
            if (!tnrDAL.verifica_existencia_contratos_sin_nro_reporte_x_cod_digitadorDAL(tnrTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
