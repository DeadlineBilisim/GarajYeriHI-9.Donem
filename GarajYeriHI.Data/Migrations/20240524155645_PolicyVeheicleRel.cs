using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarajYeriHI.Data.Migrations
{
    /// <inheritdoc />
    public partial class PolicyVeheicleRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Policies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Policies_VehicleId",
                table: "Policies",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Vehicles_VehicleId",
                table: "Policies",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Vehicles_VehicleId",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Policies_VehicleId",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Policies");
        }
    }
}
