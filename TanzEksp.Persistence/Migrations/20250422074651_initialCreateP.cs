using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanzEksp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreateP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeUserEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUserEF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TripType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripEF", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TripEventEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripEventEF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripEventEF_TripEF_TripId",
                        column: x => x.TripId,
                        principalTable: "TripEF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipcodeDetailsZipCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerEF_ZipcodeEF_ZipcodeDetailsZipCode",
                        column: x => x.ZipcodeDetailsZipCode,
                        principalTable: "ZipcodeEF",
                        principalColumn: "ZipCode");
                });

            migrationBuilder.CreateTable(
                name: "DayPlanEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripEventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayPlanEF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayPlanEF_TripEventEF_TripEventId",
                        column: x => x.TripEventId,
                        principalTable: "TripEventEF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AdultCount = table.Column<int>(type: "int", nullable: false),
                    ChildCount = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingEF_CustomerEF_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerEF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEF_CustomerId",
                table: "BookingEF",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEF_ZipcodeDetailsZipCode",
                table: "CustomerEF",
                column: "ZipcodeDetailsZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_DayPlanEF_TripEventId",
                table: "DayPlanEF",
                column: "TripEventId");

            migrationBuilder.CreateIndex(
                name: "IX_TripEventEF_TripId",
                table: "TripEventEF",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingEF");

            migrationBuilder.DropTable(
                name: "DayPlanEF");

            migrationBuilder.DropTable(
                name: "EmployeeUserEF");

            migrationBuilder.DropTable(
                name: "CustomerEF");

            migrationBuilder.DropTable(
                name: "TripEventEF");

            migrationBuilder.DropTable(
                name: "ZipcodeEF");

            migrationBuilder.DropTable(
                name: "TripEF");
        }
    }
}
