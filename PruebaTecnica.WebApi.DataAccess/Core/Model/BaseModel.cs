using System;

namespace PruebaTecnica.WebApi.DataAccess.Core.Model
{
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
    }
}
