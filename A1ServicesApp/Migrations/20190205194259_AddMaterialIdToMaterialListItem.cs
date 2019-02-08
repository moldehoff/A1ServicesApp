using Microsoft.EntityFrameworkCore.Migrations;

namespace A1ServicesApp.Migrations
{
    public partial class AddMaterialIdToMaterialListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "MaterialListItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "MaterialListItems");
        }
    }
}
