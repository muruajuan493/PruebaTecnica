using PruebaTecnica.WebApi.DataAccess.Entities;
using PruebaTecnica.WebApi.DataAccess.Repositories.Generos;
using PruebaTecnica.WebApi.DataAccess.Repositories.TiposDeIdentificacion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.WebApi.Business.Managers.Clientes.Models
{
    public class DtoClienteEnCRUD
    {
        private IGenerosRepository GenerosRepository => new GenerosRepository();
        private ITiposDeIdentificacionRepository TiposDeIdentificacionRepository => new TiposDeIdentificacionRepository();

        public DtoClienteEnCRUD()
        {
            Generos = GenerosRepository.ObtenerTodos().Select(g => new DtoSelector { Value = g.Id, Key = g.Descripcion }).ToList();
            TiposDeIdentificacion = TiposDeIdentificacionRepository.ObtenerTodos().Select(g => new DtoSelector { Value = g.Id, Key = g.Descripcion }).ToList();
        }
        public DtoClienteEnCRUD(ClienteEntity cliente)
        {
            Id = cliente.Id;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            FechaDeNacimiento = cliente.FechaDeNacimiento.ToString("yyyy-MM-dd");
            IdGenero = cliente.IdGenero;
            Generos = cliente.Generos.Select(g => new DtoSelector { Value = g.Id, Key = g.Descripcion }).ToList();
            IdTipoDeIdentificacion = cliente.IdTipoDeIdentificacion;
            TiposDeIdentificacion = cliente.TiposDeIdentificacion.Select(g => new DtoSelector { Value = g.Id, Key = g.Descripcion }).ToList();
            NumeroDeIdentificacion = cliente.NumeroDeIdentificacion;
            Maneja = cliente.Maneja;
            UsaLentes = cliente.UsaLentes;
            TieneDiabetes = cliente.TieneDiabetes;
            TieneOtrasEnfermedades = cliente.TieneOtrasEnfermedades;
            OtrasEnfermedades = cliente.OtrasEnfermedades;
            ActivoActualmente = cliente.ActivoActualmente;
        }


        public int Id { get; set; } = 0;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string FechaDeNacimiento { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        public int IdGenero { get; set; } = 0;
        public List<DtoSelector> Generos { get; set; }

        public int IdTipoDeIdentificacion { get; set; } = 0;
        public List<DtoSelector> TiposDeIdentificacion { get; set; }

        public string NumeroDeIdentificacion { get; set; } = string.Empty;

        public bool Maneja { get; set; } = false;

        public bool UsaLentes { get; set; } = false;

        public bool TieneDiabetes { get; set; } = false;

        public bool TieneOtrasEnfermedades { get; set; } = false;

        public string OtrasEnfermedades { get; set; } = string.Empty;

        public bool ActivoActualmente { get; set; } = true;
    }

    public class DtoSelector
    {
        public int Value { get; set; }
        public string Key { get; set; }
    }
}
