using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class UserTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "User",
                newName: "UserIcon");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Tasks",
                newName: "Points");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "User",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserIcon",
                table: "User",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Tasks",
                newName: "Point");
        }
    }
}
