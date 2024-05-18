using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebApp.Models;

namespace SalesWebApp.Data
{
    public class SalesWebAppContext : DbContext
    {
        public SalesWebAppContext (DbContextOptions<SalesWebAppContext> options) : base(options) { }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

    }
}
