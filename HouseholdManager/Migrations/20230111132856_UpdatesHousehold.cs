using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdManager.Migrations
{
    public partial class UpdatesHousehold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Household_Contributors_ContributorId",
                table: "Household");

            migrationBuilder.DropForeignKey(
                name: "FK_Household_Rooms_RoomId",
                table: "Household");

            migrationBuilder.DropColumn(
                name: "ContributorIds",
                table: "Household");

            migrationBuilder.DropColumn(
                name: "RoomIds",
                table: "Household");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Household",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContributorId",
                table: "Household",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Household_Contributors_ContributorId",
                table: "Household",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "ContributorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Household_Rooms_RoomId",
                table: "Household",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Household_Contributors_ContributorId",
                table: "Household");

            migrationBuilder.DropForeignKey(
                name: "FK_Household_Rooms_RoomId",
                table: "Household");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Household",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContributorId",
                table: "Household",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContributorIds",
                table: "Household",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomIds",
                table: "Household",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
