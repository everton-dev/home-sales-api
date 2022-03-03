namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task<TEntity> GetByIdAsync(string id);
        Task<ICollection<TEntity>> GetAsync();
    }
}