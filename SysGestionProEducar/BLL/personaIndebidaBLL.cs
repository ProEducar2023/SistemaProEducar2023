using DAL;
using Entidades;
using System.Data;
namespace BLL
{
    public class personaIndebidaBLL
    {
        personaIndebidaDAL pibDAL = new personaIndebidaDAL();

        public DataTable mostrarPersonaIndebidaBLL(personaIndebidaTo pibTo)
        {
            return pibDAL.obtenerPersonaIndebidaDAL(pibTo);
        }
    }
}
