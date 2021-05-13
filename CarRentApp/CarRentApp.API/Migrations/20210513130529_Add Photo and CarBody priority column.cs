using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentApp.API.Migrations
{
    public partial class AddPhotoandCarBodyprioritycolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "CarBody",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "CarBody");
        }
    }
}
