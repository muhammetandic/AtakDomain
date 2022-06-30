namespace AtakDomain.Common.Intarfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<List<T>> FindAsync(Func<T, bool> predicate);

        IQueryable<T> Table { get; }
    }
}