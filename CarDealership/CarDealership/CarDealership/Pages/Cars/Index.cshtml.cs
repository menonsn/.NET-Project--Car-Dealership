using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public IndexModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car
                .Include(c => c.Branch)
                .Include(c => c.Make)
                .Include(c => c.Owner).ToListAsync();
        }
    }
}
