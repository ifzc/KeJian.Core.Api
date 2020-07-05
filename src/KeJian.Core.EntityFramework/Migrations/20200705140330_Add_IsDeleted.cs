using Microsoft.EntityFrameworkCore.Migrations;

namespace KeJian.Core.EntityFramework.Migrations
{
    public partial class Add_IsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Team",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Study",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Recruitment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "News",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Message",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Honor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Enterprise",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DataDictionary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Case",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Study");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Recruitment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "News");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Honor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Enterprise");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DataDictionary");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Case");
        }
    }
}
