using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class gamefeeld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gameFeeldUsers_gameRooms_roomgameRoomId",
                table: "gameFeeldUsers");

            migrationBuilder.DropIndex(
                name: "IX_gameFeeldUsers_roomgameRoomId",
                table: "gameFeeldUsers");

            migrationBuilder.RenameColumn(
                name: "roomgameRoomId",
                table: "gameFeeldUsers",
                newName: "userId");

            migrationBuilder.AddColumn<int>(
                name: "gameRoomId",
                table: "gameFeeldUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "gameFeeldUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_gameFeeldUsers_gameRoomId",
                table: "gameFeeldUsers",
                column: "gameRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_gameFeeldUsers_userId1",
                table: "gameFeeldUsers",
                column: "userId1");

            migrationBuilder.AddForeignKey(
                name: "FK_gameFeeldUsers_AspNetUsers_userId1",
                table: "gameFeeldUsers",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_gameFeeldUsers_gameRooms_gameRoomId",
                table: "gameFeeldUsers",
                column: "gameRoomId",
                principalTable: "gameRooms",
                principalColumn: "gameRoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gameFeeldUsers_AspNetUsers_userId1",
                table: "gameFeeldUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_gameFeeldUsers_gameRooms_gameRoomId",
                table: "gameFeeldUsers");

            migrationBuilder.DropIndex(
                name: "IX_gameFeeldUsers_gameRoomId",
                table: "gameFeeldUsers");

            migrationBuilder.DropIndex(
                name: "IX_gameFeeldUsers_userId1",
                table: "gameFeeldUsers");

            migrationBuilder.DropColumn(
                name: "gameRoomId",
                table: "gameFeeldUsers");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "gameFeeldUsers");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "gameFeeldUsers",
                newName: "roomgameRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_gameFeeldUsers_roomgameRoomId",
                table: "gameFeeldUsers",
                column: "roomgameRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_gameFeeldUsers_gameRooms_roomgameRoomId",
                table: "gameFeeldUsers",
                column: "roomgameRoomId",
                principalTable: "gameRooms",
                principalColumn: "gameRoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
