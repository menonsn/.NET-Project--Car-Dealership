using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corecrud.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EquatorialWeather",
                table: "Destinations",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfVisit",
                table: "Destinations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EquatorialWeather",
                table: "Destinations",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfVisit",
                table: "Destinations",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
