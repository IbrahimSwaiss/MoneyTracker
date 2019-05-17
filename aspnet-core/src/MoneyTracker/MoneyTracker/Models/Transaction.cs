using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Models {
    public class Transaction : FullAuditedEntity {
        public string Name { get; set; }
        public int Repeat { get; set; }//TODO: add enum, to repeat daily or weekly, or monthly
        public decimal Amount { get; set; }
        public int BudgetId { get; set; }
    }
}
