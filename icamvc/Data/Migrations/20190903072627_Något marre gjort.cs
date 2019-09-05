using Microsoft.EntityFrameworkCore.Migrations;

namespace ICAMVC.Data.Migrations
{
    public partial class Någotmarregjort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Driver",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Driver_RouteId",
                table: "Driver",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Route_RouteId",
                table: "Driver",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Route_RouteId",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Driver_RouteId",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Driver");
        }
    }
}
