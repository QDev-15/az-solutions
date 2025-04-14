using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AZ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatenullvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserAgent",
                table: "UserSessions",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "TimeZone",
                table: "UserSessions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "UserSessions",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(378),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1072));

            migrationBuilder.AlterColumn<string>(
                name: "StackTrace",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(3090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(1534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(8428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 9, 59, 39, 341, DateTimeKind.Utc).AddTicks(8467), "AQAAAAIAAYagAAAAELxu8ftVZd9XTJkIYtyJz84GF72JdOrs7Lwde4O41l3AXetudnGrZ0jlrMDCNpUTYQ==", new DateTime(2025, 4, 14, 9, 59, 39, 341, DateTimeKind.Utc).AddTicks(8468) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserAgent",
                table: "UserSessions",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TimeZone",
                table: "UserSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "UserSessions",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 340, DateTimeKind.Utc).AddTicks(378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(4015));

            migrationBuilder.AlterColumn<string>(
                name: "StackTrace",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(8428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(7560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 14, 9, 59, 39, 339, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 10, 9, 49, 52, 928, DateTimeKind.Utc).AddTicks(7359), "AQAAAAIAAYagAAAAEIM5Cwqn0gRWuYmSXI6AImBJLhKLMYPi0FdknSZ0jREFSyN0Or5fX448lKpaG8pndg==", new DateTime(2025, 4, 10, 9, 49, 52, 928, DateTimeKind.Utc).AddTicks(7361) });
        }
    }
}
