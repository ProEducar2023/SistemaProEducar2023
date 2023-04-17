using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class transportistaBLL
    {
        transportistaDAL traDAL = new transportistaDAL();
        transportistaTo traTo = new transportistaTo();
        transportista_vehiculoDAL trvDAL = new transportista_vehiculoDAL();
        transportista_vehiculoTo trvTo = new transportista_vehiculoTo();
        transportista_conductorDAL trcDAL = new transportista_conductorDAL();
        transportista_conductorTo trcTo = new transportista_conductorTo();
        conductorBLL condBLL = new conductorBLL();
        vehiculoBLL vehBLL = new vehiculoBLL();
        public bool adicionaInsertaTransportistaBLL(DataTable dtTransportista, DataTable dtConductor, DataTable dtVehiculo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //ELIMINA LOS REGISTROS DE LAS TABLAS PARA CREARLAS NUEVAMENTE
                if (!deleteEliminaTransportista_VehiculoBLL(ref errMensaje))
                    return result = false;
                if (!deleteEliminaTransportista_ConductorBLL(ref errMensaje))
                    return result = false;
                if (!deleteEliminaTransportistaBLL(ref errMensaje))
                    return result = false;
                //inserta en Transportista
                if (!insertaTransportistaBLL(dtTransportista, ref errMensaje))
                    return result = false;
                //inserta en Transportista_Conductor
                if (!insertaTransportista_ConductorBLL(dtConductor, ref errMensaje))
                    return result = false;
                //inserta en Transportista_Vehiculo
                if (!insertaTransportista_VehiculoBLL(dtVehiculo, ref errMensaje))
                    return result = false;

                ts.Complete();
                return result;
            }
        }
        private bool deleteEliminaTransportistaBLL(ref string errMensaje)
        {
            bool result = true;
            if (!traDAL.deleteEliminaTransportistaDAL(ref errMensaje))
                return result = false;
            return result;
        }
        private bool deleteEliminaTransportista_VehiculoBLL(ref string errMensaje)
        {
            bool result = true;
            if (!vehBLL.deleteEliminaTransportistaVehiculoBLL(ref errMensaje))
                return result = false;

            return result;
            //return trvDAL.deleteEliminaTransportistaVehiculoDAL(ref errMensaje);
        }
        private bool deleteEliminaTransportista_ConductorBLL(ref string errMensaje)
        {
            bool result = true;
            if (!condBLL.deleteEliminaTransportistaConductorBLL(ref errMensaje))
                return result = false;

            return result;
        }
        private bool insertaTransportistaBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                traTo.COD_TRANSPORTISTA = rw["COD_TRANSPORTISTA"].ToString();
                traTo.NOMBRE = rw["NOMBRE"].ToString();
                traTo.DIRECCION = rw["DIRECCION"].ToString();
                traTo.RUC = rw["RUC"].ToString();

                if (!traDAL.insertaTransportistaDAL(traTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool insertaTransportista_ConductorBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                trcTo.COD_TRANSPORTISTA = rw["COD_TRANSPORTISTA"].ToString();
                trcTo.ITEM = rw["ITEM"].ToString();
                trcTo.NOMBRE_CONDUCTOR = rw["NOMBRE_CONDUCTOR"].ToString();
                trcTo.DIRECCION = rw["DIRECCION"].ToString();
                trcTo.NRO_LICENCIA = rw["NRO_LICENCIA"].ToString();
                trcTo.NRO_DOCUMENTO = rw["NRO_DOCUMENTO"].ToString();

                if (!trcDAL.insertaTransportistaConductorDAL(trcTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        private bool insertaTransportista_VehiculoBLL(DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                trvTo.COD_TRANSPORTISTA = rw["COD_TRANSPORTISTA"].ToString();
                trvTo.ITEM = rw["ITEM"].ToString();
                trvTo.MARCA = rw["MARCA"].ToString();
                trvTo.NRO_PLACA = rw["NRO_PLACA"].ToString();
                trvTo.COD_TIPO = rw["COD_TIPO"].ToString();
                trvTo.CER_INS = rw["CER_INS"].ToString();

                if (!trvDAL.insertaTransportistaVehiculo(trvTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public DataSet obtenerTransportista_Conductor_VehiculoBLL()
        {
            conductorBLL conBLL = new conductorBLL();
            vehiculoBLL vehBLL = new vehiculoBLL();

            DataSet ds = new DataSet();
            DataTable dt1 = traDAL.obtenerTransportistaDAL();//trae todos los transportistas
            DataTable dt2 = conBLL.obtenerConductorBLL();//trae todos los conductores
            DataTable dt3 = vehBLL.obtenerVehiculoBLL();//tre todos los vehiculos
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Tables.Add(dt3);
            return ds;
        }
        public int verificaTransportistaBLL(transportistaTo traTo)
        {
            return traDAL.verificaTransportistaDAL(traTo);
        }
    }
}
