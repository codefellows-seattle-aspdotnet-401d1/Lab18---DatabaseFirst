using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab18Cameorn.Models;

namespace Lab18Cameorn.Models
{
    public class Lab18CameornContext : DbContext
    {
        public Lab18CameornContext (DbContextOptions<Lab18CameornContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(150000);
        }

        public DbSet<Lab18Cameorn.Models.Destinations> Destinations { get; set; }

        public DbSet<Lab18Cameorn.Models.Supplies> Supplies { get; set; }
    }
}
