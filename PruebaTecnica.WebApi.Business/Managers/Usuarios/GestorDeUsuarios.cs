using PruebaTecnica.WebApi.Business.Managers.Usuarios.Models;
using PruebaTecnica.WebApi.DataAccess.Entities;
using PruebaTecnica.WebApi.DataAccess.Repositories.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.WebApi.Business.Managers.Usuarios
{
    public class GestorDeUsuarios
    {
        private IUsuariosRepository UsuarioRepository => new UsuariosRepository();

        public DtoUsuarioEnLista ObtenerUsuario(int Id)
        {
            var usuario = UsuarioRepository.ObtenerPorId(Id);
            return new DtoUsuarioEnLista(usuario);
        }

        public List<DtoUsuarioEnLista> ObtenerUsuarios()
        {
            var usuarios = UsuarioRepository.ObtenerTodos();
            return usuarios.Select(u => new DtoUsuarioEnLista(u)).ToList();
        }

        public DtoUsuarioEnCRUD ObtenerCrearUsuario()
        {
            return new DtoUsuarioEnCRUD();
        }

        public DtoUsuarioEnLista CrearUsuario(DtoUsuarioEnCRUD usuario)
        {
            if (!ValidarNuevoUsuario(usuario, out string motivoDeValidacion))
            {
                throw new Exception(motivoDeValidacion);
            }

            UsuarioEntity usuarioEntity = new UsuarioEntity
            {
                NombreCompleto = usuario.NombreCompleto,
                NombreDeUsuario = usuario.NombreDeUsuario,
                Contraseña = usuario.Contraseña,
                ActivoActualmente = usuario.ActivoActualmente
            };
            var nuevoUsuario = UsuarioRepository.Crear(usuarioEntity);
            return new DtoUsuarioEnLista(nuevoUsuario);
        }

        private bool ValidarNuevoUsuario(DtoUsuarioEnCRUD dtoUsuario, out string motivo)
        {
            motivo = "";
            var usuario = UsuarioRepository.ObtenerPorNombreDeUsuario(dtoUsuario.NombreDeUsuario);
            if (usuario != null)
            {
                motivo = "Ya existe un usuario registrado con este nombre de usuario.";
                return false;
            }

            return true;
        }

        public DtoUsuarioEnCRUD ObtenerActualizarUsuario(int Id)
        {
            var usuario = UsuarioRepository.ObtenerPorId(Id);
            return new DtoUsuarioEnCRUD(usuario);
        }

        public DtoUsuarioEnLista ActualizarUsuario(DtoUsuarioEnCRUD usuario)
        {
            UsuarioEntity usuarioEntity = new UsuarioEntity
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                NombreDeUsuario = usuario.NombreDeUsuario,
                Contraseña = usuario.Contraseña,
                ActivoActualmente = usuario.ActivoActualmente
            };
            var nuevoUsuario = UsuarioRepository.Actualizar(usuarioEntity);
            return new DtoUsuarioEnLista(nuevoUsuario);
        }

        public void EliminarUsuario(int Id)
        {
            UsuarioRepository.Borrar(Id);
        }
    }
}
