using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Controllers.Resources;
using MoneyTracker.Interfaces;
using MoneyTracker.Interfaces.Repositories;
using MoneyTracker.Utilities;
using System.Threading.Tasks;
using System.Transactions;
using MoneyTracker.Interfaces.Utilities;
using MoneyTracker.Models;
using Transaction = MoneyTracker.Models.Transaction;

namespace MoneyTracker.Controllers {
    [Produces("application/json")]
    [Route("api/money")]
    public class MoneyController : Controller {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IUoW _uow;
        private readonly IClock _clock;

        public MoneyController(IBudgetRepository budgetRepository, IUoW uow, IClock clock) {
            _budgetRepository = budgetRepository;
            _uow = uow;
            _clock = clock;
        }

        [HttpPost("add-budget")]
        public async Task AddBudget(BudgetInput input) {
            Guard.AssertNotNull(input);

            var budget = new Budget {
                Name = input.Name,
                MonthlyBudget = input.MonthlyBudget,
                WeeklyBudget = input.WeeklyBudget,
                MonthlySavingAmount = input.MonthlySavingAmount,
                MonthlySavingPercentage = input.MonthlySavingPercentage,
                Transactions = GetTransactionsFromInput(input.Transactions),
                CreatedOn = _clock.Now
            };

            await _budgetRepository.Add(budget);
            await _uow.Complete();
        }

        private IList<Transaction> GetTransactionsFromInput(List<TransactionInput> inputTransactions) {
            var transactions = new List<Transaction>();
            foreach (var transaction in inputTransactions) {
                transactions.Add(new Transaction {
                    Name = transaction.Name,
                    Repeat = transaction.Repeat,
                    Amount = transaction.Amount,
                    CreatedOn = _clock.Now
                });
            }
            return transactions;
        }

        [HttpGet("get-budget")]
        public async Task<Budget> GetBudget(int id) {
            var asd = await _budgetRepository.GetByIdAsync(id);
            return asd;
        }
    }
}