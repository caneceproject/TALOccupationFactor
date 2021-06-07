using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TALOccupationFactor.Models
{
    public class PersonalDataModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DOB { get; set; }

        public string Occupation { get; set; }

        public decimal SumInsured { get; set; }

        public decimal MonthlyExpenses { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public int Total { get; set; }
    }
}