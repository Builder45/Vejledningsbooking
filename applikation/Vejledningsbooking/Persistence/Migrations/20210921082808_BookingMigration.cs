using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejledningsbooking.Persistence.Migrations
{
    public partial class BookingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hold",
                columns: table => new
                {
                    HoldId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hold", x => x.HoldId);
                });

            migrationBuilder.CreateTable(
                name: "Studerende",
                columns: table => new
                {
                    StuderendeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studerende", x => x.StuderendeId);
                });

            migrationBuilder.CreateTable(
                name: "Undervisere",
                columns: table => new
                {
                    UnderviserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Undervisere", x => x.UnderviserId);
                });

            migrationBuilder.CreateTable(
                name: "Kalendere",
                columns: table => new
                {
                    UnderviserId = table.Column<int>(type: "INTEGER", nullable: false),
                    HoldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalendere", x => new { x.UnderviserId, x.HoldId });
                    table.ForeignKey(
                        name: "FK_Kalendere_Hold_HoldId",
                        column: x => x.HoldId,
                        principalTable: "Hold",
                        principalColumn: "HoldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kalendere_Undervisere_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Undervisere",
                        principalColumn: "UnderviserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingVinduer",
                columns: table => new
                {
                    BookingVindueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTidspunkt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SlutTidspunkt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KalenderId = table.Column<int>(type: "INTEGER", nullable: true),
                    KalenderUnderviserId = table.Column<int>(type: "INTEGER", nullable: true),
                    KalenderHoldId = table.Column<int>(type: "INTEGER", nullable: true),
                    UnderviserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingVinduer", x => x.BookingVindueId);
                    table.ForeignKey(
                        name: "FK_BookingVinduer_Kalendere_KalenderUnderviserId_KalenderHoldId",
                        columns: x => new { x.KalenderUnderviserId, x.KalenderHoldId },
                        principalTable: "Kalendere",
                        principalColumns: new[] { "UnderviserId", "HoldId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingVinduer_Undervisere_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Undervisere",
                        principalColumn: "UnderviserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookinger",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTidspunkt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SlutTidspunkt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookingVindueId = table.Column<int>(type: "INTEGER", nullable: true),
                    StuderendeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookinger", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookinger_BookingVinduer_BookingVindueId",
                        column: x => x.BookingVindueId,
                        principalTable: "BookingVinduer",
                        principalColumn: "BookingVindueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookinger_Studerende_StuderendeId",
                        column: x => x.StuderendeId,
                        principalTable: "Studerende",
                        principalColumn: "StuderendeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_BookingVindueId",
                table: "Bookinger",
                column: "BookingVindueId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_StuderendeId",
                table: "Bookinger",
                column: "StuderendeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingVinduer_KalenderUnderviserId_KalenderHoldId",
                table: "BookingVinduer",
                columns: new[] { "KalenderUnderviserId", "KalenderHoldId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingVinduer_UnderviserId",
                table: "BookingVinduer",
                column: "UnderviserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kalendere_HoldId",
                table: "Kalendere",
                column: "HoldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookinger");

            migrationBuilder.DropTable(
                name: "BookingVinduer");

            migrationBuilder.DropTable(
                name: "Studerende");

            migrationBuilder.DropTable(
                name: "Kalendere");

            migrationBuilder.DropTable(
                name: "Hold");

            migrationBuilder.DropTable(
                name: "Undervisere");
        }
    }
}
