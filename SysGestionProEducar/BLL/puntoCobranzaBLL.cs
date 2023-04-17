using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class puntoCobranzaBLL
    {
        puntoCobranzaDAL ptoDAL = new puntoCobranzaDAL();
        puntoCobranzaTo ptoTo = new puntoCobranzaTo();
        public DataTable obtenerPuntosCobranzaBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPuntosCobranzaDAL(ptoTo);
        }
        public DataTable obtenerPuntosCobranza_x_Inst_BLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPuntosCobranza_x_Inst_DAL(ptoTo);
        }
        public DataTable obtenerPuntosCobranzaConsolidadoInformativoBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPuntosCobranzaConsolidadoInformativoDAL(ptoTo);
        }
        public DataTable obtenerPuntosCobranzaConsolidadoInformativo_x_Inst_BLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPuntosCobranzaConsolidadoInformativo_x_Inst_DAL(ptoTo);
        }
        public DataTable obtenerPuntosCobranzaHastaFecVenBLL(DateTime FECHA_VEN, string COD_SECTORISTA, string COD_CANAL_DSCTO, string TIPO_PLANILLA, string COD_PROGRAMA)
        {
            canjePCtasxCobrarBLL pctasBLL = new canjePCtasxCobrarBLL();
            canjePCtasxCobrarTo pctasTo = new canjePCtasxCobrarTo();
            pctasTo.FECHA_VEN = FECHA_VEN;
            pctasTo.COD_SECTORISTA = COD_SECTORISTA;
            pctasTo.COD_CANAL_DSCTO = COD_CANAL_DSCTO;
            pctasTo.TIPO_PLA_COBRANZA = TIPO_PLANILLA;
            pctasTo.COD_PROGRAMA = COD_PROGRAMA;
            return pctasBLL.obtenerPuntosCobranzaHastaFecVenBLL(pctasTo);
        }
        public bool insertarPuntoCobranzaBLL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptoDAL.insertarPuntoCobranzaDAL(ptoTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerSectoristaPuntosCobranzaBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerSectoristaPuntosCobranzaDAL(ptoTo);
        }
        public DataTable obtenerPtoCobranzaxPtoCobConsolidadoBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPtoCobranzaxPtoCobConsolidadoDAL(ptoTo);
        }
        public DataTable obtenerPtoCobranzaxPtoCobBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPtoCobranzaxPtoCobDAL(ptoTo);
        }
        public DataTable obtenerTodosPuntosCobranzaBLL()
        {
            return ptoDAL.obtenerTodosPuntosCobranzaDAL();
        }
        public DataTable obtenerPuntosCobranzaVisaBLL()
        {
            return ptoDAL.obtenerPuntosCobranzaVisaDAL();
        }
        public bool modificarPuntoCobranzaBLL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptoDAL.modificarPuntoCobranzaDAL(ptoTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarPuntoCobranzaBLL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //eliminina registro de Punto de Cobranza
                if (!ptoDAL.eliminarPuntoCobranzaDAL(ptoTo, ref errMensaje))
                    return result = false;
                //elimina vinculaciones
                if (ptoTo.STATUS_CONSOLIDADO == true)
                {
                    //elimina registro de Punto de Cobranza Vinculado, si sí es consolidado
                    string cod_cons = ptoTo.COD_PTO_COB;
                    if (!ptoDAL.eliminaPuntoCobranzaVinculadosDAL(cod_cons, ref errMensaje))
                        return result = false;
                }
                else
                {
                    //elimina registro de Punto de Cobranza Vinculado, si no es consolidado
                    if (!ptoDAL.eliminaPuntoCobranzaVinculadodeConsolidadoDAL(ptoTo, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        public DataTable obtenerPuntoCobranzaVinculadosBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPuntoCobranzaVinculadosDAL(ptoTo);
        }

        public DataTable obtenerPuntoCobranzaVinculadosInformativoBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.obtenerPuntoCobranzaVinculadosInformativoDAL(ptoTo);
        }
        public bool insertarPtoCobVinculadosBLL(puntoCobranzaTo ptoTo, DataTable dt, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                if (ptoTo.op == 1)
                {
                    // no se puede actualizar puntos de venta desde aca, se debe hacer de formulario Punto de Venta

                    //if(dt.Rows.Count > 0)
                    //{
                    //    ////eliminar pto_cob
                    //    //if (!eliminarPuntoCobranzaVinculadosBLL(dt.Rows[0][0].ToString(), ref errMensaje))
                    //    //    return result = false;
                    //    ////adicionar pto_cob
                    //    //if (!insertaPuntoCobranzaConsolidadoBLL(dt, ref errMensaje))
                    //    //    return result = false;

                    //    ////actualiza Pto de Venta // no se puede actualizar puntos de venta desde aca, se debe hacer de formulario Punto de Venta
                    //    //if (!modificaPuntodeVentaDetalleBLL(ptoTo, dt, ref errMensaje))
                    //    //    return result = false;
                    //}
                    //else
                    //{
                    //    //si no hay nada en el dt es que quito todas las vinculaciones, por lo que se debe de eliminar todo de ese consolidado
                    //    if (!eliminaPuntoCobranzaVinculadoTodosBLL(ptoTo, ref errMensaje))
                    //        return result = false;
                    //}
                }
                else if (ptoTo.op == 2)
                {
                    if (dt.Rows.Count > 0)
                    {
                        //eliminar pto_cob
                        if (!eliminarPuntoCobranzaVinculadosInformativoBLL(dt.Rows[0][0].ToString(), ref errMensaje))
                            return result = false;
                        //adicionar pto_cob
                        if (!insertaPuntoCobranzaConsolidadoInformativoBLL(dt, ref errMensaje))
                            return result = false;
                    }
                    else
                    {
                        //si no hay nada en el dt es que quito todas las vinculaciones, por lo que se debe de eliminar todo de ese consolidado
                        if (!eliminaPuntoCobranzaVinculadoTodosInformativoBLL(ptoTo, ref errMensaje))
                            return result = false;
                    }

                }
                ////eliminar sucursal
                //if (!eliminarSucursalVinculadosBLL(dt1.Rows[0][1].ToString(), ref errMensaje))
                //    return result = false;
                ////adicionar sucursal
                //if (!insertarSucursalVinculadosBLL(dt1, ref errMensaje))
                //    return result = false;
                ////eliminar institucion
                //if (!eliminarInstitucionVinculadaBLL(dt2.Rows[0][1].ToString(), ref errMensaje))
                //    return result = false;
                ////adicionar institucion
                //if (!insertarInstitucionVinculadaBLL(dt2, ref errMensaje))
                //    return result = false;
                ////eliminar canal de descuento
                //if (!eliminarCanalDsctoVinculadoBLL(dt3.Rows[0][1].ToString(), ref errMensaje))
                //    return result = false;
                ////adicionar canal de descuento
                //if (!insertarCanalDsctoVinculadoBLL(dt3, ref errMensaje))
                //    return result = false;
                //
                ts.Complete();
                return result;
            }

        }
        private bool modificaPuntodeVentaDetalleBLL(puntoCobranzaTo ptoTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            puntoVentaBLL ptoVenBLL = new puntoVentaBLL();
            puntoVentaTo ptoVenTo = new puntoVentaTo();
            foreach (DataRow rw in dt.Rows)
            {
                ptoVenTo.COD_INSTITUCION = ptoTo.COD_INSTITUCION;
                ptoVenTo.COD_PTO_VEN = rw[1].ToString();
                ptoVenTo.COD_PTO_COB = ptoTo.COD_PTO_COB_CONS;

                if (!ptoVenBLL.modificaPuntoVentaDetalleBLL(ptoVenTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool eliminaPuntoCobranzaVinculadoTodosBLL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptoDAL.eliminaPuntoCobranzaVinculadoTodosDAL(ptoTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminaPuntoCobranzaVinculadoTodosInformativoBLL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptoDAL.eliminaPuntoCobranzaVinculadoTodosInformativoDAL(ptoTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminarPuntoCobranzaVinculadosBLL(string cod_cons, ref string errMensaje)
        {
            bool result = true;
            if (!ptoDAL.eliminaPuntoCobranzaVinculadosDAL(cod_cons, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminarPuntoCobranzaVinculadosInformativoBLL(string cod_cons, ref string errMensaje)
        {
            bool result = true;
            if (!ptoDAL.eliminaPuntoCobranzaVinculadosInformativoDAL(cod_cons, ref errMensaje))
                return result = false;
            return result;
        }
        private bool insertaPuntoCobranzaConsolidadoBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                ptoTo.COD_PTO_COB_CONS = rw[0].ToString();
                ptoTo.COD_PTO_COB = rw[1].ToString();
                if (!ptoDAL.insertarPtoCobVinculadosDAL(ptoTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool insertaPuntoCobranzaConsolidadoInformativoBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                ptoTo.COD_PTO_COB_CONS = rw[0].ToString();
                ptoTo.COD_PTO_COB = rw[1].ToString();
                if (!ptoDAL.insertarPtoCobVinculadosInformativoDAL(ptoTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        //private bool eliminarSucursalVinculadosBLL(string cod_cons, ref string errMensaje)
        //{
        //    bool result = true;
        //    if (!ptoDAL.eliminaSucursalVinculadosDAL(cod_cons, ref errMensaje))
        //        return result = false;
        //    return result;
        //}
        //private bool insertarSucursalVinculadosBLL(DataTable dt1, ref string errMensaje)
        //{
        //    bool result = true;
        //    foreach (DataRow rw in dt1.Rows)
        //    {
        //        ptoTo.COD_PTO_COB_CONS = rw[0].ToString();
        //        ptoTo.COD_SUCURSAL = rw[1].ToString();
        //        if (!ptoDAL.insertarSucursalVinculadosDAL(ptoTo, ref errMensaje))
        //            return result = false;
        //    }
        //    return result;
        //}
        //private bool eliminarInstitucionVinculadaBLL(string cod_cons, ref string errMensaje)
        //{
        //    bool result = true;
        //    if (!ptoDAL.eliminarInstitucionVinculadaDAL(cod_cons, ref errMensaje))
        //        return result = false;
        //    return result;
        //}
        //private bool insertarInstitucionVinculadaBLL(DataTable dt2, ref string errMensaje)
        //{
        //    bool result = true;
        //    foreach (DataRow rw in dt2.Rows)
        //    {
        //        ptoTo.COD_PTO_COB_CONS = rw[0].ToString();
        //        ptoTo.COD_INSTITUCION = rw[1].ToString();
        //        if (!ptoDAL.insertarInstitucionVinculadaDAL(ptoTo, ref errMensaje))
        //            return result = false;
        //    }
        //    return result;
        //}
        //private bool eliminarCanalDsctoVinculadoBLL(string cod_cons, ref string errMensaje)
        //{
        //    bool result = true;
        //    if (!ptoDAL.eliminarCanalDsctoVinculadoDAL(cod_cons, ref errMensaje))
        //        return result = false;
        //    return result;
        //}
        //private bool insertarCanalDsctoVinculadoBLL(DataTable dt3, ref string errMensaje)
        //{
        //    bool result = true;
        //    foreach (DataRow rw in dt3.Rows)
        //    {
        //        ptoTo.COD_PTO_COB_CONS = rw[0].ToString();
        //        ptoTo.COD_CANAL_DSCTO = rw[1].ToString();
        //        if (!ptoDAL.insertarCanalDsctoVinculadoDAL(ptoTo, ref errMensaje))
        //            return result = false;
        //    }
        //    return result;
        //}
        public int verificaPuntoCobranzaBLL(puntoCobranzaTo ptoTo)
        {
            return ptoDAL.verificaPuntoCobranzaDAL(ptoTo);
        }
        public bool validaHistoricoPedidoBLL(puntoCobranzaTo ptoTo, ref string errMensaje)
        {
            bool result = true;
            if (!ptoDAL.validaHistoricoPedidoDAL(ptoTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable ObtenerPtoCobranzaCantPlanillaBLL(string año, string mes)
        {
            return ptoDAL.ObtenerPtoCobranzaCantPlanillaDAL(año, mes);
        }

        public DataTable ObtenerPuntoCobranzaXPlanillasTrasnferidasBLL(string codPais)
        {
            return ptoDAL.ObtenerPuntoCobranzaXPlanillasTrasnferidasDAL(codPais);
        }

        public DataTable ListarPtoCobranzaCheques(string codPais)
        {
            return ptoDAL.ListarPtoCobranzaCheques(codPais);
        }

        public DataTable ListarPtoCobranza()
        {
            return ptoDAL.ListarPtoCobranza();
        }

        public DataTable ObtenerPtoCobranzaCheques(string codPais, string codPtoCob)
        {
            return ptoDAL.ObtenerPtoCobranzaCheques(codPais, codPtoCob);
        }

        public DataTable ListarPtoCobranzaXPais(string codPais)
        {
            return ptoDAL.ListarPtoCobranzaXPais(codPais);
        }
    }
}
