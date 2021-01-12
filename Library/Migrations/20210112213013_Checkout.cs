using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Checkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "BookLibraries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookLibraryId = table.Column<int>(nullable: false),
                    PatronId = table.Column<int>(nullable: false),
                    CheckoutDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.CheckoutId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLibraries_CheckoutId",
                table: "BookLibraries",
                column: "CheckoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLibraries_Checkouts_CheckoutId",
                table: "BookLibraries",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "CheckoutId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLibraries_Checkouts_CheckoutId",
                table: "BookLibraries");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_BookLibraries_CheckoutId",
                table: "BookLibraries");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "BookLibraries");
        }
    }
}
