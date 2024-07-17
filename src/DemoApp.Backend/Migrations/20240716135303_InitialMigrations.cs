using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoApp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 7, 16), "Mild", 13 },
                    { 2, new DateOnly(2024, 7, 17), "Hot", 47 },
                    { 3, new DateOnly(2024, 7, 18), "Balmy", 30 },
                    { 4, new DateOnly(2024, 7, 19), "Freezing", -4 },
                    { 5, new DateOnly(2024, 7, 20), "Warm", 4 },
                    { 6, new DateOnly(2024, 7, 21), "Bracing", -8 },
                    { 7, new DateOnly(2024, 7, 22), "Sweltering", 5 },
                    { 8, new DateOnly(2024, 7, 23), "Bracing", -9 },
                    { 9, new DateOnly(2024, 7, 24), "Balmy", 0 },
                    { 10, new DateOnly(2024, 7, 25), "Scorching", 2 },
                    { 11, new DateOnly(2024, 7, 26), "Bracing", 27 },
                    { 12, new DateOnly(2024, 7, 27), "Scorching", 52 },
                    { 13, new DateOnly(2024, 7, 28), "Cool", 25 },
                    { 14, new DateOnly(2024, 7, 29), "Freezing", 19 },
                    { 15, new DateOnly(2024, 7, 30), "Bracing", -12 },
                    { 16, new DateOnly(2024, 7, 31), "Scorching", 11 },
                    { 17, new DateOnly(2024, 8, 1), "Hot", 0 },
                    { 18, new DateOnly(2024, 8, 2), "Freezing", 42 },
                    { 19, new DateOnly(2024, 8, 3), "Hot", 53 },
                    { 20, new DateOnly(2024, 8, 4), "Hot", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
