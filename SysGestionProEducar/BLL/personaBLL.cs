using DAL;
using Entidades;
using System;
using System.Data;
namespace BLL
{
    public class personaBLL
    {
        personaDAL perDAL = new personaDAL();
        personaTo perTo = new personaTo();
        public DataTable obtenerPersonaUsuariosCargoBLL()
        {
            return perDAL.obtenerPersonaUsuariosCargoDAL();
        }
        public DataTable obtenerTipoDocBLL()
        {
            return perDAL.obtenerTipoDocDAL();
        }
        public string obtenerCodTipoDocBLL(string desc)
        {
            return perDAL.obtenerCodTipoDocDAL(desc);
        }
        public bool insertaPersonaUsuariosCargoBLL(string COD_PER, string DESC_PER, string NOMBRE, string PATERNO, string MATERNO,
            string COD_TIPO_DOC, string NRO_DOC, string MAIL, string COD_USUARIO, string NICK, ref string errMensaje)
        {
            bool result = true;
            perTo.COD_PER = COD_PER;
            perTo.DESC_PER = DESC_PER;
            perTo.NOMBRE = NOMBRE;
            perTo.PATERNO = PATERNO;
            perTo.MATERNO = MATERNO;
            perTo.COD_TIPO_DOC = COD_TIPO_DOC;
            perTo.NRO_DOC = NRO_DOC;
            perTo.MAIL = MAIL;
            perTo.COD_USUARIO = COD_USUARIO;
            perTo.NICK = NICK;

            if (!perDAL.insertaPersonaUsuariosCargoDAL(perTo, ref errMensaje))
                return result = false;
            return result;
        }

        public DataTable ObtenerMaestroPersonaProgNivel()
        {
            return perDAL.ObtenerMaestroPersonaProgNivel();
        }
       
        public DataTable ObtenerMaestroPersonaXNivel(string codNivel)
        {
            return perDAL.ObtenerMaestroPersonaXNivel(codNivel);
        }

        public bool modificaPersonaUsuariosCargoBLL(string COD_PER, string DESC_PER, string NOMBRE, string PATERNO, string MATERNO,
            string COD_TIPO_DOC, string NRO_DOC, string MAIL, string COD_USUARIO, string NICK, ref string errMensaje)
        {
            bool result = true;
            perTo.COD_PER = COD_PER;
            perTo.DESC_PER = DESC_PER;
            perTo.NOMBRE = NOMBRE;
            perTo.PATERNO = PATERNO;
            perTo.MATERNO = MATERNO;
            perTo.COD_TIPO_DOC = COD_TIPO_DOC;
            perTo.NRO_DOC = NRO_DOC;
            perTo.MAIL = MAIL;
            perTo.COD_USUARIO = COD_USUARIO;
            perTo.NICK = NICK;
            if (!perDAL.modificaPersonaUsuariosCargoDAL(perTo, ref errMensaje))
                return result = false;
            return result;
        }
        public bool eliminaPersonaUsuariosBLL(string COD_PER, ref string errMensaje)
        {
            bool result = true;
            perTo.COD_PER = COD_PER;
            if (!perDAL.eliminaPersonaUsuariosDAL(perTo, ref errMensaje))
                return result = false;
            return result;
        }
        public DataTable obtenerCargoBLL()
        {
            return perDAL.obtenerCargoDAL();
        }
        public DataTable obtenerEquipoVentaBLL()
        {
            return perDAL.obtenerEquipoVentaDAL();
        }
        public DataTable obtieneCargoporUsuarioBLL(string COD_PER)
        {
            perTo.COD_PER = COD_PER;
            return perDAL.obtieneCargoporUsuarioDAL(perTo);
        }
        public bool insertaCargoPersonaUsuariosCargoBLL(string COD_PER, string COD_CARGO, ref string errMensaje)
        {
            bool result = true;
            perTo.COD_PER = COD_PER;
            perTo.COD_TIPO_DOC = COD_CARGO;
            if (!perDAL.insertaCargoPersonaUsuariosCargoDAL(perTo, ref errMensaje))
                return result = false;

            return result;
        }
        public string obtenerCodCargoVentaBLL(string DES_CARGO)
        {
            perTo.DESC_PER = DES_CARGO;
            return perDAL.obtenerCodCargoVentaDAL(perTo);
        }
        public DataTable obtenerPersonalPedidoBLL()
        {
            return perDAL.obtenerPersonalPedidoDAL();
        }
        public DataTable obtenerUsuariosparaDesaprobarBLL(string TABLA_COD, string COD_MOD)
        {
            return perDAL.obtenerUsuariosparaDesaprobarDAL(TABLA_COD, COD_MOD);
        }
        public DataTable obtenerUsuariosparaDesaprobarVentasBLL()
        {
            return perDAL.obtenerUsuariosparaDesaprobarVentasDAL();
        }
        public string ValidarUsuarioEliminacionAnulacionBLL(string claveEncriptada, string usuarioNick)
        {
            return perDAL.ValidarUsuarioEliminacionAnulacionDAL(claveEncriptada, usuarioNick);
        }
        public int ValidarDirectorioDesaprobarBLL(string codigo, string MODULO)
        {
            return perDAL.ValidarDirectorioDesaprobarDAL(codigo, MODULO);
        }
        public bool eliminarCargoPersonaUsuariosCargoBLL(string COD_PER, string COD_CARGO, ref string errMensaje)
        {
            bool result = true;
            perTo.COD_PER = COD_PER;
            perTo.COD_TIPO_DOC = COD_CARGO;
            if (!perDAL.eliminarCargoPersonaUsuariosCargoDAL(perTo, ref errMensaje))
                return result = false;

            return result;
        }
        public DataTable obtenerPersonaparaReporteBLL(personaTo perTo)
        {
            return perDAL.obtenerPersonaparaReporteDAL(perTo);
        }
        public DataTable obtenerPersonaxCodPerBLL(personaTo perTo)
        {
            return perDAL.obtenerPersonaxCodPerDAL(perTo);
        }
        public DataTable obtenerGestoresBLL()
        {
            return perDAL.obtenerGestoresDAL();
        }

        public DataTable obtenerGestoresUbicacionBLL(personaTo perTo)
        {
            return perDAL.obtenerGestoresUbicacionDAL(perTo);
        }
        public DataTable obtenerGestoresUbicacionDirectaBLL()
        {
            return perDAL.obtenerGestoresUbicacionDirectaDAL();
        }
        public DataTable ObtenerSubUbicacion(string table, string tipo, string codigo, string codNivel)
        {
            return perDAL.ObtenerSubUbicacion(table, tipo, codigo, codNivel);
        }

        public DataTable ObtenerGestoresXAreaTrabajo()
        {
            return perDAL.ObtenerGestoresXAreaTrabajo();
        }

        public DataTable ObtenerVendedoresXSupervisor(string codSupervisor)
        {
            return perDAL.ObtenerVendedoresXSupervisor(codSupervisor);
        }

        public DataTable ObtenerPersonaNivelVentaHijoXPadre(string codDirNacional, string codDirVentas, string codSupervisor, string codNivelMostrar)
        {
            return perDAL.ObtenerPersonaNivelVentaHijoXPadre(codDirNacional, codDirVentas, codSupervisor, codNivelMostrar);
        }

        /// <summary>
        /// Obtiene vendedores por superior(supervisor, director de ventas, director nacional)
        /// </summary>
        /// <param name="codSuperior">código de superior(supervisor, director de ventas, director nacional)</param>
        /// <param name="codNivel">código de nivel de superior(supervisor, director de ventas, director nacional)</param>
        /// <returns>Lista de vendedore en DataTable</returns>
        public DataTable ObtenerVendedoresXSuperior(string codSuperior, string codNivel)
        {
            return perDAL.ObtenerVendedoresXSuperior(codSuperior, codNivel);
        }

        public DataTable ObtenerMaestroPersonaXNivelSinAnonimos(string codNivel)
        {
            return perDAL.ObtenerMaestroPersonaXNivelSinAnonimos(codNivel);
        }
    }
}
