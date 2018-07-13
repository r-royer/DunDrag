using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class DesDeVie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesDeVie",
                table: "Personnages",
                newName: "DesDeVieTotal");

            migrationBuilder.AddColumn<int>(
                name: "DesDeVieActuels",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeDesDeVie",
                table: "Personnages",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesDeVieActuels",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "TypeDesDeVie",
                table: "Personnages");

            migrationBuilder.RenameColumn(
                name: "DesDeVieTotal",
                table: "Personnages",
                newName: "DesDeVie");
        }
    }
}
