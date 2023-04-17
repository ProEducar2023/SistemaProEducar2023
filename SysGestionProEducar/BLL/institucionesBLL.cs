using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class institucionesBLL
    {
        institucionesDAL insDAL = new institucionesDAL();
        institucionesNivelesBLL inBLL = new institucionesNivelesBLL();
        institucionesNivelesTo inTo = new institucionesNivelesTo();
        public DataTable obtenerInstitucionesBLL()
        {
            return insDAL.obtenerInstitucionesDAL();
        }
        public bool insertarInstitucionesBLL(institucionesTo insTo, DataTable dtNiveles, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //instituciones
                if (!insDAL.insertarInstitucionesDAL(insTo, ref errMensaje))
                    return result = false;
                //niveles
                if (!insertarNiveles(insTo, dtNiveles, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        private bool insertarNiveles(institucionesTo insTo, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                inTo.CODIGO = Convert.ToString(rw["CODIGO"]);
                inTo.COD_INSTITUCION = insTo.COD_INST;
                inTo.DESCRIPCION = Convert.ToString(rw["DESCRIPCION"]);
                if (!inBLL.insertarInstitucionesNivelesDAL(inTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool modificarInstitucionesBLL(institucionesTo insTo, DataTable dtNiveles, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //se modifica instituciones
                if (!insDAL.modificarInstitucionesDAL(insTo, ref errMensaje))
                    return result = false;
                ////niveles
                //eliminar
                if (!eliminarNiveles(insTo, ref errMensaje))
                    return result = false;
                //insertar 
                if (!insertarNiveles(insTo, dtNiveles, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        private bool eliminarNiveles(institucionesTo insTo, ref string errMensaje)
        {
            bool result = true;
            inTo.CODIGO = insTo.COD_INST;
            if (!inBLL.eliminarInstitucionesNivelesDAL(inTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarInstitucionesBLL(institucionesTo insTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //instituciones
                if (!insDAL.eliminarInstitucionesDAL(insTo, ref errMensaje))
                    return result = false;
                //niveles
                if (!eliminarNiveles(insTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }

        public DataTable ObtenerSubNivelInstituciones(string codInstitucion)
        {
            return insDAL.ObtenerSubNivelInstituciones(codInstitucion);
        }
    }
}
