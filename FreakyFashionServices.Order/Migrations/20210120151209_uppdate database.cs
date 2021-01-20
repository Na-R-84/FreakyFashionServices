using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashionServices.Order.Migrations
{
    public partial class uppdatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerIdentifier",
                table: "Orders",
                newName: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "CustomerIdentifier");
        }
    }
}
