using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductValidationMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedDate", "Description", "Email", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Үй бұйымдары", new DateTime(2026, 1, 10, 9, 0, 0, 0, DateTimeKind.Utc), "Керамикадан жасалған, күнделікті қолдануға ыңғайлы.", "seller@example.kz", "Қолдан жасалған кесе", 4500m, 24 },
                    { 2, "Кеңсе тауарлары", new DateTime(2026, 2, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Қатты мұқабалы, 160 бет.", "shop@example.kz", "Көк былғары дәптер", 3200m, 40 },
                    { 3, "Киім", new DateTime(2026, 3, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Жұмсақ табиғи жүннен тоқылған.", "hello@example.kz", "Жүн шарф", 8900m, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
