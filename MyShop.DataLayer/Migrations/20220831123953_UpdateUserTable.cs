using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataLayer.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersDocuments_UserId",
                table: "UsersDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDocuments_UserId",
                table: "UsersDocuments",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersDocuments_UserId",
                table: "UsersDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDocuments_UserId",
                table: "UsersDocuments",
                column: "UserId");
        }
    }
}
