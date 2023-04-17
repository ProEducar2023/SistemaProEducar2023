﻿using System;

namespace Entidades
{
    public class canjeTCtasxCobrarTo
    {
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string COD_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public string COD_PER { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public DateTime FECHA_CONTRATO { get; set; }
        public DateTime FECHA_DOC { get; set; }
        public DateTime? FECHA_VEN { get; set; }
        public string COD_P_COBRANZA { get; set; }
        public string COD_COBRADOR { get; set; }
        public string NRO_PLANILLA { get; set; }
        public DateTime? FECHA_PLANILLA { get; set; }
        public string COD_D_H { get; set; }
        public string COD_MONEDA { get; set; }
        public decimal TIPO_CAMBIO { get; set; }
        public decimal IMP_DOC { get; set; }
        public string OBSERVACION { get; set; }
        public string TIPO_OPE { get; set; }
        public string NRO_LETRA { get; set; }
        public string TOTAL_LETRA { get; set; }
        public string COD_CONCEPTO { get; set; }
        public string COD_USU_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string COD_USU_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        //
        public decimal IMP_INI { get; set; }
        public string TIPO_PLA_ORIGEN { get; set; }
        public string TIPO_PLA_COBRANZA { get; set; }
    }
}
