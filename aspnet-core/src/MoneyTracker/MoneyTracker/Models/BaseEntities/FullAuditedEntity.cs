using System;

namespace MoneyTracker.Models.BaseEntities {
    public class FullAuditedEntity : AuditedEntity {
        public bool IsDeleted { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
