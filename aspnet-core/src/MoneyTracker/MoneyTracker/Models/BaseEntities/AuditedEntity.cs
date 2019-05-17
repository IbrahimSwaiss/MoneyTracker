using System;

namespace MoneyTracker.Models.BaseEntities {
    public class AuditedEntity<T> : Entity<T> {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
