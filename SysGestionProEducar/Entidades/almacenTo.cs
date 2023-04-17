namespace Entidades
{
    public class almacenTo
    {
        public string COD_TIPO { get; set; }
        public string DESC_TIPO { get; set; }
        public string DESC_CORTA { get; set; }

        public string COD_ALMACEN { get; set; }
        public string DESC_ALMACEN { get; set; }
        public string COD_CLASE { get; set; }
        public string STATUS_SUCURSAL { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string LOCALIDAD { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string STATUS_PICKING { get; set; }//siempre tendra un valor fijo porque no se usa hasta ahora, puede que lo usemos luego por eso lo dejo, igual apararece en la BD
    }
}
