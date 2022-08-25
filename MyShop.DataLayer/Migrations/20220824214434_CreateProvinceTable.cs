using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.DataLayer.Migrations
{
    public partial class CreateProvinceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Ostan",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "NoeMalekiat",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CityId",
                table: "Agents",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ProvinceId",
                table: "Agents",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceId",
                table: "City",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_City_CityId",
                table: "Agents",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Province_ProvinceId",
                table: "Agents",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_City_CityId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Province_ProvinceId",
                table: "Agents");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Agents_CityId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_ProvinceId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "NoeMalekiat",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ostan",
                table: "Agents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
