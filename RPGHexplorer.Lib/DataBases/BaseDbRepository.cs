using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RPGHexplorer.Lib.DataBases
{
    public class BaseDbRepository<TEntity> where TEntity : class
    {
        protected MapDbContext Context { get; private set; }
        
        protected DbSet<TEntity> DB { get; private set; }

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
        
        protected async Task SaveAsync(TEntity entity)
        {
            DB.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
        
        protected async Task SaveAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DB.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            
            await Context.SaveChangesAsync();
        }
        
        protected async Task DeleteAsync(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DB.Attach(entity);
            }
            
            DB.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}