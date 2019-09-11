using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Corecrud.Models;

namespace Corecrud.Models
{
    public class CorecrudContext : DbContext
    {
        public CorecrudContext (DbContextOptions<CorecrudContext> options)
            : base(options)
        {
        }

        public DbSet<Corecrud.Models.Destinations> Destinations { get; set; }

        public DbSet<Corecrud.Models.Country> Country { get; set; }
    }
}
