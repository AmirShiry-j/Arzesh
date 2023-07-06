using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_P_Incompleteds_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitedId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Part_Village = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilitiNatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiNatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilitiStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "P_Incompleteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentOrParticipation = table.Column<int>(type: "int", nullable: false),
                    PercentParticipation = table.Column<int>(type: "int", nullable: false),
                    AmountOfExperience = table.Column<int>(type: "int", nullable: false),
                    HaveAllLicences = table.Column<bool>(type: "bit", nullable: false),
                    PlaceOfImplementation = table.Column<int>(type: "int", nullable: false),
                    RentTypeId = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    JustificationPlan = table.Column<bool>(type: "bit", nullable: false),
                    ProposedPrice = table.Column<int>(type: "int", nullable: false),
                    RequiredCapitalPlan = table.Column<int>(type: "int", nullable: false),
                    AmountCapitalDemand = table.Column<int>(type: "int", nullable: false),
                    WhatTopicsNeedParticipate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnInvestmentRate = table.Column<int>(type: "int", nullable: false),
                    NetPresentValue = table.Column<int>(type: "int", nullable: false),
                    HaveReceivedFaciliti = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Incompleteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Incompleteds_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_P_Incompleteds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilitiRelProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilitiType = table.Column<int>(type: "int", nullable: false),
                    FacilitiStatusId = table.Column<int>(type: "int", nullable: false),
                    FacilitiNatureId = table.Column<int>(type: "int", nullable: false),
                    ReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstallmentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepaymentPeriod = table.Column<int>(type: "int", nullable: false),
                    placeSupply_Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestRate = table.Column<int>(type: "int", nullable: false),
                    CollateralName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiRelProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitiRelProjects_FacilitiNatures_FacilitiNatureId",
                        column: x => x.FacilitiNatureId,
                        principalTable: "FacilitiNatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilitiRelProjects_FacilitiStatuses_FacilitiStatusId",
                        column: x => x.FacilitiStatusId,
                        principalTable: "FacilitiStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilitiRelProjects_P_Incompleteds_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "P_Incompleteds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundRelProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundId = table.Column<int>(type: "int", nullable: false),
                    PercenPhysicalProgress = table.Column<int>(type: "int", nullable: false),
                    AmountSpent = table.Column<int>(type: "int", nullable: false),
                    TotalAmountNeeded = table.Column<int>(type: "int", nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundRelProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundRelProjects_Funds_FundId",
                        column: x => x.FundId,
                        principalTable: "Funds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundRelProjects_P_Incompleteds_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "P_Incompleteds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicenceRelProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenceId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceRelProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenceRelProjects_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenceRelProjects_P_Incompleteds_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "P_Incompleteds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiRelProjects_FacilitiNatureId",
                table: "FacilitiRelProjects",
                column: "FacilitiNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiRelProjects_FacilitiStatusId",
                table: "FacilitiRelProjects",
                column: "FacilitiStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiRelProjects_ProjectId",
                table: "FacilitiRelProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FundRelProjects_FundId",
                table: "FundRelProjects",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_FundRelProjects_ProjectId",
                table: "FundRelProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenceRelProjects_LicenceId",
                table: "LicenceRelProjects",
                column: "LicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenceRelProjects_ProjectId",
                table: "LicenceRelProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_AddressId",
                table: "P_Incompleteds",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_UserId",
                table: "P_Incompleteds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitiRelProjects");

            migrationBuilder.DropTable(
                name: "FundRelProjects");

            migrationBuilder.DropTable(
                name: "LicenceRelProjects");

            migrationBuilder.DropTable(
                name: "FacilitiNatures");

            migrationBuilder.DropTable(
                name: "FacilitiStatuses");

            migrationBuilder.DropTable(
                name: "Funds");

            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "P_Incompleteds");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
