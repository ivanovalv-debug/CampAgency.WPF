using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    /// <inheritdoc />
    public partial class addShiftIdToShiftJournal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "ShiftJournals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftJournals_ShiftId",
                table: "ShiftJournals",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftJournals_Shifts_ShiftId",
                table: "ShiftJournals",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShiftJournals_Shifts_ShiftId",
                table: "ShiftJournals");

            migrationBuilder.DropIndex(
                name: "IX_ShiftJournals_ShiftId",
                table: "ShiftJournals");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "ShiftJournals");
        }
    }
}
