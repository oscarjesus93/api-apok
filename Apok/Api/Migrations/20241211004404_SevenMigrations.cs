using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SevenMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandsCars");

            migrationBuilder.CreateTable(
                name: "BrandsCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Date_register = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandsCars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BrandsCars",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Ford" },
                    { 2, "Toyota" },
                    { 3, "Hiunday" },
                    { 4, "Mazda" },
                    { 5, "Kia" },
                    { 6, "Chevrolet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandsCars");

            migrationBuilder.CreateTable(
                name: "BandsCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date_register = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandsCars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BandsCars",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Ford" },
                    { 2, "Toyota" },
                    { 3, "Hiunday" },
                    { 4, "Mazda" },
                    { 5, "Kia" },
                    { 6, "Chevrolet" }
                });
        }
    }
}
