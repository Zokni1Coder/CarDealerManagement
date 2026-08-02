using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddingTestCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "address", "birthDate", "email", "firstName", "lastName", "phoneNumber" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "asd str. 8A", new DateTime(2000, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@gmail.com", "Ella", "Nut", "064581306841" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "asd str. 10A", new DateTime(2013, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@gmail.at", "Elek", "Mek", "064581306976" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "asd str. 26A", new DateTime(1986, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@gmail.eu", "Edda", "Kor", "064581300123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
