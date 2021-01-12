using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AuthorBookContinuingBugSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Authors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Authors");
        }
    }
}
