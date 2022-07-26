using PruebaTecnica.WebApi.DataAccess.Core.Context;
using PruebaTecnica.WebApi.DataAccess.Core.Repository;
using System.Linq;

namespace PruebaTecnica.WebApi.DataAccess.Repositories.Usuarios
{
    public class UsuariosRepository : Repository<Models.Usuario, Entities.UsuarioEntity>, IUsuariosRepository
    {
        public UsuariosRepository() : base(new PruebaTecnicaContext()) { }
        public UsuariosRepository(PruebaTecnicaContext context) : base(context) { }

        public Entities.UsuarioEntity ObtenerPorNombreDeUsuario(string userName)
        {
            return ObtenerPorFiltro(u => u.NombreDeUsuario == userName).FirstOrDefault();
        }
    }
}
