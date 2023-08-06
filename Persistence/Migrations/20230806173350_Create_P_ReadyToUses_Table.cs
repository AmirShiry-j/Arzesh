using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_P_ReadyToUses_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_ReadyToUses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentOrParticipation = table.Column<int>(type: "int", nullable: false),
                    PercentParticipation = table.Column<int>(type: "int", nullable: false),
                    AmountOfExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaveAllLicences = table.Column<bool>(type: "bit", nullable: false),
                    PlaceOfImplementation = table.Column<int>(type: "int", nullable: false),
                    RentTypeId = table.Column<int>(type: "int", nullable: true),
                    JustificationPlan = table.Column<bool>(type: "bit", nullable: false),
                    ProposedPrice = table.Column<int>(type: "int", nullable: false),
                    RequiredCapitalPlan = table.Column<int>(type: "int", nullable: false),
                    WhatTopicsNeedParticipate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetPresentValue = table.Column<int>(type: "int", nullable: false),
                    OverallProgressPercent = table.Column<int>(type: "int", nullable: false),
                    HaveReceivedFaciliti = table.Column<bool>(type: "bit", nullable: false),
                    DateStartOfOperationalActivities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_ReadyToUses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_ReadyToUses_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_P_ReadyToUses_RentTypes_RentTypeId",
                        column: x => x.RentTypeId,
                        principalTable: "RentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_ReadyToUses_ProjectId",
                table: "P_ReadyToUses",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_P_ReadyToUses_RentTypeId",
                table: "P_ReadyToUses",
                column: "RentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_ReadyToUses");
        }
    }
}
