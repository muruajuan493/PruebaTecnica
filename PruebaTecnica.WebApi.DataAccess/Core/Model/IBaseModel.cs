using System;

namespace PruebaTecnica.WebApi.DataAccess.Core.Model
{
    public interface IBaseModel
    {
        int Id { get; set; }
        string Estado { get; set; }
        DateTime FechaDeAlta { get; set; }
        DateTime? FechaDeBaja { get; set; }
    }
}
