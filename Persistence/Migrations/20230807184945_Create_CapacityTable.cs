using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_CapacityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CapacityRelProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    NominalCapacity = table.Column<int>(type: "int", nullable: false),
                    ActualOperatingCapacity = table.Column<int>(type: "int", nullable: false),
                    ShiftWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesiredOperationalCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastYearSale = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityRelProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapacityRelProjects_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapacityRelProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapacityRelProjects_ProductTypeId",
                table: "CapacityRelProjects",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CapacityRelProjects_ProjectId",
                table: "CapacityRelProjects",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapacityRelProjects");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
