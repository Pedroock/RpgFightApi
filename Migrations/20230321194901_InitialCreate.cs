﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    BattleCharacterId = table.Column<int>(type: "int", nullable: true),
                    BattleEnemyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effects_BattleCharacter_BattleCharacterId",
                        column: x => x.BattleCharacterId,
                        principalTable: "BattleCharacter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Effects_BattleEnemy_BattleEnemyId",
                        column: x => x.BattleEnemyId,
                        principalTable: "BattleEnemy",
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
                name: "IX_Effects_BattleCharacterId",
                table: "Effects",
                column: "BattleCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Effects_BattleEnemyId",
                table: "Effects",
                column: "BattleEnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EffectId",
                table: "Skills",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_EffectId",
                table: "Weapons",
                column: "EffectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armors_Effects_EffectId",
                table: "Armors",
                column: "EffectId",
                principalTable: "Effects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleCharacter_Characters_CharacterId",
                table: "BattleCharacter",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleCharacter_Classs_ClassId",
                table: "BattleCharacter",
                column: "ClassId",
                principalTable: "Classs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleCharacter_Skills_SkillId",
                table: "BattleCharacter",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleCharacter_Weapons_WeaponId",
                table: "BattleCharacter",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemy_Classs_ClassId",
                table: "BattleEnemy",
                column: "ClassId",
                principalTable: "Classs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemy_Skills_SkillId",
                table: "BattleEnemy",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleEnemy_Weapons_WeaponId",
                table: "BattleEnemy",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armors_Effects_EffectId",
                table: "Armors");

            migrationBuilder.DropForeignKey(
                name: "FK_Classs_Effects_EffectsId",
                table: "Classs");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Effects_EffectId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Effects_EffectId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "Effects");

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
        }
    }
}
