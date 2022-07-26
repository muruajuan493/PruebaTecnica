using PruebaTecnica.WebApi.DataAccess.Core.Entity;
using PruebaTecnica.WebApi.DataAccess.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PruebaTecnica.WebApi.DataAccess.Core.Mapper
{
    public abstract class BaseMapper<TModel, TEntity> :
        IBaseMapper<TModel, TEntity>
            where TModel : BaseModel, new()
            where TEntity : BaseEntity, new()
    {
        public virtual TEntity ModelToEntity(TModel model)
        {
            TEntity entity = new TEntity();

            MapperExtension.MatchAndMap(model, entity);

            return entity;
        }
        public virtual IEnumerable<TEntity> ModelToEntity(IEnumerable<TModel> models)
        {
            var data = models.Select(m => ModelToEntity(m));

            return data;
        }

        public virtual TModel EntityToModel(TEntity entity)
        {
            TModel model = new TModel();

            MapperExtension.MatchAndMap(entity, model);

            return model;
        }
        public virtual IEnumerable<TModel> EntityToModel(IEnumerable<TEntity> entities)
        {
            return entities.Select(e => EntityToModel(e));
        }
    }
}
