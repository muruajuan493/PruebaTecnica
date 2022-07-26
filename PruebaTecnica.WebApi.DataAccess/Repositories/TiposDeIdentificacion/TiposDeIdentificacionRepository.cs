using PruebaTecnica.WebApi.DataAccess.Core.Context;
using PruebaTecnica.WebApi.DataAccess.Core.Repository;

namespace PruebaTecnica.WebApi.DataAccess.Repositories.TiposDeIdentificacion
{
    public class TiposDeIdentificacionRepository : Repository<Models.TipoDeIdentificacion, Entities.TipoDeIdentificacionEntity>, ITiposDeIdentificacionRepository
    {
        public TiposDeIdentificacionRepository() : base(new PruebaTecnicaContext()) { }
        public TiposDeIdentificacionRepository(PruebaTecnicaContext context) : base(context) { }
    }
}
