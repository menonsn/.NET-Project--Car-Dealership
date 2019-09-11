using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCruds.Models;

namespace CoreCruds.Pages.Destinaton
{
    public class IndexModel : PageModel
    {
        private readonly CoreCruds.Models.CoreCrudsContext _context;

        public IndexModel(CoreCruds.Models.CoreCrudsContext context)
        {
            _context = context;
        }

        public IList<Destinations> Destinations { get;set; }

        public async Task OnGetAsync()
        {
            Destinations = await _context.Destinations
                .Include(d => d.Location).ToListAsync();
        }
    }
}
