using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GConge.web.api.Migrations
{
    public partial class eneleverDesColones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { new byte[] { 68, 61, 82, 135, 73, 64, 49, 151, 129, 182, 74, 237, 17, 214, 59, 174, 20, 242, 10, 215, 231, 92, 45, 116, 236, 195, 203, 93, 239, 119, 68, 167, 25, 107, 217, 50, 230, 247, 23, 18, 230, 169, 176, 127, 35, 185, 141, 84, 180, 183, 36, 228, 133, 88, 6, 75, 105, 238, 94, 152, 202, 253, 249, 97 }, new byte[] { 65, 109, 126, 87, 113, 135, 188, 251, 138, 61, 112, 80, 91, 198, 42, 90, 196, 31, 222, 187, 165, 250, 138, 226, 69, 29, 17, 89, 11, 213, 46, 161, 113, 20, 15, 86, 61, 191, 145, 119, 70, 142, 231, 69, 73, 213, 166, 26, 214, 192, 170, 246, 164, 17, 186, 234, 191, 113, 97, 26, 241, 35, 120, 225, 129, 8, 102, 121, 98, 140, 111, 81, 193, 191, 237, 25, 252, 16, 170, 217, 196, 198, 128, 104, 56, 169, 117, 94, 161, 51, 180, 163, 88, 197, 33, 251, 253, 152, 72, 244, 9, 80, 23, 179, 31, 77, 145, 120, 81, 133, 145, 184, 219, 243, 97, 135, 223, 72, 181, 36, 67, 236, 255, 150, 162, 77, 78, 170 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LeaveRequests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LeaveRequests",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "LeaveRequests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "LeaveRequests",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employees",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Employees",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Employees",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { "System", new DateTime(2022, 9, 26, 9, 41, 17, 938, DateTimeKind.Local).AddTicks(4941), "System", new DateTime(2022, 9, 26, 9, 41, 17, 938, DateTimeKind.Local).AddTicks(4947) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Password", "PasswordSalt" },
                values: new object[] { "System", new DateTime(2022, 9, 26, 9, 41, 17, 938, DateTimeKind.Local).AddTicks(4739), "System", new DateTime(2022, 9, 26, 9, 41, 17, 938, DateTimeKind.Local).AddTicks(4803), new byte[] { 97, 82, 41, 175, 159, 92, 253, 137, 180, 188, 29, 159, 104, 74, 243, 202, 2, 112, 218, 74, 18, 155, 33, 118, 61, 101, 35, 136, 240, 90, 153, 92, 200, 35, 142, 33, 3, 100, 95, 163, 24, 85, 76, 1, 169, 4, 104, 163, 191, 233, 189, 178, 167, 232, 30, 40, 159, 117, 83, 67, 68, 124, 71, 150 }, new byte[] { 154, 171, 112, 77, 129, 15, 89, 110, 182, 198, 218, 195, 205, 183, 104, 151, 204, 4, 176, 180, 116, 95, 69, 118, 71, 253, 119, 0, 226, 164, 115, 243, 178, 206, 253, 138, 71, 35, 89, 77, 201, 207, 125, 90, 6, 253, 78, 57, 55, 249, 124, 87, 180, 177, 235, 126, 182, 87, 80, 26, 172, 236, 46, 46, 196, 125, 150, 93, 32, 24, 175, 217, 138, 169, 45, 193, 156, 54, 254, 196, 76, 147, 205, 229, 158, 47, 247, 188, 198, 43, 83, 248, 151, 71, 15, 213, 45, 189, 248, 247, 11, 12, 91, 30, 30, 3, 255, 241, 191, 90, 106, 249, 239, 45, 34, 102, 140, 228, 137, 2, 222, 190, 197, 195, 132, 67, 148, 253 } });
        }
    }
}
