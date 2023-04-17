using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class serieDocumentoBLL
    {
        serieDocumentosDAL sdoDAL = new serieDocumentosDAL();
        serieDocumentosTo sdoTo = new serieDocumentosTo();

        public DataTable obtenerSerieDocumentoBLL()
        {
            return sdoDAL.obtenerSerieDocumentoDAL();
        }
        public bool insertarSerieDocumentoBLL(serieDocumentosTo sdoTo, ref string errMensaje)
        {
            bool result = true;
            if (!sdoDAL.insertarSerieDocumentoDAL(sdoTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarSerieDocumentoBLL(serieDocumentosTo sdoTo, ref string errMensaje)
        {
            bool result = true;
            if (!sdoDAL.modificarSerieDocumentoDAL(sdoTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarSerieDocumentoBLL(serieDocumentosTo sdoTo, ref string errMensaje)
        {
            bool result = true;
            if (!sdoDAL.eliminarSerieDocumentoDAL(sdoTo, ref errMensaje))
                return result = false;
            return result;
        }
        public int obtenerNro_IngBLL(serieDocumentosTo sdoTo)
        {
            return sdoDAL.obtenerNro_IngDAL(sdoTo);
        }
        public string obtenerNro_Ing2BLL(serieDocumentosTo sdoTo)
        {
            return sdoDAL.obtenerNro_Ing2DAL(sdoTo);
        }
        public string HALLAR_NRO_ACTUAL(serieDocumentosTo sdoTo)
        {
            return sdoDAL.HALLAR_NRO_ACTUAL(sdoTo);
        }
        public DataTable OBTENER_SERIE_NRO_BLL(serieDocumentosTo sdoTo)
        {
            return sdoDAL.OBTENER_SERIE_NRO_DAL(sdoTo);
        }
        public bool adicionaNroSerieBLL(serieDocumentosTo sdoTo, ref string errMensaje)
        {
            return sdoDAL.adicionaNroSerieDAL(sdoTo, ref errMensaje);
        }
        public int verificaSerieDocumentoBLL(serieDocumentosTo sdoTo)
        {
            return sdoDAL.verificaSerieDocumentoDAL(sdoTo);
        }
        public DataTable CBO_NRO_NOTAS_TRANS(serieDocumentosTo srdTo)
        {
            return sdoDAL.CBO_NRO_NOTAS_TRANS(srdTo);
        }
        public DataTable obtenerSerieDocumentoparaFacturacionBLL(serieDocumentosTo srdTo)
        {
            return sdoDAL.obtenerSerieDocumentoparaFacturacionDAL(srdTo);
        }
        public int obtenerNumeroSerieDocumentoparaFacturacionBLL(serieDocumentosTo sdoTo)
        {
            return sdoDAL.obtenerNumeroSerieDocumentoparaFacturacionDAL(sdoTo);
        }
    }
}
