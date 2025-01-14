using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiCompany.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class agains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 46, 13, 718, DateTimeKind.Utc).AddTicks(6673), "9b5b317d-f96e-4748-84f0-5936ebf1f35b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 43, 19, 227, DateTimeKind.Utc).AddTicks(2077), "d39a26fb-2f24-4fa5-a04d-ee88a506cd2f" });
        }
    }
}
