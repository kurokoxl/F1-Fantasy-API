using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_Fantasy_API.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorSelection_Constructor_ConstructorId",
                table: "ConstructorSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorSelection_Race_RaceId",
                table: "ConstructorSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorSelection_Team_TeamId",
                table: "ConstructorSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Constructor_ConstructorId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceResult_Driver_DriverId",
                table: "DriverRaceResult");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceResult_Race_RaceId",
                table: "DriverRaceResult");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelection_Driver_DriverId",
                table: "DriverSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelection_Race_RaceId",
                table: "DriverSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelection_Team_TeamId",
                table: "DriverSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_AspNetUsers_UserId",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Race",
                table: "Race");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverSelection",
                table: "DriverSelection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverRaceResult",
                table: "DriverRaceResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Driver",
                table: "Driver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConstructorSelection",
                table: "ConstructorSelection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Constructor",
                table: "Constructor");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Race",
                newName: "Races");

            migrationBuilder.RenameTable(
                name: "DriverSelection",
                newName: "DriverSelections");

            migrationBuilder.RenameTable(
                name: "DriverRaceResult",
                newName: "DriverRaceResults");

            migrationBuilder.RenameTable(
                name: "Driver",
                newName: "Drivers");

            migrationBuilder.RenameTable(
                name: "ConstructorSelection",
                newName: "ConstructorSelections");

            migrationBuilder.RenameTable(
                name: "Constructor",
                newName: "Constructors");

            migrationBuilder.RenameIndex(
                name: "IX_Team_UserId",
                table: "Teams",
                newName: "IX_Teams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSelection_TeamId",
                table: "DriverSelections",
                newName: "IX_DriverSelections_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSelection_DriverId",
                table: "DriverSelections",
                newName: "IX_DriverSelections_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverRaceResult_RaceId",
                table: "DriverRaceResults",
                newName: "IX_DriverRaceResults_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_ConstructorId",
                table: "Drivers",
                newName: "IX_Drivers_ConstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorSelection_TeamId",
                table: "ConstructorSelections",
                newName: "IX_ConstructorSelections_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorSelection_ConstructorId",
                table: "ConstructorSelections",
                newName: "IX_ConstructorSelections_ConstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Races",
                table: "Races",
                column: "RaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverSelections",
                table: "DriverSelections",
                columns: new[] { "RaceId", "DriverId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverRaceResults",
                table: "DriverRaceResults",
                columns: new[] { "DriverId", "RaceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "DriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConstructorSelections",
                table: "ConstructorSelections",
                columns: new[] { "RaceId", "ConstructorId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Constructors",
                table: "Constructors",
                column: "ConstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorSelections_Constructors_ConstructorId",
                table: "ConstructorSelections",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "ConstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorSelections_Races_RaceId",
                table: "ConstructorSelections",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorSelections_Teams_TeamId",
                table: "ConstructorSelections",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceResults_Drivers_DriverId",
                table: "DriverRaceResults",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceResults_Races_RaceId",
                table: "DriverRaceResults",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Constructors_ConstructorId",
                table: "Drivers",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "ConstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelections_Drivers_DriverId",
                table: "DriverSelections",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelections_Races_RaceId",
                table: "DriverSelections",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelections_Teams_TeamId",
                table: "DriverSelections",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorSelections_Constructors_ConstructorId",
                table: "ConstructorSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorSelections_Races_RaceId",
                table: "ConstructorSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_ConstructorSelections_Teams_TeamId",
                table: "ConstructorSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceResults_Drivers_DriverId",
                table: "DriverRaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceResults_Races_RaceId",
                table: "DriverRaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Constructors_ConstructorId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelections_Drivers_DriverId",
                table: "DriverSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelections_Races_RaceId",
                table: "DriverSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverSelections_Teams_TeamId",
                table: "DriverSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_UserId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Races",
                table: "Races");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverSelections",
                table: "DriverSelections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverRaceResults",
                table: "DriverRaceResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConstructorSelections",
                table: "ConstructorSelections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Constructors",
                table: "Constructors");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "Races",
                newName: "Race");

            migrationBuilder.RenameTable(
                name: "DriverSelections",
                newName: "DriverSelection");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Driver");

            migrationBuilder.RenameTable(
                name: "DriverRaceResults",
                newName: "DriverRaceResult");

            migrationBuilder.RenameTable(
                name: "ConstructorSelections",
                newName: "ConstructorSelection");

            migrationBuilder.RenameTable(
                name: "Constructors",
                newName: "Constructor");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_UserId",
                table: "Team",
                newName: "IX_Team_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSelections_TeamId",
                table: "DriverSelection",
                newName: "IX_DriverSelection_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverSelections_DriverId",
                table: "DriverSelection",
                newName: "IX_DriverSelection_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_ConstructorId",
                table: "Driver",
                newName: "IX_Driver_ConstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverRaceResults_RaceId",
                table: "DriverRaceResult",
                newName: "IX_DriverRaceResult_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorSelections_TeamId",
                table: "ConstructorSelection",
                newName: "IX_ConstructorSelection_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_ConstructorSelections_ConstructorId",
                table: "ConstructorSelection",
                newName: "IX_ConstructorSelection_ConstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Race",
                table: "Race",
                column: "RaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverSelection",
                table: "DriverSelection",
                columns: new[] { "RaceId", "DriverId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Driver",
                table: "Driver",
                column: "DriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverRaceResult",
                table: "DriverRaceResult",
                columns: new[] { "DriverId", "RaceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConstructorSelection",
                table: "ConstructorSelection",
                columns: new[] { "RaceId", "ConstructorId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Constructor",
                table: "Constructor",
                column: "ConstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorSelection_Constructor_ConstructorId",
                table: "ConstructorSelection",
                column: "ConstructorId",
                principalTable: "Constructor",
                principalColumn: "ConstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorSelection_Race_RaceId",
                table: "ConstructorSelection",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructorSelection_Team_TeamId",
                table: "ConstructorSelection",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Constructor_ConstructorId",
                table: "Driver",
                column: "ConstructorId",
                principalTable: "Constructor",
                principalColumn: "ConstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceResult_Driver_DriverId",
                table: "DriverRaceResult",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceResult_Race_RaceId",
                table: "DriverRaceResult",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelection_Driver_DriverId",
                table: "DriverSelection",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelection_Race_RaceId",
                table: "DriverSelection",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverSelection_Team_TeamId",
                table: "DriverSelection",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_AspNetUsers_UserId",
                table: "Team",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
