using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class Reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armors_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Classs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classs_Effects_EffectsId",
                        column: x => x.EffectsId,
                        principalTable: "Effects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id");
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
                name: "BattleCharacter",
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
                    table.PrimaryKey("PK_BattleCharacter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCharacter_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleCharacterEffect",
                columns: table => new
                {
                    BattleCharactersId = table.Column<int>(type: "int", nullable: false),
                    EffectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleCharacterEffect", x => new { x.BattleCharactersId, x.EffectsId });
                    table.ForeignKey(
                        name: "FK_BattleCharacterEffect_BattleCharacter_BattleCharactersId",
                        column: x => x.BattleCharactersId,
                        principalTable: "BattleCharacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleCharacterEffect_Effects_EffectsId",
                        column: x => x.EffectsId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleEnemy",
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
                    table.PrimaryKey("PK_BattleEnemy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleEnemy_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleEnemy_BattleCharacter_CharacterEnemyId",
                        column: x => x.CharacterEnemyId,
                        principalTable: "BattleCharacter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleEnemy_Classs_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleEnemy_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleEnemy_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleEnemyEffect",
                columns: table => new
                {
                    BattleEnemiesId = table.Column<int>(type: "int", nullable: false),
                    EffectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleEnemyEffect", x => new { x.BattleEnemiesId, x.EffectsId });
                    table.ForeignKey(
                        name: "FK_BattleEnemyEffect_BattleEnemy_BattleEnemiesId",
                        column: x => x.BattleEnemiesId,
                        principalTable: "BattleEnemy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleEnemyEffect_Effects_EffectsId",
                        column: x => x.EffectsId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armors_EffectId",
                table: "Armors",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_ArmorId",
                table: "BattleCharacter",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_CharacterId",
                table: "BattleCharacter",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_ClassId",
                table: "BattleCharacter",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_SkillId",
                table: "BattleCharacter",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacter_WeaponId",
                table: "BattleCharacter",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCharacterEffect_EffectsId",
                table: "BattleCharacterEffect",
                column: "EffectsId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemy_ArmorId",
                table: "BattleEnemy",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemy_CharacterEnemyId",
                table: "BattleEnemy",
                column: "CharacterEnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemy_ClassId",
                table: "BattleEnemy",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemy_SkillId",
                table: "BattleEnemy",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemy_WeaponId",
                table: "BattleEnemy",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleEnemyEffect_EffectsId",
                table: "BattleEnemyEffect",
                column: "EffectsId");

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
                name: "IX_Classs_EffectsId",
                table: "Classs",
                column: "EffectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EffectId",
                table: "Skills",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_EffectId",
                table: "Weapons",
                column: "EffectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleCharacterEffect");

            migrationBuilder.DropTable(
                name: "BattleEnemyEffect");

            migrationBuilder.DropTable(
                name: "BattleEnemy");

            migrationBuilder.DropTable(
                name: "BattleCharacter");

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

            migrationBuilder.DropTable(
                name: "Effects");
        }
    }
}
