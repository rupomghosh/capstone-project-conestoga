using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefectTracking.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ButtonNotWorking",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WarrantyDefects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnclosureDefect",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoSound",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerQuiet",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SwitchNotWorking",
                table: "WarrantyDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ButtonNotWorking",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ManufacturingDefects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnclosureDefect",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoSound",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerQuiet",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SwitchNotWorking",
                table: "ManufacturingDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ButtonNotWorking",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "DeliveryDefects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnclosureDefect",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoSound",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerQuiet",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SwitchNotWorking",
                table: "DeliveryDefects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonNotWorking",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "EnclosureDefect",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "NoSound",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "SpeakerQuiet",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "SwitchNotWorking",
                table: "WarrantyDefects");

            migrationBuilder.DropColumn(
                name: "ButtonNotWorking",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "EnclosureDefect",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "NoSound",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "SpeakerQuiet",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "SwitchNotWorking",
                table: "ManufacturingDefects");

            migrationBuilder.DropColumn(
                name: "ButtonNotWorking",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "EnclosureDefect",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "NoSound",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "SpeakerQuiet",
                table: "DeliveryDefects");

            migrationBuilder.DropColumn(
                name: "SwitchNotWorking",
                table: "DeliveryDefects");
        }
    }
}
