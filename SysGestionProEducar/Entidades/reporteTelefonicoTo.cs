using System;

namespace Entidades
{
    public class reporteTelefonicoTo
    {
        public string SUCURSAL { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string TIPO_PLANILLA { get; set; }
        public string FE_MES { get; set; }
        public string FE_AÑO { get; set; }
        public string COD_SEMANA { get; set; }
        public string NOM_SEMANA { get; set; }
        public DateTime FECHA { get; set; }
        public int CANTIDAD_TOT { get; set; }
        public decimal MONTO_TOTAL { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_CREA { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public string COD_MOD { get; set; }
    }
}
