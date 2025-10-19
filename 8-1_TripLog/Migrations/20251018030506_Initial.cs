using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _8_1_TripLog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Accomodation = table.Column<string>(nullable: true),
                    AccomodationPhone = table.Column<string>(nullable: true),
                    AccomodationEmail = table.Column<string>(nullable: true),
                    ThingsToDo1 = table.Column<string>(nullable: true),
                    ThingsToDo2 = table.Column<string>(nullable: true),
                    ThingsToDo3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accomodation", "AccomodationEmail", "AccomodationPhone", "Destination", "EndDate", "StartDate", "ThingsToDo1", "ThingsToDo2", "ThingsToDo3" },
                values: new object[] { 1, "The Inn", "ny@hotel.com", "1231112222", "New York", new DateTime(2025, 10, 17, 23, 5, 5, 719, DateTimeKind.Local).AddTicks(5696), new DateTime(2025, 10, 17, 23, 5, 5, 719, DateTimeKind.Local).AddTicks(4768), "Statue of Liberty", "Yankees Game", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
