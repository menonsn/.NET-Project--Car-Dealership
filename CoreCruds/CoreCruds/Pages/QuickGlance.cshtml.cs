using System;
using System.Collections.Generic;
using System.Linq;
using CoreCruds.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCruds.Pages
{
    public class QuickGlanceModel : PageModel
    {
        private CoreCrudsContext _context;



        public ICollection<Destinations> destinations { get; set; }

        public QuickGlanceModel(CoreCrudsContext context)

        {

            _context = context;

        }

        public void OnGet()

        {

            destinations = _context.Destinations.Include(coll => coll.Location).ToArray();

        }
    }
}