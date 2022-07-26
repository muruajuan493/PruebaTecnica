using PruebaTecnica.WebApi.DataAccess.Core.Entity;
using PruebaTecnica.WebApi.DataAccess.Repositories.Generos;
using PruebaTecnica.WebApi.DataAccess.Repositories.TiposDeIdentificacion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.WebApi.DataAccess.Entities
{
    public class ClienteEntity : BaseEntity
    {
        private IGenerosRepository GenerosRepository => new GenerosRepository();
        private ITiposDeIdentificacionRepository TiposDeIdentificacionRepository => new TiposDeIdentificacionRepository();

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        #region Genero
        private int _idGenero;
        public int IdGenero
        {
            get
            {
                if (_genero != null)
                    _idGenero = (int)_genero.Id;
                return _idGenero;
            }
            set
            {
                _genero = null;
                _idGenero = value;
            }
        }

        public GeneroEntity _genero;
        public GeneroEntity Genero
        {
            get
            {
                if (_idGenero > 0)
                {
                    _genero = GenerosRepository.ObtenerPorId(_idGenero);
                }
                return _genero;
            }
            set
            {
                _idGenero = 0;
                _genero = value;
                if (_idGenero > 0)
                {
                    _idGenero = (int)_genero.Id;
                }
            }
        }

        public List<GeneroEntity> Generos => GenerosRepository.ObtenerTodos().ToList();
        #endregion

        #region TipoDeIdentificacion
        public int _idTipoDeIdentificacion;
        public int IdTipoDeIdentificacion
        {
            get
            {
                if (_tipoDeIdentificacion != null)
                    _idTipoDeIdentificacion = (int)_tipoDeIdentificacion.Id;
                return _idTipoDeIdentificacion;
            }
            set
            {
                _tipoDeIdentificacion = null;
                _idTipoDeIdentificacion = value;
            }
        }

        private TipoDeIdentificacionEntity _tipoDeIdentificacion;
        public TipoDeIdentificacionEntity TipoDeIdentificacion
        {
            get
            {
                if (_idTipoDeIdentificacion > 0)
                {
                    _tipoDeIdentificacion = TiposDeIdentificacionRepository.ObtenerPorId(_idTipoDeIdentificacion);
                }
                return _tipoDeIdentificacion;
            }
            set
            {
                _idTipoDeIdentificacion = 0;
                _tipoDeIdentificacion = value;
                if (_idTipoDeIdentificacion > 0)
                {
                    _idTipoDeIdentificacion = (int)_tipoDeIdentificacion.Id;
                }
            }
        }

        public List<TipoDeIdentificacionEntity> TiposDeIdentificacion => TiposDeIdentificacionRepository.ObtenerTodos().ToList();
        #endregion

        public string NumeroDeIdentificacion { get; set; }

        public bool Maneja { get; set; }

        public bool UsaLentes { get; set; }

        public bool TieneDiabetes { get; set; }

        public bool TieneOtrasEnfermedades { get; set; }

        public string OtrasEnfermedades { get; set; }

        public bool ActivoActualmente { get; set; }
    }
}
