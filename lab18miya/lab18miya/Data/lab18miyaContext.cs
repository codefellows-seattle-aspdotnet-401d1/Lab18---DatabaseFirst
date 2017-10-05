using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab18miya.Models;

namespace lab18miya.Models
{
    public class lab18miyaContext : DbContext
    {
        public lab18miyaContext (DbContextOptions<lab18miyaContext> options)
            : base(options)
        {
        }

        public DbSet<lab18miya.Models.Destination> Destination { get; set; }

        public DbSet<lab18miya.Models.Supplies> Supplies { get; set; }

        public DbSet<lab18miya.Models.Weather> Weather { get; set; }
    }
}
