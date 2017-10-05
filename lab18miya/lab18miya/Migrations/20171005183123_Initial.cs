using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace lab18miya.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    WeatherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeatherType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.WeatherID);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationID);
                    table.ForeignKey(
                        name: "FK_Destination_Weather_WeatherID",
                        column: x => x.WeatherID,
                        principalTable: "Weather",
                        principalColumn: "WeatherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    SupplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    WeatherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.SupplyID);
                    table.ForeignKey(
                        name: "FK_Supplies_Weather_WeatherID",
                        column: x => x.WeatherID,
                        principalTable: "Weather",
                        principalColumn: "WeatherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destination_WeatherID",
                table: "Destination",
                column: "WeatherID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_WeatherID",
                table: "Supplies",
                column: "WeatherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
