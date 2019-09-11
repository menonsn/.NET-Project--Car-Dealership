using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corecrud.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public ICollection<Destinations> Destinations { get; set; }
    }
}
