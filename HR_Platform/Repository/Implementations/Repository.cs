using HR_Platform.Data;
using HR_Platform.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HR_Platform.Repository.Implementations
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Complete()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving to DB: " + ex.Message);
            }
        }

        public async Task Delete(TKey id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
            }
                
        }

        public async Task<TEntity?> Get(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
