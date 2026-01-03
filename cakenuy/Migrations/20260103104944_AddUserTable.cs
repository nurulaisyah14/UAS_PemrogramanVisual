using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cakenuy.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9144), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9145) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9151), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9152) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9157), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9163), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9164) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9169), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9169) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9174), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9546), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9547) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9553), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9559), new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "Password", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9613), "admin@cakenuy.com", "Administrator", true, "admin123", "Admin", new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9614), "admin" },
                    { 2, new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9619), "user@cakenuy.com", "User Demo", true, "user123", "User", new DateTime(2026, 1, 3, 17, 49, 43, 994, DateTimeKind.Local).AddTicks(9620), "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1658), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1664), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1671), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1677), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1678) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1682), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1688), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1937), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1939) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1944), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1950), new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1951) });
        }
    }
}
