using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanzEksp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEF_ZipcodeEF_ZipcodeDetailsZipCode",
                table: "CustomerEF");

            migrationBuilder.DropTable(
                name: "ZipcodeEF");

            migrationBuilder.DropIndex(
                name: "IX_CustomerEF_ZipcodeDetailsZipCode",
                table: "CustomerEF");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "CustomerEF");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "CustomerEF");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "CustomerEF");

            migrationBuilder.DropColumn(
                name: "ZipcodeDetailsZipCode",
                table: "CustomerEF");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "EmployeeUserEF",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "DayPlanEF",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meals",
                table: "DayPlanEF",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Airport",
                table: "BookingEF",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "BookingEF",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "BookingEF",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TripLength",
                table: "BookingEF",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingEF_TripId",
                table: "BookingEF",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEF_TripEF_TripId",
                table: "BookingEF",
                column: "TripId",
                principalTable: "TripEF",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEF_TripEF_TripId",
                table: "BookingEF");

            migrationBuilder.DropIndex(
                name: "IX_BookingEF_TripId",
                table: "BookingEF");

            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "DayPlanEF");

            migrationBuilder.DropColumn(
                name: "Meals",
                table: "DayPlanEF");

            migrationBuilder.DropColumn(
                name: "Airport",
                table: "BookingEF");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "BookingEF");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "BookingEF");

            migrationBuilder.DropColumn(
                name: "TripLength",
                table: "BookingEF");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "EmployeeUserEF",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CustomerEF",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "CustomerEF",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "CustomerEF",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZipcodeDetailsZipCode",
                table: "CustomerEF",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZipcodeEF",
                columns: table => new
                {
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipcodeEF", x => x.ZipCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEF_ZipcodeDetailsZipCode",
                table: "CustomerEF",
                column: "ZipcodeDetailsZipCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEF_ZipcodeEF_ZipcodeDetailsZipCode",
                table: "CustomerEF",
                column: "ZipcodeDetailsZipCode",
                principalTable: "ZipcodeEF",
                principalColumn: "ZipCode");
        }
    }
}
