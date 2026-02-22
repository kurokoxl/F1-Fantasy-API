using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_Fantasy_API.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelections_Races_RaceId",
                table: "DriverSelections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverSelections",
                table: "DriverSelections");

            migrationBuilder.DropIndex(
                name: "IX_DriverSelections_DriverId",
                table: "DriverSelections");

            migrationBuilder.DropColumn(
                name: "IsTurbo",
                table: "DriverSelections");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "DriverSelections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverSelections",
                table: "DriverSelections",
                columns: new[] { "DriverId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_DriverSelections_RaceId",
                table: "DriverSelections",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelections_Races_RaceId",
                table: "DriverSelections",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelections_Races_RaceId",
                table: "DriverSelections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverSelections",
                table: "DriverSelections");

            migrationBuilder.DropIndex(
                name: "IX_DriverSelections_RaceId",
                table: "DriverSelections");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "DriverSelections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTurbo",
                table: "DriverSelections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverSelections",
                table: "DriverSelections",
                columns: new[] { "RaceId", "DriverId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_DriverSelections_DriverId",
                table: "DriverSelections",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelections_Races_RaceId",
                table: "DriverSelections",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
