using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejledningsbooking.Persistence.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hold", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studerende",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studerende", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Underviser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Underviser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kalender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnderviserId = table.Column<int>(type: "int", nullable: true),
                    HoldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kalender_Hold_HoldId",
                        column: x => x.HoldId,
                        principalTable: "Hold",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kalender_Underviser_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Underviser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingVindue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnderviserId = table.Column<int>(type: "int", nullable: true),
                    KalenderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingVindue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingVindue_Kalender_KalenderId",
                        column: x => x.KalenderId,
                        principalTable: "Kalender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingVindue_Underviser_UnderviserId",
                        column: x => x.UnderviserId,
                        principalTable: "Underviser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutTidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    StuderendeId = table.Column<int>(type: "int", nullable: true),
                    BookingVindueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_BookingVindue_BookingVindueId",
                        column: x => x.BookingVindueId,
                        principalTable: "BookingVindue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Studerende_StuderendeId",
                        column: x => x.StuderendeId,
                        principalTable: "Studerende",
                        principalColumn: "Id",
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
                name: "IX_BookingVindue_KalenderId",
                table: "BookingVindue",
                column: "KalenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingVindue_UnderviserId",
                table: "BookingVindue",
                column: "UnderviserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kalender_HoldId",
                table: "Kalender",
                column: "HoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Kalender_UnderviserId",
                table: "Kalender",
                column: "UnderviserId");
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
