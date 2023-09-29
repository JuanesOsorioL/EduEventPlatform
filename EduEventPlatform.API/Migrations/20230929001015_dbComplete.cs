using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduEventPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class dbComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EventTheme = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventsSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SessionTopic = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameParticipant = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstitutionalAffiliation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AreaInterest = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeParticipation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicEvents_EventName",
                table: "AcademicEvents",
                column: "EventName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventsSchedule_SessionName",
                table: "EventsSchedule",
                column: "SessionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_NameParticipant",
                table: "Participants",
                column: "NameParticipant",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicEvents");

            migrationBuilder.DropTable(
                name: "EventsSchedule");

            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}
