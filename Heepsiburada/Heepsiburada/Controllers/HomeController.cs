using Heepsiburada.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Heepsiburada.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Context context;

        public HomeController(Context context, ILogger<HomeController> logger)
        {
            this.context = context;
            _logger = logger;
        }
        public List<Kategori> GetAllAsync()
        {
            var kategori =  context.Kategori.ToList();
            return kategori;
        }
        
        public IActionResult Index()
        {
            
            return View();

     
        }

        public IActionResult Privacy()
        {
            List<Kategori> kategori = GetAllAsync();
            return View(kategori);
        }

        public IActionResult Urun(int id)
        {
            List<Urun> uruns = (from u in context.Urun join k in context.Kategori on u.KategoriId equals k.KategoriId where k.KategoriId == id select u).ToList();
            return View(uruns);
        }


        [HttpGet] 
        public IActionResult YeniUrun()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult YeniUrun(Urun p1)
        {
            context.Urun.Add(p1);
            context.SaveChanges();
            return RedirectToAction("Privacy");
        }

        public IActionResult SIL(int id)
        {
            var urun = context.Urun.Find(id);
            context.Urun.Remove(urun);
            context.SaveChanges();
            return RedirectToAction("Privacy");
        }

        public IActionResult UrunGetir(int id)
        {
            var urn = context.Urun.Find(id);
            return View("UrunGetir", urn);
        }

        public IActionResult Guncelle(Urun p2)
        {
            var urn = context.Urun.Find(p2.UrunId);
            urn.UrunAd = p2.UrunAd;
            context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
