using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_Project_Stoppeds_Table_And_InactivityReasons_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InactivityReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InactivityReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "project_Stoppeds",
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
                    ProposedPrice = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfParticipationRequired = table.Column<int>(type: "int", nullable: false),
                    DurationInactivityYear = table.Column<int>(type: "int", nullable: false),
                    TotalValueNewInvestment = table.Column<long>(type: "bigint", nullable: false),
                    NetPresentValue = table.Column<int>(type: "int", nullable: false),
                    InactivityReasonId = table.Column<int>(type: "int", nullable: false),
                    ExplanationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaveReceivedFaciliti = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_Stoppeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_Stoppeds_InactivityReasons_InactivityReasonId",
                        column: x => x.InactivityReasonId,
                        principalTable: "InactivityReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_project_Stoppeds_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_Stoppeds_RentTypes_RentTypeId",
                        column: x => x.RentTypeId,
                        principalTable: "RentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_project_Stoppeds_InactivityReasonId",
                table: "project_Stoppeds",
                column: "InactivityReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_project_Stoppeds_ProjectId",
                table: "project_Stoppeds",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_project_Stoppeds_RentTypeId",
                table: "project_Stoppeds",
                column: "RentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "project_Stoppeds");

            migrationBuilder.DropTable(
                name: "InactivityReasons");
        }
    }
}
