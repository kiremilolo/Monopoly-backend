using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class gameroom_createdandwinner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "createdUserId",
                table: "gameRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "createdUserId1",
                table: "gameRooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "winnerUserId",
                table: "gameRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "winnerUserId1",
                table: "gameRooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_gameRooms_createdUserId1",
                table: "gameRooms",
                column: "createdUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_gameRooms_winnerUserId1",
                table: "gameRooms",
                column: "winnerUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_gameRooms_AspNetUsers_createdUserId1",
                table: "gameRooms",
                column: "createdUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_gameRooms_AspNetUsers_winnerUserId1",
                table: "gameRooms",
                column: "winnerUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gameRooms_AspNetUsers_createdUserId1",
                table: "gameRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_gameRooms_AspNetUsers_winnerUserId1",
                table: "gameRooms");

            migrationBuilder.DropIndex(
                name: "IX_gameRooms_createdUserId1",
                table: "gameRooms");

            migrationBuilder.DropIndex(
                name: "IX_gameRooms_winnerUserId1",
                table: "gameRooms");

            migrationBuilder.DropColumn(
                name: "createdUserId",
                table: "gameRooms");

            migrationBuilder.DropColumn(
                name: "createdUserId1",
                table: "gameRooms");

            migrationBuilder.DropColumn(
                name: "winnerUserId",
                table: "gameRooms");

            migrationBuilder.DropColumn(
                name: "winnerUserId1",
                table: "gameRooms");
        }
    }
}
