using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBackEnd.Migrations
{
    public partial class changedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Activities",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Better than a hike! You've got companion to help you stop and smell the roses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Better than a hike! You've got compan to help you stop and smell the roses");
        }
    }
}
