using Microsoft.AspNetCore.Mvc;

namespace PersonalPortal.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}