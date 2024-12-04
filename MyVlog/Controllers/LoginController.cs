using Microsoft.AspNetCore.Mvc;
using MyVlog.Models.Context;
using MyVlog.Models.Entity;

namespace MyVlog.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDBContext _db;

        public LoginController(AppDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.user = _db.Users.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(User w)
        {
            ViewBag.user = _db.Users.ToList();

            var user = _db.Users.Where(x => x.Username == w.Username);
            var pass = _db.Users.Where(x => x.Password == w.Password);
            if (user.Any() && pass.Any())
            {
                return RedirectToAction("AdminWork","Admin");
            }
            else
            {
                ViewBag.u = "Istifadeci adi yalnisdir";
                ViewBag.p = "Sifre yalnisdir";
            }
            return View(w);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.user = _db.Users.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User u)
        {
            ViewBag.user = _db.Users.ToList();
            var user = _db.Users.Count();

            if (user>=1)
            {
                ViewBag.mes = "Istifadeci movcuddur";
            }
            else
            {
                _db.Add(u);
                _db.SaveChanges();
                ViewBag.mes = "Hesabiniz yarandi";
            }
            return View(u);
        }
    }
}
