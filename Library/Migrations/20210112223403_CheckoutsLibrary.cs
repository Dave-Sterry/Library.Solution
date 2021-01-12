using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class CheckoutsLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLibraries_Checkouts_CheckoutId",
                table: "BookLibraries");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patrons",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "BookLibraries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookLibraries_Checkouts_CheckoutId",
                table: "BookLibraries",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "CheckoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLibraries_Checkouts_CheckoutId",
                table: "BookLibraries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patrons");

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "BookLibraries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookLibraries_Checkouts_CheckoutId",
                table: "BookLibraries",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "CheckoutId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
