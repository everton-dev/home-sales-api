namespace Domain.Interfaces.Cloud
{
    public interface IFileStorageCloud<TInputEntity, TOutputEntity>
    {
        Task<TOutputEntity> AddAsync(TInputEntity file);
        Task RemoveAsync(TInputEntity file);
        Task<TOutputEntity> GetAsync(TInputEntity file);
        Task<ICollection<TOutputEntity>> GetAllAsync(string folder);
    }
}