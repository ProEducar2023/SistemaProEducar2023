namespace Entidades
{
    public class facturacionVtaDetalleTo
    {
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string COD_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public string COD_PER { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string ITEM { get; set; }
        public string COD_DOC_GUIA { get; set; }
        public string NRO_DOC_GUIA { get; set; }
        public string NRO_PEDIDO { get; set; }
        public string COD_ARTICULO { get; set; }
        public decimal CANTIDAD { get; set; }
        public string COD_D_H { get; set; }
        public string COD_MONEDA { get; set; }
        public decimal PRECIO_UNITARIO { get; set; }
        public decimal VALOR_COMPRA { get; set; }
        public decimal POR_IGV { get; set; }
        public decimal POR_DSCTO { get; set; }
        public string STATUS_IGV { get; set; }
        public decimal VALOR_IGV { get; set; }
        public decimal VALOR_DSCTO { get; set; }
        public decimal AJUSTE_IGV { get; set; }
        public decimal AJUSTE_BI { get; set; }
        public string NRO_ITEM { get; set; }
        public string OBSERVACION { get; set; }
        public string NRO_SALIDA { get; set; }
        public string TIPO_PRECIO { get; set; }
        public string NRO_INGRESO { get; set; }
        public decimal VALOR_REFERENCIAL { get; set; }
        public decimal VALOR_IGV_REF { get; set; }
    }
}
