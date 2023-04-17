using System;

namespace Entidades
{
    public class ComisionContrato
    {
        public int ID_PROCESO { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string NRO_CUOTA { get; set; }
        public string FE_AÑO_PER { get; set; }
        public string FE_MES_PER { get; set; }
        public DateTime FECHA_APROB_INI { get; set; }
        public DateTime FECHA_APROB_FIN { get; set; }
        public DateTime? FECHA_COBRA_INI { get; set; }
        public DateTime? FECHA_COBRA_FIN { get; set; }
        public string PERIODO_PROCESO { get; set; }
        public string FE_AÑO_SIS { get; set; }
        public string FE_MES_SIS { get; set; }
        public int ID_COMISION_VEND { get; set; }
        public int ID_CONF_VEND { get; set; }
        public int ID_COMISION_SUP { get; set; }
        public int ID_CONF_SUP { get; set; }
        public int ID_COMISION_DIR_VTAS { get; set; }
        public int ID_CONF_DIR_VTAS { get; set; }
        public int ID_COMISION_DIR_NCNAL { get; set; }
        public int ID_CONF_DIR_NCNAL { get; set; }
        public string USUARIO { get; set; }
        public int ESTADO { get; set; }
        public string FLAH { get; set; }
        public vendedorTo Vendedor { get; set; }
        public supervisorTo Supervisor { get; set; }
        public directorTo DirectoVenta { get; set; }
        public directorNacTo DirectorNacional { get; set; }
        public ComisionTo ComisionTo { get; set; }
        public ComisionLiquidacionDetTo ComisionLiquidacionDetTo  { get;set;}
    }
}
