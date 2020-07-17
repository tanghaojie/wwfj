using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FJs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RegionCode = table.Column<string>(nullable: false),
                    RegionName = table.Column<string>(nullable: false),
                    RegionIndex = table.Column<string>(nullable: false),
                    LocationDetail = table.Column<string>(nullable: false),
                    ProjPropertyName = table.Column<string>(nullable: false),
                    ProjPropertyIndex = table.Column<int>(nullable: false),
                    LandPropertyName = table.Column<string>(nullable: false),
                    LandPropertyIndex = table.Column<int>(nullable: false),
                    DocumentSubmitDate = table.Column<DateTime>(nullable: true),
                    DocumentReviewCompletedDate = table.Column<DateTime>(nullable: true),
                    ProtocoledDate = table.Column<DateTime>(nullable: true),
                    UnProtocoledReason = table.Column<string>(nullable: true),
                    UnProtocoledReasonIndex = table.Column<int>(nullable: true),
                    ExplorePaidDate = table.Column<DateTime>(nullable: true),
                    ExploreStartDate = table.Column<DateTime>(nullable: true),
                    ExploreEndDate = table.Column<DateTime>(nullable: true),
                    Situation = table.Column<string>(nullable: true),
                    EstimateArea = table.Column<double>(nullable: true),
                    EstimateFinishDate = table.Column<DateTime>(nullable: true),
                    LetterDateBeforeDig = table.Column<string>(nullable: true),
                    ImpactSituationItems = table.Column<string[]>(nullable: true),
                    DigProtocoledDate = table.Column<DateTime>(nullable: true),
                    DigPaidDate = table.Column<DateTime>(nullable: true),
                    DigStartDate = table.Column<DateTime>(nullable: true),
                    DigEndDate = table.Column<DateTime>(nullable: true),
                    StageReport = table.Column<string>(nullable: true),
                    WorkInfoPublishDate = table.Column<DateTime>(nullable: true),
                    BusinessAdvicePublishDate = table.Column<DateTime>(nullable: true),
                    FinishNoticePublishDate = table.Column<DateTime>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FJs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Department = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Realname = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    RegionIndex = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FJs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
