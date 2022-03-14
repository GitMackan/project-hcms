using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_hcms.Migrations
{
    public partial class addedUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "MainCourses",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "MainCourses");
        }
    }
}
