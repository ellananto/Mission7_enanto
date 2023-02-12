using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_responses_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Action" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Romance" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Horror" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Mystery" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 6, "Thriller" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "RentalID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Christopher Nolan", false, null, "My favorite movie!", "PG-13", "Inception", "2010" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "RentalID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 2, "Kevin Feige", false, null, "Avengers are the best!", "PG-13", "Age of Ultron", "2015" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "RentalID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 3, "Disney", false, null, "The best ending!", "PG", "High School Musical 3: Senior Year", "2008" });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryID",
                table: "responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
