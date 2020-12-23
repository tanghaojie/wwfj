﻿// <auto-generated />
using System;
using Backend.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    [DbContext(typeof(BackendDbContext))]
    partial class BackendDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Backend.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ContactInfo")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegisteredLocation")
                        .HasColumnType("text");

                    b.Property<string>("ResponsiblePerson")
                        .HasColumnType("text");

                    b.Property<string>("UnifiedSocialCreditCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Backend.Entities.FJ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("BusinessAdvicePublishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DigEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DigPaidDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DigProtocoledDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DigStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DocumentReviewCompletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DocumentSubmitDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EstimateArea")
                        .HasColumnType("text");

                    b.Property<int?>("EstimateAreaIndex")
                        .HasColumnType("integer");

                    b.Property<string>("EstimateTimespan")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExploreEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExplorePaidDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExploreSituation")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExploreStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FinishNoticePublishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("HandoverData")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string[]>("ImpactSituationItems")
                        .HasColumnType("text[]");

                    b.Property<int>("LandPropertyIndex")
                        .HasColumnType("integer");

                    b.Property<string>("LandPropertyName")
                        .HasColumnType("text");

                    b.Property<string>("LetterDateBeforeDig")
                        .HasColumnType("text");

                    b.Property<string>("LocationDetail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProjPropertyIndex")
                        .HasColumnType("integer");

                    b.Property<string>("ProjPropertyName")
                        .HasColumnType("text");

                    b.Property<string>("ProtocolNumber")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProtocolSendDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProtocolSendDepartment")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProtocoledDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RegionCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegionIndex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RequestCompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Situation")
                        .HasColumnType("text");

                    b.Property<string>("StageReport")
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("UnProtocoledReason")
                        .HasColumnType("text");

                    b.Property<int?>("UnProtocoledReasonIndex")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("WorkInfoPublishDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("RequestCompanyId");

                    b.ToTable("FJs");
                });

            modelBuilder.Entity("Backend.Entities.FJ2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AllFinish")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CommunicateWithProjCompanyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DocumentSubmitDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EstimateExcavateArea")
                        .HasColumnType("text");

                    b.Property<string>("EstimateExcavateDuration")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExcavationEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExcavationEnterDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExcavationProjName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FinishDocumentIssuanceDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IfExcavation")
                        .HasColumnType("boolean");

                    b.Property<string>("IfHaveTheConditionsForExcavation")
                        .HasColumnType("text");

                    b.Property<bool>("IfHaveTheConditionsForSurvey")
                        .HasColumnType("boolean");

                    b.Property<string>("IfPaySurveyFee")
                        .HasColumnType("text");

                    b.Property<bool>("IfSignSurveyAgreement")
                        .HasColumnType("boolean");

                    b.Property<string>("IfStartExcavation")
                        .HasColumnType("text");

                    b.Property<bool>("IfSurvey")
                        .HasColumnType("boolean");

                    b.Property<int?>("LandPropertyIndex")
                        .HasColumnType("integer");

                    b.Property<string>("LandPropertyName")
                        .HasColumnType("text");

                    b.Property<string>("LocationDetail")
                        .HasColumnType("text");

                    b.Property<bool>("MajorProj")
                        .HasColumnType("boolean");

                    b.Property<string[]>("NotHaveTheConditionsForExcavationReasons")
                        .HasColumnType("text[]");

                    b.Property<string[]>("NotHaveTheConditionsForSurveyReasons")
                        .HasColumnType("text[]");

                    b.Property<string[]>("NotSurveyReasons")
                        .HasColumnType("text[]");

                    b.Property<DateTime?>("NoticeOfReceiveFinishDocumentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("NoticeOfReceiveWorkFinishInfoDocumentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("OnSiteVerificationCompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PaperDocumentReviewCompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PartExcavationEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PartHaveTheConditionsForExcavationArea")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PayExcavationFeeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PaySurveyFeeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProjCompany")
                        .HasColumnType("text");

                    b.Property<string>("ProjName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ReceivedFinishDocument")
                        .HasColumnType("boolean");

                    b.Property<bool>("ReceivedWorkFinishInfoDocument")
                        .HasColumnType("boolean");

                    b.Property<string>("RegionCode")
                        .HasColumnType("text");

                    b.Property<string>("RegionIndex")
                        .HasColumnType("text");

                    b.Property<string>("RegionName")
                        .HasColumnType("text");

                    b.Property<string[]>("RemainsInfo")
                        .HasColumnType("text[]");

                    b.Property<DateTime?>("ReplyStampedSurveyAgreementDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("SendSurveyAgreementDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("SignExcavationAgreementDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("SignSurveyAgreementDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SurveyAgreementNumber")
                        .HasColumnType("text");

                    b.Property<string>("SurveyDepartment")
                        .HasColumnType("text");

                    b.Property<DateTime?>("SurveyEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("SurveyEnterDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SurveyWorkType")
                        .HasColumnType("text");

                    b.Property<DateTime?>("TaskExclusionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("WorkFinishInfoDocumentIssuanceDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("WorkInfoDocumentIssuanceDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("FJ2s");
                });

            modelBuilder.Entity("Backend.Entities.RequestCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestCompanies");
                });

            modelBuilder.Entity("Backend.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Locked")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Realname")
                        .HasColumnType("text");

                    b.Property<string>("RegionCode")
                        .HasColumnType("text");

                    b.Property<string>("RegionIndex")
                        .HasColumnType("text");

                    b.Property<string>("RegionName")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Entities.FJ", b =>
                {
                    b.HasOne("Backend.Entities.RequestCompany", "RequestCompany")
                        .WithMany()
                        .HasForeignKey("RequestCompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
