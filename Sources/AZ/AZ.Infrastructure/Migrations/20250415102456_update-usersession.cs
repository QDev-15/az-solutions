using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AZ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateusersession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "jti",
                table: "UserSessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 572, DateTimeKind.Utc).AddTicks(515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 572, DateTimeKind.Utc).AddTicks(314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(5536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(5372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(4491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(2118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 570, DateTimeKind.Utc).AddTicks(9951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 15, 10, 24, 55, 573, DateTimeKind.Utc).AddTicks(438), "AQAAAAIAAYagAAAAEPk1e9GxRQRFtKeF5U41/ASGdRei11RvpUlQUwHCjGO2G5lXxl2k6bZMpRZzDLFAYA==", new DateTime(2025, 4, 15, 10, 24, 55, 573, DateTimeKind.Utc).AddTicks(440) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jti",
                table: "UserSessions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 572, DateTimeKind.Utc).AddTicks(515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(378),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 572, DateTimeKind.Utc).AddTicks(314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(5536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(5372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(3090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(1534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 571, DateTimeKind.Utc).AddTicks(2118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 15, 10, 24, 55, 570, DateTimeKind.Utc).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 9, 59, 39, 341, DateTimeKind.Utc).AddTicks(8467), "AQAAAAIAAYagAAAAELxu8ftVZd9XTJkIYtyJz84GF72JdOrs7Lwde4O41l3AXetudnGrZ0jlrMDCNpUTYQ==", new DateTime(2025, 4, 14, 9, 59, 39, 341, DateTimeKind.Utc).AddTicks(8468) });
        }
    }
}
