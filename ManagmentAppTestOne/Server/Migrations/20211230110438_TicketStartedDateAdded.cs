using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagmentAppTestOne.Server.Migrations
{
    public partial class TicketStartedDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TicketStartedDate",
                table: "Tickets",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketStartedDate",
                table: "Tickets");
        }
    }
}
