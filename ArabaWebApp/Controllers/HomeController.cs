using ArabaWebApp.Data;
using ArabaWebApp.Data.Entities;
using ArabaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ArabaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArabaWepAppDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ArabaWepAppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ArabaListele()
        {
            return Json(_db.Arabalar.ToList());
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Privacy");
            }
            var silinenAraba = _db.Arabalar.Find(id);
            _db.Arabalar.Remove(silinenAraba);
            _db.SaveChanges();
            return RedirectToAction("Privacy");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
