using System;

namespace MoneyTracker.Models.BaseEntities {
    public class FullAuditedEntity<T> : AuditedEntity<T> {
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
