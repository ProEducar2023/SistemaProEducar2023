using System;

namespace Entidades
{
    public class cambioTipoPllaHistoricoTo
    {
        public string NRO_CONTRATO { get; set; }
        public DateTime FECHA_CAMBIO { get; set; }
        public string TIPO_PLANILLA_CAMBIADA { get; set; }
        public string COD_MOTIVO { get; set; }
        public string COD_AUTORIZADOR { get; set; }
        public string CUOTAS_CAMBIADAS { get; set; }
        public string OBSERVACIONES { get; set; }
        public string COD_CREAR { get; set; }
        public DateTime FECHA_CREAR { get; set; }
        public string COD_MODIFICAR { get; set; }
        public DateTime FECHA_MODIFICAR { get; set; }
        //para reporte cambio de tipo de planilla
        public DateTime FECHA_DESDE { get; set; }
        public DateTime FECHA_HASTA { get; set; }
        public string COD_PTO_COB { get; set; }
        public string COD_GESTOR { get; set; }
        public string COD_GRUPO_UBICACION { get; set; }
        public string COD_SUB_UBICACION { get; set; }
        public string COD_UBICACION { get; set; }
        public string UBICACION { get; set; }
        public string COD_UBICACION_ORIGEN { get; set; }
        public string COD_GRUPO_UBICACION_ORIGEN { get; set; }
        public string COD_SUB_UBICACION_ORIGEN { get; set; }
        public string COD_PROGRAMA { get; set; }
        public string COD_PER { get; set; }
        public decimal SALDO_ANTERIOR { get; set; }
        public decimal INGRESO_CLIENTES_OTRA_UBICACION { get; set; }
        public decimal CANCELACION_X_PLLA_DEV_MERCADERIA { get; set; }
        public decimal CANCELACION_X_PLLA_PRONTO_PAGO { get; set; }
        public decimal PASAN_CLIENTES_OTRA_UBICACION { get; set; }
        public decimal COBRANZA_CLIENTES { get; set; }
        public decimal SALDO_FINAL { get; set; }
        public string NRO { get; set; }
        public DateTime FECHA_APROB_DESDE { get; set; }
        public DateTime FECHA_APROB_HASTA { get; set; }
        public DateTime FECHA_APROB { get; set; }
        public DateTime FECHA_CONTRATO { get; set; }
        public string NOM_CLIENTE { get; set; }
        public string INGRESO_UBI { get; set; }
        public string SALIDA_UBI { get; set; }
        public string TOTAL_UBI { get; set; }
        public decimal COBRANZA_OTROS_CLIENTES { get; set; }
        public DateTime? FECHA_ORIGEN { get; set; }
        public string ORIGEN { get; set; }
        public DateTime? FECHA_DESTINO { get; set; }
        public string DESTINO { get; set; }
        public decimal COBRANZA_CLIENTES_OTROS { get; set; }
        public string PERIODO_DESDE { get; set; }
        public string PERIODO_HASTA { get; set; }
        public Boolean OP1 { get; set; }
    }
}
