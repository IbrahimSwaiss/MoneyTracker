using System.Threading.Tasks;
using MoneyTracker.Interfaces;

namespace MoneyTracker.Persistence {
    public class UoW : IUoW {
        private readonly MoneyTrackerDbContext _context;

        public UoW(MoneyTrackerDbContext context) {
            _context = context;
        }
        public async Task Complete() {
            await _context.SaveChangesAsync();
        }
    }
}
