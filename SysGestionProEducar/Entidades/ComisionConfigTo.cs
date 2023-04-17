using System;
using System.Collections.Generic;

namespace Entidades
{
    public class ComisionConfigTo
    {
        public int IdComisionConfig { get; set; }
        public personaTo PersonaSuperiTo { get; set; }
        public institucionesTo InstitucionTo { get; set; }
        public List<personaTo> LstVendedores { get; set; }
        public string NroCuota { get; set; }
        public DateTime FechaIniVigencia { get; set; }
        public DateTime? FechaFinVigencia { get; set; }
        public decimal Importe { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal BaseImponible { get; set; }
        public TipoComisionTo TipoComisionTo { get; set; }
        public bool SiComisiona { get; set; }
        public int Estado { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public tipoPlanillaCreacionTo TipoPlanillaTo { get; set; }
        public List<tipoPlanillaCreacionTo> LstTipoPlanillaTo { get; set; }

        public string GetFechaFinVigencia
        {
            get => string.IsNullOrEmpty(FechaFinVigencia.ToString()) ? string.Empty : Convert.ToDateTime(FechaFinVigencia).ToShortDateString();
        }
    }
}
