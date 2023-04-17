using System;

namespace Entidades
{
    public class reporteTelefonicoDetalleTo
    {
        public string SUCURSAL { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string TIPO_PLANILLA { get; set; }
        public string FE_MES { get; set; }
        public string FE_AÑO { get; set; }
        public string COD_SEMANA { get; set; }
        public string COD_PER { get; set; }
        public string NOM_PER { get; set; }
        public DateTime FECHA { get; set; }
        public int CANTIDAD { get; set; }
        public decimal MONTO { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_CREA { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public DateTime COD_MOD { get; set; }
    }
}
