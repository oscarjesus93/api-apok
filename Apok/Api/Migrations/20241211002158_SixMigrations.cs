using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SixMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_registerl",
                table: "BandsCars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Date_registerl",
                table: "BandsCars",
                type: "integer",
                nullable: false,
                defaultValueSql: "CAST(TO_CHAR(NOW(), 'YYYYMMDD') AS INTEGER)");

            migrationBuilder.UpdateData(
                table: "BandsCars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "BandsCars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "BandsCars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "BandsCars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "BandsCars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "BandsCars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new string[0],
                values: new object[0]);
        }
    }
}
