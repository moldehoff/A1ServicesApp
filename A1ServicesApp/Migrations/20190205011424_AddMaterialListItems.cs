using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace A1ServicesApp.Migrations
{
    public partial class AddMaterialListItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobMaterials_MaterialList_MaterialListId",
                table: "JobMaterials");

            migrationBuilder.DropIndex(
                name: "IX_JobMaterials_MaterialListId",
                table: "JobMaterials");

            migrationBuilder.DropColumn(
                name: "MaterialListId",
                table: "JobMaterials");

            migrationBuilder.CreateTable(
                name: "MaterialListItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobMaterialId = table.Column<int>(nullable: false),
                    MaterialListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialListItems_JobMaterials_JobMaterialId",
                        column: x => x.JobMaterialId,
                        principalTable: "JobMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialListItems_MaterialList_MaterialListId",
                        column: x => x.MaterialListId,
                        principalTable: "MaterialList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialListItems_JobMaterialId",
                table: "MaterialListItems",
                column: "JobMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialListItems_MaterialListId",
                table: "MaterialListItems",
                column: "MaterialListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialListItems");

            migrationBuilder.AddColumn<int>(
                name: "MaterialListId",
                table: "JobMaterials",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobMaterials_MaterialListId",
                table: "JobMaterials",
                column: "MaterialListId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobMaterials_MaterialList_MaterialListId",
                table: "JobMaterials",
                column: "MaterialListId",
                principalTable: "MaterialList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
