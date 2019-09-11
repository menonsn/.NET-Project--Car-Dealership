using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCruds.Models;

namespace CoreCruds.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly CoreCruds.Models.CoreCrudsContext _context;

        public IndexModel(CoreCruds.Models.CoreCrudsContext context)
        {
            _context = context;
        }

        public IList<Country> Country { get;set; }

        public async Task OnGetAsync()
        {
            Country = await _context.Country.ToListAsync();
        }
    }
}
