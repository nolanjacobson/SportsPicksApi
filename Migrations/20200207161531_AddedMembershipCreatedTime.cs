using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPicksApi.Migrations
{
    public partial class AddedMembershipCreatedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MembershipCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipCreated",
                table: "Users");
        }
    }
}
