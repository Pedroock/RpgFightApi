using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class seedEquipmentFx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArmorEffects",
                columns: new[] { "ArmorId", "EffectId" },
                values: new object[,]
                {
                    { 1, 11 },
                    { 1, 14 },
                    { 2, 1 },
                    { 2, 14 },
                    { 3, 7 },
                    { 3, 10 },
                    { 4, 11 },
                    { 4, 15 },
                    { 5, 10 },
                    { 5, 16 },
                    { 6, 9 },
                    { 6, 14 },
                    { 7, 9 },
                    { 7, 11 },
                    { 7, 16 },
                    { 8, 12 },
                    { 8, 13 },
                    { 8, 14 },
                    { 9, 9 },
                    { 9, 13 },
                    { 9, 15 }
                });

            migrationBuilder.InsertData(
                table: "SkillEffects",
                columns: new[] { "EffectId", "SkillId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 5, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 2, 7 },
                    { 3, 7 },
                    { 1, 8 },
                    { 3, 8 },
                    { 6, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "WeaponEffects",
                columns: new[] { "EffectId", "WeaponId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 10, 2 },
                    { 9, 4 },
                    { 11, 5 },
                    { 7, 6 },
                    { 8, 7 },
                    { 11, 7 },
                    { 7, 8 },
                    { 10, 8 },
                    { 8, 9 },
                    { 13, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "ArmorEffects",
                keyColumns: new[] { "ArmorId", "EffectId" },
                keyValues: new object[] { 9, 15 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "SkillEffects",
                keyColumns: new[] { "EffectId", "SkillId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "WeaponEffects",
                keyColumns: new[] { "EffectId", "WeaponId" },
                keyValues: new object[] { 13, 9 });
        }
    }
}
