using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Transactions;
namespace BLL
{
    public class comisionesBLL
    {
        private readonly comisionesDAL comDAL = new comisionesDAL();
        private readonly comisionesDetalleBLL codBLL = new comisionesDetalleBLL();
        private readonly comisionesDetalleTo codTo = new comisionesDetalleTo();
        private readonly serieDocumentosDAL serieDAL = new serieDocumentosDAL();

        private const string COD_SUCURSAL = "0001";
        private const string COD_ADELANTO_COMISION = "22";
        private const string SERIE_ADELNATO_COMISION = "AC1";

        public DataTable obtenerComisionesBLL()
        {
            return comDAL.obtenerComisionesDAL();
        }
        public bool grabarMaestroComisionesBLL(comisionesTo comTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cabecera
                if (!insertarComisionesBLL(comTo, ref errMensaje))
                    return result = false;
                //detalle
                if (!insertarDetalleComisionesBLL(comTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }



        public bool insertarComisionesBLL(comisionesTo comTo, ref string errMensaje)
        {
            bool result = true;
            if (!comDAL.insertarComisionesDAL(comTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarDetalleComisionesBLL(comisionesTo comTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                codTo.TIPO = comTo.TIPO;
                codTo.COD_PROGRAMA = comTo.COD_PROGRAMA;
                codTo.COD_INSTITUCION = comTo.COD_INSTITUCION;
                codTo.COD_NIVEL_INSTITUCION = comTo.COD_NIVEL_INSTITUCION;
                codTo.COD_PER = comTo.COD_PER;
                codTo.COD_NIVEL = rw["cod_nivel"].ToString();
                codTo.NOM_NIVEL = rw["nom_nivel"].ToString();
                codTo.COD_PER_SUP = rw["cod_per_sup"].ToString();
                codTo.NOM_PER_SUP = rw["nom_per_sup"].ToString();
                codTo.IMPORTE = Convert.ToDecimal(rw["importe0"]);
                codTo.PORCENTAJE = Convert.ToDecimal(rw["porcentaje0"]);
                codTo.CUOTA = rw["cuota0"].ToString();
                codTo.COD_CREA = comTo.COD_CREA;
                codTo.FECHA_CREA = comTo.FECHA_CREA;
                if (!codBLL.insertarComisionesDetalleBLL(codTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }

        public DataTable ListarTipoComision()
        {
            return comDAL.ListarTipoComision();
        }

        public DataTable ListarComisiones(string codDirNacional, string codDirVentas, string codSupervisor, string codNivelMostrar, string codPerMostrar, string codTipoPlanilla)
        {
            return comDAL.ListarComisiones(codDirNacional, codDirVentas, codSupervisor, codNivelMostrar, codPerMostrar, codTipoPlanilla);
        }

        public bool actualizarMaestroComisionesBLL(comisionesTo comTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cabecera
                if (!modificarComisionesBLL(comTo, ref errMensaje))
                    return result = false;
                //eliminar detalle
                if (!eliminarComisionesDetalleBLL(comTo, ref errMensaje))
                    return result = false;
                //ingresar detalle
                if (!insertarDetalleComisionesBLL(comTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool eliminarComisionesDetalleBLL(comisionesTo comTo, ref string errMensaje)
        {
            bool result = true;
            codTo.TIPO = comTo.TIPO;
            codTo.COD_PROGRAMA = comTo.COD_PROGRAMA;
            codTo.COD_PER = comTo.COD_PER;
            codTo.COD_INSTITUCION = comTo.COD_INSTITUCION;
            codTo.COD_NIVEL_INSTITUCION = comTo.COD_NIVEL_INSTITUCION;
            if (!codBLL.eliminarComisionesDetalleBLL(codTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarComisionesBLL(comisionesTo comTo, ref string errMensaje)
        {
            bool result = true;
            if (!comDAL.modificarComisionesDAL(comTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool finiquitarMaestroComisionesBLL(comisionesTo comTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                //eliminar detalle
                if (!eliminarComisionesDetalleBLL(comTo, ref errMensaje))
                    return result = false;
                //eliminar cabecera
                if (!eliminarComisionesBLL(comTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool eliminarComisionesBLL(comisionesTo comTo, ref string errMensaje)
        {
            bool result = true;
            if (!comDAL.eliminarComisionesDAL(comTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerComisionistasparaConsultaBLL(comisionesTo comTo)
        {
            return comDAL.obtenerComisionistasparaConsultaDAL(comTo);
        }

        public bool GrabarComision(ComisionTo comTo)
        {
            return comDAL.GrabarComision(comTo);
        }

        public bool ActualizarImpoteComisionMain(ComisionTo comTo)
        {
            return comDAL.ActualizarImpoteComisionMain(comTo);
        }

        public bool EliminarComision(ComisionTo comTo)
        {
            return comDAL.EliminarComision(comTo);
        }

        public int EliminarComisionXNroCuota(List<ComisionTo> lstComision, string nroCuota)
        {
            return comDAL.EliminarComisionXNroCuota(lstComision, nroCuota);
        }

        public int EliminarComisionXFechaVigencia(List<ComisionTo> lstComision, DateTime fechaVigencia)
        {
            return comDAL.EliminarComisionXFechaVigencia(lstComision, fechaVigencia);
        }

        public DataTable RptComisionXNivelVenta(string codTipoVenta, string nivelVenta, string codPer, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            return comDAL.RptComisionXNivelVenta(codTipoVenta, nivelVenta, codPer, fechaIniVigencia, fechaFinVigencia);
        }

        public DataTable RptComisionVendedoresXNivelVenta(string codTipoVenta, string nivelVenta, string codPer, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            return comDAL.RptComisionVendedoresXNivelVenta(codTipoVenta, nivelVenta, codPer, fechaIniVigencia, fechaFinVigencia);
        }

        public DataTable RptComisionXVendedor(string codTipoVenta, string codPer, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            return comDAL.RptComisionXVendedor(codTipoVenta, codPer, fechaIniVigencia, fechaFinVigencia);
        }

        public bool EliminarSoloUnaComision(ComisionTo comTo)
        {
            return comDAL.EliminarSoloUnaComision(comTo);
        }

        public DataTable RptComisionResumen(string codTipoVenta, DateTime fechaIniVigencia, DateTime fechaFinVigencia)
        {
            return comDAL.RptComisionResumen(codTipoVenta, fechaIniVigencia, fechaFinVigencia);
        }

        public DataTable ListarContratosParaGenerarComision(DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
            string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            return comDAL.ListarContratosParaGenerarComision(fechaAprobIni, fechaAprobFin, fechaCobraIni, fechaCobraFin, codPrograma, codInstitucion, codTipoPlla, nroCuota);
        }

        public DataTable ListarContratosGeneradosComisionXPeriodo(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            return comDAL.ListarContratosGeneradosComisionXPeriodo(feAñoPer, feMesPer, periodoProceso, codPrograma, codInstitucion, codTipoPlla, nroCuota);
        }

        public DataTable ObtenerNroCuota()
        {
            return comDAL.ObtenerNroCuota();
        }

        public bool InsertarComisionContrato(List<ComisionContrato> lstCom)
        {
            return comDAL.InsertarComisionContrato(lstCom);
        }

        public bool InsertarComisionContratoExcluidos(List<ComisionContrato> lstCom)
        {
            return comDAL.InsertarComisionContratoExcluidos(lstCom);
        }

        public DataTable ObtenerContratoParaGenerarComision(string nroContrato, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota,
            DateTime fechaCobranzaIni)
        {
            return comDAL.ObtenerContratoParaGenerarComision(nroContrato, codPrograma, codInstitucion, codTipoPlla, nroCuota, fechaCobranzaIni);
        }

        public DataTable ObtenerContratoMostrarAgregarComision(string nroContrato, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            return comDAL.ObtenerContratoMostrarAgregarComision(nroContrato, codPrograma, codInstitucion, codTipoPlla, nroCuota);
        }

        public bool EliminarContratoComision(ComisionContrato comTo)
        {
            return comDAL.EliminarContratoComision(comTo);
        }

        public bool EliminarContratoComision(List<ComisionContrato> items)
        {
            return comDAL.EliminarContratoComision(items);
        }

        public string ObtenerPeriodoProceso(string feAñoPer, string feMesPer)
        {
            return comDAL.ObtenerPeriodoProceso(feAñoPer, feMesPer);
        }

        public DataTable ObtenerPeriodosGeneradosComision()
        {
            return comDAL.ObtenerPeriodosGeneradosComision();
        }

        public DataTable ObtenerPeriodosExcluidosComision()
        {
            return comDAL.ObtenerPeriodosExcluidosComision();
        }

        public DataTable RptContratosComisionGeneradosXSuperior(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma,
            string codSuperior, string codNivelVenta)
        {
            return comDAL.RptContratosComisionGeneradosXSuperior(feAñoPer, feMesPer, periodoProceso, codPrograma, codSuperior, codNivelVenta);
        }

        public DataTable RptContratosComisionGeneradosXVendedor(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codVendedor)
        {
            return comDAL.RptContratosComisionGeneradosXVendedor(feAñoPer, feMesPer, periodoProceso, codPrograma, codVendedor);
        }

        public DataTable RptContratosComisionExcluidosXSuperior(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma,
           string codSuperior, string codNivelVenta)
        {
            return comDAL.RptContratosComisionExcluidosXSuperior(feAñoPer, feMesPer, periodoProceso, codPrograma, codSuperior, codNivelVenta);
        }

        public DataTable RptContratosComisionExcluidosXVendedor(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codVendedor)
        {
            return comDAL.RptContratosComisionExcluidosXVendedor(feAñoPer, feMesPer, periodoProceso, codPrograma, codVendedor);
        }

        public DataTable RPTHISTORICOCOMISIONESAPROBADAS(DateTime fechaAprobIni, DateTime fechaAprobFin,  string codVendedor, string tipobusfecha, string fechaActper, string fechaActmes)
        {
            return comDAL.RPTHISTORICOCOMISIONESAPROBADAS(fechaAprobIni, fechaAprobFin, codVendedor, tipobusfecha,  fechaActper,  fechaActmes);
        }

        public DataTable ListarDevolucionComisionContratos(DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaDevolIni, DateTime fechaDevolFin, string codPrograma, string codInstitucion)
        {
            return comDAL.ListarDevolucionComisionContratos(fechaAprobIni, fechaAprobFin, fechaDevolIni, fechaDevolFin, codPrograma, codInstitucion);
        }

        public DataTable ListarDevolucionComisionContratosGenerados(string feAñoPer, string feMesPer)
        {
            return comDAL.ListarDevolucionComisionContratosGenerados(feAñoPer, feMesPer);
        }

        public DataTable ObtenerContratoComisonGenerado(string nroContrato)
        {
            return comDAL.ObtenerContratoComisonGenerado(nroContrato);
        }

        public DataTable ListarContratosComisionExcluidos(DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaCobraIni, DateTime fechaCobraFin,
            string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            return comDAL.ListarContratosComisionExcluidos(fechaAprobIni, fechaAprobFin, fechaCobraIni, fechaCobraFin, codPrograma, codInstitucion, codTipoPlla, nroCuota);
        }

        public bool EliminarContratoComisionExcluidos(List<ComisionContrato> lstCom)
        {
            return comDAL.EliminarContratoComisionExcluidos(lstCom);
        }

        public bool ActualizarEstadoControComisionAProcesado(List<ComisionContrato> lstCom)
        {
            return comDAL.ActualizarEstadoControComisionAProcesado(lstCom);
        }

        public bool ActualizarEstadoControComisionAExcluidos(List<ComisionContrato> lstCom)
        {
            return comDAL.ActualizarEstadoControComisionAExcluidos(lstCom);
        }

        public bool InsertarComisionContratoAPeriodoExistente(ComisionContrato com)
        {
            return comDAL.InsertarComisionContratoAPeriodoExistente(com);
        }

        public DataTable ObtenerContratoComisionGenerado(string codSucursal, string codClase, string nroContrato, string feAño, string feMes, string nroCuota)
        {
            return comDAL.ObtenerContratoComisionGenerado(codSucursal, codClase, nroContrato, feAño, feMes, nroCuota);
        }

        public bool AprobarComisionesContrato(List<ComisionContrato> lstCom)
        {
            return comDAL.AprobarComisionesContrato(lstCom);
        }

        public DataTable ListarComisionContratoAprobado(string feAñoPer, string feMesPer, string periodoProceso, string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota)
        {
            return comDAL.ListarComisionContratoAprobado(feAñoPer, feMesPer, periodoProceso, codPrograma, codInstitucion, codTipoPlla, nroCuota);
        }

        /// <summary>
        /// Reasigna comisión a un contrato que ya tiene numero de cuota y comisión
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool RecalcularComisionContrato(DataTable dt, DateTime fechaCobranzaIni)
        {
            return comDAL.RecalcularComisionContrato(dt, fechaCobranzaIni);
        }

        /// <summary>
        /// Asigna una comisión a un contrato que no tiene nro de cuota
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool RecalcularComisionContrato2(DataTable dt, DateTime fechaCobranzaIni)
        {
            return comDAL.RecalcularComisionContrato2(dt, fechaCobranzaIni);
        }

        public DataTable ObtenerContratoComisonExcluido(string nroContrato)
        {
            return comDAL.ObtenerContratoComisonExcluido(nroContrato);
        }

        public DataTable ListarContratosPendientes(DateTime fechaAprobFin, DateTime fechaCobraFin, string codPrograma,
            string codInstitucion, string codTipoPlla, string nroCuota)
        {
            return comDAL.ListarContratosPendientes(fechaAprobFin, fechaCobraFin, codPrograma, codInstitucion, codTipoPlla, nroCuota);
        }

        public bool DesaprobarComisionesContrato(List<ComisionContrato> lstCom)
        {
            return comDAL.DesaprobarComisionesContrato(lstCom);
        }

        public bool GenerarDevolucionComisionCabDet(List<DevolucionComisionITo> lstDev)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!InsertarIDevolucionComision(lstDev, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!InsertarTDevolucionComision(lstDev, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarTDevolucionComision(lstDev, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        private bool InsertarIDevolucionComision(List<DevolucionComisionITo> lstDev, SqlTransaction tr, SqlConnection cn)
        {
            var lista = from a in lstDev
                        where a.TIPO_REGISTRO == TIPO_REGISTRO.NUEVO && a.ID_DEVOLUCION == 0
                        select a;
            if (!comDAL.InsertarIDevolucionComision(lista.ToList(), tr, cn))
                return false;
            return true;
        }

        private bool InsertarTDevolucionComision(List<DevolucionComisionITo> lstDev, SqlTransaction tr, SqlConnection cn)
        {
            var lista = from a in lstDev
                        where a.TIPO_REGISTRO == TIPO_REGISTRO.NUEVO
                        select a;
            if (!comDAL.InsertarTDevolucionComision(lista.ToList(), tr, cn))
                return false;
            return true;
        }

        private bool ActualizarTDevolucionComision(List<DevolucionComisionITo> lstDev, SqlTransaction tr, SqlConnection cn)
        {
            var lista = from a in lstDev
                        where a.TIPO_REGISTRO == TIPO_REGISTRO.EXISTENTE
                        select a;
            if (!comDAL.ActualizarTDevolucionComision(lista.ToList(), tr, cn))
                return false;
            return true;
        }

        public DataTable ListarDescuentoCuotaVigencia()
        {
            return comDAL.ListarDescuentoCuotaVigencia();
        }

        public bool InsertarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!InsertarDescuentoCuotaVigencia(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarDescuentoCuotaVigenciaMenor(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        private bool InsertarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to, SqlTransaction tr, SqlConnection cn)
        {
            DescuentoCuotaVigenciaTo en = comDAL.ObtenerDescuentoFechaVigenciaMayor(to);
            if (en != null)
                to.FECHA_FIN_VIGENCIA = en.FECHA_INI_VIGENCIA;
            return comDAL.InsertarDescuentoCuotaVigencia(to, tr, cn);
        }

        private bool ActualizarDescuentoCuotaVigenciaMenor(DescuentoCuotaVigenciaTo to, SqlTransaction tr, SqlConnection cn)
        {
            DescuentoCuotaVigenciaTo en = comDAL.ObtenerDescuentoFechaVigenciaMenor(to);
            if (en != null)
            {
                en.FECHA_FIN_VIGENCIA = to.FECHA_INI_VIGENCIA;
                en.USUARIO_MODIFICA = to.USUARIO_MODIFICA;
                en.FECHA_MODIFICA = to.FECHA_MODIFICA;
                return comDAL.ActualizarDescuentoCuotaVigencia(en, tr, cn);
            }
            return true;
        }

        public bool ActualizarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!ActualizarDescuentoCuotaVigenciaMain(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarDescuentoCuotaVigenciaMain2(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public bool ActualizarDescuentoCuotaVigenciaMain(DescuentoCuotaVigenciaTo to, SqlTransaction tr, SqlConnection cn)
        {
            if (!ActualizarDescuentoCuotaVigencia(to, tr, cn))
                return false;
            if (!ActualizarDescuentoCuotaVigenciaMenor(to, tr, cn))
                return false;
            return true;
        }

        public bool ActualizarDescuentoCuotaVigenciaMain2(DescuentoCuotaVigenciaTo to, SqlTransaction tr, SqlConnection cn)
        {
            //if (to.FECHA_INI_VIGENCIA == to.FECHA_INI_VIGENCIA_ANT)
            //    return true;
            DescuentoCuotaVigenciaTo en = comDAL.ObtenerDescuentoFechaVigenciaMenor(to.FECHA_INI_VIGENCIA_ANT);
            //DescuentoCuotaVigenciaTo en = to.FECHA_INI_VIGENCIA_ANT > to.FECHA_INI_VIGENCIA
            //    ? comDAL.ObtenerDescuentoFechaVigenciaMayor(to.FECHA_INI_VIGENCIA_ANT)
            //    : comDAL.ObtenerDescuentoFechaVigenciaMenor(to.FECHA_INI_VIGENCIA_ANT);
            if (en == null)
                return true;

            en.FECHA_FIN_VIGENCIA = null;
            en.USUARIO_MODIFICA = to.USUARIO_MODIFICA;
            en.FECHA_MODIFICA = to.FECHA_MODIFICA;
            if (!ActualizarDescuentoCuotaVigencia(en, tr, cn))
                return false;
            if (!ActualizarDescuentoCuotaVigenciaMenor(en, tr, cn))
                return false;
            return true;
        }

        private bool ActualizarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to, SqlTransaction tr, SqlConnection cn)
        {
            DescuentoCuotaVigenciaTo en = comDAL.ObtenerDescuentoFechaVigenciaMayor(to);
            if (en != null)
                to.FECHA_FIN_VIGENCIA = en.FECHA_INI_VIGENCIA;
            return comDAL.ActualizarDescuentoCuotaVigencia(to, tr, cn);
        }

        public bool EliminarDescuentoCuotaVigencia(DescuentoCuotaVigenciaTo to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!comDAL.EliminarDescuentoCuotaVigencia(to))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarDescuentoCuotaVigenciaMain2(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public bool ValidarExistenciaDescCuotaVigencia(DescuentoCuotaVigenciaTo to)
        {
            return comDAL.ValidarExistenciaDescCuotaVigencia(to);
        }

        public DataTable ObtenerPeriodosDevolucionComisionGenerados()
        {
            return comDAL.ObtenerPeriodosDevolucionComisionGenerados();
        }

        public DataTable ObtenerDevolucionComisionContratosGenerado(DevolucionComisionITo to)
        {
            return comDAL.ObtenerDevolucionComisionContratosGenerado(to);
        }

        public DataTable RptDevolucionLiquidacionComisiones(string codPrograma, DateTime fechaAprobIni, DateTime fechaAprobFin, DateTime fechaDevIni, DateTime fechaDevFin)
        {
            return comDAL.RptDevolucionLiquidacionComisiones(codPrograma, fechaAprobIni, fechaAprobFin, fechaDevIni, fechaDevFin);
        }

        public bool RegistrarComisionConfig(ComisionConfigTo to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!comDAL.InsertarComisionConfig(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool ActualizarComisionConfig(ComisionConfigTo to)
        {
            return comDAL.ActualizarComisionConfig(to);
        }

        public DataTable ListarConfiguracionComision(ComisionConfigTo to)
        {
            return comDAL.ListarConfiguracionComision(to);
        }

        /// <summary>
        /// Obtiene las fechas vigencia de un determinado nivel de venta (SUPERIVISOR, DIRECTOR VENTA O NACIONAL)
        /// </summary>
        /// <param name="codSuperi">Código de persona de nivel venta(SUPERIVISOR, DIRECTOR VENTA O NACIONAL)</param>
        /// <param name="codNivelSuperi">Código de nivel de venta(SUPERIVISOR, DIRECTOR VENTA O NACIONAL)</param>
        /// <returns></returns>
        public DataTable ObtenerFechaIniVigenciaConfigComision(string codSuperi, string codNivelSuperi)
        {
            return comDAL.ObtenerFechaIniVigenciaConfigComision(codSuperi, codNivelSuperi);
        }

        public DataTable ListarTipoFechaVigenciaComision()
        {
            return comDAL.ListarTipoFechaVigenciaComision();
        }

        public bool InsertarTipoFechaVigenciaComision(TipoVigenciaComision to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!InsertarTipoFechaVigenciaComision(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarTipoFechaVigenciaComisionMenor(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        private bool InsertarTipoFechaVigenciaComision(TipoVigenciaComision to, SqlTransaction tr, SqlConnection cn)
        {
            TipoVigenciaComision en = comDAL.ObtenerTipoFechaVigenciaComisionMayor(to);
            if (en != null)
                to.FECHA_FIN_VIGENCIA = en.FECHA_INI_VIGENCIA.AddDays(-1);
            return comDAL.InsertarTipoFechaVigenciaComision(to, tr, cn);
        }

        private bool ActualizarTipoFechaVigenciaComisionMenor(TipoVigenciaComision to, SqlTransaction tr, SqlConnection cn)
        {
            TipoVigenciaComision en = comDAL.ObtenerTipoFechaVigenciaComisionMenor(to);
            if (en != null)
            {
                en.FECHA_FIN_VIGENCIA = to.FECHA_INI_VIGENCIA.AddDays(-1);
                en.USUARIO_MODIFICA = to.USUARIO_MODIFICA;
                en.FECHA_MODIFICA = to.FECHA_MODIFICA;
                return comDAL.ActualizarTipoFechaVigenciaComision(en, tr, cn);
            }
            return true;
        }

        public bool ActualizarTipoFechaVigenciaComision(TipoVigenciaComision to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!ActualizarTipoFechaVigenciaComisionMain(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarTipoFechaVigenciaComisionMain2(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public bool ActualizarTipoFechaVigenciaComisionMain(TipoVigenciaComision to, SqlTransaction tr, SqlConnection cn)
        {
            if (!ActualizarTipoFechaVigenciaComision(to, tr, cn))
                return false;
            if (!ActualizarTipoFechaVigenciaComisionMenor(to, tr, cn))
                return false;
            return true;
        }

        private bool ActualizarTipoFechaVigenciaComision(TipoVigenciaComision to, SqlTransaction tr, SqlConnection cn)
        {
            TipoVigenciaComision en = comDAL.ObtenerTipoFechaVigenciaComisionMayor(to);
            if (en != null)
                to.FECHA_FIN_VIGENCIA = en.FECHA_INI_VIGENCIA.AddDays(-1);
            return comDAL.ActualizarTipoFechaVigenciaComision(to, tr, cn);
        }

        public bool ActualizarTipoFechaVigenciaComisionMain2(TipoVigenciaComision to, SqlTransaction tr, SqlConnection cn)
        {
            TipoVigenciaComision en = comDAL.ObtenerTipoFechaVigenciaComisionMenor(to.FECHA_INI_VIGENCIA_ANT);
            if (en == null)
                return true;

            en.FECHA_FIN_VIGENCIA = null;
            en.USUARIO_MODIFICA = to.USUARIO_MODIFICA;
            en.FECHA_MODIFICA = to.FECHA_MODIFICA;
            if (!ActualizarTipoFechaVigenciaComision(en, tr, cn))
                return false;
            if (!ActualizarTipoFechaVigenciaComisionMenor(en, tr, cn))
                return false;
            return true;
        }

        public bool EliminarTipoFechaVigenciaComision(TipoVigenciaComision to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!comDAL.EliminarTipoFechaVigenciaComision(to))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarTipoFechaVigenciaComisionMain2(to, tr, cn))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public DataTable ListarDevolucionComisionGenCancelados(DevolucionComisionITo to)
        {
            return comDAL.ListarDevolucionComisionGenCancelados(to);
        }

        public DataTable ListarDevolucionComisionGenAnulados(DevolucionComisionITo to)
        {
            return comDAL.ListarDevolucionComisionGenAnulados(to);
        }

        public bool RevertirDevolucionComision(List<DevolucionComisionTTo> lstTo)
        {
            return comDAL.RevertirDevolucionComision(lstTo);
        }

        public bool EliminarDevolucionComision(DevolucionComisionTTo to)
        {
            return comDAL.EliminarDevolucionComision(to);
        }

        public DataTable ObtenerDevolucionComisionXContrato(string nroContrato)
        {
            return comDAL.ObtenerDevolucionComisionXContrato(nroContrato);
        }

        public List<DevolucionComisionITo> ObtenerTDevolucionComisionReg(DevolucionComisionITo to)
        {
            return comDAL.ObtenerTDevolucionComisionReg(to);
        }

        /// <summary>
        /// Obtiene la lista de vendedores con sus respectivos totales de comisiones, devoluciones, otros ingresos y egresos
        /// </summary>
        /// <param name="feAñoPer">Año del periodo</param>
        /// <param name="feMesPer">Mes del periodo</param>
        /// <returns></returns>
        public DataTable ListarVendedoresComisionIngreEgre(string feAñoPer, string feMesPer)
        {
            return comDAL.ListarVendedoresComisionIngreEgre(feAñoPer, feMesPer);
        }

        /// <summary>
        /// Obtiene los periodos generedos de comisiones y devoluciones
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ObtenerPeriodoGeneradosComisionYDevolucion()
        {
            return comDAL.ObtenerPeriodoGeneradosComisionYDevolucion();
        }

        /// <summary>
        /// Obtiene la lista de otros movimientos que tiene el vendedor como: adelantos, premios, bonos, penalidad, multa, etc.
        /// </summary>
        /// <param name="codVendedor">Código del vendedor</param>
        /// <returns>DataTable</returns>
        public DataTable ListarOtrosMovimientosXVendedor(MovimientosNivelVentaTo to)
        {
            return comDAL.ListarOtrosMovimientosXVendedor(to);
        }

        /// <summary>
        /// Inserta y actualiza movimientos de niveles de venta como adelantos, bonos, premios, sanciones
        /// </summary>
        /// <param name="lstRegistrar">Objeto lista MovimientsNivelVentaTo solo para insertar</param>
        /// <param name="lstActualizar">Objeto lista MovimientsNivelVentaTo solo para actualizar</param>
        /// <returns>true si se eliminó correctamente, false si no se eliminó correctamente</returns>
        public bool GrabarMovimientosNivelVenta(List<MovimientosNivelVentaTo> lstRegistrar, List<MovimientosNivelVentaTo> lstActualizar)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!RegistrarMovimientosNivelVenta(lstRegistrar, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarMovimientosNivelVenta(lstActualizar, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }

                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                        tr.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Inserta movimientos de niveles de venta como adelantos, bonos, premios, sanciones
        /// </summary>
        /// <param name="lstRegistrar">Objeto lista MovimientsNivelVentaTo solo para insertar</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        private bool RegistrarMovimientosNivelVenta(List<MovimientosNivelVentaTo> lstRegistrar, SqlConnection cn, SqlTransaction tr)
        {
            if (lstRegistrar == null) return true;
            foreach (MovimientosNivelVentaTo item in lstRegistrar)
            {
                if (!comDAL.InsertarMovimientosNivelVenta(item, cn, tr))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Actualiza movimientos de niveles de venta como adelantos, bonos, premios, sanciones
        /// </summary>
        /// <param name="lstActualizar">Objeto lista MovimientsNivelVentaTo solo para actualizar</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns></returns>
        private bool ActualizarMovimientosNivelVenta(List<MovimientosNivelVentaTo> lstActualizar, SqlConnection cn, SqlTransaction tr)
        {
            if (lstActualizar == null) return true;
            foreach (MovimientosNivelVentaTo item in lstActualizar)
            {
                if (!comDAL.ActualizarMovimientosNivelVenta(item, cn, tr))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Elimina las configuraciones establecidas de la tabla CONFIGURACION_COMISION por ID_COMISION_CONF
        /// </summary>
        /// <param name="lstTo">Lista de ComisionConfigTo a eliminar</param>
        /// <returns>Un boolean, si se se eliminó correctamente es true de lo contrario false</returns>
        public bool EliminarConfiguracionComision(List<ComisionConfigTo> lstTo)
        {
            return comDAL.EliminarConfiguracionComision(lstTo);
        }

        /// <summary>
        /// Elimina registro de la tabla MOVIMIENTOS_NIVEL_VENTA por ID_MOVIMIENTO
        /// </summary>
        /// <param name="to">Obteto MovimientosNivelVentaTo</param>
        /// <returns>true si se eliminó correctamente, false si no se eliminó correctamente</returns>
        public bool EliminarMovimientosNivelVenta(MovimientosNivelVentaTo to)
        {
            return comDAL.EliminarMovimientosNivelVenta(to);
        }

        /// <summary>
        /// Graba liquidaciones y tablas asociadas de comisiones, devoluciones, movimientos(otros ingresos, otros egresos) por persona
        /// </summary>
        /// <param name="lstLiquiComision">liquidaciones de TIPO_LIQUIDACION = COMISIONES_TERCEROS y/o TIPO_LIQUIDACION = COMISIONES_PROPIOS</param>
        /// <param name="lstLiquiDevolucion">liquidaciones de TIPO_LIQUIDACION = DEVOLUCIONES</param>
        /// <param name="lstLiquiOtrosIngresos">liquidaciones de TIPO_LIQUIDACION = OTROS_INGRESOS</param>
        /// <param name="lstLiquiOtrosEgresos">liquidaciones de TIPO_LIQUIDACION = OTROS_EGRESOS</param>
        /// <returns></returns>
        public bool GrabarLiquidacionNivelVenta(List<LiquidacionTo> lstLiquiComision, List<LiquidacionTo> lstLiquiDevolucion, List<LiquidacionTo> lstLiquiOtrosIngresos,
            List<LiquidacionTo> lstLiquiOtrosEgresos)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!GrabarLiquidacionComision(lstLiquiComision, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!GrabarLiquidacionDevolucion(lstLiquiDevolucion, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!GrabarLiquidacionOtrosIngresos(lstLiquiOtrosIngresos, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!GrabarLiquidacionOtrosEgresos(lstLiquiOtrosEgresos, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                        tr.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Inserta, actualiza liquidaciones de TIPO_LIQUIDACION = COMISIONES_TERCEROS y/o TIPO_LIQUIDACION = COMISIONES_PROPIOS
        /// </summary>
        /// <param name="lstLiquiTo">Lista de comisiones a generar o actualizar por cada persona</param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns>true si se grabó correctamente, de lo contrario false</returns>
        private bool GrabarLiquidacionComision(List<LiquidacionTo> lstLiquiTo, SqlConnection cn, SqlTransaction tr)
        {
            const string COD_SUCURSAL = "0001";
            const string COD_LIQUIDACION_DOC = "81";
            const string SERIE_COMISION_LIQUI_DOC = "COM";
            if (lstLiquiTo.Count == 0)
                return true;
            List<ComisionContrato> lstComision = comDAL.ObtenerComisionToParaLiqui(new ComisionContrato
            {
                FE_AÑO_PER = lstLiquiTo[0].FE_AÑO_PER,
                FE_MES_PER = lstLiquiTo[0].FE_MES_PER
            }, cn, tr);
            ComisionContrato[] arrComision;
            LiquidacionTo liqu;
            foreach (LiquidacionTo item in lstLiquiTo)
            {
                arrComision = lstComision.Where(x => x.ComisionTo.PersonaTo.COD_PER == item.COD_PER && x.ComisionLiquidacionDetTo.TIPO_LIQUIDACION == item.TIPO_LIQUIDACION).ToArray();
                liqu = comDAL.ObtieneLiquidacionXPersonaTipoLiqu(item, cn, tr);
                if (liqu == null)
                {
                    serieDocumentosTo serieDoc = serieDAL.ObtenerCorrelativoDoc(new serieDocumentosTo
                    { COD_SUCURSAL = COD_SUCURSAL, COD_DOC = COD_LIQUIDACION_DOC, SERIE = SERIE_COMISION_LIQUI_DOC },
                    cn, tr);
                    item.NRO_LIQUIDACION = serieDoc.CORRELATIVO;
                    if (!comDAL.InsertarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    if (!InsertarComisionLiquidacionDet(arrComision, item, cn, tr))
                        return false;
                    if (!serieDAL.AdicionaNroSerieDAL(serieDoc, cn, tr))
                        return false;
                }
                if (liqu != null)
                {
                    item.NRO_LIQUIDACION = liqu.NRO_LIQUIDACION;
                    if (!comDAL.ActualizarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    ComisionLiquidacionDetTo comDet = new ComisionLiquidacionDetTo { NRO_LIQUIDACION = item.NRO_LIQUIDACION, TIPO_LIQUIDACION = item.TIPO_LIQUIDACION };
                    if (!comDAL.EliminarComisionLiquidacionDet(comDet, cn, tr))
                        return false;
                    liqu.USUARIO_CREA = item.USUARIO_CREA;
                    if (!InsertarComisionLiquidacionDet(arrComision, liqu, cn, tr))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Inserta el número de liquidacion que corresponde a cada registro de la tabla COMISION_CONTRATO
        /// </summary>
        /// <param name="arrComision">Array de ComisionContrato a la cual se va asociar el número de liquidación generada</param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns>true si se registró correctamente, de lo contrario false</returns>
        private bool InsertarComisionLiquidacionDet(ComisionContrato[] arrComision, LiquidacionTo liqu, SqlConnection cn, SqlTransaction tr)
        {
            if (arrComision == null || arrComision.Length == 0)
                return false;
            foreach (ComisionContrato item in arrComision)
            {
                item.ComisionLiquidacionDetTo.NRO_LIQUIDACION = liqu.NRO_LIQUIDACION;
                item.ComisionLiquidacionDetTo.USUARIO_CREA = liqu.USUARIO_CREA;
                if (!comDAL.InsertarComisionLiquidacionDet(item.ComisionLiquidacionDetTo, cn, tr))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Inserta, actualiza liquidaciones de TIPO_LIQUIDACION = DEVOLUCIONES
        /// </summary>
        /// <param name="lstLiquiTo">Lista de comisiones a generar o actualizar por cada persona</param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns>true si se grabó correctamente, de lo contrario false</returns>
        private bool GrabarLiquidacionDevolucion(List<LiquidacionTo> lstLiquiTo, SqlConnection cn, SqlTransaction tr)
        {
            const string COD_SUCURSAL = "0001";
            const string COD_LIQUIDACION_DOC = "81";
            const string SERIE_DEVOLUCION_LIQUI_DOC = "DEV";
            if (lstLiquiTo.Count == 0)
                return true;
            List<DevolucionComisionITo> lstDevolucion = comDAL.ObtenerDevolucionComisionIToParaLiqui(new DevolucionComisionITo
            {
                FE_AÑO_PER = lstLiquiTo[0].FE_AÑO_PER,
                FE_MES_PER = lstLiquiTo[0].FE_MES_PER
            }, cn, tr);
            DevolucionComisionITo[] arrDevolucion;
            LiquidacionTo liqu;
            foreach (LiquidacionTo item in lstLiquiTo)
            {
                arrDevolucion = lstDevolucion.Where(x => x.COD_PER == item.COD_PER).ToArray();
                liqu = comDAL.ObtieneLiquidacionXPersonaTipoLiqu(item, cn, tr);
                if (liqu == null)
                {
                    serieDocumentosTo serieDoc = serieDAL.ObtenerCorrelativoDoc(new serieDocumentosTo
                    { COD_SUCURSAL = COD_SUCURSAL, COD_DOC = COD_LIQUIDACION_DOC, SERIE = SERIE_DEVOLUCION_LIQUI_DOC },
                    cn, tr);
                    item.NRO_LIQUIDACION = serieDoc.CORRELATIVO;
                    if (!comDAL.InsertarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    if (!InsertarNroLiquidacionEnIDevolucionContrato(arrDevolucion, item, cn, tr))
                        return false;
                    if (!serieDAL.AdicionaNroSerieDAL(serieDoc, cn, tr))
                        return false;
                }
                if (liqu != null)
                {
                    item.NRO_LIQUIDACION = liqu.NRO_LIQUIDACION;
                    if (!comDAL.ActualizarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    if (!InsertarNroLiquidacionEnIDevolucionContrato(arrDevolucion, liqu, cn, tr))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Inserta el número de liquidacion que corresponde a cada registro de la tabla T_DEVOLUCION_COMISION
        /// </summary>
        /// <param name="arrDevolucion">Array de DevolucionComisionITo a la cual se va asociar el número de liquidación generada</param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns>true si se registró correctamente, de lo contrario false</returns>
        private bool InsertarNroLiquidacionEnIDevolucionContrato(DevolucionComisionITo[] arrDevolucion, LiquidacionTo liqu, SqlConnection cn, SqlTransaction tr)
        {
            if (arrDevolucion == null || arrDevolucion.Length == 0)
                return false;
            foreach (DevolucionComisionITo item in arrDevolucion)
            {
                item.DevolucionComisionTTo.NRO_LIQUIDACION = liqu.NRO_LIQUIDACION;
                if (!comDAL.InsertarNroLiquidacionEnTDevolucionContrato(item, cn, tr))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Inserta, actualiza liquidaciones de TIPO_LIQUIDACION = OTROS_INGRESOS
        /// </summary>
        /// <param name="lstLiquiTo">Lista de comisiones a generar o actualizar por cada persona</param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns>true si se grabó correctamente, de lo contrario false</returns>
        private bool GrabarLiquidacionOtrosIngresos(List<LiquidacionTo> lstLiquiTo, SqlConnection cn, SqlTransaction tr)
        {
            const string COD_SUCURSAL = "0001";
            const string COD_LIQUIDACION_DOC = "81";
            const string SERIE_MOVIMI_LIQUI_DOC = "ING";
            const int INGRESOS = 1;
            if (lstLiquiTo.Count == 0)
                return true;
            List<MovimientosNivelVentaTo> lstDevolucion = comDAL.ObtenerOtrosMovimientosVendedorParaLiqui(new MovimientosNivelVentaTo
            {
                FE_AÑO_PER = lstLiquiTo[0].FE_AÑO_PER,
                FE_MES_PER = lstLiquiTo[0].FE_MES_PER
            }, cn, tr);
            MovimientosNivelVentaTo[] arrOtrosIngresos;
            LiquidacionTo liqu;
            foreach (LiquidacionTo item in lstLiquiTo)
            {
                arrOtrosIngresos = lstDevolucion.Where(x => x.COD_PER == item.COD_PER && x.COD_NIVEL == item.COD_NIVEL && x.TIPO_MOVIMIENTO == INGRESOS).ToArray();
                liqu = comDAL.ObtieneLiquidacionXPersonaTipoLiqu(item, cn, tr);
                if (liqu == null)
                {
                    serieDocumentosTo serieDoc = serieDAL.ObtenerCorrelativoDoc(new serieDocumentosTo
                    { COD_SUCURSAL = COD_SUCURSAL, COD_DOC = COD_LIQUIDACION_DOC, SERIE = SERIE_MOVIMI_LIQUI_DOC },
                    cn, tr);
                    item.NRO_LIQUIDACION = serieDoc.CORRELATIVO;
                    if (!comDAL.InsertarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    if (!InsertarNroLiquidacionEnMovimientosNivelVenta(arrOtrosIngresos, item, cn, tr))
                        return false;
                    if (!serieDAL.AdicionaNroSerieDAL(serieDoc, cn, tr))
                        return false;
                }
                if (liqu != null)
                {
                    item.NRO_LIQUIDACION = liqu.NRO_LIQUIDACION;
                    if (!comDAL.ActualizarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    if (!InsertarNroLiquidacionEnMovimientosNivelVenta(arrOtrosIngresos, liqu, cn, tr))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Inserta el número de liquidacion que corresponde a cada registro de la tabla MOVIMIENTOS_NIVEL_VENTA
        /// </summary>
        /// <param name="arrOtrosIngresos">Array de MovimientosNivelVentaTo a la cual se va asociar el número de liquidación generada</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns>true si se registró correctamente, de lo contrario false</returns>
        private bool InsertarNroLiquidacionEnMovimientosNivelVenta(MovimientosNivelVentaTo[] arrOtrosIngresos, LiquidacionTo liqu, SqlConnection cn, SqlTransaction tr)
        {
            if (arrOtrosIngresos == null || arrOtrosIngresos.Length == 0)
                return false;
            foreach (MovimientosNivelVentaTo item in arrOtrosIngresos)
            {
                item.NRO_LIQUIDACION = liqu.NRO_LIQUIDACION;
                if (!comDAL.InsertarNroLiquidacionEnMovimientosNivelVenta(item, cn, tr))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Inserta, actualiza comisiones de TIPO_LIQUIDACION = OTROS_EGRESOS   
        /// </summary>
        /// <param name="lstLiquiTo">Lista de comisiones a generar o actualizar por cada persona</param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns>true si se grabó correctamente, de lo contrario false</returns>
        private bool GrabarLiquidacionOtrosEgresos(List<LiquidacionTo> lstLiquiTo, SqlConnection cn, SqlTransaction tr)
        {
            const string COD_SUCURSAL = "0001";
            const string COD_LIQUIDACION_DOC = "81";
            const string SERIE_MOVIMI_LIQUI_DOC = "EGR";
            const int EGRESOS = 2;
            if (lstLiquiTo.Count == 0)
                return true;
            List<MovimientosNivelVentaTo> lstDevolucion = comDAL.ObtenerOtrosMovimientosVendedorParaLiqui(new MovimientosNivelVentaTo
            {
                FE_AÑO_PER = lstLiquiTo[0].FE_AÑO_PER,
                FE_MES_PER = lstLiquiTo[0].FE_MES_PER
            }, cn, tr);
            MovimientosNivelVentaTo[] arrOtrosIngresos;
            LiquidacionTo liqu;
            foreach (LiquidacionTo item in lstLiquiTo)
            {
                arrOtrosIngresos = lstDevolucion.Where(x => x.COD_PER == item.COD_PER && x.COD_NIVEL == item.COD_NIVEL && x.TIPO_MOVIMIENTO == EGRESOS).ToArray();
                liqu = comDAL.ObtieneLiquidacionXPersonaTipoLiqu(item, cn, tr);
                if (liqu == null)
                {
                    serieDocumentosTo serieDoc = serieDAL.ObtenerCorrelativoDoc(new serieDocumentosTo
                    { COD_SUCURSAL = COD_SUCURSAL, COD_DOC = COD_LIQUIDACION_DOC, SERIE = SERIE_MOVIMI_LIQUI_DOC },
                    cn, tr);
                    item.NRO_LIQUIDACION = serieDoc.CORRELATIVO;
                    if (!comDAL.InsertarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    if (!InsertarNroLiquidacionEnMovimientosNivelVenta(arrOtrosIngresos, item, cn, tr))
                        return false;
                    if (!serieDAL.AdicionaNroSerieDAL(serieDoc, cn, tr))
                        return false;
                }
                if (liqu != null)
                {
                    item.NRO_LIQUIDACION = liqu.NRO_LIQUIDACION;
                    if (!comDAL.ActualizarLiquidacionNivelVenta(item, cn, tr))
                        return false;
                    if (!InsertarNroLiquidacionEnMovimientosNivelVenta(arrOtrosIngresos, liqu, cn, tr))
                        return false;
                }
            }
            return true;
        }

        public DataTable ListarLiquidacionGenerada(LiquidacionTo to)
        {
            return comDAL.ListarLiquidacionGenerada(to);
        }

        /// <summary>
        /// Elimina las comisiones generadas y sus tablas relacionadas por periodo
        /// </summary>
        /// <param name="to">Objeto LiquidacionTo dónde se envía el periodo a eliminar</param>
        /// <returns></returns>
        public bool EliminarLiquidacionNivelVenta(LiquidacionTo to)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    List<LiquidacionTo> lista = comDAL.ListarLiquidacionGeneradaXPeriodo(to);
                    if (lista == null || lista.Count == 0)
                        return true;
                    if (!EliminarRelacionTablasConNroLiquidacion(lista, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!comDAL.EliminarLiquidacionNivelVenta(to, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Elimina el nro de liquidación asociado a las tablas(MOVIMIENTOS_NIVEL_VENTA, T_DEVOLUCION_COMISION, DETALLE_COMISION_LIQUIDACION)
        /// ya que se va eliminar la liquidación generada
        /// </summary>
        /// <param name="lista">Lista de comisiones a eliminar</param>
        /// <param name="cn">SqlConnection</param>
        /// <param name="tr">SqlTransaction</param>
        /// <returns>true si se eliminó correctamente, de lo contrario false</returns>
        private bool EliminarRelacionTablasConNroLiquidacion(List<LiquidacionTo> lista, SqlConnection cn, SqlTransaction tr)
        {
            ComisionLiquidacionDetTo comDet = new ComisionLiquidacionDetTo();
            foreach (LiquidacionTo item in lista)
            {
                if (item.TIPO_LIQUIDACION == TIPO_LIQUIDACION.COMISIONES_PROPIOS ||
                    item.TIPO_LIQUIDACION == TIPO_LIQUIDACION.COMISIONES_TERCEROS)
                {
                    comDet.NRO_LIQUIDACION = item.NRO_LIQUIDACION;
                    comDet.TIPO_LIQUIDACION = item.TIPO_LIQUIDACION;
                    if (!comDAL.EliminarComisionLiquidacionDet(comDet, cn, tr))
                        return false;
                    continue;
                }
                if (item.TIPO_LIQUIDACION == TIPO_LIQUIDACION.DEVOLUCIONES)
                {
                    if (!comDAL.EliminarNroLiquidacionDevolucion(new DevolucionComisionTTo { NRO_LIQUIDACION = item.NRO_LIQUIDACION }, cn, tr))
                        return false;
                    continue;
                }
                if (item.TIPO_LIQUIDACION == TIPO_LIQUIDACION.OTROS_EGRESOS ||
                    item.TIPO_LIQUIDACION == TIPO_LIQUIDACION.OTROS_INGRESOS)
                {
                    if (!comDAL.EliminarNroLiquidacionMovimientoNivVenta(new MovimientosNivelVentaTo { NRO_LIQUIDACION = item.NRO_LIQUIDACION }, cn, tr))
                        return false;
                    continue;
                }
            }
            return true;
        }

        /// <summary>
        /// Reporte de todas las liquidaciones(comisiones, devoluciones, otros ingresos, otros egresos) por persona de un periodo
        /// </summary>
        /// <param name="to">Objeto dónde se envía el periodo para filtrar</param>
        /// <returns>DataTable</returns>
        public DataTable RptLiquidacionResumenXPersona(LiquidacionTo to)
        {
            return comDAL.RptLiquidacionResumenXPersona(to);
        }

        /// <summary>
        /// Obtiene un DataTable con todos los movimientos necesarios para calcular el saldo anterior(comisiones, devoluciones, otros ingresos, otros egresos) por persona de un periodo
        /// </summary>
        /// <param name="to">Objeto dónde se envía el periodo para filtrar</param>
        /// <returns>DataTable</returns>
        public DataTable LiquidacionSaldoAnteriorXPersona(LiquidacionTo to)
        {
            return comDAL.LiquidacionSaldoAnteriorXPersona(to);
        }

        /// <summary>
        /// Obtiene un dataTable solo de las fechas de vigencia de configuración comisión por institución
        /// </summary>
        /// <param name="codInstitucion">Código de institución</param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerFechaIniVigenciaConfigComisionInstitu(string codInstitucion)
        {
            return comDAL.ObtenerFechaIniVigenciaConfigComisionInstitu(codInstitucion);
        }

        /// <summary>
        /// Obtiene la comisión de vendedores y superiores(supervisor, director de venta, director nacional) por institución
        /// </summary>
        /// <param name="to">Objeto ComisionConfigTo dónde se pasa la fecha de vigencia, codigo de istitución y tipo de venta para filtrar</param>
        /// <returns></returns>
        public DataTable ListarConfiguracionComisionInstitu(ComisionConfigTo to)
        {
            return comDAL.ListarConfiguracionComisionInstitu(to);
        }

        /// <summary>
        /// Obtiene una lista de vendedores con el total de comisiones de contratos sin aprobar generados, total adelanto y total saldo
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarVendedoresAdelantoComision(string codPrograma)
        {
            return comDAL.ListarVendedoresAdelantoComision(codPrograma);
        }

        /// <summary>
        /// Obtiene una lista de contratos sin aprobar para realizar su adelanto de comisión
        /// </summary>
        /// <param name="codPrograma">Programas que dicta la empresa como inglés</param>
        /// <param name="codVendedor">Código del vendedor</param>
        /// <returns>DataTable</returns>
        public DataTable ListarContratosParaAdelantoComision(string codPrograma, string codVendedor, int nroAdelanto)
        {
            return comDAL.ListarContratosParaAdelantoComision(codPrograma, codVendedor, nroAdelanto);
        }

        /// <summary>
        /// Registra y actualiza registros de adelanto de comisiones
        /// </summary>
        /// <param name="toRegistrar">Objeto para registrar</param>
        /// <param name="toActualizar">Objeto para actualizar</param>
        /// <returns></returns>
        public bool GrabarAdelantoComision(List<ComisionAdelantoTo> toRegistrar, List<ComisionAdelantoTo> toActualizar)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!InsertarAdelantoComision(toRegistrar, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizaAdelantoComision(toActualizar, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public bool InsertarAdelantoComision(List<ComisionAdelantoTo> to, SqlConnection cn, SqlTransaction tr)
        {
            if (to == null)
                return true;
            foreach (ComisionAdelantoTo item in to)
            {
                if (!comDAL.InsertarAdelantoComision(item, cn, tr))
                    return false;
            }
            return true;
        }

        public bool ActualizaAdelantoComision(List<ComisionAdelantoTo> to, SqlConnection cn, SqlTransaction tr)
        {
            if (to == null)
                return true;
            foreach (ComisionAdelantoTo item in to)
            {
                if (!comDAL.ActualizarAdelantoComision(item, cn, tr))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Elimina un registro de adelanto comisión
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool EliminarAdelantoComision(ComisionAdelantoTo to)
        {
            return comDAL.EliminarAdelantoComision(to);
        }

        /// <summary>
        /// Cierra(es lo mismo que aprobar) un período de devolución de comisiones para que no se puedan modificar
        /// </summary>
        /// <param name="to">Objecto DevolucionComisionTTo dónde se pasa el periodo a cerrar</param>
        /// <returns></returns>
        public bool CerrarPeriodoAdelantoComision(DevolucionComisionTTo to)
        {
            return comDAL.CerrarPeriodoAdelantoComision(to);
        }

        /// <summary>
        /// Cierra(es lo mismo que aprobar) un período de devolución de comisiones para que no se puedan modificar
        /// </summary>
        /// <param name="to">Objecto DevolucionComisionTTo dónde se pasa el periodo a cerrar</param>
        /// <returns></returns>
        public bool AbrirPeriodoAdelantoComision(DevolucionComisionTTo to)
        {
            return comDAL.AbrirPeriodoAdelantoComision(to);
        }

        public bool CerrarPeriodoLiquidacion(LiquidacionTo to)
        {
            try
            {
                DataTable dt = comDAL.ObtenerPeriodoLiquidacion(to);
                if (dt == null || dt.Rows.Count == 0)
                {
                    if (!comDAL.InsertarPeriodoLiquidacion(to))
                        return false;
                }
                return comDAL.CerrarPeriodoLiquidacion(to);
            }
            catch
            {
                throw;
            }
        }

        public bool AbrirPeriodoLiquidacion(LiquidacionTo to)
        {
            return comDAL.AbrirPeriodoLiquidacion(to);
        }

        public DataTable ObtenerPeriodoLiquidacion(LiquidacionTo to)
        {
            return comDAL.ObtenerPeriodoLiquidacion(to);
        }

        public bool InsertarAsociarConceptoTesoreria(int idAsociar, string descripcion, int idConcepto, string usuarioCrea)
        {
            return comDAL.InsertarAsociarConceptoTesoreria(idAsociar, descripcion, idConcepto, usuarioCrea);
        }

        public bool ActualizarAsociarConceptoTesoreria(int idAsociar, string descripcion, string usuarioModifica)
        {
            return comDAL.ActualizarAsociarConceptoTesoreria(idAsociar, descripcion, usuarioModifica);
        }

        public bool EliminarAsociarConceptoTesoreria(int idAsociar)
        {
            return comDAL.EliminarAsociarConceptoTesoreria(idAsociar);
        }

        public bool EliminarAsociarConceptoTesoreria(int idAsociar, int idConcepto)
        {
            return comDAL.EliminarAsociarConceptoTesoreria(idAsociar, idConcepto);
        }

        public int ObtenerCorrelativoIdAsociar()
        {
            return comDAL.ObtenerCorrelativoIdAsociar();
        }

        public bool ValidarExistenciaAsociarConceptoTesoreria(int idAsociar)
        {
            return comDAL.ValidarExistenciaAsociarConceptoTesoreria(idAsociar);
        }

        public DataTable ListarAsociarConceptoTesoreria()
        {
            return comDAL.ListarAsociarConceptoTesoreria();
        }

        public DataTable ListarAsociarConceptoTesoreriaXIdAsociar(int idAsociar)
        {
            return comDAL.ListarAsociarConceptoTesoreriaXIdAsociar(idAsociar);
        }

        /// <summary>
        /// Lista de adelanto de comisiones de contratos que faltan aprobar
        /// </summary>
        /// <param name="to">Objeto ComisionAdelantoTo dónde se pasa los parámetors de filtro</param>
        /// <returns></returns>
        public DataTable RptAdelantoComisionContratosSinAprobar(ComisionAdelantoTo to)
        {
            return comDAL.RptAdelantoComisionContratosSinAprobar(to);
        }

        /// <summary>
        /// Generar una planilla de adelanto comisión para poder registrar en tesorería, 
        /// también se conciderea esto como un cierre, ya que no se podrá modificar después de esto
        /// </summary>
        /// <param name="toRegistrar"></param>
        /// <param name="toActualizar"></param>
        /// <returns></returns>
        public bool GrabarRAdelantoComision(RComisionAdelantoTo toRegistrar, List<RComisionAdelantoTo> toActualizar)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    if (!InsertarRAdelantoComision(toRegistrar, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    if (!ActualizarRAdelantoComision(toActualizar, cn, tr))
                    {
                        tr.Rollback();
                        return false;
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Inserta resumen adelanto comisión
        /// </summary>
        /// <param name="toRegistrar"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        private bool InsertarRAdelantoComision(RComisionAdelantoTo toRegistrar, SqlConnection cn, SqlTransaction tr)
        {
            if (toRegistrar == null)
                return true;
            serieDocumentosTo serieDoc = serieDAL.ObtenerCorrelativoDoc(new serieDocumentosTo
            { COD_SUCURSAL = COD_SUCURSAL, COD_DOC = COD_ADELANTO_COMISION, SERIE = SERIE_ADELNATO_COMISION },
                    cn, tr);
            if (serieDoc == null)
                return false;
            toRegistrar.NRO_PLANILLA_DOC = serieDoc.CORRELATIVO;
            toRegistrar.NRO_ENVIO = comDAL.ObtenerSiguienteNroEnvioXPersona(toRegistrar, cn, tr);
            if (!comDAL.InsertarRAdelantoComision(toRegistrar, cn, tr))
                return false;
            if (!comDAL.CerrarAdelantoComisionTo(toRegistrar, cn, tr))
                return false;
            if (!serieDAL.AdicionaNroSerieDAL(serieDoc, cn, tr))
                return false;
            return true;
        }

        /// <summary>
        /// Actualiar resumen adelanto comisión
        /// </summary>
        /// <param name="toRegistrar"></param>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        private bool ActualizarRAdelantoComision(List<RComisionAdelantoTo> toActualizar, SqlConnection cn, SqlTransaction tr)
        {
            if (toActualizar == null)
                return false;
            foreach (RComisionAdelantoTo item in toActualizar)
            {
                if (!comDAL.ActualizarRAdelantoComision(item, cn, tr))
                    return false;
                if (!ActualizaAdelantoComision(item.ComisionAdelantoTo, cn, tr))
                    return false;
                if (!comDAL.CerrarAdelantoComisionTo(item, cn, tr))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene el ultimo número de adelanto de comisión por persona y nivel, si en caso no existe retorna 0
        /// </summary>
        /// <returns></returns>
        public int ObtenerUltimoNroAdelanto(ComisionAdelantoTo to)
        {
            return comDAL.ObtenerUltimoNroAdelanto(to);
        }

        /// <summary>
        /// Obtiene una lista de grupo de número de adelantos de comisión por persona(vendedor)
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable ListaNroAdelantoComision(ComisionAdelantoTo to)
        {
            return comDAL.ListaNroAdelantoComision(to);
        }

        /// <summary>
        /// Obtiene el total de comisión, adelanto, saldo
        /// </summary>
        /// <param name="nroAdelanto">Nro de adelanto</param>
        /// <returns></returns>
        public DataTable ObtenerTotalesAdelantoComisionXNroAdelanto(int nroAdelanto)
        {
            return comDAL.ObtenerTotalesAdelantoComisionXNroAdelanto(nroAdelanto);
        }

        /// <summary>
        /// Obtiene vendedores que tienen nro de adelanto igual al pasado por parámetro [nroAdelanto]
        /// </summary>
        /// <param name="nroAdelanto">Número de adelanto</param>
        /// <returns></returns>
        public DataTable ObtenerVendedoresConNroAdelanto(int nroAdelanto)
        {
            return comDAL.ObtenerVendedoresConNroAdelanto(nroAdelanto);
        }

        /// <summary>
        /// Abre los adelantos de comisiones para ser modificados
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool AbrirAdelantoComision(List<ComisionAdelantoTo> lista)
        {
            using (SqlConnection cn = new SqlConnection(conexion.con))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    foreach (ComisionAdelantoTo item in lista)
                    {
                        if (!comDAL.AbrirComisionAdelanto(item, cn, tr))
                        {
                            tr.Rollback();
                            return false;
                        }
                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Obtiene Comisiones por contrato junto con sus adelantos para determinar cuanto comisión va recibir la persona
        /// </summary>
        /// <param name="feAñoPer"></param>
        /// <param name="feMesPer"></param>
        /// <param name="codPer"></param>
        /// <returns></returns>
        public DataTable RptComisionesDetalleXVendedor(string feAñoPer, string feMesPer, string codPer)
        {
            return comDAL.RptComisionesDetalleXVendedor(feAñoPer, feMesPer, codPer);
        }

        /// <summary>
        /// Obtiene Comisiones por contrato junto con sus adelantos para determinar cuanto comisión va recibir la persona
        /// </summary>
        /// <param name="feAñoPer"></param>
        /// <param name="feMesPer"></param>
        /// <param name="codPer"></param>
        /// <param name="codNivel"></param>
        /// <returns></returns>
        public DataTable RptComisionesDetalleXSuperior(string feAñoPer, string feMesPer, string codPer, string codNivel)
        {
            return comDAL.RptComisionesDetalleXSuperior(feAñoPer, feMesPer, codPer, codNivel);
        }

        /// <summary>
        /// Obtiene detalle de devoluciones de mercadería y descuentos de comisiones
        /// </summary>
        /// <param name="feAñoPer"></param>
        /// <param name="feMesPer"></param>
        /// <param name="codPer"></param>
        /// <returns></returns>
        public DataTable RptDevolucionDetalle(string feAñoPer, string feMesPer, string codPer, string codNivel)
        {
            return comDAL.RptDevolucionDetalle(feAñoPer, feMesPer, codPer, codNivel);
        }

        /// <summary>
        /// Obtiene un detalle de otros ingresos y egresos de vendedores
        /// </summary>
        /// <param name="codPer">Código del vendedor</param>
        /// <param name="feAñoPer">Año del periodo en la que se registró los movimientos</param>
        /// <param name="feMesPer">Mes del periodo en la que se registró los movimientos</param>
        /// <returns></returns>
        public DataTable RptOtrosCargosAbonosXVendedorDetalle(string codPer, string feAñoPer, string feMesPer)
        {
            return comDAL.RptOtrosCargosAbonosXVendedorDetalle(codPer, feAñoPer, feMesPer);
        }

        /// <summary>
        /// Obtiene el AÑO y MES en que se registró los movimientos del vendedor
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerPeriodosRegistradosOtrosIngresosEgresosVendedor()
        {
            return comDAL.ObtenerPeriodosRegistradosOtrosIngresosEgresosVendedor();
        }

        /// <summary>
        /// Obtiene contratos que no estan aprobados con o sin adelanto comisión
        /// </summary>
        /// <param name="codPrograma">Código del programa (inglés, etc.)</param>
        /// <param name="codVendedor">Código del vendedor</param>
        /// <param name="fechaContrato">fecha del contrato</param>
        /// <returns></returns>
        public DataTable RptContratosXGenerarYGeneradosAdelantoComision(string codPrograma, string codVendedor, DateTime fechaContrato)
        {
            return comDAL.RptContratosXGenerarYGeneradosAdelantoComision(codPrograma, codVendedor, fechaContrato);
        }

        public DataTable RptContratosXGenerarYGeneradosAdelantoComisionSoloVenedor(string codPrograma, string codVendedor, DateTime fechaContrato, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {
            return comDAL.RptContratosXGenerarYGeneradosAdelantoComisionSoloVenedor(codPrograma, codVendedor, fechaContrato, fechaAprobIni, fechaAprobFin);
        }
        /// <summary>
        /// Obtiene contratos que no estan aprobados por nivel venta(supervisor, director de ventas, director nacional)
        /// </summary>
        /// <param name="codPrograma">Código del programa (inglés, etc.)</param>
        /// <param name="codVendedor">Código del vendedor</param>
        /// <param name="fechaContrato">fecha del contrato</param>
        /// <returns></returns>
        public DataTable RptContratosXGenerarYGeneradosAdelantoComision(string codPrograma, string codPer, string codNivelVenta, DateTime fechaContrato)
        {
            return comDAL.RptContratosXGenerarYGeneradosAdelantoComision(codPrograma, codPer, codNivelVenta, fechaContrato);
        }
        public DataTable RptContratosXGenerarYGeneradosAdelantoComisionDirector(string codPrograma, string codPer, string codNivelVenta, DateTime fechaContrato, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {
            return comDAL.RptContratosXGenerarYGeneradosAdelantoComisionDirector(codPrograma, codPer, codNivelVenta, fechaContrato,  fechaAprobIni,  fechaAprobFin);
        }
        /// <summary>
        /// Obtiene contratos que estan pendientes por generar comisión menores o iguales a la [fechaAproba] de vendedores
        /// </summary>
        /// <param name="codPrograma"></param>
        /// <param name="codVendedor"></param>
        /// <param name="fechaAproba"></param>
        /// <returns></returns>
        public DataTable RptContratosPendientesGenerarComisionVendedor(string codPrograma, string codVendedor, DateTime fechaAproba)
        {
            return comDAL.RptContratosPendientesGenerarComisionVendedor(codPrograma, codVendedor, fechaAproba);
        }

        public DataTable RptContratosPendientesGenerarComisionSoloVendedor(string codPrograma, string codVendedor, DateTime fechaAproba, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {
            return comDAL.RptContratosPendientesGenerarComisionSoloVendedor(codPrograma, codVendedor, fechaAproba, fechaAprobIni, fechaAprobFin);
        }
        /// <summary>
        /// Obtiene contratos que estén pendietes por generar comisión menores o iguales a la fecha [fechaAprob] de nivel Venta(supervisor, director de ventas, director nacional)
        /// </summary>
        /// <param name="codPrograma"></param>
        /// <param name="codPer"></param>
        /// <param name="codNivelVenta"></param>
        /// <param name="fechaAproba"></param>
        /// <returns></returns>
        public DataTable RptContratosPendientesGenerarComisionSuperior(string codPrograma, string codPer, string codNivelVenta, DateTime fechaAproba)
        {
            return comDAL.RptContratosPendientesGenerarComisionSuperior(codPrograma, codPer, codNivelVenta, fechaAproba);
        }

        public DataTable RptContratosPendientesGenerarComisionSuperiorDirector(string codPrograma, string codPer, string codNivelVenta, DateTime fechaAproba, DateTime fechaAprobIni, DateTime fechaAprobFin)
        {
            return comDAL.RptContratosPendientesGenerarComisionSuperiorDirector(codPrograma, codPer, codNivelVenta, fechaAproba, fechaAprobIni, fechaAprobFin);
        }
    }
}
