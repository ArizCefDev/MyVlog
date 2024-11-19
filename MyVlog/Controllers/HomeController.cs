using Microsoft.AspNetCore.Mvc;

namespace MyVlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
