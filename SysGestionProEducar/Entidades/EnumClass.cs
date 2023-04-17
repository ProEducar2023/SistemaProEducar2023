namespace Entidades
{
    public enum CRUD
    {
        Insertar = 1,
        Actualizar = 2,
        Eliminar = 3,
        None = 4
    }

    public enum Tipo_Movimiento_Cheque
    {
        Envio = 1,
        Recepcion = 2,
        Deposito = 3,
        Transferencia = 4
    }

    public enum Tipo_Operacion_Cobranza
    {
        Env_Rec_Dep = 1,
        Deposito = 2,
        Transferencia = 3
    }

    public enum Resultado_Cheque
    {
        Pendiente = 1,
        Aprobar = 2,
        Desaprobar = 3
    }

    public enum EtapaSeguiGrid
    {
        Envío = 0,
        Recepción = 1,
        Proceso = 2,
        Lista = 3,
        SD = 4,
        Ejecutado = 5,
        ND = 6
    }

    public enum EtapaSeguiChequeGrid
    {
        Planillas_Pendientes = 0,
        Planillas_Cerradas = 1
    }

    public enum Tipo_APL_SALDO
    {
        Planilla_Imp_Exceso = 0,
        Planilla_Imp_x_cobrar = 1
    }

    public enum Modulo
    {
        MOD_CXC = 0,
        MOD_COMISIONES = 1,
        MOD_FACT_VTA = 2,
        MOD_VTA = 3
    }

    public enum ESTADO_COMISION
    {
        NONE = -1,
        REGISTRO_PENDIENTE = 0,
        REGISTRO_PROCESADO = 1,
        REGISTRO_EXCLUIDO = 2,
        REGISTRO_APROBADO = 3
    }
    public enum TIPO_CONFIRMAR
    {
        COMISION = 0,
        DEVOLUCION_COMISION = 1,
        RETORNAR_ETAPA_PROCESO = 2
    }

    public enum ESTADO_REGISTRO
    {
        NONE = -1,
        REGISTRO_PENDIENTE = 0,
        REGISTRO_PROCESADO = 1,
        REGISTRO_EXCLUIDO = 2,
        REGISTRO_APROBADO = 3
    }

    public enum TIPO_REGISTRO
    {
        NUEVO = 0,
        EXISTENTE = 1
    }

    public enum TIPO_LIQUIDACION
    {
        COMISIONES_PROPIOS = 1,
        COMISIONES_TERCEROS = 2,
        DEVOLUCIONES = 3,
        OTROS_INGRESOS = 4,
        OTROS_EGRESOS = 5
    }

    public enum ESTADO_REGISTRO_DEVOLUCION
    {
        NONE = -1,
        REGISTRO = 1,
        REGISTRO_APROBADO = 2,
        REGISTRO_ANULADO = 3
    }
}
