using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.RentalID);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "RentalID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Suspense", "Christopher Nolan", false, null, "My favorite movie!", "PG-13", "Inception", "2010" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "RentalID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Action", "Kevin Feige", false, null, "Avengers are the best!", "PG-13", "Age of Ultron", "2015" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "RentalID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Musical", "Disney", false, null, "The best ending!", "PG", "High School Musical 3: Senior Year", "2008" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
