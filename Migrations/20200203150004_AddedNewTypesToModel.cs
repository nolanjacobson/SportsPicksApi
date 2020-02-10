using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPicksApi.Migrations
{
    public partial class AddedNewTypesToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MembershipType",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Users");
        }
    }
}
