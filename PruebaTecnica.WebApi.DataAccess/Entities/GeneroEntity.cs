using PruebaTecnica.WebApi.DataAccess.Core.Entity;

namespace PruebaTecnica.WebApi.DataAccess.Entities
{
    public partial class GeneroEntity : BaseEntity
    {
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
    }
}
