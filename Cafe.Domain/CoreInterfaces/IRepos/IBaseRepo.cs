using System.Linq.Expressions;

namespace Cafe.Domain.CoreInterfaces
{
    public interface IBaseRepo<TEntity, TId>
    //as update-create need TEntity , Get,Delete=> need TId 
    //Flexible ID type support / Better performance / Type safety at compile time /Optimized database queries
        where TEntity : BaseEnt<TId>
        where TId : struct

    {
        Task<TEntity> GetAsync(TId id);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate); //Using Expression<Func<>> allows the query to be translated into SQL or other query languages for efficient database execution, rather than evaluating in memory
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TId id);
    }
}
