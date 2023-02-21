using DieGarage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DieGarage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly Repository repository = new Repository();


        // ###########################################################

        // Azure - CosmosDB - Entity Framework

        // L - DependencyInjectionKontakte

        // ###########################################################

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(repository.Garage);
        }

        public IActionResult FahrzeugenList()
        {
            return View(repository.Autos.Union(repository.Motorraders));
        }

        public IActionResult FahrzeugenEinfugen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FahrzeugenEinfugen(Fahrzeugen neueFahrzeugen)
        {
            ViewBag.Meldung = repository.FahrzeugEinfugen(neueFahrzeugen);

            return View(neueFahrzeugen);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}