using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsPicksApi.Migrations
{
    public partial class ChangedUserPOCO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MembershipLength",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "MembershipExpiration",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipExpiration",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "MembershipCreated",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MembershipLength",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
