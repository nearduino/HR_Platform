using HR_Platform_Internship.Data;
using HR_Platform_Internship.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HR_Platform_Internship.Repository.Implementations
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
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TKey id)
        {
            var entity = await Get(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> Get(TKey id)
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
