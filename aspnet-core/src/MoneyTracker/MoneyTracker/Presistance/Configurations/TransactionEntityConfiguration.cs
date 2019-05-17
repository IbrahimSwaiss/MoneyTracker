using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Models;

namespace MoneyTracker.Presistance.Configurations {
    public class TransactionEntityConfiguration : BaseMoneyTrackerFullAuditedEntityConfigurations<int, Transaction> {
        public override void Configure(EntityTypeBuilder<Transaction> builder) {
            base.Configure(builder);
            builder.ToTable("Transactions");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            //builder.HasOne<Budget>().WithMany().HasForeignKey(t => t.BudgetId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
