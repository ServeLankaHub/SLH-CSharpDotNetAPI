using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serveSLhub.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_familyMembers_personDetails_PesronID",
                table: "familyMembers");

            migrationBuilder.AlterColumn<int>(
                name: "PesronID",
                table: "familyMembers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonDetailsPersonId",
                table: "familyMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_familyMembers_PersonDetailsPersonId",
                table: "familyMembers",
                column: "PersonDetailsPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_familyMembers_personDetails_PersonDetailsPersonId",
                table: "familyMembers",
                column: "PersonDetailsPersonId",
                principalTable: "personDetails",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_familyMembers_personDetails_PersonDetailsPersonId",
                table: "familyMembers");

            migrationBuilder.DropIndex(
                name: "IX_familyMembers_PersonDetailsPersonId",
                table: "familyMembers");

            migrationBuilder.DropColumn(
                name: "PersonDetailsPersonId",
                table: "familyMembers");

            migrationBuilder.AlterColumn<int>(
                name: "PesronID",
                table: "familyMembers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_familyMembers_personDetails_PesronID",
                table: "familyMembers",
                column: "PesronID",
                principalTable: "personDetails",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
