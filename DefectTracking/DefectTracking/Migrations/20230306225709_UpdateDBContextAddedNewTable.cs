using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBContextAddedNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturingDefects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Display = table.Column<int>(type: "int", nullable: false),
                    CalibrationMissingCalibration = table.Column<int>(type: "int", nullable: false),
                    MechanicalAssemblyError = table.Column<int>(type: "int", nullable: false),
                    DeadorDyingBatteries = table.Column<int>(type: "int", nullable: false),
                    PCBBoardDefect = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    OtherDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingDefects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturingDefects");
        }
    }
}
