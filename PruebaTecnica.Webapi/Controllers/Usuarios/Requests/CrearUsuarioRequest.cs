﻿using PruebaTecnica.Webapi.Models.Base;
using PruebaTecnica.WebApi.Business.Managers.Usuarios.Models;

namespace PruebaTecnica.Webapi.Controllers.Usuarios.Requests
{
    public class CrearUsuarioRequest : RequestBase
    {
        public DtoUsuarioEnCRUD Usuario { get; set; }
    }
}