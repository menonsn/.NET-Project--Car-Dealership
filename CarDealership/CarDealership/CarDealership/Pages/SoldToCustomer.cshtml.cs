using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Pages.Shared
{
    public class SoldToCustomerModel : PageModel
    {
        private CarDealershipContext _context;
        public SoldToCustomerModel(CarDealershipContext context)
        {
            _context = context;
        }

        public ICollection<Customer> Customers { get; set; }

        public void OnGet()
        {

            Customers = _context.Customer
                                      .Include(c => c.Cars)
                                      .ToArray();
            //Customers = _context.Customer.OrderBy(x => x.Customer_Name).ToList();        

        }

    }
}