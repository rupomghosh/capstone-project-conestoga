using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleiveryDefectsWithCommonDefectField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommonDefectId",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommonDefectId",
                table: "DeliveryDefects");
        }
    }
}
