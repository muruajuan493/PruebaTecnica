using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Usuarios.Models;

namespace PruebaTecnica.Webapi.Controllers.Usuarios.Responses
{
    public class ObtenerUsuarioResponse : ResponseBase
    {
        public DtoUsuarioEnLista Usuario { get; set; }
    }
}