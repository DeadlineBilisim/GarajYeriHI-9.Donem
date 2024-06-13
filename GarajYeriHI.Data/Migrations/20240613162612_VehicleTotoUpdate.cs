using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarajYeriHI.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleTotoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleTotos_Vehicles_VehicleId",
                table: "VehicleTotos");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "VehicleTotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleTotos_Vehicles_VehicleId",
                table: "VehicleTotos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleTotos_Vehicles_VehicleId",
                table: "VehicleTotos");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "VehicleTotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleTotos_Vehicles_VehicleId",
                table: "VehicleTotos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
