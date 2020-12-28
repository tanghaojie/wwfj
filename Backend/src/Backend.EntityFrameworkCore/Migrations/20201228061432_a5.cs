using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class a5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjCompany",
                table: "FJ2s");

            migrationBuilder.AddColumn<int>(
                name: "ProjCompanyId",
                table: "FJ2s",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FJ2s_ProjCompanyId",
                table: "FJ2s",
                column: "ProjCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FJ2s_Companies_ProjCompanyId",
                table: "FJ2s",
                column: "ProjCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FJ2s_Companies_ProjCompanyId",
                table: "FJ2s");

            migrationBuilder.DropIndex(
                name: "IX_FJ2s_ProjCompanyId",
                table: "FJ2s");

            migrationBuilder.DropColumn(
                name: "ProjCompanyId",
                table: "FJ2s");

            migrationBuilder.AddColumn<string>(
                name: "ProjCompany",
                table: "FJ2s",
                type: "text",
                nullable: true);
        }
    }
}
