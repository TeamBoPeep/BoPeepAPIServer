using Microsoft.EntityFrameworkCore.Migrations;

namespace APIBackEnd.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    ExternalLink = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesReviews",
                columns: table => new
                {
                    ActivitiesID = table.Column<int>(nullable: false),
                    ReviewsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesReviews", x => new { x.ReviewsID, x.ActivitiesID });
                    table.ForeignKey(
                        name: "FK_ActivitiesReviews_Activities_ActivitiesID",
                        column: x => x.ActivitiesID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesReviews_Reviews_ReviewsID",
                        column: x => x.ReviewsID,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagActivity",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagActivity", x => new { x.ActivitiesId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagActivity_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagActivity_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ID", "Description", "ExternalLink", "ImageUrl", "Location", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "A nice stroll outside to enjoy nature and fresh air", "https://www.wta.org/?gclid=CjwKCAjwvtX0BRAFEiwAGWJyZJMy_TIYVTxTlNY1u8DtYnwh-hfOyaf4tLByYfEdTrqNR2JbN8hk5xoC2-4QAvD_BwE", "https://photos.app.goo.gl/VwiATQcEmoGkmjNb9", 0, 4.5, "Hike/trails" },
                    { 9, "Aloe, succulents and anything else your cat won't eat", "http://serpadesign.com/", "https://photos.app.goo.gl/hTKgacuUNjegWq2u9", 0, 4.5, "Terrariums" },
                    { 8, "Art, cooking or C#, the options are endless", "N/A", "https://photos.app.goo.gl/FENqHw19himsaDEZ9", 0, 4.5, "Learning" },
                    { 7, "Blood pumping and brain working", "N/A", "https://photos.app.goo.gl/fExYrBfPvsroKzfs6", 0, 4.5, "Exercise" },
                    { 6, "Time to slay dragons and drink mead", "N/A", "https://photos.app.goo.gl/c1145jDRGZJChSkT8", 0, 4.5, "Games" },
                    { 10, "be social while social distancing", "N/A", "https://photos.app.goo.gl/cQYoMM3UHax4i9g2A", 0, 4.5, "Facetime/video calls" },
                    { 4, "grow veggies, flowers and fruit", "N/A", "https://photos.app.goo.gl/cknW2GGkCC9hKNwx6", 0, 4.5, "Gardening" },
                    { 3, "Better than a hike! You've got companion to help you stop and smell the roses", "N/A", "https://photos.app.goo.gl/xoRc7LsaQn9JXEfA9", 0, 4.5, "Dog/cat walking" },
                    { 2, "A chance to enjoy nature without movement, also good to enjoy with your cat", "https://www.seattleaudubon.org/sas/getinvolved/gobirding.aspx", "https://photos.app.goo.gl/KKhASik7AVioTz9r9", 1, 4.5, "Bird watching" },
                    { 5, "Get a nice bite to eat, for free!", "N/A", "https://photos.app.goo.gl/kmLEkS6xmE3q6VSr5", 0, 4.5, "Dumpster Diving" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "ID", "Names" },
                values: new object[,]
                {
                    { 9, "Productive" },
                    { 1, "Flora/fauna" },
                    { 2, "Exercise" },
                    { 3, "Games" },
                    { 4, "Social" },
                    { 5, "Pets" },
                    { 6, "Arts&Crafts" },
                    { 7, "Self care" },
                    { 8, "Online" },
                    { 10, "Baking/Cooking" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesReviews_ActivitiesID",
                table: "ActivitiesReviews",
                column: "ActivitiesID");

            migrationBuilder.CreateIndex(
                name: "IX_TagActivity_TagId",
                table: "TagActivity",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesReviews");

            migrationBuilder.DropTable(
                name: "TagActivity");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
