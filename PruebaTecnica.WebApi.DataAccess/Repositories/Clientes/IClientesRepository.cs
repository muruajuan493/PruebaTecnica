using PruebaTecnica.WebApi.DataAccess.Core.Repository;

namespace PruebaTecnica.WebApi.DataAccess.Repositories.Clientes
{
    public interface IClientesRepository : IRepository<Models.Cliente, Entities.ClienteEntity>
    {
    }
}
