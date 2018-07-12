using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class ClasseEnClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classe",
                table: "Personnages");

            migrationBuilder.AddColumn<int>(
                name: "ClasseId",
                table: "Personnages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Personnages_ClasseId",
                table: "Personnages",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_SortClasse_ClasseId",
                table: "SortClasse",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnages_Classes_ClasseId",
                table: "Personnages",
                column: "ClasseId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnages_Classes_ClasseId",
                table: "Personnages");

            migrationBuilder.DropTable(
                name: "SortClasse");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Personnages_ClasseId",
                table: "Personnages");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "Personnages");

            migrationBuilder.AddColumn<int>(
                name: "Classe",
                table: "Personnages",
                nullable: false,
                defaultValue: 0);
        }
    }
}
