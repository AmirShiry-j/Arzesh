using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify_CapacityRelProject_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapacityRelProjects_ProductTypes_ProductTypeId",
                table: "CapacityRelProjects");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_CapacityRelProjects_ProductTypeId",
                table: "CapacityRelProjects");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "CapacityRelProjects");

            migrationBuilder.AddColumn<string>(
                name: "ProductTypeName",
                table: "CapacityRelProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTypeName",
                table: "CapacityRelProjects");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "CapacityRelProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapacityRelProjects_ProductTypeId",
                table: "CapacityRelProjects",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CapacityRelProjects_ProductTypes_ProductTypeId",
                table: "CapacityRelProjects",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
