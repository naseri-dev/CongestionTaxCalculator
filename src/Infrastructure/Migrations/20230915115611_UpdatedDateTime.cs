using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Years",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Years",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "VehicleCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "VehicleCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TollingStations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "TollingStations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TollFreeVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "TollFreeVehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TaxPaids",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "TaxPaids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TaxFeePerHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "TaxFeePerHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MaximumTaxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "MaximumTaxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Holidays",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Holidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Years");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Years");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "VehicleCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "VehicleCategories");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TollingStations");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "TollingStations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TollFreeVehicles");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "TollFreeVehicles");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TaxPaids");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "TaxPaids");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TaxFeePerHours");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "TaxFeePerHours");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MaximumTaxes");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "MaximumTaxes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "Cars");
        }
    }
}
