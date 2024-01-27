using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serveSLhub.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "families",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number_of_Members = table.Column<int>(type: "int", nullable: false),
                    Income_Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_families", x => x.FamilyId);
                });

           

            migrationBuilder.CreateTable(
                name: "familyMembers",
                columns: table => new
                {
                    PesronID = table.Column<int>(type: "int", nullable: false),
                    FamilyID = table.Column<int>(type: "int", nullable: false),
                    Family_Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ishead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familyMembers", x => x.PesronID);
                    table.ForeignKey(
                        name: "FK_familyMembers_families_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_familyMembers_personDetails_PesronID",
                        column: x => x.PesronID,
                        principalTable: "personDetails",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

           
           

            migrationBuilder.CreateIndex(
                name: "IX_familyMembers_FamilyID",
                table: "familyMembers",
                column: "FamilyID");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "familyMembers");


            migrationBuilder.DropTable(
                name: "families");

           
        }
    }
}
