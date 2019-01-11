using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Models {
    public class Transaction : FullAuditedEntity {
        public string Name { get; set; }
        public bool Repeat { get; set; }
        public decimal Amount { get; set; }
        public int BudgetId { get; set; }
    }
}
