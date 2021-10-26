using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class Destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "Name" },
                values: new object[,]
                {
                    { 1, "Jurassic World" },
                    { 2, "Chicago" },
                    { 3, "Rivendell" },
                    { 4, "Hogwarts" },
                    { 5, "My Bathroom" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "DestinationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "DestinationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "DestinationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4,
                column: "DestinationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 5,
                column: "DestinationId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DestinationId",
                table: "Reviews",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Destinations_DestinationId",
                table: "Reviews",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Destinations_DestinationId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_DestinationId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Reviews",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "Location",
                value: "Jurassic World");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "Location",
                value: "Chicago");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "Location",
                value: "Rivendell");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4,
                column: "Location",
                value: "Hogwarts");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 5,
                column: "Location",
                value: "My bathroom");
        }
    }
}
