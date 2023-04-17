using System;
using System.Collections.Generic;

namespace Entidades
{
    public class DevolucionComisionITo
    {
        public int ID_DEVOLUCION { get; set; }
        public int ID_PROCESO { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string FE_AÑO_PER { get; set; }
        public string FE_MES_PER { get; set; }
        public string NRO_CUOTA { get; set; }
        public DateTime FECHA_DEV_INI { get; set; }
        public DateTime FECHA_DEV_FIN { get; set; }
        public string COD_NIVEL { get; set; }
        public string COD_PER { get; set; }
        public decimal IMPORTE_COMISION { get; set; }
        public decimal SALDO { get; set; }
        public int ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public DateTime USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
        public DevolucionComisionTTo DevolucionComisionTTo { get; set; }
        public List<DevolucionComisionTTo> LstDevolucionComisionTTo { get; set; }
        public TIPO_REGISTRO TIPO_REGISTRO { get; set; }
    }
}
