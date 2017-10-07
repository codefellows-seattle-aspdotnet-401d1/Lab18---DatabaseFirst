using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using lab18_brian.Models;

namespace lab18_brian.Migrations
{
    [DbContext(typeof(lab18_brianContext))]
    [Migration("20171007040205_Made item quantity nullable")]
    partial class Madeitemquantitynullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab18_brian.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("lab18_brian.Models.PackingList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("PackingList");
                });

            modelBuilder.Entity("lab18_brian.Models.PackingListItems", b =>
                {
                    b.Property<int>("packinglistID");

                    b.Property<int>("itemID");

                    b.HasKey("packinglistID", "itemID");

                    b.HasAlternateKey("itemID", "packinglistID");

                    b.ToTable("PackingListItems");
                });

            modelBuilder.Entity("lab18_brian.Models.PackingListItems", b =>
                {
                    b.HasOne("lab18_brian.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("itemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("lab18_brian.Models.PackingList", "PackingList")
                        .WithMany()
                        .HasForeignKey("packinglistID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
