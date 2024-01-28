using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serveSLhub.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gN_Divisions_AspNetUsers_UserId",
                table: "gN_Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_personDetails_AspNetUsers_ID",
                table: "personDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_personDetails_gN_Divisions_DivisionID",
                table: "personDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_personDetails_gN_Divisions_GN_DivisionDivisionID",
                table: "personDetails");

            migrationBuilder.DropIndex(
                name: "IX_personDetails_GN_DivisionDivisionID",
                table: "personDetails");

            migrationBuilder.DropIndex(
                name: "IX_personDetails_ID",
                table: "personDetails");

            migrationBuilder.DropIndex(
                name: "IX_gN_Divisions_UserId",
                table: "gN_Divisions");

            migrationBuilder.DropColumn(
                name: "GN_DivisionDivisionID",
                table: "personDetails");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "personDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "gN_Divisions",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_gN_Divisions_Id",
                table: "gN_Divisions",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_gN_Divisions_AspNetUsers_Id",
                table: "gN_Divisions",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personDetails_gN_Divisions_DivisionID",
                table: "personDetails",
                column: "DivisionID",
                principalTable: "gN_Divisions",
                principalColumn: "DivisionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gN_Divisions_AspNetUsers_Id",
                table: "gN_Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_personDetails_gN_Divisions_DivisionID",
                table: "personDetails");

            migrationBuilder.DropIndex(
                name: "IX_gN_Divisions_Id",
                table: "gN_Divisions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "gN_Divisions",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "GN_DivisionDivisionID",
                table: "personDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "personDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_personDetails_GN_DivisionDivisionID",
                table: "personDetails",
                column: "GN_DivisionDivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_personDetails_ID",
                table: "personDetails",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_gN_Divisions_UserId",
                table: "gN_Divisions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_gN_Divisions_AspNetUsers_UserId",
                table: "gN_Divisions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personDetails_AspNetUsers_ID",
                table: "personDetails",
                column: "ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personDetails_gN_Divisions_DivisionID",
                table: "personDetails",
                column: "DivisionID",
                principalTable: "gN_Divisions",
                principalColumn: "DivisionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personDetails_gN_Divisions_GN_DivisionDivisionID",
                table: "personDetails",
                column: "GN_DivisionDivisionID",
                principalTable: "gN_Divisions",
                principalColumn: "DivisionID");
        }
    }
}
