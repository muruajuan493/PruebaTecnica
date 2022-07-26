using PruebaTecnica.Webapi.Models.Base;

namespace PruebaTecnica.Webapi.Controllers.Authorization.Responses
{
    public class LoginResponse : ResponseBase
    {
        public int IdUsuario { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Token { get; set; }
    }
}