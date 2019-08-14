using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Interfaces.Repositories;
using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Persistence.Repositories {
    public class BaseRepository<TId, TEntity> : IBaseRepository<TId, TEntity> where TEntity : Entity<TId> {
        private readonly MoneyTrackerDbContext _context;

        protected BaseRepository(MoneyTrackerDbContext context) {
            _context = context;
        }

        public async Task<TEntity> GetById(TId id) {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IList<TEntity>> GetAll() {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Add(TEntity entity) {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity) {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity) {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
