using System;

namespace Entidades
{
    public class cobranzaDirectaTo
    {
        public string NRO_CONTRATO { get; set; }
        public string COD_PERSONA { get; set; }
        public string COD_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public DateTime FECHA_CONTRATO { get; set; }
        public DateTime? FECHA_LLAMADA { get; set; }
        public DateTime? FECHA_CONFIRMADA { get; set; }
        public decimal IMPORTE_PAGO { get; set; }
        public string TIPO_PLA_ORIGEN { get; set; }
        public string TIPO_PLA_COBRANZA { get; set; }
        public string NRO_LETRA { get; set; }
        public string TOTAL_LETRA { get; set; }
        public string NRO_OPERACION { get; set; }
        public DateTime? FECHA_OPERACION { get; set; }
        public string COD_BANCO { get; set; }
        public string COD_LLAMADA { get; set; }
        public DateTime? FECHA_NUEVA_LLAMADA { get; set; }
        public string OBSERVACIONES { get; set; }
        public string COD_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string COD_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public decimal? IMPORTE_DEPOSITADO { get; set; }
        public string STATUS_CONFIRMACION { get; set; }
        public string NRO_CUOTA { get; set; }
        public DateTime? FECHA_NUECVA_ACTIVA { get; set; }
    }
}
