using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentApp.Domain.EFMapping.Migrations
{
    public partial class AddUserFirstandLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Auth",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Auth",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Auth",
                table: "Users");
        }
    }
}
