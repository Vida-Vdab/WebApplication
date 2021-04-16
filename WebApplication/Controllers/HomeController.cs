using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Bestelling bestelling = new Bestelling();
            return View(bestelling);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Toevoegen(Bestelling bestelling)
        {
            var sessionVariableBestelling = HttpContext.Session.GetString("bestellingen");
            List<Bestelling> bestellijst;

            if (string.IsNullOrEmpty(sessionVariableBestelling))
            {
                bestellijst = new List<Bestelling>();
            }
            else
            {
                bestellijst = JsonConvert.DeserializeObject<List<Bestelling>>(sessionVariableBestelling);
            }
            bestellijst.Add(bestelling);
            var geserializeerdeLijst = JsonConvert.SerializeObject(bestellijst);
            HttpContext.Session.SetString("bestellingen", geserializeerdeLijst);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Mandje()
        {
            var sessionVariableBestelling = HttpContext.Session.GetString("bestellingen");
            List<Bestelling> bestellijst;

            if (string.IsNullOrEmpty(sessionVariableBestelling))
            {
                bestellijst = new List<Bestelling>();
            }
            else
            {
                bestellijst = JsonConvert.DeserializeObject<List<Bestelling>>(sessionVariableBestelling);
            }

            ViewBag.bestellingen = bestellijst;
            return View();
        }
        public IActionResult ToonBoodschap()
        {
            if (HttpContext.Session.GetString("bestellingen") != null)
                HttpContext.Session.Remove("bestellingen");
            return View();
        }

    }
}
