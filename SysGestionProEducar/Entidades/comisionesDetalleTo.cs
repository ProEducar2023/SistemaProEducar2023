using System;

namespace Entidades
{
    public class comisionesDetalleTo
    {
        public string TIPO { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string COD_PER { get; set; }
        public string COD_INSTITUCION { get; set; }
        public string COD_NIVEL_INSTITUCION { get; set; }
        public string COD_NIVEL { get; set; }
        public string NOM_NIVEL { get; set; }
        public string COD_PER_SUP { get; set; }
        public string NOM_PER_SUP { get; set; }
        public decimal IMPORTE { get; set; }
        public decimal PORCENTAJE { get; set; }
        public string CUOTA { get; set; }
        public string COD_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
    }
}
