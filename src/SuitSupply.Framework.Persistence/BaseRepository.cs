using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuitSupply.Framework.Domain;

namespace Soshyant.Framework.Persistence
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DataSet;

        protected BaseRepository(DbContext context)
        {
            Context = context;
            DataSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await DataSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(TEntity retailer)
        {
            DataSet.Update(retailer);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            DataSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DataSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        
        public virtual async Task<TEntity> GetById(object id)
        {
            return await DataSet.FindAsync(id);
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException();
            return await DataSet.AnyAsync(predicate);
        }
    }
}