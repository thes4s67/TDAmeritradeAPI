using Microsoft.EntityFrameworkCore.Migrations;

namespace TDAmeritradeAPI.WebExample.Data.Migrations
{
    public partial class AddAcessTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    access_token = table.Column<string>(nullable: true),
                    refresh_token = table.Column<string>(nullable: true),
                    token_type = table.Column<string>(nullable: true),
                    expires_in = table.Column<int>(nullable: false),
                    scope = table.Column<string>(nullable: true),
                    refresh_token_expires_in = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessToken", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken");
        }
    }
}
