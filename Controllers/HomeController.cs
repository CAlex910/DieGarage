using DieGarage.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
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
            return View(repository.FahrzeugenListe.OrderBy(m => m.ParkSpot));
            //return View(repository.FahrzeugenListe);
            //return View(repository.Autos.Union(repository.Motorraders));
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

        //public IActionResult Suchen()
        //{
        //    return View(repository.FahrzeugenListe);
        //}

        public IActionResult Suchen(string nummerschild)
        {
            return View(repository.FahrzeugenListe.Where(n => n.FahrzeugTyp == nummerschild));
        }

        //[HttpPost]
        //public IActionResult FahrzeugenEinfugen(Fahrzeugen neueFahrzeugen)
        //{
        //    ViewBag.Meldung = repository.FahrzeugEinfugen(neueFahrzeugen);
        //    Console.WriteLine("test");
        //    return RedirectToAction("FahrzeugenList");
        //    //return View(neueFahrzeugen);
        //}

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