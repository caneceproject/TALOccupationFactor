using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TALOccupationFactor.ViewModels;

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

        /// <summary>  
        /// Http Post for PersonalData view, handle action for Next button
        /// </summary>  
        /// <param name="person">View model storing properties for Personal Data page</param>  
        /// <returns>ActionResult</returns>  
        [HttpPost]
        public ActionResult PersonalData(PersonalDataViewModel person)
        {
            if (ModelState.IsValid) //Name and age are valid
            {
                CalculateDataViewModel calculateDataVM = new CalculateDataViewModel(person);
                calculateDataVM.OccupationList = GetOccupationList();
                calculateDataVM.StateList = GetStateList();

                ModelState.Clear();
                return View("CalculateData", calculateDataVM);
            }
            else
            {
                return View();
            }
        }

        /// <summary>  
        /// Http Post for CalculateData view, handle action for Back and Calculate buttons
        /// </summary>  
        /// <param name="person">View model storing properties for Calculate Data page</param>  
        /// <returns>ActionResult</returns>  
        [HttpPost]
        public ActionResult CalculateData(CalculateDataViewModel person, string submitButton)
        {
            //User clicks 'Back' button
            if (!String.IsNullOrEmpty(submitButton) && submitButton.Equals("Back"))
            {
                PersonalDataViewModel personalDataVM = new PersonalDataViewModel(person);
                return View("PersonalData", personalDataVM);
            }

            if (ModelState.IsValid)
            {
                //Gather all the info required to calculate the occupation factor
                decimal total = 0;
                person.Total = total;
            }

            person.OccupationList = GetOccupationList();
            person.StateList = GetStateList();
            return View("CalculateData", person);
        }


        private IEnumerable<SelectListItem> GetOccupationList()
        {
            //Temporary list, hardcoded for now
            List<SelectListItem> occupationList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "", Value = null },
                new SelectListItem { Text = "Cleaner", Value = "Cleaner" },
                new SelectListItem { Text = "Doctor", Value = "Doctor" },
                new SelectListItem { Text = "Author", Value = "Author" },
                new SelectListItem { Text = "Farmer", Value = "Farmer" },
                new SelectListItem { Text = "Mechanic", Value = "Mechanic" },
                new SelectListItem { Text = "Florist", Value = "Florist" }
            };

            return occupationList;
        }

        private IEnumerable<SelectListItem> GetStateList()
        {
            //Temporary list, hardcoded for now
            List<SelectListItem> stateList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "", Value = null },
                new SelectListItem { Text = "State 1", Value = "State 1" },
                new SelectListItem { Text = "State 2", Value = "State 2" }

            };

            return stateList;
        }
    }
}
