using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_KOLOKWIUM.Migrations
{
    public partial class AddPerformanceDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PerformanceDate",
                table: "Artist_Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerformanceDate",
                table: "Artist_Events");
        }
    }
}
