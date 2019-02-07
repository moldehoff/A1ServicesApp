using Microsoft.EntityFrameworkCore.Migrations;

namespace A1ServicesApp.Migrations
{
    public partial class MakeMaterialListItemMaterialIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialListItems",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialListItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
