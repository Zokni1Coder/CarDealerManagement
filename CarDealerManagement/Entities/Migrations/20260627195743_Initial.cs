using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    manufacturingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transmissionType = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    km = table.Column<int>(type: "int", nullable: false),
                    hp = table.Column<int>(type: "int", nullable: false),
                    fuelType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    vehicleType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "id", "fuelType", "hp", "km", "manufacturer", "manufacturingDate", "model", "transmissionType", "vehicleType" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Benzin", 122, 167000, "Audi", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A4", "Automatic", "Limousine" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Benzin", 96, 235000, "Volkswagen", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Golf", "Automatic", "Compact" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Benzin", 150, 35000, "Formentor", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cupra", "Automatic", "SUV" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Benzin", 155, 27000, "Karoq", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skoda", "Automatic", "SUV" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Benzin", 245, 123000, "M4", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BWM", "Automatic", "Coupé" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
