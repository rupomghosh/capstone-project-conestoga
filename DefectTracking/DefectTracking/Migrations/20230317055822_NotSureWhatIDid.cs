using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class NotSureWhatIDid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommonDefectID",
                table: "DeliveryDefects",
                newName: "CommonDefectId");

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectsCommonDefectId",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDefects_CommonDefects_CommonDefectsCommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDefects_CommonDefectsCommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectsCommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.RenameColumn(
                name: "CommonDefectId",
                table: "DeliveryDefects",
                newName: "CommonDefectID");
        }
    }
}
