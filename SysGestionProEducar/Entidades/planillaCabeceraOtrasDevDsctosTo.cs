using System;
using System.Collections.Generic;

namespace Entidades
{
    public class planillaCabeceraOtrasDevDsctosTo
    {
        public string NRO_PLANILLA_DOC { get; set; }
        public string COD_INSTITUCION { get; set; }
        public string COD_CANAL_DSCTO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_SUCURSAL { get; set; }
        public DateTime FECHA_PLANILLA_DOC { get; set; }
        public string COD_PER { get; set; }
        public string DESC_PER { get; set; }
        public string DNI { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string TIPO_PLANILLA_DOC { get; set; }
        public decimal IMPORTE_TOTAL { get; set; }
        public string OBSERVACIONES { get; set; }
        public string STATUS_CIERRE { get; set; }
        public string COD_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        //
        public string COD_DOC { get; set; }
        public string STATUS_DOC { get; set; }
        public string SERIE { get; set; }
        public string COD_PTO_COB { get; set; }
        public string COD_CLASE { get; set; }
        public string STATUS_CTACTE { get; set; }
        public string COD_VENTA { get; set; }
        public string NRO_LETRA { get; set; }
        public string STATUS_COMPROM { get; set; }
        public string COD_GESTOR { get; set; }
        public string COD_MOTIVO_NO_DESCONTADO { get; set; }
        public string COD_UBICACION { get; set; }
        public string ORIG_OTRAS_PLLAS { get; set; }
        public string TIPO_PLANILLA_ORI { get; set; }
        public List<planillaDetalleOtrasDevDsctosTo> ListPlamillaDetalleOtrasDevDsctos { get; set; }
        public planillaDetalleOtrasDevDsctosTo PlanillaDetalleOtrasDevDsctos { get; set; }
        public string COD_GRUPO_UBICACION { get; set; }
        public string COD_SUB_UBICACION { get; set; }
        public string COD_AREA_TRABAJO { get; set; }
        public DateTime? FECHA_IDENTIFICACION_PAGO { get; set; }
        public string TIPO_VENTA { get; set; }
    }
}
