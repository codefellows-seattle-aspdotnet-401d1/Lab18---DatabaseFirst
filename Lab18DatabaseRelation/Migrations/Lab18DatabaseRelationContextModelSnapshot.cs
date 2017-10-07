﻿// <auto-generated />
using Lab18DatabaseRelation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Lab18DatabaseRelation.Migrations
{
    [DbContext(typeof(Lab18DatabaseRelationContext))]
    partial class Lab18DatabaseRelationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab18DatabaseRelation.Models.Destination", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Distance");

                    b.Property<string>("LocationName");

                    b.Property<string>("PosterPath");

                    b.HasKey("ID");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Lab18DatabaseRelation.Models.DestinationTravelItem", b =>
                {
                    b.Property<int>("DestinationID");

                    b.Property<int>("TravelItemID");

                    b.HasKey("DestinationID", "TravelItemID");

                    b.HasIndex("TravelItemID");

                    b.ToTable("DestinationTravelItem");
                });

            modelBuilder.Entity("Lab18DatabaseRelation.Models.TravelItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("TravelItems");
                });

            modelBuilder.Entity("Lab18DatabaseRelation.Models.DestinationTravelItem", b =>
                {
                    b.HasOne("Lab18DatabaseRelation.Models.Destination", "Destination")
                        .WithMany("DestinationTravelItems")
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab18DatabaseRelation.Models.TravelItem", "TravelItem")
                        .WithMany("DestinationTravelItems")
                        .HasForeignKey("TravelItemID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
