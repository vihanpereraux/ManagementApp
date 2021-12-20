using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagmentAppTestOne.Server.Migrations
{
    public partial class newfieldsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectDescription",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectStartedDate",
                table: "Projects",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProjectStatus",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EstablishedDate",
                table: "Companies",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumOfEmployees",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectStartedDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectStatus",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EstablishedDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "NumOfEmployees",
                table: "Companies");
        }
    }
}
