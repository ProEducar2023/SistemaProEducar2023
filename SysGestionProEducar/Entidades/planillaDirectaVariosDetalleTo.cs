using System;


namespace Entidades
{
    public class planillaDirectaVariosDetalleTo
    {
        public string NRO_PLANILLA_COB { get; set; }
        public string TIPO_PLANILLA { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string TIPO_TARJETA { get; set; }
        public DateTime FE_1ER_PROCESO { get; set; }
        public decimal MONTO_CUOTA { get; set; }
        public decimal DSCTO_TARJETA { get; set; }
        public decimal PAGO_RECIBIDO { get; set; }
        public string COD_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string COD_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public decimal IMP_DEV { get; set; }
        public string COD_PER { get; set; }
    }
}
