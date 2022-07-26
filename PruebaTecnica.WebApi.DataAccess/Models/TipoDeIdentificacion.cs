using PruebaTecnica.WebApi.DataAccess.Core.Model;

namespace PruebaTecnica.WebApi.DataAccess.Models
{
    public class TipoDeIdentificacion : BaseModel
    {
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
    }
}
