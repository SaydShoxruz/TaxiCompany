using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiCompany.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsOwners_People_PersonId",
                table: "CarsOwners");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "CarsOwners",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarsOwners_PersonId",
                table: "CarsOwners",
                newName: "IX_CarsOwners_UserId");

            migrationBuilder.AddColumn<int>(
                name: "TarifType",
                table: "CarsOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2025, 1, 14, 13, 13, 2, 391, DateTimeKind.Utc).AddTicks(4942), "b2925647-0392-42a8-afc2-7d222814f96a" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarsOwners_Users_UserId",
                table: "CarsOwners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsOwners_Users_UserId",
                table: "CarsOwners");

            migrationBuilder.DropColumn(
                name: "TarifType",
                table: "CarsOwners");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CarsOwners",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CarsOwners_UserId",
                table: "CarsOwners",
                newName: "IX_CarsOwners_PersonId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2025, 1, 14, 11, 53, 47, 259, DateTimeKind.Utc).AddTicks(7217), "19a145d2-371e-402b-a718-7eaa317a94b4" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarsOwners_People_PersonId",
                table: "CarsOwners",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
