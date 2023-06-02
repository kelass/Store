using Microsoft.AspNetCore.Mvc;

namespace Store.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
