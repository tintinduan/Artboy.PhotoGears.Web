using Microsoft.EntityFrameworkCore.Migrations;

namespace Artboy.PhotoGears.Models.Migrations
{
    public partial class ChangedSet_Dec_06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Shutter",
                table: "Cameras",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shutter",
                table: "Cameras");
        }
    }
}
