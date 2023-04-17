using System;

namespace Entidades
{
    public class descuentoDirectaSeguimientoTo
    {
        public string NRO_CONTRATO { get; set; }
        public string COD_PERSONA { get; set; }
        public string COD_GESTOR { get; set; }
        public string COD_MOTIVO_LLAMADA { get; set; }
        public DateTime FECHA_OPERACION_LLAMADA { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public DateTime? FECHA_COMPROMISO_PAGO { get; set; }
        public string OBSERVACIONES { get; set; }
        public decimal IMPORTE_PAGO { get; set; }
        public string STATUS_CONFIRMACION_PAGO { get; set; }
        public DateTime? FECHA_DEPOSITO { get; set; }
        public string NRO_OPERACION { get; set; }
        public string INSTITUCION_BANCARIA { get; set; }
        public string NRO_CTA_BANCARIA { get; set; }
        public string OBS_DATOS_BANCARIOS { get; set; }
        public string COD_USU { get; set; }
        public DateTime FEC_COD_USU { get; set; }
        public string COD_MOTIVO_LLAMADA_ORIGEN { get; set; }
        public string MESES_MOROSIDAD { get; set; }
    }
}
