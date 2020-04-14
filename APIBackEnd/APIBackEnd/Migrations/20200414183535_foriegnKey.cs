using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBackEnd.Migrations
{
    public partial class foriegnKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ActivitiesId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "ActivitiesId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ActivitiesId",
                table: "Reviews",
                column: "ActivitiesId");
        }
    }
}
