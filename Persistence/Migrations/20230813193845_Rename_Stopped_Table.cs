using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Stopped_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_Stoppeds_InactivityReasons_InactivityReasonId",
                table: "project_Stoppeds");

            migrationBuilder.DropForeignKey(
                name: "FK_project_Stoppeds_Projects_ProjectId",
                table: "project_Stoppeds");

            migrationBuilder.DropForeignKey(
                name: "FK_project_Stoppeds_RentTypes_RentTypeId",
                table: "project_Stoppeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_project_Stoppeds",
                table: "project_Stoppeds");

            migrationBuilder.RenameTable(
                name: "project_Stoppeds",
                newName: "P_Stoppeds");

            migrationBuilder.RenameIndex(
                name: "IX_project_Stoppeds_RentTypeId",
                table: "P_Stoppeds",
                newName: "IX_P_Stoppeds_RentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_project_Stoppeds_ProjectId",
                table: "P_Stoppeds",
                newName: "IX_P_Stoppeds_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_project_Stoppeds_InactivityReasonId",
                table: "P_Stoppeds",
                newName: "IX_P_Stoppeds_InactivityReasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_P_Stoppeds",
                table: "P_Stoppeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_P_Stoppeds_InactivityReasons_InactivityReasonId",
                table: "P_Stoppeds",
                column: "InactivityReasonId",
                principalTable: "InactivityReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_P_Stoppeds_Projects_ProjectId",
                table: "P_Stoppeds",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_P_Stoppeds_RentTypes_RentTypeId",
                table: "P_Stoppeds",
                column: "RentTypeId",
                principalTable: "RentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_P_Stoppeds_InactivityReasons_InactivityReasonId",
                table: "P_Stoppeds");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Stoppeds_Projects_ProjectId",
                table: "P_Stoppeds");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Stoppeds_RentTypes_RentTypeId",
                table: "P_Stoppeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_P_Stoppeds",
                table: "P_Stoppeds");

            migrationBuilder.RenameTable(
                name: "P_Stoppeds",
                newName: "project_Stoppeds");

            migrationBuilder.RenameIndex(
                name: "IX_P_Stoppeds_RentTypeId",
                table: "project_Stoppeds",
                newName: "IX_project_Stoppeds_RentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_P_Stoppeds_ProjectId",
                table: "project_Stoppeds",
                newName: "IX_project_Stoppeds_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_P_Stoppeds_InactivityReasonId",
                table: "project_Stoppeds",
                newName: "IX_project_Stoppeds_InactivityReasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_project_Stoppeds",
                table: "project_Stoppeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_project_Stoppeds_InactivityReasons_InactivityReasonId",
                table: "project_Stoppeds",
                column: "InactivityReasonId",
                principalTable: "InactivityReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_project_Stoppeds_Projects_ProjectId",
                table: "project_Stoppeds",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_project_Stoppeds_RentTypes_RentTypeId",
                table: "project_Stoppeds",
                column: "RentTypeId",
                principalTable: "RentTypes",
                principalColumn: "Id");
        }
    }
}
