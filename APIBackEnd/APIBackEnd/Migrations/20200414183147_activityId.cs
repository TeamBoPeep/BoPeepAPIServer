using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBackEnd.Migrations
{
    public partial class activityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Activities_ActivitiesID",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ActivitiesID",
                table: "Reviews",
                newName: "ActivitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ActivitiesID",
                table: "Reviews",
                newName: "IX_Reviews_ActivitiesId");

            migrationBuilder.AlterColumn<int>(
                name: "ActivitiesId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 2,
                column: "Location",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Activities_ActivitiesId",
                table: "Reviews",
                column: "ActivitiesId",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Activities_ActivitiesId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ActivitiesId",
                table: "Reviews",
                newName: "ActivitiesID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ActivitiesId",
                table: "Reviews",
                newName: "IX_Reviews_ActivitiesID");

            migrationBuilder.AlterColumn<int>(
                name: "ActivitiesID",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 2,
                column: "Location",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Activities_ActivitiesID",
                table: "Reviews",
                column: "ActivitiesID",
                principalTable: "Activities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
