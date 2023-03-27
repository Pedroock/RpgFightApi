using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class ChangeClass2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassEffects");

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { 5, 15, 5, 5 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DefenseModifier", "HitPointModifier", "StrengthModifier" },
                values: new object[] { 10, 10, 10 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { -5, 10, -5, 30 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { 10, 30, -10 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { 10, 10, 20, -10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassEffects",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassEffects", x => new { x.ClassId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_ClassEffects_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassEffects_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DefenseModifier", "HitPointModifier", "StrengthModifier" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "StrengthModifier" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ClassEffects_EffectId",
                table: "ClassEffects",
                column: "EffectId");
        }
    }
}
