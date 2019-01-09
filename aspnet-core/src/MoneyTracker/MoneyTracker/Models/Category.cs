using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Models {
    public class Category : FullAuditedEntity {
        public string Name { get; set; }
    }
}
