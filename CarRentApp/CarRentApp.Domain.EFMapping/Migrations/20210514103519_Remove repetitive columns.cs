using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentApp.Domain.EFMapping.Migrations
{
    public partial class Removerepetitivecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarBody_CarBodyId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Fuel_FuelId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarBodyId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FuelId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TransmissionId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarBodyId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FuelId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TransmissionId1",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBodyId",
                table: "Cars",
                column: "CarBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelId",
                table: "Cars",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars",
                column: "TransmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarBody_CarBodyId",
                table: "Cars",
                column: "CarBodyId",
                principalTable: "CarBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Fuel_FuelId",
                table: "Cars",
                column: "FuelId",
                principalTable: "Fuel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarBody_CarBodyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Fuel_FuelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarBodyId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FuelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarBodyId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuelId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBodyId1",
                table: "Cars",
                column: "CarBodyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelId1",
                table: "Cars",
                column: "FuelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId1",
                table: "Cars",
                column: "TransmissionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarBody_CarBodyId1",
                table: "Cars",
                column: "CarBodyId1",
                principalTable: "CarBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Fuel_FuelId1",
                table: "Cars",
                column: "FuelId1",
                principalTable: "Fuel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId1",
                table: "Cars",
                column: "TransmissionId1",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
