using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_Fantasy_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConstructorSelection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructorSelections");

            migrationBuilder.AddColumn<int>(
                name: "ConstructorId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 1);

            // Update existing teams to have a valid ConstructorId (McLaren = 1)
            migrationBuilder.Sql("UPDATE Teams SET ConstructorId = 1 WHERE ConstructorId = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ConstructorId",
                table: "Teams",
                column: "ConstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Constructors_ConstructorId",
                table: "Teams",
                column: "ConstructorId",
                principalTable: "Constructors",
                principalColumn: "ConstructorId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Constructors_ConstructorId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ConstructorId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ConstructorId",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "ConstructorSelections",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    ConstructorId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructorSelections", x => new { x.RaceId, x.ConstructorId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ConstructorSelections_Constructors_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructors",
                        principalColumn: "ConstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructorSelections_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructorSelections_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructorSelections_ConstructorId",
                table: "ConstructorSelections",
                column: "ConstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructorSelections_TeamId",
                table: "ConstructorSelections",
                column: "TeamId");
        }
    }
}
