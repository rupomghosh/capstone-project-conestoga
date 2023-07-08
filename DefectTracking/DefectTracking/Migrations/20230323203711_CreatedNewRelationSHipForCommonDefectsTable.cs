using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class CreatedNewRelationSHipForCommonDefectsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDefects_CommonDefects_CommonDefectsCommonDefectId",
                table: "DeliveryDefects");

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

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDefects_CommonDefectsCommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectsCommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectsCommonDefectId",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectsCommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.AlterColumn<string>(
                name: "ProblemDesc",
                table: "ManufacturingDefects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyDefects_CommonDefectId",
                table: "WarrantyDefects",
                column: "CommonDefectId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingDefects_CommonDefectId",
                table: "ManufacturingDefects",
                column: "CommonDefectId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDefects_CommonDefectId",
                table: "DeliveryDefects",
                column: "CommonDefectId");

            migrationBuilder.AddForeignKey(
                name: "FK_deliveryDefects_commonDefects",
                table: "DeliveryDefects",
                column: "CommonDefectId",
                principalTable: "CommonDefects",
                principalColumn: "CommonDefectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manufacturingDefects_commonDefects",
                table: "ManufacturingDefects",
                column: "CommonDefectId",
                principalTable: "CommonDefects",
                principalColumn: "CommonDefectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_warrantyDefects_commonDefects",
                table: "WarrantyDefects",
                column: "CommonDefectId",
                principalTable: "CommonDefects",
                principalColumn: "CommonDefectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deliveryDefects_commonDefects",
                table: "DeliveryDefects");

            migrationBuilder.DropForeignKey(
                name: "FK_manufacturingDefects_commonDefects",
                table: "ManufacturingDefects");

            migrationBuilder.DropForeignKey(
                name: "FK_warrantyDefects_commonDefects",
                table: "WarrantyDefects");

            migrationBuilder.DropIndex(
                name: "IX_WarrantyDefects_CommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturingDefects_CommonDefectId",
                table: "ManufacturingDefects");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDefects_CommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectsCommonDefectId",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemDesc",
                table: "ManufacturingDefects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectsCommonDefectId",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectsCommonDefectId",
                table: "DeliveryDefects",
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

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDefects_CommonDefectsCommonDefectId",
                table: "DeliveryDefects",
                column: "CommonDefectsCommonDefectId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDefects_CommonDefects_CommonDefectsCommonDefectId",
                table: "DeliveryDefects",
                column: "CommonDefectsCommonDefectId",
                principalTable: "CommonDefects",
                principalColumn: "CommonDefectId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
