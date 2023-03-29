using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class RemovePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Armors");

            migrationBuilder.AddColumn<int>(
                name: "BattleCharacterId",
                table: "BattleEnemies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 1,
                column: "HitPoint",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 2,
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

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_BattleCharacterId",
                table: "BattleEnemies",
                column: "BattleCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_BattleCharacterId",
                table: "BattleEnemies",
                column: "BattleCharacterId",
                principalTable: "BattleCharacters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_BattleCharacterId",
                table: "BattleEnemies");

            migrationBuilder.DropIndex(
                name: "IX_BattleEnemies_BattleCharacterId",
                table: "BattleEnemies");

            migrationBuilder.DropColumn(
                name: "BattleCharacterId",
                table: "BattleEnemies");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Armors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 1,
                column: "HitPoint",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 2,
                column: "HitPoint",
                value: 150);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 4,
                column: "HitPoint",
                value: 250);

            migrationBuilder.UpdateData(
                table: "Enemies",
                keyColumn: "Id",
                keyValue: 5,
                column: "HitPoint",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 300);
        }
    }
}
