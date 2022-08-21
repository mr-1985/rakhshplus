using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataLayer.Migrations
{
    public partial class CreateAgentDocumentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgahiTaasisImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AkharinAgahiTaaghiratImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "FishAbImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "FishBarghImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "FishGazImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "FishTelePhoneImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "MojavezeKasbImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "NewsPaperImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "SanadNoeeMalekiatImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "SarDarForoushgahImage",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "SherkatnameImage",
                table: "Agents");

            migrationBuilder.CreateTable(
                name: "AgentDocuments",
                columns: table => new
                {
                    AgentDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentDocuments", x => x.AgentDocumentId);
                    table.ForeignKey(
                        name: "FK_AgentDocuments_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentDocuments_AgentId",
                table: "AgentDocuments",
                column: "AgentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentDocuments");

            migrationBuilder.AddColumn<string>(
                name: "AgahiTaasisImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AkharinAgahiTaaghiratImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FishAbImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FishBarghImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FishGazImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FishTelePhoneImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MojavezeKasbImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsPaperImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanadNoeeMalekiatImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SarDarForoushgahImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SherkatnameImage",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
