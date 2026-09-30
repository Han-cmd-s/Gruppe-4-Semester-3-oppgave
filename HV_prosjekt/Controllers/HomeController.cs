using HV_prosjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HV_prosjekt.Controllers
{
    public class HomeController : Controller
    {
        //definerer en liste som en in-memory lagring
        private static List<PositionModel> positions = new List<PositionModel>();
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Map
        [HttpGet]
        public IActionResult Map()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Map(PositionModel model)
        {
            if (ModelState.IsValid)
            { 
                //Legger ny posisjon til "positions" listen
                positions.Add(model);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Show saved GeoJSON entries (in-memory)
        [HttpGet]
        public IActionResult Entries()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
