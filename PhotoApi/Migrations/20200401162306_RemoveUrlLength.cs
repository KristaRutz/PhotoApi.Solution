using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoAPI.Solution.Migrations
{
    public partial class RemoveUrlLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Photos",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Photos",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
