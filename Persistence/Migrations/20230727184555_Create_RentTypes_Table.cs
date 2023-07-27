using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_RentTypes_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentTypeId",
                table: "P_Incompleteds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_RentTypeId",
                table: "P_Incompleteds",
                column: "RentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_P_Incompleteds_RentTypes_RentTypeId",
                table: "P_Incompleteds",
                column: "RentTypeId",
                principalTable: "RentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_P_Incompleteds_RentTypes_RentTypeId",
                table: "P_Incompleteds");

            migrationBuilder.DropTable(
                name: "RentTypes");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_RentTypeId",
                table: "P_Incompleteds");

            migrationBuilder.DropColumn(
                name: "RentTypeId",
                table: "P_Incompleteds");
        }
    }
}
