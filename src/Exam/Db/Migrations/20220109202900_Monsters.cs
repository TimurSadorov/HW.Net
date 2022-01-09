using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Migrations
{
    public partial class Monsters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "MonsterId", "ArmorClass", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "HitPoints", "Name", "Weapon" },
                values: new object[,]
                {
                    { 1, 10, 10, 3, 5, 4, 79, "Лось", 10 },
                    { 2, 4, 4, 2, 4, 1, 20, "Кошка", 3 },
                    { 3, 10, 1, 2, 2, 3, 50, "Амерго", 3 },
                    { 4, 2, 4, 2, 1, 3, 69, "Дерро", 1 },
                    { 5, 11, 2, 4, 6, 4, 80, "Савид", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "MonsterId",
                keyValue: 5);
        }
    }
}
