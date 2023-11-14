using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomBookingApi.Migrations
{
    public partial class roomsupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Rooms",
                newName: "AvalaibleRooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvalaibleRooms",
                table: "Rooms",
                newName: "RoomNumber");

            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
