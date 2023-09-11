using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class SeguimientoPlanillasBLL
    {
        private readonly SeguimientoPlanillasDAL DALSeguimiento = new SeguimientoPlanillasDAL();

        public DataTable ListarPlanillasPendientesEnviar(string codPtoCob, DateTime fechaInicio, DateTime fechaFin, int acces)
        {
            return DALSeguimiento.ListarPlanillasPendientesEnviar(codPtoCob, fechaInicio, fechaFin, acces);
        }

        public DataTable ListarEstadoSeguimientoPlanilla()
        {
            return DALSeguimiento.ListarEstadoSeguimientoPlanilla();
        }

        public DataTable ObtenerEstadoSeguimientoXId(int idEstado)
        {
            return DALSeguimiento.ObtenerEstadoSeguimientoXId(idEstado);
        }

        public bool GrabarSeguimientoPlanillaFase1(ref SeguimientoPlanillaTo se, CRUD crud)
        {
            return DALSeguimiento.GrabarSeguimientoPlanillaFase1(ref se, crud);
        }

        public DataTable ListarPlanillasXConfirmRecepcion(string codPtoCob, DateTime fechaInicio, DateTime fechaFin, int acces)
        {
            return DALSeguimiento.ListarPlanillasXConfirmRecepcion(codPtoCob, fechaInicio, fechaFin, acces);
        }

        public DataTable ListarEnvioSeguimientoPlanillaXTipoEnvio(int idSeguimiento, string tipoEnvio)
        {
            return DALSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(idSeguimiento, tipoEnvio);
        }

        public bool CerrarSeguimientoPlanilla(SeguimientoPlanillaTo se)
        {
            return DALSeguimiento.CerrarSeguimientoPlanilla(se);
        }

        public int TransferirPlanillas(string status, string año, string mes)
        {
            return DALSeguimiento.TransferirPlanillas(status, año, mes);
        }

        public DataTable ListarPlanillasXPtoCobranza(string año, string mes, string codPtoCob = "")
        {
            return DALSeguimiento.ListarPlanillasXPtoCobranza(codPtoCob, año, mes);
        }

        public bool ProgramarLlamada(LLamadas llamada1)
        {
            return DALSeguimiento.ProgramarLlamada(llamada1);
        }

        public bool ProgramarLlamada(LLamadas llamada1, bool esProcesada, bool chkNoSel)
        {
            return DALSeguimiento.ProgramarLlamada(llamada1, esProcesada, chkNoSel);
        }

        public bool ResultadoYProgramarLlamada(List<LLamadas> llamada)
        {
            return DALSeguimiento.ResultadoYProgramarLlamada(llamada);
        }

        public bool ProgramarLlamadaConfirmarDescuento(LLamadas llamada1, DateTime fechaTrans, bool showChecked, List<SeguimientoPlanillaTo> lstImporteListado)
        {
            return DALSeguimiento.ProgramarLlamadaConfirmarDescuento(llamada1, fechaTrans, showChecked, lstImporteListado);
        }

        public bool ModificarLlamada(LLamadas llamada)
        {
            return DALSeguimiento.ModificarLlamada(llamada);
        }

        public bool EliminarLlamada(LLamadas llamada)
        {
            return DALSeguimiento.EliminarLlamada(llamada);
        }

        public DataTable ObtenerHistorialSeguimiento(int idSeguimiento)
        {
            return DALSeguimiento.ObtenerHistorialSeguimiento(idSeguimiento);
        }

        public DataTable ListarRecepcionPlanillasXTipoRecepcion(int idSeguimiento, string tipoRecepcion)
        {
            return DALSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(idSeguimiento, tipoRecepcion);
        }

        public bool GrabarSeguimientoPlanillaFase2(ref SeguimientoPlanillaTo se, CRUD crud)
        {
            return DALSeguimiento.GrabarSeguimientoPlanillaFase2(ref se, crud);
        }

        public DataTable ListarLlamadasPendientes()
        {
            return DALSeguimiento.ListarLlamadasPendientes();
        }

        public bool RegresarEstadoAnterior(int idSeguimiento, int idEstado, int idEstadoAnterior)
        {
            return DALSeguimiento.RegresarEstadoAnterior(idSeguimiento, idEstado, idEstadoAnterior);
        }

        public bool RegresarEstadoAnteriorTransaction(int idSeguimiento, int idEstado, int idEstadoAnterior, string usuario)
        {
            return DALSeguimiento.RegresarEstadoAnteriorTransaction(idSeguimiento, idEstado, idEstadoAnterior, usuario);
        }
        public DataTable ObtenerLlamadasXId(int idLlamada)
        {
            return DALSeguimiento.ObtenerLlamadasXId(idLlamada);
        }

        public DataTable ObtenerLlamadaXIdLlamadaBase(int idLlamadaBase)
        {
            return DALSeguimiento.ObtenerLlamadaXIdLlamadaBase(idLlamadaBase);
        }

        public DataTable ListarLlamadasPendienetesXEtapa(int idEstado)
        {
            return DALSeguimiento.ListarLlamadasPendienetesXEtapa(idEstado);
        }

        public DataTable ListarPlanillasXConfirmarProcesamiento(string codPtoCob, DateTime dtFechaInicio, DateTime dtFechaFin, int acces)
        {
            return DALSeguimiento.ListarPlanillasXConfirmarProcesamiento(codPtoCob, dtFechaInicio, dtFechaFin, acces);
        }

        public DataTable ListarPlanillasXConfirmarDescuento(string codPtoCob, DateTime dtFechaInicio, DateTime dtFechaFin, int acces)
        {
            return DALSeguimiento.ListarPlanillasXConfirmarDescuento(codPtoCob, dtFechaInicio, dtFechaFin, acces);
        }

        public DataTable ListarLlamadasPendientesXIdSeguimiento(int idSeguimiento)
        {
            return DALSeguimiento.ListarLlamadasPendientesXIdSeguimiento(idSeguimiento);
        }

        public bool InsertarHistorialSeguimiento(SeguimientoPlanillaTo se)
        {
            return DALSeguimiento.InsertarHistorialSeguimiento(se);
        }

        public bool CerrarEtapaDecuento(SeguimientoPlanillaTo se)
        {
            return DALSeguimiento.CerrarEtapaDecuento(se);
        }

        public bool ResultadoLlamadaYDescuento(LLamadas llamada1)
        {
            return DALSeguimiento.ResultadoLlamadaYDescuento(llamada1);
        }

        public bool ModifiacaLlamadaYDescuento(LLamadas llamada, bool chkNo, bool chkNoSel)
        {
            return DALSeguimiento.ModifiacaLlamadaYDescuento(llamada, chkNo, chkNoSel);
        }

        public bool ModifiacaLlamadaEtapaLista(LLamadas llamada, bool chkSiNo, bool showChecked, DateTime fechaTrans, List<SeguimientoPlanillaTo> lstImportes)
        {
            return DALSeguimiento.ModifiacaLlamadaEtapaLista(llamada, chkSiNo, showChecked, fechaTrans, lstImportes);
        }

        public DataTable ListarPlanillasDescontadas(string codPtoCob, int acces)
        {
            return DALSeguimiento.ListarPlanillasDescontadas(codPtoCob, acces);
        }

        public DataTable ListarPlanillasNoDescontadas(string codPtoCob, int acces)
        {
            return DALSeguimiento.ListarPlanillasNoDescontadas(codPtoCob, acces);
        }

        public DataTable ListarPlanillasDescontadasConfirmadas(string codPtoCob, int acces)
        {
            return DALSeguimiento.ListarPlanillasDescontadasConfirmadas(codPtoCob, acces);
        }

        public DataTable ListarPlanillasEjecutadas(string codPtoCob, int acces)
        {
            return DALSeguimiento.ListarPlanillasEjecutado(codPtoCob, acces);
        }

        public DataTable ObtenerSeguimientoPlanillaXIdSeguimiento(int idSeguimiento)
        {
            return DALSeguimiento.ObtenerSeguimientoPlanillaXIdSeguimiento(idSeguimiento);
        }

        public bool RevertirTransferencia(List<planillaCabeceraTo> lstPlanillas)
        {
            return DALSeguimiento.RevertirTransferencia(lstPlanillas);
        }

        public int RevertirTransferencia(string año, string mes)
        {
            return DALSeguimiento.RevertirTransferencia(año, mes);
        }

        public DataTable ObtenerMesAñoTransferidos()
        {
            return DALSeguimiento.ObtenerMesAñoTransferidos();
        }

        public DataTable ObtenerOtrosDsctos(string codPtoCob)
        {
            return DALSeguimiento.ObtenerOtrosDsctos(codPtoCob);
        }

        public DataTable ListarPlanilasSiDescontadas()
        {
            return DALSeguimiento.ListarPlanilasSiDescontadas();
        }

        public int TransferirPlanillasSiDescontadas()
        {
            return DALSeguimiento.TransferirPlanillasSiDescontadas();
        }

        public DataTable ListarPlanillaControl(string feAño, string feMes, int acces)
        {
            return DALSeguimiento.ListarPlanillaControl(feAño, feMes, acces);
        }

        public DataTable ListarSeguimientoPlanillasControl(string feAño, string feMes)
        {
            return DALSeguimiento.ListarSeguimientoPlanillasControl(feAño, feMes);
        }

        public DataTable ListarPlanillasChequeDepositado(string codPtoCob)
        {
            return DALSeguimiento.ListarPlanillasChequeDepositado(codPtoCob);
        }

        public DataTable ListarPlanillasChequeConfirmado(string codPtoCob)
        {
            return DALSeguimiento.ListarPlanillasChequeConfirmado(codPtoCob);
        }

        public DataTable ListarPlanillasChequeRecepcionado(string codPtoCob)
        {
            return DALSeguimiento.ListarPlanillasChequeRecepcionado(codPtoCob);
        }

        public DataTable ListarPlanillasChequeEnviado(string codPtoCob)
        {
            return DALSeguimiento.ListarPlanillasChequeEnviado(codPtoCob);
        }

        public DataTable ObtenerDatosEjecutados(string nroPlanailla, string codPtoCob, string codInstitucion, string codCanalDscto, string tipoPlanilla, string feAño, string feMes)
        {
            return DALSeguimiento.ObtenerDatosEjecutados(nroPlanailla, codPtoCob, codInstitucion, codCanalDscto, tipoPlanilla, feAño, feMes);
        }

        public DataTable ObtenerLlamdasXIdSeguimiento(int idSeguimiento)
        {
            return DALSeguimiento.ObtenerLlamdasXIdSeguimiento(idSeguimiento);
        }

        public DataTable ListarLlamadasPendientesPlla()
        {
            return DALSeguimiento.ListarLlamadasPendientesPlla();
        }

        public SeguimientoPlanillaTo ObtenerSeguimientoPlanillaTo(int idSeguimiento)
        {
            return DALSeguimiento.ObtenerSeguimientoPlanillaTo(idSeguimiento);
        }

        public DataTable ObtenerPlanillasXGrupo(SeguimientoPlanillaTo se)
        {
            return DALSeguimiento.ObtenerPlanillasXGrupo(se);
        }

        public DataTable ObtenerPlanillasXGrupo2(SeguimientoPlanillaTo se)
        {
            return DALSeguimiento.ObtenerPlanillasXGrupo2(se);
        }

        public DataTable ResumenSeguimientoPlanilla(string fe_año, string fe_mes, string codPais)
        {
            return DALSeguimiento.ResumenSeguimientoPlanilla(fe_año, fe_mes, codPais);
        }

        public DataTable ObtenerUltimaLlamada(int idSeguimiento, int idEstado)
        {
            return DALSeguimiento.ObtenerUltimaLlamada(idSeguimiento, idEstado);
        }

        public DataTable RptResumenSeguimientoPlanilla(string codPrograma, string fe_año, string fe_mes, string codPtoCob)
        {
            return DALSeguimiento.RptResumenSeguimientoPlanilla(codPrograma, fe_año, fe_mes, codPtoCob);
        }

        public List<personaMaestroTo> ObtenerMaestroPersonaCategoriaPllas()
        {
            return DALSeguimiento.ObtenerMaestroPersonaCategoriaPllas();
        }

        /// <summary>
        /// Obtiene puntos de cobranza que tienen planillas ya ejecutadas [I_PLANILLA.APROBAR_RECEPCIONADO = 1], 
        /// para indicar que ya se puede cerrar la etapa de ejecución las planillas de este punto de cobranza
        /// </summary>
        /// <param name="codPais"></param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerPtoCobranzaConPlanillasEjecutadas(string codPais)
        {
            return DALSeguimiento.ObtenerPtoCobranzaConPlanillasEjecutadas(codPais);
        }

        /// <summary>
        /// Obtiene una lista de planillas por grupo para determinar que grupo ya estan ejecutadas [I_PLANILLA.APROBAR_RECEPCIONADO = 1]
        /// </summary>
        /// <param name="codPais"></param>
        /// <param name="codPtoCob"></param>
        /// <returns>DataTable</returns>
        public DataTable VerificarPlanillasAprobadoRecepcionado(string codPais, string codPtoCob)
        {
            return DALSeguimiento.VerificarPlanillasAprobadoRecepcionado(codPais, codPtoCob);
        }

        /// <summary>
        /// Retorna true si la planilla tiene ya cobros registrados (cheques, depósitos, transferencias, etc.) de lo contrario false
        /// </summary>
        /// <param name="idSeguimiento"></param>
        /// <returns>retorna true si tiene cobros registrados, de lo contrario false</returns>
        public bool VerificarSiPlanillaTienePagosRegistrados(int idSeguimiento)
        {
            return DALSeguimiento.VerificarSiPlanillaTienePagosRegistrados(idSeguimiento);
        }

        public bool VerificarPlanillaTienePagosRegistradosTesoreria(int idSeguimiento)
        {
            return DALSeguimiento.VerificarPlanillaTienePagosRegistradosTesoreria(idSeguimiento);
        }
    }
}
