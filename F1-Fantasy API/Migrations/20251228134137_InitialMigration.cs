using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F1_Fantasy_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Constructor",
                columns: table => new
                {
                    ConstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constructor", x => x.ConstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CircuitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Laps = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Driver_Constructor_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructor",
                        principalColumn: "ConstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstructorSelection",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    ConstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructorSelection", x => new { x.RaceId, x.ConstructorId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ConstructorSelection_Constructor_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructor",
                        principalColumn: "ConstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructorSelection_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructorSelection_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverRaceResult",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverRaceResult", x => new { x.DriverId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_DriverRaceResult_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverRaceResult_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverSelection",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    IsTurbo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverSelection", x => new { x.RaceId, x.DriverId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_DriverSelection_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverSelection_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverSelection_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Constructor",
                columns: new[] { "ConstructorId", "Name" },
                values: new object[,]
                {
                    { 1, "McLaren" },
                    { 2, "Red Bull" },
                    { 3, "Mercedes" },
                    { 4, "Ferrari" },
                    { 5, "Aston Martin" },
                    { 6, "Williams" },
                    { 7, "Racing Bulls" },
                    { 8, "Haas F1 Team" },
                    { 9, "Kick Sauber" },
                    { 10, "Alpine" }
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "RaceId", "CircuitName", "Date", "Laps", "Name", "Season" },
                values: new object[,]
                {
                    { 1, "Albert Park Grand Prix Circuit", new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, "Australian Grand Prix", 2025 },
                    { 2, "Shanghai International Circuit", new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, "Chinese Grand Prix", 2025 },
                    { 3, "Suzuka Circuit", new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, "Japanese Grand Prix", 2025 },
                    { 4, "Bahrain International Circuit", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, "Bahrain Grand Prix", 2025 },
                    { 5, "Jeddah Corniche Circuit", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Saudi Arabian Grand Prix", 2025 },
                    { 6, "Miami International Autodrome", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, "Miami Grand Prix", 2025 },
                    { 7, "Autodromo Enzo e Dino Ferrari", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, "Emilia Romagna Grand Prix", 2025 },
                    { 8, "Circuit de Monaco", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, "Monaco Grand Prix", 2025 },
                    { 9, "Circuit de Barcelona-Catalunya", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, "Spanish Grand Prix", 2025 },
                    { 10, "Circuit Gilles Villeneuve", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, "Canadian Grand Prix", 2025 },
                    { 11, "Red Bull Ring", new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, "Austrian Grand Prix", 2025 },
                    { 12, "Silverstone Circuit", new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, "British Grand Prix", 2025 },
                    { 13, "Circuit de Spa-Francorchamps", new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, "Belgian Grand Prix", 2025 },
                    { 14, "Hungaroring", new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, "Hungarian Grand Prix", 2025 },
                    { 15, "Circuit Park Zandvoort", new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, "Dutch Grand Prix", 2025 },
                    { 16, "Autodromo Nazionale di Monza", new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, "Italian Grand Prix", 2025 },
                    { 17, "Baku City Circuit", new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, "Azerbaijan Grand Prix", 2025 },
                    { 18, "Marina Bay Street Circuit", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, "Singapore Grand Prix", 2025 },
                    { 19, "Circuit of the Americas", new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, "United States Grand Prix", 2025 },
                    { 20, "Autódromo Hermanos Rodríguez", new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, "Mexico City Grand Prix", 2025 },
                    { 21, "Autódromo José Carlos Pace", new DateTime(2025, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, "São Paulo Grand Prix", 2025 },
                    { 22, "Las Vegas Strip Street Circuit", new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Las Vegas Grand Prix", 2025 },
                    { 23, "Losail International Circuit", new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, "Qatar Grand Prix", 2025 },
                    { 24, "Yas Marina Circuit", new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, "Abu Dhabi Grand Prix", 2025 }
                });

            migrationBuilder.InsertData(
                table: "Driver",
                columns: new[] { "DriverId", "ConstructorId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Lando Norris", 58 },
                    { 2, 1, "Oscar Piastri", 50 },
                    { 3, 2, "Max Verstappen", 60 },
                    { 4, 2, "Yuki Tsunoda", 30 },
                    { 5, 3, "George Russell", 48 },
                    { 6, 3, "Andrea Kimi Antonelli", 21 },
                    { 7, 4, "Charles Leclerc", 56 },
                    { 8, 4, "Lewis Hamilton", 55 },
                    { 9, 5, "Fernando Alonso", 40 },
                    { 10, 5, "Lance Stroll", 26 },
                    { 11, 6, "Alex Albon", 38 },
                    { 12, 6, "Carlos Sainz", 47 },
                    { 13, 7, "Liam Lawson", 22 },
                    { 14, 7, "Isack Hadjar", 16 },
                    { 15, 8, "Esteban Ocon", 28 },
                    { 16, 8, "Oliver Bearman", 20 },
                    { 17, 9, "Nico Hulkenberg", 27 },
                    { 18, 9, "Gabriel Bortoleto", 18 },
                    { 19, 10, "Pierre Gasly", 36 },
                    { 20, 10, "Franco Colapinto", 15 }
                });

            migrationBuilder.InsertData(
                table: "DriverRaceResult",
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructorSelection_ConstructorId",
                table: "ConstructorSelection",
                column: "ConstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructorSelection_TeamId",
                table: "ConstructorSelection",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_ConstructorId",
                table: "Driver",
                column: "ConstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRaceResult_RaceId",
                table: "DriverRaceResult",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverSelection_DriverId",
                table: "DriverSelection",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverSelection_TeamId",
                table: "DriverSelection",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConstructorSelection");

            migrationBuilder.DropTable(
                name: "DriverRaceResult");

            migrationBuilder.DropTable(
                name: "DriverSelection");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Constructor");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
