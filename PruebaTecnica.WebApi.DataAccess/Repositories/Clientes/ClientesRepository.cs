using PruebaTecnica.WebApi.DataAccess.Core.Context;
using PruebaTecnica.WebApi.DataAccess.Core.Repository;

namespace PruebaTecnica.WebApi.DataAccess.Repositories.Clientes
{
    public class ClientesRepository : Repository<Models.Cliente, Entities.ClienteEntity>, IClientesRepository
    {
        public ClientesRepository() : base(new PruebaTecnicaContext()) { }
        public ClientesRepository(PruebaTecnicaContext context) : base(context) { }
    }
}
