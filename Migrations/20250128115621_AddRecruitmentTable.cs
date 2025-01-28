using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testcrud.Migrations
{
    /// <inheritdoc />
    public partial class AddRecruitmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recruitments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    General = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceAlkhaleej = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceKuwait = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    ContractPeriod = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivingTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MartialStatus = table.Column<int>(type: "int", nullable: false),
                    NoOfChildren = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Complexion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalQualificationsGrade = table.Column<int>(type: "int", nullable: true),
                    LanguageArabic = table.Column<int>(type: "int", nullable: false),
                    LanguageEnglish = table.Column<int>(type: "int", nullable: false),
                    PreviousEmploymentAbroadCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousEmploymentAbroadPeriod = table.Column<int>(type: "int", nullable: true),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPassport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssuePassport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfIssuePassport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfExpiryPassport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruitments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_JobRecruitments_JobId",
                        column: x => x.JobId,
                        principalTable: "JobRecruitments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_CityId",
                table: "Recruitments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_JobId",
                table: "Recruitments",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_NationalityId",
                table: "Recruitments",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_VendorId",
                table: "Recruitments",
                column: "VendorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recruitments");
        }
    }
}
