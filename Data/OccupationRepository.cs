using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TALOccupationFactor.Data
{
    /// <summary>
    ///  This class handles data access for Occupation rating and factor
    ///  Can be used to access persistent data stored in database
    /// </summary>
    public class OccupationRepository
    {
        /// <summary>  
        /// Return a list of occupations and their rating
        /// </summary>  
        /// <returns>occupation rating mapping</returns>  
        public Dictionary<string, string> GetOccupationRatings()
        {
            //Data is hard coded - imitate sql table
            var occupationRatingDict = new Dictionary<string, string>
            {
                { "Cleaner", "Light Manual" },
                { "Doctor", "Professional" },
                { "Author", "White Collar" },
                { "Farmer", "Heavy Manual" },
                { "Mechanic", "Heavy Manual" },
                { "Florist", "Light Manual" },
            };

            return occupationRatingDict;
        }

        /// <summary>  
        /// Return a list of ratings and their factor
        /// </summary>  
        /// <returns>rating and factor mapping</returns>  
        public Dictionary<string, double> GetRatingFactors()
        {
            //Data is hard coded - imitate sql table
            var ratingFactorDict = new Dictionary<string, double>
            {
                { "Professional", 1.1 },
                { "White Collar", 1.45 },
                { "Light Manual", 1.7 },
                { "Heavy Manual", 2.1 }
            };

            return ratingFactorDict;
        }
    }
}