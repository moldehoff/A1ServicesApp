using Microsoft.EntityFrameworkCore.Migrations;

namespace A1ServicesApp.Migrations
{
    public partial class AddIdToServiceAndMaterialObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "JobServices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "JobMaterials",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "JobServices");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "JobMaterials");
        }
    }
}
