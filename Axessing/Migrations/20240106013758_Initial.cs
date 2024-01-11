using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Axessing.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HexValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Stage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabelTicket",
                columns: table => new
                {
                    LabelsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelTicket", x => new { x.LabelsId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_LabelTicket_Label_LabelsId",
                        column: x => x.LabelsId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelTicket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Stage", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1116), "Test 1", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1119), 1, "Test 1" },
                    { 2, new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1126), "Test 2", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1127), 2, "Test 2" },
                    { 3, new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1131), "Test 3", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1132), 1, "Test 3" },
                    { 4, new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1134), "Test 4", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1135), 0, "Test 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelTicket_TicketsId",
                table: "LabelTicket",
                column: "TicketsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelTicket");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
