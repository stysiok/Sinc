using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinc.Storage.Migrations
{
    public partial class UpdateRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_StoredPlaylistId",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "StoredPlaylistId",
                table: "Songs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_StoredPlaylistId",
                table: "Songs",
                column: "StoredPlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_StoredPlaylistId",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "StoredPlaylistId",
                table: "Songs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_StoredPlaylistId",
                table: "Songs",
                column: "StoredPlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
