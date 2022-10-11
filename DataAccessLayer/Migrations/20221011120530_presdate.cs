using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class presdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionDates = table.Column<DateTime>(nullable: false),
                    PatientPhoneNumber = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresDates");
        }
    }
}
