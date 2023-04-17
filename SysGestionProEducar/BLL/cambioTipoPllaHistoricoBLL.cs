using DAL;
using Entidades;
using System;
using System.Data;
using System.Threading;

namespace BLL
{
    public class cambioTipoPllaHistoricoBLL
    {
        cambioTipoPllaHistoricoDAL ctpDAL = new cambioTipoPllaHistoricoDAL();

        public DataTable obtenerCambioTipoPllaHistoricoBLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.obtenerCambioTipoPllaHistoricoDAL(ctpTo);
        }
        public string obtenerNroCambioTipoPllaHistoricoBLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.obtenerNroCambioTipoPllaHistoricoDAL(ctpTo);
        }
        public bool insertarCambioTipoPllaHistoricoBLL(cambioTipoPllaHistoricoTo ctpTo, ref string errMensaje)
        {
            bool result = true;
            if (!ctpDAL.insertarCambioTipoPllaHistoricoDAL(ctpTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable Institucion()
        {
            return ctpDAL.Institucion();
        }

        public DataTable Programas()
        {
            return ctpDAL.Programas();
        }

        public DataTable planillaCancel()
        {
            return ctpDAL.planillaCancel();
        }

        public DataTable obtenerCambioUbicacionparaNroCambiosBLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.obtenerCambioUbicacionparaNroCambiosDAL(ctpTo);
        }

        public DataTable ObtenerPersonaXInstitucion(string codInst)
        {
            return ctpDAL.ObtenerPersonaXInstitucion(codInst);
        }

        public decimal obtenerSaldoxCobrarBLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.obtenerSaldoxCobrarDAL(ctpTo);
        }
        public int obtenerNroCuotasPendientesBLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.obtenerNroCuotasPendientesDAL(ctpTo);
        }

        public DataTable ObtenerPersonasSinCodiga()
        {
            return ctpDAL.ObtenerPersonasSinCodiga();
        }

        public DataTable planillatipo(bool estado)
        {
            return ctpDAL.planillatipo(estado);
        }

        public DateTime? obtenerFechaUltCambioBLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.obtenerFechaUltCambioDAL(ctpTo);
        }
        public int obtenerNroCambiosBLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.obtenerNroCambiosDAL(ctpTo);
        }

        public DataTable ObtenerPlanilla(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            return ctpDAL.ObtenerPlanilla(PROGRAMAS, FECHA_INI, FECHA_FIN, TIPO_PLANILLA);
        }

        public DataTable ObtenerResumen(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            return ctpDAL.ObtenerResumen(PROGRAMAS, FECHA_INI, FECHA_FIN, TIPO_PLANILLA);
        }

        public DataTable ObtenerPlanillaResumenXtipo(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            return ctpDAL.ObtenerPlanillaResumenXtipo(PROGRAMAS, FECHA_INI, FECHA_FIN, TIPO_PLANILLA);
        }

        public DataTable ObtenerPlanilla_J(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            return ctpDAL.ObtenerPlanilla_J(PROGRAMAS, FECHA_INI, FECHA_FIN, TIPO_PLANILLA);
        }
        public DataTable MOSTRAR_REPORTE_PROYECCION_COBRANZA_BLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_DAL(ctpTo);
        }
        public DataTable MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_BLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_DAL(ctpTo);
        }
        public DataTable MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_PUNTO_CONBRANZA_BLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.MOSTRAR_REPORTE_PROYECCION_COBRANZA_RESUMEN_PUNTO_COBRANZA_DAL(ctpTo);
        }
        public DataTable CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_BLL(cambioTipoPllaHistoricoTo ctpTo)
        {
            return ctpDAL.CARTERA_TOTAL_PROYECTADA_X_PUNTO_COBRANZA_DAL(ctpTo);
        }
        public DataTable ObtenerGreedXtipo(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            return ctpDAL.ObtenerGreedXtipo(PROGRAMAS, FECHA_INI, FECHA_FIN, TIPO_PLANILLA);
        }

        public DataTable ObtenerResumenXtipo(string PROGRAMAS, DateTime FECHA_INI, DateTime FECHA_FIN, string TIPO_PLANILLA)
        {
            return ctpDAL.ObtenerResumenXtipo(PROGRAMAS, FECHA_INI, FECHA_FIN, TIPO_PLANILLA);
        }

        public DataTable ObtenerReportesContratosTodos(string NRO_PLANILLA, string TIPO_PLANILLA, string PROGRAMAS)
        {
            return ctpDAL.ObtenerReportesContratosTodos(NRO_PLANILLA, TIPO_PLANILLA, PROGRAMAS);
        }

        public DataTable ObtenerReportesContratos(string NRO_PLANILLA, string TIPO_PLANILLA, string PROGRAMAS)
        {
            return ctpDAL.ObtenerReportesContratos(NRO_PLANILLA, TIPO_PLANILLA, PROGRAMAS);
        }

        public DataTable RptMovimientoXUbicacionDirecta(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
                string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            return ctpDAL.RptMovimientoXUbicacionDirecta(fechaAprobIni, fechaAproFin, fechaCobraIni, fechaCobraFin, codPrograma, tipoUbicacion, codGrupoUbicacion, codSubUbicacion);
        }

        public DataTable RptMovimientosXUbicacion(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
                string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            return ctpDAL.RptMovimientosXUbicacion(fechaAprobIni, fechaAproFin, fechaCobraIni, fechaCobraFin, codPrograma, tipoUbicacion, codGrupoUbicacion, codSubUbicacion);
        }

        public DataTable RptMovimientoXUbicacionDirecta2(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
        string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            return ctpDAL.RptMovimientoXUbicacionDirecta2(fechaAprobIni, fechaAproFin, fechaCobraIni, fechaCobraFin, codPrograma, tipoUbicacion, codGrupoUbicacion, codSubUbicacion);
        }

        public DataTable RptMovimientosXUbicacion2(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
        string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            return ctpDAL.RptMovimientosXUbicacion2(fechaAprobIni, fechaAproFin, fechaCobraIni, fechaCobraFin, codPrograma, tipoUbicacion, codGrupoUbicacion, codSubUbicacion);
        }

        public DataTable RptMovimientoCarteraComparativoMes(DateTime fechaAprobIni, DateTime fechaAproFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
        string codPrograma, string tipoUbicacion, string codGrupoUbicacion, string codSubUbicacion)
        {
            return ctpDAL.RptMovimientoCarteraComparativoMes(fechaAprobIni, fechaAproFin, fechaCobraIni, fechaCobraFin, codPrograma, tipoUbicacion, codGrupoUbicacion, codSubUbicacion);
        }

        public DataTable RptCobrazaUbicacionDetalle(CancellationToken cancelToken, DateTime fechaAproIni, DateTime fechaAproFin, DateTime fechaCobraIni,
                DateTime fechaCobraFin, string codUbicacion, string codPrograma, string codGrupoUbicacion, string codSubUbicacion)
        {
            return ctpDAL.RptCobrazaUbicacionDetalle(cancelToken, fechaAproIni, fechaAproFin, fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion);
        }

        public DataTable RptCobrazaUbicacionDetalleDir(CancellationToken cancelToken, DateTime fechaAproIni, DateTime fechaAproFin, DateTime fechaCobraIni,
        DateTime fechaCobraFin, string codUbicacion, string codPrograma, string codGrupoUbicacion, string codSubUbicacion)
        {
            return ctpDAL.RptCobrazaUbicacionDetalleDir(cancelToken, fechaAproIni, fechaAproFin, fechaCobraIni, fechaCobraFin, codUbicacion, codPrograma, codGrupoUbicacion, codSubUbicacion);
        }

        public DataTable RptDetalladoXContratoFecIdenPago(string codPrograma, string codAreaTrabajo, string codGestor, DateTime fechaIdenIni, DateTime fechaIdenFin, bool incluyeSinFecha)
        {
            return ctpDAL.RptDetalladoXContratoFecIdenPago(codPrograma, codAreaTrabajo, codGestor, fechaIdenIni, fechaIdenFin, incluyeSinFecha);
        }
    }
}
