using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Recorect_Rel_In_Address_and_project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_P_Incompleteds_Addresses_AddressId",
                table: "P_Incompleteds");

            migrationBuilder.DropIndex(
                name: "IX_P_Incompleteds_AddressId",
                table: "P_Incompleteds");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "P_Incompleteds");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Addresses",
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
                name: "IX_Addresses_ProjectId",
                table: "Addresses",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_P_Incompleteds_ProjectId",
                table: "Addresses",
                column: "ProjectId",
                principalTable: "P_Incompleteds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_P_Incompleteds_ProjectId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ProjectId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "P_Incompleteds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_P_Incompleteds_AddressId",
                table: "P_Incompleteds",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_P_Incompleteds_Addresses_AddressId",
                table: "P_Incompleteds",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
