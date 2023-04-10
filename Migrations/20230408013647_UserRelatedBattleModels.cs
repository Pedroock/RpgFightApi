using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class UserRelatedBattleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleCharacters_Characters_CharacterId",
                table: "BattleCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_BattleCharacterId",
                table: "BattleEnemies");

            migrationBuilder.RenameColumn(
                name: "BattleCharacterId",
                table: "BattleEnemies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleEnemies_BattleCharacterId",
                table: "BattleEnemies",
                newName: "IX_BattleEnemies_UserId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "BattleCharacters",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleCharacters_CharacterId",
                table: "BattleCharacters",
                newName: "IX_BattleCharacters_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleCharacters_Users_UserId",
                table: "BattleCharacters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemies_Users_UserId",
                table: "BattleEnemies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleCharacters_Users_UserId",
                table: "BattleCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleEnemies_Users_UserId",
                table: "BattleEnemies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BattleEnemies",
                newName: "BattleCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleEnemies_UserId",
                table: "BattleEnemies",
                newName: "IX_BattleEnemies_BattleCharacterId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BattleCharacters",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleCharacters_UserId",
                table: "BattleCharacters",
                newName: "IX_BattleCharacters_CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleCharacters_Characters_CharacterId",
                table: "BattleCharacters",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemies_BattleCharacters_BattleCharacterId",
                table: "BattleEnemies",
                column: "BattleCharacterId",
                principalTable: "BattleCharacters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
