using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ComisionLiquidacionDetTo
    {
        public int ID_PROCESO { get; set; }
        public string NRO_LIQUIDACION { get; set; }
        public TIPO_LIQUIDACION TIPO_LIQUIDACION { get; set; }
        public int ID_TIPO_LIQUIDACION => (int)TIPO_LIQUIDACION;
        public int ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }

    }
}
