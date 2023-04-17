using DAL;
using Entidades;
using System;
using System.Data;
using System.Transactions;
namespace BLL
{
    public class personaMaestroBLL
    {
        personaMaestroDAL pemDAL = new personaMaestroDAL();
        personaClaseBLL pelBLL = new personaClaseBLL();
        personaClaseTo pelTo = new personaClaseTo();
        personaDireccionBLL pedBLL = new personaDireccionBLL();
        personaDireccionTo pedTo = new personaDireccionTo();
        personaFonoBLL pefBLL = new personaFonoBLL();
        personaFonoTo pefTo = new personaFonoTo();
        personaContactoBLL pecBLL = new personaContactoBLL();
        personaContactoTo pecTo = new personaContactoTo();
        personaBeneficiarioBLL pebBLL = new personaBeneficiarioBLL();
        personaBeneficiarioTo pebTo = new personaBeneficiarioTo();
        UsuarioWebBLL uswBLL = new UsuarioWebBLL();
        usuarioWebTo uswTo = new usuarioWebTo();
        public DataTable obtenerMaestroPersonaBLL()
        {
            return pemDAL.obtenerMaestroPersonaDAL();
        }
        public string obtenerNuevoCodPerBLL()
        {
            return pemDAL.obtenerNuevoCodPerDAL();
        }
        public DataTable obtenerMaestroPersonaporCOD_PERBLL(personaMaestroTo pemTo)
        {
            return pemDAL.obtenerMaestroPersonaporCOD_PERDAL(pemTo);
        }
        public string obtenerNombrePersonaporCOD_PERBLL(personaMaestroTo pemTo)
        {
            return pemDAL.obtenerNombrePersonaporCOD_PERDAL(pemTo);
        }
        public bool adicionaNuevoMaestroPersonaBLL(personaMaestroTo pemTo, DataTable dtContactos, DataTable dtTelefono, DataTable dtDireccion,
            DataTable dtClase, personaSustitutoTo pesTo, DataTable dtBeneficiario, DataTable dtWebUsu, ref string cod_persona, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //Maestro Persona
                if (!insertarMaestroPersonaBLL(pemTo, ref cod_persona, ref errMensaje))
                    return result = false;
                //Contactos
                pemTo.COD_PER = cod_persona;
                if (!insertarPersonaContactoBLL(pemTo.COD_PER, dtContactos, ref errMensaje))
                    return result = false;
                //Telefono
                if (!insertarPersonaTelefonoBLL(pemTo.COD_PER, dtTelefono, ref errMensaje))
                    return result = false;
                //Direccion
                if (!insertarDireccionBLL(pemTo.COD_PER, dtDireccion, ref errMensaje))
                    return result = false;
                //Clase
                if (!insertarClaseBLL(pemTo.COD_PER, dtClase, ref errMensaje))
                    return result = false;
                //Sustituto
                if (pesTo.DNI_SUS != "" || pesTo.NOMBRE_SUS != "" || pesTo.DIRECCION_SUS != "" || pesTo.EMAIL_SUS != "" || pesTo.TELEFONO_SUS != "")
                {
                    if (!insertarSustitutoBLL(pesTo, ref errMensaje))
                        return result = false;
                }
                //Beneficiarios
                if (!insertarBeneficiarioBLL(pemTo.COD_PER, dtBeneficiario, ref errMensaje))
                    return result = false;
                //Web Usuario
                if (!insertarWebUsuBLL(pemTo.COD_PER, dtWebUsu, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool insertarBeneficiarioBLL(string COD_PER, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {

                pebTo.COD_PER = COD_PER;
                pebTo.ITEM = rw[0].ToString();
                pebTo.NRO_CONTRATO = rw[1].ToString();
                pebTo.NOMBRE = rw[2].ToString();
                pebTo.DNI = rw[3].ToString();
                pebTo.FE_NAC = Convert.ToDateTime(rw[4]);
                pebTo.EMAIL = rw[5].ToString();
                pebTo.TEL_CONTACTO = rw[6].ToString();
                pebTo.PLAZO_ACTIVACION = rw[7].ToString();
                if (!pebBLL.insertarPersonaBeneficiarioBLL(pebTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarWebUsuBLL(string COD_PER, DataTable dt, ref string errMensaje)
        {
            bool result = true;
            foreach (DataRow rw in dt.Rows)
            {
                uswTo.COD_PER = COD_PER;
                uswTo.NRO_CONTRATO = Convert.ToString(rw["usu_web_contrato"]);
                uswTo.ITEM = Convert.ToString(rw["usu_web_item"]);
                uswTo.USUARIO = Convert.ToString(rw["usu_web_usuario"]);
                uswTo.PASSWORD = Convert.ToString(rw["usu_web_password"]);
                if (!uswBLL.insertarUsuarioWebBLL(uswTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarSustitutoBLL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool result = true;
            personaSustitutoBLL pesBLL = new personaSustitutoBLL();
            if (!pesBLL.insertarPersonaSustitutoBLL(pesTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool insertarClaseBLL(string COD_PER, DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                pelTo.COD_PER = COD_PER;
                pelTo.COD_CLASE = rw[0].ToString();
                pelTo.COD_CAT = rw[2].ToString();
                pelTo.LINEA_CRED = Convert.ToDecimal(rw[4]);
                pelTo.FORMA_PAGO = rw[5].ToString();
                pelTo.CONDICION_VENTA = rw[7].ToString();
                pelTo.NRO_DIAS = rw[9].ToString();
                if (!pelBLL.insertarPersonaClaseBLL(pelTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarDireccionBLL(string COD_PER, DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                pedTo.COD_PER = COD_PER;
                pedTo.COD_TIPO = rw[0].ToString();
                pedTo.COD_PAIS = rw[4].ToString();
                pedTo.COD_DEP = rw[6].ToString();
                pedTo.COD_PRO = rw[7].ToString();
                pedTo.COD_DIST = rw[8].ToString();
                pedTo.DIRECCION = rw[2].ToString();
                pedTo.REFERENCIA = rw[3].ToString();
                if (!pedBLL.insertarPersonaDireccionBLL(pedTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarPersonaTelefonoBLL(string COD_PER, DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                pefTo.COD_PER = COD_PER;
                pefTo.COD_TIPO_FONO = rw[1].ToString();
                pefTo.ITEM = rw[0].ToString();
                pefTo.NRO_FONO = rw[3].ToString();
                if (!pefBLL.insertarPersonaFonoBLL(pefTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarPersonaContactoBLL(string COD_PER, DataTable dt, ref string errMensaje)
        {
            bool result = true;

            foreach (DataRow rw in dt.Rows)
            {
                pecTo.COD_PER = COD_PER;
                pecTo.ITEM = rw[0].ToString();
                pecTo.NOMBRE = rw[1].ToString();
                pecTo.DNI = rw[2].ToString();
                pecTo.TELEFONO = rw[3].ToString();
                pecTo.MAIL = rw[4].ToString();
                pecTo.OBSERVACION = rw[5].ToString();
                pecTo.STATUS_FE = rw[6].ToString();
                if (!pecBLL.insertarPersonaContactoBLL(pecTo, ref errMensaje))
                    return result = false;
            }
            return result;
        }
        public bool insertarMaestroPersonaBLL(personaMaestroTo pemTo, ref string cod_persona, ref string errMensaje)
        {
            bool result = true;
            if (!pemDAL.insertarMaestroPersonaDAL(pemTo, ref cod_persona, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificarMaestroPersonaBLL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool result = true;
            if (!pemDAL.modificarMaestroPersonaDAL(pemTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminarMaestroPersonaBLL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool result = true;
            if (!pemDAL.eliminarMaestroPersonaDAL(pemTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaMaestroPersonaBLL(personaMaestroTo pemTo, DataTable dtContactos, DataTable dtTelefono, DataTable dtDireccion,
            DataTable dtClase, personaSustitutoTo pesTo, DataTable dtBeneficiario, DataTable dtWebUsu, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //Maestro Persona
                if (!modificarMaestroPersonaBLL(pemTo, ref errMensaje))
                    return result = false;
                //Contactos elimina y adiciona
                //if (!eliminaPersonaContactoporCOD_PER(pemTo.COD_PER,ref errMensaje))
                //    return result = false;
                if (!insertarPersonaContactoBLL(pemTo.COD_PER, dtContactos, ref errMensaje))
                    return result = false;
                //Telefono elimina y adiciona
                //if (!eliminaPersonaTelefonoporCOD_PER(pemTo.COD_PER, ref errMensaje))
                //    return result = false;
                if (!insertarPersonaTelefonoBLL(pemTo.COD_PER, dtTelefono, ref errMensaje))
                    return result = false;
                //Direccion elimina y adiciona
                //if (!eliminaPersonaDireccionporCOD_PER(pemTo.COD_PER, ref errMensaje))
                //    return result = false;
                if (!insertarDireccionBLL(pemTo.COD_PER, dtDireccion, ref errMensaje))
                    return result = false;
                //Clase elimina y adiciona
                //if (!eliminaPersonaClaseporCOD_PER(pemTo.COD_PER, ref errMensaje))
                //    return result = false;
                if (!insertarClaseBLL(pemTo.COD_PER, dtClase, ref errMensaje))
                    return result = false;
                //Persona Sustituto
                if (pesTo.DNI_SUS != "" || pesTo.NOMBRE_SUS != "" || pesTo.DIRECCION_SUS != "" || pesTo.EMAIL_SUS != "" || pesTo.TELEFONO_SUS != "")
                {
                    if (!insertarMaestroPersonaSustitutoBLL(pesTo, ref errMensaje))
                        return result = false;
                }
                //Persona Beneficiario
                if (!insertarBeneficiarioBLL(pemTo.COD_PER, dtBeneficiario, ref errMensaje))
                    return result = false;
                //Web Usuario
                if (!insertarWebUsuBLL(pemTo.COD_PER, dtWebUsu, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        public bool insertarMaestroPersonaSustitutoBLL(personaSustitutoTo pesTo, ref string errMensaje)
        {
            bool result = true;
            personaSustitutoBLL pesBLL = new personaSustitutoBLL();
            if (!pesBLL.insertarPersonaSustitutoBLL(pesTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaPersonaBLL(personaMaestroTo pemTo, ref string errMensaje)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
            {
                bool result = true;
                //Persona Maestro
                if (!eliminarMaestroPersonaBLL(pemTo, ref errMensaje))
                    return result = false;
                ts.Complete();
                return result;
            }
        }
        private bool eliminaPersonaContactoporCOD_PER(string COD_PER, ref string errMensaje)
        {
            bool result = true;
            pecTo.COD_PER = COD_PER;
            if (!pecBLL.eliminarPersonaContactoBLL(pecTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminaPersonaTelefonoporCOD_PER(string COD_PER, ref string errMensaje)
        {
            bool result = true;
            pefTo.COD_PER = COD_PER;
            if (!pefBLL.eliminarPersonaFonoBLL(pefTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminaPersonaDireccionporCOD_PER(string COD_PER, ref string errMensaje)
        {
            bool result = true;
            pedTo.COD_PER = COD_PER;
            if (!pedBLL.eliminarPersonaDireccionBLL(pedTo, ref errMensaje))
                return result = false;
            return result;
        }
        private bool eliminaPersonaClaseporCOD_PER(string COD_PER, ref string errMensaje)
        {
            bool result = true;
            pelTo.COD_PER = COD_PER;
            if (!pelBLL.eliminarPersonaClaseBLL(pelTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool verificaCodigoIdentidadBLL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool result = true;
            if (!pemDAL.verificaCodigoIdentidadDAL(pemTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool verificaNroRucDniPersonaBLL(personaMaestroTo pemTo, ref bool val, ref string errMensaje)
        {
            bool result = true;
            if (!pemDAL.verificaNroRucDniPersonaDAL(pemTo, ref val, ref errMensaje))
                return result = false;
            return result;
        }
        public bool modificaMaestroPersonaxCambioPtoCobBLL(personaMaestroTo pemTo, ref string errMensaje)
        {
            bool result = true;
            if (!pemDAL.modificaMaestroPersonaxCambioPtoCobDAL(pemTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable ListarMaestroPersonaXNivel(string codNivel)
        {
            return pemDAL.ListarMaestroPersonaXNivel(codNivel);
        }

        public DataTable ObtenerPersonasXPuntoCobranza(string codPtoCob)
        {
            return pemDAL.ObtenerPersonasXPuntoCobranza(codPtoCob);
        }
    }
}
