﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Models
{
    public class CoreCrudContext : DbContext
    {
        public CoreCrudContext (DbContextOptions<CoreCrudContext> options)
            : base(options)
        {
        }

        public DbSet<CoreCrud.Models.Destinations> Destinations { get; set; }

        public DbSet<CoreCrud.Models.Country> Country { get; set; }
    }
}
