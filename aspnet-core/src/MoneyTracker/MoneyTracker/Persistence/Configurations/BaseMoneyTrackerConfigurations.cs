using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Persistence.Configurations {
    public class BaseMoneyTrackerEntityConfigurations<TId, TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TId> {
        protected const string GetDateSqlMethodName = "GETDATE()";
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Id).IsRequired();
        }
    }

    public class BaseMoneyTrackerAuditedEntityConfigurations<TId, TEntity> : BaseMoneyTrackerEntityConfigurations<TId, TEntity> where TEntity : AuditedEntity<TId> {
        public override void Configure(EntityTypeBuilder<TEntity> builder) {
            base.Configure(builder);
            builder.Property(p => p.CreatedOn).IsRequired().HasDefaultValueSql(GetDateSqlMethodName);
            builder.Property(p => p.ModifiedOn).IsRequired(false);
            builder.Property(p => p.ModifiedBy).IsRequired(false);
        }
    }

    public class BaseMoneyTrackerFullAuditedEntityConfigurations<TId, TEntity> : BaseMoneyTrackerAuditedEntityConfigurations<TId, TEntity> where TEntity : FullAuditedEntity<TId> {
        public override void Configure(EntityTypeBuilder<TEntity> builder) {
            base.Configure(builder);
            builder.Property(p => p.DeletedOn).IsRequired(false).HasDefaultValueSql(GetDateSqlMethodName);
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.DeletedBy).IsRequired(false);
        }
    }
}
