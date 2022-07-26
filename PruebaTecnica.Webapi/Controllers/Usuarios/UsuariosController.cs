using PruebaTecnica.Webapi.Controllers.Usuarios.Requests;
using PruebaTecnica.Webapi.Controllers.Usuarios.Responses;
using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Usuarios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace PruebaTecnica.Webapi.Controllers.Usuarios
{
    [Authorize]
    [RoutePrefix("api/")]
    public class UsuariosController : ApiController
    {
        private GestorDeUsuarios gestorDeUruarios => new GestorDeUsuarios();

        [HttpGet]
        [ActionName("ObtenerUsuario")]
        public IHttpActionResult ObtenerUsuario(int Id)
        {
            ObtenerUsuarioResponse response = new ObtenerUsuarioResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerUsuario(Id);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    response.Mensaje = $"No se encontró el cliente con el Id: {Id}";
                    return Ok(response);
                }

                response.Usuario = result;
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
        [ActionName("ObtenerUsuarios")]
        public IHttpActionResult ObtenerUsuarios()
        {
            ObtenerUsuariosResponse response = new ObtenerUsuariosResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerUsuarios();
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Usuarios = result;
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
        [ActionName("InicializarCrearUsuario")]
        public IHttpActionResult InicializarCrearUsuario()
        {
            InicializarCrearUsuarioResponse response = new InicializarCrearUsuarioResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerCrearUsuario();
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Usuario = result;
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
        [ActionName("CrearUsuario")]
        public IHttpActionResult CrearUsuario(CrearUsuarioRequest request)
        {
            CrearUsuarioResponse response = new CrearUsuarioResponse();

            try
            {
                var result = gestorDeUruarios.CrearUsuario(request.Usuario);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Usuario = result;
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
        [ActionName("InicializarActualizarUsuario")]
        public IHttpActionResult InicializarActualizarUsuario(int Id)
        {
            InicializarActualizarUsuarioResponse response = new InicializarActualizarUsuarioResponse();

            try
            {
                var result = gestorDeUruarios.ObtenerActualizarUsuario(Id);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Usuario = result;
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
        [ActionName("ActualizarUsuario")]
        public IHttpActionResult ActualizarUsuario(ActualizarUsuarioRequest request)
        {
            ActualizarUsuarioResponse response = new ActualizarUsuarioResponse();

            try
            {
                var result = gestorDeUruarios.ActualizarUsuario(request.Usuario);
                if (result == null)
                {
                    response.Codigo = (int)HttpStatusCode.Accepted;
                    return Ok(response);
                }

                response.Usuario = result;
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
        [ActionName("EliminarUsuario")]
        public IHttpActionResult EliminarUsuario(int Id)
        {
            ResponseBase response = new ResponseBase();

            try
            {
                gestorDeUruarios.EliminarUsuario(Id);
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
