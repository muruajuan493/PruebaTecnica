using PruebaTecnica.WebApi.DataAccess.Entities;
using System;

namespace PruebaTecnica.WebApi.Business.Managers.Clientes.Models
{
    public class DtoClienteEnLista
    {
        public DtoClienteEnLista(ClienteEntity cliente)
        {
            Id = cliente.Id;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            Edad = (int)Math.Floor((DateTime.Now - cliente.FechaDeNacimiento).TotalDays / 365.25D);
            Genero = cliente.Genero.Descripcion;
            TipoDeIdentificacion = cliente.TipoDeIdentificacion.Descripcion;
            NumeroDeIdentificacion = cliente.NumeroDeIdentificacion;
            Maneja = cliente.Maneja ? "Si" : "No";
            UsaLentes = cliente.UsaLentes ? "Si" : "No";
            TieneDiabetes = cliente.TieneDiabetes ? "Si" : "No";
            TieneOtrasEnfermedades = cliente.TieneOtrasEnfermedades ? "Si" : "No";
            OtrasEnfermedades = cliente.OtrasEnfermedades;
            ActivoActualmente = cliente.ActivoActualmente ? "Si" : "No";
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Genero { get; set; }

        public string TipoDeIdentificacion { get; set; }

        public string NumeroDeIdentificacion { get; set; }

        public string Maneja { get; set; }

        public string UsaLentes { get; set; }

        public string TieneDiabetes { get; set; }

        public string TieneOtrasEnfermedades { get; set; }

        public string OtrasEnfermedades { get; set; }

        public string ActivoActualmente { get; set; }
    }
}
