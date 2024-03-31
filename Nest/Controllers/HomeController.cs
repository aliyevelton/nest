using Microsoft.AspNetCore.Mvc;

namespace Nest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
