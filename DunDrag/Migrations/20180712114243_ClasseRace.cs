using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class ClasseRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Classe",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Race",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classe",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Personnages");
        }
    }
}
