using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Controllers {
    [Produces("application/json")]
    [Route("api/Money")]
    public class MoneyController : Controller {
        [HttpGet]
        public string Index(string name) {
            return $"Welcome {name} to my money application!";
        }
    }
}