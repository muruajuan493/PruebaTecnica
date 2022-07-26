using PruebaTecnica.Webapi.Controllers.Clientes.Responses;
using PruebaTecnica.Webapi.Controllers.Usuarios.Requests;
using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Clientes;
using System;
using System.Net;
using System.Web.Http;

namespace PruebaTecnica.Webapi.Controllers.Clientes
{
    [Authorize]
    [RoutePrefix("api/")]
    public class ClientesController : ApiController
    {
        private GestorDeClientes gestorDeUruarios => new GestorDeClientes();

        [HttpGet]
        [ActionName("ObtenerCliente")]
        public IHttpActionResult ObtenerCliente(int Id)
        {
            ObtenerClienteResponse response = new ObtenerClienteResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerCliente(Id);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    response.Mensaje = $"No se encontró el cliente con el Id: { Id }";
                    return Ok(response);
                }

                response.Cliente = result;
            }
            catch(Exception ex)
            {
                response.Exito = false;
                response.Codigo = (int)HttpStatusCode.InternalServerError;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [ActionName("ObtenerClientes")]
        public IHttpActionResult ObtenerClientes()
        {
            ObtenerClientesResponse response = new ObtenerClientesResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerClientes();
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Clientes = result;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Codigo = (int)HttpStatusCode.InternalServerError;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [ActionName("InicializarCrearCliente")]
        public IHttpActionResult InicializarCrearCliente()
        {
            InicializarCrearClienteResponse response = new InicializarCrearClienteResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerCrearCliente();
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Cliente = result;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Codigo = (int)HttpStatusCode.InternalServerError;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [ActionName("CrearCliente")]
        public IHttpActionResult CrearCliente(CrearClienteRequest request)
        {
            CrearClienteResponse response = new CrearClienteResponse();

            try
            {
                var result = gestorDeUruarios.CrearCliente(request.Cliente);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Cliente = result;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Codigo = (int)HttpStatusCode.InternalServerError;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [ActionName("InicializarActualizarCliente")]
        public IHttpActionResult InicializarActualizarCliente(int Id)
        {
            InicializarActualizarClienteResponse response = new InicializarActualizarClienteResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerActualizarCliente(Id);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Cliente = result;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Codigo = (int)HttpStatusCode.InternalServerError;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [ActionName("ActualizarCliente")]
        public IHttpActionResult ActualizarCliente(ActualizarClienteRequest request)
        {
            ActualizarClienteResponse response = new ActualizarClienteResponse();

            try
            {
                var result = gestorDeUruarios.ActualizarCliente(request.Cliente);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Cliente = result;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Codigo = (int)HttpStatusCode.InternalServerError;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [ActionName("EliminarCliente")]
        public IHttpActionResult EliminarCliente(int Id)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                gestorDeUruarios.EliminarCliente(Id);
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Codigo = (int)HttpStatusCode.InternalServerError;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
    }
}
