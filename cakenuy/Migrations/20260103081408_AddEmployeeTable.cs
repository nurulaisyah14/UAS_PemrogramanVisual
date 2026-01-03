using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cakenuy.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    WorkShift = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9238), new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9245), new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9246) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9251), new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9252) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9257), new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9263), new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9268), new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9269) });
        }
    }
}
