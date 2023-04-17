using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RComisionAdelantoTo
    {
        public string NRO_PLANILLA_DOC { get; set; }
        public string COD_PER { get; set; }
        public string COD_NIVEL { get; set; }
        public decimal IMPORTE_COMISION { get; set; }
        public decimal IMPORTE_ADELANTO { get; set; }
        public int NRO_ENVIO { get; set; }
        public int ID_I_BANCO { get; set; }
        public int ESTADO { get; set; }
        public string USUARIO_CREA { get; set; }
        public DateTime FECHA_CREA { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
        public List<ComisionAdelantoTo> ComisionAdelantoTo { get; set; }
    }
}
