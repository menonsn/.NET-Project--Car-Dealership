using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.Makes
{
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public IndexModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Make> Make { get;set; }

        public async Task OnGetAsync()
        {
            Make = await _context.Make
                .Include(m => m.MakeType)
                .Include(m => m.Manufacturer).ToListAsync();
        }
    }
}
