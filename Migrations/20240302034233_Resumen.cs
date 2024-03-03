using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebasArticulos.API.Migrations
{
    /// <inheritdoc />
    public partial class Resumen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Users_UsersId",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_UsersId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "shoppingCarts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "shoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_UsersId",
                table: "shoppingCarts",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Users_UsersId",
                table: "shoppingCarts",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
