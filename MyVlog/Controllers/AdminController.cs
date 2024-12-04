using Microsoft.AspNetCore.Mvc;
using MyVlog.Models.Context;
using MyVlog.Models.Entity;

namespace MyVlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDBContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(AppDBContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult AdminWork()
        {
            ViewBag.user = _db.Users.ToList();
            var values = _db.Works.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AdminCreate()
        {
            ViewBag.user = _db.Users.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminCreate(Work w)
        {
            ViewBag.user = _db.Users.ToList();

            if (w.Image != null && w.Image.Length > 0)
            {
                // Şəkil üçün unikal bir ad yarat
                var fileName = Path.GetFileNameWithoutExtension(w.Image.FileName);
                var extension = Path.GetExtension(w.Image.FileName);
                var newFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

                // Şəkilin saxlanacağı tam yol
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "WebImages", newFileName);

                // Faylı saxla
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await w.Image.CopyToAsync(stream);
                }

                // Şəkilin yolunu modeli doldur
                w.ImageURL = $"/WebImages/{newFileName}";
            }

            w.Date = DateTime.Now;
            _db.Add(w);
            _db.SaveChanges();
            return RedirectToAction("AdminWork");
        }

        public IActionResult AdminDelete(int id)
        {
            var x = _db.Works.Find(id);
            _db.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("AdminWork");
        }
    }
}
