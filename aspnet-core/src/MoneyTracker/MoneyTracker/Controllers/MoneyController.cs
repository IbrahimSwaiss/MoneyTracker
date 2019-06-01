using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Interfaces;
using MoneyTracker.Interfaces.Repositories;
using MoneyTracker.Models;
using MoneyTracker.Utilities;

namespace MoneyTracker.Controllers {
    [Produces("application/json")]
    [Route("api/money")]
    public class MoneyController : Controller {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IUoW _uow;

        public MoneyController(IBudgetRepository budgetRepository, IUoW uow)
        {
            _budgetRepository = budgetRepository;
            _uow = uow;
        }

        [HttpGet("add-budget")]
        public async Task AddBudget(Budget budget) {
            Guard.AssertNotNull(budget);
            await _budgetRepository.Add(budget);
            await _uow.Complete();
        }
    }
}