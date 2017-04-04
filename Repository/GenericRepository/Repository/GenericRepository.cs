using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Model;

namespace GenericRepository.Repository
{
    public abstract class GenericRepository<TEntity> :
        IRepository<TEntity> where TEntity : class,new()
    {
        internal CenterEntities context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(CenterEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null,
            params string []includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public void Update(TEntity entityToUpdate)
        {
            //dbSet.AddOrUpdate(entityToUpdate);
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}
