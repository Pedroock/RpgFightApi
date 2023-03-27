using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class CreateEnemies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "Id", "ArmorId", "ClassId", "Defense", "HitPoint", "Intelligence", "Name", "SkillId", "Strength", "WeaponId" },
                values: new object[,]
                {
                    { 1, null, null, 5, 100, 10, "Tippy-toe Jack", null, 15, null },
                    { 2, null, null, 10, 150, 15, "Blair Witch", null, 5, null },
                    { 3, null, null, 15, 200, 5, "Holy Warrior", null, 10, null },
                    { 4, null, null, 10, 250, 20, "Shadow Wizzard", null, 0, null },
                    { 5, null, null, 0, 300, 0, "Ragnar", null, 30, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
