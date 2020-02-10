using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPicksApi.Migrations
{
    public partial class CorrectedDescriptiontypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripton",
                table: "NewGame");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "NewGame",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "NewGame");

            migrationBuilder.AddColumn<string>(
                name: "Descripton",
                table: "NewGame",
                type: "text",
                nullable: true);
        }
    }
}
