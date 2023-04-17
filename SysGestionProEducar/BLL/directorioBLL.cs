using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
namespace BLL
{
    public class directorioBLL
    {
        directorioDAL dirDAL = new directorioDAL();

        public DataTable obtenerDirectorioBLL()
        {
            return dirDAL.obtenerDirectorioDAL();
        }
        public bool insertarDirectorioBLL(directorioTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.insertarDirectorioDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarDirectorioDatoBLL(directorioTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.insertarDirectorioDatoDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarDirectorioBLL(directorioTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.modificarDirectorioDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable MOSTRAR_DIRECTORIO_DATO_BLL(directorioTo dirTo)
        {
            return dirDAL.MOSTRAR_DIRECTORIO_DATO_DAL(dirTo);
        }
        public DataTable MOSTRAR_MOTIVOS_RECEPCION_DESCUENTO_BLL()
        {
            return dirDAL.MOSTRAR_MOTIVOS_RECEPCION_DESCUENTO_DAL();
        }
        public int VERIFICAR_DIRECTORIO_TABLA_BLL(directorioTo dirTo)
        {
            return dirDAL.VERIFICAR_DIRECTORIO_TABLA_DAL(dirTo);
        }
        public bool eliminarDirectorioBLL(directorioTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.eliminarDirectorioDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarDirectorioDetBLL(directorioTo dirTo, ref string errMensaje)
        {
            bool result = true;
            if (!dirDAL.eliminarDirectorioDetDAL(dirTo, ref errMensaje))
                return result = false;
            return result;
        }
        public decimal obtenerPorcentajeEvalContratoBLL()
        {
            return dirDAL.obtenerPorcentajeEvalContratoDAL();
        }
        public string DIR_TABLA_DESC(directorioTo dirTo)
        {
            return dirDAL.DIR_TABLA_DESC(dirTo);
        }
        public DataTable MOSTRAR_APROBADORES_CAMBIO_PTO_COB_BLL(directorioTo dirTo)
        {
            return dirDAL.MOSTRAR_APROBADORES_CAMBIO_PTO_COB_DAL(dirTo);
        }

        public DataTable obtenerCodigoDescripcionDirectorioBLL(directorioTo dirTo)
        {
            return dirDAL.obtenerCodigoDescripcionDirectorioDAL(dirTo);
        }
        public DataTable obtenerCodigoDescripcionDirectorioDirectaBLL(directorioTo dirTo)
        {
            return dirDAL.obtenerCodigoDescripcionDirectorioDirectaDAL(dirTo);
        }

        public List<directorioTo> ListarDirectorioXParametros(directorioTo dir)
        {
            return dirDAL.ListarDirectorioXParametros(dir);
        }
    }
}
