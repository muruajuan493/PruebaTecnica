using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Clientes.Models;

namespace PruebaTecnica.Webapi.Controllers.Usuarios.Requests
{
    public class CrearClienteRequest : RequestBase
    {
        public DtoClienteEnCRUD Cliente { get; set; }
    }
}