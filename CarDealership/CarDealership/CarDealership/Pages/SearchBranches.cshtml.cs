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
    public class SearchBranchesModel : PageModel
    {
        private CarDealershipContext _context;


        public SearchBranchesModel(CarDealershipContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            SearchCompleted = false;
        }


        [BindProperty]
        public string Search { get; set; }

        public bool SearchCompleted { get; set; }

        public ICollection<Branch> SearchResults { get; set; }


        public void OnPost()
        {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(Search))
            {
                // EXIT EARLY IF THERE IS NO SEARCH TERM PROVIDED
                return;
            }
            /*SearchResults = _context.Branch
                                    .Include(x => x.Branch_City)
                                    .Include(x => x.Zip_Code)
                                    .Include(x => x.IsOperational)
                                    .Include(x => x.Average_Rating)
                                    .Include(x => x.Review_Count)
                                    .Where(x => x.Branch_City.ToLower().Contains(Search.ToLower()))
                                    .ToList();*/

            SearchResults = _context.Branch.Where(x => x.Branch_City.ToLower().Contains(Search.ToLower())).ToList();


            SearchCompleted = true;
        }
    }
}