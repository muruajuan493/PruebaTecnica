using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Usuarios.Models;

namespace PruebaTecnica.Webapi.Controllers.Usuarios.Responses
{
    public class InicializarCrearUsuarioResponse : ResponseBase
    {
        public DtoUsuarioEnCRUD Usuario { get; set; }
    }
}