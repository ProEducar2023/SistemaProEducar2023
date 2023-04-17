using System;

namespace Entidades
{
    public class calendarioTo
    {
        public int IdCalendario { get; set; }
        public string NuAño { get; set; }
        public string NuMes { get; set; }
        public int NuDia { get; set; }
        public bool FlFeriado { get; set; }
        public DateTime FECHA_ACTIVA { get; set; }
        public string COD_MOD { get; set; }
        public DateTime FECHA_MOD { get; set; }
        public string TIPO { get; set; }
    }
}
