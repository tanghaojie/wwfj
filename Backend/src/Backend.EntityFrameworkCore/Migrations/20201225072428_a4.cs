using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class a4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Options_OptionType",
                table: "Options",
                column: "OptionType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Options_OptionType",
                table: "Options");
        }
    }
}
