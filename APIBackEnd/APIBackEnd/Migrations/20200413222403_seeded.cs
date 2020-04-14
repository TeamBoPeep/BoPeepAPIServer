using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBackEnd.Migrations
{
    public partial class seeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ID", "Description", "ExternalLink", "Location", "Rate", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "A nice stroll outside to enjoy nature and fresh air", "N/A", 0, 1, 4.5, "Hike/trails" },
                    { 2, "A chance to enjoy nature without movement, also good to enjoy with your cat", "N/A", 0, 1, 4.5, "Bird watching" },
                    { 3, "Better than a hike! You've got compan to help you stop and smell the roses", "N/A", 0, 1, 4.5, "Dog/cat walking" },
                    { 4, "grow veggies, flowers and fruit", "N/A", 0, 1, 4.5, "Gardening" },
                    { 5, "Get a nice bite to eat, for free!", "N/A", 0, 1, 4.5, "Dumpster Diving" },
                    { 6, "Time to slay dragons and drink mead", "N/A", 0, 1, 4.5, "Games" },
                    { 7, "Blood pumping and brain working", "N/A", 0, 1, 4.5, "Exercise" },
                    { 8, "Art, cooking or C#, the options are endless", "N/A", 0, 1, 4.5, "Learning" },
                    { 9, "Aloe, succulents and anything else your cat won't eat", "N/A", 0, 1, 4.5, "Terrariums" },
                    { 10, "be social while social distancing", "N/A", 0, 1, 4.5, "Facetime/video calls" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: 10);
        }
    }
}
