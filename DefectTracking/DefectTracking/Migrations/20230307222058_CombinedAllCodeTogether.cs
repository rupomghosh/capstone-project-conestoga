using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class CombinedAllCodeTogether : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarrantyDefects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display = table.Column<int>(type: "int", nullable: false),
                    CalibrationMissingCalibration = table.Column<int>(type: "int", nullable: false),
                    MechanicalAssemblyError = table.Column<int>(type: "int", nullable: false),
                    DeadorDyingBatteries = table.Column<int>(type: "int", nullable: false),
                    PCBBoardDefect = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    OtherDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProblemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyDefects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarrantyDefects");
        }
    }
}
