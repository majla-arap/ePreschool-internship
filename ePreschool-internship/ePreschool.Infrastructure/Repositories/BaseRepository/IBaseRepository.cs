namespace ePreschool.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity, TPrimaryKey>
    {
        Task<TEntity> GetByIdAsync(TPrimaryKey id, bool asNoTracking = false);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveByIdAsync(TPrimaryKey id, bool isSoft = true);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
