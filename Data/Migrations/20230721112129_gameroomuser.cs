using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class gameroomuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "gameRoomUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_gameRoomUsers_gameRoomId",
                table: "gameRoomUsers",
                column: "gameRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_gameRoomUsers_userId1",
                table: "gameRoomUsers",
                column: "userId1");

            migrationBuilder.AddForeignKey(
                name: "FK_gameRoomUsers_AspNetUsers_userId1",
                table: "gameRoomUsers",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_gameRoomUsers_gameRooms_gameRoomId",
                table: "gameRoomUsers",
                column: "gameRoomId",
                principalTable: "gameRooms",
                principalColumn: "gameRoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gameRoomUsers_AspNetUsers_userId1",
                table: "gameRoomUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_gameRoomUsers_gameRooms_gameRoomId",
                table: "gameRoomUsers");

            migrationBuilder.DropIndex(
                name: "IX_gameRoomUsers_gameRoomId",
                table: "gameRoomUsers");

            migrationBuilder.DropIndex(
                name: "IX_gameRoomUsers_userId1",
                table: "gameRoomUsers");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "gameRoomUsers");
        }
    }
}
