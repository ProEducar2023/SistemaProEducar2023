using System;

namespace Entidades
{
    public class pResumenComisionTo
    {
        public string COD_SUCURSAL { get; set; }
        public string TIPO_VTA { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_PER { get; set; }
        public decimal IMPORTE { get; set; }
        public decimal IMP_COMISION { get; set; }
        public decimal IMP_ADELANTO { get; set; }
        public decimal IMP_DEVOLUCION { get; set; }
        public decimal IMP_CANCELADO { get; set; }
        public string COD_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_MODIF { get; set; }
        public DateTime FECHA_MODIF { get; set; }
    }
}
