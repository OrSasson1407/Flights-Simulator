using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAirportServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeparture = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    WaitTime = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    CurrentLeg = table.Column<int>(type: "int", nullable: true),
                    NextLegs = table.Column<int>(type: "int", nullable: true),
                    IsChangeStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legs_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Loggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegId = table.Column<int>(type: "int", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    In = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Out = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loggers_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Loggers_Legs_LegId",
                        column: x => x.LegId,
                        principalTable: "Legs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Legs_FlightId",
                table: "Legs",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Loggers_FlightId",
                table: "Loggers",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Loggers_LegId",
                table: "Loggers",
                column: "LegId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loggers");

            migrationBuilder.DropTable(
                name: "Legs");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
