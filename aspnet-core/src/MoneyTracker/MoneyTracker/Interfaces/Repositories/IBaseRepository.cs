using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Interfaces.Repositories {
    public interface IBaseRepository<TId, TEntity> where TEntity : Entity<TId> {
        Task<TEntity> GetById(TId id);
        Task<IList<TEntity>> GetAll();
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
