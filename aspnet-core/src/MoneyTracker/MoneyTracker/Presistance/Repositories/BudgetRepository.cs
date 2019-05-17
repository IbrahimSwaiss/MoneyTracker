using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Interfaces.Repositories;
using MoneyTracker.Models;

namespace MoneyTracker.Presistance.Repositories {
    public class BudgetRepository : IBudgetRepository {
        private readonly MoneyTrackerDbContext _context;

        public BudgetRepository(MoneyTrackerDbContext context) {
            _context = context;
        }

        public async Task<Budget> GetById(int id) {
            return await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IList<Budget>> GetAll() {
            return await _context.Budgets.ToListAsync();
        }

        public async Task Add(Budget entity) {
            await _context.Budgets.AddAsync(entity);
        }

        public void Update(Budget entity) {
            _context.Budgets.Update(entity);
        }

        public void Delete(Budget entity) {
            _context.Budgets.Remove(entity);
        }
    }
}
