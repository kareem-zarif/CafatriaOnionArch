﻿using System.Linq.Expressions;

namespace Cafe.Domain.CoreInterfaces
{
    public interface IBaseRepo<TEntity, TId>
        //as update-create need TEntity , Get,Delete=> need TId 
        //Flexible ID type support / Better performance / Type safety at compile time /Optimized database queries
        where TEntity : BaseEnt<TId>
        where TId : struct

    {
        Task<TEntity> GetAsync(TId id);
        Task<IEnumerable<TEntity>> GetAsyncAll(Expression<Func<TEntity, bool>> predicate = null); //Using Expression<Func<>> •	Enables efficient filtering at the database level rather than in memory
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TId id);
    }
}
