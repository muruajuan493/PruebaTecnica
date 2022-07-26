using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Clientes.Models;
using System.Collections.Generic;

namespace PruebaTecnica.Webapi.Controllers.Clientes.Responses
{
    public class ObtenerClientesResponse : ResponseBase
    {
        public List<DtoClienteEnLista> Clientes { get; set; }
    }
}