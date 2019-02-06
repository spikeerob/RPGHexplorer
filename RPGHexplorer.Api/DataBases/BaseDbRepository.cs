using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGHexplorer.Lib.Repositories;

namespace RPGHexplorer.Api.DataBases
{
    public abstract class BaseDbRepository<TEntity> where TEntity : class
    {
        protected MapDbContext Context { get; private set; }
        
        protected DbSet<TEntity> DB { get; private set; }

        public IUnitOfWork UnitOfWork => Context;
        
        protected BaseDbRepository(MapDbContext context)
        {
            Context = context;
            DB = context.Set<TEntity>();
        }

        protected async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DB;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        protected async Task<TEntity> GetAsync(params object[] ids)
        {
            return await DB.FindAsync(ids);
        }
        
        protected Task SaveAsync(TEntity entity)
        {
            DB.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            
            return Task.CompletedTask;
        }
        
        protected Task SaveAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DB.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            
            return Task.CompletedTask;
        }
        
        protected Task DeleteAsync(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DB.Attach(entity);
            }
            
            DB.Remove(entity);
            
            return Task.CompletedTask;
        }
    }
}