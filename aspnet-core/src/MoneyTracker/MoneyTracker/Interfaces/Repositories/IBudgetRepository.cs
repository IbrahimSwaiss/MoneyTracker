using MoneyTracker.Models;
using System.Threading.Tasks;

namespace MoneyTracker.Interfaces.Repositories {
    public interface IBudgetRepository : IBaseRepository<int, Budget> {
        Task<Budget> GetByIdAsync(int id);
    }
}
