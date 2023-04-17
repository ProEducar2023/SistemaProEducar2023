using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class canjeICtasxCobrarDAL
    {
        SqlConnection conn;
        public canjeICtasxCobrarDAL()
        {
            conn = new SqlConnection(conexion.con);
        }
        public DataTable obtenerCanjeICtasxCobrarDAL(canjeICtasxCobrarTo cicxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CANJE_DOC_CXC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cicxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cicxTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_USU", cicxTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", cicxTo.COD_USU);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable obtenerCanjeICtasxCobrarxBloqueDAL(canjeICtasxCobrarTo cicxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("MOSTRAR_CANJE_DOC_CXC_X_BLOQUE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FE_AÑO", cicxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cicxTo.FE_MES);
            cmd.Parameters.AddWithValue("@TIPO_USU", cicxTo.TIPO_USU);
            cmd.Parameters.AddWithValue("@COD_USU", cicxTo.COD_USU);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool insertarCanjeICtasxCobrarDAL(canjeICtasxCobrarTo icxcTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("INSERTAR_CANJE_I_CTAS_X_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", icxcTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", icxcTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", icxcTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", icxcTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", icxcTo.FE_MES);
            cmd.Parameters.AddWithValue("@FECHA_CONTRATO", icxcTo.FECHA_CONTRATO);
            if (icxcTo.FECHA_APROBACION == null)
                cmd.Parameters.AddWithValue("@FECHA_APROBACION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_APROBACION", icxcTo.FECHA_APROBACION);
            cmd.Parameters.AddWithValue("@NRO_REPORTE", icxcTo.NRO_REPORTE);
            cmd.Parameters.AddWithValue("@FECHA_REPORTE", icxcTo.FECHA_REPORTE);
            cmd.Parameters.AddWithValue("@COD_MONEDA", icxcTo.COD_MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", icxcTo.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@IMP_DOC", icxcTo.IMP_DOC);
            cmd.Parameters.AddWithValue("@OBSERVACION", icxcTo.OBSERVACION);
            cmd.Parameters.AddWithValue("@TIPO_OPE", icxcTo.TIPO_OPE);
            cmd.Parameters.AddWithValue("@COD_PER", icxcTo.COD_PER);
            cmd.Parameters.AddWithValue("@NRO_CUOTAS", icxcTo.NRO_CUOTAS);
            cmd.Parameters.AddWithValue("@IMP_DEVOLUCION", icxcTo.IMP_DEVOLUCION);
            if (icxcTo.FECHA_DEVOLUCION == null)
                cmd.Parameters.AddWithValue("@FECHA_DEVOLUCION", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@FECHA_DEVOLUCION", icxcTo.FECHA_DEVOLUCION);
            cmd.Parameters.AddWithValue("@COD_VENDEDOR", icxcTo.COD_VENDEDOR);
            cmd.Parameters.AddWithValue("@COD_NIVEL1", icxcTo.COD_NIVEL1);
            cmd.Parameters.AddWithValue("@COD_NIVEL2", icxcTo.COD_NIVEL2);
            cmd.Parameters.AddWithValue("@COD_NIVEL3", icxcTo.COD_NIVEL3);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", icxcTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_USU_CREA", icxcTo.COD_USU_CREA);
            //cmd.Parameters.AddWithValue("@COD_USU_MOD", icxcTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_CREA", icxcTo.FECHA_CREA);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", icxcTo.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_TIPO_VENTA", icxcTo.COD_TIPO_VENTA);
            cmd.Parameters.AddWithValue("@COD_MODALIDAD_VTA", icxcTo.COD_MODALIDAD_VTA);
            cmd.Parameters.AddWithValue("@STATUS_PRE_APROB", icxcTo.STATUS_PRE_APROB);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool ELIMINAR_I_CTAS_COBRAR_CANJE_DAL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINAR_I_CTAS_COBRAR_CANJE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cicxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@FE_AÑO", cicxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cicxTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_USU", cicxTo.COD_USU);
            cmd.Parameters.AddWithValue("@COD_PER", cicxTo.COD_PER);
            cmd.Parameters.AddWithValue("@FECHA", cicxTo.FECHA_MOD);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool Aprueba_Actualiza_Repciona_I_Planilla_I_CTAS_COBRAR_DAL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_I_CTAS_COBRAR_POR_APROBAR_RECEPCION_COBRANZA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cicxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@COD_CLASE", cicxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@FE_AÑO", cicxTo.FE_AÑO);
            cmd.Parameters.AddWithValue("@FE_MES", cicxTo.FE_MES);
            cmd.Parameters.AddWithValue("@COD_SECTORISTA", cicxTo.COD_SECTORISTA);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", cicxTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", cicxTo.FECHA_MOD);
            cmd.Parameters.AddWithValue("@IMP_DOC_ACUMULADO", cicxTo.IMP_DOC);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool actualizaICtasCobrarxCobranzaDirectaDAL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICA_I_CTAS_COBRAR_X_COBRANZA_DIRECTA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cicxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", cicxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            cmd.Parameters.AddWithValue("@STATUS_TRANSF_DIRECTA", cicxTo.STATUS_TRANSF_DIRECTA);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool VerificaExisteNroContratoEnviadoDAL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICAR_ELIMINAR_CUENTA_CORRIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public DataTable ConsultaEstadoCuentaKardexClienteDAL(canjeICtasxCobrarTo cicxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable ConsultaEstadoCuentaKardexClienteDetalleDAL(canjeICtasxCobrarTo cicxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE_DETALLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable obtenerCuotasComprometidasxContratoDAL(canjeICtasxCobrarTo cicxTo)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("CONSULTA_ESTADO_CUENTA_KARDEX_CLIENTE_CUOTAS_COMPROMETIDAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool modificarICtasxCambioPtoCobDAL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("MODIFICAR_ICTAS_COBRAR_X_CAMBIO_PTO_COB", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_PER", cicxTo.COD_PER);
            cmd.Parameters.AddWithValue("@COD_PTO_COB", cicxTo.COD_PTO_COB);
            cmd.Parameters.AddWithValue("@COD_USU_MOD", cicxTo.COD_USU_MOD);
            cmd.Parameters.AddWithValue("@FECHA_MOD", cicxTo.FECHA_MOD);
            try
            {
                conn.Open();
                cmd.ExecuteScalar();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool eliminarICtasCobrarDAL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("ELIMINA_ICTAS_COBRAR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cicxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", cicxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                cmd.ExecuteScalar();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        public bool verifica_Movimiento_ContratoDAL(canjeICtasxCobrarTo cicxTo, ref string errMensaje)
        {
            bool flag = false;
            SqlCommand cmd = new SqlCommand("VERIFICA_MOVIMIENTO_CONTRATO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_SUCURSAL", cicxTo.COD_SUCURSAL);
            cmd.Parameters.AddWithValue("@COD_CLASE", cicxTo.COD_CLASE);
            cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            try
            {
                conn.Open();
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                flag = false;
                errMensaje = e.Message;
            }
            finally
            {
                conn.Close();
            }
            return flag;
            ///////////////////////////

            //bool flag = false;
            //SqlCommand cmd = new SqlCommand("VERIFICA_MOVIMIENTO_CONTRATO", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@COD_SUCURSAL", cicxTo.COD_SUCURSAL);
            //cmd.Parameters.AddWithValue("@COD_CLASE", cicxTo.COD_CLASE);
            //cmd.Parameters.AddWithValue("@NRO_CONTRATO", cicxTo.NRO_CONTRATO);
            //try
            //{
            //    conn.Open();
            //    cmd.ExecuteScalar();
            //    flag = true;
            //}
            //catch (Exception e)
            //{
            //    flag = false;
            //    errMensaje = e.Message;
            //}
            //finally
            //{
            //    conn.Close();
            //}
            //return flag;
        }

        public DataTable RptCuentasXCobrarC6(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codInstitucion, string subNivelInstitucion, int act)
        {
            string procedure;
            switch (act)
            {
                case 0:
                    procedure = "usp_RptCuentasXCobrarC6";
                    break;
                case 1:
                    procedure = "usp_RptCuentasXCobrarC6_1";
                    break;
                case 2:
                    procedure = "usp_RptCuentasXCobrarC6_2";
                    break;
                case 3:
                    procedure = "usp_RptCuentasXCobrarXInstitucionDetalle";
                    break;
                default:
                    throw new ArgumentNullException();
            }
            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.CommandTimeout = 7000;

                cmd.Parameters.AddWithValue("@FECHA_VENTA_INI", fechaVentaIni);
                cmd.Parameters.AddWithValue("@FECHA_VENTA_FIN", fechaVentaFin);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobacionIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobacionFin);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INI", fechaVencimientoIni);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_FIN", fechaVencimientoFin);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                if (act != 1)
                    cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", subNivelInstitucion);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable RptCuentasXCobrarMesXPuntoCobranza(string codPrograma, DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobIni, DateTime fechaAproFin,
            DateTime fechaVenIni, DateTime fechaVenFin, string codPtoCob, int act)
        {
            try
            {
                string procedure;
                switch (act)
                {
                    case 0:
                        procedure = "usp_RptCuentasXCobrarXMesXPCobranza";
                        break;
                    case 1:
                        procedure = "usp_RptCuentasXCobrarPCobranza";
                        break;
                    case 2:
                        procedure = "usp_RptCuentasXCobrarXPCobranzaDet";
                        break;
                    default:
                        throw new ArgumentNullException();
                }
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FECHA_VENTA_INI", fechaVentaIni);
                cmd.Parameters.AddWithValue("@FECHA_VENTA_FIN", fechaVentaFin);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAproFin);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INI", fechaVenIni);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_FIN", fechaVenFin);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable RptCuentasXCobrarC4(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
                DateTime fechaVencimientoFin, string codPrograma, string codCategoria, string codPer, int act)
        {
            try
            {
                string procedure;
                switch (act)
                {
                    case 0:
                        procedure = "usp_RptCuentasXCobrarC4";
                        break;
                    case 1:
                        procedure = "usp_RptCuentasXCobrarC4_2";
                        break;
                    case 2:
                        procedure = "usp_RptCuentasXCobrarXNivelVentaDet";
                        break;
                    default:
                        throw new ArgumentNullException();
                }

                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.CommandTimeout = 5000;

                cmd.Parameters.AddWithValue("@FECHA_VENTA_INI", fechaVentaIni);
                cmd.Parameters.AddWithValue("@FECHA_VENTA_FIN", fechaVentaFin);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobacionIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobacionFin);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INI", fechaVencimientoIni);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_FIN", fechaVencimientoFin);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_CATEGORIA", codCategoria);
                cmd.Parameters.AddWithValue("@COD_PER", codPer);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable RptCuentasXCobrarC5(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
        DateTime fechaVencimientoFin, string codPrograma, string codUbicacion, string codGrupoUbicacion, string codSubUbicacion, int act)
        {
            try
            {
                string procedure;
                switch (act)
                {
                    case 0:
                        procedure = "usp_RptCuentasXCobrarC5";
                        break;
                    case 1:
                        procedure = "usp_RptCuentasXCobrarC5_2";
                        break;
                    case 2:
                        procedure = "usp_RptCuentasXCobrarXUbicacionDet";
                        break;
                    default:
                        throw new ArgumentNullException();
                }

                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FECHA_VENTA_INI", fechaVentaIni);
                cmd.Parameters.AddWithValue("@FECHA_VENTA_FIN", fechaVentaFin);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobacionIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobacionFin);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INI", fechaVencimientoIni);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_FIN", fechaVencimientoFin);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_UBICACION", codUbicacion);
                cmd.Parameters.AddWithValue("@COD_GRUPO_UBICACION", codGrupoUbicacion);
                cmd.Parameters.AddWithValue("@COD_SUB_UBICACION", codSubUbicacion);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable RptCuentasXCobrarC8(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codPtoCob, string codUbicacion, int act)
        {
            string procedure;
            switch (act)
            {
                case 1:
                    procedure = "usp_RptCuentasXCobrarXMesXPCobranzaUbicacion";
                    break;
                case 2:
                    procedure = "usp_RptCuentasXCobrarXMesXPCobranzaUbicacionDet";
                    break;
                default: throw new ArgumentNullException();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FECHA_VENTA_INI", fechaVentaIni);
                cmd.Parameters.AddWithValue("@FECHA_VENTA_FIN", fechaVentaFin);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobacionIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobacionFin);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INI", fechaVencimientoIni);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_FIN", fechaVencimientoFin);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_PTO_COB", codPtoCob);
                cmd.Parameters.AddWithValue("@COD_UBICACION", codUbicacion);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable RptCuentasXCobrarC7_1(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
        DateTime fechaVencimientoFin, string codPrograma, string codDepartamento, string cod_pto_cob, int act)
        {
            string procedure;
            switch (act)
            {
                case 0:
                    procedure = "usp_RptCuentasXCobrarC7_1";
                    break;
                case 1:
                    procedure = "usp_RptCuentasXCobrarXDepartamentoDetalle";
                    break;
                default: throw new ArgumentNullException();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FECHA_VENTA_INI", fechaVentaIni);
                cmd.Parameters.AddWithValue("@FECHA_VENTA_FIN", fechaVentaFin);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobacionIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobacionFin);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INI", fechaVencimientoIni);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_FIN", fechaVencimientoFin);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_DEPARTAMENTO", codDepartamento);
                cmd.Parameters.AddWithValue("@COD_PTO_COB", cod_pto_cob);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable RptCuentasXCobrarC7(DateTime fechaVentaIni, DateTime fechaVentaFin, DateTime fechaAprobacionIni, DateTime fechaAprobacionFin, DateTime fechaVencimientoIni,
            DateTime fechaVencimientoFin, string codPrograma, string codDepartamento, string codInstitucion, string codNivelInst, int act)
        {
            string procedure;
            switch (act)
            {
                case 0:
                    procedure = "usp_RptCuentasXCobrarC7";
                    break;
                default: throw new ArgumentNullException();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FECHA_VENTA_INI", fechaVentaIni);
                cmd.Parameters.AddWithValue("@FECHA_VENTA_FIN", fechaVentaFin);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_INI", fechaAprobacionIni);
                cmd.Parameters.AddWithValue("@FECHA_APROBACION_FIN", fechaAprobacionFin);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_INI", fechaVencimientoIni);
                cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO_FIN", fechaVencimientoFin);
                cmd.Parameters.AddWithValue("@COD_PROGRAMA", codPrograma);
                cmd.Parameters.AddWithValue("@COD_DEPARTAMENTO", codDepartamento);
                cmd.Parameters.AddWithValue("@COD_INSTITUCION", codInstitucion);
                cmd.Parameters.AddWithValue("@COD_NIVEL_INSTITUCION", codNivelInst);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr, LoadOption.Upsert);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
