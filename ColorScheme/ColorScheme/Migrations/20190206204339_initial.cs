using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ColorScheme.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "colorScheme",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserMID = table.Column<int>(nullable: false),
                    SchemeType = table.Column<string>(nullable: true),
                    ColorSearched = table.Column<string>(nullable: true),
                    ColorSearchedHex = table.Column<string>(nullable: true),
                    ColorReceived = table.Column<string>(nullable: true),
                    ColorReceivedHex = table.Column<string>(nullable: true),
                    ColorReceivedTwo = table.Column<string>(nullable: true),
                    ColorReceivedHexTwo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colorScheme", x => x.ID);
                    table.ForeignKey(
                        name: "FK_colorScheme_User_UserMID",
                        column: x => x.UserMID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_colorScheme_UserMID",
                table: "colorScheme",
                column: "UserMID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colorScheme");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
