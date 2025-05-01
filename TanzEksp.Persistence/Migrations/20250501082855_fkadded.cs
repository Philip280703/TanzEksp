using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanzEksp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fkadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayPlanEF_TripEventEF_TripEventId",
                table: "DayPlanEF");

            migrationBuilder.AlterColumn<int>(
                name: "TripEventId",
                table: "DayPlanEF",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DayPlanEF_TripEventEF_TripEventId",
                table: "DayPlanEF",
                column: "TripEventId",
                principalTable: "TripEventEF",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayPlanEF_TripEventEF_TripEventId",
                table: "DayPlanEF");

            migrationBuilder.AlterColumn<int>(
                name: "TripEventId",
                table: "DayPlanEF",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DayPlanEF_TripEventEF_TripEventId",
                table: "DayPlanEF",
                column: "TripEventId",
                principalTable: "TripEventEF",
                principalColumn: "Id");
        }
    }
}
