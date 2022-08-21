using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataLayer.Migrations
{
    public partial class CreteAgentTbe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ostan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoeMalekiat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MojavezeKasbImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SherkatnameImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NewsPaperImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AgahiTaasisImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AkharinAgahiTaaghiratImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SarDarForoushgahImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FishAbImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FishGazImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FishBarghImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FishTelePhoneImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SanadNoeeMalekiatImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDtae = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AgentId",
                table: "Users",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Agents_AgentId",
                table: "Users",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "AgentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Agents_AgentId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Users_AgentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Users");
        }
    }
}
