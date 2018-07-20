using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class Historique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Historiques", x => x.Id); });

            migrationBuilder.RenameTable("Personnages", null, "Personnages_Old");
            migrationBuilder.CreateTable(
                name: "Personnages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClasseId = table.Column<int>(nullable: true),
                    Race = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    ClasseArmure = table.Column<int>(nullable: false),
                    Initiative = table.Column<int>(nullable: false),
                    Vitesse = table.Column<int>(nullable: false),
                    PvMaximum = table.Column<int>(nullable: false),
                    PvTemporaires = table.Column<int>(nullable: true),
                    PvActuels = table.Column<int>(nullable: false),
                    DesDeVieActuels = table.Column<int>(nullable: false),
                    DesDeVieTotal = table.Column<int>(nullable: false),
                    TypeDesDeVie = table.Column<string>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Niveau = table.Column<int>(nullable: false),
                    Taille = table.Column<decimal>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Yeux = table.Column<string>(nullable: true),
                    Peau = table.Column<string>(nullable: true),
                    Cheveux = table.Column<string>(nullable: true),
                    Poids = table.Column<decimal>(nullable: false),
                    HistoriqueId = table.Column<int>(nullable: true),
                    NomJoueur = table.Column<string>(nullable: true),
                    Alignement = table.Column<int>(nullable: false),
                    TraitsDePersonnalite = table.Column<string>(nullable: true),
                    Ideaux = table.Column<string>(nullable: true),
                    Liens = table.Column<string>(nullable: true),
                    Defauts = table.Column<string>(nullable: true),
                    AutresCompetences = table.Column<string>(nullable: true),
                    PiecesCuivre = table.Column<int>(nullable: false),
                    PiecesArgent = table.Column<int>(nullable: false),
                    PiecesEthereum = table.Column<int>(nullable: false),
                    PiecesOr = table.Column<int>(nullable: false),
                    PiecesPlatine = table.Column<int>(nullable: false),
                    DesDeSauvegardeContreSorts = table.Column<int>(nullable: false),
                    BonusAttaqueAvecSort = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnages_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnages_Historiques_HistoriqueId",
                        column: x => x.HistoriqueId,
                        principalTable: "Historiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnages_HistoriqueId",
                table: "Personnages",
                column: "HistoriqueId");

            migrationBuilder.Sql("INSERT INTO Personnages SELECT * FROM Personnages_Old");
            migrationBuilder.DropTable("Personnages_Old");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
