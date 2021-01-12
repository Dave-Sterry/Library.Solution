using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AuthorBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorBookId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorBookId",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorBookId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => x.AuthorBookId);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorBookId",
                table: "Books",
                column: "AuthorBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorBookId",
                table: "Authors",
                column: "AuthorBookId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AuthorBooks_AuthorBookId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AuthorBooks_AuthorBookId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

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
    }
}
