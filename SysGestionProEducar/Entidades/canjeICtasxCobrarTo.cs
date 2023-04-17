using System;

namespace Entidades
{
    public class canjeICtasxCobrarTo
    {
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public DateTime FECHA_CONTRATO { get; set; }
        public DateTime? FECHA_APROBACION { get; set; }
        //public DateTime FECHA_GENERACION { get; set; }
        public string NRO_REPORTE { get; set; }
        public DateTime FECHA_REPORTE { get; set; }
        public string COD_MONEDA { get; set; }
        public decimal TIPO_CAMBIO { get; set; }
        public decimal IMP_DOC { get; set; }
        public string OBSERVACION { get; set; }
        public string TIPO_OPE { get; set; }
        public string COD_PER { get; set; }
        public string NRO_CUOTAS { get; set; }
        public decimal IMP_DEVOLUCION { get; set; }
        public DateTime? FECHA_DEVOLUCION { get; set; }
        public string COD_VENDEDOR { get; set; }
        public string COD_NIVEL1 { get; set; }
        public string COD_NIVEL2 { get; set; }
        public string COD_NIVEL3 { get; set; }
        public string COD_USU_CREA { get; set; }
        public string COD_USU_MOD { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public DateTime FECHA_MOD { get; set; }
        //
        public string TIPO_USU { get; set; }
        public string COD_USU { get; set; }
        public string COD_SECTORISTA { get; set; }
        public string COD_PTO_COB { get; set; }
        public string COD_TIPO_VENTA { get; set; }
        public string COD_MODALIDAD_VTA { get; set; }
        public string STATUS_PRE_APROB { get; set; }
        public string STATUS_TRANSF_DIRECTA { get; set; }
        public DateTime FECHA_DOC { get; set; }
        public DateTime FECHA_VEN { get; set; }
        public decimal IMP_INI { get; set; }
        public DateTime FECHA_VEN2 { get; set; }
        public decimal IMP_INI2 { get; set; }
        public decimal IMP_TOTAL { get; set; }
        public string NRO_DOC_INV { get; set; }
        public string TIPO_PLA_ORIGEN { get; set; }
        public string TIPO_PLA_COBRANZA { get; set; }
    }
}
