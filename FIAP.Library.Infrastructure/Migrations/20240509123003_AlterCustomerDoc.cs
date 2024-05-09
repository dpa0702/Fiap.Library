using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.Library.Infrastructure.Migrations
{
    public partial class AlterCustomerDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Customers",
                newName: "document");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "document",
                table: "Customers",
                newName: "status");
        }
    }
}
