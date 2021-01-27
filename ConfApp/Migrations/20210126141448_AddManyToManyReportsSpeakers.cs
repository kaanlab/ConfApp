using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfApp.Migrations
{
    public partial class AddManyToManyReportsSpeakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Reports_ReportId",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_ReportId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Speakers");

            migrationBuilder.CreateTable(
                name: "ReportSpeaker",
                columns: table => new
                {
                    ReportsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeakersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSpeaker", x => new { x.ReportsId, x.SpeakersId });
                    table.ForeignKey(
                        name: "FK_ReportSpeaker_Reports_ReportsId",
                        column: x => x.ReportsId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSpeaker_Speakers_SpeakersId",
                        column: x => x.SpeakersId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportSpeaker_SpeakersId",
                table: "ReportSpeaker",
                column: "SpeakersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportSpeaker");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Speakers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ReportId",
                table: "Speakers",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Reports_ReportId",
                table: "Speakers",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
