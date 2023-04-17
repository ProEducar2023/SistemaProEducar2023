using System;

namespace Entidades
{
    public class planillaCabeceraTo
    {
        public string NRO_PLANILLA_COB { get; set; }
        public string COD_INSTITUCION { get; set; }
        public string COD_PTO_COB_CONSOLIDADO { get; set; }
        public string COD_CANAL_DSCTO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string COD_PTO_COB { get; set; }
        public string COD_SECTORISTA { get; set; }
        public string COD_COBRADOR { get; set; }
        public DateTime FECHA_PLANILLA_COB { get; set; }
        public DateTime FECHA_VEN_AL { get; set; }
        public DateTime? FECHA_APROBACION { get; set; }
        public DateTime? FECHA_ENVIO { get; set; }
        public DateTime? FECHA_RECEPCION { get; set; }
        public DateTime? FECHA_PAGO { get; set; }
        public string STATUTS_APROBADO { get; set; }
        public string STATUS_ENVIO { get; set; }
        public string STATUS_RECEPCION { get; set; }
        public string STATUS_PAGO { get; set; }
        public string STATUS_ANULADO { get; set; }
        public string OBSERVACION { get; set; }
        public string TIPO_PLANILLA { get; set; }
        public decimal IMP_ENVIO { get; set; }
        public decimal IMP_RECEPCION_CTA_CTE { get; set; }
        public decimal IMP_RECEPCION_DEV { get; set; }
        public string COD_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string COD_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public string COD_DOC { get; set; }
        public string SERIE { get; set; }
        public string STATUS_DOC { get; set; }
        public string COD_CLASE { get; set; }
        public string STATUS_NO_ENVIADO { get; set; }
        public int CANT_CONTRATOS { get; set; }
        public decimal IMP_DOC { get; set; }
        public bool STATUS_RECEPCIONADO { get; set; }
        public bool APROBAR_RECEPCIONADO { get; set; }
        public string DESC_PTO_COB { get; set; }
        public int OP { get; set; }
        public string NOMBRE_MES { get; set; }
        public string COD_MONEDA { get; set; }
        public decimal IMP_RECEPCION_INI { get; set; }
        public decimal IMP_RECEPCION_DOC { get; set; }
        public string COD_TIPO_OPERACION { get; set; }
        public string COD_PROGRAMA { get; set; }
    }
}
