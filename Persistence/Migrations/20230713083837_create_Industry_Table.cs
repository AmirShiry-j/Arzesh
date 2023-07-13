using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class create_Industry_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "P_Incompleteds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "P_Idehs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_IndustryId",
                table: "P_Incompleteds",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_P_Idehs_IndustryId",
                table: "P_Idehs",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_P_Idehs_Industries_IndustryId",
                table: "P_Idehs",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_P_Incompleteds_Industries_IndustryId",
                table: "P_Incompleteds",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_P_Idehs_Industries_IndustryId",
                table: "P_Idehs");

            migrationBuilder.DropForeignKey(
                name: "FK_P_Incompleteds_Industries_IndustryId",
                table: "P_Incompleteds");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_IndustryId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Idehs_IndustryId",
                table: "P_Idehs");

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "P_Incompleteds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "P_Idehs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
