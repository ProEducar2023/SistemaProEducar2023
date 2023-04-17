using System;

namespace Entidades
{
    public class tComisionTo
    {
        public string TIPO_VTA { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string COD_VENDEDOR { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public DateTime FE_DOC { get; set; }
        public DateTime? FE_CANC { get; set; }
        public DateTime? FE_APROB { get; set; }
        public string COD_PER { get; set; }
        public decimal IMPORTE { get; set; }
        public string NRO_LETRA { get; set; }
        public string COD_NIVEL { get; set; }
        public string TIPO_OPE { get; set; }
        public string COD_PER_SUP { get; set; }
        public string NRO_PLANILLA { get; set; }
        public DateTime? FE_PLANILLA { get; set; }
        public string COD_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_MODIF { get; set; }
        public DateTime FECHA_MODIF { get; set; }
        public string COD_D_H { get; set; }
    }
}
