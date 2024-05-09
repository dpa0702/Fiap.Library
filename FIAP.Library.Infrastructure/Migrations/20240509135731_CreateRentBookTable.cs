using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.Library.Infrastructure.Migrations
{
    public partial class CreateRentBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentBook_Books_bookId",
                table: "RentBook");

            migrationBuilder.DropForeignKey(
                name: "FK_RentBook_Customers_customerId",
                table: "RentBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentBook",
                table: "RentBook");

            migrationBuilder.RenameTable(
                name: "RentBook",
                newName: "RentBooks");

            migrationBuilder.RenameIndex(
                name: "IX_RentBook_customerId",
                table: "RentBooks",
                newName: "IX_RentBooks_customerId");

            migrationBuilder.RenameIndex(
                name: "IX_RentBook_bookId",
                table: "RentBooks",
                newName: "IX_RentBooks_bookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentBooks",
                table: "RentBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentBooks_Books_bookId",
                table: "RentBooks",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentBooks_Customers_customerId",
                table: "RentBooks",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentBooks_Books_bookId",
                table: "RentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_RentBooks_Customers_customerId",
                table: "RentBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentBooks",
                table: "RentBooks");

            migrationBuilder.RenameTable(
                name: "RentBooks",
                newName: "RentBook");

            migrationBuilder.RenameIndex(
                name: "IX_RentBooks_customerId",
                table: "RentBook",
                newName: "IX_RentBook_customerId");

            migrationBuilder.RenameIndex(
                name: "IX_RentBooks_bookId",
                table: "RentBook",
                newName: "IX_RentBook_bookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentBook",
                table: "RentBook",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentBook_Books_bookId",
                table: "RentBook",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentBook_Customers_customerId",
                table: "RentBook",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
