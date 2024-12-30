
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FluxoDeCaixa.Infrastructure.SQLite.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : EntityControl
    {
        protected FluxoDeCaixaDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(FluxoDeCaixaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbSet.AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetAsync(string? id)
            => await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression)
            => await _dbSet.AsNoTracking().Where(expression).ToListAsync();

        public void Add(TEntity entity)
            => _context.Add(entity);

        public void Update(TEntity entity)
            => _context.Update(entity);

        public void Delete(TEntity entity)
            => _context.Remove(entity);

        public async Task<bool> SaveChangesAsync(TEntity entity)
        {
            if (await GetAsync(entity.Id) is null)
            {
                Add(entity);
            }
            else
            {
                Update(entity);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task StartTransactionAsync()
          => await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync()
         => await _context.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync()
          => await _context.Database.RollbackTransactionAsync();

        public void Dispose()
          => _context?.Dispose();
    }
}
