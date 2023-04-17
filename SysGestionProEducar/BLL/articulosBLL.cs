using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class articulosBLL
    {
        articulosDAL artDAL = new articulosDAL();
        articulosTo artTo = new articulosTo();
        articuloClaseBLL arcBLL = new articuloClaseBLL();
        articuloClaseTo arcTo = new articuloClaseTo();
        articuloUbicacionBLL aruBLL = new articuloUbicacionBLL();
        articuloUbicacionTo aruTo = new articuloUbicacionTo();
        articuloContenidoBLL atcBLL = new articuloContenidoBLL();
        articuloContenidoTo atcTo = new articuloContenidoTo();
        public DataTable obtenerArticulosBLL()
        {
            return artDAL.obtenerArticulosDAL();
        }
        public bool adicionaInsertaArticulosBLL(articulosTo artTo, DataTable dtArtClase, DataTable dtArtUbicacion,
            DataTable dtArtContenido, string COD_ARTICULO, string DESC_CARACTERISTICA, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //adiciona Articulo
                if (!artDAL.insertaArticuloDAL(artTo, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_CLASE
                if (!adicionaArticuloClase(artTo, dtArtClase, 0, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_UBICACION
                if (!adicionaArticuloUbicacion(artTo, dtArtUbicacion, 0, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_CONTENIDO
                if (artTo.STATUS_DETALLE == "1")
                {
                    if (!adicionaArticuloContenidoBLL(artTo, dtArtContenido, 0, ref errMensaje))
                        return result = false;
                }
                if (DESC_CARACTERISTICA != "")
                {
                    //adiciona en ARTICULO_CARACTERISTICA
                    if (!adicionaArticuloCaracteristicaBLL(COD_ARTICULO, DESC_CARACTERISTICA, ref errMensaje))
                        return result = false;
                }
                ts.Complete();
                return result;
            }
        }
        public bool adicionaArticuloClase(articulosTo artTo, DataTable dt, int k, ref string errMensaje)
        {
            bool result = true;
            //se elimina para luego adicionarlo
            if (k > 0)
            {
                if (!arcBLL.eliminaArticuloClaseBLL(artTo.COD_ARTICULO, ref errMensaje))
                    return result = false;
            }
            //adiciona
            foreach (DataRow rw in dt.Rows)
            {
                arcTo.COD_ARTICULO = artTo.COD_ARTICULO;
                arcTo.COD_CLASE = rw["codcla"].ToString();
                arcTo.COD_GRUPO = rw["codgru"].ToString();
                arcTo.COD_SUBGRUPO = rw["codsub"].ToString();
                arcTo.STOCK_MINIMO = Convert.ToDecimal(rw["min"]);
                arcTo.STOCK_MAXIMO = Convert.ToDecimal(rw["max"]);
                arcTo.FACTOR_CONVERSION1 = 0;
                arcTo.U_MEDIDA1 = "";
                arcTo.FACTOR_CONVERSION2 = 0;
                arcTo.U_MEDIDA2 = "";
                if (!arcBLL.insertaArticuloClaseBLL(arcTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool adicionaArticuloUbicacion(articulosTo artTo, DataTable dt, int k, ref string errMensaje)
        {
            bool result = true;
            //se elimina para luego adicionarlo
            if (k > 0)
            {
                if (!aruBLL.eliminaArticuloUbicacionBLL(artTo.COD_ARTICULO, ref errMensaje))
                    return result = false;
            }
            //adiciona
            foreach (DataRow rw in dt.Rows)
            {
                aruTo.COD_ARTICULO = artTo.COD_ARTICULO;
                aruTo.COD_ALMACEN = rw["COD_ALMACEN"].ToString();
                aruTo.ITEM = rw["item1"].ToString();
                aruTo.CAMPO1 = rw["CAMPO1"].ToString();
                aruTo.CAMPO2 = rw["CAMPO2"].ToString();
                aruTo.CAMPO3 = rw["CAMPO3"].ToString();
                aruTo.CAMPO4 = rw["CAMPO4"].ToString();
                if (!aruBLL.insertaArticuloUbicacionBLL(aruTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool adicionaArticuloContenidoBLL(articulosTo artTo, DataTable dt, int k, ref string errMensaje)
        {
            bool result = true;
            //se elimina para luego adicionarlo
            if (k > 0)
            {
                if (!atcBLL.eliminaArticuloContenidoBLL(artTo.COD_ARTICULO, ref errMensaje))
                    return result = false;
            }
            //adiciona
            foreach (DataRow rw in dt.Rows)
            {
                atcTo.COD_ARTICULO = rw["cod_art"].ToString();
                atcTo.COD_ART_CONTENIDO = rw["cod_art_cont"].ToString();
                atcTo.DESC_ARTICULO = rw["desc_art_cont"].ToString();
                atcTo.ST_SUSPENDIDO = rw["st_sus_cont"].ToString();
                if (!atcBLL.insertaArticuloContenidoBLL(atcTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool modificaActualizaArticulosBLL(articulosTo artTo, DataTable dtArtClase, DataTable dtArtUbicacion,
             DataTable dtArtContenido, string COD_ARTICULO, string DESC_CARACTERISTICA, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //modifica Articulo
                if (!artDAL.modificaArticuloDAL(artTo, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_CLASE
                if (!adicionaArticuloClase(artTo, dtArtClase, 1, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_UBICACION
                if (!adicionaArticuloUbicacion(artTo, dtArtUbicacion, 1, ref errMensaje))
                    return result = false;
                //adiciona en ARTICULO_CONTENIDO
                if (artTo.STATUS_DETALLE == "1")
                {
                    if (!adicionaArticuloContenidoBLL(artTo, dtArtContenido, 1, ref errMensaje))
                        return result = false;
                }
                //modifica ARTICULO_CARACTERISTICA
                if (!artDAL.modificaArticuloCaracteristicaDAL(COD_ARTICULO, DESC_CARACTERISTICA, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public string obtenerNuevoCodigoBLL()
        {
            return artDAL.obtenerNuevoCodigoDAL();
        }
        public string obtenerImagenBLL(articulosTo artTo)
        {
            return artDAL.obtenerImagenDAL(artTo);
        }
        public bool adicionaArticuloCaracteristicaBLL(string COD_ARTICULO, string DESC_CARACTERISTICA, ref string errMensaje)
        {
            bool result = true;
            if (!artDAL.adicionaArticuloCaracteristicaDAL(COD_ARTICULO, DESC_CARACTERISTICA, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaArticuloBLL(string COD_ARTICULO, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //elimina Articulo_Clase
                if (!arcBLL.eliminaArticuloClaseBLL(COD_ARTICULO, ref errMensaje))
                    return result = false;
                //elimina Articulo_Ubicacion
                if (!aruBLL.eliminaArticuloUbicacionBLL(COD_ARTICULO, ref errMensaje))
                    return result = false;
                //elimina Articulo_Contenido
                if (!atcBLL.eliminaArticuloContenidoBLL(COD_ARTICULO, ref errMensaje))
                    return result = false;
                //elimina Articulo_Caracteristica
                if (!artDAL.eliminaArticuloCaracteristicaDAL(COD_ARTICULO, ref errMensaje))
                    return result = false;
                //elimina Articulo
                if (!artDAL.eliminaArticuloDAL(COD_ARTICULO, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        public DataTable obtenerArticulosparaKitBLL(articulosTo artTo)
        {
            return artDAL.obtenerArticulosparaKitDAL(artTo);
        }
        public DataTable CARGAR_SALDOS_CLASE_ARTICULO(string CodigoClase, string CodigoArticulo)
        {
            return artDAL.CARGAR_SALDOS_CLASE_ARTICULO(CodigoClase, CodigoArticulo);
        }
        public DataTable MOSTRAR_ARTICULO_APLICACION(string CodigoArticulo)
        {
            return artDAL.MOSTRAR_ARTICULO_APLICACION(CodigoArticulo);
        }
        public string HALLAR_UM_ARTICULO_BLL(string codigoArticulo)
        {
            return artDAL.HALLAR_UM_ARTICULO_DAL(codigoArticulo);
        }
        public string OBTENER_SALDO_BLL(articulosTo artTo)
        {
            return artDAL.OBTENER_SALDO_DAL(artTo);
        }
        public int VerificaArticuloBLL(articulosTo artTo)
        {
            return artDAL.VerificaArticuloDAL(artTo);
        }
        public bool validaEliminarArticuloBLL(articulosTo artTo, ref string errMensaje)
        {
            bool result = true;
            if (!artDAL.validaEliminarArticuloDAL(artTo, ref errMensaje))
                return result = false;
            return result;
        }
        public string obtenerSaldoProductoxTransferenciaBLL(articulosTo artTo)
        {
            return artDAL.obtenerSaldoProductoxTransferenciaDAL(artTo);
        }
        public DataTable obtenerArticulos_con_ContenidoBLL()
        {
            return artDAL.obtenerArticulos_con_ContenidoDAL();
        }
    }

}
