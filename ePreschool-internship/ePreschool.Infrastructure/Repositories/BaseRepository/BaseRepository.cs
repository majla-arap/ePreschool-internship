using ePreschool.Core;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{

    public abstract class BaseRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        protected readonly DatabaseContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected DbConnection DbConnection => _dbContext.Database.GetDbConnection();

        public BaseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id, bool asNoTracking = false)
        {
            var entity = await _dbSet.FindAsync(id);

            if (asNoTracking)
                _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
       
        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return _dbSet.AddRangeAsync(entities);
        }


        public async Task RemoveByIdAsync(TPrimaryKey id, bool isSoft = true)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new NullReferenceException();

            if (isSoft)
            {
                if (entity is IBaseEntity)
                    (entity as IBaseEntity).IsDeleted = true;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities, bool isSoft = true) 
        {
            foreach (var entity in entities)
            {
                if (isSoft && entity is IBaseEntity)
                        (entity as IBaseEntity).IsDeleted = true;
            }

            if (isSoft)
                _dbSet.UpdateRange(entities);
            else
                _dbSet.RemoveRange(entities);
        }


        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
        
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

      
    }
}
