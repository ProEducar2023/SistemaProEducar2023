using System;

namespace Entidades
{
    public class planillaDirectaSeguimientoTo
    {
        public string NRO_CONTRATO { get; set; }
        public string COD_PERSONA { get; set; }
        public string NRO_CUOTA { get; set; }
        public string TIPO { get; set; }
        public DateTime? FECHA_LLAMADA { get; set; }
        public string COD_LLAMADA_LL { get; set; }
        public DateTime? FECHA_NUEVA_LLAMADA_LL { get; set; }
        public string OBS_LLAMADA_LL { get; set; }
        public string COD_LLAMADA_CO { get; set; }
        public DateTime? FECHA_NUEVA_LLAMADA_CO { get; set; }
        public DateTime? FECHA_OPERACION_CO { get; set; }
        public string OBS_LLAMADA_CO { get; set; }
        public DateTime? FECHA_ACTIVA { get; set; }
        public string DES_LLAMADA_LL { get; set; }
        public string DES_LLAMADA_CO { get; set; }
        public string COD_USU_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public string TIPO_PLA_COBRANZA { get; set; }
        public string TIPO_PLA_DESTINO { get; set; }
        //para el historico de cambio de tipo de planilla
        public DateTime FECHA_CAMBIO { get; set; }
        public string COD_MOTIVO { get; set; }
        public string COD_AUTORIZADOR { get; set; }
        public string CUOTAS_CAMBIADAS { get; set; }
        public string OBSERVACIONES { get; set; }
    }
}
