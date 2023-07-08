using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class removecommondefects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "CommonDefects");

            migrationBuilder.DropIndex(
                name: "IX_WarrantyDefects_CommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturingDefects_CommonDefectId",
                table: "ManufacturingDefects");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDefects_CommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectId",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectId",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "CommonDefectId",
                table: "DeliveryDefects");

            migrationBuilder.AlterColumn<string>(
                name: "ProblemDesc",
                table: "ManufacturingDefects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommonDefectId",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemDesc",
                table: "ManufacturingDefects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectId",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommonDefectId",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommonDefects",
                columns: table => new
                {
                    CommonDefectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonDefectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonDefects", x => x.CommonDefectId);
                });

            migrationBuilder.InsertData(
                table: "CommonDefects",
                columns: new[] { "CommonDefectId", "CommonDefectName" },
                values: new object[,]
                {
                    { 1, "" },
                    { 2, "Speaker quiet" },
                    { 3, "No sound" },
                    { 4, "Switch not working" },
                    { 5, "Button not working" },
                    { 6, "Enclosure Defect" }
                });

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
    }
}
