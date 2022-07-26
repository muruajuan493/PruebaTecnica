using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Usuarios.Models;
using System.Collections.Generic;

namespace PruebaTecnica.Webapi.Controllers.Usuarios.Responses
{
    public class ObtenerUsuariosResponse : ResponseBase
    {
        public List<DtoUsuarioEnLista> Usuarios { get; set; }
    }
}