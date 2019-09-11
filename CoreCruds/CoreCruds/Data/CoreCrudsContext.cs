using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreCruds.Models;

namespace CoreCruds.Models
{
    public class CoreCrudsContext : DbContext
    {
        public CoreCrudsContext (DbContextOptions<CoreCrudsContext> options)
            : base(options)
        {
        }

        public DbSet<CoreCruds.Models.Country> Country { get; set; }

        public DbSet<CoreCruds.Models.Destinations> Destinations { get; set; }
    }
}
