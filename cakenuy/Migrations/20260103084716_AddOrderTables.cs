using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cakenuy.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7621), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7628), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7629) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7634), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7640), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7646), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7651), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7652) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7922), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7923) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7929), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7935), new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7936) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

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

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1946), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1948) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1955), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1956) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1963), new DateTime(2026, 1, 3, 15, 37, 22, 300, DateTimeKind.Local).AddTicks(1964) });
        }
    }
}
