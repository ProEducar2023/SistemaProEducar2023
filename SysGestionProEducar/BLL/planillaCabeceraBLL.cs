using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Transactions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace BLL
{
    public class DocumentoResult
    {
        public string Documento { get; set; }
        public int CantRegistros { get; set; }
        public int Total { get; set; }

    }
    public class planillaCabeceraBLL
    {
        planillaCabeceraDAL plcDAL = new planillaCabeceraDAL();
        planillaDetalleBLL pldBLL = new planillaDetalleBLL();

        planillaDetalleTo pldTo = new planillaDetalleTo();
        public DataTable obtener_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtener_I_Planilla_Cabecera_DAL(plcTo);
        }
        public bool adicionaNuevaPlanillaBLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                if (plcTo.STATUS_NO_ENVIADO == "1")//SE CREA UNA LISTA DE LOS NO ENVIADOS POR ALGUNA RAZON
                {
                    //I
                    if (!insertar_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                        return result = false;
                    //adiciona en uno el nro de planilla
                    serieDocumentoBLL sdBLL = new serieDocumentoBLL();
                    serieDocumentosTo sdTo = new serieDocumentosTo();
                    sdTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                    sdTo.COD_DOC = "43";
                    sdTo.STATUS_DOC = "0";
                    sdTo.SERIE = "001";
                    if (!sdBLL.adicionaNroSerieBLL(sdTo, ref errMensaje))
                        return result = false;
                }
                else
                {
                    //I
                    if (!insertar_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                        return result = false;
                    //T
                    if (!insertar_T_Planilla_Detalle_BLL(plcTo, dt, ref errMensaje))
                        return result = false;
                    //PCTA_COBRAR se establece el campo STATUS_GENERADO Y STATUS_ENVIADO(comprometido)
                    if (!modifica_P_Ctas_BLL(plcTo, dt, ref errMensaje))
                        return result = false;
                    //adiciona en uno el nro de planilla
                    if (!HelpersBLL.estableceNuevoNumeroContador(plcTo.COD_SUCURSAL, plcTo.COD_DOC, plcTo.STATUS_DOC, plcTo.SERIE, ref errMensaje))
                        return result = false;
                }

                ts.Complete();
                return result;
            }
        }
        public bool modifica_P_Ctas_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL pctasBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctasTo = new canjePCtasxCobrarTo();
            foreach (DataRow rw in dt.Rows)
            {
                pctasTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                pctasTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();//0
                pctasTo.NRO_DOC = rw["NRO_DOC"].ToString();//6
                pctasTo.STATUS_GENERADO = "1";
                pctasTo.STATUS_ENVIADO = "1";// DESDE QUE SE GRABA SE PONE COMO COMPROMETIDO, ASI LO PIDIO LA SEÑORA NURIA
                pctasTo.COD_USU_MOD = plcTo.COD_CREACION;
                pctasTo.FECHA_MOD = plcTo.FECHA_CREACION;
                if (!pctasBLL.modifica_P_Ctas_por_Generacion_Planilla_BLL(pctasTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool modifica_P_Ctas_st_enviado_BLL(planillaCabeceraTo plcTo, DataTable dt, string status, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL pctasBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctasTo = new canjePCtasxCobrarTo();
            foreach (DataRow rw in dt.Rows)
            {
                pctasTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                pctasTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();//rw["NRO_CONTRATO_Det"].ToString();//0
                pctasTo.NRO_DOC = rw["NRO_DOC"].ToString();//rw["NRO_DOC_Det"].ToString();//6
                pctasTo.STATUS_GENERADO = status;
                pctasTo.STATUS_ENVIADO = status;
                pctasTo.COD_USU_MOD = plcTo.COD_MOD;
                pctasTo.FECHA_MOD = plcTo.FECHA_MOD;
                if (!pctasBLL.modifica_P_Ctas_por_Envio_Planilla_BLL(pctasTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool modifica_P_Ctas_st_enviado_x_generar_BLL(planillaCabeceraTo plcTo, DataTable dt, string status, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarBLL pctasBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctasTo = new canjePCtasxCobrarTo();
            foreach (DataRow rw in dt.Rows)
            {
                pctasTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                pctasTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();//0
                pctasTo.NRO_DOC = rw["NRO_DOC"].ToString();//6
                pctasTo.STATUS_GENERADO = status;
                pctasTo.STATUS_ENVIADO = status;
                pctasTo.COD_USU_MOD = plcTo.COD_MOD;
                pctasTo.FECHA_MOD = plcTo.FECHA_MOD;
                if (!pctasBLL.modifica_P_Ctas_por_Envio_Planilla_BLL(pctasTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertar_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.insertar_I_Planilla_Cabecera_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPCtasCobrar_para_PlanillaBLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtenerPCtasCobrar_para_PlanillaDAL(plcTo);
        }
        public bool insertar_T_Planilla_Detalle_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            foreach (DataRow rw in dt.Rows)
            {
                pldTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_COB;
                pldTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
                pldTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB_CONSOLIDADO;
                pldTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
                pldTo.FE_AÑO = plcTo.FE_AÑO;
                pldTo.FE_MES = plcTo.FE_MES;
                pldTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();//0
                pldTo.COD_PER = rw["COD_PER"].ToString();//1
                pldTo.COD_DOC = rw["COD_DOC"].ToString();//5
                pldTo.NRO_DOC = rw["NRO_DOC"].ToString();//6
                pldTo.FECHA_VEN = Convert.ToDateTime(rw["FECHA_VEN"]);//7
                pldTo.IMP_DOC = Convert.ToDecimal(rw["SAL_IMP"]);//9
                pldTo.IMP_COB = 0;
                pldTo.IMP_COB_CTA_CTE = 0;
                pldTo.OK = false;
                pldTo.IMP_DEV = 0;
                pldTo.NRO_LETRA = rw["NRO_LETRA"].ToString();//10
                pldTo.TOT_LETRA = rw["TOTAL_LETRA"].ToString();//
                pldTo.TIPO_PLANILLA = plcTo.TIPO_PLANILLA;
                pldTo.TIPO_GENERACION = "G";//GENERADO
                pldTo.COD_MOTIVO_NO_DESCONTADO = "";
                pldTo.OBSERVACION = rw["OBSERVACION"].ToString();//12
                pldTo.COD_PTO_COB = rw["COD_PTO_COB"].ToString();//13
                pldTo.COD_PTO_VEN = rw["COD_SUB_PTO_VEN"].ToString();
                pldTo.COD_CREACION = plcTo.COD_CREACION;
                pldTo.FECHA_CREACION = plcTo.FECHA_CREACION;
                if (!pldBLL.insertar_T_Planilla_Detalle_BLL(pldTo, ref errMensaje))
                    return result = false;

            }
            return result;
        }
        public DataTable obtenerClientesparaPlanillaCob()
        {
            return plcDAL.obtenerClientesparaPlanillaCob();
        }
        public bool modificaActualizaPlanillaBLL(planillaCabeceraTo plcTo, DataTable dtAnt, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                string status;
                //I
                if (!modificar_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                    return result = false;
                //elimina T
                if (!eliminar_I_Planilla_Detalle_BLL(plcTo, ref errMensaje))
                    return result = false;
                //T
                if (!insertar_T_Planilla_Detalle_BLL(plcTo, dt, ref errMensaje))
                    return result = false;
                //elimina Pctas_cobrar, status_envio=null
                status = null;
                if (!modifica_P_Ctas_st_enviado_BLL(plcTo, dtAnt, status, ref errMensaje))
                    return result = false;
                //Pctas_cobrar status_envio=1
                status = "1";
                if (!modifica_P_Ctas_st_enviado_BLL(plcTo, dt, status, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool modificar_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.modificar_I_Planilla_Cabecera_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminar_I_Planilla_Detalle_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            if (!pldBLL.eliminar_I_Planilla_Detalle_BLL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaPlanillaCobBLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //Pctas_cobrar status_envio=null
                if (!modifica_P_Ctas_st_enviado_x_generar_BLL(plcTo, dt, null, ref errMensaje))
                    return result = false;
                //elimina I
                if (!eliminar_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                    return result = false;
                //elimina T
                if (!eliminar_I_Planilla_Detalle_BLL(plcTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool eliminar_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.eliminar_I_Planilla_Cabecera_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool anulaPlanillaCobBLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina I
                if (!anular_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                    return result = false;
                //elimina T
                if (!eliminar_I_Planilla_Detalle_BLL(plcTo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool anular_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.anular_I_Planilla_Cabecera_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool aprobarPlanillaCobranzaBLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I_Planilla
                if (!aprobarPlanillaCobBLL(plcTo, ref errMensaje))
                    return result = false;
                //----------------------------- preguntar si es planilla directa para que entre aquí
                if (plcTo.COD_TIPO_OPERACION == "D")//NUNCA ENTRA PUES COD_TIPO_OPERACION ES PP
                {
                    //Envio
                    if (!generar_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                        return result = false;
                    //Pctas_cobrar status_envio=1
                    if (!modifica_P_Ctas_st_enviado_BLL(plcTo, dt, "1", ref errMensaje))
                        return result = false;
                    //-----------------------------
                }
                ts.Complete();
                return result;
            }
        }
        public bool aprobarPlanillaCobBLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.aprobarPlanillaCobDAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtener_Envio_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtener_Envio_I_Planilla_Cabecera_DAL(plcTo);
        }
        public DataTable obtener_Recepcion_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtener_Recepcion_I_Planilla_Cabecera_DAL(plcTo);
        }
        public DataTable obtener_Cancelacion_R_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtener_Cancelacion_R_Planilla_Cabecera_DAL(plcTo);
        }
        public bool generaActualizaPlanillaBLL(planillaCabeceraTo plcTo, string ruta, DataTable dt, DataTable dtConsolidado, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I_Planilla
                if (!generar_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                    return result = false;
                ////Pctas_cobrar status_envio=1
                //if (!modifica_P_Ctas_st_enviado_BLL(plcTo, dt,"1", ref errMensaje))  //AHORA SE COMPROMETE DESDE LA GENERACION DE LA PLANILLA
                //    return result = false;
                //Genera archivos
                if (!genera_Archivos_PtoCobBLL(plcTo, ruta, dtConsolidado))
                    return result = false;
                //Exportacion
                if (!ExportarDataGridViewExcel(plcTo, ruta, dtConsolidado))
                    return result = false;
                ts.Complete();
                return result;
            }
        }

        private bool ExportarDataGridViewExcel(planillaCabeceraTo plcTo, string ruta, DataTable detalles)
        {
            bool result = true;
            if (plcTo.COD_INSTITUCION == "01")
            {
                if (!exportaMinisterioEducacionLimaProvincias(plcTo, ruta, detalles))
                    return result = false;
            }
            else if (plcTo.COD_INSTITUCION == "02")
            {
                if (!exportaPolicia(plcTo, ruta, detalles))
                    return result = false;
            }
            return result;
        }
        private bool exportaMinisterioEducacionLimaProvincias(planillaCabeceraTo plcTo, string ruta, DataTable detalles)
        {
            bool result = true;
            try
            {
                Excel.Application excel;
                Excel.Workbook workBook;
                Excel.Worksheet sheet;
                Excel.Range range;
                excel = new Excel.Application();
                workBook = excel.Workbooks.Add(Type.Missing);
                sheet = (Excel.Worksheet)workBook.ActiveSheet;
                sheet.Name = "MINEDU-LIMA";
                range = sheet.get_Range("A1", "P1");
                range.Merge();
                sheet.Cells[1, 1] = "PLANILLA DE DESCUENTO DEL MES DE " + plcTo.NOMBRE_MES + " DEL " + plcTo.FE_AÑO;
                range = sheet.get_Range("A1", "A1");
                range.Font.Bold = true;
                range.Font.Size = 15;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range = sheet.get_Range("A2", "P2");
                range.Merge();
                sheet.Cells[2, 1] = "PERSONAL ACTIVO";
                range = sheet.get_Range("A2", "A2");
                range.Font.Bold = true;
                range.Font.Size = 15;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                //
                int fila = 4; int i = 0; string mtotal = ""; string montodes = ""; decimal monto = 0; string cod_empresa = "";
                string formato = @"""00000000"""; string formato2 = @"""0000"""; string formato3 = @"""00""";
                foreach (DataRow row in detalles.Rows)
                {
                    if (fila == 4)
                    {
                        //cabeceras
                        sheet.Cells[fila, 1] = "N°";
                        sheet.Cells[fila, 2] = "PERIODO";
                        sheet.Cells[fila, 3] = "EMPRESA";
                        sheet.Cells[fila, 4] = "CODMOD";
                        sheet.Cells[fila, 5] = "CARGO";
                        sheet.Cells[fila, 6] = "CARBEN";
                        sheet.Cells[fila, 7] = "T_PLANILLA";
                        sheet.Cells[fila, 8] = "CODDES";
                        sheet.Cells[fila, 9] = "MONTODES";
                        sheet.Cells[fila, 10] = "APEPATER";
                        sheet.Cells[fila, 11] = "APEMATER";
                        sheet.Cells[fila, 12] = "NOMBRE";
                        sheet.Cells[fila, 13] = "FINICRE";
                        //sheet.Cells[fila, 14] = "MTOTAL";
                        //sheet.Cells[fila, 15] = "NROCUOTAS";
                        //
                        range = sheet.get_Range("A" + fila, "R" + fila);
                        range.Font.Bold = true;
                        range.Font.Size = 10;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //
                        fila++;
                        sheet.Cells[fila, 4] = plcTo.DESC_PTO_COB;
                        range = sheet.get_Range("D" + fila, "G" + fila);
                        range.Font.Bold = true;
                        range.Font.Size = 10;
                        range.Merge();
                        //
                        fila++;
                    }
                    i++;
                    sheet.Cells[fila, 1] = i;//Nª
                    range = sheet.get_Range("A" + fila, "A" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //
                    sheet.Cells[fila, 2] = plcTo.FE_AÑO + plcTo.FE_MES;//PERIODO
                    range = sheet.get_Range("B" + fila, "B" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    cod_empresa = row["COD_ZONA_Det"].ToString();
                    range = sheet.get_Range("C" + fila, "C" + fila);
                    //range.Formula = "=" + @"TEXT(1" + "," + formato3 + ")";//EMPRESA
                    range.Formula = "=" + @"TEXT(" + cod_empresa + "," + formato3 + ")";//EMPRESA
                    range.Copy(Type.Missing);
                    range.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, System.Type.Missing, System.Type.Missing);
                    //
                    sheet.Cells[fila, 4] = row["DES_IDENTIDAD_Det"].ToString();//CODMOD
                    range = sheet.get_Range("D" + fila, "D" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    sheet.Cells[fila, 5] = row["DES_PROCESO_Det"].ToString();//CARGO
                    range = sheet.get_Range("E" + fila, "E" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    range = sheet.get_Range("F" + fila, "F" + fila);
                    range.Formula = "=" + @"TEXT(0" + "," + formato2 + ")";//CARBEN
                    range.Copy(Type.Missing);
                    range.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, System.Type.Missing, System.Type.Missing);
                    //
                    sheet.Cells[fila, 7] = "A";//T_PLANILLA
                    range = sheet.get_Range("G" + fila, "G" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    range = sheet.get_Range("H" + fila, "H" + fila);
                    range.Formula = "=" + @"TEXT(140" + "," + formato2 + ")";//CODDES
                    range.Copy(Type.Missing);
                    range.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, System.Type.Missing, System.Type.Missing);
                    //
                    monto += Convert.ToDecimal(row["SAL_IMP_Det"]);
                    montodes = row["SAL_IMP_Det"].ToString().Replace(".", "");
                    range = sheet.get_Range("I" + fila, "I" + fila);
                    range.Formula = "=TEXT(" + montodes + "," + formato + ")";
                    range.Copy(Type.Missing);
                    range.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, System.Type.Missing, System.Type.Missing);
                    //
                    sheet.Cells[fila, 10] = row["PATERNO_Det"].ToString();//APEPATER
                    range = sheet.get_Range("J" + fila, "J" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    sheet.Cells[fila, 11] = row["MATERNO_Det"].ToString();//APEMATER
                    range = sheet.get_Range("K" + fila, "K" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    sheet.Cells[fila, 12] = row["NOMBRE_Det"].ToString();//NOMBRE
                    range = sheet.get_Range("L" + fila, "L" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    sheet.Cells[fila, 13] = row["FECHA_PRIMER_VENC_Det"].ToString();//FINICRE
                    range = sheet.get_Range("M" + fila, "M" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    //mtotal = row["TOTAL_CONTRATO_Det"].ToString().Replace(".", "");
                    //range = sheet.get_Range("N" + fila, "N" + fila);
                    //range.Formula = "=TEXT(" + mtotal + "," + formato + ")";//MTOTAL
                    //range.Copy(Type.Missing);
                    //range.PasteSpecial(Excel.XlPasteType.xlPasteValues, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, System.Type.Missing, System.Type.Missing);
                    ////
                    //sheet.Cells[fila, 15] = row["TOT_LETRA_Det"].ToString();//NROCUOTAS
                    //range = sheet.get_Range("O" + fila, "O" + fila);
                    //range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //
                    fila++;
                }
                sheet.Cells[fila + 1, 9] = monto;
                range = sheet.get_Range("I" + (fila + 1), "I" + (fila + 1));
                range.NumberFormat = "###,###,##0.00";
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                range.Font.Bold = true;

                sheet.Columns.AutoFit();
                //sheet.get_Range("C:C", Missing.Value).EntireColumn.Hidden = true;//esto debe estar al final de todos los cambios para ocultar la columna
                ////excel.Visible = true;
                //excel.DisplayAlerts = true;

                workBook.SaveAs(ruta + @"\" + plcTo.DESC_PTO_COB + "." + plcTo.FE_AÑO + "." + plcTo.FE_MES + ".xls",
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                workBook.Close(true);
                excel.Quit();
                result = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
                result = false;
            }
            return result;
        }
        private bool exportaPolicia(planillaCabeceraTo plcTo, string ruta, DataTable detalles)
        {
            bool result = true;
            try
            {
                Excel.Application excel;
                Excel.Workbook workBook;
                Excel.Worksheet sheet;
                Excel.Range range;
                excel = new Excel.Application();
                workBook = excel.Workbooks.Add(Type.Missing);
                sheet = (Excel.Worksheet)workBook.ActiveSheet;
                sheet.Name = "PNP";

                range = sheet.get_Range("A1", "J1");
                range.Merge();
                sheet.Cells[1, 1] = "PLANILLA ENVIADA AL MES DE " + plcTo.NOMBRE_MES + " DEL " + plcTo.FE_AÑO;
                range = sheet.get_Range("A1", "A1");
                range.Font.Bold = true;
                range.Font.Size = 15;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                //------------------------

                //range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin,
                //  Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                //range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //*/

                int fila = 2; int i = 0;
                foreach (DataRow row in detalles.Rows) //row["CoCuentaActivo"].ToString()
                {
                    if (fila == 2)
                    {
                        //cabeceras
                        sheet.Cells[fila, 1] = "N°";
                        sheet.Cells[fila, 2] = "CODIGO ENTIDAD";
                        sheet.Cells[fila, 3] = "DNI";
                        sheet.Cells[fila, 4] = "CODOFIN";
                        sheet.Cells[fila, 5] = "APELLIDOS Y NOMBRES";
                        sheet.Cells[fila, 6] = "MONTO";
                        sheet.Cells[fila, 7] = "CUOTA";
                        sheet.Cells[fila, 8] = "PRESTAMO";
                        sheet.Cells[fila, 9] = "FECHA";
                        sheet.Cells[fila, 10] = "CUOTA PACTADA";

                        range = sheet.get_Range("A" + fila, "M" + fila);
                        range.Font.Bold = true;
                        range.Font.Size = 10;
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        fila++;
                    }
                    i++;
                    sheet.Cells[fila, 1] = i;
                    range = sheet.get_Range("A" + fila, "A" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //range.ColumnWidth = 3;
                    sheet.Cells[fila, 2] = "14040000";
                    range = sheet.get_Range("B" + fila, "B" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //range.ColumnWidth = 10;
                    sheet.Cells[fila, 3] = row["DNI_Det"].ToString();
                    range = sheet.get_Range("C" + fila, "C" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //range.EntireColumn.Hidden = true;
                    //range.ColumnWidth = 10;
                    sheet.Cells[fila, 4] = row["DES_PROCESO_Det"].ToString();
                    range = sheet.get_Range("D" + fila, "D" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //range.ColumnWidth = 10;
                    sheet.Cells[fila, 5] = row["PATERNO_Det"].ToString() + " " + row["MATERNO_Det"].ToString() + " " + row["NOMBRE_Det"].ToString();
                    range = sheet.get_Range("E" + fila, "E" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //range.ColumnWidth = 40;
                    sheet.Cells[fila, 6] = row["SAL_IMP_Det"].ToString();
                    range = sheet.get_Range("F" + fila, "F" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    range.NumberFormat = "0.00";
                    //range.ColumnWidth = 10;
                    sheet.Cells[fila, 7] = row["NRO_LETRA_Det"].ToString();
                    range = sheet.get_Range("G" + fila, "G" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //range.ColumnWidth = 4;
                    sheet.Cells[fila, 8] = row["SAL_IMP_Det"].ToString();
                    range = sheet.get_Range("H" + fila, "H" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    range.NumberFormat = "0.00";
                    //range.ColumnWidth = 10;
                    sheet.Cells[fila, 9] = row["FECHA_PRE_Det"].ToString();
                    range = sheet.get_Range("I" + fila, "I" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //range.ColumnWidth = 10;
                    sheet.Cells[fila, 10] = row["SAL_IMP_Det"].ToString();
                    range = sheet.get_Range("J" + fila, "J" + fila);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    range.NumberFormat = "0.00";
                    //range.ColumnWidth = 10;
                    fila++;

                }

                range = sheet.get_Range("A2:J" + (fila - 1).ToString());//H-J
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //
                range = sheet.get_Range("E" + (fila + 1), "E" + (fila + 1));
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                range.Font.Bold = true;
                sheet.Cells[fila + 1, 5] = "TOTAL";

                range = sheet.get_Range("H" + (fila + 1), "H" + (fila + 1));
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                range.Font.Bold = true;
                range.Formula = "=SUM(H3:H" + (fila - 1).ToString() + ")";//+fila.ToString()+")");
                //range.FormulaHidden = true;
                //range.Calculate();
                //
                sheet.Columns.AutoFit();
                sheet.get_Range("C:C", Missing.Value).EntireColumn.Hidden = true;//esto debe estar al final de todos los cambios
                //excel.Visible = true;
                excel.DisplayAlerts = true;

                workBook.SaveAs(ruta + @"\" + plcTo.DESC_PTO_COB + "." + plcTo.FE_AÑO + "." + plcTo.FE_MES + ".xls",
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                workBook.Close(true);
                excel.Quit();
                result = true;

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
                result = false;
            }
            return result;
        }


        public bool generar_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.generar_I_Planilla_Cabecera_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }

        private bool genera_Archivos_PtoCobBLL(planillaCabeceraTo plcTo, string archivo, DataTable dt)
        {
            bool result = true;
            //puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            //puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            //DataTable dtPto = new DataTable();
            //DataTable tblFiltered = null ;
            //ptoTo.STATUS_CONSOLIDADO = true;
            if (plcTo.TIPO_PLANILLA == "PP")
            {
                //ptoTo.COD_PTO_COB = plcTo.COD_PTO_COB_CONSOLIDADO;
                //dtPto = ptoBLL.obtenerPtoCobranzaxPtoCobConsolidadoBLL(ptoTo);//TRAE SUB PTOS COBRANZA
                //if(dtPto.Rows.Count > 0)
                //{
                //    foreach (DataRow rw in dtPto.Rows)
                //    {
                //        var query = dt.AsEnumerable().Where(row => row.Field<String>("Column14") == rw[0].ToString());
                //        if (query.Count() > 0)
                //        {
                //            tblFiltered = dt.AsEnumerable()
                //            .Where(row => row.Field<String>("Column14") == rw[0].ToString())
                //            .CopyToDataTable();
                //            //
                //            if (!EscribeArchivo(plcTo, archivo + @"\" + rw[1].ToString() + ".txt", tblFiltered))
                //                return result = false;
                //        }
                //        //if (!EscribeArchivo(plcTo, archivo +@"\"+ rw[1].ToString() + ".txt", tblFiltered))
                //        //    return result = false;
                //    }
                //    if(dtPto.Rows.Count > 0)//solo si es mayor que uno los puntos de cobranza se creara otro archivo, que es el Consolidado
                //    {
                //        //para el Consolidado
                //        if (!EscribeArchivo(plcTo, archivo + @"\CONSOLIDADO " + dtPto.Rows[0][2].ToString() + ".txt", dt))
                //            return result = false;
                //    }
                //}
                //else
                //{
                //    //para el Consolidado
                //    if (!EscribeArchivo(plcTo, archivo + @"\CONSOLIDADO " + ptoTo.COD_PTO_COB + ".txt", dt))
                //        return result = false;
                //}
                //
                //para el Consolidado
                if (!EscribeArchivo(plcTo, archivo + @"\" + plcTo.DESC_PTO_COB + "." + plcTo.FE_AÑO + "." + plcTo.FE_MES + ".txt", dt))
                    return result = false;
            }
            else
            {
                if (!EscribeArchivo(plcTo, archivo + ".txt", dt))
                    return result = false;
            }
            return result;
        }
        private bool EscribeArchivo(planillaCabeceraTo plcTo, string archivo, DataTable dt)
        {
            bool result = false;
            using (FileStream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    try
                    {
                        if (plcTo.COD_INSTITUCION == "01")//MINISTERIO DE EDUCACION
                        {
                            foreach (DataRow rw in dt.Rows)
                            {
                                sw.WriteLine(plcTo.FE_AÑO + plcTo.FE_MES + //PERIODO 6 CARACTERES
                                    rw["COD_ZONA_Det"].ToString() + //COD EMPRESA 2 CARACTERES
                                    (rw["DES_IDENTIDAD_Det"].ToString().Length > 10 ? rw["DES_IDENTIDAD_Det"].ToString().Substring(0, 10) : rw["DES_IDENTIDAD_Det"].ToString().PadRight(10, ' ')) +  // COD MODULAR 10 CARACTERES
                                    (rw["DES_PROCESO_Det"].ToString().Length > 6 ? rw["DES_PROCESO_Det"].ToString().Substring(0, 6) : rw["DES_PROCESO_Det"].ToString().PadRight(6, ' ')) +  // COD CARGO 6 CARACTERES 
                                    "0000A" + rw[14].ToString() + //---->POR DEFECTO, DEBE SER EL  CODIGO DE CASILLERO
                                    (Convert.ToInt32(Convert.ToDecimal(rw["SAL_IMP_Det"]) * 100)).ToString().PadLeft(8, '0') + // MONTODES 8 CARACTERES
                                    rw["PATERNO_Det"].ToString().PadRight(40, ' ') + //APEPATER 40 CARACTERES
                                    rw["MATERNO_Det"].ToString().PadRight(40, ' ') + //APEMATER 40 CARACTERES
                                    rw["NOMBRE_Det"].ToString().PadRight(35, ' ') + //NOMBRES 35 CARACTERES
                                    rw["FECHA_PRIMER_VENC_Det"].ToString());
                            }
                        }
                        else if (plcTo.COD_INSTITUCION == "02")//POLICIA
                        {
                            foreach (DataRow rw in dt.Rows)
                            {
                                sw.WriteLine(rw[2].ToString() +
                                    rw[14].ToString() +
                                    "0000" + "00000000" + (Convert.ToInt32(Convert.ToDecimal(rw[9]) * 100)).ToString() +
                                    "000000000000" + "00000000" + (Convert.ToInt32(Convert.ToDecimal(rw[9]) * 100)).ToString() +
                                    rw[7].ToString() + "00000000" + (Convert.ToInt32(Convert.ToDecimal(rw[9]) * 100)).ToString());
                            }
                        }
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
            }
            result = true;
            return result;
        }
        public bool RecepcionaPlanillaBLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //eliminar todos los registros adicionados por descuento en exceso.
                if (!eliminar_I_Planilla_Detalle_Modificar_BLL(plcTo, ref errMensaje))
                    return result = false;
                //I
                if (!Actualiza_Repciona_I_Planilla_Cabecera_BLL(plcTo, ref errMensaje))
                    return result = false;
                //T
                if (!Actualiza_Repciona_I_Planilla_Detalle_BLL(plcTo, dt, ref errMensaje))
                    return result = false;
                ////ADICIONA EN T_PLANILLAS CASO QUE SE RECEPCIONE UN CLIENTE QUE NO SE HAYA ENVIADO EN EL ARCHIVO
                //if (!Adiciona_en_T_Planillas_BLL(plcTo, dt, ref errMensaje))
                //    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool eliminar_I_Planilla_Detalle_Modificar_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            pldTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_COB;
            pldTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
            pldTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB_CONSOLIDADO;
            pldTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
            pldTo.FE_AÑO = plcTo.FE_AÑO;
            pldTo.FE_MES = plcTo.FE_MES;
            if (!pldBLL.eliminar_T_Planilla_Detalle_Modificar_BLL(pldTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool Adiciona_en_T_Planillas_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            DataTable tblFiltered = dt.AsEnumerable()
                    .Where(row => row.Field<String>("Column1") == "0000000")
                    //&& row.Field<String>("Ort") == location)
                    //.OrderByDescending(row => row.Field<String>("Nachname"))
                    .CopyToDataTable();

            //if (!insertar_T_Planilla_Detalle_por_Recepcion_BLL(plcTo, tblFiltered, ref errMensaje))//hay que revisar esto 
            //    return result = false;
            return result;
        }
        public bool insertar_T_Planilla_Detalle_por_Recepcion_BLL(planillaCabeceraTo plcTo, DataRow rw, ref string errMensaje)
        {
            bool result = true;
            //int i = 1;
            planillaDetalleBLL pldBLL = new planillaDetalleBLL();
            planillaDetalleTo pldTo = new planillaDetalleTo();
            //foreach (DataRow rw in dt.Rows)
            //{
            pldTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_COB;
            pldTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
            pldTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB_CONSOLIDADO;
            pldTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
            pldTo.FE_AÑO = plcTo.FE_AÑO;
            pldTo.FE_MES = plcTo.FE_MES;
            pldTo.NRO_CONTRATO = rw[0].ToString();
            pldTo.COD_PER = rw[1].ToString();
            pldTo.COD_DOC = rw[5].ToString();
            pldTo.NRO_DOC = rw[6].ToString();//para que haya diferencia en cada registro
            pldTo.FECHA_VEN = Convert.ToDateTime(rw[7]);
            pldTo.IMP_DOC = Convert.ToDecimal(rw[8]);
            pldTo.IMP_COB = Convert.ToDecimal(rw[9]);
            pldTo.IMP_COB_CTA_CTE = Convert.ToDecimal(rw[10]);
            pldTo.IMP_DEV = Convert.ToDecimal(rw[11]);
            pldTo.OK = true;
            pldTo.NRO_LETRA = rw[12].ToString();
            pldTo.TOT_LETRA = rw[13].ToString();
            pldTo.TIPO_PLANILLA = "P";
            pldTo.TIPO_GENERACION = "G";
            pldTo.COD_MOTIVO_NO_DESCONTADO = rw[14].ToString();
            pldTo.OBSERVACION = "Cuota adiciona por exceso en descuento";
            pldTo.COD_PTO_COB = plcTo.COD_PTO_COB_CONSOLIDADO;
            pldTo.COD_PTO_VEN = "";
            pldTo.COD_CREACION = plcTo.COD_MOD;
            pldTo.FECHA_CREACION = plcTo.FECHA_MOD;
            if (!pldBLL.insertar_T_Planilla_Detalle_BLL(pldTo, ref errMensaje))
                return result = false;
            //i++;
            //}
            return result;
        }
        public bool Actualiza_Repciona_I_Planilla_Cabecera_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.Actualiza_Recepciona_I_Planilla_Cabecera_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool Actualiza_Repciona_I_Planilla_Detalle_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                pldTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_COB;
                pldTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
                pldTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB_CONSOLIDADO;
                pldTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
                pldTo.FE_AÑO = plcTo.FE_AÑO;
                pldTo.FE_MES = plcTo.FE_MES;
                pldTo.NRO_CONTRATO = rw[0].ToString();
                pldTo.NRO_DOC = rw[6].ToString().Trim();
                pldTo.IMP_COB = rw[9] == DBNull.Value ? 0 : (rw[9].ToString() != "" ? Convert.ToDecimal(rw[9]) : 0);
                pldTo.IMP_COB_CTA_CTE = rw[10] == DBNull.Value ? 0 : (rw[10].ToString() != "" ? Convert.ToDecimal(rw[10]) : 0);
                pldTo.IMP_DEV = rw[11] == DBNull.Value ? 0 : (rw[11].ToString() != "" ? Convert.ToDecimal(rw[11]) : 0);
                pldTo.COD_MOD = plcTo.COD_MOD;
                pldTo.FECHA_MOD = plcTo.FECHA_MOD;
                pldTo.COD_PER = rw[1].ToString();
                pldTo.COD_DOC = rw[5].ToString();
                pldTo.FECHA_VEN = rw[7] == DBNull.Value ? null : (rw[7].ToString() != "" ? Convert.ToDateTime(rw[7]) : (DateTime?)null);
                pldTo.IMP_DOC = Convert.ToDecimal(rw[8]);//pldTo.IMP_COB;
                pldTo.OK = Convert.ToBoolean(rw[17]);//si es falso es porque se ha agregado, no estaba cuando se envío la planilla
                pldTo.NRO_LETRA = rw[12].ToString();
                pldTo.TOT_LETRA = rw[13].ToString();
                pldTo.TIPO_PLANILLA = plcTo.TIPO_PLANILLA;
                pldTo.TIPO_GENERACION = "A";
                pldTo.COD_MOTIVO_NO_DESCONTADO = rw[14].ToString();
                pldTo.OBSERVACION = rw[15].ToString();
                pldTo.COD_PTO_COB = rw[16].ToString();
                pldTo.COD_CREACION = plcTo.COD_MOD;
                pldTo.FECHA_CREACION = plcTo.FECHA_MOD;
                pldTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                pldTo.CLIENTE = rw[3].ToString();
                pldTo.FECHA_PLANILLA_COB = plcTo.FECHA_PLANILLA_COB;
                pldTo.DNI = rw[4].ToString();
                if (pldTo.OK && pldTo.COD_MOTIVO_NO_DESCONTADO != "005")
                {
                    if (!pldBLL.Actualiza_Repciona_T_Planilla_Detalle_BLL(pldTo, ref errMensaje))
                        return result = false;
                }
                else if (pldTo.COD_MOTIVO_NO_DESCONTADO != "005")
                {
                    if (!insertar_T_Planilla_Detalle_por_Recepcion_BLL(plcTo, rw, ref errMensaje))
                        return result = false;
                }
                //
                if (pldTo.COD_MOTIVO_NO_DESCONTADO == "005")//DESCUENTO INDEBIDO
                {
                    if (!insertaPersonaIndebidaBLL(pldTo, ref errMensaje))
                        return result = false;
                }
            }
            return result;
        }
        private bool insertaPersonaIndebidaBLL(planillaDetalleTo pldTo, ref string errMensaje)
        {
            bool result = true;
            if (!pldBLL.insertarPersonaIndebidaPlanillaBLL(pldTo, ref errMensaje))
                return result = false;
            return result;

        }
        public bool Aprobar_Recepciona_PlanillaBLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //I_CTAS
                if (!Aprueba_Actualiza_Repciona_I_CTAS_COBRAR_BLL(plcTo, dt, ref errMensaje))
                    return result = false;
                //PCTAS
                if (!Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle_BLL(plcTo, dt, ref errMensaje))//
                    return result = false;
                //TCTAS
                if (!Aprueba_Adiciona_Repciona_T_Planilla_Detalle_BLL(plcTo, dt, ref errMensaje))//
                    return result = false;
                //I_PLANILLA
                if (!Aprueba_Actualiza_Repciona_I_PLANILLA_BLL(plcTo, ref errMensaje))
                    return result = false;
                // R_PLANILLA y RT_PLANILLA
                if (!Aprueba_Adiciona_Recepciona_R_Planilla_BLL(plcTo, dt, ref errMensaje))
                    return result = false;
                //DEV_PCTAS_COBRAR y DEV_TCTAS_COBRAR
                if (!Aprueba_Adiciona_DEV_PCTAS_COBRAR_BLL(plcTo, dt, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public bool Aprueba_Adiciona_Recepciona_R_Planilla_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            IEnumerable<string> rs;
            resumenPlanillaBLL rplaBLL = new resumenPlanillaBLL();
            resumenPlanillaTo rplaTo = new resumenPlanillaTo();
            resumenTPlanillaBLL rtplBLL = new resumenTPlanillaBLL();
            resumenTPlanillaTo rtplTo = new resumenTPlanillaTo();
            DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "").CopyToDataTable();
            if (plcTo.TIPO_PLANILLA == "PP")
            {
                //DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "0000000").CopyToDataTable();
                dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "006").CopyToDataTable();
                dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "007").CopyToDataTable();
                rs = dtPT.AsEnumerable().Select(x => x.Field<string>("COD_PTO_COB_CONSOLIDADO")).Distinct();
            }
            else
            {
                rs = dtPT.AsEnumerable().Select(x => x.Field<string>("NRO_PLANILLA_COB")).Distinct();
            }

            decimal IMP_RECEPCION_INI; decimal IMP_RECEPCION_DEV; decimal IMP_DOC;
            foreach (var r in rs)
            {
                if (plcTo.TIPO_PLANILLA == "PP")
                {
                    IMP_RECEPCION_INI = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_PTO_COB") == r).Sum(x => x.Field<decimal>("IMP_COB")) +
                    dtPT.AsEnumerable().Where(x => x.Field<string>("COD_PTO_COB") == r).Sum(x => x.Field<decimal>("IMP_COB_CTA_CTE"));
                    plcTo.IMP_RECEPCION_INI = IMP_RECEPCION_INI;
                    plcTo.IMP_RECEPCION_DOC = IMP_RECEPCION_INI;
                    IMP_RECEPCION_DEV = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_PTO_COB") == r).Sum(x => x.Field<decimal>("IMP_DEV"));
                    plcTo.IMP_RECEPCION_DEV = IMP_RECEPCION_DEV;
                    IMP_DOC = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_PTO_COB") == r).Sum(x => x.Field<decimal>("IMP_DOC"));
                    plcTo.COD_PTO_COB = r.ToString();

                }
                else
                {
                    IMP_RECEPCION_INI = dtPT.AsEnumerable().Where(x => x.Field<string>("NRO_PLANILLA_COB") == r).Sum(x => x.Field<decimal>("IMP_COB")) +
                    dtPT.AsEnumerable().Where(x => x.Field<string>("NRO_PLANILLA_COB") == r).Sum(x => x.Field<decimal>("IMP_COB_CTA_CTE"));
                    plcTo.IMP_RECEPCION_INI = IMP_RECEPCION_INI;
                    plcTo.IMP_RECEPCION_DOC = IMP_RECEPCION_INI;
                    IMP_RECEPCION_DEV = dtPT.AsEnumerable().Where(x => x.Field<string>("NRO_PLANILLA_COB") == r).Sum(x => x.Field<decimal>("IMP_DEV"));
                    plcTo.IMP_RECEPCION_DEV = IMP_RECEPCION_DEV;
                    IMP_DOC = dtPT.AsEnumerable().Where(x => x.Field<string>("NRO_PLANILLA_COB") == r).Sum(x => x.Field<decimal>("IMP_DOC"));
                    plcTo.COD_PTO_COB = "";
                }
                plcTo.IMP_ENVIO = IMP_DOC;
                plcTo.COD_MONEDA = "S";

                //R_PLANILLA
                rplaTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_COB;
                rplaTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
                rplaTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB_CONSOLIDADO;
                rplaTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
                rplaTo.FE_AÑO = plcTo.FE_AÑO;
                rplaTo.FE_MES = plcTo.FE_MES;
                rplaTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                rplaTo.COD_PTO_COB = plcTo.COD_PTO_COB;
                rplaTo.FECHA_PLANILLA_COB = plcTo.FECHA_PLANILLA_COB;
                rplaTo.FECHA_RECEPCION = plcTo.FECHA_RECEPCION;
                rplaTo.OBSERVACION = plcTo.OBSERVACION;
                rplaTo.TIPO_PLANILLA = plcTo.TIPO_PLANILLA;
                rplaTo.COD_MOD = plcTo.COD_MONEDA;
                rplaTo.IMP_ENV = plcTo.IMP_ENVIO;
                rplaTo.IMP_RECEPCION_INI = plcTo.IMP_RECEPCION_INI;
                rplaTo.IMP_RECEPCION_DOC = plcTo.IMP_RECEPCION_DOC;
                rplaTo.IMP_RECEPCION_DEV = plcTo.IMP_RECEPCION_DEV;
                rplaTo.STATUS_APROB = false;
                rplaTo.COD_CREACION = plcTo.COD_MOD;
                rplaTo.FECHA_CREACION = plcTo.FECHA_MOD;
                //R_PLANILLA
                if (!rplaBLL.insertarResumenPlanillaBLL(rplaTo, ref errMensaje))
                    return result = false;

                //RT_PLANILLA
                rtplTo.NRO_PLANILLA_COB = rplaTo.NRO_PLANILLA_COB;
                rtplTo.COD_INSTITUCION = rplaTo.COD_INSTITUCION;
                rtplTo.COD_PTO_COB_CONSOLIDADO = rplaTo.COD_PTO_COB_CONSOLIDADO;
                rtplTo.COD_CANAL_DSCTO = rplaTo.COD_CANAL_DSCTO;
                rtplTo.FE_AÑO = rplaTo.FE_AÑO;
                rtplTo.FE_MES = rplaTo.FE_MES;
                rtplTo.COD_SUCURSAL = rplaTo.COD_SUCURSAL;
                rtplTo.COD_PTO_COB = rplaTo.COD_PTO_COB;
                rtplTo.FECHA_PLANILLA_COB = rplaTo.FECHA_PLANILLA_COB;
                rtplTo.FECHA_RECEPCION = rplaTo.FECHA_RECEPCION;
                rtplTo.FECHA_PAGO = null;
                rtplTo.OBSERVACION = rplaTo.OBSERVACION;
                rtplTo.TIPO_PLANILLA = rplaTo.TIPO_PLANILLA;
                rtplTo.COD_MOD = rplaTo.COD_MOD;
                rtplTo.IMP_RECEPCION_DOC = rplaTo.IMP_RECEPCION_DOC;
                rtplTo.COD_D_H = "D";
                rtplTo.TIPO_OPE = "GF";
                rtplTo.COD_CREACION = rplaTo.COD_CREACION;
                rtplTo.FECHA_CREACION = rplaTo.FECHA_CREACION;
                rtplTo.COD_DOCUMENTO_PAGO = "";
                rtplTo.NRO_DOCUMENTO_PAGO = "";
                //RT_PLANILLA
                if (!rtplBLL.insertarResumenTPlanillaBLL(rtplTo, ref errMensaje))
                    return result = false;
            }

            return result;
        }
        public bool Aprueba_Actualiza_Repciona_I_PLANILLA_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;

            if (!plcDAL.Aprueba_Actualiza_Repciona_I_PLANILLA_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool Aprueba_Actualiza_Repciona_I_CTAS_COBRAR_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            canjeICtasxCobrarBLL ciccBLL = new canjeICtasxCobrarBLL();
            canjeICtasxCobrarTo ciccTo = new canjeICtasxCobrarTo();

            //DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "" || x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "006").CopyToDataTable();//006 EXCESO CONTRATO
            DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "").CopyToDataTable();
            dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "006").CopyToDataTable();
            dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "007").CopyToDataTable();
            ciccTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
            ciccTo.COD_CLASE = plcTo.COD_CLASE;
            ciccTo.COD_SECTORISTA = plcTo.COD_SECTORISTA;
            ciccTo.COD_USU_MOD = plcTo.COD_MOD;
            ciccTo.FECHA_MOD = plcTo.FECHA_MOD;
            if (!ciccBLL.Aprueba_Actualiza_Repciona_I_Planilla_I_CTAS_COBRAR_BLL(ciccTo, dtPT, ref errMensaje))
                return result = false;

            return result;
        }
        public bool Aprueba_Adiciona_Repciona_T_Planilla_Detalle_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            canjeTCtasxCobrarDAL cttxDAL = new canjeTCtasxCobrarDAL();
            canjeTCtasxCobrarTo ctcxTo = new canjeTCtasxCobrarTo();
            //DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "").CopyToDataTable();
            //DataTable dtPT = dt.AsEnumerable().Where(x => (x.Field<string>("NRO_CONTRATO") != "" || x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "006")).CopyToDataTable();//006 EXCESO CONTRATO
            DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "").CopyToDataTable();
            dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "006").CopyToDataTable();
            dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "007").CopyToDataTable();
            foreach (DataRow rw in dtPT.Rows)
            {
                if (Convert.ToDecimal(rw["IMP_COB"]) > 0)//estaban insertándose los valores de POR AVERIGUAR que son de cero, no debe pasar
                {
                    ctcxTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                    ctcxTo.COD_CLASE = plcTo.COD_CLASE;// en T_PLANILLA NO HAY CLASE
                    ctcxTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    ctcxTo.FE_AÑO = rw["FE_AÑO"].ToString();
                    ctcxTo.FE_MES = rw["FE_MES"].ToString();
                    ctcxTo.COD_PER = rw["COD_PER"].ToString();
                    ctcxTo.COD_DOC = rw["COD_DOC"].ToString();
                    ctcxTo.NRO_DOC = rw["NRO_DOC"].ToString();
                    ctcxTo.FECHA_CONTRATO = rw["FECHA_CONTRATO"].ToString() != "" ? Convert.ToDateTime(rw["FECHA_CONTRATO"]) : DateTime.Now;// NO LO TENGO
                    ctcxTo.FECHA_DOC = Convert.ToDateTime(rw["FECHA_RECEPCION"]).Date + DateTime.Now.TimeOfDay;
                    ctcxTo.FECHA_VEN = rw["FECHA_VEN"].ToString() != "" ? Convert.ToDateTime(rw["FECHA_VEN"]) : (DateTime?)null;
                    ctcxTo.COD_P_COBRANZA = rw["COD_PTO_COB"].ToString();
                    ctcxTo.COD_COBRADOR = rw["COD_COBRADOR"].ToString();
                    ctcxTo.NRO_PLANILLA = rw["NRO_PLANILLA_COB"].ToString();
                    ctcxTo.FECHA_PLANILLA = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]).Date + DateTime.Now.TimeOfDay;
                    ctcxTo.COD_D_H = "H";
                    ctcxTo.COD_MONEDA = "";
                    ctcxTo.TIPO_CAMBIO = rw["TIPO_CAMBIO"].ToString() == "" ? 0 : Convert.ToDecimal(rw["TIPO_CAMBIO"]);//NO LO TENGO
                    ctcxTo.IMP_DOC = Convert.ToDecimal(rw["IMP_COB"]);
                    ctcxTo.OBSERVACION = rw["OBSERVACION"].ToString();
                    ctcxTo.TIPO_OPE = "CP";
                    ctcxTo.NRO_LETRA = rw["NRO_LETRA"].ToString();
                    ctcxTo.TOTAL_LETRA = rw["TOT_LETRA"].ToString();
                    ctcxTo.COD_CONCEPTO = "";
                    ctcxTo.COD_USU_CREA = plcTo.COD_MOD;
                    ctcxTo.FECHA_CREA = plcTo.FECHA_MOD;
                    ctcxTo.TIPO_PLA_COBRANZA = plcTo.TIPO_PLANILLA;
                    ctcxTo.TIPO_PLA_ORIGEN = plcTo.TIPO_PLANILLA.Substring(0, 1);
                    //insertar registro en TCTAS
                    if (!cttxDAL.insertarCanjeTCtasxCobrarRecepcionPlanillaDAL(ctcxTo, ref errMensaje))
                        return result = false;
                    //modifica TCTAS el COD_PTO_COB // ver si esto en la practica es necesario, tenerlo en obs en las pruebas.
                    if (!cttxDAL.modificarTCtasxRecepcionPlanillaDAL(ctcxTo, ref errMensaje))
                        return result = false;
                }
                else if (Convert.ToDecimal(rw["IMP_COB"]) == 0)//hay que ver esto luego
                {
                    //modifica TCTAS el COD_PTO_COB // ver si esto en la practica es necesario, tenerlo en obs en las pruebas.
                    ctcxTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                    ctcxTo.COD_CLASE = plcTo.COD_CLASE;// en T_PLANILLA NO HAY CLASE
                    ctcxTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                    ctcxTo.NRO_DOC = rw["NRO_DOC"].ToString();
                    ctcxTo.COD_USU_CREA = plcTo.COD_MOD;
                    ctcxTo.FECHA_CREA = plcTo.FECHA_MOD;
                    if (!cttxDAL.modificarTCtasxRecepcionPlanillaDAL(ctcxTo, ref errMensaje))
                        return result = false;
                }
            }

            return result;
        }
        public bool Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle_BLL(planillaCabeceraTo plcTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            canjePCtasxCobrarDAL ctpxDAL = new canjePCtasxCobrarDAL();
            canjePCtasxCobrarTo ctcxTo = new canjePCtasxCobrarTo();
            //DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "" || x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "006").CopyToDataTable();//006 EXCESO CONTRATO
            DataTable dtPT = dt.AsEnumerable().Where(x => x.Field<string>("NRO_CONTRATO") != "").CopyToDataTable();
            dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "006").CopyToDataTable();
            dtPT = dtPT.AsEnumerable().Where(x => x.Field<string>("COD_MOTIVO_NO_DESCONTADO") != "007").CopyToDataTable();
            foreach (DataRow rw in dtPT.Rows)
            {
                ctcxTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                ctcxTo.COD_CLASE = plcTo.COD_CLASE;
                ctcxTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                ctcxTo.FE_AÑO = rw["AÑO"].ToString();
                ctcxTo.FE_MES = rw["MES"].ToString();
                ctcxTo.NRO_DOC = rw["NRO_DOC"].ToString();
                ctcxTo.IMP_DOC = Convert.ToDecimal(rw["IMP_COB"]);
                ctcxTo.IMP_COB_CTA_CTE = Convert.ToDecimal(rw["IMP_COB_CTA_CTE"]);
                ctcxTo.COD_USU_MOD = plcTo.COD_MOD;
                ctcxTo.FECHA_MOD = plcTo.FECHA_MOD;
                //ctcxTo.COD_PTO_COB = plcTo.COD_PTO_COB_CONSOLIDADO;
                //INSERTA EN P
                if (!ctpxDAL.Aprueba_Actualiza_Repciona_PCTAS_COBRAR_Planilla_Detalle_DAL(ctcxTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool Aprueba_Adiciona_DEV_TCTAS_COBRAR_BLL(devPCtasCobrarTo dpxTo, ref string errMensaje)
        {
            bool result = true;
            devTCtasCobrarBLL dtxBLL = new devTCtasCobrarBLL();
            devTCtasCobrarTo dtxTo = new devTCtasCobrarTo();
            dtxTo.NRO_PLANILLA_COB = dpxTo.NRO_PLANILLA_COB;
            dtxTo.COD_SUCURSAL = dpxTo.COD_SUCURSAL;
            dtxTo.COD_CLASE = dpxTo.COD_CLASE;
            dtxTo.NRO_CONTRATO = dpxTo.NRO_CONTRATO;
            dtxTo.FE_AÑO = dpxTo.FE_AÑO;
            dtxTo.FE_MES = dpxTo.FE_MES;
            dtxTo.COD_PER = dpxTo.COD_PER;
            dtxTo.DESC_PER = dpxTo.DESC_PER;
            dtxTo.COD_DOC = dpxTo.COD_DOC;
            dtxTo.NRO_DOC = dpxTo.NRO_DOC;
            dtxTo.FECHA_CONTRATO = dpxTo.FECHA_CONTRATO;
            dtxTo.FECHA_DOC = dpxTo.FECHA_DOC;
            dtxTo.FECHA_VEN = dpxTo.FECHA_VEN;
            dtxTo.COD_P_COBRANZA = dpxTo.COD_P_COBRANZA;
            dtxTo.COD_COBRADOR = "";// dpxTo.COD_COBRADOR; por el momento así, parece que no se usa
            dtxTo.NRO_PLANILLA = dpxTo.NRO_PLANILLA_COB;
            dtxTo.FECHA_PLANILLA = dpxTo.FECHA_PLANILLA;
            dtxTo.COD_MOTIVO_NO_DESCONTADO = dpxTo.COD_MOTIVO_NO_DESCONTADO;
            dtxTo.COD_D_H = dpxTo.COD_D_H;
            dtxTo.COD_MONEDA = dpxTo.COD_MONEDA;
            dtxTo.TIPO_CAMBIO = 0;//dpxTo.TIPO_CAMBIO;
            dtxTo.IMP_DOC = dpxTo.IMP_DOC;
            dtxTo.OBSERVACION = dpxTo.OBSERVACION;
            dtxTo.TIPO_OPE = dpxTo.TIPO_OPE;
            dtxTo.NRO_LETRA = dpxTo.NRO_LETRA;
            dtxTo.TOTAL_LETRA = dpxTo.TOTAL_LETRA;
            dtxTo.COD_CONCEPTO = "";//dpxTo.COD_CONCEPTO;
            dtxTo.TIPO_PLA_ORIGEN = dpxTo.TIPO_PLA_ORIGEN;
            dtxTo.TIPO_PLA_COBRANZA = dpxTo.TIPO_PLA_COBRANZA;
            dtxTo.COD_USU_CREA = dpxTo.COD_USU_CREA;
            dtxTo.COD_USU_MOD = dpxTo.COD_USU_MOD;
            dtxTo.FECHA_CREA = DateTime.Now;

            if (!dtxBLL.insertarDevTCtasCobrarBLL(dtxTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool Aprueba_Adiciona_DEV_PCTAS_COBRAR_BLL(planillaCabeceraTo plcTo, DataTable dtPT, ref string errMensaje)
        {
            bool result = true;
            devPCtasCobrarDAL dpxDAL = new devPCtasCobrarDAL();
            devPCtasCobrarTo dpxTo = new devPCtasCobrarTo();
            canjePCtasxCobrarBLL pxcBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pxcTo = new canjePCtasxCobrarTo();
            DataTable dt;

            DataTable dtCloned = dtPT.Clone();
            dtCloned.Columns["IMP_DEV"].DataType = typeof(decimal);
            dtCloned.Columns["IMP_COB_CTA_CTE"].DataType = typeof(decimal);
            foreach (DataRow row in dtPT.Rows)
            {
                if (Convert.ToDecimal(row["IMP_DEV"]) > 0 || Convert.ToDecimal(row["IMP_COB_CTA_CTE"]) > 0)
                    dtCloned.ImportRow(row);
            }
            if (dtCloned.Rows.Count > 0)
            {
                foreach (DataRow rw in dtCloned.Rows)
                {
                    if (Convert.ToDecimal(rw["IMP_DEV"]) > 0 || Convert.ToDecimal(rw["IMP_COB_CTA_CTE"]) > 0)
                    {
                        pxcTo.NRO_DOC = rw["NRO_DOC"].ToString();//nro_doc es la letra
                        dt = pxcBLL.obtener_PCtasCobrar_por_CodDocBLL(pxcTo);//si es una cuota que no es exceso de contrato
                        if (dt.Rows.Count > 0)//X DEV ó X APL
                        {
                            dpxTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                            dpxTo.COD_SUCURSAL = dt.Rows[0]["COD_SUCURSAL"].ToString();
                            dpxTo.COD_CLASE = dt.Rows[0]["COD_CLASE"].ToString();
                            dpxTo.NRO_CONTRATO = dt.Rows[0]["NRO_CONTRATO"].ToString();
                            dpxTo.FE_AÑO = plcTo.FE_AÑO;//dt.Rows[0]["FE_AÑO"].ToString();
                            dpxTo.FE_MES = plcTo.FE_MES;//dt.Rows[0]["FE_MES"].ToString();
                            dpxTo.COD_PER = dt.Rows[0]["COD_PER"].ToString();
                            dpxTo.DESC_PER = dt.Rows[0]["DESC_PER"].ToString();
                            dpxTo.COD_DOC = dt.Rows[0]["COD_DOC"].ToString();
                            dpxTo.NRO_DOC = dt.Rows[0]["NRO_DOC"].ToString();
                            dpxTo.FECHA_DOC = Convert.ToDateTime(dt.Rows[0]["FECHA_DOC"]);
                            dpxTo.FECHA_VEN = Convert.ToDateTime(dt.Rows[0]["FECHA_VEN"]);
                            //dpxTo.IMP_INI = Convert.ToDecimal(dt.Rows[0]["IMP_INI"]);
                            dpxTo.IMP_INI = dpxTo.COD_MOTIVO_NO_DESCONTADO == "006" ? Convert.ToDecimal(rw["IMP_DEV"]) : Convert.ToDecimal(rw["IMP_COB_CTA_CTE"]);//Convert.ToDecimal(dt.Rows[0]["IMP_DOC"]);//aqui estoy poniendo lo que se devolvera aunque creo que era para otra cosa.
                            dpxTo.COD_MOTIVO_NO_DESCONTADO = rw["COD_MOTIVO_NO_DESCONTADO"].ToString();
                            //dpxTo.IMP_DOC = dpxTo.COD_MOTIVO_NO_DESCONTADO == "006" ? Convert.ToDecimal(rw["IMP_DEV"]) : Convert.ToDecimal(rw["IMP_COB_CTA_CTE"]);//Convert.ToDecimal(dt.Rows[0]["IMP_DOC"]);//aqui estoy poniendo lo que se devolvera aunque creo que era para otra cosa.
                            dpxTo.IMP_DOC = dpxTo.IMP_INI;
                            dpxTo.COD_D_H = dt.Rows[0]["COD_D_H"].ToString();
                            dpxTo.OBSERVACION = dt.Rows[0]["OBSERVACION"].ToString();
                            dpxTo.COD_MONEDA = "S";//dt.Rows[0]["COD_MONEDA"].ToString();//esto debe ser traido desde la generacion de pllas, se debe de agregar 
                            dpxTo.TIPO_OPE = dt.Rows[0]["TIPO_OPE"].ToString();
                            dpxTo.NRO_LETRA = dt.Rows[0]["NRO_LETRA"].ToString();
                            dpxTo.TOTAL_LETRA = dt.Rows[0]["TOTAL_LETRA"].ToString();
                            dpxTo.STATUS_GENERADO = "0";//dt.Rows[0]["STATUS_GENERADO"].ToString();
                            dpxTo.STATUS_CANCELADO = "0";//dt.Rows[0]["STATUS_CANCELADO"].ToString();
                            dpxTo.TIPO_PLA_ORIGEN = dt.Rows[0]["TIPO_PLA_ORIGEN"].ToString();
                            dpxTo.TIPO_PLA_COBRANZA = dpxTo.COD_MOTIVO_NO_DESCONTADO == "004" ? "PA" : "PS";//exceso cuota ó devolucion suspendido
                            dpxTo.COD_USU_CREA = plcTo.COD_MOD;
                            dpxTo.FECHA_CREA = plcTo.FECHA_MOD;
                            dpxTo.FECHA_CONTRATO = Convert.ToDateTime(dt.Rows[0]["FECHA_PRE"]);
                            dpxTo.COD_P_COBRANZA = dt.Rows[0]["COD_PTO_COB"].ToString();
                            dpxTo.FECHA_PLANILLA = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                        }
                        else if (rw["NRO_CONTRATO"].ToString() != "")//Devolucion exceso contrato
                        {
                            contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
                            contratoCabeceraTo ccTo = new contratoCabeceraTo();
                            ccTo.NRO_PRESUPUESTO = rw["NRO_CONTRATO"].ToString();
                            DataTable dtCon = ccBLL.obtenerDatosdeContratoBLL(ccTo);
                            if (dtCon.Rows.Count > 0)
                            {
                                dpxTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                                dpxTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                                dpxTo.COD_CLASE = plcTo.COD_CLASE;
                                dpxTo.NRO_CONTRATO = rw["NRO_CONTRATO"].ToString();
                                dpxTo.FE_AÑO = plcTo.FE_AÑO;
                                dpxTo.FE_MES = plcTo.FE_MES;
                                dpxTo.COD_PER = rw["COD_PER"].ToString();//"";
                                dpxTo.DESC_PER = dtCon.Rows[0]["DESC_PER"].ToString();
                                dpxTo.COD_DOC = "";
                                dpxTo.NRO_DOC = "0000000";
                                dpxTo.FECHA_DOC = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                                dpxTo.FECHA_VEN = rw["FECHA_VEN"].ToString() != "" ? Convert.ToDateTime(rw["FECHA_VEN"]) : (DateTime?)null;
                                dpxTo.IMP_INI = Convert.ToDecimal(rw["IMP_COB"]);// 0;
                                dpxTo.IMP_DOC = Convert.ToDecimal(rw["IMP_COB"]);//aqui estoy poniendo lo que se devolvera aunque creo que era para otra cosa. DEBE SER IMP_DEV
                                dpxTo.COD_MOTIVO_NO_DESCONTADO = "006";
                                dpxTo.COD_D_H = "D";
                                dpxTo.OBSERVACION = "";
                                dpxTo.COD_MONEDA = "S";
                                dpxTo.TIPO_OPE = "GF";
                                dpxTo.NRO_LETRA = "000";
                                dpxTo.TOTAL_LETRA = "000";
                                dpxTo.STATUS_GENERADO = "0";
                                dpxTo.STATUS_CANCELADO = "0";
                                dpxTo.TIPO_PLA_ORIGEN = "P";
                                dpxTo.TIPO_PLA_COBRANZA = "DE";//devolucion exceso contrato
                                dpxTo.COD_USU_CREA = plcTo.COD_MOD;
                                dpxTo.FECHA_CREA = plcTo.FECHA_MOD;
                                dpxTo.FECHA_CONTRATO = null;
                                dpxTo.COD_P_COBRANZA = dtCon.Rows[0]["COD_PTO_COB"].ToString();
                                dpxTo.FECHA_PLANILLA = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                            }
                        }
                        else //INDEBIDOS
                        {
                            //aqui saca de maestro_indebido
                            //crea las clases para indebido
                            personaIndebidaBLL pibBLL = new personaIndebidaBLL();
                            personaIndebidaTo pibTo = new personaIndebidaTo();
                            pibTo.NRO_PLANILLA_COB = plcTo.NRO_PLANILLA_COB;
                            pibTo.COD_INSTITUCION = plcTo.COD_INSTITUCION;
                            pibTo.COD_PTO_COB_CONSOLIDADO = plcTo.COD_PTO_COB_CONSOLIDADO;
                            pibTo.COD_CANAL_DSCTO = plcTo.COD_CANAL_DSCTO;
                            pibTo.FE_AÑO = plcTo.FE_AÑO;
                            pibTo.FE_MES = plcTo.FE_MES;
                            pibTo.DESC_PER = rw["DESC_PER"].ToString();
                            DataTable dtPer = pibBLL.mostrarPersonaIndebidaBLL(pibTo);
                            if (dtPer.Rows.Count > 0)
                            {
                                dpxTo.NRO_PLANILLA_COB = rw["NRO_PLANILLA_COB"].ToString();
                                dpxTo.COD_SUCURSAL = plcTo.COD_SUCURSAL;
                                dpxTo.COD_CLASE = plcTo.COD_CLASE;
                                dpxTo.NRO_CONTRATO = "";
                                dpxTo.FE_AÑO = plcTo.FE_AÑO;
                                dpxTo.FE_MES = plcTo.FE_MES;
                                dpxTo.COD_PER = "";
                                dpxTo.DESC_PER = rw["DESC_PER"].ToString();
                                dpxTo.COD_DOC = "";
                                dpxTo.NRO_DOC = "0000000";
                                dpxTo.FECHA_DOC = Convert.ToDateTime(dtPer.Rows[0]["FECHA_PLANILLA_COB"]);
                                dpxTo.FECHA_VEN = Convert.ToDateTime(dtPer.Rows[0]["FECHA_PLANILLA_COB"]);
                                dpxTo.IMP_INI = Convert.ToDecimal(dtPer.Rows[0]["IMP_COB"]);//0;
                                dpxTo.IMP_DOC = Convert.ToDecimal(dtPer.Rows[0]["IMP_COB"]);//aqui estoy poniendo lo que se devolvera aunque creo que era para otra cosa.
                                dpxTo.COD_MOTIVO_NO_DESCONTADO = "005";
                                dpxTo.COD_D_H = "D";
                                dpxTo.OBSERVACION = "";
                                dpxTo.COD_MONEDA = "S";
                                dpxTo.TIPO_OPE = "GF";
                                dpxTo.NRO_LETRA = "000";
                                dpxTo.TOTAL_LETRA = "000";
                                dpxTo.STATUS_GENERADO = "0";
                                dpxTo.STATUS_CANCELADO = "0";
                                dpxTo.TIPO_PLA_ORIGEN = "P";
                                dpxTo.TIPO_PLA_COBRANZA = "DI";//indebidos
                                dpxTo.COD_USU_CREA = plcTo.COD_MOD;
                                dpxTo.FECHA_CREA = plcTo.FECHA_MOD;
                                dpxTo.FECHA_CONTRATO = null;
                                dpxTo.COD_P_COBRANZA = "";
                                dpxTo.FECHA_PLANILLA = Convert.ToDateTime(rw["FECHA_PLANILLA_COB"]);
                            }
                        }
                        //DEV_PCTAS_COBRAR
                        if (!dpxDAL.insertarDevPCtasCobrarDAL(dpxTo, ref errMensaje))
                            return result = false;
                        //DEV_TCTAS_COBRAR
                        if (!Aprueba_Adiciona_DEV_TCTAS_COBRAR_BLL(dpxTo, ref errMensaje))
                            return result = false;
                    }
                }
            }
            //else
            //{
            //    StringBuilder sb = new StringBuilder();
            //    foreach(DataRow rw in dtPT.Rows)
            //    {
            //        sb.Append(rw["IMP_DEV"].ToString() + " " + rw["IMP_COB_CTA_CTE"].ToString()+"\n");
            //    }
            //    MessageBox.Show(sb.ToString());
            //}
            return result;

        }
        public DataTable obtener_Consulta_I_Planilla_BLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtener_Consulta_I_Planilla_DAL(plcTo);
        }
        public DataTable obtener_R_Planilla_BLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtener_R_Planilla_DAL(plcTo);
        }
        public DataTable obtenerPtosCobranzaConsolidadosGeneradosXmesBLL(string MES, string AÑO)
        {
            return plcDAL.obtenerPtosCobranzaConsolidadosGeneradosXmesDAL(MES, AÑO);
        }
        public bool Retornar_a_Generacion_BLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.Retornar_a_Generacion_DAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool Aprobar_R_PlanillaBLL(planillaCabeceraTo plcTo, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.Aprobar_R_PlanillaDAL(plcTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerPlanillaNoEnviadaBLLporPtoCobranzaBLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtenerPlanillaNoEnviadaBLLporPtoCobranzaDAL(plcTo);
        }
        public DataTable obtenerPlanillaInformativaBLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtenerPlanillaInformativaDAL(plcTo);
        }
        public bool generaPlanillaInformativaBLL(planillaCabeceraTo plcTo, string ruta, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //Genera archivos
                if (!genera_Archivos_PtoCobBLL(plcTo, ruta, dt))
                    return result = false;
                //Exportacion
                if (!ExportarDataGridViewExcel(plcTo, ruta, dt))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public DataTable obtenerNroPlanillaparaRepEnviadosBLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtenerNroPlanillaparaRepEnviadosDAL(plcTo);
        }
        public bool adicionaBucleTablaParametrosBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                if (!adicionaTablaParametrosBLL(rw["NRO_PLANILLA_COB"].ToString(), ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool adicionaTablaParametrosBLL(string nro_planilla, ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.adicionaTablaParametrosDAL(nro_planilla, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaTablaParamPlanillaBLL(ref string errMensaje)
        {
            bool result = true;
            if (!plcDAL.eliminaTablaParamPlanillaDAL(ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerReportePlanillaCobInternaEnviadaDetalleBLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtenerReportePlanillaCobInternaEnviadaDetalleDAL(plcTo);
        }
        public DataTable reportePlanillaInformativaBLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.reportePlanillaInformativaDAL(plcTo);
        }
        public DataTable obtenerPlanillaDescuentoCabeceraxNroPllaBLL(planillaCabeceraTo plcTo)
        {
            return plcDAL.obtenerPlanillaDescuentoCabeceraxNroPllaDAL(plcTo);
        }

        public DataTable AnalisisCarteraXTrabajar(CancellationToken cancellationToken, DateTime fechaReporte)
        {
            return plcDAL.AnalisisCarteraXTrabajar(cancellationToken, fechaReporte);
        }
    }
}
