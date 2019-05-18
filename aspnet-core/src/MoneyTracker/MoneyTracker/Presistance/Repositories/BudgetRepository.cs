using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Interfaces.Repositories;
using MoneyTracker.Models;

namespace MoneyTracker.Presistance.Repositories {
    public class BudgetRepository : BaseRepository<int, Budget>, IBudgetRepository {
        private readonly MoneyTrackerDbContext _context;

        public BudgetRepository(MoneyTrackerDbContext context) : base(context) {
            _context = context;
        }

        public async Task<Budget> GetByIdAsync(int id) {
            return await _context.Budgets.Include(b => b.Transactions).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
