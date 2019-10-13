using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Pages
{
    public class IndexModel : PageModel
    {


        private CarDealershipContext _context;
        public IndexModel(CarDealershipContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            NoOfCarsAvailable = _context.Car.Where(x => x.IsAvailable == true).Count();
            NoofCarsSold = _context.Car.Where(x => x.IsAvailable == false).Count();
            TotalNoOfCustomers = _context.Customer.Count();
            NoofModels = _context.Manufacturer.Count();
        }
        public int NoOfCarsAvailable { get; set; }
        public int NoofCarsSold { get; set; }
        public int TotalNoOfCustomers { get; set; }
        public int NoofModels { get; set; }

    }
}