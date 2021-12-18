using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementAppCW02.Server.Migrations
{
    public partial class AddCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Companies",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "establishedDate",
                table: "Companies",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "establishedDate",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "guid");
        }
    }
}
