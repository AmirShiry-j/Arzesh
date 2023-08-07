using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_UnderCapacity_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_UnderCapacity",
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
                    HaveFinancialStatement = table.Column<bool>(type: "bit", nullable: false),
                    ProposedPrice = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfParticipationRequired = table.Column<int>(type: "int", nullable: false),
                    WhatTopicsNeedParticipate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCurrentlyProfitable = table.Column<bool>(type: "bit", nullable: false),
                    LastYearProfit = table.Column<int>(type: "int", nullable: false),
                    LastYearLoss = table.Column<int>(type: "int", nullable: false),
                    HaveReceivedFaciliti = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_UnderCapacity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_UnderCapacity_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_P_UnderCapacity_RentTypes_RentTypeId",
                        column: x => x.RentTypeId,
                        principalTable: "RentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_UnderCapacity_ProjectId",
                table: "P_UnderCapacity",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_P_UnderCapacity_RentTypeId",
                table: "P_UnderCapacity",
                column: "RentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_UnderCapacity");
        }
    }
}
