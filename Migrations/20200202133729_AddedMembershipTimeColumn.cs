using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPicksApi.Migrations
{
    public partial class AddedMembershipTimeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipTime",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipTime",
                table: "Users");
        }
    }
}
