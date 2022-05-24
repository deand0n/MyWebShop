using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebShop.Infrastructure.Migrations
{
    public partial class RemovedOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "order",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
