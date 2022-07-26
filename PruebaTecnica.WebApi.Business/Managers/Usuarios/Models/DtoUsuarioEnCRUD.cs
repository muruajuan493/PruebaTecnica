using PruebaTecnica.WebApi.DataAccess.Entities;

namespace PruebaTecnica.WebApi.Business.Managers.Usuarios.Models
{
    public class DtoUsuarioEnCRUD
    {
        public DtoUsuarioEnCRUD() { }
        public DtoUsuarioEnCRUD(UsuarioEntity usuario)
        {
            Id = usuario.Id;
            NombreCompleto = usuario.NombreCompleto;
            NombreDeUsuario = usuario.NombreDeUsuario;
            Contraseña = usuario.Contraseña;
            ActivoActualmente = usuario.ActivoActualmente;
        }

        public int Id { get; set; } = 0;
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreDeUsuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public bool ActivoActualmente { get; set; } = true;
    }
}
