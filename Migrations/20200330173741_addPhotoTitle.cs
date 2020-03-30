using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoAPI.Solution.Migrations
{
    public partial class addPhotoTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Photos");
        }
    }
}
