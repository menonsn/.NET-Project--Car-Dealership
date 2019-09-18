using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCruds.Models
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

        [NotMapped]
        public bool ischeap { get { if (CostOfTrip < 1222) { return true; } return false; } }
    }
}
