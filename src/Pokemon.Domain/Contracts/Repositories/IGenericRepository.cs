namespace Pokemon.Domain.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPagedAsync(int page, int pageSize);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity); 
        Task DeleteAsync(Guid id);
    }
}
