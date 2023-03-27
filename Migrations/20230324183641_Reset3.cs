using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class Reset3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intensity = table.Column<int>(type: "int", nullable: false),
                    Self = table.Column<bool>(type: "bit", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmorEffects",
                columns: table => new
                {
                    ArmorId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorEffects", x => new { x.ArmorId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_ArmorEffects_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorEffects_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SkillEffects",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillEffects", x => new { x.SkillId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_SkillEffects_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillEffects_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPoint = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
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
                    SkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enemies_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enemies_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enemies_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeaponEffects",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponEffects", x => new { x.WeaponId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_WeaponEffects_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponEffects_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleCharacters",
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
                    CharacterId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_BattleCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_BattleCharacters_Weapons_WeaponId",
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
                name: "BattleEnemies",
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
                    CharacterEnemyId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_BattleEnemies_BattleCharacters_CharacterEnemyId",
                        column: x => x.CharacterEnemyId,
                        principalTable: "BattleCharacters",
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
                        name: "FK_BattleEnemies_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
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
                name: "IX_ArmorEffects_EffectId",
                table: "ArmorEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacterEffects_EffectId",
                table: "BattleCharacterEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_ArmorId",
                table: "BattleCharacters",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_CharacterId",
                table: "BattleCharacters",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_ClassId",
                table: "BattleCharacters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_SkillId",
                table: "BattleCharacters",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacters_WeaponId",
                table: "BattleCharacters",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_ArmorId",
                table: "BattleEnemies",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_CharacterEnemyId",
                table: "BattleEnemies",
                column: "CharacterEnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_ClassId",
                table: "BattleEnemies",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_SkillId",
                table: "BattleEnemies",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemies_WeaponId",
                table: "BattleEnemies",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemyEffects_EffectId",
                table: "BattleEnemyEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArmorId",
                table: "Characters",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SkillId",
                table: "Characters",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaponId",
                table: "Characters",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassEffects_EffectId",
                table: "ClassEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_ArmorId",
                table: "Enemies",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_ClassId",
                table: "Enemies",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_SkillId",
                table: "Enemies",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_WeaponId",
                table: "Enemies",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillEffects_EffectId",
                table: "SkillEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponEffects_EffectId",
                table: "WeaponEffects",
                column: "EffectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorEffects");

            migrationBuilder.DropTable(
                name: "BattleCharacterEffects");

            migrationBuilder.DropTable(
                name: "BattleEnemyEffects");

            migrationBuilder.DropTable(
                name: "ClassEffects");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "SkillEffects");

            migrationBuilder.DropTable(
                name: "WeaponEffects");

            migrationBuilder.DropTable(
                name: "BattleEnemies");

            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "BattleCharacters");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Classs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
