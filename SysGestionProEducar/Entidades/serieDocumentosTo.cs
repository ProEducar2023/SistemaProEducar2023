namespace Entidades
{
    public class serieDocumentosTo
    {
        public string COD_SUCURSAL { get; set; }
        public string STATUS_DOC { get; set; }
        public string COD_DOC { get; set; }
        public string SERIE { get; set; }
        public string NUMERO { get; set; }
        public string COD_OPCION { get; set; }
        public string STATUS_SERIE { get; set; }
        public string STATUS_BLOQUE { get; set; }
        public string CORRELATIVO => SERIE + "-" + NUMERO;
    }
}
