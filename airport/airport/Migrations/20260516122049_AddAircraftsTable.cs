using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace airport.Migrations
{
    /// <inheritdoc />
    public partial class AddAircraftsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Aircraft_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Regrestration_No = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Aircraft_ID);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Airport_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IATA_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Airport_ID);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Passenger_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Passenger_ID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Staff_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Staff_ID);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Flight_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin_ID = table.Column<int>(type: "int", nullable: false),
                    Dest_ID = table.Column<int>(type: "int", nullable: false),
                    Aircraft_ID = table.Column<int>(type: "int", nullable: false),
                    Arr_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dep_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Flight_ID);
                    table.ForeignKey(
                        name: "FK_Flights_Aircrafts_Aircraft_ID",
                        column: x => x.Aircraft_ID,
                        principalTable: "Aircrafts",
                        principalColumn: "Aircraft_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_Dest_ID",
                        column: x => x.Dest_ID,
                        principalTable: "Airports",
                        principalColumn: "Airport_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_Origin_ID",
                        column: x => x.Origin_ID,
                        principalTable: "Airports",
                        principalColumn: "Airport_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewDetails",
                columns: table => new
                {
                    Schedule_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_ID = table.Column<int>(type: "int", nullable: false),
                    Staff_ID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewDetails", x => x.Schedule_ID);
                    table.ForeignKey(
                        name: "FK_CrewDetails_Flights_Flight_ID",
                        column: x => x.Flight_ID,
                        principalTable: "Flights",
                        principalColumn: "Flight_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewDetails_Staffs_Staff_ID",
                        column: x => x.Staff_ID,
                        principalTable: "Staffs",
                        principalColumn: "Staff_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Ticket_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_ID = table.Column<int>(type: "int", nullable: false),
                    Passenger_ID = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seat_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Ticket_ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_Flight_ID",
                        column: x => x.Flight_ID,
                        principalTable: "Flights",
                        principalColumn: "Flight_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_Passenger_ID",
                        column: x => x.Passenger_ID,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticket_ID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transaction_Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_ID);
                    table.ForeignKey(
                        name: "FK_Payments_Tickets_Ticket_ID",
                        column: x => x.Ticket_ID,
                        principalTable: "Tickets",
                        principalColumn: "Ticket_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewDetails_Flight_ID",
                table: "CrewDetails",
                column: "Flight_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CrewDetails_Staff_ID",
                table: "CrewDetails",
                column: "Staff_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Aircraft_ID",
                table: "Flights",
                column: "Aircraft_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Dest_ID",
                table: "Flights",
                column: "Dest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Origin_ID",
                table: "Flights",
                column: "Origin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Ticket_ID",
                table: "Payments",
                column: "Ticket_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Flight_ID",
                table: "Tickets",
                column: "Flight_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Passenger_ID",
                table: "Tickets",
                column: "Passenger_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
