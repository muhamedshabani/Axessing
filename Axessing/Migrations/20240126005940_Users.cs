using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Axessing.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Workspaces_WorkspaceId",
                table: "AppUser");

            migrationBuilder.AlterColumn<int>(
                name: "WorkspaceId",
                table: "AppUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "WorkspaceId" },
                values: new object[,]
                {
                    { "100", 0, "0b08c62f-71e6-4a79-b1e5-653673ed2960", "muhamed.shaban@hotmail.com", true, false, null, "Muhamed Shabani", "MUHAMED.SHABAN@HOTMAIL.COM", "MUHAMEDSH", null, "+389 71 894 975", true, "8378a38f-1f49-4f5e-b99e-dc5511f26526", false, "omuj", 1 },
                    { "101", 0, "da20d35a-c8d1-451a-adcf-1d5b9056e9bd", "podgragja.a@hotmail.com", true, false, null, "Agon Podgragja", "PODGRAGJA.A@HOTMAIL.COM", "POGI", null, "+389 71 818 819", true, "e89fe5f2-a859-41e1-a104-87a25f1f1fba", false, "pogi", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5625), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5626) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5631), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5635), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5636) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5638), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5639) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5642), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5643) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5647), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5648) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5651), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5652) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5654), new DateTime(2024, 1, 26, 1, 59, 40, 827, DateTimeKind.Local).AddTicks(5655) });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Workspaces_WorkspaceId",
                table: "AppUser",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Workspaces_WorkspaceId",
                table: "AppUser");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "100");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "101");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppUser");

            migrationBuilder.AlterColumn<int>(
                name: "WorkspaceId",
                table: "AppUser",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5914), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5915) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5921), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5925), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5926) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5928), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5929) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5932), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5937), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5938) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5940), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5944), new DateTime(2024, 1, 12, 2, 36, 34, 236, DateTimeKind.Local).AddTicks(5945) });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Workspaces_WorkspaceId",
                table: "AppUser",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id");
        }
    }
}
