using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_P_Idehs_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_Idehs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentOrParticipation = table.Column<int>(type: "int", nullable: false),
                    PercentParticipation = table.Column<int>(type: "int", nullable: false),
                    HaveSimilarDomesticCase = table.Column<bool>(type: "bit", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    HasLicense = table.Column<bool>(type: "bit", nullable: false),
                    JustificationPlan = table.Column<bool>(type: "bit", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    RequiredCapitalPlan = table.Column<int>(type: "int", nullable: false),
                    AmountCapitalDemand = table.Column<int>(type: "int", nullable: false),
                    WhatTopicsNeedParticipate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnInvestmentRate = table.Column<int>(type: "int", nullable: false),
                    NetPresentValue = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Idehs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Idehs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_Idehs_UserId",
                table: "P_Idehs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_Idehs");
        }
    }
}
