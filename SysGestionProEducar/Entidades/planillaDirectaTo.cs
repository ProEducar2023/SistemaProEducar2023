using System;

namespace Entidades
{
    public class planillaDirectaTo
    {
        public string NRO_CONTRATO { get; set; }
        public string COD_PERSONA { get; set; }
        public DateTime FECHA_CONTRATO { get; set; }
        public DateTime FECHA_LLAMADA { get; set; }
        public DateTime? FECHA_NUEVA_LLAMADA { get; set; }
        public string COD_LLAMADA { get; set; }
        public int CANT_CUOTA { get; set; }
        public decimal IMPORTE_CUOTA { get; set; }
        public string OBSERVACIONES { get; set; }
        public string COD_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string COD_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public DateTime FECHA_VEN { get; set; }
        public string TIPO { get; set; }
        public bool? VISTO_CONFIRMADO { get; set; }
    }
}
