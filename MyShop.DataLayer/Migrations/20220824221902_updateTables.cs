using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataLayer.Migrations
{
    public partial class updateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_City_CityId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_CityId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ostan",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Ostan",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Province",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CityId",
                table: "Agents",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_City_CityId",
                table: "Agents",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
