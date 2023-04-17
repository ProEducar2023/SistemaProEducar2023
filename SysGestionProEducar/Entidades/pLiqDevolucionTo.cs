using System;

namespace Entidades
{
    public class pLiqDevolucionTo
    {
        public string TIPO_VTA { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string COD_COMISIONANTE { get; set; }
        public string COD_VENDEDOR { get; set; }
        public string NRO_CONTRATO { get; set; }
        public DateTime FE_CONTRATO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public DateTime FE_DOC { get; set; }
        public string COD_PER { get; set; }
        public string NRO_LETRA { get; set; }
        public string COD_NIVEL { get; set; }
        public string NRO_PLANILLA { get; set; }
        public DateTime FE_PLANILLA { get; set; }
        public decimal IMP_INI { get; set; }
        public decimal IMPORTE { get; set; }
        public string COD_PER_SUP { get; set; }
        public string STATUS_CANCELADO { get; set; }
        public string STATUS_CIERRE { get; set; }
        public string NRO_DOC_PAG { get; set; }
        public DateTime? FECHA_DOC_PAG { get; set; }
        public string COD_CONCEPTO { get; set; }
        public string COD_BANCO { get; set; }
        public string COD_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_MODIF { get; set; }
        public DateTime FECHA_MODIF { get; set; }
        public string STATUS_PRE_APROB { get; set; }
        public string OP { get; set; }
    }
}
