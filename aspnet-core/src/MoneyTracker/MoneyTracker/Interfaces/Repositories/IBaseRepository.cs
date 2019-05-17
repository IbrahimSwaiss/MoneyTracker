using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Interfaces.Repositories {
    public interface IBaseRepository<T> where T : Entity {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
