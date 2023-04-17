using System;

namespace Entidades
{
    public class personaMaestroTo: ICloneable
    {
        public string COD_PER { get; set; }
        public string TIPO_PER { get; set; }
        public string DESC_PER { get; set; }
        public string NOMBRE { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOM_COMERCIAL { get; set; }
        public string COD_TIPO_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public string MAIL { get; set; }
        public string NOM_AVAL { get; set; }
        public int NRO_BENEFICIARIOS { get; set; }
        public string NRO_DOC_AVAL { get; set; }
        public string DIR_AVAL { get; set; }
        public string FONO_AVAL { get; set; }
        public string ST_CONTRIBUYENTE { get; set; }
        public string ST_RETENEDOR { get; set; }
        public string ST_PERCEPTOR { get; set; }
        public string COD_INSTITUCION { get; set; }
        public string COD_IDENTIDAD { get; set; }
        public string DES_IDENTIDAD { get; set; }
        public string COD_PROCESO { get; set; }
        public string DES_PROCESO { get; set; }
        public string COD_SITUACION { get; set; }
        public string COD_USUARIO { get; set; }
        public string PWD_USUARIO { get; set; }
        public string COD_CARGO { get; set; }
        public string COD_VIVIENDA { get; set; }
        public string COD_CONDICION { get; set; }
        public string IMAGEN { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
