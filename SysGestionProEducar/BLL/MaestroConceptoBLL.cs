using DAL;
using System;
using System.Data;

namespace BLL
{
    public class MaestroConceptoBLL
    {
        private static MaestroConceptoBLL instancia = null;
        private static readonly object syncRoot = new object();

        public static MaestroConceptoBLL Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                            instancia = new MaestroConceptoBLL();
                    }
                }
                return instancia;
            }
        }

        private readonly MaestroConceptoDAL conceptoDAL = new MaestroConceptoDAL();

        public DataTable ListarSegundoNivel()
        {
            return conceptoDAL.ListarSegundoNivel();
        }

        public DataTable ListarPrimerNivel()
        {
            return conceptoDAL.ListarPrimerNivel();
        }
    }
}
