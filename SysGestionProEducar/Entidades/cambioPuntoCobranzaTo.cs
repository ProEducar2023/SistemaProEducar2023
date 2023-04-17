using System;

namespace Entidades
{
    public class cambioPuntoCobranzaTo
    {
        public int ID_CAMBIO_PTO_COB { get; set; }
        public string COD_PER { get; set; }
        public string COD_PTO_COB { get; set; }
        public DateTime FE_COD_PTO_COB { get; set; }
        public string AUTORIZADO { get; set; }
        public string OBSERVACIONES { get; set; }
        public string COD_USU_CREA { get; set; }
        public DateTime FECHA_USU_CREA { get; set; }
        public string COD_USU_MOD { get; set; }
        public DateTime FECHA_USU_MOD { get; set; }
        public string COD_PTO_COB_ANT { get; set; }
        public string COD_DESCUENTO { get; set; }
        public string COD_INSTITUCION { get; set; }
        public bool SIN_CAMBIO_PTO_COB { get; set; }
    }
}
