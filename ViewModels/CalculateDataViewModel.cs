using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TALOccupationFactor.ViewModels
{
    public class CalculateDataViewModel
    {
        public CalculateDataViewModel()
        {
        }

        public CalculateDataViewModel(PersonalDataViewModel person)
        {
            this.Name = person.Name;
            this.DOB = person.DOB;
            this.Age = CalculateAge(person.DOB);
        }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }
        public IEnumerable<SelectListItem> OccupationList { get; set; }

        [Display(Name = "Sum insured")]
        [Range(1000, 1000000, ErrorMessage = "Sum insured must be between 1,000 and 1,000,000")]
        public decimal SumInsured { get; set; }

        [Display(Name = "Monthly expenses")]
        public decimal MonthlyExpenses { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }

        [Required(ErrorMessage = "Please enter your postcode")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Please enter a valid postcode (4 digit number")]
        public string Postcode { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        /// <summary>  
        /// Calculate age using date of birth
        /// </summary>  
        /// <param name="dateOfBirth">Date of birth</param>  
        /// <returns>age</returns>  
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}