using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_relation_between_project_and_ideh_and_imcompleted_and_projectTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_ProjectId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Idehs_ProjectId",
                table: "P_Idehs");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_ProjectId",
                table: "P_Incompleteds",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_P_Idehs_ProjectId",
                table: "P_Idehs",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_ProjectId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Idehs_ProjectId",
                table: "P_Idehs");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_ProjectId",
                table: "P_Incompleteds",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Idehs_ProjectId",
                table: "P_Idehs",
                column: "ProjectId");
        }
    }
}
