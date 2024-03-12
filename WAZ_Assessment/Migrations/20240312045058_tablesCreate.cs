using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAZ_Assessment.Migrations
{
    /// <inheritdoc />
    public partial class tablesCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    uniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WellDummy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    platformId = table.Column<int>(type: "int", nullable: false),
                    uniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellDummy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Well",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    platformId = table.Column<int>(type: "int", nullable: false),
                    uniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Well", x => x.id);
                    table.ForeignKey(
                        name: "FK_Well_Platform_platformId",
                        column: x => x.platformId,
                        principalTable: "Platform",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformDummy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    uniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    wellid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDummy", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlatformDummy_WellDummy_wellid",
                        column: x => x.wellid,
                        principalTable: "WellDummy",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDummy_wellid",
                table: "PlatformDummy",
                column: "wellid");

            migrationBuilder.CreateIndex(
                name: "IX_Well_platformId",
                table: "Well",
                column: "platformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "PlatformDummy");

            migrationBuilder.DropTable(
                name: "Well");

            migrationBuilder.DropTable(
                name: "WellDummy");

            migrationBuilder.DropTable(
                name: "Platform");
        }
    }
}
