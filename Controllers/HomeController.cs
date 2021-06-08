using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TALOccupationFactor.Data;
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
                CalculateDataViewModel calculateDataVM = new CalculateDataViewModel(person)
                {
                    OccupationList = GetOccupationList(),
                    StateList = GetStateList()
                };

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
                //Gather all the info required to calculate the total
                decimal total = 0;

                try
                {
                    if (person.Age > 0)
                    {
                        OccupationRepository occupationRepo = new OccupationRepository();

                        var occupationRatingDict = occupationRepo.GetOccupationRatings();
                        if (occupationRatingDict.TryGetValue(person.Occupation, out string rating))
                        {
                            var ratingFactorDict = occupationRepo.GetRatingFactors();
                            if (ratingFactorDict.TryGetValue(rating, out double factor))
                            {
                                //Formula: (SumInsured * OccupationRating) / (12 * 100 * Age)
                                total = person.SumInsured * (decimal)factor / (1200 * person.Age);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //logging ....
                }

                person.Total = total;
            }

            person.OccupationList = GetOccupationList();
            person.StateList = GetStateList();
            return View("CalculateData", person);
        }

        /// <summary>  
        /// Call data repository to populate Occupation drop down list
        /// </summary>  
        /// <returns>Select list item with a list of occupations</returns>  
        private IEnumerable<SelectListItem> GetOccupationList()
        {
            OccupationRepository occupationRepo = new OccupationRepository();
            var occupationRatingDict = occupationRepo.GetOccupationRatings();

            List<SelectListItem> occupationList = new List<SelectListItem>();
            occupationList.Add(new SelectListItem { Text = "", Value = null });

            foreach (KeyValuePair<string, string> occupationEntry in occupationRatingDict)
            {
                occupationList.Add(new SelectListItem { Text = occupationEntry.Key, Value = occupationEntry.Key });
            }

            return occupationList;
        }

        /// <summary>  
        /// Populate state drop down list
        /// </summary>  
        /// <returns>Select list item with a list of states</returns>  
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
