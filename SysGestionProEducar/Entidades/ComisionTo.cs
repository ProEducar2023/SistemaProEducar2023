using System;
using System.Collections.Generic;

namespace Entidades
{
    public class ComisionTo
    {
        public int IdComision { get; set; }
        public personaTo PersonaTo { get; set; }
        public List<personaTo> LstMaestroPersonaTo { get; set; }
        public nivelTo NivelTo { get; set; }
        public string NroCuota { get; set; }
        public DateTime FechaIniVigencia { get; set; }
        public DateTime ? FechaFinVigencia { get; set; }
        public decimal Importe { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal BaseImponible { get; set; }
        public TipoComisionTo TipoComisionTo { get; set; }
        public int Estado { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime ? FechaModifica { get; set; }
        public tipoPlanillaCreacionTo TipoPlanillaTo { get; set; }
        public List<tipoPlanillaCreacionTo> LstTipoPlanillaTo { get; set; }

        public string GetFechaFinVigencia
        {
            get => string.IsNullOrEmpty(FechaFinVigencia.ToString()) ? string.Empty : Convert.ToDateTime(FechaFinVigencia).ToShortDateString();
        }
    }
}
