using System;

namespace Entidades
{
    public class MovimientosNivelVentaTo
    {
        public int ID_MOVIMIENTO { get; set; }
        public string COD_PER { get; set; }
        public string COD_NIVEL { get; set; }
        public DateTime FECHA_MOVIMIENTO { get; set; }
        public string FE_AÑO_PER { get; set; }
        public string FE_MES_PER { get; set; }
        public string TABLA_CON { get; set; }
        public string TIPO_CON { get; set; }
        public string CODIGO_CON { get; set; }
        public string DESC_CON { get; set; }
        public int TIPO_MOVIMIENTO { get; set; }
        public decimal IMPORTE { get; set; }
        public int ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
        public string NRO_LIQUIDACION { get; set; }
    }
}
