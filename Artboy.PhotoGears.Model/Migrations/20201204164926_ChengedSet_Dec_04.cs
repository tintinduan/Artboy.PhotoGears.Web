using Microsoft.EntityFrameworkCore.Migrations;

namespace Artboy.PhotoGears.Models.Migrations
{
    public partial class ChengedSet_Dec_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "Lenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "Cameras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsForSale",
                table: "Accessories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "Lenses");

            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "Cameras");

            migrationBuilder.DropColumn(
                name: "IsForSale",
                table: "Accessories");
        }
    }
}
