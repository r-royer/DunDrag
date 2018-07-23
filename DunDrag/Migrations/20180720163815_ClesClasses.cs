using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class ClesClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cle",
                table: "Classes",
                nullable: true);

            migrationBuilder.Sql("UPDATE Classes SET Cle = 'BAR' WHERE Nom = 'Barde'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'CLE' WHERE Nom = 'Clerc'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'DRU' WHERE Nom = 'Druide'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'ENS' WHERE Nom = 'Ensorceleur'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'MAG' WHERE Nom = 'Magicien'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'PAL' WHERE Nom = 'Paladin'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'ROD' WHERE Nom = 'Rôdeur'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'SOR' WHERE Nom = 'Sorcier'");
            migrationBuilder.Sql("UPDATE Classes SET Cle = 'ROU' WHERE Nom = 'Roublard'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cle",
                table: "Classes");
        }
    }
}
