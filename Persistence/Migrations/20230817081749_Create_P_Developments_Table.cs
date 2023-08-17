using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_P_Developments_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_Developments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentOrParticipation = table.Column<int>(type: "int", nullable: false),
                    PercentParticipation = table.Column<int>(type: "int", nullable: false),
                    AmountOfExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevPlanLeadsToIncrease = table.Column<int>(type: "int", nullable: false),
                    HaveAllLicences = table.Column<bool>(type: "bit", nullable: false),
                    PlaceOfImplementation = table.Column<int>(type: "int", nullable: false),
                    RentTypeId = table.Column<int>(type: "int", nullable: true),
                    JustificationPlan = table.Column<bool>(type: "bit", nullable: false),
                    WhichPartIntendParticipate = table.Column<int>(type: "int", nullable: false),
                    HaveFinancialStatement = table.Column<bool>(type: "bit", nullable: false),
                    ProposedPrice = table.Column<long>(type: "bigint", nullable: false),
                    AmountOfParticipationRequired = table.Column<int>(type: "int", nullable: false),
                    NetPresentValue = table.Column<long>(type: "bigint", nullable: false),
                    IsCurrentlyProfitable = table.Column<bool>(type: "bit", nullable: false),
                    LastYearProfit = table.Column<int>(type: "int", nullable: false),
                    LastYearLoss = table.Column<int>(type: "int", nullable: false),
                    HaveReceivedFaciliti = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Developments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Developments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_P_Developments_RentTypes_RentTypeId",
                        column: x => x.RentTypeId,
                        principalTable: "RentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_Developments_ProjectId",
                table: "P_Developments",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_P_Developments_RentTypeId",
                table: "P_Developments",
                column: "RentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_Developments");
        }
    }
}
