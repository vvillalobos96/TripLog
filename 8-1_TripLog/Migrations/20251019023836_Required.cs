using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_1_TripLog.Migrations
{
    public partial class Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 22, 38, 35, 624, DateTimeKind.Local).AddTicks(5753), new DateTime(2025, 10, 18, 22, 38, 35, 624, DateTimeKind.Local).AddTicks(5059) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 17, 23, 5, 5, 719, DateTimeKind.Local).AddTicks(5696), new DateTime(2025, 10, 17, 23, 5, 5, 719, DateTimeKind.Local).AddTicks(4768) });
        }
    }
}
