using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsApp.Migrations
{
    public partial class updateStudentsdbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletionDescription",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletionDescription",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Students");
        }
    }
}
