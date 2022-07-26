using PruebaTecnica.WebApi.DataAccess.Entities;

namespace PruebaTecnica.WebApi.Business.Managers.Usuarios.Models
{
    public class DtoUsuarioEnLista
    {
        public DtoUsuarioEnLista(UsuarioEntity usuario)
        {
            Id = usuario.Id;
            NombreCompleto = usuario.NombreCompleto;
            NombreDeUsuario = usuario.NombreDeUsuario;
            ActivoActualmente = usuario.ActivoActualmente ? "Si" : "No";
        }

        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreDeUsuario { get; set; }
        public string ActivoActualmente { get; set; }
    }
}
