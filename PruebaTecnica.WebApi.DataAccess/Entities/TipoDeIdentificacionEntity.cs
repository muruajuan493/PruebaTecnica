using PruebaTecnica.WebApi.DataAccess.Core.Entity;

namespace PruebaTecnica.WebApi.DataAccess.Entities
{
    public class TipoDeIdentificacionEntity : BaseEntity
    {
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
    }
}
