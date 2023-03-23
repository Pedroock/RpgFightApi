using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class EffectSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "Id", "Duration", "Intensity", "Name", "Self" },
                values: new object[,]
                {
                    { 1, 3, 10, "Flames", false },
                    { 2, 3, 10, "Ice", false },
                    { 3, 3, 10, "Sparks", false },
                    { 4, 1, 25, "Heal", true },
                    { 5, 5, 15, "Frenzy", false },
                    { 6, 5, -15, "Lethargy", false },
                    { 7, 5, 15, "Wisdom", false },
                    { 8, 5, -15, "Folly", false },
                    { 9, 5, 15, "Endurance", false },
                    { 10, 5, -15, "Weakness", false },
                    { 11, -1, 10, "Riposite", true },
                    { 12, -1, 15, "Protection", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
