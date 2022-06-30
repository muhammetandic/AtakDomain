using AtakDomain.Common.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace AtakDomain.Persistence
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly AppDbContext _context;
        private IQueryable<T> _dbSet;

        public GenericRepositoryAsync(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Table => _dbSet;

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> FindAsync(Func<T, bool> predicate)
        {
            var result = _context.Set<T>().Where(predicate).ToList();
            return Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}