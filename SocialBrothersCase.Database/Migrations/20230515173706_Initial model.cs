using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialBrothersCase.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    HouseNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Addition = table.Column<string>(type: "TEXT", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Addition", "City", "Country", "HouseNumber", "Postcode", "Street" },
                values: new object[,]
                {
                    { new Guid("63b19780-dd72-4dfb-9cc4-558c63a4410d"), null, "Utrecht", "Nederland", 1000, "3528 BD", "Orteliuslaan" },
                    { new Guid("bf8a4d8b-d5fc-4259-b47e-d26ed02dc7a6"), "A", "Vianen", "Nederland", 43, "4132 XX", "Sparrendreef" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
