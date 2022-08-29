using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataLayer.Migrations
{
    public partial class CreateUserDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersDocuments",
                columns: table => new
                {
                    UserDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PersonalImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FrontNationalImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BackNationalImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FrontShenasnamehImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DescriptionShenasnamehImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDocuments", x => x.UserDocumentId);
                    table.ForeignKey(
                        name: "FK_UsersDocuments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersDocuments_UserId",
                table: "UsersDocuments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersDocuments");
        }
    }
}
