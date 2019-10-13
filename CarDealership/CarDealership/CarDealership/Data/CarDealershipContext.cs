using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Models
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext (DbContextOptions<CarDealershipContext> options)
            : base(options)
        {
        }

      

        public DbSet<CarDealership.Models.Branch> Branch { get; set; }

        

        public DbSet<CarDealership.Models.Car> Car { get; set; }

        public DbSet<CarDealership.Models.Customer> Customer { get; set; }

        public DbSet<CarDealership.Models.Manufacturer> Manufacturer { get; set; }

        public DbSet<CarDealership.Models.Make> Make { get; set; }

        

        public DbSet<CarDealership.Models.MakeType> MakeType { get; set; }
    }
}
