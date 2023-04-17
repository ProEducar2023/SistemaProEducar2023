using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class inventariosBLL
    {
        inventariosDAL invDAL = new inventariosDAL();
        public DataTable obtenerInventariosBLL(inventariosTo invTo)
        {
            return invDAL.obtenerInventariosDAL(invTo);
        }

        public DataTable obtenerMostrar_Nota_Salida_BLL(inventariosTo invTo)
        {
            return invDAL.obtenerMostrar_Nota_Salida_DAL(invTo);
        }
        public bool adicionaInsertaInventariosBLL(inventariosTo invTo, DataTable dt, DataTable dt1, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona en Inventario Cabecera
                if (!insertarInventariosBLL(invTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool adicionaTransferenciaInventariosBLL(inventariosTo invTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona en Inventario Cabecera
                if (!transferirInventariosBLL(invTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificaTransferenciaInventariosBLL(inventariosTo invTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //modifica en Inventario Cabecera, falta esto
                if (!modificarTransferenciaInventariosBLL(invTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificaActualizaInventariosBLL(inventariosTo invTo, DataTable dt, DataTable dt1, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona en Inventario Cabecera
                if (!modificarInventariosBLL(invTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificaActualizaInventariosDevueltosBLL(inventariosTo invTo, DataTable dt, DataTable dtMov, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                DataTable dtArt = dt.Copy();
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona en Inventario Cabecera
                if (!modificarInventariosBLL(invTo, ref errMensaje))
                    return result = false;
                //
                if (invTo.COD_ALMACEN1 != invTo.COD_ALMACEN2)
                {
                    if (!intercambiarArticulosdeDiferentesAlmacenesBLL(invTo, dtArt, ref errMensaje))
                        return result = false;
                }
                //adiciona en ARTICULO_CONTENIDO_MOVIMIENTO
                if (!modificarArticuloMovimientoBLL(invTo, dtMov, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool intercambiarArticulosdeDiferentesAlmacenesBLL(inventariosTo invTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            mArticuloBLL marBLL = new mArticuloBLL();
            mArticuloTo marTo = new mArticuloTo();
            //almacen actual
            foreach (DataRow rw in dt.Rows)
            {
                marTo.COD_CLASE = invTo.COD_CLASE;
                marTo.COD_ALMACEN = invTo.COD_ALMACEN1;
                marTo.COD_ARTICULO = Convert.ToString(rw["COD_ARTICULO"]);
                marTo.SALDO_ACT = Convert.ToDecimal(rw["CANTIDAD"]);
                marTo.FECHA_DOC = DateTime.Now;
                if (!marBLL.restarSaldoxCambioAlmacenesBLL(marTo, ref errMensaje))
                    return result = false;
                //
                marTo.COD_ALMACEN = invTo.COD_ALMACEN2;
                if (!marBLL.adicionarSaldoxCambioAlmacenesBLL(marTo, ref errMensaje))
                    return result = false;
            }
            //almacen nuevo

            return result;
        }
        private bool modificarArticuloMovimientoBLL(inventariosTo invTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            if (!eliminarArticuloDevolucionContenidoMovimientoBLL(invTo, ref errMensaje))
                return result = false;
            if (!insertarArticuloMovimientoBLL(invTo, dt, ref errMensaje))
                return result = false;

            return result;
        }
        private bool modificarTransferenciaInventariosBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.modificarTransferenciaInventariosDAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarBulkCopyInvDetBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.insertarBulkCopyInvDetDAL(dt, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarBulkCopyArtSerieBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.insertarBulkCopyArtSerieDAL(dt, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarInventariosBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.insertarInventarioDAL(invTo, ref errMensaje))
                return result = true;
            return result;
        }
        public bool transferirInventariosBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.transferirInventarioDAL(invTo, ref errMensaje))
                return result = true;
            return result;
        }
        public bool modificarInventariosBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.modificarInventarioDAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VERIFICAR_DOC_INVENTARIOBLL(inventariosTo invTo, ref bool existe, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.VERIFICAR_DOC_INVENTARIODAL(invTo, ref existe, ref errMensaje))
                return result = true;
            return result;
        }
        public DataTable obtenerMostrar_Nota_Ingreso_DetalleBLL(inventariosTo invTo)
        {
            return invDAL.obtenerMostrar_Nota_Ingreso_DetalleDAL(invTo);
        }
        public DataTable obtenerMostrar_Nota_Ingreso_Detalle_OdevBLL(inventariosTo invTo)
        {
            return invDAL.obtenerMostrar_Nota_Ingreso_Detalle_OdevDAL(invTo);
        }
        public DataTable obtenerMostrar_Nota_Transferencia_DetalleBLL(inventariosTo invTo)
        {
            return invDAL.obtenerMostrar_Nota_Transferencia_DetalleDAL(invTo);
        }
        public bool VerificaDetalleBLL(inventariosTo invTo, ref bool flag2, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.VerificaDetalleDAL(invTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VERIFICAR_MOD_NOTA_INGRESO(inventariosTo invTo, ref string str7, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.VERIFICAR_MOD_NOTA_INGRESO(invTo, ref str7, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ELIMINA_NOTA_INGRESO(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.ELIMINA_NOTA_INGRESO(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ELIMINA_NOTA_TRANSFERENCIA(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.ELIMINA_NOTA_TRANSFERENCIA(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ANULA_NOTA_TRANSFERENCIA(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.ANULA_NOTA_TRANSFERENCIA(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ANULA_NOTA_INGRESO(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.ANULA_NOTA_INGRESO(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaSalidaInventarioBLL(inventariosTo invTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona en Inventario Cabecera
                if (!insertarInventariosSalidaBLL(invTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool modificaSalidaInventarioBLL(inventariosTo invTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //adiciona en Inventario Cabecera
                if (!modificarInventariosSalidaBLL(invTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool insertarInventariosSalidaBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.insertarInventarioSalidaDAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarInventariosSalidaBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.modificarInventarioSalidaDAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerInventariosSalidaDetalleBLL(inventariosTo invTo)
        {
            return invDAL.obtenerInventariosSalidaDetalleDAL(invTo);
        }
        public bool ELIMINAR_NOTA_SALIDA_BLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.ELIMINAR_NOTA_SALIDA_DAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ANULAR_NOTA_SALIDA_BLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.ANULAR_NOTA_SALIDA_DAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable Mostrar_Nota_TransferenciaBLL(inventariosTo invTo)
        {
            return invDAL.Mostrar_Nota_TransferenciaDAL(invTo);
        }
        public DataTable CARGAR_GUIA_DETALLES_PTE2_BLL(inventariosTo invTo)
        {
            return invDAL.CARGAR_GUIA_DETALLES_PTE2_DAL(invTo);
        }
        public DataTable CARGAR_GUIA_DETALLES_PTE3_BLL(inventariosTo invTo)
        {
            return invDAL.CARGAR_GUIA_DETALLES_PTE3_DAL(invTo);
        }
        public bool adicionaInsertaInventariosDevolucionBLL(inventariosTo invTo, DataTable dt, DataTable dtMov, inventariosTo inv02To, DataTable dt00, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                    return result = false;
                //graba en la tabla
                if (!insertarInventariosBLL(invTo, ref errMensaje))
                    return result = false;
                //actualiza en I_Pedido en el campo COD_REF para que desaparezca de los pendientes 
                if (!modificaActualizaIPedidoBLL(invTo, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_CONTENIDO_MOVIMIENTO
                if (!insertarArticuloMovimientoBLL(invTo, dtMov, ref errMensaje))
                    return result = false;
                //
                if (invTo.COD_REF != "01")
                {
                    //adiciona en Bulky para Inventario Detalle
                    if (!insertarBulkCopyInvDetBLL(dt00, ref errMensaje))
                        return result = false;
                    //adiciona en Inventario Cabecera
                    if (!transferirInventariosBLL(inv02To, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        public bool modificaInsertaInventariosDevolucionBLL(inventariosTo invTo, DataTable dt, DataTable dtMov, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona en Bulky para Inventario Detalle
                if (!insertarInventarioDetalleBLL(invTo, dt, ref errMensaje, "1"))
                    return result = false;
                ////graba en la tabla
                //if (!insertarInventariosBLL(invTo, ref errMensaje))
                //    return result = false;
                //actualiza en I_Pedido en el campo COD_REF para que desaparezca de los pendientes 
                if (!modificaActualizaIPedidoBLL(invTo, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_CONTENIDO_MOVIMIENTO
                if (!insertarArticuloMovimientoBLL(invTo, dtMov, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        private bool insertarInventarioDetalleBLL(inventariosTo invTo, DataTable dt, ref string errMensaje, string op = "0")
        {
            bool result = true;
            if (op == "1")
            {
                if (!invDAL.eliminaNotaIngresoDetalleDAL(invTo, ref errMensaje))
                    return result = false;
            }
            if (!insertarNotaIngresoDevolucionDetalleDAL(dt, ref errMensaje))
                return result = false;
            return result;
        }
        private bool insertarNotaIngresoDevolucionDetalleDAL(DataTable dt, ref string errMensaje)
        {
            bool result = true;

            //foreach(DataRow rw in dt.Rows)
            //{

            //    if (!invDAL.insertaNotaIngresoDevolucionDetalleDAL())
            //        return result = false;
            //}
            return result;
        }
        private bool insertarArticuloMovimientoBLL(inventariosTo invTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            articuloContenidoMovimientoBLL acmBLL = new articuloContenidoMovimientoBLL();
            articuloContenidoMovimientoTo acmTo = new articuloContenidoMovimientoTo();
            foreach (DataRow rw in dt.Rows)
            {
                acmTo.NRO_NOTA_ING = invTo.NRO_DOC_INV;
                acmTo.COD_ARTICULO = rw["COD_ARTICULO"].ToString();
                acmTo.COD_ART_CONTENIDO = rw["COD_ART_CONTENIDO"].ToString();
                acmTo.CANTIDAD = Convert.ToInt32(rw["CANTIDAD"]);
                acmTo.SITUACION = rw["SITUACION"].ToString();
                acmTo.COD_USU_CREA = invTo.COD_USU;
                acmTo.FECHA_CREA = invTo.FECHA;
                if (!acmBLL.insertarArticuloContenidoMovimientoBLL(acmTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        private bool eliminarArticuloDevolucionContenidoMovimientoBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            articuloContenidoMovimientoBLL acmBLL = new articuloContenidoMovimientoBLL();
            articuloContenidoMovimientoTo acmTo = new articuloContenidoMovimientoTo();
            acmTo.NRO_NOTA_ING = invTo.NRO_DOC_INV;
            if (!acmBLL.eliminarArticuloDevolucionContenidoMovimientoDAL(acmTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificaActualizaIPedidoBLL(inventariosTo invTo, ref string errMensaje)
        {
            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
            contratoCabeceraTo ccTo = new contratoCabeceraTo();
            bool result = true;
            //ccTo.COD_REF = "1";
            ccTo.COD_SUCURSAL = invTo.COD_SUCURSAL;
            //ccTo.NRO_DOC = invTo.NRO_DOC_VTA;
            ccTo.COD_PER = invTo.COD_PER;
            ccTo.COD_CLASE = invTo.COD_CLASE;
            ccTo.FE_AÑO = invTo.FE_AÑO2;
            ccTo.FE_MES = invTo.FE_MES2;
            ccTo.NRO_FAC_PRE_UNI = invTo.NRO_FAC_PRE_UNI == "" ? null : invTo.NRO_FAC_PRE_UNI;
            ccTo.NRO_PRESUPUESTO = invTo.NRO_PEDIDO == "" ? null : invTo.NRO_PEDIDO;// aqui se guarda el valor de nro de contrato
            if (!ccBLL.modificaActualizaIPedidoporDevolucionBLL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerDetalleparaCostoTransferenciaBLL(inventariosTo invTo)
        {
            return invDAL.obtenerDetalleparaCostoTransferenciaDAL(invTo);
        }
        public DataTable obtenerDetalleparaCostoTransferencia2BLL(inventariosTo invTo)
        {
            return invDAL.obtenerDetalleparaCostoTransferencia2DAL(invTo);
        }
        public DataTable obtenerDetallesCostosBLL(inventariosTo invTo)
        {
            return invDAL.obtenerDetallesCostosDAL(invTo);
        }
        public bool TRANSFERIR_COSTOS(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.TRANSFERIR_COSTOS(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        //esto es para Inventarios Detalle, pero esa clase no existe, por eso la hago aqui
        public bool ACTUALIZAR_INVENTARIOS_DETALLE_BLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.ACTUALIZAR_INVENTARIOS_DETALLE_DAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaInventarioSaldoInicialBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.modificaInventarioSaldoInicialDAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaDesInventarioSaldoInicialBLL(inventariosTo invTo, ref string errMensaje)
        {
            bool result = true;
            if (!invDAL.modificaDesInventarioSaldoInicialDAL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerReporteKardexInventarioHistoricoBLL(inventariosTo invTo)
        {
            return invDAL.obtenerReporteKardexInventarioHistoricoDAL(invTo);
        }
        public DataTable obetenerReporteHistorialPrecioVentaBLL(inventariosTo invTo)
        {
            return invDAL.obetenerReporteHistorialPrecioVentaDAL(invTo);
        }
        public DataTable obtenerReporteDevolucionMercaderiaBLL(inventariosTo invTo)
        {
            return invDAL.obtenerReporteDevolucionMercaderiaDAL(invTo);
        }
        public string obtenerNroDocInventarioBLL(string nro_contrato)
        {
            return invDAL.obtenerNroDocInventarioDAL(nro_contrato);
        }
    }
}
