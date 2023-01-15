using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Examen2022.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "C1" },
                    { 2, "C2" },
                    { 3, "C3" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "Date", "Title" },
                values: new object[,]
                {
                    { 1, 1, "CO1", new DateTime(2023, 1, 15, 17, 59, 10, 732, DateTimeKind.Local).AddTicks(615), "T1" },
                    { 2, 2, "CO2", new DateTime(2023, 1, 15, 17, 59, 10, 732, DateTimeKind.Local).AddTicks(644), "T2" },
                    { 3, 2, "CO3", new DateTime(2023, 1, 15, 17, 59, 10, 732, DateTimeKind.Local).AddTicks(646), "T3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
