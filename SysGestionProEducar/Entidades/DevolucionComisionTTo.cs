using System;

namespace Entidades
{
    public class DevolucionComisionTTo
    {
        public int IDT_DEVOLUCION { get; set; }
        public int ID_DEVOLUCION { get; set; }
        public string FE_AÑO_PER { get; set; }
        public string FE_MES_PER { get; set; }
        public string NRO_PLANILLA_DEV { get; set; }
        public string COD_INSTITUCION_DEV { get; set; }
        public string COD_CANAL_DSCTO_DEV { get; set; }
        public string FE_AÑO_DEV { get; set; }
        public string FE_MES_DEV { get; set; }
        public string TIPO_PLANILLA_DEV { get; set; }
        public decimal IMPORTE_DESCONTAR { get; set; }
        public decimal TAG { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
        public string COD_MOTIVO_NO_DSCTO { get; set; }
        public string SI_NO_DESCONTAR { get; set; }
        public string NRO_LIQUIDACION { get; set; }
        public ESTADO_REGISTRO Estado { get; set; }
    }
}
