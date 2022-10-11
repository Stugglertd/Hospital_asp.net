using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class presdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresDates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientPhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrescriptionDates = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresDates_patients_PatientPhoneNumber",
                        column: x => x.PatientPhoneNumber,
                        principalTable: "patients",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresDates_PatientPhoneNumber",
                table: "PresDates",
                column: "PatientPhoneNumber");
        }
    }
}
