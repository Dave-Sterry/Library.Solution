using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AuthorBookForTheLastTimeAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AuthorBooks_AuthorBookId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AuthorBooks_AuthorBookId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorBookId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_AuthorBookId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AuthorBookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorBookId",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorBookId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorBookId",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorBookId",
                table: "Books",
                column: "AuthorBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorBookId",
                table: "Authors",
                column: "AuthorBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AuthorBooks_AuthorBookId",
                table: "Authors",
                column: "AuthorBookId",
                principalTable: "AuthorBooks",
                principalColumn: "AuthorBookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AuthorBooks_AuthorBookId",
                table: "Books",
                column: "AuthorBookId",
                principalTable: "AuthorBooks",
                principalColumn: "AuthorBookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
