using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class CorrectUserBattleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BattleModels_UserId",
                table: "BattleModels");

            migrationBuilder.CreateIndex(
                name: "IX_BattleModels_UserId",
                table: "BattleModels",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BattleModels_UserId",
                table: "BattleModels");

            migrationBuilder.CreateIndex(
                name: "IX_BattleModels_UserId",
                table: "BattleModels",
                column: "UserId",
                unique: true);
        }
    }
}
