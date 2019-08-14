using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Models;

namespace MoneyTracker.Persistence.Configurations {
    public class BudgetEntityConfiguration : BaseMoneyTrackerFullAuditedEntityConfigurations<int, Budget> {
        public override void Configure(EntityTypeBuilder<Budget> builder) {
            base.Configure(builder);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
        }
    }
}
