using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cakenuy.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmojiFromMenuNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Orders",
                type: "TEXT",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1658), "Chocolate Delight", new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1664), "Strawberry Bliss", new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1671), "Vanilla Dream Cupcakes", new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1677), "Red Velvet Romance", new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1678) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1682), "Matcha Heaven", new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1688), "Tiramisu Classic", new DateTime(2026, 1, 3, 17, 18, 34, 517, DateTimeKind.Local).AddTicks(1689) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Orders",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7621), "🍫 Chocolate Delight", new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7628), "🍓 Strawberry Bliss", new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7629) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7634), "🧁 Vanilla Dream Cupcakes", new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7640), "❤️ Red Velvet Romance", new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7646), "🍵 Matcha Heaven", new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7651), "☕ Tiramisu Classic", new DateTime(2026, 1, 3, 15, 47, 15, 984, DateTimeKind.Local).AddTicks(7652) });

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
        }
    }
}
