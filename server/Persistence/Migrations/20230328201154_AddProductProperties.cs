using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddProductProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDestination_OrderDestinationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDestination",
                table: "OrderDestination");

            migrationBuilder.RenameTable(
                name: "OrderDestination",
                newName: "OrderDestinations");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDestinations",
                table: "OrderDestinations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDestinations_OrderDestinationId",
                table: "Orders",
                column: "OrderDestinationId",
                principalTable: "OrderDestinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDestinations_OrderDestinationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDestinations",
                table: "OrderDestinations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "OrderDestinations",
                newName: "OrderDestination");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDestination",
                table: "OrderDestination",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDestination_OrderDestinationId",
                table: "Orders",
                column: "OrderDestinationId",
                principalTable: "OrderDestination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
