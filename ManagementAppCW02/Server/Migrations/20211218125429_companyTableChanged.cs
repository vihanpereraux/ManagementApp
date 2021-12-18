using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementAppCW02.Server.Migrations
{
    public partial class companyTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_Companyid",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Companyid",
                table: "Projects",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_Companyid",
                table: "Projects",
                newName: "IX_Projects_companyId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "companyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "companyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_companyId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "Projects",
                newName: "Companyid");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_companyId",
                table: "Projects",
                newName: "IX_Projects_Companyid");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "Companies",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_Companyid",
                table: "Projects",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
