using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class HouseholdContributors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContributorId",
                table: "Household",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContributorIds",
                table: "Household",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Household",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomIds",
                table: "Household",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Household_ContributorId",
                table: "Household",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Household_RoomId",
                table: "Household",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Household_Contributors_ContributorId",
                table: "Household",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "ContributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Household_Rooms_RoomId",
                table: "Household",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Household_Contributors_ContributorId",
                table: "Household");

            migrationBuilder.DropForeignKey(
                name: "FK_Household_Rooms_RoomId",
                table: "Household");

            migrationBuilder.DropIndex(
                name: "IX_Household_ContributorId",
                table: "Household");

            migrationBuilder.DropIndex(
                name: "IX_Household_RoomId",
                table: "Household");

            migrationBuilder.DropColumn(
                name: "ContributorId",
                table: "Household");

            migrationBuilder.DropColumn(
                name: "ContributorIds",
                table: "Household");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Household");

            migrationBuilder.DropColumn(
                name: "RoomIds",
                table: "Household");
        }
    }
}
