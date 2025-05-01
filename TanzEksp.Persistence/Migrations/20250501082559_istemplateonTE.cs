using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanzEksp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class istemplateonTE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTemplate",
                table: "TripEventEF",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTemplate",
                table: "TripEventEF");
        }
    }
}
