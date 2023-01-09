using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class UpdateTitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Users",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "RoomName");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Rooms",
                newName: "RoomIcon");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Missions",
                newName: "MissionStatus");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Missions",
                newName: "MissionPoints");

            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "Missions",
                newName: "MissionInstructions");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Missions",
                newName: "MissionDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "Users",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "RoomName",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RoomIcon",
                table: "Rooms",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "MissionStatus",
                table: "Missions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "MissionPoints",
                table: "Missions",
                newName: "Points");

            migrationBuilder.RenameColumn(
                name: "MissionInstructions",
                table: "Missions",
                newName: "Instructions");

            migrationBuilder.RenameColumn(
                name: "MissionDate",
                table: "Missions",
                newName: "Date");
        }
    }
}
