using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class ChargeSort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargeSort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NiveauSort = table.Column<int>(nullable: false),
                    ChargesTotales = table.Column<int>(nullable: false),
                    ChargesRestantes = table.Column<int>(nullable: false),
                    PersonnageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeSort", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargeSort_Personnages_PersonnageId",
                        column: x => x.PersonnageId,
                        principalTable: "Personnages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargeSort_PersonnageId",
                table: "ChargeSort",
                column: "PersonnageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargeSort");
        }
    }
}
