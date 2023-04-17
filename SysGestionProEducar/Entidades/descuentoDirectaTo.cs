using System;

namespace Entidades
{
    public class descuentoDirectaTo
    {
        public string NRO_CONTRATO { get; set; }
        public string COD_PERSONA { get; set; }
        public DateTime FECHA_CONTRATO { get; set; }
        public string COD_SECTORISTA { get; set; }
        public string COD_GESTOR { get; set; }
        public int MESES_MOROSIDAD { get; set; }
        public DateTime FECHA_LLAMADA { get; set; }
        public DateTime? FECHA_NUEVA_LLAMADA { get; set; }
        public string COD_USU_CREA { get; set; }
        public DateTime FECHA_USU_CREA { get; set; }
        public string COD_USU_MOD { get; set; }
        public DateTime FECHA_USU_MOD { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string COD_MOTIVO_LLAMADA { get; set; }

    }
}
