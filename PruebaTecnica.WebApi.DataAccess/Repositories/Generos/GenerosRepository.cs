using PruebaTecnica.WebApi.DataAccess.Core.Context;
using PruebaTecnica.WebApi.DataAccess.Core.Repository;

namespace PruebaTecnica.WebApi.DataAccess.Repositories.Generos
{
    public class GenerosRepository : Repository<Models.Genero, Entities.GeneroEntity>, IGenerosRepository
    {
        public GenerosRepository() : base(new PruebaTecnicaContext()) { }
        public GenerosRepository(PruebaTecnicaContext context) : base(context) { }
    }
}
