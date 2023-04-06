using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class BattleEnemyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_CharacterEnemyId",
                table: "BattleEnemies");

            migrationBuilder.DropIndex(
                name: "IX_BattleEnemies_CharacterEnemyId",
                table: "BattleEnemies");

            migrationBuilder.DropColumn(
                name: "CharacterEnemyId",
                table: "BattleEnemies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterEnemyId",
                table: "BattleEnemies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_CharacterEnemyId",
                table: "BattleEnemies",
                column: "CharacterEnemyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_CharacterEnemyId",
                table: "BattleEnemies",
                column: "CharacterEnemyId",
                principalTable: "BattleCharacters",
                principalColumn: "Id");
        }
    }
}
