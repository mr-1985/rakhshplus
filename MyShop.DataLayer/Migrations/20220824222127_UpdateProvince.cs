using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataLayer.Migrations
{
    public partial class UpdateProvince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Province_ProvinceId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_ProvinceId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Agents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ProvinceId",
                table: "Agents",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Province_ProvinceId",
                table: "Agents",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
