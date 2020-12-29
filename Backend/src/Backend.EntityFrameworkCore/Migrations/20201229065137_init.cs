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
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    RegisteredLocation = table.Column<string>(nullable: true),
                    UnifiedSocialCreditCode = table.Column<string>(nullable: true),
                    ResponsiblePerson = table.Column<string>(nullable: true),
                    ContactInfo = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OptionType = table.Column<string>(nullable: false),
                    Values = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Realname = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    RegionIndex = table.Column<string>(nullable: true),
                    Locked = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FJ2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjName = table.Column<string>(nullable: false),
                    ProjCompanyId = table.Column<int>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    LocationDetail = table.Column<string>(nullable: true),
                    LandPropertyName = table.Column<string>(nullable: true),
                    MajorProj = table.Column<bool>(nullable: false),
                    DocumentSubmitDate = table.Column<DateTime>(nullable: true),
                    PaperDocumentReviewCompletionDate = table.Column<DateTime>(nullable: true),
                    OnSiteVerificationCompletionDate = table.Column<DateTime>(nullable: true),
                    IfSurvey = table.Column<bool>(nullable: false),
                    NotSurveyReasons = table.Column<string[]>(nullable: true),
                    SurveyWorkType = table.Column<string>(nullable: true),
                    IfSignSurveyAgreement = table.Column<bool>(nullable: false),
                    SendSurveyAgreementDate = table.Column<DateTime>(nullable: true),
                    ReplyStampedSurveyAgreementDate = table.Column<DateTime>(nullable: true),
                    SignSurveyAgreementDate = table.Column<DateTime>(nullable: true),
                    SurveyAgreementNumber = table.Column<string>(nullable: true),
                    TaskExclusionDate = table.Column<DateTime>(nullable: true),
                    SurveyDepartment = table.Column<string>(nullable: true),
                    CommunicateWithProjCompanyDate = table.Column<DateTime>(nullable: true),
                    IfHaveTheConditionsForSurvey = table.Column<bool>(nullable: false),
                    NotHaveTheConditionsForSurveyReasons = table.Column<string[]>(nullable: true),
                    SurveyEnterDate = table.Column<DateTime>(nullable: true),
                    SurveyEndDate = table.Column<DateTime>(nullable: true),
                    IfExcavation = table.Column<bool>(nullable: false),
                    RemainsInfo = table.Column<string[]>(nullable: true),
                    EstimateExcavateArea = table.Column<string>(nullable: true),
                    EstimateExcavateDuration = table.Column<string>(nullable: true),
                    ExcavationProjName = table.Column<string>(nullable: true),
                    IfHaveTheConditionsForExcavation = table.Column<string>(nullable: true),
                    NotHaveTheConditionsForExcavationReasons = table.Column<string[]>(nullable: true),
                    PartHaveTheConditionsForExcavationArea = table.Column<string>(nullable: true),
                    IfStartExcavation = table.Column<string>(nullable: true),
                    ExcavationEnterDate = table.Column<DateTime>(nullable: true),
                    PartExcavationEndDate = table.Column<DateTime>(nullable: true),
                    ExcavationEndDate = table.Column<DateTime>(nullable: true),
                    SignExcavationAgreementDate = table.Column<DateTime>(nullable: true),
                    IfPaySurveyFee = table.Column<string>(nullable: true),
                    PaySurveyFeeDate = table.Column<DateTime>(nullable: true),
                    PayExcavationFeeDate = table.Column<DateTime>(nullable: true),
                    WorkInfoDocumentIssuanceDate = table.Column<DateTime>(nullable: true),
                    WorkFinishInfoDocumentIssuanceDate = table.Column<DateTime>(nullable: true),
                    NoticeOfReceiveWorkFinishInfoDocumentDate = table.Column<DateTime>(nullable: true),
                    ReceivedWorkFinishInfoDocument = table.Column<bool>(nullable: false),
                    FinishDocumentIssuanceDate = table.Column<DateTime>(nullable: true),
                    NoticeOfReceiveFinishDocumentDate = table.Column<DateTime>(nullable: true),
                    ReceivedFinishDocument = table.Column<bool>(nullable: false),
                    AllFinish = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FJ2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FJ2s_Companies_ProjCompanyId",
                        column: x => x.ProjCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    LocationDetail = table.Column<string>(nullable: true),
                    RequestCompanyId = table.Column<int>(nullable: true),
                    ProjPropertyName = table.Column<string>(nullable: true),
                    ProjPropertyIndex = table.Column<int>(nullable: false),
                    LandPropertyName = table.Column<string>(nullable: true),
                    LandPropertyIndex = table.Column<int>(nullable: false),
                    DocumentSubmitDate = table.Column<DateTime>(nullable: true),
                    DocumentReviewCompletedDate = table.Column<DateTime>(nullable: true),
                    ProtocoledDate = table.Column<DateTime>(nullable: true),
                    ProtocolNumber = table.Column<string>(nullable: true),
                    ProtocolSendDate = table.Column<DateTime>(nullable: true),
                    ProtocolSendDepartment = table.Column<string>(nullable: true),
                    UnProtocoledReason = table.Column<string>(nullable: true),
                    UnProtocoledReasonIndex = table.Column<int>(nullable: true),
                    ExplorePaidDate = table.Column<DateTime>(nullable: true),
                    ExploreSituation = table.Column<string>(nullable: true),
                    ExploreStartDate = table.Column<DateTime>(nullable: true),
                    ExploreEndDate = table.Column<DateTime>(nullable: true),
                    Situation = table.Column<string>(nullable: true),
                    EstimateArea = table.Column<string>(nullable: true),
                    EstimateAreaIndex = table.Column<int>(nullable: true),
                    EstimateTimespan = table.Column<string>(nullable: true),
                    LetterDateBeforeDig = table.Column<string>(nullable: true),
                    ImpactSituationItems = table.Column<string[]>(nullable: true),
                    DigProtocoledDate = table.Column<DateTime>(nullable: true),
                    DigPaidDate = table.Column<DateTime>(nullable: true),
                    DigStartDate = table.Column<DateTime>(nullable: true),
                    DigEndDate = table.Column<DateTime>(nullable: true),
                    StageReport = table.Column<string>(nullable: true),
                    HandoverData = table.Column<DateTime>(nullable: true),
                    WorkInfoPublishDate = table.Column<DateTime>(nullable: true),
                    BusinessAdvicePublishDate = table.Column<DateTime>(nullable: true),
                    FinishNoticePublishDate = table.Column<DateTime>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FJs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FJs_RequestCompanies_RequestCompanyId",
                        column: x => x.RequestCompanyId,
                        principalTable: "RequestCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FJ2s_ProjCompanyId",
                table: "FJ2s",
                column: "ProjCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FJs_RequestCompanyId",
                table: "FJs",
                column: "RequestCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_OptionType",
                table: "Options",
                column: "OptionType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_TenantId_Name_UserId",
                table: "Settings",
                columns: new[] { "TenantId", "Name", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FJ2s");

            migrationBuilder.DropTable(
                name: "FJs");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "RequestCompanies");
        }
    }
}
