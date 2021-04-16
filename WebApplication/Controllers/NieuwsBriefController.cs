using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    public class NieuwsBriefController : Controller
    {
        private PersoonService _persoonService;

        public NieuwsBriefController(PersoonService persoonService)
        {
            _persoonService = persoonService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inschrijven(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Add(p);

                return View(p);
            }
            else
                return RedirectToAction("Index");
        }

        public IActionResult ValideerGeboortedatum(string Geboortedatum)
        {
            DateTime doorgegevenDatum;

            var nlDate = DateTime.TryParseExact(Geboortedatum, "dd/MM/yyyy", CultureInfo.GetCultureInfo("nl-BE"), DateTimeStyles.None, out doorgegevenDatum);
            var ukDate = DateTime.TryParseExact(Geboortedatum, "yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out doorgegevenDatum);

            if (!nlDate && !ukDate)
            {
                return Json("Gelieve een geldige datum in te voeren (dd/mm/jjjj) !");
            }
            else if (DateTime.Now < doorgegevenDatum)
            {
                return Json("Voer een datum uit het verleden in !");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
