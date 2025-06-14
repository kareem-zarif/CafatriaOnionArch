using Cafe.Domain;
using Cafe.Domain.CoreInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cafe.Infrastructure.EF
{
    public class BaseRepo<TEntity, TId> : IBaseRepo<TEntity, TId>
        where TEntity : BaseEnt<TId>
        where TId : struct

    {
        //readonly :: Thread-safe because fields can't be changed after initialization in case of multiple threads(so all classes inheits from BaseRepo will use same _dbContext,_dbset)
        private readonly CafeDBContext _dbContext; //represent conn to database
        private readonly DbSet<TEntity> _dbset; //represent dbset in memory
        public BaseRepo(CafeDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            var foundEntity = await _dbset.AsNoTracking().FirstOrDefaultAsync(x => x.Equals(id)); //AsNoTracking() for read only :: better peformance
            //Equals rather than == with AsNoTracking() ::
            //--Better SQL translation => Better performance
            //--Better performance
            //--2More reliable value type comparison => Equals checks for reference or value equality , == compares by reference

            if (foundEntity == null)
                throw new Exception($"Not Found Entity with id : {id}");

            return foundEntity;
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return await _dbset.ToListAsync();

            return await _dbset.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var EntEntry = await _dbset.AddAsync(entity);
            return EntEntry.Entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var FoundEnt = await GetAsync(entity.Id); //detach old entity as it using asNoTracking()
            _dbset.Attach(entity); //attach comming new entity
            _dbset.Entry(entity).State=EntityState.Modified;//to force update when saveChanges

            return entity;
        }
        public async Task<TEntity> DeleteAsync(TId id)
        {
            var foundEntity = await GetAsync(id);
            _dbset.Remove(foundEntity);

            return foundEntity;
        }
    }
}
