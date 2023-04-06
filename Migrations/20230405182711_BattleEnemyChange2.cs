using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class BattleEnemyChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_BattleCharacterId",
                table: "BattleEnemies");

            migrationBuilder.DropIndex(
                name: "IX_BattleEnemies_BattleCharacterId",
                table: "BattleEnemies");

            migrationBuilder.AlterColumn<int>(
                name: "BattleCharacterId",
                table: "BattleEnemies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_BattleCharacterId",
                table: "BattleEnemies",
                column: "BattleCharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_BattleCharacterId",
                table: "BattleEnemies",
                column: "BattleCharacterId",
                principalTable: "BattleCharacters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "BattleCharacterId",
                table: "BattleEnemies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
