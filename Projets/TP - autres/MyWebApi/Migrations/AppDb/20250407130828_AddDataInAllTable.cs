using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebApi.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class AddDataInAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Produits électroniques et gadgets", "Électronique" },
                    { 2, "Articles vestimentaires pour hommes et femmes", "Vêtements" },
                    { 3, "Produits alimentaires et boissons", "Alimentation" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adresse", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Rue de Paris, 75001 Paris", "jean.dupont@example.com", "Jean", "Dupont", "0123456789" },
                    { 2, "456 Avenue des Champs-Élysées, 75008 Paris", "marie.martin@example.com", "Marie", "Martin", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveryDate", "Notes", "OrderDate", "Status" },
                values: new object[] { 1, 1, new DateTime(2025, 4, 12, 13, 8, 28, 324, DateTimeKind.Utc).AddTicks(1884), "Livrer entre 14h et 16h", new DateTime(2025, 4, 7, 13, 8, 28, 324, DateTimeKind.Utc).AddTicks(1883), 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Note", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Le dernier smartphone avec caméra haute résolution", "Smartphone XYZ", 4, 699.99m, 50 },
                    { 2, 2, "T-shirt en coton bio de haute qualité", "T-shirt Premium", 5, 29.99m, 100 },
                    { 3, 3, "Café en grains de qualité supérieure", "Café Arabica", 4, 12.99m, 200 }
                });

            migrationBuilder.InsertData(
                table: "PriceHistories",
                columns: new[] { "Id", "EndDate", "Price", "ProductId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 799.99m, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, 699.99m, 1, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.99m, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, 29.99m, 2, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PriceHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PriceHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PriceHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PriceHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
