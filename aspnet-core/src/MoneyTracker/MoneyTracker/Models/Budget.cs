using System.Collections.Generic;
using System.Collections.ObjectModel;
using MoneyTracker.Models.BaseEntities;

namespace MoneyTracker.Models {
    public class Budget : FullAuditedEntity {
        public string Name { get; set; }
        public decimal MonthlyBudget { get; set; }
        public decimal WeeklyBudget { get; set; }
        public decimal MonthlySavingAmount { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Budget() {
            Transactions = new Collection<Transaction>();
        }
    }
}
