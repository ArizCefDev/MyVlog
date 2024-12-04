using Microsoft.AspNetCore.Mvc;
using MyVlog.Models.Context;

namespace MyVlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _db;

        public HomeController(AppDBContext db)
        {
            _db = db;
        }

        public IActionResult Index() //GetList
        {
            var values = _db.Works.ToList();
            ViewBag.user = _db.Users.ToList();
            return View(values);
        }

        public IActionResult Detail(int id) //GetByid
        {
            var values = _db.Works.Find(id);
            ViewBag.user = _db.Users.ToList();
            return View(values);
        }
    }
}
