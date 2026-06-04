using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    /// <inheritdoc />
    public partial class addRegionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Camps");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Camps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camps_RegionId",
                table: "Camps",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Camps_Regions_RegionId",
                table: "Camps",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camps_Regions_RegionId",
                table: "Camps");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Camps_RegionId",
                table: "Camps");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Camps");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Camps",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
