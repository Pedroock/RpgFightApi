using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFxDuration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12,
                column: "Duration",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12,
                column: "Duration",
                value: 5);
        }
    }
}
