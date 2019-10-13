using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.Branches
{
    public class IndexModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public IndexModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        public IList<Branch> Branch { get;set; }

        public async Task OnGetAsync()
        {
            Branch = await _context.Branch.ToListAsync();
        }
    }
}
