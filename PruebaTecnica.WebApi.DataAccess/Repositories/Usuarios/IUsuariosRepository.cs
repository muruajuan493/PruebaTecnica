using PruebaTecnica.WebApi.DataAccess.Core.Repository;

namespace PruebaTecnica.WebApi.DataAccess.Repositories.Usuarios
{
    public interface IUsuariosRepository : IRepository<Models.Usuario, Entities.UsuarioEntity>
    {
        Entities.UsuarioEntity ObtenerPorNombreDeUsuario(string userName);
    }
}
