using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiCompany.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 25, 40, 957, DateTimeKind.Utc).AddTicks(3591), "89682781-497a-4300-b308-5f4623591cfc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2025, 1, 9, 13, 24, 30, 534, DateTimeKind.Utc).AddTicks(85), "bea55ef6-e359-4305-b982-0af2e2f69b11" });
        }
    }
}
