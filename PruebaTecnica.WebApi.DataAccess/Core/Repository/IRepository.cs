using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PruebaTecnica.WebApi.DataAccess.Core.Repository
{
    public interface IRepository<TModel, TEntity>
    {
        IEnumerable<TEntity> ObtenerTodos();
        TEntity ObtenerPorId(int id);
        IEnumerable<TEntity> ObtenerPorFiltro(Expression<Func<TModel, bool>> filter);
        
        TEntity Crear(TEntity entity);

        TEntity Actualizar(TEntity entity);

        TEntity Borrar(int id);
    }
}
