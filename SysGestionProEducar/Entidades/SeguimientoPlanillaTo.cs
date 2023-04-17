using System;
using static Entidades.ConstClass;

namespace Entidades
{
    public class SeguimientoPlanillaTo
    {
        public int ID_SEGUIMIENTO { get; set; }
        public int ID_ESTADO { get; set; }
        public string NRO_PLANILLA { get; set; }
        public string TIPO_PLANILLA { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string COD_PTO_COB_CONSOLIDADO { get; set; }
        public string OBSERVACION { get; set; }
        public string USUARIO_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public decimal IMPORTE_DESCUENTO { get; set; }
        public decimal IMPORTE_CASILLERO { get; set; }
        public decimal IMPORTE_RETENIDO { get; set; }
        public decimal OTROS_DSCTOS { get; set; }
        public PersonaEnvioTo PersonaEnvio { get; set; }
        public EnvioPlanillaTo EnvioPlanilla { get; set; }
        public RecepcionPlanillaTo RecepcionPlanillaTo { get; set; }
        public int ID_HISTORIAL { get; set; }
        public PersonaEnvioTo EmisorTo { get; set; }
        public decimal IMPORTE_LISTADO { get; set; }
        public decimal? PORCENTAJE_CASILLERO { get; set; }
        public decimal IMPORTE_CASILLERO_MAN { get; set; }
        public decimal IMPORTE_EJECUTADO { get; set; }
        public string COD_INSTITUCION { get; set; }
        public string COD_CANAL_DSCTO { get; set; }
        public decimal IMPORTE_NETO { get; set; }
        public decimal IMPORTE_AJUSTE { get; set; }
        public decimal IMPORTE_VERIFICADO { get; set; }
        public decimal SALDO_X_COBRAR { get; set; }
        public decimal IMPORTE_EXC_INI { get; set; }
        public decimal IMPORTE_EXC_DOC { get; set; }
        public DateTime? FEC_RETOR_PLAN { get; set; }
        public DateTime? FECHA_CIERRE_COBRANZA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
        public string COD_SUCURSAL { get; set; }
        public personaContactoTo PersonaContactoTo { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string NRO_LETRA { get; set; }
        public string COD_GRUPO { get; set; }
        public bool CAB_GRUPO { get; set; }
        public decimal IMPORTE_NETO_GRUPO { get; set; }
        public bool ST_NO_PROCESADO { get; set; }
        public string ST_NO_PROCESADO_OBS { get; set; }
        public bool ST_LISTADO { get; set; }
        public string NRO_PLLA_ENV { get; set; }
        public string TEXTODESCRIPTIVOGRILLA { get; set; }

        public string TEXTOMSJELIMINACION { get; set; }
        public string PERIODO { get; set; }
        public bool INHABILITAR { get; set; }
        public int ID_PAGO { get; set; }
        public string TIPO_PAGO { get; set; }

        public int CHEQUE_APLICADO_SALDO { get; set; }
    }

    public class EnvioPlanillaTo
    {
        public int ID_ENVIO { get; set; }
        public DateTime FECHA_ENVIO { get; set; }
        public string HORA_ENVIO { get; set; }
        public string DOC_ENVIO { get; set; }
        public string TIPO_ENVIO { get; set; }
        public string NOMBRE_INST { get; set; }
        public string TLF_INST { get; set; }
        public string ENVIO_CORRESP { get; set; }
    }

    public class LLamadas
    {
        public int ID_LLAMADA_BASE { get; set; }
        public SeguimientoPlanillaTo SeguimientoPlanillaTo { get; set; }
        public PersonaEnvioTo PersonaEnvioTo { get; set; }
        public DateTime FECHA_LLAMADA { get; set; }
        public string HORA_LLAMADA { get; set; }
        public string OBSERVACION { get; set; }
        public int ESTADO { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string NOMBRE_INST { get; set; }
        public string TLF_INST { get; set; }
        public string TIPO { get; set; }
        public string MOTIVO { get; set; }
        public string REC_LIST_DESCTO { get; set; }
        public string DESCUENTO { get; set; }
        public string PROCESO_RESULT { get; set; }
    }

    public class RecepcionPlanillaTo
    {
        public int ID_RECEPCION { get; set; }
        public DateTime FECHA_RECEPCION { get; set; }
        public string HORA_RECEPCION { get; set; }
        public string AREA_RECEPCION { get; set; }
        public string TIPO_REPCION { get; set; }
        public string OBSERVACION { get; set; }
    }

    public class ChequesPlanillaTo
    {
        public string USUARIO_CREA { get; set; }
        public SeguimientoPlanillaTo SeguimientoPlanillaTo { get; set; }
        public EnvioChequeTo EnvioChequeTo { get; set; }
        public RecepcionChequeTo RecepcionChequeTo { get; set; }
        public DepositoChequeTo DepositoChequeTo { get; set; }

        public DevolucionExcesoEntidad DevolucionExcesoEntidad { get; set; }
        public TransferenciaSeguiTo TransferenciaSeguiTo { get; set; }
        public Resultado_Cheque ESTADO { get; set; }
        public Tipo_Movimiento_Cheque TIPO_PAGO;
        public string TIPO_PAGO_TXT { get; set; }
        public int ID_PAGO { get; set; }
        public Tipo_Operacion_Cobranza TipoOperacionCobranza
        {
            get
            {
                switch (TIPO_PAGO_TXT)
                {
                    case Env_Rec_Dep: return Tipo_Operacion_Cobranza.Env_Rec_Dep;
                    case Deposito: return Tipo_Operacion_Cobranza.Deposito;
                    case Transferencia: return Tipo_Operacion_Cobranza.Transferencia;
                    default: throw new ArgumentException($"No existe un procedimiento para el tipo de pago: ${TIPO_PAGO_TXT}");
                }
            }
        }

        public string TIPO_ENVIO_CHEQUE
        {
            get
            {
                switch (TIPO_PAGO)
                {
                    case Tipo_Movimiento_Cheque.Envio: return EnvioCourier;
                    case Tipo_Movimiento_Cheque.Recepcion: return Recepcion;
                    case Tipo_Movimiento_Cheque.Deposito: return Deposito;
                    case Tipo_Movimiento_Cheque.Transferencia: return Transferencia;
                    default: throw new ArgumentException();
                }
            }
        }

        public bool FL_GEN_APL { get; set; }
    }

    public class EnvioChequeTo
    {
        public int ID_ENVIO { get; set; }
        public DateTime FECHA_ENVIO { get; set; }
        public string EMPRESA { get; set; }
        public int ID_DOCUMENTO { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string REPRESENTANTE { get; set; }
        public string RESPONSABLE { get; set; }
    }

    public class RecepcionChequeTo
    {
        public int ID_RECEPCION { get; set; }
        public DateTime FECHA_RECEPCION { get; set; }
        public string BANCO_ORIGEN { get; set; }
        public string NRO_CHEQUE { get; set; }
        public int ID_MONEDA { get; set; }
        public decimal IMPORTE { get; set; }
        public string REPRESENTANTE { get; set; }
        public string RESPONSABLE { get; set; }
        public int ESTADO { get; set; }
        public int ID_ENVIO { get; set; }
    }

    public class DepositoChequeTo
    {
        public int ID_DEPOSITO { get; set; }
        public DateTime FECHA_DEPOSITO { get; set; }
        public string COD_BANCO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public string NRO_OPERACION { get; set; }
        public int ID_MONEDA { get; set; }
        public decimal IMPORTE { get; set; }
        public string REPRESENTANTE { get; set; }
        public string RESPONSABLE { get; set; }
        public string OBSERVACION { get; set; }
        public int ESTADO { get; set; }
        public decimal IMPORTE_VERIFICADO { get; set; }
        public int ID_ENVIO { get; set; }
        public decimal IMPORTE_PROPIO_PLLA { get; set; }
        public bool FL_GEN_APL { get; set; }
    }

    public class DevolucionExcesoEntidad
    {
        public int ID_DEVOLUCION_EXC { get; set; }
        public int ID_SEGUIMIENTO { get; set; }
        public int ID_PAGO { get; set; }
        public string TIPO_PAGO { get; set; }
        public string FE_AÑO_SIS { get; set; }
        public string FE_MES_SIS { get; set; }
        public decimal IMPORTE_DEVOLVER_ENTIDAD { get; set; }
        public string OBSERVACION { get; set; }
        public int ID_ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
      
    }
    public class TransferenciaSeguiTo
    {
        public int ID_TRANSFERENCIA { get; set; }
        public DateTime FECHA_TRANSFERENCIA { get; set; }
        public string BANCO_ORIGEN { get; set; }
        public string NRO_CTA_ORIGEN { get; set; }
        public string COD_BANCO_DEST { get; set; }
        public int ID_MONEDA { get; set; }
        public decimal IMPORTE { get; set; }
        public string REPRESENTANTE { get; set; }
        public string OBSERVACION { get; set; }
        public string ESTADO { get; set; }
        public decimal IMPORTE_VERIFICADO { get; set; }
        public string NRO_OPERACION { get; set; }
        public decimal IMPORTE_PROPIO_PLLA { get; set; }
        public bool FL_GEN_APL { get; set; }
    }
}
