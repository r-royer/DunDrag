using Microsoft.EntityFrameworkCore.Migrations;

namespace DunDrag.Migrations
{
    public partial class SortSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Sorts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Sorts");
        }
    }
}
