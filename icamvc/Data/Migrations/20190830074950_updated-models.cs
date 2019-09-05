using Microsoft.EntityFrameworkCore.Migrations;

namespace ICAMVC.Data.Migrations
{
    public partial class updatedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllDone",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "FreezerDone",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "NumberOfFreezeBags",
                table: "Route");

            migrationBuilder.RenameColumn(
                name: "PickingDone",
                table: "Route",
                newName: "TruckLoaded");

            migrationBuilder.RenameColumn(
                name: "NumberOfPickingBoxes",
                table: "Route",
                newName: "NumberOfParcels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TruckLoaded",
                table: "Route",
                newName: "PickingDone");

            migrationBuilder.RenameColumn(
                name: "NumberOfParcels",
                table: "Route",
                newName: "NumberOfPickingBoxes");

            migrationBuilder.AddColumn<bool>(
                name: "AllDone",
                table: "Route",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FreezerDone",
                table: "Route",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFreezeBags",
                table: "Route",
                nullable: false,
                defaultValue: 0);
        }
    }
}
