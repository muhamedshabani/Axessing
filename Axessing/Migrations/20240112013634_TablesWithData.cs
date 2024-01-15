using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Axessing.Migrations
{
    /// <inheritdoc />
    public partial class TablesWithData : Migration
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
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    LogoURL = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id");
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
                    Stage = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkspaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Workspaces",
                columns: new[] { "Id", "Description", "LogoURL", "Name" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet.", "https://png.pngtree.com/png-vector/20221119/ourmid/pngtree-aa-letter-logos-png-image_6471608.png", "Axessing - Monorepo" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Stage", "Title", "WorkspaceId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5914), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5915), 1, "Create new dashboard", 1 },
                    { 2, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5921), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5922), 2, "Change state of data models", 1 },
                    { 3, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5925), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5926), 0, "Type state error when accessing ticket", 1 },
                    { 4, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5928), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5929), 0, "Git log error after update", 1 },
                    { 5, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5932), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5933), 4, "Wishlist sharing problems", 1 },
                    { 6, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5937), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5938), 3, "Telegram does not accept list of type x", 1 },
                    { 7, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5940), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5941), 0, "Button color palette should be changed", 1 },
                    { 8, new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5944), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5945), 5, "Account appears only when logged in", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_WorkspaceId",
                table: "AppUser",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTicket_TicketsId",
                table: "LabelTicket",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_WorkspaceId",
                table: "Tickets",
                column: "WorkspaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "LabelTicket");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Workspaces");
        }
    }
}
