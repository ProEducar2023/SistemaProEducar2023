using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class usuariosBLL
    {
        usuariosDAL usuDAL = new usuariosDAL();

        public DataTable obtenerUsuariosparaUsuariosCargoBLL()
        {
            return usuDAL.obtenerUsuariosparaUsuariosCargoDAL();
        }
        public DataTable obtenerTodosUsuariosBLL()
        {
            conexion._sqlGestion = null;//esto es para inicializar la cadena de conexion de la empresa
            conexion._sql = null;
            return usuDAL.obtenerTodosUsuariosDAL();
        }
        public DataTable obtenerUsuario_x_CodBLL(usuariosTo usuTo)
        {
            return usuDAL.obtenerUsuario_x_CodDAL(usuTo);
        }

    }
}
