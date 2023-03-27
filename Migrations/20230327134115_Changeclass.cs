using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgFight.Migrations
{
    /// <inheritdoc />
    public partial class Changeclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassEffects",
                keyColumns: new[] { "ClassId", "EffectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.AddColumn<int>(
                name: "DefenseModifier",
                table: "Classs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HitPointModifier",
                table: "Classs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IntelligenceModifier",
                table: "Classs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StrengthModifier",
                table: "Classs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Warrior Armor", 100 },
                    { 2, "Mage Robe", 100 },
                    { 3, "Fur Armor", 100 },
                    { 4, "Full Plate Armor", 200 },
                    { 5, "Royal Armor", 200 },
                    { 6, "Necromancer Robe", 200 },
                    { 7, "Heavenly Armor", 300 },
                    { 8, "Cursed Armor", 300 },
                    { 9, "Arch Mage Mask", 300 }
                });

            migrationBuilder.UpdateData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "Name", "StrengthModifier" },
                values: new object[] { 0, 0, 0, "Knight", 0 });

            migrationBuilder.InsertData(
                table: "Classs",
                columns: new[] { "Id", "DefenseModifier", "HitPointModifier", "IntelligenceModifier", "Name", "StrengthModifier" },
                values: new object[,]
                {
                    { 2, 0, 0, 0, "Crusader", 0 },
                    { 3, 0, 0, 0, "Berserker", 0 },
                    { 4, 0, 0, 0, "Mage", 0 },
                    { 5, 0, 0, 0, "Witch", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 10, "Heal I" });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Duration", "Intensity", "Name", "Self" },
                values: new object[] { 1, 20, "Heal II", true });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Duration", "Intensity", "Name", "Self" },
                values: new object[] { 1, 30, "Heal III", true });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Duration", "Name", "Self" },
                values: new object[] { -1, "Frenzy", true });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Lethargy");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Duration", "Name", "Self" },
                values: new object[] { -1, "Wisdom", true });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Folly");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 15, "Endurance" });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Duration", "Intensity", "Name", "Self" },
                values: new object[] { 5, -15, "Weakness", false });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 10, "Riposite" });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 10, "Protection I" });

            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "Id", "Duration", "Intensity", "Name", "Self" },
                values: new object[,]
                {
                    { 15, -1, 20, "Protection II", true },
                    { 16, -1, 30, "Protection III", true }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 0, "Heal I", 100 },
                    { 2, 25, "Flames", 100 },
                    { 3, 25, "Ice Spike", 100 },
                    { 4, 25, "Eletric Shock", 100 },
                    { 5, 0, "Heal II", 200 },
                    { 6, 50, "Thermal Shock", 200 },
                    { 7, 50, "Cold Storm", 200 },
                    { 8, 50, "Eletric Fire", 200 },
                    { 9, 0, "Heal III", 300 },
                    { 10, 75, "Elemental Burst", 300 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "Damage", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 30, "Clunky Longsword", 100 },
                    { 2, 25, "Ugly Knife", 100 },
                    { 3, 25, "Sword", 100 },
                    { 4, 50, "Assassins Blade", 200 },
                    { 5, 50, "Blessed Sword", 200 },
                    { 6, 50, "Scimitar", 200 },
                    { 7, 75, "Heavy Axe", 300 },
                    { 8, 75, "Blessed Sword", 300 },
                    { 9, 75, "Sword and Shield", 300 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "DefenseModifier",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "HitPointModifier",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "IntelligenceModifier",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "StrengthModifier",
                table: "Classs");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Characters");

            migrationBuilder.InsertData(
                table: "ClassEffects",
                columns: new[] { "ClassId", "EffectId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 25, "Heal" });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Duration", "Intensity", "Name", "Self" },
                values: new object[] { 5, 15, "Frenzy", false });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Duration", "Intensity", "Name", "Self" },
                values: new object[] { 5, -15, "Lethargy", false });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Duration", "Name", "Self" },
                values: new object[] { 5, "Wisdom", false });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Folly");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Duration", "Name", "Self" },
                values: new object[] { 5, "Endurance", false });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Weakness");

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 10, "Riposite" });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Duration", "Intensity", "Name", "Self" },
                values: new object[] { -1, 10, "Protection I", true });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 20, "Protection II" });

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Intensity", "Name" },
                values: new object[] { 30, "Protection III" });
        }
    }
}
