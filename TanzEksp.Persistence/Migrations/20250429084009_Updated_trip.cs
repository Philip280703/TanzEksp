using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanzEksp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updated_trip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TripEF");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TripEF");

            migrationBuilder.AddColumn<bool>(
                name: "IsTemplate",
                table: "TripEF",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTemplate",
                table: "TripEF");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TripEF",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TripEF",
                type: "datetime2",
                nullable: true);
        }
    }
}
