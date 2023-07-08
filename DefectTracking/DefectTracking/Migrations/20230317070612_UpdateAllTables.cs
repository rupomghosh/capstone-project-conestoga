using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommonDefectId",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectsCommonDefectId",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectId",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectsCommonDefectId",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyDefects_CommonDefectsCommonDefectId",
                table: "WarrantyDefects",
                column: "CommonDefectsCommonDefectId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingDefects_CommonDefectsCommonDefectId",
                table: "ManufacturingDefects",
                column: "CommonDefectsCommonDefectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingDefects_CommonDefects_CommonDefectsCommonDefectId",
                table: "ManufacturingDefects",
                column: "CommonDefectsCommonDefectId",
                principalTable: "CommonDefects",
                principalColumn: "CommonDefectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantyDefects_CommonDefects_CommonDefectsCommonDefectId",
                table: "WarrantyDefects",
                column: "CommonDefectsCommonDefectId",
                principalTable: "CommonDefects",
                principalColumn: "CommonDefectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingDefects_CommonDefects_CommonDefectsCommonDefectId",
                table: "ManufacturingDefects");

            migrationBuilder.DropForeignKey(
                name: "FK_WarrantyDefects_CommonDefects_CommonDefectsCommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropIndex(
                name: "IX_WarrantyDefects_CommonDefectsCommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturingDefects_CommonDefectsCommonDefectId",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectsCommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectId",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectsCommonDefectId",
                table: "ManufacturingDefects");
        }
    }
}
