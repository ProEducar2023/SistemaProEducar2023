using System;

namespace Entidades
{
    public class resumenPlanillaTo
    {
        public string NRO_PLANILLA_COB { get; set; }
        public string COD_INSTITUCION { get; set; }
        public string COD_PTO_COB_CONSOLIDADO { get; set; }
        public string COD_CANAL_DSCTO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string COD_PTO_COB { get; set; }
        public DateTime FECHA_PLANILLA_COB { get; set; }
        public DateTime? FECHA_RECEPCION { get; set; }
        public string OBSERVACION { get; set; }
        public string TIPO_PLANILLA { get; set; }
        public string COD_MOD { get; set; }
        public decimal IMP_ENV { get; set; }
        public decimal IMP_RECEPCION_INI { get; set; }
        public decimal IMP_RECEPCION_DOC { get; set; }
        public decimal IMP_RECEPCION_DEV { get; set; }
        public bool STATUS_APROB { get; set; }
        public string COD_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string COD_MODIFICACION { get; set; }
        public DateTime FECHA_MOD { get; set; }
    }
}
