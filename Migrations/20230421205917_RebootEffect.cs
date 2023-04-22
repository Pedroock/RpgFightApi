using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class RebootEffect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 7,
                column: "Intensity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Intensity",
                value: -5);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 9,
                column: "Intensity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10,
                column: "Intensity",
                value: -5);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 11,
                column: "Intensity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12,
                column: "Intensity",
                value: -5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 7,
                column: "Intensity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Intensity",
                value: -15);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 9,
                column: "Intensity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10,
                column: "Intensity",
                value: -15);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 11,
                column: "Intensity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12,
                column: "Intensity",
                value: -15);
        }
    }
}
