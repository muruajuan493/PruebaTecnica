using PruebaTecnica.WebApi.DataAccess.Core.Model;

namespace PruebaTecnica.WebApi.DataAccess.Models
{
    public class Usuario : BaseModel
    {
        public string NombreCompleto { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool ActivoActualmente { get; set; }
    }
}
