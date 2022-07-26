using PruebaTecnica.WebApi.Business.Managers.Authorization.Models;
using PruebaTecnica.WebApi.DataAccess.Repositories.Usuarios;

namespace PruebaTecnica.WebApi.Business.Managers.Authorization
{
    public class GestorDeAutorizacion
    {
        private IUsuariosRepository UsuarioRepository => new UsuariosRepository();

        public DtoLogin EsLoginValido(DtoLogin login)
        {
            var user = UsuarioRepository.ObtenerPorNombreDeUsuario(login.NombreDeUsuario);

            if (user != null)
            {
                if (user.Contraseña == login.Contraseña)
                {
                    login.IdUsuario = user.Id;
                    login.NombreCompleto = user.NombreCompleto;
                    login.EsSesionvalida = true;
                }
            }

            return login;
        }
    }
}
