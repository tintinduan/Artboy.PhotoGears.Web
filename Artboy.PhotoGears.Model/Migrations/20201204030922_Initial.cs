using Microsoft.EntityFrameworkCore.Migrations;

namespace Artboy.PhotoGears.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessoryDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MadeInCountry = table.Column<int>(type: "int", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mounts",
                columns: table => new
                {
                    MountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlangeFocalDistance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThreadDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MountType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mounts", x => x.MountId);
                });

            migrationBuilder.CreateTable(
                name: "Lenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LensCategory = table.Column<int>(type: "int", nullable: false),
                    LensType = table.Column<int>(type: "int", nullable: false),
                    FocusingType = table.Column<int>(type: "int", nullable: false),
                    MountId = table.Column<int>(type: "int", nullable: false),
                    FocalLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApertureRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseFocusingDistance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FilterSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LensConstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxReproductionRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiaphragmBlades = table.Column<int>(type: "int", nullable: true),
                    IsAttachedToCamera = table.Column<bool>(type: "bit", nullable: false),
                    MadeInCountry = table.Column<int>(type: "int", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lenses_Mounts_MountId",
                        column: x => x.MountId,
                        principalTable: "Mounts",
                        principalColumn: "MountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraType = table.Column<int>(type: "int", nullable: false),
                    FrameSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageType = table.Column<int>(type: "int", nullable: false),
                    IsoRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeedRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MountId = table.Column<int>(type: "int", nullable: false),
                    FocusingType = table.Column<int>(type: "int", nullable: false),
                    ExposureMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExposureCompensation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasInterchangeableLens = table.Column<bool>(type: "bit", nullable: false),
                    IsDigital = table.Column<bool>(type: "bit", nullable: false),
                    LensId = table.Column<long>(type: "bigint", nullable: true),
                    MadeInCountry = table.Column<int>(type: "int", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cameras_Lenses_LensId",
                        column: x => x.LensId,
                        principalTable: "Lenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cameras_Mounts_MountId",
                        column: x => x.MountId,
                        principalTable: "Mounts",
                        principalColumn: "MountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GearImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageCategory = table.Column<int>(type: "int", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    AccessoryId = table.Column<long>(type: "bigint", nullable: true),
                    CameraId = table.Column<long>(type: "bigint", nullable: true),
                    LensId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearImages_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GearImages_Cameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Cameras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GearImages_Lenses_LensId",
                        column: x => x.LensId,
                        principalTable: "Lenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_LensId",
                table: "Cameras",
                column: "LensId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_MountId",
                table: "Cameras",
                column: "MountId");

            migrationBuilder.CreateIndex(
                name: "IX_GearImages_AccessoryId",
                table: "GearImages",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GearImages_CameraId",
                table: "GearImages",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_GearImages_LensId",
                table: "GearImages",
                column: "LensId");

            migrationBuilder.CreateIndex(
                name: "IX_Lenses_MountId",
                table: "Lenses",
                column: "MountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GearImages");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "Lenses");

            migrationBuilder.DropTable(
                name: "Mounts");
        }
    }
}
