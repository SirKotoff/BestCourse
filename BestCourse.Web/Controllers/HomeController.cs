using BestCourse.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BestCourse.BLL;

namespace BestCourse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Currency cur)
        {
            var r = new RequestLogic();
            cur.Date = DateTime.Now;
            if (cur.City == "Brest")
            {
               cur.BestCurrencyBuy = r.GetDataFromRequest("https://myfin.by/currency/brest");
            }
            if (cur.City == "Minsk")
            {
                cur.BestCurrencyBuy = r.GetDataFromRequest("https://myfin.by/currency/minsk");
            }
            if (cur.City == "Gomel")
            {
                cur.BestCurrencyBuy = r.GetDataFromRequest("https://myfin.by/currency/gomel");
            }
            if (cur.City == "Mogilev")
            {
                cur.BestCurrencyBuy = r.GetDataFromRequest("https://myfin.by/currency/mogilev");
            }
            if (cur.City == "Grodno")
            {
                cur.BestCurrencyBuy = r.GetDataFromRequest("https://myfin.by/currency/grodno");
            }

            if (cur.City == "Vitebsk")
            {
                cur.BestCurrencyBuy = r.GetDataFromRequest("https://myfin.by/currency/vitebsk");
            }
            cur.BestCurrencySale = "2.65";
            db.currency.Add(cur);
            await db.SaveChangesAsync();
            return RedirectToAction("Privacy");
        }

        public IActionResult Privacy()
        {
            return View(db.currency.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}