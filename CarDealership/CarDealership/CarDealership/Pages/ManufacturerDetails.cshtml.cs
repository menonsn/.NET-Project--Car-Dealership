using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Pages
{
    public class ManufacturerDetailsModel : PageModel
    {

        private CarDealershipContext _context;
        public ManufacturerDetailsModel(CarDealershipContext context)
        {
            _context = context;
        }

        public ICollection<Manufacturer> Manufacturers { get; set; }

        public void OnGet()
        {

            Manufacturers = _context.Manufacturer
                                       .Include(m => m.Makes)
                                       .ThenInclude(mk => mk.MakeType)
                                       .ToArray();



        }
    }
}