using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab18_brian.Models;

namespace lab18_brian.Models
{
    public class lab18_brianContext : DbContext
    {
        public lab18_brianContext (DbContextOptions<lab18_brianContext> options)
            : base(options)
        {
        }

        public DbSet<lab18_brian.Models.Item> Item { get; set; }

        public DbSet<lab18_brian.Models.PackingList> PackingList { get; set; }

        public DbSet<PackingListItems> PackingListItems { get; set; }

        //OnModelCreating method is called when the model for a derived context has been initialized
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PackingListItems>().HasKey(table => new
            {
                table.packinglistID,
                table.itemID
            });
        }
    }
}
