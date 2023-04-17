using System;

namespace Entidades
{
    public class kitDetalleTo
    {
        public string COD_KIT { get; set; }
        public string COD_ARTICULO { get; set; }
        public decimal CANTIDAD { get; set; }
        public decimal PRECIO_UNITARIO { get; set; }
        public DateTime FEC_ACTUALIZACION { get; set; }
        public bool ST_SUSPENDIDO { get; set; }
        public bool ST_VALOR_REFERENCIAL { get; set; }
        public DateTime DESDE { get; set; }
        public DateTime HASTA { get; set; }

    }
}
