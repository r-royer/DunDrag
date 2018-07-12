using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class AjoutPersonnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: false),
                    Niveau = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: false),
                    Niveau = table.Column<int>(nullable: false),
                    Ecole = table.Column<int>(nullable: false),
                    Incantation = table.Column<string>(nullable: false),
                    Rituel = table.Column<bool>(nullable: false),
                    Portee = table.Column<string>(nullable: true),
                    Composantes = table.Column<string>(nullable: true),
                    Duree = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Resume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonnagesSorts",
                columns: table => new
                {
                    PersonnageId = table.Column<int>(nullable: false),
                    SortId = table.Column<int>(nullable: false)
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
                name: "IX_PersonnagesSorts_SortId",
                table: "PersonnagesSorts",
                column: "SortId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnagesSorts");

            migrationBuilder.DropTable(
                name: "Personnages");

            migrationBuilder.DropTable(
                name: "Sorts");
        }
    }
}
