using System;

namespace Entidades
{
    public class resumenPlanillaDevolucionTo
    {
        public string NRO_PLANILLA_DOC { get; set; }
        public string COD_INSTITUCION { get; set; }
        public string COD_PTO_COB_CONSOLIDADO { get; set; }
        public string COD_CANAL_DSCTO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_SUCURSAL { get; set; }
        public DateTime FECHA_PLANILLA_DOC { get; set; }
        public string COD_PER { get; set; }
        public string DESC_PER { get; set; }
        public string DNI { get; set; }
        public string OBSERVACIONES { get; set; }
        public string TIPO_PLANILLA { get; set; }
        public string COD_MONEDA { get; set; }
        public decimal IMP_INI { get; set; }
        public decimal IMP_DOC { get; set; }
        public bool STATUS_APROB { get; set; }
        public string COD_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string COD_MODIFICACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
    }
}
