using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class institucionesNivelesBLL
    {
        institucionesNivelesDAL inDAL = new institucionesNivelesDAL();

        public DataTable obtenerInstitucionesNivelesBLL(institucionesNivelesTo inTo)
        {
            return inDAL.obtenerInstitucionesNivelesDAL(inTo);
        }
        public bool insertarInstitucionesNivelesDAL(institucionesNivelesTo inTo, ref string errMensaje)
        {
            bool result = true;
            if (!inDAL.insertarInstitucionesNivelesDAL(inTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarInstitucionesNivelesDAL(institucionesNivelesTo inTo, ref string errMensaje)
        {
            bool result = true;
            if (!inDAL.eliminarInstitucionesNivelesDAL(inTo, ref errMensaje))
                return result = false;
            return result;
        }
    }
}
