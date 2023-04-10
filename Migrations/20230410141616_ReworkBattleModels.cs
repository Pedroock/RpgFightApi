using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class ReworkBattleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleCharacterEffects");

            migrationBuilder.DropTable(
                name: "BattleEnemyEffects");

            migrationBuilder.DropTable(
                name: "BattleCharacters");

            migrationBuilder.DropTable(
                name: "BattleEnemies");

            migrationBuilder.CreateTable(
                name: "BattleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPoint = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleModels_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleModels_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleModels_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleModels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleModels_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleModelEffects",
                columns: table => new
                {
                    BattleModelId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleModelEffects", x => new { x.BattleModelId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_BattleModelEffects_BattleModels_BattleModelId",
                        column: x => x.BattleModelId,
                        principalTable: "BattleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleModelEffects_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleModelEffects_EffectId",
                table: "BattleModelEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleModels_ArmorId",
                table: "BattleModels",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleModels_ClassId",
                table: "BattleModels",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleModels_SkillId",
                table: "BattleModels",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleModels_UserId",
                table: "BattleModels",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleModels_WeaponId",
                table: "BattleModels",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleModelEffects");

            migrationBuilder.DropTable(
                name: "BattleModels");

            migrationBuilder.CreateTable(
                name: "BattleCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    HitPoint = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleCharacters_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacters_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacters_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleCharacters_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleEnemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    HitPoint = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleEnemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleEnemies_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleEnemies_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleEnemies_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleEnemies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleEnemies_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleCharacterEffects",
                columns: table => new
                {
                    BattleCharacterId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleCharacterEffects", x => new { x.BattleCharacterId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_BattleCharacterEffects_BattleCharacters_BattleCharacterId",
                        column: x => x.BattleCharacterId,
                        principalTable: "BattleCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleCharacterEffects_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleEnemyEffects",
                columns: table => new
                {
                    BattleEnemyId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleEnemyEffects", x => new { x.BattleEnemyId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_BattleEnemyEffects_BattleEnemies_BattleEnemyId",
                        column: x => x.BattleEnemyId,
                        principalTable: "BattleEnemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleEnemyEffects_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacterEffects_EffectId",
                table: "BattleCharacterEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_ArmorId",
                table: "BattleCharacters",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_ClassId",
                table: "BattleCharacters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_SkillId",
                table: "BattleCharacters",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_UserId",
                table: "BattleCharacters",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_WeaponId",
                table: "BattleCharacters",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_ArmorId",
                table: "BattleEnemies",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_ClassId",
                table: "BattleEnemies",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_SkillId",
                table: "BattleEnemies",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_UserId",
                table: "BattleEnemies",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_WeaponId",
                table: "BattleEnemies",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemyEffects_EffectId",
                table: "BattleEnemyEffects",
                column: "EffectId");
        }
    }
}
