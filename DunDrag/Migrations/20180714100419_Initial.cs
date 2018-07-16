using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caracteristiques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    CaracteristiqueEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    CaracteristiqueAssociee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: false),
                    Niveau = table.Column<int>(nullable: false),
                    Ecole = table.Column<int>(nullable: false),
                    Incantation = table.Column<string>(nullable: false),
                    Rituel = table.Column<bool>(nullable: false),
                    Portee = table.Column<string>(nullable: true),
                    Composantes = table.Column<string>(nullable: true),
                    Duree = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Resume = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorts", x => x.Id);
                });

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
                    Historique = table.Column<string>(nullable: true),
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
                    BonusAttaqueAvecSort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnages_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SortClasse",
                columns: table => new
                {
                    SortId = table.Column<int>(nullable: false),
                    ClasseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortClasse", x => new { x.SortId, x.ClasseId });
                    table.ForeignKey(
                        name: "FK_SortClasse_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SortClasse_Sorts_SortId",
                        column: x => x.SortId,
                        principalTable: "Sorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "PersonnagesSorts",
                columns: table => new
                {
                    PersonnageId = table.Column<int>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    EstPrepare = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnagesSorts", x => new { x.PersonnageId, x.SortId });
                    table.ForeignKey(
                        name: "FK_PersonnagesSorts_Personnages_PersonnageId",
                        column: x => x.PersonnageId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnagesSorts_Sorts_SortId",
                        column: x => x.SortId,
                        principalTable: "Sorts",
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

            migrationBuilder.CreateIndex(
                name: "IX_PersonnageLangue_LangueId",
                table: "PersonnageLangue",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnages_ClasseId",
                table: "Personnages",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnagesSorts_SortId",
                table: "PersonnagesSorts",
                column: "SortId");

            migrationBuilder.CreateIndex(
                name: "IX_SortClasse_ClasseId",
                table: "SortClasse",
                column: "ClasseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnageCaracteristique");

            migrationBuilder.DropTable(
                name: "PersonnageCompetence");

            migrationBuilder.DropTable(
                name: "PersonnageLangue");

            migrationBuilder.DropTable(
                name: "PersonnagesSorts");

            migrationBuilder.DropTable(
                name: "SortClasse");

            migrationBuilder.DropTable(
                name: "Caracteristiques");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Langues");

            migrationBuilder.DropTable(
                name: "Personnages");

            migrationBuilder.DropTable(
                name: "Sorts");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
