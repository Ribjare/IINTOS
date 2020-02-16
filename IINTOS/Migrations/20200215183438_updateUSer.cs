using Microsoft.EntityFrameworkCore.Migrations;

namespace IINTOS.Migrations
{
    public partial class updateUSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Nationality_NationalityId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "SortName",
                table: "Country");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Country_NationalityId",
                table: "AspNetUsers",
                column: "NationalityId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Country_NationalityId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PhoneCode",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SortName",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Nationality_NationalityId",
                table: "AspNetUsers",
                column: "NationalityId",
                principalTable: "Nationality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
