using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class Langue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alignement",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Historique",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomJoueur",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Poids",
                table: "Personnages",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Taille",
                table: "Personnages",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonnageLangue",
                columns: table => new
                {
                    LangueId = table.Column<int>(nullable: false),
                    PersonnageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnageLangue", x => new { x.PersonnageId, x.LangueId });
                    table.ForeignKey(
                        name: "FK_PersonnageLangue_Langues_LangueId",
                        column: x => x.LangueId,
                        principalTable: "Langues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnageLangue_Personnages_PersonnageId",
                        column: x => x.PersonnageId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnageLangue_LangueId",
                table: "PersonnageLangue",
                column: "LangueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnageLangue");

            migrationBuilder.DropTable(
                name: "Langues");

            migrationBuilder.DropColumn(
                name: "Alignement",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Historique",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "NomJoueur",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Poids",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Taille",
                table: "Personnages");
        }
    }
}
