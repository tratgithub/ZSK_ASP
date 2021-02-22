using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZSK_ASP.Models;

namespace ZSK_ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ZSKListe.ClearZSKListe();
            DAHRSListe.ClearDAHRSListe();
            return View();
        }

        [HttpGet]
        public ViewResult ZSKForm()
        {
            return View();
        }

        [HttpGet]
        public ViewResult DAHRSForm()
        {
            return View();
        }


        [HttpPost]
        public ViewResult ErgebnisinEuro(ZSKEinheiten zsk)
        {
            ZSKListe.AddZSKListe(zsk);

            ZSKListe.Einheitenliste.ElementAt(0).Euro = ZSKListe.Einheitenliste.ElementAt(0).Kuehe * zsk.PreisKuehe +
                ZSKListe.Einheitenliste.ElementAt(0).Schafe * zsk.PreisSchafe +
                ZSKListe.Einheitenliste.ElementAt(0).Ziegen * zsk.PreisZiegen +
                ZSKListe.Einheitenliste.ElementAt(0).KleineZiegen * zsk.PreisKlZiegen;
            return View(ZSKListe.Einheitenliste);
        }

        [HttpPost]
        public ViewResult PreisinTieren(ZSKEinheiten zsk)
        {
            int rest;
                
            int kuehe = zsk.Euro / zsk.PreisKuehe;
            rest = zsk.Euro % zsk.PreisKuehe;

            int schafe = rest / zsk.PreisSchafe;
            rest %= zsk.PreisSchafe;

            int ziegen = rest / zsk.PreisZiegen;
            rest %= zsk.PreisZiegen;

            int klziegen = rest / zsk.PreisKlZiegen;
            rest %= zsk.PreisKlZiegen;

            int restbetrag = rest;

            ZSKListe.AddZSKListe(new ZSKEinheiten { Kuehe = kuehe, Schafe = schafe, Ziegen = ziegen, KleineZiegen = klziegen, Rest = restbetrag });

            return View(ZSKListe.Einheitenliste);
        }


        [HttpPost]
        public ViewResult PreisinEuroDAHRS(DAHRSEinheiten dahrs)
        {
            DAHRSListe.AddDAHRSListe(dahrs);

            double PreisAal = dahrs.PreisDorsch / 11;

            double PreisHering = PreisAal / 5;

            double PreisRochen = 9 * PreisHering + 7 / PreisAal;

            double PreisSprotte = PreisHering / 11;

            DAHRSListe.Einheitenliste.ElementAt(0).Euro = DAHRSListe.Einheitenliste.ElementAt(0).Dorsche * dahrs.PreisDorsch +
                DAHRSListe.Einheitenliste.ElementAt(0).Aale * PreisAal +
                DAHRSListe.Einheitenliste.ElementAt(0).Heringe * PreisHering +
                DAHRSListe.Einheitenliste.ElementAt(0).Rochen * PreisRochen +
                DAHRSListe.Einheitenliste.ElementAt(0).Sprotten * PreisSprotte;
            return View(DAHRSListe.Einheitenliste);
        }

        [HttpPost]
        public ViewResult PreisinTierenDAHRS(DAHRSEinheiten dahrs)
        {
            double PreisAal = dahrs.PreisDorsch / 11;

            double PreisHering = PreisAal / 5;

            double PreisRochen = 9 * PreisHering + 7 / PreisAal;

            double PreisSprotte = PreisHering / 11;

            double rest;

            int dorsche = (int) Math.Floor(dahrs.Euro / dahrs.PreisDorsch); 
            rest = dahrs.Euro % dahrs.PreisDorsch;

            int rochen = (int) Math.Floor(rest / PreisRochen);
            rest %= PreisRochen;

            int aale = (int) Math.Floor(rest / PreisAal);
            rest %= PreisAal;

            int heringe = (int) Math.Floor(rest / PreisHering);
            rest %= PreisHering;

            int sprotten = (int) Math.Floor(rest / PreisSprotte);
            rest %= PreisSprotte;

            double restbetrag = Math.Floor(rest);

            DAHRSListe.AddDAHRSListe(new DAHRSEinheiten {Dorsche = dorsche, Rochen = rochen, Aale = aale, Heringe = heringe, Sprotten = sprotten, Rest = restbetrag });

            return View(DAHRSListe.Einheitenliste);
        }

        [HttpPost]
        public ViewResult DAHRSinZSK(DAHRSEinheiten dahrs, ZSKEinheiten zsk)
        {
            PreisinEuroDAHRS(dahrs);
            zsk.Euro = (int) dahrs.Euro;
            PreisinTieren(zsk);
            return View(ZSKListe.Einheitenliste);
        }

        [HttpPost]
        public ViewResult ZSKinDAHRS(ZSKEinheiten zsk, DAHRSEinheiten dahrs)
        {
            ErgebnisinEuro(zsk);
            dahrs.Euro = zsk.Euro;
            PreisinTierenDAHRS(dahrs);
            return View(DAHRSListe.Einheitenliste);
        }








        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
