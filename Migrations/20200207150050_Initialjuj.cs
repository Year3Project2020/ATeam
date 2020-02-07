using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yearthreeproject.Migrations
{
    public partial class Initialjuj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Patient = table.Column<string>(nullable: true),
                    DateOfVisit = table.Column<DateTime>(nullable: false),
                    Illness = table.Column<string>(nullable: true),
                    MedicationGiven = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
