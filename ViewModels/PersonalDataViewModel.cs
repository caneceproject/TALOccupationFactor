using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TALOccupationFactor.ViewModels
{
    public class PersonalDataViewModel
    {
        public PersonalDataViewModel()
        {
        }

        public PersonalDataViewModel(CalculateDataViewModel person)
        {
            this.Name = person.Name;
            this.DOB = person.DOB;
        }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth")]
        [Display(Name = "Date of birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/YYYY}")]
        public DateTime DOB { get; set; }
    }
}