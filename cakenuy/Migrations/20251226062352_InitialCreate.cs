using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cakenuy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Cake", new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9238), "Kue coklat berlapis dengan frosting coklat krim yang lembut, dihiasi chocolate shavings dan buah berry segar.", "/images/chocolate_cake.png", true, "🍫 Chocolate Delight", 180000m, new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9240) },
                    { 2, "Cake", new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9245), "Kue strawberry segar dengan krim lembut dan strawberry premium di setiap lapisan. Sempurna untuk perayaan spesial.", "/images/strawberry_cake.png", true, "🍓 Strawberry Bliss", 200000m, new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9246) },
                    { 3, "Cupcake", new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9251), "Set 6 cupcake vanilla dengan frosting pink yang manis, ditaburi sprinkles warna-warni. Cocok untuk acara kecil.", "/images/vanilla_cupcake.png", true, "🧁 Vanilla Dream Cupcakes", 85000m, new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9252) },
                    { 4, "Cake", new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9257), "Kue red velvet klasik dengan cream cheese frosting yang creamy. Warna merah menawan dengan rasa yang tak terlupakan.", "/images/red_velvet_cake.png", true, "❤️ Red Velvet Romance", 195000m, new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9258) },
                    { 5, "Cake", new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9263), "Kue matcha premium dengan krim putih lembut, ditaburi bubuk matcha pilihan. Perpaduan rasa manis dan pahit yang sempurna.", "/images/matcha_cake.png", true, "🍵 Matcha Heaven", 175000m, new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9264) },
                    { 6, "Cake", new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9268), "Tiramisu Italia autentik dengan ladyfinger yang direndam kopi espresso dan mascarpone cream. Ditaburi cocoa powder premium.", "/images/tiramisu_cake.png", true, "☕ Tiramisu Classic", 185000m, new DateTime(2025, 12, 26, 13, 23, 51, 784, DateTimeKind.Local).AddTicks(9269) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
