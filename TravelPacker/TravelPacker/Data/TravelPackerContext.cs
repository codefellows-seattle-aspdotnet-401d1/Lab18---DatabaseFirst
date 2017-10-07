using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelPacker.Models;

namespace TravelPacker.Models
{
    public class TravelPackerContext : DbContext
    {
        public TravelPackerContext (DbContextOptions<TravelPackerContext> options)
            : base(options)
        {
        }

        public DbSet<TravelPacker.Models.Destination> Destination { get; set; }

        public DbSet<TravelPacker.Models.Product> Product { get; set; }
    }
}
