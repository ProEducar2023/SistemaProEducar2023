using System;

namespace Entidades
{
    public class mArticuloTo
    {
        public string COD_CLASE { get; set; }
        public string COD_ALMACEN { get; set; }
        public string COD_ARTICULO { get; set; }
        public decimal SALDO_ACT { get; set; }
        public decimal SALDO_INI { get; set; }
        public DateTime FECHA_DOC { get; set; }
        public string NRO_PRESUPUESTO { get; set; }//NRO DE CONTRATO
    }
}
