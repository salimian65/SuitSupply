using System.Linq.Expressions;

namespace SuitSupply.Framework.Domain
{
    public interface IRepository<TEntity>
    {
        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(TEntity entity);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetById(object id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate);
        
        Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
    }
}