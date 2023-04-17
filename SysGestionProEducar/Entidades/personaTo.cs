using System.Collections.Generic;

namespace Entidades
{
    public class personaTo
    {
        public string COD_PER { get; set; }
        public string DESC_PER { get; set; }
        public string NOMBRE { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOM_COMERCIAL { get; set; }
        public string COD_TIPO_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public string MAIL { get; set; }
        public string COD_USUARIO { get; set; }
        public string NICK { get; set; }
        public string COD_CLASE { get; set; }
        public string COD_CAT { get; set; }
        public string DIRECCION { get; set; }

        public List<personaTo> Detail = new List<personaTo>();
        public string contrato { get; set; }
        public string cod_modular { get; set; }
        public string cod_pago { get; set; }
        public string nom_clie { get; set; }
        public string dni_ruc { get; set; }
        public string nro_planilla { get; set; }
        public decimal monto_dev { get; set; }
        public string CODIGO { get; set; }
        public nivelTo NivelTo { get; set; }
    }
}
