using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cakenuy.Migrations
{
    /// <inheritdoc />
    public partial class AddServicesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1574), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1576) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1583), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1590), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1597), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1598) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1604), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1610), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1612) });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Color", "CreatedAt", "Description", "Icon", "IsActive", "Name", "SortOrder", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "bg-success", new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1946), "Makan di tempat dengan suasana nyaman dan pelayanan langsung dari staff kami", "🍽️", true, "Dine In", 1, new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1948) },
                    { 2, "bg-warning", new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1955), "Pesan dan ambil langsung di toko, praktis untuk dibawa pulang", "🥡", true, "Take Away", 2, new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1956) },
                    { 3, "bg-info", new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1963), "Pesan online dan kami antar langsung ke alamat Anda", "🚚", true, "Delivery Order", 3, new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1964) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8839), new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8841) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8846), new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8852), new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8853) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8858), new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8859) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8863), new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8869), new DateTime(2026, 1, 3, 15, 14, 7, 748, DateTimeKind.Local).AddTicks(8870) });
        }
    }
}
