using System;

namespace Entidades
{
    public class articuloContenidoMovimientoTo
    {
        public string NRO_NOTA_ING { get; set; }
        public string COD_ARTICULO { get; set; }
        public string COD_ART_CONTENIDO { get; set; }
        public int CANTIDAD { get; set; }
        public string SITUACION { get; set; }
        public string COD_USU_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_USU_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public DateTime FE_DESDE { get; set; }
        public DateTime FE_HASTA { get; set; }
        public string DESC_ARTICULO { get; set; }
    }
}
