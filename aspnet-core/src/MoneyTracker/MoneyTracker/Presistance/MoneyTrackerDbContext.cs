using Microsoft.EntityFrameworkCore;

namespace MoneyTracker.Presistance {
    public class MoneyTrackerDbContext : DbContext {
        public MoneyTrackerDbContext(DbContextOptions<MoneyTrackerDbContext> options) : base(options) {
        }
    }
}
