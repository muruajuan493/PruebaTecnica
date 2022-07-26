using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PruebaTecnica.Webapi.Models.Base
{
    public class ResponseBase
    {
        private bool _exito = true;
        public bool Exito
        {
            get
            {
                return _exito;
            }
            set
            {
                _exito = value;
            }
        }

        private int _codigo = (int)HttpStatusCode.OK;
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }

        public string Mensaje { get; set; }
    }
}