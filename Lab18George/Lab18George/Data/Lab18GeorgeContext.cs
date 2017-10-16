using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab18George.Models;

namespace Lab18George.Models
{
    public class Lab18GeorgeContext : DbContext
    {
        public Lab18GeorgeContext (DbContextOptions<Lab18GeorgeContext> options)
            : base(options)
        {
        }

        public DbSet<Lab18George.Models.Destination> Destination { get; set; }

        public DbSet<Lab18George.Models.Supply> Supply { get; set; }
    }
}
