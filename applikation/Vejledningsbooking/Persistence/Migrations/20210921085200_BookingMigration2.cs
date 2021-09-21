using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejledningsbooking.Persistence.Migrations
{
    public partial class BookingMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KalenderId",
                table: "BookingVinduer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KalenderId",
                table: "BookingVinduer",
                type: "INTEGER",
                nullable: true);
        }
    }
}
