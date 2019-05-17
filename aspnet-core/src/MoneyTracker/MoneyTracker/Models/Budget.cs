using System.Collections.Generic;
using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Models {
    public class Budget : FullAuditedEntity<int> {
        public string Name { get; set; }
        public decimal MonthlyBudget { get; set; }
        public decimal WeeklyBudget { get; set; }
        public decimal MonthlySavingAmount { get; set; }
        public short MonthlySavingPercentage { get; set; }
        public IList<Transaction> Transactions { get; set; }
    }
}
