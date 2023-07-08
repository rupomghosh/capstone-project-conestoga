using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class CreatedCommonDefectTableWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonDefects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonDefectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonDefects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CommonDefects",
                columns: new[] { "Id", "CommonDefectName" },
                values: new object[,]
                {
                    { 1, "Speaker quiet" },
                    { 2, "No sound" },
                    { 3, "Switch not working" },
                    { 4, "Button not working" },
                    { 5, "Enclosure Defect" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonDefects");
        }
    }
}
