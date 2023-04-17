using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class contratoCabeceraBLL
    {
        contratoCabeceraDAL ccDAL = new contratoCabeceraDAL();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        public DataTable obtenerContratoBLL()
        {
            return ccDAL.obtenerContratoDAL();
        }
        public bool insertarContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.insertarContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarContratoDAL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaInsertaContratoBLL(contratoCabeceraTo ccTo, DataTable DT00, DataTable DT01, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //bulkcopy de T_PEDIDO2
                if (!insertarBulkCopyPedDetBLL(DT00, ref errMensaje))
                    return result = false;
                //adiciona en Pedido Cabecera
                if (!insertarContratoBLL(ccTo, ref errMensaje))
                    return result = false;
                //bulkcopy de INVENTARIO_DETALLE2
                if (!insertarBulkCopyInventarioDetalleBLL(DT01, ref errMensaje))
                    return result = false;
                //adiciona en Inventarios Cabecera
                if (!insertarInventarioBLL(ccTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }

        }
        public bool insertarInventarioBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            invTo.COD_SUCURSAL = ccTo.COD_SUCURSAL;
            invTo.COD_CLASE = ccTo.COD_CLASE;
            invTo.COD_PER = ccTo.COD_PER;
            invTo.COD_CLASE_PER = "1";
            invTo.NRO_DOC_PER = "";
            invTo.COD_DOC_INV = "02";//02 salida , 01 ingreso
            invTo.NRO_DOC_INV = ccTo.NRO_DOC_INV;
            invTo.SERIE = ccTo.NRO_DOC_INV.Substring(0, 3);//falta la serie
            invTo.NUMERO = ccTo.NRO_DOC_INV.Substring(4, 7);
            invTo.FE_AÑO = ccTo.FE_AÑO;
            invTo.FE_MES = ccTo.FE_MES;
            invTo.COD_MOV = "002";
            invTo.COD_MONEDA = "S";
            invTo.FECHA_DOC_INV = Convert.ToDateTime(ccTo.FECHA_APROB);//ccTo.FECHA_DOC;
            invTo.FECHA_DOC = null;
            invTo.COD_DOC = "";
            invTo.NRO_DOC = "";
            invTo.OBSERVACION = "Salida por creacion de Contrato";
            invTo.TIPO_CAMBIO = ccTo.TIPO_CAMBIO;
            invTo.STATUS_PV = "";
            invTo.COD_USU = ccTo.COD_USU;
            invTo.FECHA = DateTime.Now;
            invTo.NOMBRE_PC = ccTo.NOMBRE_PC;
            invTo.COD_ELABORADO = ccTo.COD_PER_ELAB;
            invTo.FECHA_CREA = DateTime.Now;
            invTo.AREA = "";
            invTo.NRO_PEDIDO = ccTo.NRO_PRESUPUESTO; //se ingresa el numero de contrato para identificar la salida con el contrato
            if (!invBLL.insertarInventariosSalidaBLL(invTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarBulkCopyInventarioDetalleBLL(DataTable dt, ref string errMensaje)
        {

            bool result = true;
            if (!invBLL.insertarBulkCopyInvDetBLL(dt, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaInsertaContratoOrdDevVtasBLL(contratoCabeceraTo ccTo, DataTable DT00, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;

                if (!insertarBulkCopyPedDetBLL(DT00, ref errMensaje))
                    return result = false;
                //adiciona en Pedido Cabecera
                if (!insertarContratoOrdDevVtasBLL(ccTo, ref errMensaje))
                    return result = false;
                //
                if (ccTo.TIPO_ORIGEN == "F" || ccTo.TIPO_ORIGEN == "B")//solo si es una devolucion proveniente de una factura se empleará este método, si es un devolución proveniente de un contrato, o sea si no se ha facturado.
                {
                    //actualiza el campo status_dev, lo establece en 1 para que ya no se vean las facturas a las que se le puede hacer orden de devolucion
                    if (!actualizaFacturacionOrdDevVtasBLL(ccTo, ref errMensaje))
                        return result = false;
                }
                else if (ccTo.TIPO_ORIGEN == "C")
                {
                    //actualiza en el campo NRO_FAC_PRE_UNI para que no se vuelva a ver en los contratos que ya aparecieron
                    if (!actualizaIPedidoporOrdenDevolucionBLL(ccTo, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }

        }
        private bool actualizaIPedidoporOrdenDevolucionBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.actualizaIPedidoporOrdenDevolucionDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaFacturacionOrdDevVtasBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            facturacionVtaCabeceraBLL fccBLL = new facturacionVtaCabeceraBLL();
            facturacionVtaCabeceraTo fccTo = new facturacionVtaCabeceraTo();
            fccTo.COD_SUCURSAL = ccTo.COD_SUCURSAL;
            fccTo.NRO_DOC = ccTo.NRO_FAC_PRE_UNI;
            fccTo.COD_PER = ccTo.COD_PER;
            fccTo.COD_CLASE = ccTo.COD_CLASE;
            fccTo.FE_AÑO = ccTo.AÑO_DOC;
            fccTo.FE_MES = ccTo.MES_DOC;
            if (!fccBLL.modificarActualizaFacturacionOrdDevVtaBLL(fccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarContratoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.insertarContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarContratoDirectoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarContratoDirectoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }

        public bool insertarContratoOrdDevVtasBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.insertarContratoOrdDevVtasDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarBulkCopyPedDetBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.insertarBulkCopyPedDetDAL(dt, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarContratoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaPreContratoStatusCierreBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            precontratoCabeceraBLL pccBLL = new precontratoCabeceraBLL();
            precontratoCabeceraTo pccTo = new precontratoCabeceraTo();
            pccTo.COD_SUCURSAL = ccTo.COD_SUCURSAL;
            pccTo.NRO_PRESUPUESTO = ccTo.NRO_PRESUPUESTO;
            pccTo.COD_PER = ccTo.COD_PER;
            pccTo.COD_CLASE = ccTo.COD_CLASE;
            pccTo.FE_AÑO = ccTo.FE_AÑO;
            pccTo.FE_MES = ccTo.FE_MES;
            if (!pccBLL.actualizaPreContratoStatusCierreBLL(pccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratoCabeceraBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratoCabeceraDAL(ccTo);
        }
        public DataTable obtenerContratoCabecera_para_Fact_Elect_BLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratoCabecera_para_Fact_Elect_DAL(ccTo);
        }
        public bool insertarContratoDetalleBLL(contratoCabeceraTo ccTo, DataTable dt, ref string errMensaje)
        {
            contratoDetalleBLL dccBLL = new contratoDetalleBLL();
            contratoDetalleTo dccTo = new contratoDetalleTo();
            bool result = true;
            int i = 1;
            foreach (DataRow rw in dt.Rows)
            {
                dccTo.COD_SUCURSAL = ccTo.COD_SUCURSAL;
                dccTo.NRO_DOC = ccTo.NRO_DOC;
                dccTo.COD_PER = ccTo.COD_PER;
                dccTo.COD_CLASE = ccTo.COD_CLASE;
                dccTo.FE_AÑO = ccTo.FE_AÑO;
                dccTo.FE_MES = ccTo.FE_MES;
                dccTo.ITEM = i.ToString("00");
                dccTo.COD_ARTICULO = rw[1].ToString();
                dccTo.CANTIDAD_PED = Convert.ToDecimal(rw[3]);
                dccTo.CANTIDAD_ATEN = Convert.ToDecimal(rw[4]);
                dccTo.CANTIDAD_ANUL = Convert.ToDecimal(rw[5]);
                dccTo.PRECIO_UNIT = Convert.ToDecimal(rw[6]);
                dccTo.VALOR_COMPRA = Convert.ToDecimal(rw[7]);
                dccTo.POR_IGV = Convert.ToDecimal(rw[8]);
                dccTo.POR_DSCTO = Convert.ToDecimal(rw[9]);
                dccTo.STATUS_IGV = rw[10].ToString();
                dccTo.VALOR_IGV = Convert.ToDecimal(rw[11]);
                dccTo.VALOR_DSCTO = Convert.ToDecimal(rw[12]);
                dccTo.AJUSTE_IGV = Convert.ToDecimal(rw[13]);
                dccTo.AJUSTE_BI = Convert.ToDecimal(rw[14]);
                dccTo.COD_D_H = rw[15].ToString();
                dccTo.OBSERVACION = rw[16].ToString();
                dccTo.NRO_PRESUPUESTO = ccTo.NRO_PRESUPUESTO;
                dccTo.NRO_ITEM = rw[0].ToString();
                dccTo.COD_CONDICION = "";
                dccTo.DESC_ARTICULO = rw[2].ToString();
                dccTo.TIPO_PRECIO = "";

                if (!dccBLL.insertarContratoDetalleBLL(dccTo, ref errMensaje))
                    return result = false;
                i++;
            }
            return result;
        }
        public bool ELIMINAR_PEDIDO_PRESUPUESTO_BLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina contrato de I_Pedido
                if (!ccDAL.ELIMINAR_PEDIDO_PRESUPUESTO_DAL(ccTo, ref errMensaje))
                    return result = false;
                //elimina salida de almacen
                invTo.COD_SUCURSAL = ccTo.COD_SUCURSAL;
                invTo.COD_CLASE = ccTo.COD_CLASE;
                invTo.COD_PER = ccTo.COD_PER;
                invTo.COD_DOC_INV = "02";
                invTo.NRO_DOC_INV = ccTo.NRO_DOC_INV;
                invTo.FE_AÑO = ccTo.FE_AÑO;
                invTo.FE_MES = ccTo.FE_MES;
                if (!invBLL.ELIMINAR_NOTA_SALIDA_BLL(invTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool modificaApruebaContratoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificaApruebaContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaPreApruebaContratoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificaPreApruebaContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VALIDAR_DESAPROBAR_CONTRATOBLL(contratoCabeceraTo ccTo, ref bool flag2, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.VALIDAR_DESAPROBAR_CONTRATODAL(ccTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }
        public bool VALIDAR_DESPREAPROBAR_CONTRATOBLL(contratoCabeceraTo ccTo, ref bool flag2, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.VALIDAR_DESPREAPROBAR_CONTRATODAL(ccTo, ref flag2, ref errMensaje))
                return result = false;
            return result;
        }
        public bool DESAPROBAR_PEDIDOBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.DESAPROBAR_PEDIDODAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool DESPREAPROBAR_PEDIDOBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.DESPREAPROBAR_PEDIDODAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool cerrarContratoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.cerrarContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool actualizaPedido_Status_Cta_BLL(string COD_SUCURSAL, string NRO_PRESUPUESTO, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.actualizaPedido_Status_Cta_DAL(COD_SUCURSAL, NRO_PRESUPUESTO, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratosparaFacturacionBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratosparaFacturacionDAL(ccTo);
        }
        public DataTable obtenerContratosDevolucionparaFacturacionBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratosDevolucionparaFacturacionDAL(ccTo);
        }
        public DataTable obtenerContratosparaFacturacion3BLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratosparaFacturacion3DAL(ccTo);
        }
        public DataTable MOSTRAR_ORD_DEV_VTA_BLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.MOSTRAR_ORD_DEV_VTA_DAL(ccTo);
        }
        public DataTable obtenerOrdenDevVentasPendientesBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerOrdenDevVentasPendientesDAL(ccTo);
        }
        public DataTable obtenerObsequiosDevolucionparaFacturacionBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerObsequiosDevolucionparaFacturacionDAL(ccTo);
        }
        public bool modificaApruebaOrdDevVtasBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificaApruebaOrdDevVtasDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaActualizaIPedidoporDevolucionBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificaActualizaIPedidoporDevolucionDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerFacturacionCabeceraparaConsultaOrdDevFactporContratoBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerFacturacionCabeceraparaConsultaOrdDevFactporContratoDAL(ccTo);
        }
        public DataTable obtenerContratoCabeceraparaComisionesBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratoCabeceraparaComisionesDAL(ccTo);
        }
        public DataTable obtenerContratoCabeceraparaDevolucionesBLL()
        {
            return ccDAL.obtenerContratoCabeceraparaDevolucionesDAL();
        }
        public DataTable obtenerContratoCabeceraparaComisionesxNroContratoBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratoCabeceraparaComisionesxNroContratoDAL(ccTo);
        }
        public DataTable obtenerDatosdeContratoBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerDatosdeContratoDAL(ccTo);
        }
        public bool modificarIPedidoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarIPedidoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificar_IPedido_por_NroContratoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificar_IPedido_por_NroContratoDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarIPedidoxLiqComisionBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarIPedidoxLiqComisionDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarIPedidoxGeneracionDevolucionBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarIPedidoxGeneracionDevolucionDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarIPedidoxDevolucionGeneradaBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarIPedidoxDevolucionGeneradaDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool adicionaInsertaContrato_dbf_BLL(contratoCabeceraTo ccTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cabecera
                if (!insertarContratoBLL(ccTo, ref errMensaje))
                    return result = false;
                //detalle
                if (!insertarContratoDetalle_dbf_BLL(ccTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool insertarContratoDetalle_dbf_BLL(contratoCabeceraTo ccTo, DataTable dt, ref string errMensaje)
        {
            contratoDetalleBLL dccBLL = new contratoDetalleBLL();
            contratoDetalleTo dccTo = new contratoDetalleTo();
            bool result = true;
            int i = 1;
            foreach (DataRow rw in dt.Rows)
            {
                dccTo.COD_SUCURSAL = ccTo.COD_SUCURSAL;
                dccTo.NRO_DOC = ccTo.NRO_DOC;
                dccTo.COD_PER = ccTo.COD_PER;
                dccTo.COD_CLASE = ccTo.COD_CLASE;
                dccTo.FE_AÑO = ccTo.FE_AÑO;
                dccTo.FE_MES = ccTo.FE_MES;
                dccTo.ITEM = i.ToString("00");
                dccTo.COD_ARTICULO = rw["CDART"].ToString();
                dccTo.CANTIDAD_PED = Convert.ToDecimal(rw["CADOC"]);
                dccTo.CANTIDAD_ATEN = 0;
                dccTo.CANTIDAD_ANUL = 0;
                dccTo.PRECIO_UNIT = Convert.ToDecimal(rw["PRVAC"]);
                dccTo.VALOR_COMPRA = Convert.ToDecimal(rw["VANET"]);
                dccTo.POR_IGV = Convert.ToDecimal(rw["POIGV"]);
                dccTo.POR_DSCTO = Convert.ToDecimal(rw["PODES"]);
                dccTo.STATUS_IGV = rw["ST_IGV"].ToString();//"0";
                dccTo.VALOR_IGV = Convert.ToDecimal(rw["VAIGV"]);
                dccTo.VALOR_DSCTO = Convert.ToDecimal(rw["VADES"]);
                dccTo.AJUSTE_IGV = 0;
                dccTo.AJUSTE_BI = 0;
                dccTo.COD_D_H = rw["CDD_H"].ToString();
                dccTo.OBSERVACION = rw["DSOBS"].ToString();
                dccTo.NRO_PRESUPUESTO = ccTo.NRO_PRESUPUESTO;
                dccTo.NRO_ITEM = dccTo.ITEM;//rw["NUIT1"].ToString().Substring(1,2);
                dccTo.COD_CONDICION = "";
                dccTo.DESC_ARTICULO = rw["DSART"].ToString();
                dccTo.TIPO_PRECIO = "";
                dccTo.NRO_FAC_PRE_UNI = "";
                dccTo.TIPO_ENTR_FAC = "0";
                dccTo.COD_KIT = rw["cod_kit"].ToString();
                dccTo.ST_VALOR_REFERENCIAL = rw["ST_VALOR_REFERENCIAL"].ToString();//rw["ST_VALOR_REFERENCIAL"].ToString()=="VALOR REFERENCIAL" ? "1" : "0";

                if (!dccBLL.insertarContratoDetalle_dbf_BLL(dccTo, ref errMensaje))
                    return result = false;
                i++;
            }
            return result;
        }
        public bool VERIFICA_NRO_CONTRATO_BLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.VERIFICA_NRO_CONTRATO_DAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ELIMINAR_PEDIDOBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.ELIMINAR_PEDIDODAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool ELIMINAR_PEDID_X_NRO_CONTRATO_BLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.ELIMINAR_PEDID_X_NRO_CONTRATO_DAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable repContratosRegistradosBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.repContratosRegistradosDAL(ccTo);
        }
        public DataTable repContratosRegistrados_Resumen_BLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.repContratosRegistrados_Resumen_DAL(ccTo);
        }
        public DataTable repContratosRegistrados_x_PtoCons_Resumen_BLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.repContratosRegistrados_x_PtoCons_Resumen_DAL(ccTo);
        }
        public DataTable repContratosRegistrados_x_PtoCons_BLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.repContratosRegistrados_x_PtoCons_DAL(ccTo);
        }
        public bool modificarContratoDirectoFacturacionBLL(contratoCabeceraTo ccTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //cabecera
                if (!modificarContratoDirectoBLL(ccTo, ref errMensaje))
                    return result = false;
                //eliminar detalle
                if (!eliminarContratoDirectoBLL(ccTo, ref errMensaje))
                    return result = false;
                //detalle
                if (!insertarContratoDetalle_dbf_BLL(ccTo, dt, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool eliminarContratoDirectoBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            contratoDetalleDAL dccDAL = new contratoDetalleDAL();
            contratoDetalleTo dccTo = new contratoDetalleTo();
            dccTo.COD_SUCURSAL = ccTo.COD_SUCURSAL;
            dccTo.NRO_DOC = ccTo.NRO_DOC;
            dccTo.COD_PER = ccTo.COD_PER;
            dccTo.COD_CLASE = ccTo.COD_CLASE;
            dccTo.FE_AÑO = ccTo.FE_AÑO;
            dccTo.FE_MES = ccTo.FE_MES;
            if (!dccDAL.eliminarContratoDirectoDAL(dccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerContratosparaReporteContratosDirectosBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratosparaReporteContratosDirectosDAL(ccTo);
        }
        public DataTable obtenerContratosCuentaCorrienteBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratosCuentaCorrienteDAL(ccTo);
        }
        public DataTable obtenerDatosDescuentoIndebidoxContratoBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerDatosDescuentoIndebidoxContratoDAL(ccTo);
        }
        public DataTable obtenerContratosxCodPersonaBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtenerContratosxCodPersonaDAL(ccTo);
        }
        public bool eliminaContratoOrdDevVtasBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina detalle de T_PEDIOD donde STATUS_NC='1'
                if (!eliminarDetalleContratoOrdDevBLL(ccTo, ref errMensaje))
                    return result = false;
                //elimina cabecera I_PEDIDO donde STATUS_NC='1'
                if (!eliminarCabeceraContratoOrdDevBLL(ccTo, ref errMensaje))
                    return result = false;
                //
                if (ccTo.TIPO_ORIGEN == "F" || ccTo.TIPO_ORIGEN == "B")//solo si es una devolucion proveniente de una factura se empleará este método, si es un devolución proveniente de un contrato, o sea si no se ha facturado.
                {
                    //actualiza el campo status_dev, lo establece en 0 para que se vean las facturas a las que se le puede hacer orden de devolucion
                    if (!modificarEliminarFacturacionOrdDevBLL(ccTo, ref errMensaje))
                        return result = false;
                }
                else if (ccTo.TIPO_ORIGEN == "C")
                {
                    //actualiza en el campo NRO_FAC_PRE_UNI=''
                    if (!modificarEliminarCabezaContratoOrdDevBLL(ccTo, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }

        }
        private bool eliminarDetalleContratoOrdDevBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.eliminarDetalleContratoOrdDevDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminarCabeceraContratoOrdDevBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.eliminarCabeceraContratoOrdDevDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarEliminarCabezaContratoOrdDevBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarEliminarCabezaContratoOrdDevDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool modificarEliminarFacturacionOrdDevBLL(contratoCabeceraTo ccTo, ref string errMensaje)
        {
            bool result = true;
            if (!ccDAL.modificarEliminarFacturacionOrdDevDAL(ccTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtener_Personas_para_Plla_Directa_VariosBLL(contratoCabeceraTo ccTo)
        {
            return ccDAL.obtener_Personas_para_Plla_Directa_VariosDAL(ccTo);
        }
    }
}
