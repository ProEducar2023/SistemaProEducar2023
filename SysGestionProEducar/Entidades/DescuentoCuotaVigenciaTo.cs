using System;

namespace Entidades
{
    public class DescuentoCuotaVigenciaTo
    {
        public int ID { get; set; }
        public string NRO_CUOTA { get; set; }
        public DateTime FECHA_INI_VIGENCIA { get; set; }
        public DateTime FECHA_INI_VIGENCIA_ANT { get; set; }
        public DateTime? FECHA_FIN_VIGENCIA { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime FECHA_MODIFICA { get; set; }
    }
}
