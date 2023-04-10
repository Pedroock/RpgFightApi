using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class IsChar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChar",
                table: "BattleModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChar",
                table: "BattleModels");
        }
    }
}
