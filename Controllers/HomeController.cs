using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TALOccupationFactor.Models;

namespace TALOccupationFactor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult PersonalData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonalData(PersonalDataModel personalData)
        {
            if (ModelState.IsValid)
            {
                return View("CalculateData", personalData);
            }
            else
            {
                return View();
            }
        }
    }
}
