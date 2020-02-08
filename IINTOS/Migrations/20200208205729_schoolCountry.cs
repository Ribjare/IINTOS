using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
    public partial class schoolCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_City_CityId",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_CityId",
                table: "School");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "School");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "School",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_School_CountryId",
                table: "School",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Country_CountryId",
                table: "School",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Country_CountryId",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_CountryId",
                table: "School");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "School");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "School",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_School_CityId",
                table: "School",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_City_CityId",
                table: "School",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
