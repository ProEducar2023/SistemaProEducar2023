using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LiquidacionTo
    {
        public string NRO_LIQUIDACION { get; set; }
        public TIPO_LIQUIDACION TIPO_LIQUIDACION { get; set; }
        public string COD_PER { get; set; }
        public string COD_NIVEL { get; set; }
        public string FE_AÑO_PER { get; set; }
        public string FE_MES_PER { get; set; }
        public decimal IMPORTE { get; set; }
        public int ID_TBANCO { get; set; }
        public int ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime ? FECHA_MODIFICA { get; set; }

        public int ID_TIPO_LIQUIDACION => (int)TIPO_LIQUIDACION;
    }
}
