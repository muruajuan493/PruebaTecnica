using PruebaTecnica.WebApi.DataAccess.Core.Model;

namespace PruebaTecnica.WebApi.DataAccess.Models
{
    public class Genero : BaseModel
    {
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
    }
}
