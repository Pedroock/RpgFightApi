using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class MinorBalancing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DefenseModifier", "StrengthModifier" },
                values: new object[] { -5, -5 });

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 3,
                column: "HitPoint",
                value: 250);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 4,
                column: "HitPoint",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 5,
                column: "HitPoint",
                value: 350);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DefenseModifier", "StrengthModifier" },
                values: new object[] { 0, -10 });

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 3,
                column: "HitPoint",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 4,
                column: "HitPoint",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 5,
                column: "HitPoint",
                value: 200);
        }
    }
}
