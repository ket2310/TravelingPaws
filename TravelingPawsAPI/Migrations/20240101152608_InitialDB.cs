using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelingPawsAPI.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                });

            migrationBuilder.CreateTable(
                name: "PetOwners",
                columns: table => new
                {
                    PetOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    catId = table.Column<int>(type: "int", nullable: false),
                    dogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwners", x => x.PetOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelTypeId = table.Column<int>(type: "int", nullable: false),
                    traveldate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    returndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pickupaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pickupaddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pickupcity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pickupstate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pickupzip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destinationaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destinationaddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destinationcity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destinationstate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destinationzip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherinfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    petOwnerId = table.Column<int>(type: "int", nullable: false),
                    TravelType = table.Column<int>(type: "int", nullable: false),
                    tripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quotes_PetOwners_petOwnerId",
                        column: x => x.petOwnerId,
                        principalTable: "PetOwners",
                        principalColumn: "PetOwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PetOwners",
                columns: new[] { "PetOwnerId", "CellNumber", "Email", "FirstName", "Instructions", "LastName", "PhoneNumber", "catId", "dogId" },
                values: new object[] { 1, "1234567890", "dablumaroon@gmail.com", "Kirk", null, "Thomas", "1234567890", 0, 0 });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "TravelType", "petOwnerId", "tripId" },
                values: new object[] { 1, 0, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_petOwnerId",
                table: "Quotes",
                column: "petOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "PetOwners");
        }
    }
}
