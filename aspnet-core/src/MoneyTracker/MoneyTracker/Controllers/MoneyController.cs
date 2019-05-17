using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Controllers {
    [Produces("application/json")]
    [Route("api/money")]
    public class MoneyController : Controller {

        public MoneyController() {

        }

        [HttpGet("add-budget")]
        public string AddBudget(string name) {
            return $"Welcome {name} to my money application!";
        }
    }
}