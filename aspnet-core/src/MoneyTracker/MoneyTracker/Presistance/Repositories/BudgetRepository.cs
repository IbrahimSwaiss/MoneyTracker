using System;
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
            return await _context.Budgets.FirstOrDefaultAsync(b=>b.Id == id);
        }

        public async Task<IList<Budget>> GetAll() {
            return await _context.Budgets.ToListAsync();
        }

        public Task Add(Budget entity) {
            throw new NotImplementedException();
        }

        public Task Update(Budget entity) {
            throw new NotImplementedException();
        }

        public Task Delete(Budget entity) {
            throw new NotImplementedException();
        }
    }
}
