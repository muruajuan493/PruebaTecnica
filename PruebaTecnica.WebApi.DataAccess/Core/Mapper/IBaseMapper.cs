using System.Collections.Generic;

namespace PruebaTecnica.WebApi.DataAccess.Core.Mapper
{
    public interface IBaseMapper<TModel, TEntity> {
        TEntity ModelToEntity(TModel model);
        IEnumerable<TEntity> ModelToEntity(IEnumerable<TModel> model);

        TModel EntityToModel(TEntity entity);
        IEnumerable<TModel> EntityToModel(IEnumerable<TEntity> entity);
    }
}
