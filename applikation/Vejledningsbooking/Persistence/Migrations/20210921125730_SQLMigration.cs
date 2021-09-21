using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejledningsbooking.Persistence.Migrations
{
    public partial class SQLMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hold",
                columns: table => new
                {
                    HoldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hold", x => x.HoldId);
                });

            migrationBuilder.CreateTable(
                name: "Studerende",
                columns: table => new
                {
                    StuderendeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studerende", x => x.StuderendeId);
                });

            migrationBuilder.CreateTable(
                name: "Underviser",
                columns: table => new
                {
                    UnderviserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Underviser", x => x.UnderviserId);
                });

            migrationBuilder.CreateTable(
                name: "Kalender",
                columns: table => new
                {
                    UnderviserId = table.Column<int>(type: "int", nullable: false),
                    HoldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalender", x => new { x.UnderviserId, x.HoldId });
                    table.ForeignKey(
                        name: "FK_Kalender_Hold_HoldId",
                        column: x => x.HoldId,
                        principalTable: "Hold",
                        principalColumn: "HoldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kalender_Underviser_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Underviser",
                        principalColumn: "UnderviserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingVindue",
                columns: table => new
                {
                    BookingVindueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KalenderUnderviserId = table.Column<int>(type: "int", nullable: true),
                    KalenderHoldId = table.Column<int>(type: "int", nullable: true),
                    UnderviserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingVindue", x => x.BookingVindueId);
                    table.ForeignKey(
                        name: "FK_BookingVindue_Kalender_KalenderUnderviserId_KalenderHoldId",
                        columns: x => new { x.KalenderUnderviserId, x.KalenderHoldId },
                        principalTable: "Kalender",
                        principalColumns: new[] { "UnderviserId", "HoldId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingVindue_Underviser_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Underviser",
                        principalColumn: "UnderviserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingVindueId = table.Column<int>(type: "int", nullable: true),
                    StuderendeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_BookingVindue_BookingVindueId",
                        column: x => x.BookingVindueId,
                        principalTable: "BookingVindue",
                        principalColumn: "BookingVindueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Studerende_StuderendeId",
                        column: x => x.StuderendeId,
                        principalTable: "Studerende",
                        principalColumn: "StuderendeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingVindueId",
                table: "Booking",
                column: "BookingVindueId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_StuderendeId",
                table: "Booking",
                column: "StuderendeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingVindue_KalenderUnderviserId_KalenderHoldId",
                table: "BookingVindue",
                columns: new[] { "KalenderUnderviserId", "KalenderHoldId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingVindue_UnderviserId",
                table: "BookingVindue",
                column: "UnderviserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kalender_HoldId",
                table: "Kalender",
                column: "HoldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "BookingVindue");

            migrationBuilder.DropTable(
                name: "Studerende");

            migrationBuilder.DropTable(
                name: "Kalender");

            migrationBuilder.DropTable(
                name: "Hold");

            migrationBuilder.DropTable(
                name: "Underviser");
        }
    }
}
