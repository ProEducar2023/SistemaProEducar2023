using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ComisionAdelantoTo
    {
        public int ID_PROCESO { get; set; }
        public string COD_CLIENTE { get; set; }
        public string COD_SUCURSAL { get; set; }
        public string COD_CLASE { get; set; }
        public string NRO_CONTRATO { get; set; }
        public string NRO_PLANILLA_DOC { get; set; }
        public string FE_AÑO { get; set; }
        public string FE_MES { get; set; }
        public string NRO_CUOTA { get; set; }
        public string COD_PER { get; set; }
        public string COD_NIVEL { get; set; }
        public int TIPO { get; set; }
        public int NRO_ADELANTO { get; set; }
        public decimal IMPORTE_COMISION { get; set; }
        public decimal IMPORTE_ADELANTO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
        public int ESTADO { get; set; }
        public programaTo ProgramaTo { get; set; }
    }
}
