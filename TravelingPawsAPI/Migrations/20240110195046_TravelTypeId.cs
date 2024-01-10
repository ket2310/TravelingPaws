using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelingPawsAPI.Migrations
{
    public partial class TravelTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetOwners",
                keyColumn: "PetOwnerId",
                keyValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_tripId",
                table: "Quotes",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_catId",
                table: "PetOwners",
                column: "catId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_dogId",
                table: "PetOwners",
                column: "dogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_Cats_catId",
                table: "PetOwners",
                column: "catId",
                principalTable: "Cats",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_Dogs_dogId",
                table: "PetOwners",
                column: "dogId",
                principalTable: "Dogs",
                principalColumn: "DogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Trips_tripId",
                table: "Quotes",
                column: "tripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_Cats_catId",
                table: "PetOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_Dogs_dogId",
                table: "PetOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Trips_tripId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_tripId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_PetOwners_catId",
                table: "PetOwners");

            migrationBuilder.DropIndex(
                name: "IX_PetOwners_dogId",
                table: "PetOwners");

            migrationBuilder.InsertData(
                table: "PetOwners",
                columns: new[] { "PetOwnerId", "CellNumber", "Email", "FirstName", "Instructions", "LastName", "PhoneNumber", "catId", "dogId" },
                values: new object[] { 1, "1234567890", "dablumaroon@gmail.com", "Kirk", null, "Thomas", "1234567890", 0, 0 });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "TravelType", "petOwnerId", "tripId" },
                values: new object[] { 1, 0, 1, 0 });
        }
    }
}
