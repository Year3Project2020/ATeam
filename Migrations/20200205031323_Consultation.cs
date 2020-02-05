using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yearthreeproject.Migrations
{
    public partial class Consultation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NextAppointment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    PatientID = table.Column<string>(nullable: false),
                    ConsultationID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => new { x.PatientID, x.ConsultationID });
                    table.ForeignKey(
                        name: "FK_Consultation_Doctors_ConsultationID",
                        column: x => x.ConsultationID,
                        principalTable: "Doctors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultation_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_ConsultationID",
                table: "Consultation",
                column: "ConsultationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
