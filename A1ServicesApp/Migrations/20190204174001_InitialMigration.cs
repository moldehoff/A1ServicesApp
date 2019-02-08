using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace A1ServicesApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobServiceMaterialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true),
                    ServiceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobServiceMaterialLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    MemberPrice = table.Column<double>(nullable: true),
                    AddOnPrice = table.Column<double>(nullable: true),
                    AddOnMemberPrice = table.Column<double>(nullable: true),
                    Active = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    JobServiceMaterialLinkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialList_JobServiceMaterialLinks_JobServiceMaterialLinkId",
                        column: x => x.JobServiceMaterialLinkId,
                        principalTable: "JobServiceMaterialLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Active = table.Column<int>(nullable: false),
                    MaterialListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobMaterials_MaterialList_MaterialListId",
                        column: x => x.MaterialListId,
                        principalTable: "MaterialList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobMaterials_MaterialListId",
                table: "JobMaterials",
                column: "MaterialListId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialList_JobServiceMaterialLinkId",
                table: "MaterialList",
                column: "JobServiceMaterialLinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobMaterials");

            migrationBuilder.DropTable(
                name: "JobServices");

            migrationBuilder.DropTable(
                name: "MaterialList");

            migrationBuilder.DropTable(
                name: "JobServiceMaterialLinks");
        }
    }
}
