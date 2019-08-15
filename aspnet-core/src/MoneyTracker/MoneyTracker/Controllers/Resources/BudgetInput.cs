using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Controllers.Resources {
    public class BudgetInput {
        [Required]
        [MaxLength(250)]
        [MinLength(0)]
        public string Name { get; set; }
        public decimal MonthlyBudget { get; set; }
        public decimal WeeklyBudget { get; set; }
        public decimal MonthlySavingAmount { get; set; }
        public short MonthlySavingPercentage { get; set; }
        public List<TransactionInput> Transactions { get; set; }
    }
}
