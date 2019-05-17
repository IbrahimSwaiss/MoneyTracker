using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Interfaces;
using MoneyTracker.Interfaces.Repositories;
using MoneyTracker.Models;

namespace MoneyTracker.Controllers {
    [Produces("application/json")]
    [Route("api/money")]
    public class MoneyController : Controller {
        private readonly IBudgetRepository _bueRepository;
        private readonly IUoW _uow;

        public MoneyController(IBudgetRepository bueRepository, IUoW uow)
        {
            _bueRepository = bueRepository;
            _uow = uow;
        }

        [HttpGet("add-budget")]
        public async Task AddBudget(Budget budget) {
            await _bueRepository.Add(budget);
            await _uow.Save();
        }
    }
}