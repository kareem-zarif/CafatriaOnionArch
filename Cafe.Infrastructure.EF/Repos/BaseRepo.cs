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
        //repo :: use one instance of dbcontext and CRUP logic in one place and call CRUD any where , so any edit in CRUD for any entity will be one place => better maintance

        //readonly :: Thread-safe because fields can't be changed after initialization in case of multiple threads(so all classes inheits from BaseRepo will use same _dbContext,_dbset)
        private readonly CafeDBContext _dbContext; //represent conn to database
        private readonly DbSet<TEntity> _dbset; //represent dbset in memory
        public BaseRepo(CafeDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(TId id)
        {
            var foundEntity = await _dbset.FindAsync(id); //AsNoTracking() for read only :: better peformance

            if (foundEntity == null)
                throw new Exception($"Not Found Entity with id : {id}");

            return foundEntity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsyncAll(Expression<Func<TEntity, bool>> predicate = null) //still beneficial for not common filters as employess who age >37 and IsAbsent>30 days
        {
            if (predicate == null)
                return await _dbset.ToListAsync();

            return await _dbset.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetBlockedUsers() //benefits of common used methods -- as can change here once without change in every controlller use the service use this repo
        {
            return await _dbset.Where(x => x.Id.Equals(Guid.Empty)).ToListAsync();
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var EntEntry = await _dbset.AddAsync(entity);
            return EntEntry.Entity;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var FoundEnt = await GetAsync(entity.Id);

            _dbContext.Entry(FoundEnt).State = EntityState.Detached;//detached found

            _dbset.Attach(entity); //attach comming new entity
            _dbset.Entry(entity).State = EntityState.Modified;//to force update when saveChanges

            return entity;
        }
        public virtual async Task<TEntity> DeleteAsync(TId id)
        {
            var foundEntity = await GetAsync(id);
            _dbset.Remove(foundEntity);

            return foundEntity;
        }
    }
}
