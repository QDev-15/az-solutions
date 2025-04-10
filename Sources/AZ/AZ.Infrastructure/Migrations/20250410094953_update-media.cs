using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AZ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatemedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Logs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(8271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(8068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(2261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(1162));

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StackTrace",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(8428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 995, DateTimeKind.Utc).AddTicks(9265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(7560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 995, DateTimeKind.Utc).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 10, 9, 49, 52, 928, DateTimeKind.Utc).AddTicks(7359), "AQAAAAIAAYagAAAAEIM5Cwqn0gRWuYmSXI6AImBJLhKLMYPi0FdknSZ0jREFSyN0Or5fX448lKpaG8pndg==", new DateTime(2025, 4, 10, 9, 49, 52, 928, DateTimeKind.Utc).AddTicks(7361) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "StackTrace",
                table: "Logs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(8271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(8068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(2261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Media",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(2099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(1072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 996, DateTimeKind.Utc).AddTicks(1162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 927, DateTimeKind.Utc).AddTicks(265));

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Logs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Logs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 995, DateTimeKind.Utc).AddTicks(9265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(8428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Feedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 9, 9, 40, 44, 995, DateTimeKind.Utc).AddTicks(8194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 10, 9, 49, 52, 926, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 9, 40, 44, 998, DateTimeKind.Utc).AddTicks(261), "AQAAAAIAAYagAAAAEE1VBJ6fEiXW14VDLUQVI7FWM2l8vc2stz5eyKXPOgQuBPEJFyZS1V2mczjiwZ1fGg==", new DateTime(2025, 4, 9, 9, 40, 44, 998, DateTimeKind.Utc).AddTicks(267) });
        }
    }
}
