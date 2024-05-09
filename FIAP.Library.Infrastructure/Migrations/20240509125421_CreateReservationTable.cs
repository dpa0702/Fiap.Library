using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.Library.Infrastructure.Migrations
{
    public partial class CreateReservationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Books_bookId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customers_customerId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_customerId",
                table: "Reservations",
                newName: "IX_Reservations_customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_bookId",
                table: "Reservations",
                newName: "IX_Reservations_bookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Books_bookId",
                table: "Reservations",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_customerId",
                table: "Reservations",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Books_bookId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_customerId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_customerId",
                table: "Reservation",
                newName: "IX_Reservation_customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_bookId",
                table: "Reservation",
                newName: "IX_Reservation_bookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Books_bookId",
                table: "Reservation",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customers_customerId",
                table: "Reservation",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
