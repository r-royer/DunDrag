using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class Caracteristique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstPrepare",
                table: "PersonnagesSorts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BonusAttaqueAvecSort",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cheveux",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClasseArmure",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Defauts",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DesDeSauvegardeContreSorts",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesDeVie",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ideaux",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Initiative",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Liens",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Peau",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PiecesArgent",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PiecesCuivre",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PiecesEthereum",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PiecesOr",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PiecesPlatine",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PvActuels",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PvMaximum",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PvTemporaires",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TraitsDePersonnalite",
                table: "Personnages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vitesse",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Yeux",
                table: "Personnages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Caracteristiques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true),
                    CaracteristiqueEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true),
                    CaracteristiqueAssociee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonnageCaracteristique",
                columns: table => new
                {
                    CaracteristiqueId = table.Column<int>(nullable: false),
                    PersonnageId = table.Column<int>(nullable: false),
                    Valeur = table.Column<int>(nullable: false),
                    ValeurTemporaire = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnageCaracteristique", x => new { x.PersonnageId, x.CaracteristiqueId });
                    table.ForeignKey(
                        name: "FK_PersonnageCaracteristique_Caracteristiques_CaracteristiqueId",
                        column: x => x.CaracteristiqueId,
                        principalTable: "Caracteristiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnageCaracteristique_Personnages_PersonnageId",
                        column: x => x.PersonnageId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnageCompetence",
                columns: table => new
                {
                    CompetenceId = table.Column<int>(nullable: false),
                    PersonnageId = table.Column<int>(nullable: false),
                    Maitrise = table.Column<bool>(nullable: false),
                    Expertise = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnageCompetence", x => new { x.PersonnageId, x.CompetenceId });
                    table.ForeignKey(
                        name: "FK_PersonnageCompetence_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnageCompetence_Personnages_PersonnageId",
                        column: x => x.PersonnageId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnageCaracteristique_CaracteristiqueId",
                table: "PersonnageCaracteristique",
                column: "CaracteristiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnageCompetence_CompetenceId",
                table: "PersonnageCompetence",
                column: "CompetenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnageCaracteristique");

            migrationBuilder.DropTable(
                name: "PersonnageCompetence");

            migrationBuilder.DropTable(
                name: "Caracteristiques");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropColumn(
                name: "EstPrepare",
                table: "PersonnagesSorts");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "BonusAttaqueAvecSort",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Cheveux",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "ClasseArmure",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Defauts",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "DesDeSauvegardeContreSorts",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "DesDeVie",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Ideaux",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Initiative",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Liens",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Peau",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PiecesArgent",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PiecesCuivre",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PiecesEthereum",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PiecesOr",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PiecesPlatine",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PvActuels",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PvMaximum",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "PvTemporaires",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "TraitsDePersonnalite",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Vitesse",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "Yeux",
                table: "Personnages");
        }
    }
}
