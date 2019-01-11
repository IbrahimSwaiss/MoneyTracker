using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Models;

namespace MoneyTracker.Presistance.Configurations {
    public class BudgetEntityConfiguration : IEntityTypeConfiguration<Budget> {
        public void Configure(EntityTypeBuilder<Budget> builder) {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
        }
    }
}
