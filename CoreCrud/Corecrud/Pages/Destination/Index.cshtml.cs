using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Corecrud.Models;

namespace Corecrud.Pages.Destination
{
    public class IndexModel : PageModel
    {
        private readonly Corecrud.Models.CorecrudContext _context;

        public IndexModel(Corecrud.Models.CorecrudContext context)
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
