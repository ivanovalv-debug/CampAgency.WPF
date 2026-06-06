using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    /// <inheritdoc />
    public partial class addOperatorComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OperatorComment",
                table: "Documents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatorComment",
                table: "Documents");
        }
    }
}
