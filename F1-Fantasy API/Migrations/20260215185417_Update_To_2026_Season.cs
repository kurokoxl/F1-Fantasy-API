using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F1_Fantasy_API.Migrations
{
    /// <inheritdoc />
    public partial class Update_To_2026_Season : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "DriverRaceResults",
                keyColumns: new[] { "DriverId", "RaceId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 1,
                columns: new[] { "Date", "Season" },
                values: new object[] { new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 3,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 4,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 5,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 6,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 7,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 8,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 9,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 10,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 11,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 12,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 13,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 14,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 15,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 16,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 17,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 18,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 19,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 20,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 21,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 22,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 23,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 24,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2026, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2026, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DriverRaceResults",
                columns: new[] { "DriverId", "RaceId", "Points", "Position" },
                values: new object[,]
                {
                    { 1, 1, 25, 1 },
                    { 1, 2, 18, 2 },
                    { 2, 1, 2, 9 },
                    { 2, 2, 25, 1 },
                    { 3, 1, 18, 2 },
                    { 3, 2, 12, 4 },
                    { 4, 1, 0, 12 },
                    { 5, 1, 15, 3 },
                    { 5, 2, 15, 3 },
                    { 6, 1, 12, 4 },
                    { 6, 2, 8, 6 },
                    { 7, 1, 4, 8 },
                    { 8, 1, 1, 10 },
                    { 10, 1, 8, 6 },
                    { 10, 2, 2, 9 },
                    { 11, 1, 10, 5 },
                    { 11, 2, 6, 7 },
                    { 12, 2, 1, 10 },
                    { 15, 1, 0, 13 },
                    { 15, 2, 10, 5 },
                    { 16, 1, 0, 14 },
                    { 16, 2, 4, 8 },
                    { 17, 1, 6, 7 },
                    { 19, 1, 0, 11 }
                });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 1,
                columns: new[] { "Date", "Season" },
                values: new object[] { new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 3,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 4,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 5,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 6,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 7,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 8,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 9,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 10,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 11,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 12,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 13,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 14,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 15,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 16,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 17,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 18,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 19,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 20,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 21,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 22,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 23,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 24,
                columns: new[] { "Date", "Season", "Status" },
                values: new object[] { new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2025, 1 });
        }
    }
}
