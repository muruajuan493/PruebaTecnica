using PruebaTecnica.WebApi.DataAccess.Core.Context;
using PruebaTecnica.WebApi.DataAccess.Core.Entity;
using PruebaTecnica.WebApi.DataAccess.Core.Mapper;
using PruebaTecnica.WebApi.DataAccess.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PruebaTecnica.WebApi.DataAccess.Core.Repository
{
    public abstract class Repository<TModel, TEntity> : BaseMapper<TModel, TEntity>, IRepository<TModel, TEntity> 
        where TModel : BaseModel, new()
        where TEntity : BaseEntity, new()
    {
        internal PruebaTecnicaContext context;
        internal DbSet<TModel> dbSet;

        public Repository(PruebaTecnicaContext context)
        {
            this.context = context;
            dbSet = context.Set<TModel>();
        }

        private IEnumerable<TEntity> ObtenerActivos()
        {
            using (context)
            {
                var resultQuerry = this.dbSet.Where(a => a.Estado == "A").ToArray();
                var resultMapping = ModelToEntity(resultQuerry);
                return resultMapping;
            }
        }

        public virtual IEnumerable<TEntity> ObtenerTodos()
        {
            return ObtenerActivos();
        }
        public virtual TEntity ObtenerPorId(int id)
        {
            return ObtenerActivos().FirstOrDefault(a => a.Id == id);
        }
        public virtual IEnumerable<TEntity> ObtenerPorFiltro(Expression<Func<TModel, bool>> filter = null)
        {
            IQueryable<TModel> query = dbSet;

            query = query.Where(a => a.Estado == "A");

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return ModelToEntity(query.ToArray());
        }


        public virtual TEntity Crear(TEntity entity)
        {
            using (context)
            {
                var model = EntityToModel(entity);
                model.Estado = "A";
                model.FechaDeAlta = DateTime.Now;
                context.Entry(model).State = EntityState.Added;
                context.SaveChanges();
                return ModelToEntity(model);
            }
        }

        public virtual TEntity Actualizar(TEntity entity)
        {
            using (context)
            {
                var model = this.dbSet.Where(w => w.Estado == "A").ToArray().FirstOrDefault(f => f.Id == entity.Id);
                MapperExtension.MatchAndMap(entity, model);
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return ModelToEntity(model);
            }
        }

        public virtual TEntity Borrar(int id)
        {
            using (context)
            {
                var model = this.dbSet.Where(w => w.Estado == "A").ToArray().FirstOrDefault(f => f.Id == id);
                model.Estado = "B";
                model.FechaDeBaja = DateTime.Now;
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return ModelToEntity(model);
            }
        }
    }
}
