using Microsoft.EntityFrameworkCore.Migrations;

namespace Corecrud.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelName",
                table: "Destinations");

            migrationBuilder.AlterColumn<decimal>(
                name: "Altitude",
                table: "Destinations",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EquatorialWeather",
                table: "Destinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquatorialWeather",
                table: "Destinations");

            migrationBuilder.AlterColumn<decimal>(
                name: "Altitude",
                table: "Destinations",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "HotelName",
                table: "Destinations",
                nullable: true);
        }
    }
}
