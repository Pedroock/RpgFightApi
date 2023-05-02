using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class EffectsDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Effects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RebootEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleModelId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebootEffects", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Removes hitpoints by burning your enemy");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Removes hitpoints by freezing your enemy");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Removes hitpoints by shocking your enemy");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Restores hitpoints");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Restores hitpoints");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Restores hitpoints");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Gives a strength buff");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Gives a strength debuff");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Gives a intelligence buff");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Gives a deintelligence buff");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Gives a defense buff");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Gives a defense debuff");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Mirrors some of the damage recieved");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "Eats away some damage");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "Eats away some damage");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: "Eats away some damage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RebootEffects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Effects");
        }
    }
}
