using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebShop.Infrastructure.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_product_UserId",
                table: "product",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_user_UserId",
                table: "product",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_user_UserId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_UserId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "product");
        }
    }
}
