using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Axessing.Migrations
{
    /// <inheritdoc />
    public partial class Relation_Workspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkspaceId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title", "WorkspaceId" },
                values: new object[] { new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9008), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9010), "Create new dashboard", 1 });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title", "WorkspaceId" },
                values: new object[] { new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9015), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9017), "Change state of data models", 1 });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title", "WorkspaceId" },
                values: new object[] { new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9049), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9050), "Type state error when accessing ticket", 1 });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title", "WorkspaceId" },
                values: new object[] { new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9053), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9074), "Git log error after update", 1 });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Description", "LogoURL", "Name" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet.", "https://png.pngtree.com/png-vector/20221119/ourmid/pngtree-aa-letter-logos-png-image_6471608.png", "Axessing - Monorepo" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Stage", "Title", "WorkspaceId" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9077), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9078), 0, "Wishlist sharing problems", 1 },
                    { 6, new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9083), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9084), 0, "Telegram does not accept list of type x", 1 },
                    { 7, new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9087), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9088), 0, "Button color palette should be changed", 1 },
                    { 8, new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9090), "Lorem ipsum dolor sit amet at avis mia seguind ralf cuspat en colo lat gerda mecant e.", new DateTime(2024, 1, 8, 4, 46, 53, 67, DateTimeKind.Local).AddTicks(9091), 0, "Account appears only when logged in", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_WorkspaceId",
                table: "Tickets",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_WorkspaceId",
                table: "AppUser",
                column: "WorkspaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Workspaces_WorkspaceId",
                table: "Tickets",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Workspaces_WorkspaceId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_WorkspaceId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "WorkspaceId",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title" },
                values: new object[] { new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1116), "Test 1", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1119), "Test 1" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title" },
                values: new object[] { new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1126), "Test 2", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1127), "Test 2" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title" },
                values: new object[] { new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1131), "Test 3", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1132), "Test 3" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "LastModifiedDate", "Title" },
                values: new object[] { new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1134), "Test 4", new DateTime(2024, 1, 6, 2, 37, 58, 622, DateTimeKind.Local).AddTicks(1135), "Test 4" });
        }
    }
}
