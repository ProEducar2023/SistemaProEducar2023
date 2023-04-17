using System;
namespace Entidades
{
    public class facturacionVtaCabeceraTo
    {
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string COD_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public string COD_PER { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string NRO_DOC_PER { get; set; }
        public DateTime FECHA_DOC { get; set; }
        public DateTime FECHA_VEN { get; set; }
        public string COD_MONEDA { get; set; }
        public decimal TIPO_CAMBIO { get; set; }
        public string OBSERVACION { get; set; }
        public string TIPO_ORIGEN { get; set; }
        public string COD_D_H { get; set; }
        public string STATUS_CIERRE { get; set; }
        public string NRO_PEDIDO { get; set; }
        public string STATUS_PV { get; set; }
        public string COD_VENDEDOR { get; set; }
        public string STATUS_ANUL { get; set; }
        public string COD_REF { get; set; }
        public string NRO_REF { get; set; }
        public DateTime? FECHA_REF { get; set; }
        public string NRO_SALIDA { get; set; }
        public string NRO_GUIA { get; set; }
        public string COD_USU_CREA { get; set; }
        public string COD_USU_MOD { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public string NOMBRE_PC { get; set; }
        public string SERIE2 { get; set; }
        public string TIPO_USU { get; set; }
        public string COD_USU { get; set; }
        public string ST_TIP_VTA { get; set; }
        public string NRO_PRESUPUESTO { get; set; }
        public string COD_MOT_DEV { get; set; }
        public string STATUS_DEV { get; set; }
        public string COD_MOV { get; set; }
        public string STATUS_MOV { get; set; }
        public string STATUS_FE { get; set; }
        public string STATUS_ENVIO_FE { get; set; }
        public string TIPO_OPERACION_FE { get; set; }
        public string STATUS_BAJA_FE { get; set; }
        public string TIPO_FACT { get; set; }
        public decimal VALOR_DETRACCION { get; set; }
        public decimal POR_DETRACCION { get; set; }
        public string FORMA_PAGO { get; set; }
        public int NRO_DIAS { get; set; }
        public string CONDICION_VENTA { get; set; }
    }
}
