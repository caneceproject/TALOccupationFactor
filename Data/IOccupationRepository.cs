using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALOccupationFactor.Data
{
    public interface IOccupationRepository
    {
        Dictionary<string, string> GetOccupationRatings();

        Dictionary<string, double> GetRatingFactors();
        
    }
}
