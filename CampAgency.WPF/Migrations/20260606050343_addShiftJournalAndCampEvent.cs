using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    /// <inheritdoc />
    public partial class addShiftJournalAndCampEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampEvents",
                columns: table => new
                {
                    CampEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampEvents", x => x.CampEventId);
                });

            migrationBuilder.CreateTable(
                name: "ShiftJournals",
                columns: table => new
                {
                    ShiftJournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    CampEventId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftJournals", x => x.ShiftJournalId);
                    table.ForeignKey(
                        name: "FK_ShiftJournals_CampEvents_CampEventId",
                        column: x => x.CampEventId,
                        principalTable: "CampEvents",
                        principalColumn: "CampEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftJournals_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShiftJournals_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftJournals_CampEventId",
                table: "ShiftJournals",
                column: "CampEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftJournals_ChildId",
                table: "ShiftJournals",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftJournals_OperatorId",
                table: "ShiftJournals",
                column: "OperatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftJournals");

            migrationBuilder.DropTable(
                name: "CampEvents");
        }
    }
}
