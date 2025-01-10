using Microsoft.EntityFrameworkCore;

namespace Sample.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SampleContext _sampleContext;
        private readonly DbSet<T> _dbSet;

        public Repository(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
            _dbSet = sampleContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            // TODO: return null instead of throw an exception
            if (entity is null)
            {
                throw new Exception("Entity not found");
            }

            return entity;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _sampleContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _sampleContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _sampleContext.SaveChangesAsync();
            }
        }
    }
}
