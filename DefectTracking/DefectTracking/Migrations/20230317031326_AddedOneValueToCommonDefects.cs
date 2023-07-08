using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddedOneValueToCommonDefects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommonDefectName",
                value: "");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommonDefectName",
                value: "Speaker quiet");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommonDefectName",
                value: "No sound");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommonDefectName",
                value: "Switch not working");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommonDefectName",
                value: "Button not working");

            migrationBuilder.InsertData(
                table: "CommonDefects",
                columns: new[] { "Id", "CommonDefectName" },
                values: new object[] { 6, "Enclosure Defect" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommonDefectName",
                value: "Speaker quiet");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommonDefectName",
                value: "No sound");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommonDefectName",
                value: "Switch not working");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CommonDefectName",
                value: "Button not working");

            migrationBuilder.UpdateData(
                table: "CommonDefects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CommonDefectName",
                value: "Enclosure Defect");
        }
    }
}
