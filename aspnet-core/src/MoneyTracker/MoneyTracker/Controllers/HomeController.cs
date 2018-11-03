using Microsoft.AspNetCore.Mvc;

namespace MoneyTracker.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return Redirect("/swagger");
        }
    }
}