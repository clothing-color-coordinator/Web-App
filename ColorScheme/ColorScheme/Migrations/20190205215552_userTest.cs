using Microsoft.EntityFrameworkCore.Migrations;

namespace ColorScheme.Migrations
{
    public partial class userTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserMID",
                table: "colorScheme",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_colorScheme_UserMID",
                table: "colorScheme",
                column: "UserMID");

            migrationBuilder.AddForeignKey(
                name: "FK_colorScheme_User_UserMID",
                table: "colorScheme",
                column: "UserMID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_colorScheme_User_UserMID",
                table: "colorScheme");

            migrationBuilder.DropIndex(
                name: "IX_colorScheme_UserMID",
                table: "colorScheme");

            migrationBuilder.DropColumn(
                name: "UserMID",
                table: "colorScheme");
        }
    }
}
