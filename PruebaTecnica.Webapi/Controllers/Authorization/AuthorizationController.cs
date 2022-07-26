using PruebaTecnica.Webapi.Authorization;
using PruebaTecnica.Webapi.Controllers.Authorization.Responses;
using PruebaTecnica.WebApi.Business.Managers.Authorization;
using PruebaTecnica.WebApi.Business.Managers.Authorization.Models;
using System;
using System.Net;
using System.Threading;
using System.Web.Http;

namespace PruebaTecnica.Webapi.Controllers.Authorization
{
    [AllowAnonymous]
    [RoutePrefix("api/")]
    public class AuthorizationController : ApiController
    {
        private GestorDeAutorizacion gestorDeAutorizacion => new GestorDeAutorizacion();

        [HttpGet]
        [ActionName("EchoPing")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [ActionName("EchoUser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [ActionName("Authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                if (login == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var userAuth = gestorDeAutorizacion.EsLoginValido(new DtoLogin { NombreDeUsuario = login.NombreDeUsuario, Contraseña = login.Contraseña });
                if (userAuth.EsSesionvalida)
                {
                    response.IdUsuario = userAuth.IdUsuario;
                    response.NombreDeUsuario = userAuth.NombreCompleto;
                    response.Token = TokenGenerator.GenerateTokenJwt(userAuth.NombreDeUsuario);
                    return Ok(response);
                }
                else
                {
                    response.Codigo = (int)HttpStatusCode.Unauthorized;
                    response.Mensaje = "El nombre de usuario o contraseña enviado no son correctos ";
                }
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
