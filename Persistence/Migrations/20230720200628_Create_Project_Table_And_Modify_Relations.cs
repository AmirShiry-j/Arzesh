using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_Project_Table_And_Modify_Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_P_Incompleteds_ProjectId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_FacilitiRelProjects_P_Incompleteds_ProjectId",
                table: "FacilitiRelProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_FundRelProjects_P_Incompleteds_ProjectId",
                table: "FundRelProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenceRelProjects_P_Incompleteds_ProjectId",
                table: "LicenceRelProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Idehs_AspNetUsers_UserId",
                table: "P_Idehs");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Idehs_Industries_IndustryId",
                table: "P_Idehs");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Incompleteds_AspNetUsers_UserId",
                table: "P_Incompleteds");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Incompleteds_Industries_IndustryId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_IndustryId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_UserId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Idehs_IndustryId",
                table: "P_Idehs");

            migrationBuilder.DropIndex(
                name: "IX_P_Idehs_UserId",
                table: "P_Idehs");

            migrationBuilder.DropColumn(
                name: "AmountCapitalDemand",
                table: "P_Incompleteds");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "P_Incompleteds");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "P_Incompleteds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "P_Incompleteds");

            migrationBuilder.DropColumn(
                name: "AmountCapitalDemand",
                table: "P_Idehs");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "P_Idehs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "P_Idehs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "P_Idehs");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "LicenceRelProjects");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "FundRelProjects");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "FacilitiRelProjects");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ReturnInvestmentRate",
                table: "P_Incompleteds",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "ReturnInvestmentRate",
                table: "P_Idehs",
                newName: "ProjectId");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: true),
                    ReturnInvestmentRate = table.Column<int>(type: "int", nullable: false),
                    AmountCapitalDemand = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_ProjectId",
                table: "P_Incompleteds",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Idehs_ProjectId",
                table: "P_Idehs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IndustryId",
                table: "Projects",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Projects_ProjectId",
                table: "Addresses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitiRelProjects_Projects_ProjectId",
                table: "FacilitiRelProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundRelProjects_Projects_ProjectId",
                table: "FundRelProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenceRelProjects_Projects_ProjectId",
                table: "LicenceRelProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_P_Idehs_Projects_ProjectId",
                table: "P_Idehs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_P_Incompleteds_Projects_ProjectId",
                table: "P_Incompleteds",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Projects_ProjectId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_FacilitiRelProjects_Projects_ProjectId",
                table: "FacilitiRelProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_FundRelProjects_Projects_ProjectId",
                table: "FundRelProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenceRelProjects_Projects_ProjectId",
                table: "LicenceRelProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Idehs_Projects_ProjectId",
                table: "P_Idehs");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Incompleteds_Projects_ProjectId",
                table: "P_Incompleteds");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_ProjectId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Idehs_ProjectId",
                table: "P_Idehs");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "P_Incompleteds",
                newName: "ReturnInvestmentRate");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "P_Idehs",
                newName: "ReturnInvestmentRate");

            migrationBuilder.AddColumn<int>(
                name: "AmountCapitalDemand",
                table: "P_Incompleteds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndustryId",
                table: "P_Incompleteds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "P_Incompleteds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "P_Incompleteds",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AmountCapitalDemand",
                table: "P_Idehs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndustryId",
                table: "P_Idehs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "P_Idehs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "P_Idehs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "LicenceRelProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "FundRelProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "FacilitiRelProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_IndustryId",
                table: "P_Incompleteds",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_UserId",
                table: "P_Incompleteds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Idehs_IndustryId",
                table: "P_Idehs",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Idehs_UserId",
                table: "P_Idehs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_P_Incompleteds_ProjectId",
                table: "Addresses",
                column: "ProjectId",
                principalTable: "P_Incompleteds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitiRelProjects_P_Incompleteds_ProjectId",
                table: "FacilitiRelProjects",
                column: "ProjectId",
                principalTable: "P_Incompleteds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundRelProjects_P_Incompleteds_ProjectId",
                table: "FundRelProjects",
                column: "ProjectId",
                principalTable: "P_Incompleteds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenceRelProjects_P_Incompleteds_ProjectId",
                table: "LicenceRelProjects",
                column: "ProjectId",
                principalTable: "P_Incompleteds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_P_Idehs_AspNetUsers_UserId",
                table: "P_Idehs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_P_Idehs_Industries_IndustryId",
                table: "P_Idehs",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_P_Incompleteds_AspNetUsers_UserId",
                table: "P_Incompleteds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_P_Incompleteds_Industries_IndustryId",
                table: "P_Incompleteds",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id");
        }
    }
}
