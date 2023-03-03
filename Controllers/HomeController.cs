using DieGarage.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Diagnostics;

namespace DieGarage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly Repository repository = new Repository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FahrzeugenList()
        {
            ViewData["anzahl"] = repository.Parkhaus.FreiePlatze;

            return View(repository.FahrzeugenListe.OrderBy(m => m.ParkSpot).OrderBy(m => m.ParkEbene));
        }

        public IActionResult FahrzeugenErstellen()
        {
            Fahrzeugen fahrzeugen = new Fahrzeugen();
            ViewBag.Meldung = repository.FahrzeugenErstellen(fahrzeugen);

            return RedirectToAction("FahrzeugenList");
        }

        public IActionResult Einparken()
        {
            Fahrzeugen fahrzeugen = new Fahrzeugen();
            ViewBag.Meldung = repository.Einparken(fahrzeugen);

            return RedirectToAction("FahrzeugenList");
        }

        public IActionResult Ausparken()
        {
            Fahrzeugen fahrzeugen = new Fahrzeugen();
            ViewBag.Meldung = repository.Ausparken();

            return RedirectToAction("FahrzeugenList");
        }

        public IActionResult Suchen()
        {
            return View();
        }

        public IActionResult SuchergebnisseAnzeigen(string nummernschild)
        {
            return View("_FahrzeugenList", repository.FahrzeugenListe.Where(n => n.Nummernschild.Contains(nummernschild)));
        }

        public IActionResult Garage(int parkplätze, int etagen)
        {
            repository.GarageErstellen(parkplätze, etagen);

            return RedirectToAction(nameof(FahrzeugenList));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}