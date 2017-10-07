using Lab18DatabaseRelation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18DatabaseRelation.Data
{
    public class Lab18DatabaseRelationContext: DbContext
    {
        public Lab18DatabaseRelationContext(DbContextOptions<Lab18DatabaseRelationContext> options) : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TravelItem> TravelItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DestinationTravelItem>()
                .HasKey(t => new { t.DestinationID, t.TravelItemID });

            modelBuilder.Entity<DestinationTravelItem>()
                .HasOne(pt => pt.Destination)
                .WithMany(p => p.DestinationTravelItems)
                .HasForeignKey(pt => pt.DestinationID);

            modelBuilder.Entity<DestinationTravelItem>()
                .HasOne(pt => pt.TravelItem)
                .WithMany(t => t.DestinationTravelItems)
                .HasForeignKey(pt => pt.TravelItemID);
        }

        public DbSet<Lab18DatabaseRelation.Models.DestinationTravelItem> DestinationTravelItem { get; set; }
    }
}

