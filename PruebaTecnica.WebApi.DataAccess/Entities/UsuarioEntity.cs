using PruebaTecnica.WebApi.DataAccess.Core.Entity;

namespace PruebaTecnica.WebApi.DataAccess.Entities
{
    public partial class UsuarioEntity : BaseEntity
    {
        public string NombreCompleto { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool ActivoActualmente { get; set; }
    }
}
