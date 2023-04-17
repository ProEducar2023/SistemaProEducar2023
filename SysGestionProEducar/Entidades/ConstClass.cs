namespace Entidades
{
    public static class ConstClass
    {
        public const int ENVIADA = 1;
        public const int ENVIADO_CERRADO = 2;
        public const int RECEPCIONADA = 3;
        public const int RECEPCIONADO_CERRADO = 4;
        public const int PROCESADA = 5;
        public const int PROCESADA_CERRADA = 6;
        public const int DESCONTADA = 7;
        public const int DESCONTADA_CERRADA = 8;
        public const int NO_PROCESADA = 9;
        public const int NO_DESCONTADO = 10;
        public const int CHEQUE_DEPOSITADO = 11;
        public const int CHEQUE_CONFIRMADO = 12;
        public const int DESCONTADO_CONFIRMADO = 13;
        public const int CHEQUE_ENVIADO = 14;
        public const int CHEQUE_RECEPCIONADO = 15;
        public const int CHEQUE_TRANS = 16;
        public const int NO_EJECUTADO = 17;

        public const int ETAPA_PROCESO = 4;

        public const string EnvioCorreo = "EC";
        public const string EnvioFisico = "EF";
        public const string RecepcionCorreo = "RC";
        public const string RecepcionFisico = "RF";
        public const string LlamadaProgramada = "LLP";
        public const string LlamadaRegistrada = "LLREG";
        public const string LlamadaReprogramada = "LLREP";
        public const string OtrosResultado = "OTR";

        public const int Programado = 1;
        public const int ProgramadoCerrado = 3;
        public const int Reprogramado = 4;
        public const int Resultado = 2;
        public const int OtrosResultados = 5;
        public const int ActualizarResultado = 7;

        public const string TituloProgramado = "Programar Llamada";
        public const string TituloRegistrado = "Resultado Llamada";
        public const string TituloReprogramar = "Reprogramar Llamada";
        public const string TituloOtrosResultados = "Otros Resultados";

        public const string TipoProgramadoCorreo = "PC";
        public const string TipoProgramadoCorresp = "PF";
        public const string TipoProgramadoOtros = "PO";

        public const string EnvioCourier = "ENV";
        public const string Recepcion = "REC";
        public const string Deposito = "DEP";
        public const string Transferencia = "TRA";
        public const string Env_Rec_Dep = "ENV-REC-DEP";

        public const string ORIGEN_DEV_PLLA = "RET_ENT_CLIE";
        public const string ORIGEN_REE_PLLA = "REE_ENT_PLA";

        public const string TIPO_PLLA_REEMBOLSO = "RE";
        public const string TIPO_PLLA_RETENCION = "RT";
        public const string TIPO_PLLA_DESCUENTO = "PP";
        public const string TIPO_DOC_APLICACION = "AP";
    }
}
