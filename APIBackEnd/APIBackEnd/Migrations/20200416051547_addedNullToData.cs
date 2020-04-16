using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBackEnd.Migrations
{
    public partial class addedNullToData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ExternalLink", "ImageUrl" },
                values: new object[] { "https://www.wta.org/?gclid=CjwKCAjwvtX0BRAFEiwAGWJyZJMy_TIYVTxTlNY1u8DtYnwh-hfOyaf4tLByYfEdTrqNR2JbN8hk5xoC2-4QAvD_BwE", "https://photos.app.goo.gl/VwiATQcEmoGkmjNb9" });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ExternalLink", "ImageUrl" },
                values: new object[] { "https://www.seattleaudubon.org/sas/getinvolved/gobirding.aspx", "https://photos.app.goo.gl/KKhASik7AVioTz9r9" });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://photos.app.goo.gl/xoRc7LsaQn9JXEfA9");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://photos.app.goo.gl/cknW2GGkCC9hKNwx6");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://photos.app.goo.gl/kmLEkS6xmE3q6VSr5");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://photos.app.goo.gl/c1145jDRGZJChSkT8");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://photos.app.goo.gl/fExYrBfPvsroKzfs6");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://photos.app.goo.gl/FENqHw19himsaDEZ9");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "ExternalLink", "ImageUrl" },
                values: new object[] { "http://serpadesign.com/", "https://photos.app.goo.gl/hTKgacuUNjegWq2u9" });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://photos.app.goo.gl/cQYoMM3UHax4i9g2A");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ExternalLink", "ImageUrl" },
                values: new object[] { "N/A", null });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ExternalLink", "ImageUrl" },
                values: new object[] { "N/A", null });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "ExternalLink", "ImageUrl" },
                values: new object[] { "N/A", null });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageUrl",
                value: null);
        }
    }
}
