using PruebaTecnica.WebApi.Business.Managers.Clientes.Models;
using PruebaTecnica.WebApi.DataAccess.Entities;
using PruebaTecnica.WebApi.DataAccess.Repositories.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.WebApi.Business.Managers.Clientes
{
    public class GestorDeClientes
    {
        private IClientesRepository ClienteRepository => new ClientesRepository();

        public DtoClienteEnLista ObtenerCliente(int Id)
        {
            var cliente = ClienteRepository.ObtenerPorId(Id);
            return new DtoClienteEnLista(cliente);
        }

        public List<DtoClienteEnLista> ObtenerClientes()
        {
            var clientes = ClienteRepository.ObtenerTodos();
            return clientes.Select(u => new DtoClienteEnLista(u)).ToList();
        }

        public DtoClienteEnCRUD ObtenerCrearCliente()
        {
            return new DtoClienteEnCRUD();
        }

        public DtoClienteEnLista CrearCliente(DtoClienteEnCRUD cliente)
        {
            if (!ValidarNuevoCliente(cliente, out string motivoDeValidacion))
            {
                throw new Exception(motivoDeValidacion);
            }

            ClienteEntity clienteEntity = new ClienteEntity
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                FechaDeNacimiento = DateTime.Parse(cliente.FechaDeNacimiento),
                IdGenero = cliente.IdGenero,
                IdTipoDeIdentificacion = cliente.IdTipoDeIdentificacion,
                NumeroDeIdentificacion = cliente.NumeroDeIdentificacion,
                Maneja = cliente.Maneja,
                UsaLentes = cliente.UsaLentes,
                TieneDiabetes = cliente.TieneDiabetes,
                TieneOtrasEnfermedades = cliente.TieneOtrasEnfermedades,
                OtrasEnfermedades = cliente.OtrasEnfermedades,
                ActivoActualmente = cliente.ActivoActualmente
            };
            var nuevoCliente = ClienteRepository.Crear(clienteEntity);
            return new DtoClienteEnLista(nuevoCliente);
        }

        private bool ValidarNuevoCliente(DtoClienteEnCRUD dtoCliente, out string motivo)
        {
            motivo = "";
            var cliente = ClienteRepository.ObtenerPorFiltro(u => u.NumeroDeIdentificacion == dtoCliente.NumeroDeIdentificacion).FirstOrDefault();
            if (cliente != null)
            {
                motivo = "Ya existe un usuario registrado con este numero de identificación .";
                return false;
            }

            return true;
        }

        public DtoClienteEnCRUD ObtenerActualizarCliente(int Id)
        {
            var cliente = ClienteRepository.ObtenerPorId(Id);
            return new DtoClienteEnCRUD(cliente);
        }

        public DtoClienteEnLista ActualizarCliente(DtoClienteEnCRUD cliente)
        {
            ClienteEntity clienteEntity = new ClienteEntity
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                FechaDeNacimiento = DateTime.Parse(cliente.FechaDeNacimiento),
                IdGenero = cliente.IdGenero,
                IdTipoDeIdentificacion = cliente.IdTipoDeIdentificacion,
                NumeroDeIdentificacion = cliente.NumeroDeIdentificacion,
                Maneja = cliente.Maneja,
                UsaLentes = cliente.UsaLentes,
                TieneDiabetes = cliente.TieneDiabetes,
                TieneOtrasEnfermedades = cliente.TieneOtrasEnfermedades,
                OtrasEnfermedades = cliente.OtrasEnfermedades,
                ActivoActualmente = cliente.ActivoActualmente
            };
            var nuevoCliente = ClienteRepository.Actualizar(clienteEntity);
            return new DtoClienteEnLista(nuevoCliente);
        }

        public void EliminarCliente(int Id)
        {
            ClienteRepository.Borrar(Id);
        }
    }
}
