using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Clientes.Models;

namespace PruebaTecnica.Webapi.Controllers.Clientes.Responses
{
    public class InicializarCrearClienteResponse : ResponseBase
    {
        public DtoClienteEnCRUD Cliente { get; set; }
    }
}