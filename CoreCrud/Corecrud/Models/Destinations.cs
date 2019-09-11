using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corecrud.Models
{
    public class Destinations
    {
        public int ID { get; set; }
        public string DestinationName { get; set; }
        public decimal Altitude { get; set; }
        public double? CostOfTrip { get; set; }
        public string MainAttraction { get; set; }
        public bool EquatorialWeather { get; set; }
        public DateTime DateOfVisit { get; set; }


        public int LocationId { get; set; }
        public Country Location { get; set; }

    }
}
